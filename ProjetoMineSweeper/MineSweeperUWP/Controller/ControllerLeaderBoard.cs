using Library.Helpers;
using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperUWP.Controller
{
	public class ControllerLeaderBoard
	{
		public App Program { get; }

		public ControllerLeaderBoard()
		{
			Program = App.Current as App;

			V_LeaderBoard_AskListViewItems();
			Program.V_LeaderBoard.PressEasyButton();
		}

		private void V_LeaderBoard_AskListViewItems()
		{
			List<Top10Resultado> listaTop10 = new List<Top10Resultado>();

			listaTop10 = Server.ConsultaTop10();
			if (listaTop10 != null)
			{
				Program.M_Status.top10Resultados = listaTop10;
				Program.V_LeaderBoard.ShowTop10AccordingtoDifficulty(Dificuldade.Facil);
			}
		}
	}
}