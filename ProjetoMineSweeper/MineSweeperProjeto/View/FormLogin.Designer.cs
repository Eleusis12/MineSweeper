namespace MineSweeperProjeto.View
{
	partial class FormLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.TBPassword = new System.Windows.Forms.TextBox();
			this.TBUsername = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BTLogin = new System.Windows.Forms.Button();
			this.LLBLCreate = new System.Windows.Forms.LinkLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.BTClose = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.CheckBoxRememberMe = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BTClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Location = new System.Drawing.Point(43, 212);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(215, 1);
			this.panel2.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel3.Location = new System.Drawing.Point(43, 309);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(215, 1);
			this.panel3.TabIndex = 1;
			// 
			// TBPassword
			// 
			this.TBPassword.BackColor = System.Drawing.SystemColors.Control;
			this.TBPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TBPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TBPassword.Location = new System.Drawing.Point(43, 288);
			this.TBPassword.Name = "TBPassword";
			this.TBPassword.PasswordChar = '*';
			this.TBPassword.Size = new System.Drawing.Size(215, 19);
			this.TBPassword.TabIndex = 1;
			// 
			// TBUsername
			// 
			this.TBUsername.BackColor = System.Drawing.SystemColors.Control;
			this.TBUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TBUsername.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TBUsername.Location = new System.Drawing.Point(43, 191);
			this.TBUsername.Name = "TBUsername";
			this.TBUsername.Size = new System.Drawing.Size(215, 19);
			this.TBUsername.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Location = new System.Drawing.Point(49, 175);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Username";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label2.Location = new System.Drawing.Point(49, 268);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Password";
			// 
			// BTLogin
			// 
			this.BTLogin.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.BTLogin.FlatAppearance.BorderSize = 0;
			this.BTLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTLogin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTLogin.ForeColor = System.Drawing.SystemColors.Control;
			this.BTLogin.Location = new System.Drawing.Point(113, 354);
			this.BTLogin.Name = "BTLogin";
			this.BTLogin.Size = new System.Drawing.Size(75, 23);
			this.BTLogin.TabIndex = 2;
			this.BTLogin.Text = "Login";
			this.BTLogin.UseVisualStyleBackColor = false;
			this.BTLogin.Click += new System.EventHandler(this.BTLogin_Click);
			// 
			// LLBLCreate
			// 
			this.LLBLCreate.AutoSize = true;
			this.LLBLCreate.DisabledLinkColor = System.Drawing.SystemColors.ControlDarkDark;
			this.LLBLCreate.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.LLBLCreate.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
			this.LLBLCreate.Location = new System.Drawing.Point(80, 408);
			this.LLBLCreate.Name = "LLBLCreate";
			this.LLBLCreate.Size = new System.Drawing.Size(147, 17);
			this.LLBLCreate.TabIndex = 6;
			this.LLBLCreate.TabStop = true;
			this.LLBLCreate.Text = "Create your Account ";
			this.LLBLCreate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLBLCreate_LinkClicked);
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = global::MineSweeperProjeto.Properties.Resources._16_163420_light_color_gradient_background;
			this.panel1.Controls.Add(this.BTClose);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(300, 139);
			this.panel1.TabIndex = 5;
			// 
			// BTClose
			// 
			this.BTClose.BackColor = System.Drawing.Color.Transparent;
			this.BTClose.Image = global::MineSweeperProjeto.Properties.Resources.close;
			this.BTClose.Location = new System.Drawing.Point(276, 3);
			this.BTClose.Name = "BTClose";
			this.BTClose.Size = new System.Drawing.Size(21, 19);
			this.BTClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.BTClose.TabIndex = 7;
			this.BTClose.TabStop = false;
			this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Harlow Solid Italic", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Location = new System.Drawing.Point(98, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(173, 30);
			this.label3.TabIndex = 7;
			this.label3.Text = "Mine Sweeper ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(24, 27);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(74, 73);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// CheckBoxRememberMe
			// 
			this.CheckBoxRememberMe.AutoSize = true;
			this.CheckBoxRememberMe.Location = new System.Drawing.Point(177, 331);
			this.CheckBoxRememberMe.Name = "CheckBoxRememberMe";
			this.CheckBoxRememberMe.Size = new System.Drawing.Size(94, 17);
			this.CheckBoxRememberMe.TabIndex = 7;
			this.CheckBoxRememberMe.Text = "Remember me";
			this.CheckBoxRememberMe.UseVisualStyleBackColor = true;
			// 
			// FormLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 450);
			this.Controls.Add(this.CheckBoxRememberMe);
			this.Controls.Add(this.LLBLCreate);
			this.Controls.Add(this.BTLogin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TBUsername);
			this.Controls.Add(this.TBPassword);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FormLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.Load += new System.EventHandler(this.FormLogin_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BTClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox TBPassword;
		private System.Windows.Forms.TextBox TBUsername;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BTLogin;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel LLBLCreate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox BTClose;
		private System.Windows.Forms.CheckBox CheckBoxRememberMe;
	}
}