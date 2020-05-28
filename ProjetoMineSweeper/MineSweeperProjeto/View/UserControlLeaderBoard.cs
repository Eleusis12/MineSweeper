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

namespace MineSweeperProjeto.View
{
	public partial class UserControlLeaderBoard : UserControl
	{
		public event NotificationTaskHandler AskTop10;

		public ListView ListViewTop10
		{
			get { return LVTop10; }
			set { LVTop10 = value; }
		}

		public UserControlLeaderBoard()
		{
			InitializeComponent();

			if (AskTop10 != null)
			{
				AskTop10();
			}
		}
	}
}