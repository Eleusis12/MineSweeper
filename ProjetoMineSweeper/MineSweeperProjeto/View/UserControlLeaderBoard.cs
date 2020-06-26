using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Helpers;
using Library.Interfaces;
using System.Diagnostics;

namespace MineSweeperProjeto.View
{
	public partial class UserControlLeaderBoard : UserControl
	{
		public event NotificationTaskHandler AskTop10;

		public event DifficultyExtractionHandler ShowTop10AccordingtoDifficulty;

		public event UsernameExtractionHandler ShowProfile;

		public ListView ListViewTop10
		{
			get { return LVTop10; }
			set { LVTop10 = value; }
		}

		public UserControlLeaderBoard()
		{
			InitializeComponent();
		}

		private void UserControlLeaderBoard_Load(object sender, EventArgs e)
		{
			if (AskTop10 != null)
			{
				AskTop10();
			}
		}

		private void ShowTop10Difficulty(object sender, EventArgs e)
		{
			if (ShowTop10AccordingtoDifficulty != null)
			{
				ShowTop10AccordingtoDifficulty((Dificuldade)Enum.Parse(typeof(Dificuldade), (sender as Button).Tag.ToString()));
			}
		}

		private void LVTop10_MouseClick(object sender, MouseEventArgs e)
		{
			// Get the information of an item that is located in a given point (mouse location in this case).
			ListViewHitTestInfo hit = LVTop10.HitTest(e.Location);
			// hit.Item: Gets the ListViewItem.
			// hit.SubItem: Get the ListViewItem.ListViewSubItem

			int colNr = hit.Item.SubItems.IndexOf(hit.SubItem);
			if (colNr == 1)
			{
				if (ShowProfile != null)
				{
					Program.M_Status.SearchingFromLeaderBoard = true;
					ShowProfile(hit.SubItem.Text);
				}
			}
		}
	}
}