namespace MineSweeperProjeto.View
{
	partial class UserControlSearch
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
			this.LBLSearch = new System.Windows.Forms.Label();
			this.TBSearch = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.LBLPais = new System.Windows.Forms.Label();
			this.LBLBestTimeMedium = new System.Windows.Forms.Label();
			this.LBLBestTimeEasy = new System.Windows.Forms.Label();
			this.LBLNumeroJogosPerdidos = new System.Windows.Forms.Label();
			this.LBLNumeroJogosGanhos = new System.Windows.Forms.Label();
			this.LBLNumeroJogos = new System.Windows.Forms.Label();
			this.LBLEmail = new System.Windows.Forms.Label();
			this.LBLNome = new System.Windows.Forms.Label();
			this.PBProfilePic = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBProfilePic)).BeginInit();
			this.SuspendLayout();
			// 
			// LBLSearch
			// 
			this.LBLSearch.AutoSize = true;
			this.LBLSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLSearch.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLSearch.Location = new System.Drawing.Point(25, 18);
			this.LBLSearch.Name = "LBLSearch";
			this.LBLSearch.Size = new System.Drawing.Size(62, 17);
			this.LBLSearch.TabIndex = 7;
			this.LBLSearch.Text = "Pesquise";
			// 
			// TBSearch
			// 
			this.TBSearch.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.TBSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TBSearch.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TBSearch.Location = new System.Drawing.Point(19, 37);
			this.TBSearch.Name = "TBSearch";
			this.TBSearch.Size = new System.Drawing.Size(215, 19);
			this.TBSearch.TabIndex = 6;
			this.TBSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBSearch_KeyDown);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Location = new System.Drawing.Point(19, 58);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(215, 1);
			this.panel2.TabIndex = 5;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LBLPais);
			this.groupBox1.Controls.Add(this.LBLBestTimeMedium);
			this.groupBox1.Controls.Add(this.LBLBestTimeEasy);
			this.groupBox1.Controls.Add(this.LBLNumeroJogosPerdidos);
			this.groupBox1.Controls.Add(this.LBLNumeroJogosGanhos);
			this.groupBox1.Controls.Add(this.LBLNumeroJogos);
			this.groupBox1.Controls.Add(this.LBLEmail);
			this.groupBox1.Controls.Add(this.LBLNome);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox1.Location = new System.Drawing.Point(19, 65);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(355, 211);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Resultado da Pesquisa";
			this.groupBox1.Visible = false;
			// 
			// LBLPais
			// 
			this.LBLPais.AutoSize = true;
			this.LBLPais.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLPais.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLPais.Location = new System.Drawing.Point(6, 63);
			this.LBLPais.Name = "LBLPais";
			this.LBLPais.Size = new System.Drawing.Size(32, 16);
			this.LBLPais.TabIndex = 10;
			this.LBLPais.Text = "País:";
			// 
			// LBLBestTimeMedium
			// 
			this.LBLBestTimeMedium.AutoSize = true;
			this.LBLBestTimeMedium.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLBestTimeMedium.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLBestTimeMedium.Location = new System.Drawing.Point(6, 148);
			this.LBLBestTimeMedium.Name = "LBLBestTimeMedium";
			this.LBLBestTimeMedium.Size = new System.Drawing.Size(128, 16);
			this.LBLBestTimeMedium.TabIndex = 9;
			this.LBLBestTimeMedium.Text = "Melhor tempo, Médio:";
			// 
			// LBLBestTimeEasy
			// 
			this.LBLBestTimeEasy.AutoSize = true;
			this.LBLBestTimeEasy.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLBestTimeEasy.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLBestTimeEasy.Location = new System.Drawing.Point(6, 131);
			this.LBLBestTimeEasy.Name = "LBLBestTimeEasy";
			this.LBLBestTimeEasy.Size = new System.Drawing.Size(117, 16);
			this.LBLBestTimeEasy.TabIndex = 9;
			this.LBLBestTimeEasy.Text = "Melhor tempo, Fácil:";
			// 
			// LBLNumeroJogosPerdidos
			// 
			this.LBLNumeroJogosPerdidos.AutoSize = true;
			this.LBLNumeroJogosPerdidos.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLNumeroJogosPerdidos.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLNumeroJogosPerdidos.Location = new System.Drawing.Point(14, 113);
			this.LBLNumeroJogosPerdidos.Name = "LBLNumeroJogosPerdidos";
			this.LBLNumeroJogosPerdidos.Size = new System.Drawing.Size(57, 16);
			this.LBLNumeroJogosPerdidos.TabIndex = 9;
			this.LBLNumeroJogosPerdidos.Text = "Perdidos:";
			// 
			// LBLNumeroJogosGanhos
			// 
			this.LBLNumeroJogosGanhos.AutoSize = true;
			this.LBLNumeroJogosGanhos.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLNumeroJogosGanhos.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLNumeroJogosGanhos.Location = new System.Drawing.Point(14, 96);
			this.LBLNumeroJogosGanhos.Name = "LBLNumeroJogosGanhos";
			this.LBLNumeroJogosGanhos.Size = new System.Drawing.Size(54, 16);
			this.LBLNumeroJogosGanhos.TabIndex = 9;
			this.LBLNumeroJogosGanhos.Text = "Ganhos:";
			// 
			// LBLNumeroJogos
			// 
			this.LBLNumeroJogos.AutoSize = true;
			this.LBLNumeroJogos.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLNumeroJogos.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLNumeroJogos.Location = new System.Drawing.Point(6, 80);
			this.LBLNumeroJogos.Name = "LBLNumeroJogos";
			this.LBLNumeroJogos.Size = new System.Drawing.Size(104, 16);
			this.LBLNumeroJogos.TabIndex = 9;
			this.LBLNumeroJogos.Text = "Número de Jogos:";
			// 
			// LBLEmail
			// 
			this.LBLEmail.AutoSize = true;
			this.LBLEmail.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLEmail.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLEmail.Location = new System.Drawing.Point(6, 46);
			this.LBLEmail.Name = "LBLEmail";
			this.LBLEmail.Size = new System.Drawing.Size(39, 16);
			this.LBLEmail.TabIndex = 9;
			this.LBLEmail.Text = "Email:";
			// 
			// LBLNome
			// 
			this.LBLNome.AutoSize = true;
			this.LBLNome.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLNome.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.LBLNome.Location = new System.Drawing.Point(6, 29);
			this.LBLNome.Name = "LBLNome";
			this.LBLNome.Size = new System.Drawing.Size(101, 16);
			this.LBLNome.TabIndex = 8;
			this.LBLNome.Text = "Nome Abreviado";
			// 
			// PBProfilePic
			// 
			this.PBProfilePic.Location = new System.Drawing.Point(315, 9);
			this.PBProfilePic.Name = "PBProfilePic";
			this.PBProfilePic.Size = new System.Drawing.Size(49, 50);
			this.PBProfilePic.TabIndex = 9;
			this.PBProfilePic.TabStop = false;
			this.PBProfilePic.Visible = false;
			// 
			// UserControlSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.PBProfilePic);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.LBLSearch);
			this.Controls.Add(this.TBSearch);
			this.Controls.Add(this.panel2);
			this.Name = "UserControlSearch";
			this.Size = new System.Drawing.Size(377, 302);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBProfilePic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LBLSearch;
		private System.Windows.Forms.TextBox TBSearch;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label LBLPais;
		private System.Windows.Forms.Label LBLBestTimeMedium;
		private System.Windows.Forms.Label LBLBestTimeEasy;
		private System.Windows.Forms.Label LBLNumeroJogosPerdidos;
		private System.Windows.Forms.Label LBLNumeroJogosGanhos;
		private System.Windows.Forms.Label LBLNumeroJogos;
		private System.Windows.Forms.Label LBLEmail;
		private System.Windows.Forms.Label LBLNome;
		private System.Windows.Forms.PictureBox PBProfilePic;
	}
}
