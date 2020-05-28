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
			this.label9 = new System.Windows.Forms.Label();
			this.ColunaQuando = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// LVTop10
			// 
			this.LVTop10.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.LVTop10.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColunaRank,
            this.ColunaNome,
            this.ColunaTempo,
            this.ColunaQuando});
			this.LVTop10.HideSelection = false;
			this.LVTop10.Location = new System.Drawing.Point(39, 52);
			this.LVTop10.Name = "LVTop10";
			this.LVTop10.Size = new System.Drawing.Size(335, 207);
			this.LVTop10.TabIndex = 0;
			this.LVTop10.UseCompatibleStateImageBehavior = false;
			this.LVTop10.View = System.Windows.Forms.View.Details;
			// 
			// ColunaRank
			// 
			this.ColunaRank.Text = "Rank";
			this.ColunaRank.Width = 43;
			// 
			// ColunaNome
			// 
			this.ColunaNome.Text = "Nome";
			this.ColunaNome.Width = 124;
			// 
			// ColunaTempo
			// 
			this.ColunaTempo.Text = "Tempo";
			this.ColunaTempo.Width = 88;
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
			// ColunaQuando
			// 
			this.ColunaQuando.Text = "Quando";
			this.ColunaQuando.Width = 78;
			// 
			// UserControlLeaderBoard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.label9);
			this.Controls.Add(this.LVTop10);
			this.Name = "UserControlLeaderBoard";
			this.Size = new System.Drawing.Size(377, 302);
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
	}
}
