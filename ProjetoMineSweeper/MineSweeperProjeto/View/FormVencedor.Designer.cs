namespace MineSweeperProjeto.View
{
	partial class FormVencedor
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
			this.LBLUsername = new System.Windows.Forms.Label();
			this.TBNomeVencedor = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.BTSubmeter = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LBLUsername
			// 
			this.LBLUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LBLUsername.AutoSize = true;
			this.LBLUsername.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LBLUsername.Location = new System.Drawing.Point(22, 9);
			this.LBLUsername.Name = "LBLUsername";
			this.LBLUsername.Size = new System.Drawing.Size(75, 17);
			this.LBLUsername.TabIndex = 0;
			this.LBLUsername.Text = "Username:";
			// 
			// TBNomeVencedor
			// 
			this.TBNomeVencedor.BackColor = System.Drawing.SystemColors.Control;
			this.TBNomeVencedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TBNomeVencedor.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TBNomeVencedor.Location = new System.Drawing.Point(15, 29);
			this.TBNomeVencedor.Name = "TBNomeVencedor";
			this.TBNomeVencedor.Size = new System.Drawing.Size(136, 19);
			this.TBNomeVencedor.TabIndex = 10;
			this.TBNomeVencedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBNomeVencedor_KeyDown);
			this.TBNomeVencedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNomeVencedor_KeyPress);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Location = new System.Drawing.Point(15, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(136, 1);
			this.panel2.TabIndex = 9;
			// 
			// BTSubmeter
			// 
			this.BTSubmeter.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.BTSubmeter.FlatAppearance.BorderSize = 0;
			this.BTSubmeter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTSubmeter.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTSubmeter.ForeColor = System.Drawing.SystemColors.Control;
			this.BTSubmeter.Location = new System.Drawing.Point(139, 59);
			this.BTSubmeter.Name = "BTSubmeter";
			this.BTSubmeter.Size = new System.Drawing.Size(75, 23);
			this.BTSubmeter.TabIndex = 11;
			this.BTSubmeter.Text = "Submeter";
			this.BTSubmeter.UseVisualStyleBackColor = false;
			// 
			// FormVencedor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 94);
			this.Controls.Add(this.BTSubmeter);
			this.Controls.Add(this.TBNomeVencedor);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.LBLUsername);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormVencedor";
			this.Text = "Nome do Vencedor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LBLUsername;
		private System.Windows.Forms.TextBox TBNomeVencedor;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button BTSubmeter;
	}
}