namespace MineSweeperProjeto.View
{
	partial class UserControlOptions
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
			this.BTSoundEffects = new System.Windows.Forms.Button();
			this.BTTheme = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BTSoundEffects
			// 
			this.BTSoundEffects.BackColor = System.Drawing.Color.Gray;
			this.BTSoundEffects.FlatAppearance.BorderSize = 0;
			this.BTSoundEffects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTSoundEffects.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTSoundEffects.ForeColor = System.Drawing.SystemColors.Control;
			this.BTSoundEffects.Location = new System.Drawing.Point(67, 86);
			this.BTSoundEffects.Name = "BTSoundEffects";
			this.BTSoundEffects.Size = new System.Drawing.Size(190, 27);
			this.BTSoundEffects.TabIndex = 7;
			this.BTSoundEffects.Text = "Efeitos Sonoros: ON";
			this.BTSoundEffects.UseVisualStyleBackColor = false;
			this.BTSoundEffects.Click += new System.EventHandler(this.BTSoundEffects_Click);
			// 
			// BTTheme
			// 
			this.BTTheme.BackColor = System.Drawing.Color.Gray;
			this.BTTheme.FlatAppearance.BorderSize = 0;
			this.BTTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTTheme.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BTTheme.ForeColor = System.Drawing.SystemColors.Control;
			this.BTTheme.Location = new System.Drawing.Point(67, 129);
			this.BTTheme.Name = "BTTheme";
			this.BTTheme.Size = new System.Drawing.Size(190, 27);
			this.BTTheme.TabIndex = 7;
			this.BTTheme.Text = "Theme...";
			this.BTTheme.UseVisualStyleBackColor = false;
			// 
			// UserControlOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.BTTheme);
			this.Controls.Add(this.BTSoundEffects);
			this.Name = "UserControlOptions";
			this.Size = new System.Drawing.Size(377, 302);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button BTSoundEffects;
		private System.Windows.Forms.Button BTTheme;
	}
}
