using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperUWP.Controller
{
	public class ControllerOptions
	{
		public App Program { get; }

		public ControllerOptions()
		{
			Program = App.Current as App;

			Program.V_OptionsForm.WarnMainFormSoundEffectsChoice += V_OptionsForm_WarnMainFormSoundEffectsChoice;
		}

		private void V_OptionsForm_WarnMainFormSoundEffectsChoice()
		{
			Program.M_Options.SoundOnOrOFF = !Program.M_Options.SoundOnOrOFF;
		}
	}
}