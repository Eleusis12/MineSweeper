using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeperProjeto;
using MineSweeperProjeto.Model;
using MineSweeperProjeto.Properties;
using MineSweeperProjeto.View;
using static MineSweeperProjeto.Program;
using Timer = System.Windows.Forms.Timer;
using Library;
using Library.Helpers;
using Library.Models;
using Library.ServerEndpoint;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		public GameController()
		{
			// Indica a dificuldade escolhida pelo utilizador
			V_StartForm.ChangeDifficultyInGame += V_GameMode_ChangeDifficulty;

			// O jogador opta por desligar/ ligar audio do jogo
			V_StartForm.TurnSoundEffectsInGame += V_StartForm_TurnSoundEffectsInGame;

			V_StartForm.AskBestScoreData += V_StartForm_AskBestScoreData;

			V_StartForm.StartReverseMode += V_StartForm_StartReverseMode;

			V_StartForm.DestroyModel += V_StartForm_DestroyModel;

			V_StartForm.SetupEventsMineSweeper += SetupEventsMineSweeper;

			SetupEventsMineSweeper();

			// Jogador termina o jogo numa vitória
			V_Vencedor.SendUsername += V_vencedor_SendUsername;
			//Server Connetion
			V_StartForm.AskListViewItems += V_StartForm_AskListViewItems;
			V_StartForm.AskUserData += V_StartForm_AskUserData;
			V_Login.SendCredentials += V_Login_SendCredentials;
			V_Register.RegisterThisUser += V_Register_RegisterThisUser;

			// Prepara o model para permitir o jogo
			SetupModel();

			// Prepara o temporizador para cronometrar a partida do jogador
			Temporizador = new Timer();
			SetupTimer();
		}

		private void SetupEventsMineSweeper()
		{
			// Jogador prime botao durante o jogo
			V_MineSweeperGame.ButtonPressed += OnButtonClicked;

			// Para debug: Jogador prime no botao que revela todos os botoes
			V_MineSweeperGame.AskToRevealAllPieces += RevealAllPieces;

			// Jogador pede um reset ao jogo
			V_MineSweeperGame.AskToResetBoard += V_MineSweeperGame_AskToResetBoard;
		}
	}
}