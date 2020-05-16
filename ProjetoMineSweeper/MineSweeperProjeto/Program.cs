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
		// Enum
		public enum Dificuldade { Facil, Medio, Dificil }

		public static TileGrid M_Grelha { get; private set; }

		public static FormMinesweeper V_MineSweeperGame { get; private set; }
		public static FormStart V_StartForm { get; private set; }

		public static FormVencedor V_Vencedor { get; private set; }
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

			// View
			V_StartForm = new FormStart();
			V_MineSweeperGame = new FormMinesweeper();
			V_Vencedor = new FormVencedor();

			// Controlador
			C_Master = new GameController();

			Application.Run(V_StartForm);
		}
	}
}