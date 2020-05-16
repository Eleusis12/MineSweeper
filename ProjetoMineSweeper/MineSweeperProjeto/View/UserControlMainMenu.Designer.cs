namespace MineSweeperProjeto.View
{
	partial class UserControlMainMenu
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BTSinglePlayer = new System.Windows.Forms.Button();
			this.BTOnline = new System.Windows.Forms.Button();
			this.BTExit = new System.Windows.Forms.Button();
			this.BTOptions = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.LBLStatus = new System.Windows.Forms.Label();
			this.PBPerfil = new System.Windows.Forms.PictureBox();
			this.PBLeaderBoard = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PBPerfil)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PBLeaderBoard)).BeginInit();
			this.SuspendLayout();
			// 
			// BTSinglePlayer
			// 
			this.BTSinglePlayer.BackColor = System.Drawing.Color.Gray;
			this.BTSinglePlayer.FlatAppearance.BorderSize = 0;
			this.BTSinglePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTSinglePlayer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTSinglePlayer.ForeColor = System.Drawing.SystemColors.Control;
			this.BTSinglePlayer.Location = new System.Drawing.Point(66, 92);
			this.BTSinglePlayer.Name = "BTSinglePlayer";
			this.BTSinglePlayer.Size = new System.Drawing.Size(190, 27);
			this.BTSinglePlayer.TabIndex = 6;
			this.BTSinglePlayer.Text = "SinglePlayer";
			this.BTSinglePlayer.UseVisualStyleBackColor = false;
			this.BTSinglePlayer.Click += new System.EventHandler(this.BTSinglePlayer_Click);
			// 
			// BTOnline
			// 
			this.BTOnline.BackColor = System.Drawing.Color.Gray;
			this.BTOnline.FlatAppearance.BorderSize = 0;
			this.BTOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTOnline.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTOnline.ForeColor = System.Drawing.SystemColors.Control;
			this.BTOnline.Location = new System.Drawing.Point(66, 134);
			this.BTOnline.Name = "BTOnline";
			this.BTOnline.Size = new System.Drawing.Size(190, 27);
			this.BTOnline.TabIndex = 6;
			this.BTOnline.Text = "Online";
			this.BTOnline.UseVisualStyleBackColor = false;
			this.BTOnline.Click += new System.EventHandler(this.BTOnline_Click);
			// 
			// BTExit
			// 
			this.BTExit.BackColor = System.Drawing.Color.Gray;
			this.BTExit.FlatAppearance.BorderSize = 0;
			this.BTExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTExit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTExit.ForeColor = System.Drawing.SystemColors.Control;
			this.BTExit.Location = new System.Drawing.Point(166, 176);
			this.BTExit.Name = "BTExit";
			this.BTExit.Size = new System.Drawing.Size(90, 27);
			this.BTExit.TabIndex = 6;
			this.BTExit.Text = "Exit";
			this.BTExit.UseVisualStyleBackColor = false;
			this.BTExit.Click += new System.EventHandler(this.BTExit_Click);
			// 
			// BTOptions
			// 
			this.BTOptions.BackColor = System.Drawing.Color.Gray;
			this.BTOptions.FlatAppearance.BorderSize = 0;
			this.BTOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTOptions.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTOptions.ForeColor = System.Drawing.SystemColors.Control;
			this.BTOptions.Location = new System.Drawing.Point(66, 176);
			this.BTOptions.Name = "BTOptions";
			this.BTOptions.Size = new System.Drawing.Size(90, 27);
			this.BTOptions.TabIndex = 6;
			this.BTOptions.Text = "Options";
			this.BTOptions.UseVisualStyleBackColor = false;
			this.BTOptions.Click += new System.EventHandler(this.BTOptions_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::MineSweeperProjeto.Properties.Resources.Mine_Sweeper;
			this.pictureBox1.Location = new System.Drawing.Point(6, 14);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(305, 63);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// LBLStatus
			// 
			this.LBLStatus.AutoSize = true;
			this.LBLStatus.ForeColor = System.Drawing.SystemColors.Control;
			this.LBLStatus.Location = new System.Drawing.Point(330, 42);
			this.LBLStatus.Name = "LBLStatus";
			this.LBLStatus.Size = new System.Drawing.Size(37, 13);
			this.LBLStatus.TabIndex = 9;
			this.LBLStatus.Text = "Offline";
			// 
			// PBPerfil
			// 
			this.PBPerfil.BackColor = System.Drawing.Color.Transparent;
			this.PBPerfil.Image = global::MineSweeperProjeto.Properties.Resources.user;
			this.PBPerfil.Location = new System.Drawing.Point(335, 14);
			this.PBPerfil.Name = "PBPerfil";
			this.PBPerfil.Size = new System.Drawing.Size(24, 24);
			this.PBPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PBPerfil.TabIndex = 8;
			this.PBPerfil.TabStop = false;
			// 
			// PBLeaderBoard
			// 
			this.PBLeaderBoard.Image = global::MineSweeperProjeto.Properties.Resources.icons8_pastel_64;
			this.PBLeaderBoard.Location = new System.Drawing.Point(136, 243);
			this.PBLeaderBoard.Name = "PBLeaderBoard";
			this.PBLeaderBoard.Size = new System.Drawing.Size(46, 44);
			this.PBLeaderBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PBLeaderBoard.TabIndex = 10;
			this.PBLeaderBoard.TabStop = false;
			this.PBLeaderBoard.Click += new System.EventHandler(this.PBLeaderBoard_Click);
			// 
			// UserControlMainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.PBLeaderBoard);
			this.Controls.Add(this.LBLStatus);
			this.Controls.Add(this.PBPerfil);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.BTOptions);
			this.Controls.Add(this.BTExit);
			this.Controls.Add(this.BTOnline);
			this.Controls.Add(this.BTSinglePlayer);
			this.Name = "UserControlMainMenu";
			this.Size = new System.Drawing.Size(377, 302);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PBPerfil)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PBLeaderBoard)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BTSinglePlayer;
		private System.Windows.Forms.Button BTOnline;
		private System.Windows.Forms.Button BTExit;
		private System.Windows.Forms.Button BTOptions;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label LBLStatus;
		private System.Windows.Forms.PictureBox PBPerfil;
		private System.Windows.Forms.PictureBox PBLeaderBoard;
	}
}
