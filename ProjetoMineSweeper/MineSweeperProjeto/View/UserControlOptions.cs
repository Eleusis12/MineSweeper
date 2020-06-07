using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Helpers;
using Library.Interfaces;

namespace MineSweeperProjeto.View
{
	public partial class UserControlOptions : UserControl
	{
		public event NotificationTaskHandler WarnMainFormSoundEffectsChoice;

		public UserControlOptions()
		{
			InitializeComponent();
		}

		private void BTSoundEffects_Click(object sender, EventArgs e)
		{
			if (WarnMainFormSoundEffectsChoice != null)
			{
				WarnMainFormSoundEffectsChoice();
			}
			if (BTSoundEffects.Text == "Efeitos Sonoros: Desligado")
			{
				BTSoundEffects.Text = "Efeitos Sonoros: Ligado";
			}
			else
			{
				BTSoundEffects.Text = "Efeitos Sonoros: Desligado";
			}
		}
	}
}