using Library.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperProjeto.View
{
	public partial class FormLogin : Form
	{
		public event AccountCredentialsExtractionHandler SendCredentials;

		public FormLogin()
		{
			InitializeComponent();
		}

		private void LLBLCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// TODO: Solução temporária
			FormRegister V_Resgister = new FormRegister();
			V_Resgister.ShowDialog();
			this.Close();
		}

		private void BTLogin_Click(object sender, EventArgs e)
		{
			if (SendCredentials != null)
			{
				SendCredentials(TBUsername.Text, TBPassword.Text);
			}
		}

		private void BTClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}