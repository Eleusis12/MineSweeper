namespace MineSweeperProjeto.View
{
	partial class UserControlDifficulty
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
			this.BTFácil = new System.Windows.Forms.Button();
			this.BTMedio = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.BTReverseMode = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BTFácil
			// 
			this.BTFácil.BackColor = System.Drawing.Color.IndianRed;
			this.BTFácil.FlatAppearance.BorderSize = 0;
			this.BTFácil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTFácil.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTFácil.ForeColor = System.Drawing.SystemColors.Control;
			this.BTFácil.Location = new System.Drawing.Point(121, 88);
			this.BTFácil.Name = "BTFácil";
			this.BTFácil.Size = new System.Drawing.Size(75, 27);
			this.BTFácil.TabIndex = 5;
			this.BTFácil.Tag = "Facil";
			this.BTFácil.Text = "Fácil";
			this.BTFácil.UseVisualStyleBackColor = false;
			this.BTFácil.Click += new System.EventHandler(this.BTClick);
			// 
			// BTMedio
			// 
			this.BTMedio.BackColor = System.Drawing.Color.IndianRed;
			this.BTMedio.FlatAppearance.BorderSize = 0;
			this.BTMedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTMedio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTMedio.ForeColor = System.Drawing.SystemColors.Control;
			this.BTMedio.Location = new System.Drawing.Point(121, 133);
			this.BTMedio.Name = "BTMedio";
			this.BTMedio.Size = new System.Drawing.Size(75, 27);
			this.BTMedio.TabIndex = 6;
			this.BTMedio.Tag = "Medio";
			this.BTMedio.Text = "Médio";
			this.BTMedio.UseVisualStyleBackColor = false;
			this.BTMedio.Click += new System.EventHandler(this.BTClick);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label9.Location = new System.Drawing.Point(33, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(135, 25);
			this.label9.TabIndex = 12;
			this.label9.Text = "Dificuldade ";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.IndianRed;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(121, 178);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 27);
			this.button1.TabIndex = 13;
			this.button1.Tag = "Dificil";
			this.button1.Text = "Difícil";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.BTClick);
			// 
			// BTReverseMode
			// 
			this.BTReverseMode.BackColor = System.Drawing.Color.IndianRed;
			this.BTReverseMode.FlatAppearance.BorderSize = 0;
			this.BTReverseMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTReverseMode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTReverseMode.ForeColor = System.Drawing.SystemColors.Control;
			this.BTReverseMode.Location = new System.Drawing.Point(58, 242);
			this.BTReverseMode.Name = "BTReverseMode";
			this.BTReverseMode.Size = new System.Drawing.Size(203, 27);
			this.BTReverseMode.TabIndex = 13;
			this.BTReverseMode.Tag = "Inverso";
			this.BTReverseMode.Text = "Modo Especial: Inverso";
			this.BTReverseMode.UseVisualStyleBackColor = false;
			this.BTReverseMode.Click += new System.EventHandler(this.BTReverseMode_Click);
			// 
			// UserControlDifficulty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.BTReverseMode);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.BTMedio);
			this.Controls.Add(this.BTFácil);
			this.Name = "UserControlDifficulty";
			this.Size = new System.Drawing.Size(377, 302);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BTFácil;
		private System.Windows.Forms.Button BTMedio;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button BTReverseMode;
	}
}
