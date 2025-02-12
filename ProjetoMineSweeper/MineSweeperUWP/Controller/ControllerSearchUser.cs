﻿using Library.Helpers;
using Library.Models;
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
		/// <summary>
		/// Pede Dados ao servidor acerca de um username
		/// </summary>
		/// <param name="username"></param>
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
	}
}