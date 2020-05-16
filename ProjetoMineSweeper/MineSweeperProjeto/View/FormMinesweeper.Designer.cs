using System.Drawing;

namespace MineSweeperProjeto
{
	partial class FormMinesweeper
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMinesweeper));
			this.FLPPainelBotoes = new System.Windows.Forms.FlowLayoutPanel();
			this.Cheater = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.LBLMinas = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.LBLTimer = new System.Windows.Forms.Label();
			this.BTSmile = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// FLPPainelBotoes
			// 
			resources.ApplyResources(this.FLPPainelBotoes, "FLPPainelBotoes");
			this.FLPPainelBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.FLPPainelBotoes.Name = "FLPPainelBotoes";
			// 
			// Cheater
			// 
			resources.ApplyResources(this.Cheater, "Cheater");
			this.Cheater.Name = "Cheater";
			this.Cheater.TabStop = false;
			this.Cheater.UseVisualStyleBackColor = true;
			this.Cheater.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cheater_MouseClick);
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = System.Drawing.Color.Silver;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.LBLMinas);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.LBLTimer);
			this.panel1.Controls.Add(this.BTSmile);
			this.panel1.Name = "panel1";
			// 
			// LBLMinas
			// 
			resources.ApplyResources(this.LBLMinas, "LBLMinas");
			this.LBLMinas.BackColor = System.Drawing.Color.Black;
			this.LBLMinas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(25)))), ((int)(((byte)(2)))));
			this.LBLMinas.Name = "LBLMinas";
			this.LBLMinas.UseCompatibleTextRendering = true;
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.TabStop = false;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cheater_MouseClick);
			// 
			// LBLTimer
			// 
			resources.ApplyResources(this.LBLTimer, "LBLTimer");
			this.LBLTimer.BackColor = System.Drawing.Color.Black;
			this.LBLTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(25)))), ((int)(((byte)(2)))));
			this.LBLTimer.Name = "LBLTimer";
			this.LBLTimer.UseCompatibleTextRendering = true;
			// 
			// BTSmile
			// 
			resources.ApplyResources(this.BTSmile, "BTSmile");
			this.BTSmile.BackColor = System.Drawing.Color.Transparent;
			this.BTSmile.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
			this.BTSmile.Name = "BTSmile";
			this.BTSmile.TabStop = false;
			this.BTSmile.UseVisualStyleBackColor = false;
			this.BTSmile.Click += new System.EventHandler(this.BTSmile_Click);
			this.BTSmile.Paint += new System.Windows.Forms.PaintEventHandler(this.BTSmile_Paint);
			this.BTSmile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Reset_MouseClick);
			// 
			// FormMinesweeper
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Controls.Add(this.Cheater);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.FLPPainelBotoes);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormMinesweeper";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		
		private System.Windows.Forms.FlowLayoutPanel FLPPainelBotoes;
		private System.Windows.Forms.Button BTSmile;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label LBLTimer;
		private System.Windows.Forms.Button Cheater;
		private System.Windows.Forms.Label LBLMinas;
		private System.Windows.Forms.Button button1;
	}
}

