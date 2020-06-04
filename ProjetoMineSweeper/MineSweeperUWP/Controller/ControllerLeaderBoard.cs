using Library.Helpers;
using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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

		private async void V_LeaderBoard_AskListViewItems()
		{
			List<Top10Resultado> listaTop10 = new List<Top10Resultado>();
			//if (M_Status.Logado == true)
			//{
			try
			{
				listaTop10 = Server.ConsultaTop10();
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
					{
						await ShowErrorDialog("404 not found - " + ex.Message);
					}
				}
				else if (ex.Status == WebExceptionStatus.NameResolutionFailure)
				{
					await ShowErrorDialog("Certifique-se que está a utilizar a VPN da UTAD" + ex.Message);
				}

				_ = new LogWriter(ex.Message);
				listaTop10 = null;
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				listaTop10 = null;

				await ShowErrorDialog(ex.Message);
			}

			if (listaTop10 != null)
			{
				Program.M_Status.top10Resultados = listaTop10;
				Program.V_LeaderBoard.ShowTop10AccordingtoDifficulty(Dificuldade.Facil);
			}
		}

		private async Task ShowErrorDialog(string _string)
		{
			var dlg = new MessageDialog(_string);

			await dlg.ShowAsync();
		}
	}
}