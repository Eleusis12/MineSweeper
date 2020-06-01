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
	public partial class UserControlOnlineDifficulty : UserControl
	{
		public event DifficultyChangedHandler WarnMainFormDifficultyChoiceOnline;

		public UserControlOnlineDifficulty()
		{
			InitializeComponent();
		}

		private void BTClick(object sender, EventArgs e)
		{
			if (WarnMainFormDifficultyChoiceOnline != null)
				WarnMainFormDifficultyChoiceOnline((Dificuldade)Enum.Parse(typeof(Dificuldade), (sender as Button).Tag.ToString()));
		}
	}
}