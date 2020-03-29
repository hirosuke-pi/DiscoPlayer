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
            this.token_show_checkBox = new System.Windows.Forms.CheckBox();
            this.token_textBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guild_id_textBox = new System.Windows.Forms.TextBox();
            this.channel_state_label = new System.Windows.Forms.Label();
            this.channel_in_button = new System.Windows.Forms.Button();
            this.channel_out_button = new System.Windows.Forms.Button();
            this.channel_id_textBox = new System.Windows.Forms.TextBox();
            this.player_pause_button = new System.Windows.Forms.Button();
            this.player_play_button = new System.Windows.Forms.Button();
            this.player_stop_button = new System.Windows.Forms.Button();
            this.player_trackBar = new System.Windows.Forms.TrackBar();
            this.mp3_path_textBox = new System.Windows.Forms.TextBox();
            this.player_groupBox = new System.Windows.Forms.GroupBox();
            this.mp3_title_textBox = new System.Windows.Forms.TextBox();
            this.time_label = new System.Windows.Forms.Label();
            this.player_label = new System.Windows.Forms.Label();
            this.file_browse_button = new System.Windows.Forms.Button();
            this.mp3_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_trackBar)).BeginInit();
            this.player_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.token_show_checkBox);
            this.groupBox2.Controls.Add(this.token_textBox);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "トークン";
            // 
            // token_show_checkBox
            // 
            this.token_show_checkBox.AutoSize = true;
            this.token_show_checkBox.Checked = true;
            this.token_show_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.token_show_checkBox.Location = new System.Drawing.Point(544, 27);
            this.token_show_checkBox.Name = "token_show_checkBox";
            this.token_show_checkBox.Size = new System.Drawing.Size(15, 14);
            this.token_show_checkBox.TabIndex = 1;
            this.token_show_checkBox.UseVisualStyleBackColor = true;
            this.token_show_checkBox.CheckedChanged += new System.EventHandler(this.Token_show_checkBox_CheckedChanged);
            // 
            // token_textBox
            // 
            this.token_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.token_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.token_textBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.token_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.token_textBox.Location = new System.Drawing.Point(6, 22);
            this.token_textBox.Name = "token_textBox";
            this.token_textBox.PasswordChar = '*';
            this.token_textBox.Size = new System.Drawing.Size(532, 23);
            this.token_textBox.TabIndex = 0;
            this.token_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.guild_id_textBox);
            this.groupBox3.Controls.Add(this.channel_state_label);
            this.groupBox3.Controls.Add(this.channel_in_button);
            this.groupBox3.Controls.Add(this.channel_out_button);
            this.groupBox3.Controls.Add(this.channel_id_textBox);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Location = new System.Drawing.Point(12, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(565, 91);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ボイスチャンネル";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "ボイスチャンネルID:";
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
            this.guild_id_textBox.Location = new System.Drawing.Point(107, 22);
            this.guild_id_textBox.Name = "guild_id_textBox";
            this.guild_id_textBox.Size = new System.Drawing.Size(246, 23);
            this.guild_id_textBox.TabIndex = 12;
            this.guild_id_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // channel_state_label
            // 
            this.channel_state_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.channel_state_label.Location = new System.Drawing.Point(357, 26);
            this.channel_state_label.Name = "channel_state_label";
            this.channel_state_label.Size = new System.Drawing.Size(200, 15);
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
            this.channel_in_button.Location = new System.Drawing.Point(359, 53);
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
            this.channel_out_button.Location = new System.Drawing.Point(461, 53);
            this.channel_out_button.Name = "channel_out_button";
            this.channel_out_button.Size = new System.Drawing.Size(96, 23);
            this.channel_out_button.TabIndex = 0;
            this.channel_out_button.Text = "切断";
            this.channel_out_button.UseVisualStyleBackColor = true;
            this.channel_out_button.Click += new System.EventHandler(this.Channel_out_button_Click);
            // 
            // channel_id_textBox
            // 
            this.channel_id_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.channel_id_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.channel_id_textBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.channel_id_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.channel_id_textBox.Location = new System.Drawing.Point(107, 53);
            this.channel_id_textBox.Name = "channel_id_textBox";
            this.channel_id_textBox.Size = new System.Drawing.Size(246, 23);
            this.channel_id_textBox.TabIndex = 2;
            this.channel_id_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // player_pause_button
            // 
            this.player_pause_button.Enabled = false;
            this.player_pause_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player_pause_button.Image = global::DiscoPlayer.Properties.Resources.icons8_pause_40;
            this.player_pause_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.player_pause_button.Location = new System.Drawing.Point(132, 63);
            this.player_pause_button.Name = "player_pause_button";
            this.player_pause_button.Size = new System.Drawing.Size(120, 69);
            this.player_pause_button.TabIndex = 4;
            this.player_pause_button.Text = "Pause";
            this.player_pause_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.player_pause_button.UseVisualStyleBackColor = true;
            this.player_pause_button.Click += new System.EventHandler(this.Player_pause_button_Click);
            // 
            // player_play_button
            // 
            this.player_play_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player_play_button.Image = global::DiscoPlayer.Properties.Resources.icons8_play_40;
            this.player_play_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.player_play_button.Location = new System.Drawing.Point(6, 63);
            this.player_play_button.Name = "player_play_button";
            this.player_play_button.Size = new System.Drawing.Size(120, 69);
            this.player_play_button.TabIndex = 5;
            this.player_play_button.Text = "Play";
            this.player_play_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.player_play_button.UseVisualStyleBackColor = true;
            this.player_play_button.Click += new System.EventHandler(this.Player_play_button_Click);
            // 
            // player_stop_button
            // 
            this.player_stop_button.Enabled = false;
            this.player_stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player_stop_button.Image = global::DiscoPlayer.Properties.Resources.icons8_stop_40;
            this.player_stop_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.player_stop_button.Location = new System.Drawing.Point(258, 63);
            this.player_stop_button.Name = "player_stop_button";
            this.player_stop_button.Size = new System.Drawing.Size(120, 69);
            this.player_stop_button.TabIndex = 6;
            this.player_stop_button.Text = "Stop";
            this.player_stop_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.player_stop_button.UseVisualStyleBackColor = true;
            this.player_stop_button.Click += new System.EventHandler(this.Player_stop_button_Click);
            // 
            // player_trackBar
            // 
            this.player_trackBar.Location = new System.Drawing.Point(6, 152);
            this.player_trackBar.Maximum = 1000;
            this.player_trackBar.Name = "player_trackBar";
            this.player_trackBar.Size = new System.Drawing.Size(553, 45);
            this.player_trackBar.TabIndex = 7;
            this.player_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.player_trackBar.Scroll += new System.EventHandler(this.Player_trackBar_Scroll);
            // 
            // mp3_path_textBox
            // 
            this.mp3_path_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mp3_path_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mp3_path_textBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mp3_path_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mp3_path_textBox.Location = new System.Drawing.Point(6, 26);
            this.mp3_path_textBox.Name = "mp3_path_textBox";
            this.mp3_path_textBox.ReadOnly = true;
            this.mp3_path_textBox.Size = new System.Drawing.Size(449, 23);
            this.mp3_path_textBox.TabIndex = 8;
            // 
            // player_groupBox
            // 
            this.player_groupBox.Controls.Add(this.mp3_title_textBox);
            this.player_groupBox.Controls.Add(this.time_label);
            this.player_groupBox.Controls.Add(this.player_label);
            this.player_groupBox.Controls.Add(this.file_browse_button);
            this.player_groupBox.Controls.Add(this.mp3_path_textBox);
            this.player_groupBox.Controls.Add(this.player_stop_button);
            this.player_groupBox.Controls.Add(this.player_play_button);
            this.player_groupBox.Controls.Add(this.player_pause_button);
            this.player_groupBox.Controls.Add(this.player_trackBar);
            this.player_groupBox.Enabled = false;
            this.player_groupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.player_groupBox.Location = new System.Drawing.Point(12, 174);
            this.player_groupBox.Name = "player_groupBox";
            this.player_groupBox.Size = new System.Drawing.Size(565, 203);
            this.player_groupBox.TabIndex = 0;
            this.player_groupBox.TabStop = false;
            this.player_groupBox.Text = "プレイヤー";
            // 
            // mp3_title_textBox
            // 
            this.mp3_title_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mp3_title_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mp3_title_textBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mp3_title_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mp3_title_textBox.Location = new System.Drawing.Point(403, 63);
            this.mp3_title_textBox.Name = "mp3_title_textBox";
            this.mp3_title_textBox.ReadOnly = true;
            this.mp3_title_textBox.Size = new System.Drawing.Size(156, 16);
            this.mp3_title_textBox.TabIndex = 13;
            this.mp3_title_textBox.Text = "選択されていません";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(400, 117);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(102, 15);
            this.time_label.TabIndex = 12;
            this.time_label.Text = "00:00:00 / 00:00:00";
            // 
            // player_label
            // 
            this.player_label.AutoSize = true;
            this.player_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.player_label.Location = new System.Drawing.Point(400, 90);
            this.player_label.Name = "player_label";
            this.player_label.Size = new System.Drawing.Size(31, 15);
            this.player_label.TabIndex = 11;
            this.player_label.Text = "停止";
            // 
            // file_browse_button
            // 
            this.file_browse_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file_browse_button.Image = global::DiscoPlayer.Properties.Resources.icons8_mp3_16;
            this.file_browse_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.file_browse_button.Location = new System.Drawing.Point(461, 26);
            this.file_browse_button.Name = "file_browse_button";
            this.file_browse_button.Size = new System.Drawing.Size(98, 23);
            this.file_browse_button.TabIndex = 9;
            this.file_browse_button.Text = "開く";
            this.file_browse_button.UseVisualStyleBackColor = true;
            this.file_browse_button.Click += new System.EventHandler(this.File_browse_button_Click);
            // 
            // mp3_openFileDialog
            // 
            this.mp3_openFileDialog.Filter = "MP3ファイル|*.mp3";
            this.mp3_openFileDialog.Title = "MP3ファイルを開く";
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(589, 390);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.player_groupBox);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "DiscoPlayer v0.10";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_trackBar)).EndInit();
            this.player_groupBox.ResumeLayout(false);
            this.player_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox token_textBox;
        private System.Windows.Forms.CheckBox token_show_checkBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox channel_id_textBox;
        private System.Windows.Forms.Button channel_in_button;
        private System.Windows.Forms.Button channel_out_button;
        private System.Windows.Forms.Button player_pause_button;
        private System.Windows.Forms.Button player_play_button;
        private System.Windows.Forms.Button player_stop_button;
        private System.Windows.Forms.TrackBar player_trackBar;
        private System.Windows.Forms.TextBox mp3_path_textBox;
        private System.Windows.Forms.Button file_browse_button;
        private System.Windows.Forms.GroupBox player_groupBox;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label player_label;
        private System.Windows.Forms.Label channel_state_label;
        private System.Windows.Forms.TextBox guild_id_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog mp3_openFileDialog;
        private System.Windows.Forms.TextBox mp3_title_textBox;
    }
}

