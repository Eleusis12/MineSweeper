using Library.Helpers;
using Library.Interfaces;
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
	public partial class FormLogin : Form, LoginView
	{
		public event AccountCredentialsExtractionHandler SendCredentials;

		public FormLogin()
		{
			InitializeComponent();
		}

		private void LLBLCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Program.V_Register.ShowDialog();
			this.Close();
		}

		private void BTLogin_Click(object sender, EventArgs e)
		{
			if (SendCredentials != null)
			{
				SendCredentials(TBUsername.Text, TBPassword.Text);
			}

			if (CheckBoxRememberMe.Checked == true)
			{
				Properties.Settings.Default.Username = TBUsername.Text;
				Properties.Settings.Default.Password = TBPassword.Text;
				Properties.Settings.Default.Save();
			}
		}

		private void BTClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FormLogin_Load(object sender, EventArgs e)
		{
			TBUsername.Text = Properties.Settings.Default.Username;
			TBPassword.Text = Properties.Settings.Default.Password;
		}

		public void Response(bool resposta)
		{
			throw new NotImplementedException();
		}
	}
}