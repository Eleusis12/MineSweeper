using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MineSweeperProjeto.Program;
using Timer = System.Windows.Forms.Timer;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		public static Timer Temporizador { get; private set; }

		// Temporizador
		public void SetupTimer()
		{
			V_MineSweeperGame.AtualizaTempo("00:00");
			// Temporizador
			Temporizador.Interval = 1000; //1 sec
			Temporizador.Tick += TimerTick;
			M_Grelha.TimerCounter = 0;
		}

		/// <summary>
		/// Formata temporizador para uma string de forma legível
		/// </summary>
		/// <returns></returns>
		public string GetTimeString()
		{
			//create time span from our counter
			TimeSpan time = TimeSpan.FromSeconds(M_Grelha.TimerCounter);

			//format that into a string
			string timeString = time.ToString(@"mm\:ss");

			//return it
			return timeString;
		}

		public void TimerTick(object sender, EventArgs e)
		{
			M_Grelha.TimerCounter++;
			V_MineSweeperGame.AtualizaTempo(GetTimeString());
		}
	}
}