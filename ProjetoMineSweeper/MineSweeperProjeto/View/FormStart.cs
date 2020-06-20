using MineSweeperProjeto.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using MineSweeperProjeto.Model;
using Library.Helpers;
using Library.Models;
using Library.Interfaces;
using System.Threading;

namespace MineSweeperProjeto.View
{
	public partial class FormStart : Form, DifficultyView, LeaderBoardView, MainView, OptionsView, SearchUserView
	{
		public event DifficultyChangedHandler ChangeDifficultyInGame;

		public event DifficultyChangedHandler StartReverseMode;

		public event NotificationTaskHandler TurnSoundEffectsInGame;

		public event NotificationTaskHandler AskListViewItems;

		public event NotificationTaskHandler SetupEventsMineSweeper;

		public event UsernameExtractionHandler AskUserData;

		public event NotificationTaskHandler AskBestScoreData;

		public event NotificationTaskHandler DestroyModel;

		public UserControlDifficulty UCDifficulty { get; set; }
		public UserControlMainMenu UCMainMenu { get; set; }
		public UserControlOptions UCOptions { get; set; }
		public UserControlLeaderBoard UCLeaderBoard { get; set; }
		public UserControlSearch UCSearch { get; set; }

		private List<Entry> HighScores;

		public Panel PanelContainer
		{
			get { return PNLContainer; }
			set { PNLContainer = value; }
		}

		public PictureBox BackButton
		{
			get { return BTBack; }
			set { BTBack = value; }
		}

		private Thread thread;
		private ThreadStart threadStart;

		public FormStart()
		{
			InitializeComponent();

			//mainMenu1.CloseClicked += SinglePlayerMode;
			//gameMode1.CloseForm += close;
			//gameMode1.HideForm += hide;
			//gameMode1.ChangeDifficulty += GameMode1_ChangeDifficulty;
		}

		public void ShowBestScore()
		{
			HighScores = new List<Entry>();
			HighScores = new List<Entry>();
			TryAddToList(Program.M_BestScores.EasyBestScore);
			TryAddToList(Program.M_BestScores.MediumBestScore);
			TryAddToList(Program.M_BestScores.HardBestScore);

			void TryAddToList(Entry entrada)
			{
				if (entrada != null)
					HighScores.Add(entrada);
			}

			threadStart = new ThreadStart(GetTheThreadStarted);

			thread = new Thread(threadStart);

			UCMainMenu.LabelBestScore.Visible = true;
			thread.Start();
			//for (int i = 0; i < 3; i++)
			//{
			//	UCMainMenu.LabelBestScore.Visible = true;
			//	UCMainMenu.LabelBestScore.Text = "Melhor Score: " + temp.Tempo + "(" + temp.Nivel + ")";

			//	ToolTip TPShowUsername = new ToolTip();
			//	The below are optional, of course,

			//	TPShowUsername.ToolTipIcon = ToolTipIcon.Info;
			//	TPShowUsername.IsBalloon = true;
			//	TPShowUsername.ShowAlways = true;

			//	TPShowUsername.SetToolTip(UCMainMenu.LabelBestScore, "Este score foi atingido por: " + temp.Username);
			//}
		}

		public void GetTheThreadStarted()
		{
			ScoreExtractionHandler dlg_UpdateLabel = new ScoreExtractionHandler(UpdateLabelBestScore);

			for (int i = 0; i < HighScores.Count(); i++)
			{
				UCMainMenu.LabelBestScore.BeginInvoke(dlg_UpdateLabel, HighScores[i]);
				Thread.Sleep(4000);

				if (i == HighScores.Count - 1)
					i = -1;
			}
		}

		private void UpdateLabelBestScore(Entry entrada)
		{
			UCMainMenu.LabelBestScore.Text = "Melhor Score: " + entrada.Tempo + "(" + entrada.Nivel + ")";

			ToolTip TPShowUsername = new ToolTip();
			//The below are optional, of course,

			TPShowUsername.ToolTipIcon = ToolTipIcon.Info;
			TPShowUsername.IsBalloon = true;
			TPShowUsername.ShowAlways = true;

			TPShowUsername.SetToolTip(UCMainMenu.LabelBestScore, "Este score foi atingido por: " + entrada.Username);
		}

		public void ShowTop10AccordingtoDifficulty(Dificuldade dificuldade)
		{
			int i, rank = 0;
			UCLeaderBoard.ListViewTop10.Items.Clear();
			List<Top10Resultado> listaTop10 = Program.M_Status.top10Resultados;
			for (i = 0; i < listaTop10.Count; i++)
			{
				if (dificuldade.ToString() != listaTop10[i].dificuldade)
				{
					continue;
				}

				ListViewItem item = new ListViewItem();
				item.Text = ((rank + 1).ToString());
				item.SubItems.Add(listaTop10[i].Nome);
				item.SubItems.Add(listaTop10[i].Tempo);
				item.SubItems.Add(listaTop10[i].Quando);
				item.SubItems.Add(listaTop10[i].dificuldade);
				rank++;

				//row[i] = { (i + 1).ToString(), listaTop10[i].Nome, listaTop10[i].Tempo, listaTop10[i].Quando, listaTop10[i].dificuldade };
				//var listViewItem = new ListViewItem(row);
				UCLeaderBoard.ListViewTop10.Items.Add(item);
			}
		}

		// Informa o Controlador a dificuldade escolhida
		private void UCDifficulty_WarnMainFormDifficultyChoice(Dificuldade dificuldade)
		{
			Program.M_Options.ModoJogo = GameMode.Normal;

			if (Program.V_MineSweeperGame.IsDisposed)
			{
				Program.V_MineSweeperGame = new FormMinesweeper();
				if (SetupEventsMineSweeper != null)
				{
					SetupEventsMineSweeper();
				}
			}
			this.Hide();
			thread.Abort();

			if (ChangeDifficultyInGame != null)
				ChangeDifficultyInGame(dificuldade);

			Program.V_MineSweeperGame.ShowDialog();

			Program.V_MineSweeperGame.Dispose();

			if (DestroyModel != null)
			{
				DestroyModel();
			}
			this.Show();
		}

		private void UCDifficulty_WarnMainFormReverseModeChoice(Dificuldade dificuldade)
		{
			Program.M_Options.ModoJogo = GameMode.Inverso;

			if (Program.V_MineSweeperGame.IsDisposed)
			{
				Program.V_MineSweeperGame = new FormMinesweeper();
				if (SetupEventsMineSweeper != null)
				{
					SetupEventsMineSweeper();
				}
			}
			this.Hide();
			thread.Abort();

			if (StartReverseMode != null)
				StartReverseMode(dificuldade);

			Program.V_MineSweeperGame.ShowDialog();

			Program.V_MineSweeperGame.Dispose();

			if (DestroyModel != null)
			{
				DestroyModel();
			}
			this.Show();
		}

		private void FormStart_Load(object sender, EventArgs e)
		{
			BTBack.Visible = false;
			// Quando o form é carregado, criamos objetos referentes a cada user control que irá ser disponibilizado ao utilizador
			UCOptions = new UserControlOptions();
			UCDifficulty = new UserControlDifficulty();
			UCLeaderBoard = new UserControlLeaderBoard();
			UCSearch = new UserControlSearch();

			UCDifficulty.WarnMainFormDifficultyChoice += UCDifficulty_WarnMainFormDifficultyChoice;
			UCDifficulty.WarnMainFormReverseModeChoice += UCDifficulty_WarnMainFormReverseModeChoice;

			UCOptions.WarnMainFormSoundEffectsChoice += UCOptions_WarnMainFormSoundEffectsChoice;
			UCLeaderBoard.AskTop10 += UCLeaderBoard_AskTop10;
			UCLeaderBoard.ShowTop10AccordingtoDifficulty += UCLeaderBoard_ShowTop10AccordingtoDifficulty;
			UCSearch.AskUserData += UCSearch_AskUserData;

			// Apresenta o Main Menu ao utilizador
			UCMainMenu = new UserControlMainMenu();
			UCMainMenu.Dock = DockStyle.Fill;
			UCMainMenu.Anchor = AnchorStyles.Top;
			PNLContainer.Controls.Add(UCMainMenu);

			// Pede o melhor score
			if (AskBestScoreData != null)
			{
				AskBestScoreData();
			}
		}

		private void UCLeaderBoard_ShowTop10AccordingtoDifficulty(Dificuldade dificuldade)
		{
			ShowTop10AccordingtoDifficulty(dificuldade);
		}

		public void ShowProfile(User temp)
		{
			if (temp != null)
			{
				UCSearch.GroupBoxDados.Controls["LBLNome"].Text = ("Nome Abreviado: " + temp.Username);
				UCSearch.GroupBoxDados.Controls["LBLEmail"].Text = ("Email: " + temp.Email);
				UCSearch.GroupBoxDados.Controls["LBLPais"].Text = ("País: " + temp.Country);
				UCSearch.GroupBoxDados.Controls["LBLNumeroJogos"].Text = ("Número de Jogos: " + (temp.WinStats + temp.LoseStats).ToString());
				UCSearch.GroupBoxDados.Controls["LBLNumeroJogosGanhos"].Text = ("Ganhos: " + temp.WinStats.ToString());
				UCSearch.GroupBoxDados.Controls["LBLNumeroJogosPerdidos"].Text = ("Perdidos: " + temp.LoseStats.ToString());
				UCSearch.GroupBoxDados.Controls["LBLBestTimeEasy"].Text = ("Melhor tempo, Fácil: " + temp.BestTimeEasy);
				UCSearch.GroupBoxDados.Controls["LBLBestTimeMedium"].Text = ("Melhor tempo, Médio: " + temp.BestTimeMedium);
				UCSearch.PictureBoxProfilePic.Image = temp.Perfil;
				UCSearch.PictureBoxProfilePic.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		public void UpdateLoggedStatus()
		{
			UCMainMenu.LabelStatus.Text = "Online";
			UCMainMenu.ButtonOnline.Text = "MultiPlayer";
		}

		//  O utilizador pretende retrodecer uma página
		public void BTBack_Click(object sender, EventArgs e)
		{
			PNLContainer.Controls["UserControlMainMenu"].BringToFront();
			BTBack.Visible = false;
		}

		public void UCLeaderBoard_AskTop10()
		{
			if (AskListViewItems != null)
			{
				AskListViewItems();
			}
		}

		public void UCSearch_AskUserData(string username)
		{
			if (AskUserData != null)
			{
				AskUserData(username);
			}
		}

		public void UCOptions_WarnMainFormSoundEffectsChoice()
		{
			if (TurnSoundEffectsInGame != null)
			{
				TurnSoundEffectsInGame();
			}
		}
	}
}