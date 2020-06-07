using Library.Helpers;
using Library.Model;
using Library.ServerEndpoint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperUWP.Controller
{
	public partial class GameController
	{
		// Efetua Prepara o Model para permitir o Jogo
		public void SetupModel()
		{
			Program.M_Grelha.NumeroAleatorio = new Random();
			Program.M_Grelha.Matriz = new Dictionary<Point, Tile>();
			Program.M_Grelha.Abertos = new HashSet<Tile>();

			SetModel(Program.M_Grelha.dificuldade);
		}

		public void SetModel(Dificuldade dificuldade)
		{
			Program.M_Grelha.Tamanho = classDificuldade.GetTamanho(dificuldade);
			SetAmountOfMines();
			LoadTileGrid();
			LoadAdjacentsMines();
		}

		public void LoadAdjacentsMines()
		{
			Point _pontoTemporario;
			Tile tempTile;

			foreach (KeyValuePair<Point, Tile> espaco in Program.M_Grelha.Matriz)
			{
				// Se o espaco em questñao possuir uma mina, a contagem de minas nñao é necessária
				if (espaco.Value.TemMina == true)
					continue;

				foreach (Point coordenada in adjacentCoords)
				{
					_pontoTemporario = new Point(espaco.Value.Ponto.X + coordenada.X, espaco.Value.Ponto.Y + coordenada.Y);
					// Se estivermos perante um ponto válido
					if (PointIsValid(ref _pontoTemporario))
					{
						if (Program.M_Grelha.Matriz.TryGetValue(_pontoTemporario, out tempTile) == true)
						{
							if (tempTile.TemMina == true)
							{
								espaco.Value.NumeroMinas++;
							}
						}
					}
				}

				if (espaco.Value.NumeroMinas == 0)
					espaco.Value.Vazio = true;
				else
				{
					espaco.Value.Vazio = false;
				}
			}
		}

		public bool PointIsValid(ref Point _pontoTemporario)
		{
			return (_pontoTemporario.X >= 0 && _pontoTemporario.X < Program.M_Grelha.Tamanho.Height && _pontoTemporario.Y >= 0
									&& _pontoTemporario.Y < Program.M_Grelha.Tamanho.Width);
		}

		public void LoadTileGrid()
		{
			// Gerar Minas
			if (Program.M_Status.PlayingWithTheOnlineBoard == true)
			{
				Program.M_Grelha.indexMinas = Server.NovoJogo(Program.M_Grelha.dificuldade.ToString(), Program.M_Status.ID);
			}
			else
			{
				Program.M_Grelha.indexMinas = new List<Point>();
				Point minaPonto;
				for (int i = 0; i < Program.M_Grelha.NumMinasTotal; i++)
				{
					do
					{
						minaPonto = new Point(Program.M_Grelha.NumeroAleatorio.Next(Program.M_Grelha.Tamanho.Height), Program.M_Grelha.NumeroAleatorio.Next(Program.M_Grelha.Tamanho.Width));
					} while (Program.M_Grelha.indexMinas.Contains(minaPonto) == true);
					Program.M_Grelha.indexMinas.Add(minaPonto);
				}
			}
			int index = 0;
			for (int i = 0; i < Program.M_Grelha.Tamanho.Height; i++)
			{
				for (int j = 0; j < Program.M_Grelha.Tamanho.Width; j++)
				{
					//Debug.Write(i);
					//Debug.WriteLine(j);
					Point location = new Point(i, j);

					// Se a mina foi gerada para este lugar
					if (Program.M_Grelha.indexMinas.Contains(new Point(i, j)))
					{
						// Adiciona um elemento com mina
						Tile elemento = new Tile(location);
						elemento.TemMina = true;
						Program.M_Grelha.Matriz.Add(location, elemento);
					}
					else
					{
						// Adiciona um elemento sem mina
						Tile elemento = new Tile(location);
						elemento.TemMina = false;
						Program.M_Grelha.Matriz.Add(location, elemento);
					}
					index++;
				}
			}
			//Debug.WriteLine(Matriz.Count);
			//foreach (var item in Matriz)

			//{
			//	Debug.WriteLine(item.Value.Ponto.ToString() + " " + item.Value.temMina.ToString());
			//}
		}

		public void SetAmountOfMines()
		{
			switch (dificuldade)
			{
				case Dificuldade.Facil:

					Program.M_Grelha.NumMinasTotal = 10;
					break;

				case Dificuldade.Medio:

					Program.M_Grelha.NumMinasTotal = 40;
					break;

				case Dificuldade.Dificil:
					Program.M_Grelha.NumMinasTotal = 99;
					break;

				default:
					throw new InvalidOperationException("Dificuldade não implementada");
			}
		}

		public void ResetModel()
		{
			Program.M_Grelha.Matriz = new Dictionary<Point, Tile>();
			Program.M_Grelha.Abertos = new HashSet<Tile>();
			Program.M_Grelha.NumeroElementosAbertos = 0;
			Program.M_Grelha.Fim = false;

			SetModel(dificuldade);

			Program.V_MineSweeperGame.ResetBoardView();
			Program.V_MineSweeperGame.ResetTimer();
		}
	}
}