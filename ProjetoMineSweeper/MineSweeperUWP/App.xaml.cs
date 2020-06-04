using MineSweeperUWP.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Library.Model;
using MineSweeperUWP.Controller;
using MineSweeperProjeto.Helpers;
using MineSweeperUWP.Views;

namespace MineSweeperUWP
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	///
	//public static TileGrid M_Grelha { get; private set; }

	public partial class App : Application
	{
		public static SoundEffects SoundPlayer;

		// Models
		public TileGrid M_Grelha { get; private set; }

		public ConnectionToServer M_Status { get; private set; }

		public Options M_Options { get; private set; }

		//Views
		public MineSweeper V_MineSweeperGame { get; set; }

		public MainPage V_StartForm { get; set; }
		public DificuldadePage V_DifficultyForm { get; set; }

		public LeaderBoardPage V_LeaderBoard { get; set; }
		public OptionsPage V_OptionsForm { get; set; }
		public Register V_RegisterForm { get; set; }
		public Login V_LoginPage { get; set; }

		public SearchUserPage V_SearchPage { get; set; }

		// Controller

		public ControllerMineSweeperGameCode C_MineSweeperGame { get; set; }
		public ControllerLeaderBoard C_LeaderBoard { get; set; }
		public ControllerOptions C_OptionsForm { get; set; }
		public ControllerRegister C_RegisterForm { get; set; }
		public ControllerLogin C_LoginPage { get; set; }

		public ControllerSearchUser C_SearchPage { get; set; }

		// Controllers

		//public static FormVencedor V_Vencedor { get; private set; }
		//public static GameController C_Master { get; private set; }

		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			this.InitializeComponent();
			this.Suspending += OnSuspending;

			M_Grelha = new TileGrid();
			M_Status = new ConnectionToServer();
			M_Options = new Options();

			// class que vai permitir a reprodução de audio
			SoundPlayer = new SoundEffects();
		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;

			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if (rootFrame == null)
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window.Current.Content = rootFrame;
			}

			if (e.PrelaunchActivated == false)
			{
				if (rootFrame.Content == null)
				{
					// When the navigation stack isn't restored navigate to the first page,
					// configuring the new page by passing required information as a navigation
					// parameter
					rootFrame.Navigate(typeof(MainPage), e.Arguments);
				}
				ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(1500, 1500));
				// Ensure the current window is active
				Window.Current.Activate();
			}
			//No final do método OnLaunched instanciam-se as Views os Controllers//Views
			V_StartForm = rootFrame.Content as MainPage;

			//V_MineSweeperGame = rootFrame.Content as MineSweeper;
			//V_LeaderBoard = rootFrame.Content as LeaderBoardPage;
			//V_OptionsForm = rootFrame.Content as OptionsPage;
			//V_RegisterForm = rootFrame.Content as Register;
			//V_LoginPage = rootFrame.Content as Login;
			////Controllers
			//C_StartForm = new ControllerMainPage();

			//C_MineSweeperGame = new ControllerMineSweeper();

			//C_LeaderBoard = new ControllerLeaderBoard();
			//C_OptionsForm = new ControllerOptions();
			//C_RegisterForm = new ControllerRegister();
			//C_LoginPage = new ControllerLogin();
			//C_Vencedor = new ControllerVencedor();
		}

		internal void V_MineSweeperGame_AskToResetBoard()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">The Frame which failed navigation</param>
		/// <param name="e">Details about the navigation failure</param>
		private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// Invoked when application execution is being suspended.  Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}
	}
}