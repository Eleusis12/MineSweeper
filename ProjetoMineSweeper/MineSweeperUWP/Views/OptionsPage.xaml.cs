﻿using Library.Helpers;
using Library.Interfaces;
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

namespace MineSweeperUWP.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class OptionsPage : Page, OptionsView
	{
		public event NotificationTaskHandler TurnSoundEffectsInGame;

		public OptionsPage()
		{
			this.InitializeComponent();
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

		private void BTSoundEffects_Click(object sender, RoutedEventArgs e)
		{
			if (TurnSoundEffectsInGame != null)
			{
				TurnSoundEffectsInGame();
			}
			if (BTSoundEffects.Content.ToString() == "Efeitos Sonoros: Desligado")
			{
				BTSoundEffects.Content = "Efeitos Sonoros: Ligado";
			}
			else
			{
				BTSoundEffects.Content = "Efeitos Sonoros: Desligado";
			}
		}
	}
}