using Library.Helpers;
using MineSweeperUWP.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeperUWP.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Login : Page
	{
		public App Program { get; }

		public event AccountCredentialsExtractionHandler SendCredentials;

		public Login()
		{
			Program = App.Current as App;
			this.InitializeComponent();
		}

		private void BTRegister_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Register));
			Frame rootFrame = Window.Current.Content as Frame;
			Program.V_RegisterForm = rootFrame.Content as Register;
			Program.C_RegisterForm = new ControllerRegister();
		}

		private void BTLogin_Click(object sender, RoutedEventArgs e)
		{
			if (SendCredentials != null)
			{
				SendCredentials(TBUsername.Text, TBPassword.Password.ToString());
			}
		}

		private void BTClose_Click(object sender, EventArgs e)
		{
			CoreApplication.Exit();
		}

		private static async Task ShowErrorDialog(string _string)
		{
			var dlg = new MessageDialog(_string);

			await dlg.ShowAsync();
		}

		public async void Response(bool response)
		{
			if (response == true)
			{
				await ShowErrorDialog("A autenticação foi efetuada com sucesso.");
			}
			else
			{
				await ShowErrorDialog("Não foi possível efetuar a autenticação.");
			}

			On_BackRequested();
		}

		private void Back_Button(object sender, RoutedEventArgs e)
		{
			On_BackRequested();
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
	}
}