namespace MineSweeperProjeto.View
{
	partial class FormRegister
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.BTUploadPic = new System.Windows.Forms.Button();
			this.PBProfilePic = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.CBCountry = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.TBEmail = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TBPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TBUsername = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TBLastName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TBFirstName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.BTRegister = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBProfilePic)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.White;
			this.groupBox1.Controls.Add(this.BTUploadPic);
			this.groupBox1.Controls.Add(this.PBProfilePic);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.CBCountry);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.TBEmail);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.TBPassword);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.TBUsername);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.TBLastName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.TBFirstName);
			this.groupBox1.Location = new System.Drawing.Point(44, 98);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(712, 304);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// BTUploadPic
			// 
			this.BTUploadPic.Location = new System.Drawing.Point(559, 224);
			this.BTUploadPic.Name = "BTUploadPic";
			this.BTUploadPic.Size = new System.Drawing.Size(75, 23);
			this.BTUploadPic.TabIndex = 16;
			this.BTUploadPic.Text = "Upload";
			this.BTUploadPic.UseVisualStyleBackColor = true;
			this.BTUploadPic.Click += new System.EventHandler(this.BTUploadPic_Click);
			// 
			// PBProfilePic
			// 
			this.PBProfilePic.Image = global::MineSweeperProjeto.Properties.Resources.user64;
			this.PBProfilePic.Location = new System.Drawing.Point(573, 168);
			this.PBProfilePic.Name = "PBProfilePic";
			this.PBProfilePic.Size = new System.Drawing.Size(50, 50);
			this.PBProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PBProfilePic.TabIndex = 15;
			this.PBProfilePic.TabStop = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label7.Location = new System.Drawing.Point(29, 224);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(33, 17);
			this.label7.TabIndex = 14;
			this.label7.Text = "País";
			// 
			// CBCountry
			// 
			this.CBCountry.FormattingEnabled = true;
			this.CBCountry.Location = new System.Drawing.Point(29, 248);
			this.CBCountry.Name = "CBCountry";
			this.CBCountry.Size = new System.Drawing.Size(121, 21);
			this.CBCountry.TabIndex = 14;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label8.Location = new System.Drawing.Point(559, 149);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 17);
			this.label8.TabIndex = 13;
			this.label8.Text = "Fotografia";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label6.Location = new System.Drawing.Point(29, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 17);
			this.label6.TabIndex = 13;
			this.label6.Text = "Email";
			// 
			// TBEmail
			// 
			this.TBEmail.BackColor = System.Drawing.Color.White;
			this.TBEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TBEmail.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TBEmail.Location = new System.Drawing.Point(29, 95);
			this.TBEmail.Name = "TBEmail";
			this.TBEmail.Size = new System.Drawing.Size(530, 20);
			this.TBEmail.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label5.Location = new System.Drawing.Point(29, 173);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(235, 17);
			this.label5.TabIndex = 11;
			this.label5.Text = "Password (minimo de 8 caracteres)";
			// 
			// TBPassword
			// 
			this.TBPassword.BackColor = System.Drawing.Color.White;
			this.TBPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TBPassword.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TBPassword.Location = new System.Drawing.Point(29, 197);
			this.TBPassword.Name = "TBPassword";
			this.TBPassword.PasswordChar = '*';
			this.TBPassword.Size = new System.Drawing.Size(219, 20);
			this.TBPassword.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label4.Location = new System.Drawing.Point(29, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "Username";
			// 
			// TBUsername
			// 
			this.TBUsername.BackColor = System.Drawing.Color.White;
			this.TBUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TBUsername.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TBUsername.Location = new System.Drawing.Point(29, 146);
			this.TBUsername.Name = "TBUsername";
			this.TBUsername.Size = new System.Drawing.Size(219, 20);
			this.TBUsername.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Location = new System.Drawing.Point(307, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Último Nome";
			// 
			// TBLastName
			// 
			this.TBLastName.BackColor = System.Drawing.Color.White;
			this.TBLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TBLastName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TBLastName.Location = new System.Drawing.Point(310, 40);
			this.TBLastName.Name = "TBLastName";
			this.TBLastName.Size = new System.Drawing.Size(252, 20);
			this.TBLastName.TabIndex = 6;
			this.TBLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label2.Location = new System.Drawing.Point(29, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Primeiro Nome";
			// 
			// TBFirstName
			// 
			this.TBFirstName.BackColor = System.Drawing.Color.White;
			this.TBFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TBFirstName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TBFirstName.Location = new System.Drawing.Point(29, 44);
			this.TBFirstName.Name = "TBFirstName";
			this.TBFirstName.Size = new System.Drawing.Size(249, 20);
			this.TBFirstName.TabIndex = 1;
			this.TBFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Harlow Solid Italic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Location = new System.Drawing.Point(357, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 26);
			this.label3.TabIndex = 9;
			this.label3.Text = "Mine Sweeper ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(303, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 44);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// BTRegister
			// 
			this.BTRegister.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.BTRegister.FlatAppearance.BorderSize = 0;
			this.BTRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTRegister.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTRegister.ForeColor = System.Drawing.SystemColors.Control;
			this.BTRegister.Location = new System.Drawing.Point(133, 419);
			this.BTRegister.Name = "BTRegister";
			this.BTRegister.Size = new System.Drawing.Size(534, 23);
			this.BTRegister.TabIndex = 10;
			this.BTRegister.Text = "Registar";
			this.BTRegister.UseVisualStyleBackColor = false;
			this.BTRegister.Click += new System.EventHandler(this.BTRegister_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(50, 71);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(178, 25);
			this.label9.TabIndex = 11;
			this.label9.Text = "Cria a tua conta";
			// 
			// FormRegister
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.BTRegister);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.Name = "FormRegister";
			this.Text = "Register";
			this.Load += new System.EventHandler(this.FormRegister_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBProfilePic)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox TBFirstName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox CBCountry;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox TBEmail;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox TBPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TBUsername;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TBLastName;
		private System.Windows.Forms.Button BTUploadPic;
		private System.Windows.Forms.PictureBox PBProfilePic;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button BTRegister;
		private System.Windows.Forms.Label label9;
	}
}