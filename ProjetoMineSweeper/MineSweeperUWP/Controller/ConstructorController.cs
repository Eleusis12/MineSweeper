using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MineSweeperUWP.Controller
{
	public partial class GameController
	{
		public App Program { get; set; }

		public GameController()
		{
			Program = App.Current as App;

			//if (Program.V_DifficultyForm != null)
			//{
			//	SetupEventsDifficultyView();
			//}

			//if (Program.V_StartForm != null)
			//{
			//	SetupEventsMainView();
			//}

			if (Program.V_LeaderBoard != null)
			{
				SetupEventsLeaderBoardView();
			}
			if (Program.V_LoginPage != null)
			{
				SetupEventsLoginView();
			}

			if (Program.V_MineSweeperGame != null)
			{
				SetupEventsMineSweeperView();
			}
			if (Program.V_OptionsForm != null)
			{
				SetupEventsOptionsView();
			}
			if (Program.V_RegisterForm != null)
			{
				SetupEventsRegisterView();
			}
			if (Program.V_SearchPage != null)
			{
				SetupEventsSearchUserView();
			}
		}

		//internal void SetupEventsDifficultyView()
		//{
		//	throw new NotImplementedException();
		//}

		//internal void SetupEventsMainView()
		//{
		//	throw new NotImplementedException();
		//}

		internal void SetupEventsLeaderBoardView()
		{
			// LeaderBoard

			Program.V_LeaderBoard.AskListViewItems += V_LeaderBoard_AskListViewItems;
		}

		internal void SetupEventsLoginView()
		{
			//Login

			Program.V_LoginPage.SendCredentials += V_Login_SendCredentials;
		}

		internal void SetupEventsMineSweeperView()
		{
			// MineSweeper
			// Jogador prime botao durante o jogo
			Program.V_MineSweeperGame.LeftButtonPressed += V_MineSweeperGame_LeftButtonPressed;

			// O jogador tenta colocar uma flag
			Program.V_MineSweeperGame.RightButtonPressed += V_MineSweeperGame_RightButtonPressed;

			//// Para debug: Jogador prime no botao que revela todos os botoes
			//Program.V_MineSweeperGame.AskToRevealAllPieces += Reveal;

			// Jogador pede um reset ao jogo
			Program.V_MineSweeperGame.AskToResetBoard += V_MineSweeperGame_AskToResetBoard;

			Program.V_MineSweeperGame.UpdateTimer += V_MineSweeperGame_UpdateTimer;
			SetupModel();
		}

		internal void SetupEventsOptionsView()
		{
			//Options
			Program.V_OptionsForm.TurnSoundEffectsInGame += V_OptionsForm_WarnMainFormSoundEffectsChoice;
		}

		internal void SetupEventsRegisterView()
		{
			//Register
			Program.V_RegisterForm.RegisterThisUser += V_RegisterForm_RegisterThisUser;
		}

		internal void SetupEventsSearchUserView()
		{
			//Search
			Program.V_SearchPage.AskUserData += V_SearchPage_AskUserData;
		}

		private async Task ShowErrorDialog(string _string)
		{
			var dlg = new MessageDialog(_string);

			await dlg.ShowAsync();
		}
	}
}