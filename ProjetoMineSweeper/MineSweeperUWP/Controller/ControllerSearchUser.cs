using Library.Helpers;
using Library.Model;
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
	public class ControllerSearchUser
	{
		public App Program { get; }

		public ControllerSearchUser()
		{
			Program = App.Current as App;

			Program.V_SearchPage.AskUserData += V_SearchPage_AskUserData;
		}

		private async void V_SearchPage_AskUserData(string username)
		{
			string resposta;
			User temp;

			try
			{
				resposta = Server.ConsultaPerfil(username, out temp);
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
				resposta = "Erro";
				temp = null;
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				resposta = "Erro";
				temp = null;
				await ShowErrorDialog(ex.Message);
			}
			Program.V_SearchPage.ShowProfile(temp);
		}

		private async Task ShowErrorDialog(string _string)
		{
			var dlg = new MessageDialog(_string);

			await dlg.ShowAsync();
		}
	}
}