using Library.Helpers;
using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MineSweeperUWP.Controller
{
	public partial class GameController
	{
		/// <summary>
		/// Faz Pedido ao servidor para se autenticar
		/// </summary>
		/// <param name="username">Credencial: Username</param>
		/// <param name="password">Credencial: PassWord</param>
		///
		public async void V_Login_SendCredentials(string username, string password)
		{
			string id = string.Empty;
			bool resposta;
			try
			{
				resposta = Server.Login(username, password, out id);
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
				resposta = false;
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				resposta = false;

				await ShowErrorDialog(ex.Message);
			}

			if (resposta == true)
			{
				Program.M_Status.Logado = true;
				Program.M_Status.ID = id;
			}

			Program.V_LoginPage.Response(resposta);
		}

		// Apresenta uma Mensagem de Erro
	}
}