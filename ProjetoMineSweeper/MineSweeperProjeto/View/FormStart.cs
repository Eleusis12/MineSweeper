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
using Library.Model;

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

		internal void ShowTop10(List<Top10Resultado> listaTop10)
		{
			int i = 0;
			for (i = 0; i < 10; i++)
			{
				string[] row = { (i + 1).ToString(), listaTop10[i].Nome, listaTop10[i].Tempo, listaTop10[i].Quando };
				var listViewItem = new ListViewItem(row);
				UCLeaderBoard.ListViewTop10.Items.Add(listViewItem);
			}
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

		internal void ShowProfile(User temp)
		{
			UCSearch.GroupBoxDados.Controls["LBLNome"].Text += (" " + temp.Username);
			UCSearch.GroupBoxDados.Controls["LBLEmail"].Text += (" " + temp.Email);
			UCSearch.GroupBoxDados.Controls["LBLPais"].Text += (" " + temp.Country);
			UCSearch.GroupBoxDados.Controls["LBLNumeroJogos"].Text += (" " + (temp.WinStats + temp.LoseStats).ToString());
			UCSearch.GroupBoxDados.Controls["LBLNumeroJogosGanhos"].Text += (" " + temp.WinStats.ToString());
			UCSearch.GroupBoxDados.Controls["LBLNumeroJogosPerdidos"].Text += (" " + temp.LoseStats.ToString());
			UCSearch.GroupBoxDados.Controls["LBLBestTimeEasy"].Text += (" " + temp.Username);
			UCSearch.GroupBoxDados.Controls["LBLBestTimeMedium"].Text += (" " + temp.Username);
		}

		public void UpdateLoggedStatus()
		{
			UCMainMenu.LabelStatus.Text = "Online";
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