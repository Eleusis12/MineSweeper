using Library.Interfaces;
using MineSweeperUWP.Controller;
using MineSweeperUWP.View;
using MineSweeperUWP.Views;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MineSweeperUWP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page, MainView
	{
		private App Program;

		public MainPage()
		{
			Program = App.Current as App;
			this.InitializeComponent();

			if (Program.M_Status.Logado == true)
			{
				LBLStatus.Text = "Online";
				BTOnline.Content = "MultiPlayer";
			}
			else
			{
				LBLStatus.Text = "Offline";
				BTOnline.Content = "Online";
			}
		}

		private void BTSinglePLayer_Click(object sender, RoutedEventArgs e)

		{
			this.Frame.Navigate(typeof(DificuldadePage));

			//C_DifficultyForm = new ControllerDificuldade();
		}

		private void BTOnline_Click(object sender, RoutedEventArgs e)
		{
			if (Program.M_Status.Logado == true)
			{
				Program.M_Status.PlayingWithTheOnlineBoard = true;
				this.Frame.Navigate(typeof(DificuldadePage));
			}
			else
			{
				this.Frame.Navigate(typeof(LoginPage));
			}
		}

		private void BTOptions_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(OptionsPage));
		}

		private void BTLeaderBoard_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(LeaderBoardPage));
		}

		private void BTSearch_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(SearchUserPage));
		}

		private void BTExit_Click(object sender, RoutedEventArgs e)
		{
			CoreApplication.Exit();
		}
	}
}