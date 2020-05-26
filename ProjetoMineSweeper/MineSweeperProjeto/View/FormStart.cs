using MineSweeperProjeto.Controller;
using MineSweeperProjeto.Helpers;
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

namespace MineSweeperProjeto.View
{
	public partial class FormStart : Form
	{
		public event DifficultyChangedHandler ChangeDifficultyInGame;

		public event NotificationTaskHandler TurnSoundEffectsInGame;

		public event NotificationTaskHandler AskListViewItems;

		public event UsernameExtractionHandler AskUserData;

		public UserControlDifficulty UCDifficulty { get; set; }
		public UserControlMainMenu UCMainMenu { get; set; }
		public UserControlOptions UCOptions { get; set; }
		public UserControlLeaderBoard UCLeaderBoard { get; set; }
		public UserControlSearch UCSearch { get; set; }

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

		public FormStart()
		{
			InitializeComponent();

			//mainMenu1.CloseClicked += SinglePlayerMode;
			//gameMode1.CloseForm += close;
			//gameMode1.HideForm += hide;
			//gameMode1.ChangeDifficulty += GameMode1_ChangeDifficulty;
		}

		// Informa o Controlador a dificuldade escolhida
		private void UCDifficulty_WarnMainFormDifficultyChoice(Dificuldade dificuldade)
		{
			if (ChangeDifficultyInGame != null)
				ChangeDifficultyInGame(dificuldade);

			this.Hide();
			Program.V_MineSweeperGame.ShowDialog();
			this.Close();
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
			UCOptions.WarnMainFormSoundEffectsChoice += UCOptions_WarnMainFormSoundEffectsChoice;
			UCLeaderBoard.AskTop10 += UCLeaderBoard_AskTop10;
			UCSearch.AskUserData += UCSearch_AskUserData;

			// Apresenta o Main Menu ao utilizador
			UCMainMenu = new UserControlMainMenu();
			UCMainMenu.Dock = DockStyle.Fill;
			UCMainMenu.Anchor = AnchorStyles.Top;
			PNLContainer.Controls.Add(UCMainMenu);
		}

		//  O utilizador pretende retrodecer uma página
		private void BTBack_Click(object sender, EventArgs e)
		{
			PNLContainer.Controls["UserControlMainMenu"].BringToFront();
			BTBack.Visible = false;
		}

		private void UCLeaderBoard_AskTop10()
		{
			if (AskListViewItems != null)
			{
				AskListViewItems();
			}
		}

		private void UCSearch_AskUserData(string username)
		{
			if (AskUserData != null)
			{
				AskUserData(username);
			}
		}

		private void UCOptions_WarnMainFormSoundEffectsChoice()
		{
			if (TurnSoundEffectsInGame != null)
			{
				TurnSoundEffectsInGame();
			}
		}
	}
}