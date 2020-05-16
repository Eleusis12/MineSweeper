namespace MineSweeperProjeto.View
{
	partial class FormStart
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
			this.label1 = new System.Windows.Forms.Label();
			this.PNLContainer = new System.Windows.Forms.Panel();
			this.BTBack = new System.Windows.Forms.PictureBox();
			this.PNLContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BTBack)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(331, 280);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "© 2020";
			// 
			// PNLContainer
			// 
			this.PNLContainer.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.PNLContainer.Controls.Add(this.label1);
			this.PNLContainer.Location = new System.Drawing.Point(62, 0);
			this.PNLContainer.Name = "PNLContainer";
			this.PNLContainer.Size = new System.Drawing.Size(377, 302);
			this.PNLContainer.TabIndex = 5;
			// 
			// BTBack
			// 
			this.BTBack.Dock = System.Windows.Forms.DockStyle.Left;
			this.BTBack.Image = global::MineSweeperProjeto.Properties.Resources.grey_sliderLeft;
			this.BTBack.Location = new System.Drawing.Point(0, 0);
			this.BTBack.Name = "BTBack";
			this.BTBack.Size = new System.Drawing.Size(61, 302);
			this.BTBack.TabIndex = 0;
			this.BTBack.TabStop = false;
			this.BTBack.Click += new System.EventHandler(this.BTBack_Click);
			// 
			// FormStart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
			this.ClientSize = new System.Drawing.Size(439, 302);
			this.Controls.Add(this.BTBack);
			this.Controls.Add(this.PNLContainer);
			this.Name = "FormStart";
			this.Text = "MineSweeper";
			this.Load += new System.EventHandler(this.FormStart_Load);
			this.PNLContainer.ResumeLayout(false);
			this.PNLContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BTBack)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel PNLContainer;
		private System.Windows.Forms.PictureBox BTBack;
		//private GameMode gameMode1;
	}
}