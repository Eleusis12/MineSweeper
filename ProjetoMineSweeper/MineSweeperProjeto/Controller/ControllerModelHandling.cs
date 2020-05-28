using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static MineSweeperProjeto.Program;
using System.Threading.Tasks;
using Library.Helpers;
using Library.Model;
using System.Diagnostics;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		// Efetua Prepara o Model para permitir o Jogo
		public void SetupModel()
		{
			M_Grelha.NumeroAleatorio = new Random();
			M_Grelha.Matriz = new Dictionary<Point, Tile>();
			M_Grelha.Abertos = new HashSet<Tile>();
		}

		public void AlteraDificuldade(Dificuldade _dificuldade)
		{
			this.dificuldade = _dificuldade;
			SetModel(dificuldade);
			V_MineSweeperGame.AlteraDificuldadeNoView(this.dificuldade);
		}

		public void SetModel(Dificuldade dificuldade)
		{
			M_Grelha.Tamanho = classDificuldade.GetTamanho(dificuldade);
			SetAmountOfMines();
			LoadTileGrid();
			LoadAdjacentsMines();
		}

		public void LoadAdjacentsMines()
		{
			Point _pontoTemporario;
			Tile tempTile;

			foreach (KeyValuePair<Point, Tile> espaco in M_Grelha.Matriz)
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
						if (M_Grelha.Matriz.TryGetValue(_pontoTemporario, out tempTile) == true)
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
			return (_pontoTemporario.X >= 0 && _pontoTemporario.X < M_Grelha.Tamanho.Height && _pontoTemporario.Y >= 0
									&& _pontoTemporario.Y < M_Grelha.Tamanho.Width);
		}

		public void LoadTileGrid()
		{
			// Gerar Minas
			List<Point> indexMinas = new List<Point>();
			Point minaPonto;
			for (int i = 0; i < M_Grelha.NumMinasTotal; i++)
			{
				do
				{
					minaPonto = new Point(M_Grelha.NumeroAleatorio.Next(M_Grelha.Tamanho.Height), M_Grelha.NumeroAleatorio.Next(M_Grelha.Tamanho.Width));
				} while (indexMinas.Contains(minaPonto) == true);
				indexMinas.Add(minaPonto);
			}
			int index = 0;
			for (int i = 0; i < M_Grelha.Tamanho.Height; i++)
			{
				for (int j = 0; j < M_Grelha.Tamanho.Width; j++)
				{
					//Debug.Write(i);
					//Debug.WriteLine(j);
					Point location = new Point(i, j);

					// Se a mina foi gerada para este lugar
					if (indexMinas.Contains(new Point(i, j)))
					{
						// Adiciona um elemento com mina
						Tile elemento = new Tile(location);
						elemento.TemMina = true;
						M_Grelha.Matriz.Add(location, elemento);
					}
					else
					{
						// Adiciona um elemento sem mina
						Tile elemento = new Tile(location);
						elemento.TemMina = false;
						M_Grelha.Matriz.Add(location, elemento);
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

					M_Grelha.NumMinasTotal = 10;
					break;

				case Dificuldade.Medio:

					M_Grelha.NumMinasTotal = 40;
					break;

				case Dificuldade.Dificil:
					M_Grelha.NumMinasTotal = 99;
					break;

				default:
					throw new InvalidOperationException("Dificuldade não implementada");
			}
		}

		public void ResetModel()
		{
			M_Grelha.Matriz = new Dictionary<Point, Tile>();
			M_Grelha.Abertos = new HashSet<Tile>();
			M_Grelha.NumeroElementosAbertos = 0;
			M_Grelha.Fim = false;

			SetModel(dificuldade);

			V_MineSweeperGame.ResetBoardView();
		}
	}
}