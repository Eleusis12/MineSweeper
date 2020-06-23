using Library.Helpers;
using Library.Models;
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
		/// <summary>
		/// Inicia as coleções do Model para permitir o bom funcionamento do Jogo
		/// </summary>
		public void InitModel()
		{
			Program.M_Grelha.NumeroAleatorio = new Random();
			Program.M_Grelha.Matriz = new Dictionary<Point, Tile>();
			Program.M_Grelha.Abertos = new HashSet<Tile>();

			SetupModel(Program.M_Grelha._Dificuldade);
		}

		/// <summary>
		/// Prepara o jogo funcionalmente consoante com a dificuldade escolhida
		/// </summary>
		public void SetupModel(Dificuldade dificuldade)
		{
			Program.M_Grelha.Tamanho = classDificuldade.GetTamanho(dificuldade);
			SetAmountOfMines();
			LoadTileGrid();
			LoadAdjacentsMines();
		}

		/// <summary>
		/// Atribui o número de minas adjacentes a cada quadrícula
		/// </summary>
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

		/// <summary>
		/// Verifica se o ponto faz sentido no contexto da matriz
		/// </summary>
		/// <param name="_pontoTemporario">Ponto que se pretende avaliar</param>
		/// <returns></returns>
		public bool PointIsValid(ref Point _pontoTemporario)
		{
			return (_pontoTemporario.X >= 0 && _pontoTemporario.X < Program.M_Grelha.Tamanho.Height && _pontoTemporario.Y >= 0
									&& _pontoTemporario.Y < Program.M_Grelha.Tamanho.Width);
		}

		/// <summary>
		/// Carrega a Matriz com todas Tiles (quadrículas) de acordo com o seu posicionamento (x,y)
		/// </summary>
		public void LoadTileGrid()
		{
			// Gerar Minas
			if (Program.M_Status.PlayingWithTheOnlineBoard == true)
			{
				Program.M_Grelha.IndexMinas = Server.NovoJogo(Program.M_Grelha._Dificuldade.ToString(), Program.M_Status.ID);
			}
			else
			{
				Program.M_Grelha.IndexMinas = new List<Point>();
				Point minaPonto;
				for (int i = 0; i < Program.M_Grelha.NumMinasTotal; i++)
				{
					do
					{
						minaPonto = new Point(Program.M_Grelha.NumeroAleatorio.Next(Program.M_Grelha.Tamanho.Height), Program.M_Grelha.NumeroAleatorio.Next(Program.M_Grelha.Tamanho.Width));
					} while (Program.M_Grelha.IndexMinas.Contains(minaPonto) == true);
					Program.M_Grelha.IndexMinas.Add(minaPonto);
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
					if (Program.M_Grelha.IndexMinas.Contains(new Point(i, j)))
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

		/// <summary>
		/// Determina o número de Minas a colocar em campo
		/// </summary>
		public void SetAmountOfMines()
		{
			switch (Program.M_Grelha._Dificuldade)
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

		//public void ResetModel()
		//{
		//	Program.M_Grelha.Matriz = new Dictionary<Point, Tile>();
		//	Program.M_Grelha.Abertos = new HashSet<Tile>();
		//	Program.M_Grelha.NumeroElementosAbertos = 0;
		//	Program.M_Grelha.Fim = false;
		//	Program.M_Grelha.NumFlagsPosicionadosEmMinas = 0;
		//	Program.M_Grelha.NumFlags = 0;

		//	SetModel(dificuldade);

		//	Program.V_MineSweeperGame.ResetBoardView();
		//	Program.V_MineSweeperGame.ResetTimer();
		//}

		/// <summary>
		/// Faz reset funcional ao jogo
		/// </summary>
		public void ResetModel()
		{
			ResetTileGridProperties();

			SetupModel(Program.M_Grelha._Dificuldade);

			Program.V_MineSweeperGame.ResetBoardView();
		}

		/// <summary>
		/// Apaga dados presentes do Model
		/// </summary>
		public void ResetTileGridProperties()
		{
			Program.M_Grelha.Matriz = new Dictionary<Point, Tile>();
			Program.M_Grelha.Abertos = new HashSet<Tile>();
			Program.M_Grelha.NumeroElementosAbertos = 0;
			Program.M_Grelha.Fim = false;
			Program.M_Grelha.NumFlagsPosicionadosEmMinas = 0;
			Program.M_Grelha.NumFlags = 0;
			Program.M_Grelha.TimerCounter = 0;
		}
	}
}