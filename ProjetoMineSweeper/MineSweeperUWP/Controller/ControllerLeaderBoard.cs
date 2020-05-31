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
		public ControllerLeaderBoard()
		{
			Program = App.Current as App;

			Program.V_LeaderBoard.AskListViewItems += V_LeaderBoard_AskListViewItems;
		}

		private void V_LeaderBoard_AskListViewItems()
		{
			List<Top10Resultado> listaTop10 = new List<Top10Resultado>();
			if (Program.M_Status.Logado == true)
			{
				listaTop10 = Server.ConsultaTop10();
				Program.V_LeaderBoard.ShowTop10(listaTop10);
			}
		}

		public App Program { get; }
	}
}