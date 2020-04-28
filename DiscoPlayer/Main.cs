using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


using NAudio.Wave;
using NAudio.CoreAudioApi;
using Discord.Audio;
using Discord;
using Discord.WebSocket;


namespace DiscoPlayer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public class botActivityObj : IActivity
        {
            public string SetName = "";
            public ActivityType SetType = ActivityType.Listening;

            string IActivity.Name { get { return SetName; } }

            ActivityType IActivity.Type { get { return SetType; } }
        }

        public void setBotActivity(string status, ActivityType activityType)
        {
            try
            {
                if (status == "")
                    Text = tmpTitle;
                else
                    Text = tmpTitle + " - Playing: " + status;
                botActivity.SetName = status;
                botActivity.SetType = activityType;
                Client.SetActivityAsync(botActivity);
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
        }


        private void Main_Load(object sender, EventArgs e)
        {
            Client = new DiscordSocketClient();
            Client.Ready += ReadyAsync;

            configPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.ini";
            List<string> configList = new List<string>() { };
            
            int vol = 100;
            int h = Height;
            int w = Width;

            if (File.Exists(configPath))
            {
                using (StreamReader sr = new StreamReader(configPath, Encoding.UTF8))
                {
                    while (sr.Peek() != -1)
                    {
                        configList.Add(sr.ReadLine());
                    }
                }
                

                if (configList.Count >= 1)
                    token_textBox.Text = configList[0];
                if (configList.Count >= 2)
                    guild_id_textBox.Text = configList[1];
                if (configList.Count >= 3)
                    voicechannel_id_textBox.Text = configList[2];
                if (configList.Count >= 4)
                    addPlayList_Async(new string[] { configList[3] });
                if (configList.Count >= 5 && int.TryParse(configList[4], out vol))
                {
                    volume_trackBar.Value = vol;
                    volume_groupBox.Text = "音量: " + volume_trackBar.Value.ToString();
                }
                if (configList.Count >= 6 && int.TryParse(configList[5], out w))
                    Width = w;
                if (configList.Count >= 7 && int.TryParse(configList[6], out h))
                    Height = h;

            }

            tmpTitle = Text;
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var cap = WaveIn.GetCapabilities(i);
                waveIn_comboBox.Items.Add(cap.ProductName);
            }

        }


        public System.Drawing.Color RED { get { return System.Drawing.Color.FromArgb(255, 128, 128); } }
        public System.Drawing.Color GREEN { get { return System.Drawing.Color.FromArgb(128, 255, 128); } }
        public System.Drawing.Color ORANGE { get { return System.Drawing.Color.FromArgb(255, 192, 128); } }

        private DiscordSocketClient Client;
        public IAudioClient Vclient;
        public static AudioOutStream dstream = null;
        public static CancellationTokenSource cancellationToken = new CancellationTokenSource();
        public AudioFileReader AudioReader = null;
        public botActivityObj botActivity = new botActivityObj();

        public WaveInEvent waveIn;
        public AudioOutStream dscStream;
        public int waveInBlockSize = 0;

        public string configPath = "";
        public string tmpTitle = "";
        public List<string> playList = new List<string>() { };
        public int playIndex = -1;
        public int waveRate = 48000;
        public bool playlist_flag = false;
        public List<string> tmpPlayList = new List<string>() { };

        public bool randomFlag = false;
        public bool exitFlag = false;
        public bool pingFlag = false;
        public bool playerActive = false;
        public bool pauseFlag = false;
        public bool stopFlag = false;
        public bool playFlag = false;
        public bool nextFlag = false;
        public bool prevFlag = false;
        public bool waitFlag = false;
        public Task pingTask = null;
        public Task playerTask = null;
        public Task playerCurrentTask = null;


        private void Token_show_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (token_show_checkBox.Checked)
                token_textBox.PasswordChar = '*';
            else
                token_textBox.PasswordChar = '\0';
        }

        private void Channnel_in_button_Click(object sender, EventArgs e)
        {
            // チャンネルログインチェック

            if (token_textBox.Text == "" || guild_id_textBox.Text == "")
            {
                MessageBox.Show("トークンとユーザーIDを入力してください", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Task.Run(() => {
                LoginAsync().Wait();
            });

        }


        public async Task LoginAsync()
        {
            enableControl_Invoke(false, true);
            channelLog_Invoke("ログイン中...", ORANGE);
            try
            {
                await Client.LoginAsync(TokenType.Bot, token_textBox.Text);
                await Client.StartAsync();
                await Task.Delay(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                channelLog_Invoke("サーバーにログインできませんでした", RED);
                enableControl_Invoke(false, false);
            }
        }


        public async Task ReadyAsync()
        {
            try
            {
                channelLog_Invoke("ボイスチャンネルに接続中...", ORANGE);

                var guild = Client.GetGuild(Convert.ToUInt64(guild_id_textBox.Text));
                var voice_channel = (SocketVoiceChannel)guild.GetChannel(ulong.Parse(voicechannel_id_textBox.Text));

                Vclient = await voice_channel.ConnectAsync();

                pingFlag = true;
                pingTask = Task.Run(() =>
                {
                    try
                    {
                        connectionPing_Loop(voice_channel).Wait();
                    } catch { }
                    
                });
                
                enableControl_Invoke(true, false);
            }
            catch (Exception e)
            {
                channelLog_Invoke("ボイスチャンネルに接続できません", RED);
                await Client.StopAsync();
                await Client.LogoutAsync();
                enableControl_Invoke(false, false);
                Console.WriteLine(e.ToString());
                return;
            }

            playerActive = true;
            playFlag = false;
            stopFlag = false;
            pauseFlag = false;

            playerTask =  PlayerStart();
        }


        public async Task PlayerStart()
        {
            while (playerActive)
            {
                if (!playFlag && !nextFlag && !prevFlag)
                {
                    await Task.Delay(100);
                    waitFlag = true;
                    continue;
                }
                else if (Client.LoginState == LoginState.LoggedOut)
                {
                    break;
                }

                if (nextFlag || prevFlag)
                {
                    if (playerCurrentTask != null) playerCurrentTask.Wait();
                    //await Task.Delay(1000);
                    
                    Invoke((Action)delegate ()
                    {
                        if (nextFlag)
                            playlist_listBox.SelectedIndex++;
                        else
                            playlist_listBox.SelectedIndex--;
                        Player_play_button_Click(null, EventArgs.Empty);
                        prev_button.Enabled = true;
                        next_button.Enabled = true;
                        //player_play_button.Enabled = true;
                    });
                }

                waitFlag = false;
                nextFlag = false;
                prevFlag = false;
                bool errorFlag = false;

                try
                {
                    AudioReader = new AudioFileReader(playList[playIndex]); // Create a new Disposable MP3FileReader, to read audio from the filePath parameter
                    Invoke((Action)delegate ()
                    {
                        AudioReader.Volume = (float)(volume_trackBar.Value * 0.01);
                    });
                    var OutFormat = new WaveFormat(waveRate, 16, 2); // Create a new Output Format, using the spec that Discord will accept, and with the number of channels that our client supports.
                    using (var resampler = new MediaFoundationResampler(AudioReader, OutFormat)) // Create a Disposable Resampler, which will convert the read MP3 data to PCM, using our Output Format
                    using (var dstream = Vclient.CreatePCMStream(AudioApplication.Music))
                    {
                        resampler.ResamplerQuality = 60; // Set the quality of the resampler to 60, the highest quality
                        int blockSize = OutFormat.AverageBytesPerSecond / 50; // Establish the size of our AudioBuffer
                        byte[] buffer = new byte[blockSize];
                        int byteCount;


                        playerCurrentTask = Task.Run(() =>
                        {
                            try
                            {
                                playerCurrentTime().Wait();
                            }catch { }
                        });


                        while ((byteCount = resampler.Read(buffer, 0, blockSize)) > 0) // Read audio into our buffer, and keep a loop open while data is present
                        {
                            if (byteCount < blockSize)
                            {
                                // Incomplete Frame
                                for (int i = byteCount; i < blockSize; i++)
                                    buffer[i] = 0;
                            }

                            while (pauseFlag)
                            {
                                await Task.Delay(100);
                                if (stopFlag) break;
                            }
                            if (stopFlag)
                            {
                                playFlag = false;
                                pauseFlag = false;
                                break;
                            };


                            await dstream.WriteAsync(buffer, 0, blockSize, cancellationToken.Token);
                        }
                    }
                    AudioReader.Dispose();
                    AudioReader = null;
                    playFlag = false;
                    bool continueFlag = false;

                    Invoke((Action)delegate ()
                    {
                        if (stopFlag) // 停止ボタン押された時
                            continueFlag = true;
                        else if (musicRepeat_checkBox.Checked) // 1曲リピートオン
                        {
                            playFlag = true;
                            continueFlag = true;
                        }
                    });

                    stopFlag = false;
                    if (continueFlag)
                        continue;
                       
                }
                catch (IOException e)
                {
                    playFlag = false;
                }
                catch (FormatException e)
                {
                    playFlag = false;
                    playerCurrentTask = null;
                    Task.Run(() => {
                        MessageBox.Show("ファイルオープンに失敗しました: \r\n" + e.Message, Path.GetFileName(playList[playIndex]), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                    Console.WriteLine(e.ToString());
                    errorFlag = true;
                }
                catch (InvalidOperationException e)
                {
                    playFlag = false;
                    playerCurrentTask = null;
                    Task.Run(() => {
                        MessageBox.Show("サポートされていない形式です: \r\n" + e.Message, Path.GetFileName(playList[playIndex]), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                    Console.WriteLine(e.ToString());
                    errorFlag = true;
                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    playFlag = false;
                    playerCurrentTask = null;
                    Task.Run(() => {
                        MessageBox.Show("ファイル変換に失敗しました: \r\n" + e.Message, Path.GetFileName(playList[playIndex]), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                    Console.WriteLine(e.ToString());
                    errorFlag = true;
                }
                catch (Exception e)
                {
                    playFlag = false;
                    Console.WriteLine(e.ToString());
                    Channel_out_button_Click(null, EventArgs.Empty);
                    MessageBox.Show("エラーが発生しました: " + e.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorFlag = true;
                    break;
                }

                // プレイヤー初期化
                playerInitalize_Invoke();

                // 全曲リピート
                Invoke((Action)delegate ()
                {
                    if (playIndex < playList.Count - 1)
                        nextFlag = true;
                    else if (allMusicRepeat_checkBox.Checked && !errorFlag)
                    {
                        playlist_listBox.SelectedIndex = 0;
                        Player_play_button_Click(null, EventArgs.Empty);
                    }
                });
            }

            playFlag = false;
            playerCurrentTask = null;
            waitFlag = false;
            nextFlag = false;
            prevFlag = false;
        }

        public async Task connectionPing_Loop(SocketVoiceChannel vchannel)
        {
            while (pingFlag)
            {
                channelLog_Invoke(vchannel.Name +" - "+  Vclient.Latency.ToString() +"ms", GREEN);
                await Task.Delay(1000);
            }
        }

        public void channelLog_Invoke(string log, System.Drawing.Color color)
        {
            this.Invoke((Action)delegate ()
            {
                channel_state_label.ForeColor = color;
                channel_state_label.Text = log;
            });
        }

        public async Task playerCurrentTime()
        {
            Invoke((Action)delegate ()
            {
               if (AudioReader != null) player_trackBar.Maximum = (int)AudioReader.TotalTime.TotalSeconds;
            });
            while (playFlag)
            {
                if (!pauseFlag)
                {
                    Invoke((Action)delegate ()
                    {
                        try
                        {
                            time_label.Text = AudioReader.CurrentTime.ToString(@"hh\:mm\:ss") + " / " + AudioReader.TotalTime.ToString(@"hh\:mm\:ss");
                            player_trackBar.Value = (int)AudioReader.CurrentTime.TotalSeconds;
                        } catch { }

                    });
                }
                await Task.Delay(500);
            }
        }

        public void enableControl_Invoke(bool flag, bool all)
        {
            Invoke((Action)delegate ()
            {
                if (all)
                {
                    player_groupBox.Enabled = flag;
                    waveIn_groupBox.Enabled = flag;
                    channel_out_button.Enabled = !flag;
                    channel_in_button.Enabled = flag;
                    guild_id_textBox.ReadOnly = !flag;
                    token_textBox.ReadOnly = !flag;
                    voicechannel_id_textBox.ReadOnly = !flag;
                }
                else
                {
                    player_groupBox.Enabled = flag;
                    waveIn_groupBox.Enabled = flag;
                    channel_out_button.Enabled = flag;
                    channel_in_button.Enabled = !flag;
                    guild_id_textBox.ReadOnly = flag;
                    token_textBox.ReadOnly = flag;
                    voicechannel_id_textBox.ReadOnly = flag;
                }
            });
        }

        public void playerInitalize_Invoke()
        {
            Invoke((Action)delegate ()
            {
                player_stop_button.Enabled = false;
                player_pause_button.Enabled = false;
                player_play_button.Enabled = true;
                player_label.Text = "停止";
                time_label.Text = "00:00:00 / 00:00:00";
                mp3_title_textBox.Text = "選択されていません";
                player_trackBar.Value = 0;
                player_label.ForeColor = RED;
                file_browse_button.Enabled = true;
            });
        }

        private void Channel_out_button_Click(object sender, EventArgs e)
        {
            /*
            if (waveIn_stop_button.Enabled)
            {
                MessageBox.Show("切断する場合は、入力デバイス音源を停止させてください。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */

            exitFlag = false;
            Task.Run(() => {
                LogoutAsync().Wait();
            });

            Task.Run(() => {
                LogoutAsyncWatch().Wait();
            });

        }

        public async Task LogoutAsync()
        {
            enableControl_Invoke(false, true);
            channelLog_Invoke("切断中...", ORANGE);
            playerInitalize_Invoke();
            pingFlag = false;
            playerActive = false;
            Invoke((Action)delegate ()
            {
                waveIn_stop_button_Click(null, EventArgs.Empty);
                Player_stop_button_Click(null, EventArgs.Empty);
            });

            if (playerTask != null) playerTask.Wait();
            if (playerCurrentTask != null) playerCurrentTask.Wait();
            await Client.StopAsync();
            await Client.LogoutAsync();
            channelLog_Invoke("接続されていません", RED);
            enableControl_Invoke(false, false);

            Invoke((Action)delegate ()
            {
                playList_enable(true);
                randomPlay_checkBox.Enabled = true;
                next_button.Enabled = true;
                prev_button.Enabled = true;
            });
            exitFlag = true;
        }

        public async Task LogoutAsyncWatch()
        {
            int count = 0;
            while (true)
            {
                count++;
                await Task.Delay(500);
                if (exitFlag)
                    return;
                else if (count > 20)
                    break;
            }

            pingFlag = false;
            playerActive = false;
            playerInitalize_Invoke();
            Invoke((Action)delegate ()
            {
                waveIn_stop_button_Click(null, EventArgs.Empty);
                Player_stop_button_Click(null, EventArgs.Empty);
                playList_enable(true);
                randomPlay_checkBox.Enabled = true;
                next_button.Enabled = true;
                prev_button.Enabled = true;
            });
            enableControl_Invoke(false, false);
            channelLog_Invoke("接続されていません", RED);
        }


        private void Player_play_button_Click(object sender, EventArgs e)
        {
            if (pauseFlag)
            {
                pauseFlag = false;
                player_pause_button.Enabled = true;
                player_play_button.Enabled = false;
                player_stop_button.Enabled = true;
                waveIn_groupBox.Enabled = false;
                player_label.Text = "再生中";
                player_label.ForeColor = GREEN;
                playList_enable(false);
            }
            else
            {
                if (playIndex > -1 && File.Exists(playList[playIndex]))
                {
                    mp3_title_textBox.Text = Path.GetFileName(playList[playIndex]);
                    playFlag = true;
                    player_pause_button.Enabled = true;
                    player_stop_button.Enabled = true;
                    player_play_button.Enabled = false;
                    player_label.Text = "再生中";
                    player_label.ForeColor = GREEN;
                    file_browse_button.Enabled = false;
                    wave_rate_groupBox.Enabled = false;
                    randomPlay_checkBox.Enabled = false;
                    waveIn_groupBox.Enabled = false;
                    playList_enable(false);
                    setBotActivity(Path.GetFileName(playList[playIndex]), ActivityType.Listening);
                }
                else
                {
                    Task.Run(() => {
                        string fileName = "";
                        if (playIndex > -1)
                            fileName = Path.GetFileName(playList[playIndex]);

                        MessageBox.Show("MP3ファイルが見つからないか、プレイリストにMP3ファイルが追加されていません。", fileName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                }

            }
        }

        public void playList_enable(bool flag)
        {
            file_browse_button.Enabled = flag;
            folder_browse_button.Enabled = flag;
            delete_music_button.Enabled = flag;
            clear_playlist_button.Enabled = flag;
        }

        private void Player_pause_button_Click(object sender, EventArgs e)
        {
            if (!pauseFlag)
            {
                pauseFlag = true;
                player_pause_button.Enabled = false;
                player_play_button.Enabled = true;
                player_stop_button.Enabled = true;
                player_label.Text = "一時停止";
                player_label.ForeColor = ORANGE;
                waveIn_groupBox.Enabled = true;
            }
        }

        private void Player_stop_button_Click(object sender, EventArgs e)
        {
            stopFlag = true;
            player_stop_button.Enabled = false;
            player_pause_button.Enabled = false;
            player_play_button.Enabled = true;
            player_label.Text = "停止";
            player_trackBar.Value = 0;
            mp3_title_textBox.Text = "選択されていません";
            time_label.Text = "00:00:00 / 00:00:00";
            player_label.ForeColor = RED;
            file_browse_button.Enabled = true;
            wave_rate_groupBox.Enabled = true;
            randomPlay_checkBox.Enabled = true;
            waveIn_groupBox.Enabled = true;
            setBotActivity("", ActivityType.Listening);
            playList_enable(true);
        }

        private void Player_trackBar_Scroll(object sender, EventArgs e)
        {
            if (pauseFlag && AudioReader != null)
            {
                try
                {
                    var playTime = TimeSpan.FromSeconds(player_trackBar.Value);
                    time_label.Text = playTime.ToString(@"hh\:mm\:ss") + " / " + AudioReader.TotalTime.ToString(@"hh\:mm\:ss");
                    AudioReader.CurrentTime = playTime;
                } catch { }
            }
        }

        private void Volume_trackBar_Scroll(object sender, EventArgs e)
        {
            if (playFlag && AudioReader != null)
            {
                try
                {
                    AudioReader.Volume = (float)(volume_trackBar.Value * 0.01);
                    volume_groupBox.Text = "音量: " + volume_trackBar.Value.ToString();
                }
                catch (Exception err) { Console.WriteLine(err.ToString()); }
            }
            else
            {
                volume_groupBox.Text = "音量: " + volume_trackBar.Value.ToString();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            randomPlay_checkBox.Checked = false;
            string defaultPLPath = Path.GetDirectoryName(configPath) + "\\default.playlist";

            using (StreamWriter sw = new StreamWriter(defaultPLPath, false, Encoding.UTF8))
            {
                sw.WriteLine(playIndex.ToString());
                foreach (string path in playList)
                {
                    sw.WriteLine(path);
                }
            }

            using (StreamWriter sw = new StreamWriter(configPath, false, Encoding.UTF8))
            {
                sw.WriteLine(token_textBox.Text);
                sw.WriteLine(guild_id_textBox.Text);
                sw.WriteLine(voicechannel_id_textBox.Text);
                sw.WriteLine(defaultPLPath);
                sw.WriteLine(volume_trackBar.Value.ToString());
                sw.WriteLine(Width.ToString());
                sw.WriteLine(Height.ToString());
            }
        }


        public void addPlayList_Async(string[] pathList)
        {
            if (playlist_flag || playFlag)
                return;

            playlist_groupBox.Enabled = false;
            playlist_flag = true;
            Cursor = Cursors.WaitCursor;

            Task.Run(() =>
            {
                Invoke((Action)delegate () { playlist_groupBox.Text = "MP3ファイルを抽出中..."; });
                List<string> tmpPathList = getAvailableFile(pathList);

                Invoke((Action)delegate () { playlist_listBox.BeginUpdate(); });
                    
                foreach (string path in tmpPathList)
                    Invoke((Action)delegate () { playlist_listBox.Items.Add(Path.GetFileName(path)); }); 

                Invoke((Action)delegate () { playlist_listBox.EndUpdate(); });
                playList.AddRange(tmpPathList);
                tmpPlayList.AddRange(tmpPathList);

                Invoke((Action)delegate () {
                    playlist_groupBox.Enabled = true;
                    Cursor = Cursors.Default;

                    if (playlist_listBox.Items.Count > 0 && playIndex == -1)
                    {
                        playlist_listBox.SetSelected(0, true);
                        playIndex = 0;
                    }

                    playlist_groupBox.Text = "プレイリスト: " + (playIndex + 1).ToString() + "/" + playList.Count.ToString();
                });
                playlist_flag = false;
            });
        }


        public List<string> getAvailableFile(string[] pathList)
        {
            List<string> extPatterns = new List<string>(){ ".mp3", ".aiff", ".wma", ".wav", ".aac", ".mp2", ".m4a", ".flac", ".wmv", ".mp4", ".m4v", ".mov" };
            List<string> tmpPathList = new List<string>() { };

            foreach (string path in pathList)
            {
                if (File.Exists(path))
                {
                    if (Path.GetExtension(path).ToLower() == ".playlist")
                    {
                        using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                        {
                            while (sr.Peek() != -1)
                            {
                                string tmpPath = sr.ReadLine();
                                if (!playList.Contains(tmpPath) && !tmpPathList.Contains(tmpPath) && File.Exists(tmpPath) && extPatterns.Contains(Path.GetExtension(tmpPath).ToLower()))
                                    tmpPathList.Add(tmpPath);
                            }
                        }
                    }
                    else if (!playList.Contains(path) && !tmpPathList.Contains(path) && File.Exists(path) && extPatterns.Contains(Path.GetExtension(path).ToLower()))
                    {
                        tmpPathList.Add(path);
                    }
                }
                else if (Directory.Exists(path))
                {
                    string[] _tmpList = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories).Where(file => extPatterns.Any(pattern => file.ToLower().EndsWith(pattern))).ToArray();
                    foreach (string _path in _tmpList)
                        if (!playList.Contains(_path) && !tmpPathList.Contains(_path))
                            tmpPathList.Add(_path);
                }
            }

            return tmpPathList;

        }


        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            if (!playFlag)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                addPlayList_Async(files);
            }
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void File_browse_button_Click(object sender, EventArgs e)
        {
            if (mp3_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addPlayList_Async(mp3_openFileDialog.FileNames);
            }
        }

        private void Folder_browse_button_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == music_folderBrowserDialog.ShowDialog())
            {
                addPlayList_Async(new string[] { music_folderBrowserDialog.SelectedPath });
            }
            
        }


        public void savePlayList_Async(string savePath)
        {
            if (playlist_flag)
                return ;

            playlist_groupBox.Enabled = false;
            playlist_flag = true;
            Cursor = Cursors.WaitCursor;

            Task.Run(() =>
            {
                Invoke((Action)delegate () { playlist_groupBox.Text = "プレイリスト生成中..."; });

                using (StreamWriter sw = new StreamWriter(savePath, false, Encoding.UTF8))
                {
                    sw.WriteLine(playIndex.ToString());
                    foreach (string path in playList)
                    {
                        sw.WriteLine(path);
                    }
                }

                Invoke((Action)delegate () {
                    playlist_groupBox.Enabled = true;
                    Cursor = Cursors.Default;
                    playlist_groupBox.Text = "プレイリスト: "+ (playIndex + 1).ToString() +"/" + playList.Count.ToString();
                });
                playlist_flag = false;
            });
        }


        private void Save_playlist_button_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == playList_saveFileDialog.ShowDialog())
            {
                savePlayList_Async(playList_saveFileDialog.FileName);

            }
        }

        private void Delete_music_button_Click(object sender, EventArgs e)
        {
            if (tmpPlayList.Contains(playList[playIndex]))
            {
                string d = playList[playIndex];
                tmpPlayList.Remove(d);
            }

            playlist_listBox.Items.RemoveAt(playIndex);
            playList.RemoveAt(playIndex);
                

            if (playlist_listBox.Items.Count > 0)
            {
                if (playIndex + 1 >= playlist_listBox.Items.Count)
                {
                    playlist_listBox.SelectedIndex = playIndex - 1;
                }
                else
                {
                    playlist_listBox.SelectedIndex = playIndex;
                }
            }
            else
            {
                playIndex = -1;
            }
        }

        private void Clear_playlist_button_Click(object sender, EventArgs e)
        {
            playlist_listBox.Items.Clear();
            playList.Clear();
            tmpPlayList.Clear();
            randomPlay_checkBox.Checked = false;
            playIndex = -1;
            playlist_groupBox.Text = "プレイリスト: 0/0";
        }


        private void Playlist_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playFlag)
            {
                playlist_listBox.SelectedIndex = playIndex;
            }
            else if (playlist_listBox.SelectedIndex > -1)
            {
                playIndex = playlist_listBox.SelectedIndex;
                playlist_groupBox.Text = "プレイリスト: " + (playIndex + 1).ToString() + "/" + playList.Count.ToString();
            }

        }

        public int listSelectNo = 0;
        private void Playlist_listBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox list = (ListBox)sender;
            listSelectNo = list.SelectedIndex;
        }

        private void Playlist_listBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (playFlag || listSelectNo < 0)
                return;

            ListBox list = (ListBox)sender;
            int listChangeNo = list.SelectedIndex;

            object tmpData = list.Items[listSelectNo];
            string path = playList[listSelectNo];

            list.Items.RemoveAt(listSelectNo);
            playList.RemoveAt(listSelectNo);
            list.Items.Insert(listChangeNo, tmpData);
            playList.Insert(listChangeNo, path);
            list.SelectedIndex = listChangeNo;
        }

        private void Prev_button_Click(object sender, EventArgs e)
        {
            if (playlist_listBox.SelectedIndex > 0)
            {
                if (playFlag)
                {
                    next_button.Enabled = false;
                    prev_button.Enabled = false;
                    prevFlag = true;
                    Player_stop_button_Click(null, EventArgs.Empty);
                    player_play_button.Enabled = false;
                }
                else
                {
                    playlist_listBox.SelectedIndex--;
                }
            }
        }

        private void Next_button_Click(object sender, EventArgs e)
        {
            if (playlist_listBox.SelectedIndex <= playlist_listBox.Items.Count - 2)
            {
                if (playFlag)
                {
                    next_button.Enabled = false;
                    prev_button.Enabled = false;
                    nextFlag = true;
                    Player_stop_button_Click(null, EventArgs.Empty);
                    player_play_button.Enabled = false;
                }
                else
                {
                    playlist_listBox.SelectedIndex++;
                }

            }
        }

        public int volumeVal = 0;
        private void Volume_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (volume_checkBox.Checked)
            {
                volume_trackBar.Maximum = 1000;
                volume_trackBar.TickFrequency = 100;
                Height = 635;
                volumeVal = volume_trackBar.Value;
            }
            else
            {
                Height = 555;
                volume_groupBox.Text = "音量: "+ volumeVal.ToString();
                volume_trackBar.Value = volumeVal;
                volume_trackBar.Maximum = 100;
                volume_trackBar.TickFrequency = 25;

                if (playFlag && AudioReader != null)
                {
                    try
                    {
                        AudioReader.Volume = (float)(volume_trackBar.Value * 0.01);
                    }
                    catch (Exception err) { Console.WriteLine(err.ToString()); }
                }
            }
        }

        private void Wave_rate_trackBar_Scroll(object sender, EventArgs e)
        {
            wave_rate_groupBox.Text = "周波数: "+ wave_rate_trackBar.Value.ToString() +"Hz";
            waveRate = wave_rate_trackBar.Value;
        }

        private void RandomPlay_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (playlist_listBox.Items.Count > 1)
            {
                if (randomPlay_checkBox.Checked)
                {
                    tmpPlayList.Clear();
                    tmpPlayList = playList;
                    playList = playList.OrderBy(i => Guid.NewGuid()).ToList();

                    playlist_listBox.BeginUpdate();
                    playlist_listBox.Items.Clear();
                    foreach (string fileName in playList)
                        playlist_listBox.Items.Add(Path.GetFileName(fileName));
                    playlist_listBox.EndUpdate();
                    if (playlist_listBox.Items.Count > 0) playlist_listBox.SelectedIndex = 0;
                }
                else
                {
                    playList = tmpPlayList.ToList();
                    tmpPlayList.Clear();

                    playlist_listBox.BeginUpdate();
                    playlist_listBox.Items.Clear();
                    foreach (string fileName in playList)
                        playlist_listBox.Items.Add(Path.GetFileName(fileName));
                    playlist_listBox.EndUpdate();
                    if (playlist_listBox.Items.Count > 0) playlist_listBox.SelectedIndex = 0;
                    
                }
            }
        }

        private void Clear_rate_button_Click(object sender, EventArgs e)
        {
            waveRate = 48000;
            wave_rate_trackBar.Value = 48000;
            wave_rate_groupBox.Text = "周波数: " + wave_rate_trackBar.Value.ToString() + "Hz";
            
        }

        private void waveIn_reload_button_Click(object sender, EventArgs e)
        {
            waveIn_comboBox.Items.Clear();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var cap = WaveIn.GetCapabilities(i);
                waveIn_comboBox.Items.Add(cap.ProductName);
            }
        }

        private void waveIn_play_button_Click(object sender, EventArgs e)
        {
            if (waveIn_comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("入力デバイスが選択されていません。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int deviceNumber = waveIn_comboBox.SelectedIndex;

            waveIn = new WaveInEvent();
            waveIn.DeviceNumber = deviceNumber;

            waveIn.WaveFormat = new WaveFormat(waveRate, 2);
            waveInBlockSize = waveIn.WaveFormat.AverageBytesPerSecond / 50;

            dscStream = Vclient.CreatePCMStream(AudioApplication.Music);
            dscStream.Clear();

            waveIn.DataAvailable += (_, ee) =>
            {
                dscStream.WriteAsync(ee.Buffer, 0, ee.BytesRecorded, cancellationToken.Token).Wait();
            };

            try
            {
                waveIn.StartRecording();
                setBotActivity(waveIn_comboBox.Text, ActivityType.Listening);
                waveIn_play_button.Enabled = false;
                waveIn_comboBox.Enabled = false;
                waveIn_stop_button.Enabled = true;
                player_groupBox.Enabled = false;
                wave_rate_groupBox.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("指定された入力デバイスにアクセスできませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void waveIn_stop_button_Click(object sender, EventArgs e)
        {
            waveIn?.StopRecording();
            waveIn?.Dispose();
            waveIn = null;

            dscStream?.Close();
            dscStream?.Clear();
            dscStream?.Dispose();
            dscStream = null;

            waveIn_play_button.Enabled = true;
            waveIn_comboBox.Enabled = true;
            waveIn_stop_button.Enabled = false;
            player_groupBox.Enabled = true;
            wave_rate_groupBox.Enabled = true;
            setBotActivity("", ActivityType.Listening);
            //Task.Delay(5000);
        }
    }
}
