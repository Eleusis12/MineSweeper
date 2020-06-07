using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperUWP.Controller
{
	public partial class GameController
	{
		private void V_OptionsForm_WarnMainFormSoundEffectsChoice()
		{
			Program.M_Options.SoundOnOrOFF = !Program.M_Options.SoundOnOrOFF;
		}
	}
}