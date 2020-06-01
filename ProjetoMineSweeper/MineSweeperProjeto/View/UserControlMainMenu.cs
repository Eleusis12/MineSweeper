using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Model;

namespace MineSweeperProjeto.View
{
	public partial class UserControlMainMenu : UserControl
	{
		//public event EventHandler CloseClicked;

		public Label LabelStatus
		{
			get { return LBLStatus; }
			set { LBLStatus = value; }
		}

		public Button ButtonOnline
		{
			get { return BTOnline; }
			set { BTOnline = value; }
		}

		public UserControlMainMenu()
		{
			InitializeComponent();
		}

		private void BTSinglePlayer_Click(object sender, EventArgs e)
		{
			if (!Program.V_StartForm.PanelContainer.Controls.ContainsKey("UserControlDifficulty"))
			{
				var UCSinglePlayerMode = Program.V_StartForm.UCDifficulty;
				UCSinglePlayerMode.Dock = DockStyle.Fill;
				UCSinglePlayerMode.Anchor = AnchorStyles.Top;
				Program.V_StartForm.PanelContainer.Controls.Add(UCSinglePlayerMode);
			}
			Program.V_StartForm.PanelContainer.Controls["UserControlDifficulty"].BringToFront();
			Program.V_StartForm.BackButton.Visible = true;
			Program.V_StartForm.BackButton.BringToFront();
		}

		private void BTExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void BTOptions_Click(object sender, EventArgs e)
		{
			if (!Program.V_StartForm.PanelContainer.Controls.ContainsKey("UserControlOptions"))
			{
				var UCOptionsMode = Program.V_StartForm.UCOptions;
				UCOptionsMode.Dock = DockStyle.Fill;
				UCOptionsMode.Anchor = AnchorStyles.Top;
				Program.V_StartForm.PanelContainer.Controls.Add(UCOptionsMode);
			}
			Program.V_StartForm.PanelContainer.Controls["UserControlOptions"].BringToFront();
			Program.V_StartForm.BackButton.Visible = true;
			Program.V_StartForm.BackButton.BringToFront();
		}

		private void BTOnline_Click(object sender, EventArgs e)
		{
			if (Program.M_Status.Logado == true)
			{
				if (!Program.V_StartForm.PanelContainer.Controls.ContainsKey("UserControlOnlineDifficulty"))
				{
					var UCOnlineDifficultyMode = Program.V_StartForm.UCOnlineDifficulty;
					UCOnlineDifficultyMode.Dock = DockStyle.Fill;
					UCOnlineDifficultyMode.Anchor = AnchorStyles.Top;
					Program.V_StartForm.PanelContainer.Controls.Add(UCOnlineDifficultyMode);
				}
				Program.V_StartForm.PanelContainer.Controls["UserControlOnlineDifficulty"].BringToFront();
				Program.V_StartForm.BackButton.Visible = true;
				Program.V_StartForm.BackButton.BringToFront();
			}
			else
			{
				Program.V_Login.ShowDialog();
			}
		}

		private void PBLeaderBoard_Click(object sender, EventArgs e)
		{
			//if (Program.M_Status.Logado == false)
			//{
			//	MessageBox.Show("Não se encontra ligado ao servidor. Pressione no botão Online para efetuar o Login ao servidor. Use VPN se não se encontra conectado à rede UTAD"
			//		, "Autenticação não feita", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//}
			//else
			//{
			if (!Program.V_StartForm.PanelContainer.Controls.ContainsKey("UserControlLeaderBoard"))
			{
				var UCLeaderBoardMode = Program.V_StartForm.UCLeaderBoard;
				UCLeaderBoardMode.Dock = DockStyle.Fill;
				UCLeaderBoardMode.Anchor = AnchorStyles.Top;
				Program.V_StartForm.PanelContainer.Controls.Add(UCLeaderBoardMode);
			}
			Program.V_StartForm.PanelContainer.Controls["UserControlLeaderBoard"].BringToFront();
			Program.V_StartForm.BackButton.Visible = true;
			Program.V_StartForm.BackButton.BringToFront();
			//}
		}

		private void PBSearch_Click(object sender, EventArgs e)
		{
			//if (Program.M_Status.Logado == false)
			//{
			//	MessageBox.Show("Não se encontra ligado ao servidor. Pressione no botão Online para efetuar o Login ao servidor. Use VPN se não se encontra conectado à rede UTAD"
			//		, "Autenticação não feita", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//}
			//else
			//{
			if (!Program.V_StartForm.PanelContainer.Controls.ContainsKey("UserControlSearch"))
			{
				var UserControlSearchMode = Program.V_StartForm.UCSearch;
				UserControlSearchMode.Dock = DockStyle.Fill;
				UserControlSearchMode.Anchor = AnchorStyles.Top;
				Program.V_StartForm.PanelContainer.Controls.Add(UserControlSearchMode);
			}
			Program.V_StartForm.PanelContainer.Controls["UserControlSearch"].BringToFront();
			Program.V_StartForm.BackButton.Visible = true;
			Program.V_StartForm.BackButton.BringToFront();
			//}
		}
	}
}