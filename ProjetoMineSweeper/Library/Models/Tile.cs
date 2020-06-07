using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
	public class Tile
	{
		// Nome do "tile"
		public string Name { get; set; } = string.Empty;

		// Ponto de coordenadas do "tile"
		public Point Ponto { get; set; }

		// Variável pode adquirir os seguintes valores:
		// True: O quadrado foi assinalado pelo utilizador. (Com o rato direito - em principio)
		// False: O quadrado encontra-se no seu estado normal, o utilizador ainda não teve interação com este.

		public bool Flagged { get; set; }

		// Indica se estamos perante um tile vazio
		public bool Vazio { get; set; } = false;

		// Números de minas que se encontram à volta do "tile"
		private int numeroMinas;

		public int NumeroMinas
		{
			get { return numeroMinas; }
			set
			{
				if (value >= 0 && value <= 8)
					numeroMinas = value;
				else
				{
					throw new ArgumentOutOfRangeException("Número inválido de minas adjacentes");
				}
			}
		}

		// Indica se o "tile" possui Mina, True: Possui, False: Não Possui
		public bool TemMina { get; set; } = false;

		// Indica se o "tile" já foi aberto"
		public bool Aberto { get; set; } = false;

		// Coordenadas adjacentes vão ser obtidas a partir de cada soma a um desses pontos a cada iteração

		public Tile(Point _ponto)
		{
			// Verifica se o ponto recebido está vazio
			//if (_ponto != Point.)
			//{
			this.Ponto = _ponto;
			this.Name = string.Format($"{_ponto.X}-{_ponto.Y}");
			//}
			// Lança uma excepção caso o ponto estão vazio
			//else
			//{
			//	throw new ArgumentNullException("Ponto do tile encontra-se vazio");
			//}
		}

		public Tile(string _nome, Point _ponto)
		{
			// Verifica se o conteúdo recebido por paramatros são nulos ou vazios
			if (string.IsNullOrEmpty(_nome) /*&& _ponto != Point.Empty*/)
			{
				this.Name = _nome;
				this.Ponto = _ponto;
			}
			// Lança uma excepção caso o nome e o ponto estão vazios
			else
			{
				throw new ArgumentNullException("Nome e Ponto do tile encontram-se vazios");
			}
		}
	}
}