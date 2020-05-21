using MineSweeperProjeto.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperProjeto.Model
{
	internal static class Sound
	{
		private static SoundPlayer player;

		// This method will be called when the thread is started.
		public static void PlayGameOver()
		{
			player = new SoundPlayer(Resources.GameOver);
			player.PlaySync();
		}

		public static void PlayOpenTile()
		{
			player = new SoundPlayer(Resources.click);
			player.PlaySync();
		}

		public static void PlayPutFlag()
		{
			player = new SoundPlayer(Resources.flag);
			player.PlaySync();
		}

		public static void PlayWinning()
		{
			player = new SoundPlayer(Resources.GameWin);
			player.PlaySync();
		}
	}
}