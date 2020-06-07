using Library.Helpers;
using Library.Interfaces;
using Library.Models;
using MineSweeperProjeto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperProjeto.View
{
	public partial class FormRegister : Form, RegisterView
	{
		private List<string> cultureList = new List<string>();
		private CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

		public event UserExtractionHandler RegisterThisUser;

		private User temp;

		public FormRegister()
		{
			InitializeComponent();
			temp = new User();
		}

		private void BTRegister_Click(object sender, EventArgs e)
		{
			// Fazer a verificação dos dados introduzidos

			if (String.IsNullOrEmpty(TBFirstName.Text) || String.IsNullOrEmpty(TBLastName.Text) || String.IsNullOrEmpty(TBUsername.Text) || String.IsNullOrEmpty(TBPassword.Text))
			{
				MessageBox.Show("Formulário Incompleto", "Erro");
			}

			try
			{
				new System.Net.Mail.MailAddress(this.TBEmail.Text);
				temp.Email = TBEmail.Text;
			}
			catch (FormatException)
			{
				MessageBox.Show("Email inválido", "Formulário não aceite");
			}

			temp.Firstname = TBFirstName.Text;
			temp.LastName = TBLastName.Text;
			temp.Username = TBUsername.Text;
			temp.Password = TBPassword.Text;
			temp.Country = CBCountry.SelectedItem.ToString();

			if (RegisterThisUser != null)
			{
				RegisterThisUser(temp);
			}
		}

		private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
		}

		private void FormRegister_Load(object sender, EventArgs e)
		{
			GetCountryList();
		}

		public void ResultOfRegistration(string resposta)
		{
			if (resposta.ToLower() == "OK".ToLower())
			{
				MessageBox.Show("Registo efetuado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (resposta.ToLower() == "Erro".ToLower())
			{
				MessageBox.Show("Registo não efetuado", "Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Close();
		}

		public void GetCountryList()
		{
			foreach (CultureInfo culture in cultures)
			{
				RegionInfo region = new RegionInfo(culture.LCID);

				if (!(cultureList.Contains(region.EnglishName)))
				{
					cultureList.Add(region.EnglishName);
					CBCountry.Items.Add(region.EnglishName);
				}
			}

			CBCountry.SelectedItem = "Portugal";
		}

		private void BTUploadPic_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();

			dlg.Title = "Open Image";
			dlg.Filter = "bmp files (*.bmp)|*.bmp | Todos os ficheiros| *.*";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Bitmap imagem = new Bitmap(dlg.FileName);
				Image imagemConvertida = (Image)imagem;
				PBProfilePic.Image = imagemConvertida;
				temp.Perfil = imagemConvertida;
			}

			dlg.Dispose();
		}
	}
}