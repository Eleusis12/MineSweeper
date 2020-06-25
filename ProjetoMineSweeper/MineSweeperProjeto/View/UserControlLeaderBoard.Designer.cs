namespace MineSweeperProjeto.View
{
	partial class UserControlLeaderBoard
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
			this.LVTop10 = new System.Windows.Forms.ListView();
			this.ColunaRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColunaNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColunaTempo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColunaQuando = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colunaDificuldade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label9 = new System.Windows.Forms.Label();
			this.LBLEasy = new System.Windows.Forms.Button();
			this.LBLMedium = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LVTop10
			// 
			this.LVTop10.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.LVTop10.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColunaRank,
            this.ColunaNome,
            this.ColunaTempo,
            this.ColunaQuando,
            this.colunaDificuldade});
			this.LVTop10.FullRowSelect = true;
			this.LVTop10.HideSelection = false;
			this.LVTop10.Location = new System.Drawing.Point(0, 52);
			this.LVTop10.Name = "LVTop10";
			this.LVTop10.Size = new System.Drawing.Size(374, 207);
			this.LVTop10.TabIndex = 0;
			this.LVTop10.UseCompatibleStateImageBehavior = false;
			this.LVTop10.View = System.Windows.Forms.View.Details;
			this.LVTop10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LVTop10_MouseClick);
			// 
			// ColunaRank
			// 
			this.ColunaRank.Text = "Rank";
			this.ColunaRank.Width = 43;
			// 
			// ColunaNome
			// 
			this.ColunaNome.Text = "Nome";
			this.ColunaNome.Width = 113;
			// 
			// ColunaTempo
			// 
			this.ColunaTempo.Text = "Tempo";
			this.ColunaTempo.Width = 55;
			// 
			// ColunaQuando
			// 
			this.ColunaQuando.Text = "Quando";
			this.ColunaQuando.Width = 78;
			// 
			// colunaDificuldade
			// 
			this.colunaDificuldade.Text = "Dificuldade";
			this.colunaDificuldade.Width = 83;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label9.Location = new System.Drawing.Point(21, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(81, 25);
			this.label9.TabIndex = 12;
			this.label9.Text = "TOP 10";
			// 
			// LBLEasy
			// 
			this.LBLEasy.BackColor = System.Drawing.Color.Gray;
			this.LBLEasy.FlatAppearance.BorderSize = 0;
			this.LBLEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LBLEasy.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLEasy.ForeColor = System.Drawing.SystemColors.Control;
			this.LBLEasy.Location = new System.Drawing.Point(0, 265);
			this.LBLEasy.Name = "LBLEasy";
			this.LBLEasy.Size = new System.Drawing.Size(57, 27);
			this.LBLEasy.TabIndex = 13;
			this.LBLEasy.Tag = "Facil";
			this.LBLEasy.Text = "Fácil";
			this.LBLEasy.UseVisualStyleBackColor = false;
			this.LBLEasy.Click += new System.EventHandler(this.ShowTop10Difficulty);
			// 
			// LBLMedium
			// 
			this.LBLMedium.BackColor = System.Drawing.Color.Gray;
			this.LBLMedium.FlatAppearance.BorderSize = 0;
			this.LBLMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LBLMedium.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLMedium.ForeColor = System.Drawing.SystemColors.Control;
			this.LBLMedium.Location = new System.Drawing.Point(63, 265);
			this.LBLMedium.Name = "LBLMedium";
			this.LBLMedium.Size = new System.Drawing.Size(68, 27);
			this.LBLMedium.TabIndex = 13;
			this.LBLMedium.Tag = "Medio";
			this.LBLMedium.Text = "Médio";
			this.LBLMedium.UseVisualStyleBackColor = false;
			this.LBLMedium.Click += new System.EventHandler(this.ShowTop10Difficulty);
			// 
			// UserControlLeaderBoard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.LBLMedium);
			this.Controls.Add(this.LBLEasy);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.LVTop10);
			this.Name = "UserControlLeaderBoard";
			this.Size = new System.Drawing.Size(377, 302);
			this.Load += new System.EventHandler(this.UserControlLeaderBoard_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView LVTop10;
		private System.Windows.Forms.ColumnHeader ColunaRank;
		private System.Windows.Forms.ColumnHeader ColunaNome;
		private System.Windows.Forms.ColumnHeader ColunaTempo;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ColumnHeader ColunaQuando;
		private System.Windows.Forms.ColumnHeader colunaDificuldade;
		private System.Windows.Forms.Button LBLEasy;
		private System.Windows.Forms.Button LBLMedium;
	}
}
