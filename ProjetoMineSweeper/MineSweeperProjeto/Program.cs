using Library.Interfaces;
using Library.Models;
using MineSweeperProjeto.Controller;
using MineSweeperProjeto.Model;
using MineSweeperProjeto.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperProjeto
{
	public static class Program
	{
		//M
		public static TileGrid M_Grelha { get; set; }

		public static ConnectionToServer M_Status { get; private set; }
		public static Options M_Options { get; private set; }

		public static BestScores M_BestScores { get; private set; }

		//V
		public static FormMinesweeper V_MineSweeperGame { get; set; }

		public static FormStart V_StartForm { get; private set; }

		public static FormLogin V_Login { get; private set; }
		public static FormRegister V_Register { get; private set; }
		public static FormVencedor V_Vencedor { get; private set; }

		//C
		public static GameController C_Master { get; private set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Model
			M_Grelha = new TileGrid();
			M_Status = new ConnectionToServer();
			M_Options = new Options();
			M_BestScores = new BestScores();

			// View
			V_StartForm = new FormStart();
			V_MineSweeperGame = new FormMinesweeper();
			V_Login = new FormLogin();
			V_Register = new FormRegister();
			V_Vencedor = new FormVencedor();

			// Controlador
			C_Master = new GameController();

			Application.Run(V_StartForm);
		}
	}
}