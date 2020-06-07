using Library.Helpers;
using Library.Interfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeperUWP.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SearchUserPage : Page, SearchUserView
	{
		public event UsernameExtractionHandler AskUserData;

		public SearchUserPage()
		{
			this.InitializeComponent();
		}

		private void TBSearch_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			if (e.Key == Windows.System.VirtualKey.Enter)
			{//execute code here
				if (AskUserData != null)
				{
					AskUserData(TBSearch.Text);
				}
			}
		}

		public void ShowProfile(User temp)
		{
			if (temp != null)
			{
				LBLNome.Text = ("Nome Abreviado: " + temp.Username);
				LBLEmail.Text = ("Email: " + temp.Email);
				LBLPais.Text = ("País: " + temp.Country);
				LBLNumeroJogos.Text = ("Número de Jogos: " + (temp.WinStats + temp.LoseStats).ToString());
				LBLNumeroJogosGanhos.Text = ("Ganhos: " + temp.WinStats.ToString());
				LBLNumeroJogosPerdidos.Text = ("Perdidos: " + temp.LoseStats.ToString());
				LBLBestTimeEasy.Text = ("Melhor tempo, Fácil: " + temp.BestTimeEasy);
				LBLBestTimeMedium.Text = ("Melhor tempo, Médio: " + temp.BestTimeMedium);
				//ImagemPerfil.

				// Apresentar ao utilizador o resultado da pesquisa
				LBLNome.Visibility = Visibility.Visible;
				LBLEmail.Visibility = Visibility.Visible;
				LBLPais.Visibility = Visibility.Visible;
				LBLNumeroJogos.Visibility = Visibility.Visible;
				LBLNumeroJogosGanhos.Visibility = Visibility.Visible;
				LBLNumeroJogosPerdidos.Visibility = Visibility.Visible;
				LBLBestTimeEasy.Visibility = Visibility.Visible;
				LBLBestTimeMedium.Visibility = Visibility.Visible;
			}
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