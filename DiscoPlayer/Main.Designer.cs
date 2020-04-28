namespace DiscoPlayer
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.token_textBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.token_show_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.voicechannel_id_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guild_id_textBox = new System.Windows.Forms.TextBox();
            this.channel_state_label = new System.Windows.Forms.Label();
            this.channel_in_button = new System.Windows.Forms.Button();
            this.channel_out_button = new System.Windows.Forms.Button();
            this.player_trackBar = new System.Windows.Forms.TrackBar();
            this.player_groupBox = new System.Windows.Forms.GroupBox();
            this.volume_checkBox = new System.Windows.Forms.CheckBox();
            this.randomPlay_checkBox = new System.Windows.Forms.CheckBox();
            this.allMusicRepeat_checkBox = new System.Windows.Forms.CheckBox();
            this.musicRepeat_checkBox = new System.Windows.Forms.CheckBox();
            this.volume_groupBox = new System.Windows.Forms.GroupBox();
            this.volume_trackBar = new System.Windows.Forms.TrackBar();
            this.next_button = new System.Windows.Forms.Button();
            this.prev_button = new System.Windows.Forms.Button();
            this.mp3_title_textBox = new System.Windows.Forms.TextBox();
            this.time_label = new System.Windows.Forms.Label();
            this.player_label = new System.Windows.Forms.Label();
            this.player_stop_button = new System.Windows.Forms.Button();
            this.player_play_button = new System.Windows.Forms.Button();
            this.player_pause_button = new System.Windows.Forms.Button();
            this.wave_rate_groupBox = new System.Windows.Forms.GroupBox();
            this.wave_rate_trackBar = new System.Windows.Forms.TrackBar();
            this.mp3_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.playlist_groupBox = new System.Windows.Forms.GroupBox();
            this.delete_music_button = new System.Windows.Forms.Button();
            this.clear_playlist_button = new System.Windows.Forms.Button();
            this.save_playlist_button = new System.Windows.Forms.Button();
            this.playlist_listBox = new System.Windows.Forms.ListBox();
            this.file_browse_button = new System.Windows.Forms.Button();
            this.folder_browse_button = new System.Windows.Forms.Button();
            this.music_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.playList_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.waveIn_groupBox = new System.Windows.Forms.GroupBox();
            this.waveIn_reload_button = new System.Windows.Forms.Button();
            this.waveIn_stop_button = new System.Windows.Forms.Button();
            this.waveIn_play_button = new System.Windows.Forms.Button();
            this.waveIn_comboBox = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clear_rate_button = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_trackBar)).BeginInit();
            this.player_groupBox.SuspendLayout();
            this.volume_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volume_trackBar)).BeginInit();
            this.wave_rate_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wave_rate_trackBar)).BeginInit();
            this.playlist_groupBox.SuspendLayout();
            this.waveIn_groupBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "トークン";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.token_textBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 29);
            this.panel1.TabIndex = 5;
            // 
            // token_textBox
            // 
            this.token_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.token_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.token_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.token_textBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.token_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.token_textBox.Location = new System.Drawing.Point(0, 0);
            this.token_textBox.Name = "token_textBox";
            this.token_textBox.PasswordChar = '*';
            this.token_textBox.Size = new System.Drawing.Size(702, 23);
            this.token_textBox.TabIndex = 0;
            this.token_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.token_show_checkBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(705, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 29);
            this.panel2.TabIndex = 4;
            // 
            // token_show_checkBox
            // 
            this.token_show_checkBox.AutoSize = true;
            this.token_show_checkBox.Checked = true;
            this.token_show_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.token_show_checkBox.Location = new System.Drawing.Point(4, 5);
            this.token_show_checkBox.Name = "token_show_checkBox";
            this.token_show_checkBox.Size = new System.Drawing.Size(15, 14);
            this.token_show_checkBox.TabIndex = 1;
            this.token_show_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.voicechannel_id_textBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.guild_id_textBox);
            this.groupBox3.Controls.Add(this.channel_state_label);
            this.groupBox3.Controls.Add(this.channel_in_button);
            this.groupBox3.Controls.Add(this.channel_out_button);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Location = new System.Drawing.Point(12, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 118);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ボイスチャンネル";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "ボイスチャンネルID: ";
            // 
            // voicechannel_id_textBox
            // 
            this.voicechannel_id_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.voicechannel_id_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.voicechannel_id_textBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.voicechannel_id_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.voicechannel_id_textBox.Location = new System.Drawing.Point(110, 51);
            this.voicechannel_id_textBox.Name = "voicechannel_id_textBox";
            this.voicechannel_id_textBox.Size = new System.Drawing.Size(303, 23);
            this.voicechannel_id_textBox.TabIndex = 14;
            this.voicechannel_id_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "サーバーID: ";
            // 
            // guild_id_textBox
            // 
            this.guild_id_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guild_id_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guild_id_textBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.guild_id_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guild_id_textBox.Location = new System.Drawing.Point(110, 22);
            this.guild_id_textBox.Name = "guild_id_textBox";
            this.guild_id_textBox.Size = new System.Drawing.Size(303, 23);
            this.guild_id_textBox.TabIndex = 12;
            this.guild_id_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // channel_state_label
            // 
            this.channel_state_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.channel_state_label.Location = new System.Drawing.Point(6, 85);
            this.channel_state_label.Name = "channel_state_label";
            this.channel_state_label.Size = new System.Drawing.Size(204, 15);
            this.channel_state_label.TabIndex = 11;
            this.channel_state_label.Text = "接続されていません";
            this.channel_state_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // channel_in_button
            // 
            this.channel_in_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.channel_in_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.channel_in_button.Image = global::DiscoPlayer.Properties.Resources.icons8_connected_16;
            this.channel_in_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.channel_in_button.Location = new System.Drawing.Point(216, 81);
            this.channel_in_button.Name = "channel_in_button";
            this.channel_in_button.Size = new System.Drawing.Size(96, 23);
            this.channel_in_button.TabIndex = 3;
            this.channel_in_button.Text = "接続";
            this.channel_in_button.UseVisualStyleBackColor = true;
            this.channel_in_button.Click += new System.EventHandler(this.Channnel_in_button_Click);
            // 
            // channel_out_button
            // 
            this.channel_out_button.Enabled = false;
            this.channel_out_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.channel_out_button.Image = global::DiscoPlayer.Properties.Resources.icons8_disconnected_16;
            this.channel_out_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.channel_out_button.Location = new System.Drawing.Point(317, 81);
            this.channel_out_button.Name = "channel_out_button";
            this.channel_out_button.Size = new System.Drawing.Size(96, 23);
            this.channel_out_button.TabIndex = 0;
            this.channel_out_button.Text = "切断";
            this.channel_out_button.UseVisualStyleBackColor = true;
            this.channel_out_button.Click += new System.EventHandler(this.Channel_out_button_Click);
            // 
            // player_trackBar
            // 
            this.player_trackBar.AutoSize = false;
            this.player_trackBar.Location = new System.Drawing.Point(1, 22);
            this.player_trackBar.Maximum = 60;
            this.player_trackBar.Name = "player_trackBar";
            this.player_trackBar.Size = new System.Drawing.Size(420, 39);
            this.player_trackBar.TabIndex = 7;
            this.player_trackBar.TickFrequency = 60;
            this.player_trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.player_trackBar.Scroll += new System.EventHandler(this.Player_trackBar_Scroll);
            // 
            // player_groupBox
            // 
            this.player_groupBox.Controls.Add(this.volume_checkBox);
            this.player_groupBox.Controls.Add(this.randomPlay_checkBox);
            this.player_groupBox.Controls.Add(this.allMusicRepeat_checkBox);
            this.player_groupBox.Controls.Add(this.musicRepeat_checkBox);
            this.player_groupBox.Controls.Add(this.volume_groupBox);
            this.player_groupBox.Controls.Add(this.next_button);
            this.player_groupBox.Controls.Add(this.prev_button);
            this.player_groupBox.Controls.Add(this.mp3_title_textBox);
            this.player_groupBox.Controls.Add(this.time_label);
            this.player_groupBox.Controls.Add(this.player_label);
            this.player_groupBox.Controls.Add(this.player_stop_button);
            this.player_groupBox.Controls.Add(this.player_play_button);
            this.player_groupBox.Controls.Add(this.player_pause_button);
            this.player_groupBox.Controls.Add(this.player_trackBar);
            this.player_groupBox.Enabled = false;
            this.player_groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.player_groupBox.Location = new System.Drawing.Point(12, 266);
            this.player_groupBox.Name = "player_groupBox";
            this.player_groupBox.Size = new System.Drawing.Size(422, 237);
            this.player_groupBox.TabIndex = 0;
            this.player_groupBox.TabStop = false;
            this.player_groupBox.Text = "プレイヤー";
            // 
            // volume_checkBox
            // 
            this.volume_checkBox.AutoSize = true;
            this.volume_checkBox.Location = new System.Drawing.Point(356, 66);
            this.volume_checkBox.Name = "volume_checkBox";
            this.volume_checkBox.Size = new System.Drawing.Size(60, 19);
            this.volume_checkBox.TabIndex = 22;
            this.volume_checkBox.Text = "ブースト";
            this.volume_checkBox.UseVisualStyleBackColor = true;
            this.volume_checkBox.CheckedChanged += new System.EventHandler(this.Volume_checkBox_CheckedChanged);
            // 
            // randomPlay_checkBox
            // 
            this.randomPlay_checkBox.AutoSize = true;
            this.randomPlay_checkBox.Location = new System.Drawing.Point(163, 66);
            this.randomPlay_checkBox.Name = "randomPlay_checkBox";
            this.randomPlay_checkBox.Size = new System.Drawing.Size(61, 19);
            this.randomPlay_checkBox.TabIndex = 21;
            this.randomPlay_checkBox.Text = "ランダム";
            this.randomPlay_checkBox.UseVisualStyleBackColor = true;
            this.randomPlay_checkBox.CheckedChanged += new System.EventHandler(this.RandomPlay_checkBox_CheckedChanged);
            // 
            // allMusicRepeat_checkBox
            // 
            this.allMusicRepeat_checkBox.AutoSize = true;
            this.allMusicRepeat_checkBox.Checked = true;
            this.allMusicRepeat_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allMusicRepeat_checkBox.Location = new System.Drawing.Point(9, 66);
            this.allMusicRepeat_checkBox.Name = "allMusicRepeat_checkBox";
            this.allMusicRepeat_checkBox.Size = new System.Drawing.Size(83, 19);
            this.allMusicRepeat_checkBox.TabIndex = 20;
            this.allMusicRepeat_checkBox.Text = "全曲リピート";
            this.allMusicRepeat_checkBox.UseVisualStyleBackColor = true;
            // 
            // musicRepeat_checkBox
            // 
            this.musicRepeat_checkBox.AutoSize = true;
            this.musicRepeat_checkBox.Location = new System.Drawing.Point(98, 67);
            this.musicRepeat_checkBox.Name = "musicRepeat_checkBox";
            this.musicRepeat_checkBox.Size = new System.Drawing.Size(59, 19);
            this.musicRepeat_checkBox.TabIndex = 19;
            this.musicRepeat_checkBox.Text = "リピート";
            this.musicRepeat_checkBox.UseVisualStyleBackColor = true;
            // 
            // volume_groupBox
            // 
            this.volume_groupBox.Controls.Add(this.volume_trackBar);
            this.volume_groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.volume_groupBox.Location = new System.Drawing.Point(9, 151);
            this.volume_groupBox.Name = "volume_groupBox";
            this.volume_groupBox.Size = new System.Drawing.Size(200, 71);
            this.volume_groupBox.TabIndex = 18;
            this.volume_groupBox.TabStop = false;
            this.volume_groupBox.Text = "音量: 100";
            // 
            // volume_trackBar
            // 
            this.volume_trackBar.AutoSize = false;
            this.volume_trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volume_trackBar.Location = new System.Drawing.Point(3, 19);
            this.volume_trackBar.Maximum = 100;
            this.volume_trackBar.Minimum = 1;
            this.volume_trackBar.Name = "volume_trackBar";
            this.volume_trackBar.Size = new System.Drawing.Size(194, 49);
            this.volume_trackBar.TabIndex = 17;
            this.volume_trackBar.TickFrequency = 25;
            this.volume_trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volume_trackBar.Value = 100;
            this.volume_trackBar.Scroll += new System.EventHandler(this.Volume_trackBar_Scroll);
            // 
            // next_button
            // 
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_button.Image = global::DiscoPlayer.Properties.Resources.icons8_end_40;
            this.next_button.Location = new System.Drawing.Point(380, 92);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(33, 53);
            this.next_button.TabIndex = 15;
            this.next_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.Next_button_Click);
            // 
            // prev_button
            // 
            this.prev_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prev_button.Image = global::DiscoPlayer.Properties.Resources.icons8_skip_to_start_40;
            this.prev_button.Location = new System.Drawing.Point(9, 92);
            this.prev_button.Name = "prev_button";
            this.prev_button.Size = new System.Drawing.Size(33, 53);
            this.prev_button.TabIndex = 14;
            this.prev_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.prev_button.UseVisualStyleBackColor = true;
            this.prev_button.Click += new System.EventHandler(this.Prev_button_Click);
            // 
            // mp3_title_textBox
            // 
            this.mp3_title_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mp3_title_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mp3_title_textBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mp3_title_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mp3_title_textBox.Location = new System.Drawing.Point(216, 172);
            this.mp3_title_textBox.Name = "mp3_title_textBox";
            this.mp3_title_textBox.ReadOnly = true;
            this.mp3_title_textBox.Size = new System.Drawing.Size(197, 16);
            this.mp3_title_textBox.TabIndex = 13;
            this.mp3_title_textBox.Text = "選択されていません";
            this.mp3_title_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_label
            // 
            this.time_label.Location = new System.Drawing.Point(213, 201);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(126, 15);
            this.time_label.TabIndex = 12;
            this.time_label.Text = "00:00:00 / 00:00:00";
            this.time_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player_label
            // 
            this.player_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.player_label.Location = new System.Drawing.Point(345, 201);
            this.player_label.Name = "player_label";
            this.player_label.Size = new System.Drawing.Size(68, 15);
            this.player_label.TabIndex = 11;
            this.player_label.Text = "停止";
            this.player_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player_stop_button
            // 
            this.player_stop_button.Enabled = false;
            this.player_stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player_stop_button.Image = global::DiscoPlayer.Properties.Resources.icons8_stop_40;
            this.player_stop_button.Location = new System.Drawing.Point(269, 92);
            this.player_stop_button.Name = "player_stop_button";
            this.player_stop_button.Size = new System.Drawing.Size(105, 53);
            this.player_stop_button.TabIndex = 6;
            this.player_stop_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.player_stop_button.UseVisualStyleBackColor = true;
            this.player_stop_button.Click += new System.EventHandler(this.Player_stop_button_Click);
            // 
            // player_play_button
            // 
            this.player_play_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player_play_button.Image = global::DiscoPlayer.Properties.Resources.icons8_play_40;
            this.player_play_button.Location = new System.Drawing.Point(48, 92);
            this.player_play_button.Name = "player_play_button";
            this.player_play_button.Size = new System.Drawing.Size(104, 53);
            this.player_play_button.TabIndex = 5;
            this.player_play_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.player_play_button.UseVisualStyleBackColor = true;
            this.player_play_button.Click += new System.EventHandler(this.Player_play_button_Click);
            // 
            // player_pause_button
            // 
            this.player_pause_button.Enabled = false;
            this.player_pause_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player_pause_button.Image = global::DiscoPlayer.Properties.Resources.icons8_pause_40;
            this.player_pause_button.Location = new System.Drawing.Point(158, 92);
            this.player_pause_button.Name = "player_pause_button";
            this.player_pause_button.Size = new System.Drawing.Size(105, 53);
            this.player_pause_button.TabIndex = 4;
            this.player_pause_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.player_pause_button.UseVisualStyleBackColor = true;
            this.player_pause_button.Click += new System.EventHandler(this.Player_pause_button_Click);
            // 
            // wave_rate_groupBox
            // 
            this.wave_rate_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wave_rate_groupBox.Controls.Add(this.panel4);
            this.wave_rate_groupBox.Controls.Add(this.wave_rate_trackBar);
            this.wave_rate_groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.wave_rate_groupBox.Location = new System.Drawing.Point(12, 518);
            this.wave_rate_groupBox.Name = "wave_rate_groupBox";
            this.wave_rate_groupBox.Size = new System.Drawing.Size(730, 68);
            this.wave_rate_groupBox.TabIndex = 4;
            this.wave_rate_groupBox.TabStop = false;
            this.wave_rate_groupBox.Text = "周波数: 48000Hz";
            // 
            // wave_rate_trackBar
            // 
            this.wave_rate_trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wave_rate_trackBar.AutoSize = false;
            this.wave_rate_trackBar.Location = new System.Drawing.Point(3, 19);
            this.wave_rate_trackBar.Maximum = 68000;
            this.wave_rate_trackBar.Minimum = 28000;
            this.wave_rate_trackBar.Name = "wave_rate_trackBar";
            this.wave_rate_trackBar.Size = new System.Drawing.Size(688, 46);
            this.wave_rate_trackBar.TabIndex = 8;
            this.wave_rate_trackBar.TickFrequency = 10000;
            this.wave_rate_trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.wave_rate_trackBar.Value = 48000;
            this.wave_rate_trackBar.Scroll += new System.EventHandler(this.Wave_rate_trackBar_Scroll);
            // 
            // mp3_openFileDialog
            // 
            this.mp3_openFileDialog.Filter = "すべてのファイル|*.mp3;*.aiff;*.wma;*.wav;*.aac;*.mp2;*.m4a;*.flac;*.wmv;*.mp4;*.m4v;*.mo" +
    "v;*.playlist|音声ファイル|*.mp3;*.aiff;*.wma;*.wav;*.aac;*.mp2;*.m4a;*.flac|動画ファイル|*.w" +
    "mv;*.mp4;*.m4v;*.mov|プレイリスト|*.playlist";
            this.mp3_openFileDialog.Multiselect = true;
            this.mp3_openFileDialog.Title = "プレイリストへ追加";
            // 
            // playlist_groupBox
            // 
            this.playlist_groupBox.Controls.Add(this.delete_music_button);
            this.playlist_groupBox.Controls.Add(this.clear_playlist_button);
            this.playlist_groupBox.Controls.Add(this.save_playlist_button);
            this.playlist_groupBox.Controls.Add(this.playlist_listBox);
            this.playlist_groupBox.Controls.Add(this.file_browse_button);
            this.playlist_groupBox.Controls.Add(this.folder_browse_button);
            this.playlist_groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.playlist_groupBox.Location = new System.Drawing.Point(455, 69);
            this.playlist_groupBox.Name = "playlist_groupBox";
            this.playlist_groupBox.Size = new System.Drawing.Size(287, 434);
            this.playlist_groupBox.TabIndex = 3;
            this.playlist_groupBox.TabStop = false;
            this.playlist_groupBox.Text = "プレイリスト: 0/0";
            // 
            // delete_music_button
            // 
            this.delete_music_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_music_button.Image = global::DiscoPlayer.Properties.Resources.icons8_delete_16;
            this.delete_music_button.Location = new System.Drawing.Point(224, 400);
            this.delete_music_button.Name = "delete_music_button";
            this.delete_music_button.Size = new System.Drawing.Size(26, 23);
            this.delete_music_button.TabIndex = 19;
            this.delete_music_button.UseVisualStyleBackColor = true;
            this.delete_music_button.Click += new System.EventHandler(this.Delete_music_button_Click);
            // 
            // clear_playlist_button
            // 
            this.clear_playlist_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_playlist_button.Image = global::DiscoPlayer.Properties.Resources.icons8_trash_16;
            this.clear_playlist_button.Location = new System.Drawing.Point(256, 400);
            this.clear_playlist_button.Name = "clear_playlist_button";
            this.clear_playlist_button.Size = new System.Drawing.Size(26, 23);
            this.clear_playlist_button.TabIndex = 18;
            this.clear_playlist_button.UseVisualStyleBackColor = true;
            this.clear_playlist_button.Click += new System.EventHandler(this.Clear_playlist_button_Click);
            // 
            // save_playlist_button
            // 
            this.save_playlist_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_playlist_button.Image = global::DiscoPlayer.Properties.Resources.icons8_save_16;
            this.save_playlist_button.Location = new System.Drawing.Point(70, 400);
            this.save_playlist_button.Name = "save_playlist_button";
            this.save_playlist_button.Size = new System.Drawing.Size(26, 23);
            this.save_playlist_button.TabIndex = 17;
            this.save_playlist_button.UseVisualStyleBackColor = true;
            this.save_playlist_button.Click += new System.EventHandler(this.Save_playlist_button_Click);
            // 
            // playlist_listBox
            // 
            this.playlist_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playlist_listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlist_listBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.playlist_listBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.playlist_listBox.FormattingEnabled = true;
            this.playlist_listBox.HorizontalScrollbar = true;
            this.playlist_listBox.ItemHeight = 15;
            this.playlist_listBox.Location = new System.Drawing.Point(3, 19);
            this.playlist_listBox.Name = "playlist_listBox";
            this.playlist_listBox.ScrollAlwaysVisible = true;
            this.playlist_listBox.Size = new System.Drawing.Size(281, 375);
            this.playlist_listBox.TabIndex = 0;
            this.playlist_listBox.SelectedIndexChanged += new System.EventHandler(this.Playlist_listBox_SelectedIndexChanged);
            this.playlist_listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Playlist_listBox_MouseDown);
            this.playlist_listBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Playlist_listBox_MouseUp);
            // 
            // file_browse_button
            // 
            this.file_browse_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file_browse_button.Image = global::DiscoPlayer.Properties.Resources.icons8_mp3_16;
            this.file_browse_button.Location = new System.Drawing.Point(6, 400);
            this.file_browse_button.Name = "file_browse_button";
            this.file_browse_button.Size = new System.Drawing.Size(26, 23);
            this.file_browse_button.TabIndex = 9;
            this.file_browse_button.UseVisualStyleBackColor = true;
            this.file_browse_button.Click += new System.EventHandler(this.File_browse_button_Click);
            // 
            // folder_browse_button
            // 
            this.folder_browse_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.folder_browse_button.Image = global::DiscoPlayer.Properties.Resources.icons8_folder_16;
            this.folder_browse_button.Location = new System.Drawing.Point(38, 400);
            this.folder_browse_button.Name = "folder_browse_button";
            this.folder_browse_button.Size = new System.Drawing.Size(26, 23);
            this.folder_browse_button.TabIndex = 16;
            this.folder_browse_button.UseVisualStyleBackColor = true;
            this.folder_browse_button.Click += new System.EventHandler(this.Folder_browse_button_Click);
            // 
            // playList_saveFileDialog
            // 
            this.playList_saveFileDialog.FileName = "NewPlayList1";
            this.playList_saveFileDialog.Filter = "プレイリスト|*.playlist";
            this.playList_saveFileDialog.Title = "プレイリストを保存";
            // 
            // waveIn_groupBox
            // 
            this.waveIn_groupBox.Controls.Add(this.waveIn_reload_button);
            this.waveIn_groupBox.Controls.Add(this.waveIn_stop_button);
            this.waveIn_groupBox.Controls.Add(this.waveIn_play_button);
            this.waveIn_groupBox.Controls.Add(this.waveIn_comboBox);
            this.waveIn_groupBox.Enabled = false;
            this.waveIn_groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.waveIn_groupBox.Location = new System.Drawing.Point(12, 193);
            this.waveIn_groupBox.Name = "waveIn_groupBox";
            this.waveIn_groupBox.Size = new System.Drawing.Size(422, 63);
            this.waveIn_groupBox.TabIndex = 5;
            this.waveIn_groupBox.TabStop = false;
            this.waveIn_groupBox.Text = "入力デバイス音源";
            // 
            // waveIn_reload_button
            // 
            this.waveIn_reload_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.waveIn_reload_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waveIn_reload_button.Image = global::DiscoPlayer.Properties.Resources.icons8_refresh_16;
            this.waveIn_reload_button.Location = new System.Drawing.Point(266, 24);
            this.waveIn_reload_button.Name = "waveIn_reload_button";
            this.waveIn_reload_button.Size = new System.Drawing.Size(45, 23);
            this.waveIn_reload_button.TabIndex = 6;
            this.waveIn_reload_button.UseVisualStyleBackColor = true;
            this.waveIn_reload_button.Click += new System.EventHandler(this.waveIn_reload_button_Click);
            // 
            // waveIn_stop_button
            // 
            this.waveIn_stop_button.Enabled = false;
            this.waveIn_stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waveIn_stop_button.Image = global::DiscoPlayer.Properties.Resources.icons8_stop_16__1_;
            this.waveIn_stop_button.Location = new System.Drawing.Point(368, 24);
            this.waveIn_stop_button.Name = "waveIn_stop_button";
            this.waveIn_stop_button.Size = new System.Drawing.Size(45, 23);
            this.waveIn_stop_button.TabIndex = 5;
            this.waveIn_stop_button.UseVisualStyleBackColor = true;
            this.waveIn_stop_button.Click += new System.EventHandler(this.waveIn_stop_button_Click);
            // 
            // waveIn_play_button
            // 
            this.waveIn_play_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.waveIn_play_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waveIn_play_button.Image = global::DiscoPlayer.Properties.Resources.icons8_circled_play_16;
            this.waveIn_play_button.Location = new System.Drawing.Point(317, 24);
            this.waveIn_play_button.Name = "waveIn_play_button";
            this.waveIn_play_button.Size = new System.Drawing.Size(45, 23);
            this.waveIn_play_button.TabIndex = 4;
            this.waveIn_play_button.UseVisualStyleBackColor = true;
            this.waveIn_play_button.Click += new System.EventHandler(this.waveIn_play_button_Click);
            // 
            // waveIn_comboBox
            // 
            this.waveIn_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waveIn_comboBox.FormattingEnabled = true;
            this.waveIn_comboBox.Location = new System.Drawing.Point(9, 24);
            this.waveIn_comboBox.Name = "waveIn_comboBox";
            this.waveIn_comboBox.Size = new System.Drawing.Size(251, 23);
            this.waveIn_comboBox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AllowDrop = true;
            this.panel3.Controls.Add(this.waveIn_groupBox);
            this.panel3.Controls.Add(this.playlist_groupBox);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.player_groupBox);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 516);
            this.panel3.TabIndex = 6;
            this.panel3.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.panel3.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            // 
            // clear_rate_button
            // 
            this.clear_rate_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_rate_button.Image = global::DiscoPlayer.Properties.Resources.icons8_refresh_16;
            this.clear_rate_button.Location = new System.Drawing.Point(7, 0);
            this.clear_rate_button.Name = "clear_rate_button";
            this.clear_rate_button.Size = new System.Drawing.Size(30, 40);
            this.clear_rate_button.TabIndex = 17;
            this.clear_rate_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clear_rate_button.UseVisualStyleBackColor = true;
            this.clear_rate_button.Click += new System.EventHandler(this.Clear_rate_button_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.clear_rate_button);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(688, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(39, 46);
            this.panel4.TabIndex = 18;
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(754, 516);
            this.Controls.Add(this.wave_rate_groupBox);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 635);
            this.MinimumSize = new System.Drawing.Size(462, 305);
            this.Name = "Main";
            this.Text = "DiscoPlayer v2.00";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_trackBar)).EndInit();
            this.player_groupBox.ResumeLayout(false);
            this.player_groupBox.PerformLayout();
            this.volume_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volume_trackBar)).EndInit();
            this.wave_rate_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wave_rate_trackBar)).EndInit();
            this.playlist_groupBox.ResumeLayout(false);
            this.waveIn_groupBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button channel_in_button;
        private System.Windows.Forms.Button channel_out_button;
        private System.Windows.Forms.Button player_pause_button;
        private System.Windows.Forms.Button player_play_button;
        private System.Windows.Forms.Button player_stop_button;
        private System.Windows.Forms.TrackBar player_trackBar;
        private System.Windows.Forms.Button file_browse_button;
        private System.Windows.Forms.GroupBox player_groupBox;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label player_label;
        private System.Windows.Forms.Label channel_state_label;
        private System.Windows.Forms.TextBox guild_id_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog mp3_openFileDialog;
        private System.Windows.Forms.TextBox mp3_title_textBox;
        private System.Windows.Forms.Button prev_button;
        private System.Windows.Forms.Button folder_browse_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.GroupBox playlist_groupBox;
        private System.Windows.Forms.ListBox playlist_listBox;
        private System.Windows.Forms.TrackBar volume_trackBar;
        private System.Windows.Forms.GroupBox volume_groupBox;
        private System.Windows.Forms.CheckBox allMusicRepeat_checkBox;
        private System.Windows.Forms.CheckBox musicRepeat_checkBox;
        private System.Windows.Forms.FolderBrowserDialog music_folderBrowserDialog;
        private System.Windows.Forms.Button save_playlist_button;
        private System.Windows.Forms.Button delete_music_button;
        private System.Windows.Forms.Button clear_playlist_button;
        private System.Windows.Forms.CheckBox randomPlay_checkBox;
        private System.Windows.Forms.SaveFileDialog playList_saveFileDialog;
        private System.Windows.Forms.CheckBox volume_checkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox voicechannel_id_textBox;
        private System.Windows.Forms.GroupBox wave_rate_groupBox;
        private System.Windows.Forms.TrackBar wave_rate_trackBar;
        private System.Windows.Forms.GroupBox waveIn_groupBox;
        private System.Windows.Forms.ComboBox waveIn_comboBox;
        private System.Windows.Forms.Button waveIn_stop_button;
        private System.Windows.Forms.Button waveIn_play_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox token_textBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox token_show_checkBox;
        private System.Windows.Forms.Button waveIn_reload_button;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button clear_rate_button;
    }
}

