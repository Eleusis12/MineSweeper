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

			//Program.V_StartForm.Hide();
			//switch ((sender as Button).Text)
			//{
			//	case "Fácil":
			//		//OnHideClicked();
			//		LançaDificuldade(Dificuldade.Facil);
			//		V_MineSweeperGame.ShowDialog();
			//		break;

			//	case "Médio":
			//		//OnHideClicked();
			//		LançaDificuldade(Dificuldade.Medio);
			//		V_MineSweeperGame.ShowDialog();
			//		break;

			//	case "Difícil":
			//		//OnHideClicked();
			//		LançaDificuldade(Dificuldade.Dificil);
			//		V_MineSweeperGame.ShowDialog();
			//		break;

			//	default:
			//		throw new ArgumentException();
			//}
			//FechaForm();
			// Depois de serem executados os dois forms, fecha este form também que estava escondido
			//this.Close();
		}

		//private void FechaForm()
		//{
		//	if (CloseForm != null)
		//		CloseForm(this, EventArgs.Empty);
		//}

		private void LançaDificuldade(Dificuldade _dificuldade)
		{
			if (WarnMainFormDifficultyChoice != null)
				WarnMainFormDifficultyChoice(_dificuldade);
		}

		//private void OnHideClicked()
		//{
		//	if (HideForm != null)
		//		HideForm(this, EventArgs.Empty);
		//}
	}
}