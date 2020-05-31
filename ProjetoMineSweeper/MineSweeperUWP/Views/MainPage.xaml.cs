﻿using MineSweeperUWP.Controller;
using MineSweeperUWP.View;
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
	public sealed partial class MainPage : Page
	{
		private App Program;

		public MainPage()
		{
			Program = App.Current as App;
			this.InitializeComponent();

			if (Program.M_Status.Logado == true)
			{
				LBLStatus.Text = "Online";
			}
			else
			{
				LBLStatus.Text = "Offline";
			}
		}

		private void BTSinglePLayer_Click(object sender, RoutedEventArgs e)

		{
			this.Frame.Navigate(typeof(DificuldadePage));
			Frame rootFrame = GetCurrentWindow();
			Program.V_DifficultyForm = rootFrame.Content as DificuldadePage;
			//C_DifficultyForm = new ControllerDificuldade();
		}

		private void BTOnline_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Login));
			Frame rootFrame = GetCurrentWindow();
			Program.V_LoginPage = rootFrame.Content as Login;
			Program.C_LoginPage = new ControllerLogin();
		}

		private void BTOptions_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(OptionsPage));
			Frame rootFrame = GetCurrentWindow();
			Program.V_OptionsForm = rootFrame.Content as OptionsPage;
			Program.C_OptionsForm = new ControllerOptions();
		}

		private async void BTLeaderBoard_Click(object sender, RoutedEventArgs e)
		{
			if (Program.M_Status.Logado == false)
			{
				await ShowErrorDialog();
			}

			this.Frame.Navigate(typeof(LeaderBoardPage));
			Frame rootFrame = GetCurrentWindow();
			Program.V_LeaderBoard = rootFrame.Content as LeaderBoardPage;
			Program.C_LeaderBoard = new ControllerLeaderBoard();
		}

		private static async Task ShowErrorDialog()
		{
			var dlg = new MessageDialog("Não se encontra ligado ao servidor. Pressione no botão Online para efetuar o Login ao servidor. Use VPN se não se encontra conectado à rede UTAD"
								, "Autenticação não feita");

			await dlg.ShowAsync();
		}

		private void BTExit_Click(object sender, RoutedEventArgs e)
		{
			CoreApplication.Exit();
		}

		private static Frame GetCurrentWindow()
		{
			return Window.Current.Content as Frame;
		}
	}
}