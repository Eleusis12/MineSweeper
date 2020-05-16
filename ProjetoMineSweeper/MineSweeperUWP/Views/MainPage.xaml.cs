using MineSweeperUWP.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
		}

		private void BTSinglePLayer_Click(object sender, RoutedEventArgs e)

		{
			this.Frame.Navigate(typeof(DificuldadePage));
		}

		private void BTOnline_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Login));
		}

		private void BTOptions_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(OptionsPage));
		}

		private void BTExit_Click(object sender, RoutedEventArgs e)
		{
			CoreApplication.Exit();
		}

		private void BTLeaderBoard_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(LeaderBoardPage));
		}
	}
}