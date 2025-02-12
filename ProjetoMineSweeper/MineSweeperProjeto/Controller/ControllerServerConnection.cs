﻿using Library.Helpers;
using Library.Models;
using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MineSweeperProjeto.Program;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		/// <summary>
		/// Faz pedido ao servidor para registar utilizador
		/// </summary>
		/// <param name="temp">Dados do Utilizador</param>
		public void V_Register_RegisterThisUser(User temp)
		{
			string resposta;

			try
			{
				resposta = Server.RegistarUtilizador(temp);
			}
			catch (WebException ex)
			{
				HandleWebException(ex);

				_ = new LogWriter(ex.Message);
				resposta = "Erro";
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				resposta = "Erro";

				ShowErrorDialog(ex);
			}

			if (resposta == "OK")
			{
				V_Register.ResultOfRegistration(resposta);
			}
			else if (resposta.ToLower() == "Erro".ToLower())
			{
				V_Register.ResultOfRegistration(resposta);
			}
			else
			{
				V_Register.ResultOfRegistration("Erro");
			}
		}

		/// <summary>
		/// Pede Dados ao servidor acerca de um username
		/// </summary>
		/// <param name="username"></param>
		public void V_StartForm_AskUserData(string username)
		{
			string resposta;
			User temp;

			try
			{
				resposta = Server.ConsultaPerfil(username, out temp);
			}
			catch (WebException ex)
			{
				HandleWebException(ex);

				_ = new LogWriter(ex.Message);
				resposta = "Erro";
				temp = null;
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				resposta = "Erro";
				temp = null;
				ShowErrorDialog(ex);
			}
			V_StartForm.ShowProfile(temp);
		}

		/// <summary>
		/// Faz Pedido ao servidor para se autenticar
		/// </summary>
		/// <param name="username">Credencial: Username</param>
		/// <param name="password">Credencial: PassWord</param>
		public void V_Login_SendCredentials(string username, string password)
		{
			string id = string.Empty;
			bool resposta;
			try
			{
				resposta = Server.Login(username, password, out id);
			}
			catch (WebException ex)
			{
				HandleWebException(ex);

				_ = new LogWriter(ex.Message);
				resposta = false;
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				resposta = false;

				ShowErrorDialog(ex);
			}

			if (resposta == true)
			{
				M_Status.Logado = true;
				M_Status.ID = id;
				MessageBox.Show("Autenticação realizada com sucesso", "Login Efetuado");

				V_StartForm.UpdateLoggedStatus();
			}
			else
			{
				MessageBox.Show("Autenticação falhada", "Login não efetuado");
			}
			V_Login.Close();
		}

		/// <summary>
		/// Faz pedido ao servidor do top 10 online
		/// </summary>
		public void V_StartForm_AskListViewItems()
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
				HandleWebException(ex);

				_ = new LogWriter(ex.Message);
				listaTop10 = null;
			}
			catch (Exception ex)
			{
				_ = new LogWriter(ex.Message);
				listaTop10 = null;

				ShowErrorDialog(ex);
			}

			if (listaTop10 != null)
			{
				Program.M_Status.top10Resultados = listaTop10;
				V_StartForm.ShowTop10AccordingtoDifficulty(Dificuldade.Facil);
			}
			//}
		}

		/// <summary>
		/// Apresenta mensagem de erro
		/// </summary>
		/// <param name="ex"></param>
		private void ShowErrorDialog(Exception ex)
		{
			MessageBox.Show("Não possível concluir a operação dado o erro: " + ex.Message);
		}

		/// <summary>
		/// Throw erro
		/// </summary>
		/// <param name="ex"></param>
		private void HandleWebException(WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
				{
					MessageBox.Show("404 not found", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (ex.Status == WebExceptionStatus.NameResolutionFailure)
			{
				MessageBox.Show("Certifique-se que está a utilizar a VPN da UTAD", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}