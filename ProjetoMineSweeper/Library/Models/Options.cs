using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
	[Serializable]
	public enum GameMode { Normal = 0, Inverso = 1 }

	public class Options
	{
		public bool SoundOnOrOFF { get; set; } = true;
		public GameMode ModoJogo { get; set; } = GameMode.Normal;
	}
}