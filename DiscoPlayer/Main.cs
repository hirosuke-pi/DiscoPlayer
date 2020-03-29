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

        private void Main_Load(object sender, EventArgs e)
        {
            Client = new DiscordSocketClient();
            Client.Ready += ReadyAsync;

            configPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\config.ini";
            List<string> configList = new List<string>() { };

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
                    channel_id_textBox.Text = configList[2];
                if (configList.Count >= 4)
                    mp3_path_textBox.Text = configList[3];
            }
        }


        public System.Drawing.Color RED { get { return System.Drawing.Color.FromArgb(255, 128, 128); } }
        public System.Drawing.Color GREEN { get { return System.Drawing.Color.FromArgb(128, 255, 128); } }
        public System.Drawing.Color ORANGE { get { return System.Drawing.Color.FromArgb(255, 192, 128); } }

        private DiscordSocketClient Client;
        public IAudioClient Vclient;
        public static AudioOutStream dstream = null;
        public static CancellationTokenSource cancellationToken = new CancellationTokenSource();
        public Mp3FileReader MP3Reader = null;
        public string configPath = "";

        public bool pingFlag = false;
        public bool playerActive = false;
        public bool pauseFlag = false;
        public bool stopFlag = false;
        public bool playFlag = false;
        public Task pingTask = null;
        public Task playerTask = null;


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

            if (token_textBox.Text == "" || channel_id_textBox.Text == "")
            {
                MessageBox.Show("トークンとチャンネルIDを入力してください。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                channelLog_Invoke("サーバーにログインできませんでした", RED);
                enableControl_Invoke(false, false);
            }
        }


        public async Task ReadyAsync()
        {
            IAudioClient vclient = null;
            try
            {
                channelLog_Invoke("ボイスチャンネルに接続中...", ORANGE);
                var guild = Client.GetGuild(Convert.ToUInt64(guild_id_textBox.Text));
                var voice_channel = (SocketVoiceChannel)guild.GetChannel(ulong.Parse(channel_id_textBox.Text));
                vclient = await voice_channel.ConnectAsync();
                pingFlag = true;
                pingTask = Task.Run(() =>
                {
                    try
                    {
                        connectionPing_Loop().Wait();
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
                return;
            }

            playerActive = true;
            playFlag = false;
            stopFlag = false;
            pauseFlag = false;

            playerTask =  PlayerStart(vclient);
        }


        public async Task PlayerStart(IAudioClient vclient)
        {
            while (playerActive)
            {
                if (!playFlag)
                {
                    await Task.Delay(100);
                    continue;
                }
                else if (Client.LoginState == LoginState.LoggedOut)
                {
                    break;
                }

                try
                {

                    var OutFormat = new WaveFormat(48000, 16, 2); // Create a new Output Format, using the spec that Discord will accept, and with the number of channels that our client supports.
                    MP3Reader = new Mp3FileReader(mp3_path_textBox.Text); // Create a new Disposable MP3FileReader, to read audio from the filePath parameter
                    using (var resampler = new MediaFoundationResampler(MP3Reader, OutFormat)) // Create a Disposable Resampler, which will convert the read MP3 data to PCM, using our Output Format
                    using (var dstream = vclient.CreatePCMStream(AudioApplication.Music))
                    {
                        resampler.ResamplerQuality = 60; // Set the quality of the resampler to 60, the highest quality
                        int blockSize = OutFormat.AverageBytesPerSecond / 50; // Establish the size of our AudioBuffer
                        byte[] buffer = new byte[blockSize];
                        int byteCount;

                        Task.Run(() =>
                        {
                            playerCurrentTime(MP3Reader).Wait();
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
                                stopFlag = false;
                                pauseFlag = false;
                                break;
                            };
                                

                            await dstream.WriteAsync(buffer, 0, blockSize, cancellationToken.Token);
                        }
                    }
                    MP3Reader.Dispose();
                    MP3Reader = null;
                    playerInitalize_Invoke();
                    playFlag = false;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.ToString());
                    Channel_out_button_Click(null, EventArgs.Empty);
                    MessageBox.Show("ネットワークエラーが発生しました: "+ e.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        public async Task connectionPing_Loop()
        {
            while (pingFlag)
            {
                channelLog_Invoke("接続中 - "+  Client.Latency.ToString() +"ms", GREEN);
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

        public async Task playerCurrentTime(Mp3FileReader render)
        {
            Invoke((Action)delegate ()
            {
                player_trackBar.Maximum = (int)render.TotalTime.TotalSeconds;
            });
            while (playFlag)
            {
                if (!pauseFlag)
                {
                    Invoke((Action)delegate ()
                    {
                        time_label.Text = render.CurrentTime.ToString(@"hh\:mm\:ss") + " / " + render.TotalTime.ToString(@"hh\:mm\:ss");
                        player_trackBar.Value = (int)render.CurrentTime.TotalSeconds;
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
                    channel_out_button.Enabled = !flag;
                    channel_in_button.Enabled = flag;
                    channel_id_textBox.ReadOnly = !flag;
                    guild_id_textBox.ReadOnly = !flag;
                    token_textBox.ReadOnly = !flag;
                }
                else
                {
                    player_groupBox.Enabled = flag;
                    channel_out_button.Enabled = flag;
                    channel_in_button.Enabled = !flag;
                    channel_id_textBox.ReadOnly = flag;
                    guild_id_textBox.ReadOnly = flag;
                    token_textBox.ReadOnly = flag;
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
            Task.Run(() => {
                try
                {
                    LogoutAsync().Wait();
                }
                catch { }
            });
        }

        public async Task LogoutAsync()
        {
            enableControl_Invoke(false, true);
            channelLog_Invoke("切断中...", ORANGE);
            playerInitalize_Invoke();
            pingFlag = false;
            playerActive = false;
            stopFlag = true;
            pingTask.Wait();
            playerTask.Wait();
            await Client.StopAsync();
            await Client.LogoutAsync();
            channelLog_Invoke("接続されていません", RED);
            enableControl_Invoke(false, false);
        }

        private void File_browse_button_Click(object sender, EventArgs e)
        {
            if (mp3_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mp3_path_textBox.Text = mp3_openFileDialog.FileName;
            }
        }

        private void Player_play_button_Click(object sender, EventArgs e)
        {
            if (pauseFlag)
            {
                pauseFlag = false;
                player_pause_button.Enabled = true;
                player_play_button.Enabled = false;
                player_stop_button.Enabled = true;
                player_label.Text = "再生中";
                player_label.ForeColor = GREEN;
            }
            else
            {
                if (System.IO.File.Exists(mp3_path_textBox.Text))
                {
                    mp3_title_textBox.Text = System.IO.Path.GetFileName(mp3_path_textBox.Text);
                    playFlag = true;
                    player_pause_button.Enabled = true;
                    player_stop_button.Enabled = true;
                    player_play_button.Enabled = false;
                    player_label.Text = "再生中";
                    player_label.ForeColor = GREEN;
                    file_browse_button.Enabled = false;
                }
                else
                {
                    MessageBox.Show("MP3ファイルが存在しません。ファイルパスを確認してください", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
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
        }

        private void Player_trackBar_Scroll(object sender, EventArgs e)
        {
            if (pauseFlag && MP3Reader != null)
            {
                try
                {
                    var playTime = TimeSpan.FromSeconds(player_trackBar.Value);
                    time_label.Text = playTime.ToString(@"hh\:mm\:ss") + " / " + MP3Reader.TotalTime.ToString(@"hh\:mm\:ss");
                    MP3Reader.CurrentTime = playTime;
                } catch { }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(configPath, false, Encoding.UTF8))
            {
                sw.WriteLine(token_textBox.Text);
                sw.WriteLine(guild_id_textBox.Text);
                sw.WriteLine(channel_id_textBox.Text);
                sw.WriteLine(mp3_path_textBox.Text);
            }
        }


        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            if (!playFlag)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (Path.GetExtension(files[0]).ToLower() == ".mp3")
                    mp3_path_textBox.Text = files[0];
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
    }
}
