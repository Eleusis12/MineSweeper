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
	public partial class GameController
	{
		private async void V_RegisterForm_RegisterThisUser(Library.Model.User temp)
		{
			string resposta;

			try
			{
				resposta = Server.RegistarUtilizador(temp);
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
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				resposta = "Erro";

				await ShowErrorDialog("Não possível concluir a operação dado o erro" + ex.Message);
			}

			if (resposta == "OK")
			{
				Program.V_RegisterForm.ResultOfRegistration(resposta);
			}
			else if (resposta.ToLower() == "Erro".ToLower())
			{
				Program.V_RegisterForm.ResultOfRegistration(resposta);
			}
			else
			{
				Program.V_RegisterForm.ResultOfRegistration("Erro");
			}

			//string resposta = Server.RegistarUtilizador(temp);
			//if (resposta == "OK")
			//{
			//	Program.V_RegisterForm.ResultOfRegistration(resposta);
			//}
			//else if (resposta.ToLower() == "Erro".ToLower())
			//{
			//	Program.V_RegisterForm.ResultOfRegistration(resposta);
			//}
			//else
			//{
			//	Program.V_RegisterForm.ResultOfRegistration("Erro");
			//}
		}
	}
}