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
		// Switch do botão de áudio
		public void V_StartForm_TurnSoundEffectsInGame()
		{
			// Faz um flip ao valor do boolean
			M_Options.SoundOnOrOFF = !M_Options.SoundOnOrOFF;
		}
	}
}