using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MineSweeperUWP.Controller
{
	public class ControllerLogin
	{
		public App Program { get; }

		public ControllerLogin()
		{
			Program = App.Current as App;
			Program.V_LoginPage.SendCredentials += V_Login_SendCredentials;
		}

		public void V_Login_SendCredentials(string username, string password)
		{
			string id;
			bool resposta = Server.Login(username, password, out id);

			try
			{
				if (resposta == true)
				{
					Program.M_Status.Logado = true;
					Program.M_Status.ID = id;
				}

				Program.V_LoginPage.Response(resposta);
			}
			catch (Exception)
			{
				throw;
			}
		}

		private static async Task ShowErrorDialog(string message)
		{
			var dlg = new MessageDialog(message);

			await dlg.ShowAsync();
		}
	}
}