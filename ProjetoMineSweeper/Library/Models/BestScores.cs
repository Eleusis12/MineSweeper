using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
	public class Entry
	{
		private string username;
		private string nivel;
		private string tempo;

		public string Username { get => username; set => username = value; }
		public string Nivel { get => nivel; set => nivel = value; }
		public string Tempo { get => tempo; set => tempo = value; }
	}

	public class BestScores
	{
		public Entry EasyBestScore { get; set; }
		public Entry MediumBestScore { get; set; }
		public Entry HardBestScore { get; set; }
	}
}