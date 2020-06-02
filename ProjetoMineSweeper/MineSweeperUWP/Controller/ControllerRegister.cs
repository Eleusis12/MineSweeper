using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperUWP.Controller
{
	public class ControllerRegister
	{
		public App Program { get; }

		public ControllerRegister()
		{
			Program = App.Current as App;

			Program.V_RegisterForm.RegisterThisUser += V_RegisterForm_RegisterThisUser;
		}

		private void V_RegisterForm_RegisterThisUser(Library.Model.User temp)
		{
			string resposta = Server.RegistarUtilizador(temp);
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
		}
	}
}