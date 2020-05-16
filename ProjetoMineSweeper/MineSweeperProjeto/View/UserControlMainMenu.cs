using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperProjeto.View
{
	public partial class UserControlMainMenu : UserControl
	{
		//public event EventHandler CloseClicked;

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
			// TODO: SOLUÇÃO TEMPORARIA
			FormLogin V_Login = new FormLogin();
			V_Login.ShowDialog();
		}

		private void PBLeaderBoard_Click(object sender, EventArgs e)
		{
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
		}
	}
}