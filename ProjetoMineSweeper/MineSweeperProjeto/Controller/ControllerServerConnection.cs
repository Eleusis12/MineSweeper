using Library.Helpers;
using Library.Model;
using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MineSweeperProjeto.Program;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		private void V_StartForm_ChangeDifficultyInGameComingFromOnline(Dificuldade _dificuldade)
		{
			Program.M_Grelha.dificuldade = _dificuldade;
			Program.M_Status.PlayingWithTheOnlineBoard = true;

			AlteraDificuldade(Program.M_Grelha.dificuldade);
			V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal);
		}

		public void V_Register_RegisterThisUser(User temp)
		{
			string resposta = Server.RegistarUtilizador(temp);
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

		public void V_StartForm_AskUserData(string username)
		{
			User temp;
			Server.ConsultaPerfil(username, out temp);
			V_StartForm.ShowProfile(temp);
		}

		public void V_Login_SendCredentials(string username, string password)
		{
			string id;
			try
			{
				if (Server.Login(username, password, out id) == true)
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
			catch (Exception)
			{
				throw;
			}
		}

		// Efetua Operrações com o server
		public void V_StartForm_AskListViewItems()
		{
			List<Top10Resultado> listaTop10 = new List<Top10Resultado>();
			//if (M_Status.Logado == true)
			//{
			listaTop10 = Server.ConsultaTop10();
			if (listaTop10 != null)
			{
				Program.M_Status.top10Resultados = listaTop10;
				V_StartForm.ShowTop10(Dificuldade.Facil);
			}
			//}
		}
	}
}