using Library.Helpers;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeperUWP.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Register : Page
	{
		private List<string> cultureList = new List<string>();
		private CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

		public event UserExtractionHandler RegisterThisUser;

		private User temp;

		public Register()
		{
			this.InitializeComponent();
			GetCountryList();
			temp = new User();
		}

		private async void BTRegister_Click(object sender, RoutedEventArgs e)
		{
			// Fazer a verificação dos dados introduzidos

			if (String.IsNullOrEmpty(TBFirstName.Text) || String.IsNullOrEmpty(TBLastName.Text) || String.IsNullOrEmpty(TBUsername.Text) || String.IsNullOrEmpty(TBPassword.Text))
			{
				//MessageBox.Show("Formulário Incompleto", "Erro");
				await ShowErrorDialog("Formulário Incompleto");
			}

			try
			{
				new System.Net.Mail.MailAddress(this.TBEmail.Text);
				temp.Email = TBEmail.Text;
			}
			catch (FormatException)
			{
				//MessageBox.Show("Email inválido", "Formulário não aceite");
				await ShowErrorDialog("Email Inválido");
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

		private static async Task ShowErrorDialog(string _string)
		{
			var dlg = new MessageDialog(_string);

			await dlg.ShowAsync();
		}

		private void TextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
		{
			args.Cancel = args.NewText.Any(c => (!char.IsLetter(c) || !char.IsControl(c)));
		}

		private bool On_BackRequested()
		{
			if (this.Frame.CanGoBack)
			{
				this.Frame.GoBack();
				return true;
			}
			return false;
		}

		public async void ResultOfRegistration(string resposta)
		{
			if (resposta.ToLower() == "OK".ToLower())
			{
				await ShowErrorDialog("Registo efetuado com sucesso");
			}
			else if (resposta.ToLower() == "Erro".ToLower())
			{
				await ShowErrorDialog("Registo não efetuado");
			}
			this.Frame.Navigate(typeof(MainPage));
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

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			On_BackRequested();
		}

		private async void BTUploadPic_Click(object sender, RoutedEventArgs e)
		{
			FileOpenPicker openPicker = new FileOpenPicker();
			openPicker.ViewMode = PickerViewMode.Thumbnail;
			openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			openPicker.FileTypeFilter.Add(".jpg");
			openPicker.FileTypeFilter.Add(".png");
			openPicker.FileTypeFilter.Add(".bmp");

			StorageFile file = await openPicker.PickSingleFileAsync();

			if (file != null)
			{
				var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
				var image = new BitmapImage();
				image.SetSource(stream);

				//BTUploadPic.Children.Add(new Image() { Source = image, Width = 300, Height = 300 });
				//TODO: tratar de imagem
				//temp.Perfil = stream;
			}
		}

		private void Back_Button(object sender, RoutedEventArgs e)
		{
			On_BackRequested();
		}
	}
}