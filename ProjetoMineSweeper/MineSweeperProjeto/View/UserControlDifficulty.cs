using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeperProjeto.Controller;
using MineSweeperProjeto.Model;
using static MineSweeperProjeto.Program;
using Library;
using Library.Helpers;

namespace MineSweeperProjeto.View
{
	public partial class UserControlDifficulty : UserControl
	{
		public event DifficultyChangedHandler WarnMainFormDifficultyChoice;

		public UserControlDifficulty()
		{
			InitializeComponent();
		}

		private void BTClick(object sender, EventArgs e)
		{
			if (WarnMainFormDifficultyChoice != null)
				WarnMainFormDifficultyChoice((Dificuldade)Enum.Parse(typeof(Dificuldade), (sender as Button).Tag.ToString()));
		}
	}
}