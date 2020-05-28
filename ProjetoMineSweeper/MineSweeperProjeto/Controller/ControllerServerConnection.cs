using Library.Helpers;
using Library.Model;
using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MineSweeperProjeto.Program;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		public void V_Register_RegisterThisUser(User temp)
		{
			string resposta = Server.RegistarUtilizador(temp);
			if (resposta == "OK")
			{
				V_Register.ResultOfRegistration(resposta);
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
			string id = null;
			try
			{
				if (Server.Login(username, password, out id) == true)
				{
					M_Status.Logado = true;
					M_Status.id = id;
				}
				V_Login.Close();
				V_StartForm.UpdateLoggedStatus();
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
			if (M_Status.Logado == true)
			{
				listaTop10 = Server.ConsultaTop10();
				V_StartForm.ShowTop10(listaTop10);
			}
		}
	}
}