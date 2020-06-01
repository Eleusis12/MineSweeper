using Library;
using Library.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
	public class TileGrid
	{
		// Lado * Altura = tamanho da matriz de elementos
		public Size Tamanho { get; set; }

		// Número Total de minas na lista
		public int NumMinasTotal { get; set; }

		public int NumeroElementosAbertos { get; set; } = 0;

		// Indica se todos os espaços sem minas já foram explorados
		public bool Fim { get; set; } = false;

		// Coleção Dictionary que vai permitir guardar todos os "tiles" num único lugar
		// Foi escolhido Dictionary porque permite guardar apenas um tile único tendo em conta o valor da chave : Fácil de controlar erros
		// Coleção genérica: melhor que hastable
		public Dictionary<Point, Tile> Matriz { get; set; }

		public HashSet<Tile> Abertos { get; set; }

		// Numero de flags selecionadas, para depois apresentar no ecrã (Lembrar: flag é quando se carrega no rato direito sobre a tile)
		public int NumFlags { get; set; }

		public Random NumeroAleatorio { get; set; }

		public Dificuldade dificuldade { get; set; }

		public int timerCounter { get; set; } = 0;

		public bool SoundOnOrOFF { get; set; } = true;

		public List<Point> indexMinas { get; set; }
	}
}