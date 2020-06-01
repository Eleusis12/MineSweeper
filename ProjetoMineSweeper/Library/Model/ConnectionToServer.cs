using Library.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Library.Model
{
	public class ConnectionToServer
	{
		public bool Logado { get; set; } = false;

		public string ID { get; set; }

		public List<Top10Resultado> top10Resultados { get; set; }

		public bool PlayingWithTheOnlineBoard { get; set; } = false;
	}
}