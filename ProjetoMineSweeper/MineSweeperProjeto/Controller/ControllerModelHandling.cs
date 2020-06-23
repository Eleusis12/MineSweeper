using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static MineSweeperProjeto.Program;
using System.Threading.Tasks;
using Library.Helpers;
using Library.Models;
using System.Diagnostics;
using Library.ServerEndpoint;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		/// <summary>
		/// Inicia as coleções do Model para permitir o bom funcionamento do Jogo
		/// </summary>
		public void InitModel()
		{
			M_Grelha.NumeroAleatorio = new Random();
			M_Grelha.Matriz = new Dictionary<Point, Tile>();
			M_Grelha.Abertos = new HashSet<Tile>();
		}

		/// <summary>
		/// Prepara o jogo funcionalmente consoante com a dificuldade escolhida
		/// </summary>
		public void SetupModel()
		{
			M_Grelha.Tamanho = classDificuldade.GetTamanho(Program.M_Grelha._Dificuldade);
			SetAmountOfMinesInPlay();
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

		/// <summary>
		/// Verifica se o ponto faz sentido no contexto da matriz
		/// </summary>
		/// <param name="_pontoTemporario">Ponto que se pretende avaliar</param>
		/// <returns></returns>
		public bool PointIsValid(ref Point _pontoTemporario)
		{
			return (_pontoTemporario.X >= 0 && _pontoTemporario.X < M_Grelha.Tamanho.Height && _pontoTemporario.Y >= 0
									&& _pontoTemporario.Y < M_Grelha.Tamanho.Width);
		}

		/// <summary>
		/// Carrega a Matriz com todas Tiles (quadrículas) de acordo com o seu posicionamento (x,y)
		/// </summary>
		public void LoadTileGrid()
		{
			// Gerar Minas
			if (M_Status.PlayingWithTheOnlineBoard == true)
			{
				Program.M_Grelha.IndexMinas = Server.NovoJogo(Program.M_Grelha._Dificuldade.ToString(), Program.M_Status.ID);
			}
			else
			{
				M_Grelha.IndexMinas = new List<Point>();
				Point minaPonto;
				for (int i = 0; i < M_Grelha.NumMinasTotal; i++)
				{
					do
					{
						minaPonto = new Point(M_Grelha.NumeroAleatorio.Next(M_Grelha.Tamanho.Height), M_Grelha.NumeroAleatorio.Next(M_Grelha.Tamanho.Width));
					} while (Program.M_Grelha.IndexMinas.Contains(minaPonto) == true);
					Program.M_Grelha.IndexMinas.Add(minaPonto);
				}
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
					if (Program.M_Grelha.IndexMinas.Contains(new Point(i, j)))
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

		/// <summary>
		/// Determina o número de Minas a colocar em campo
		/// </summary>
		public void SetAmountOfMinesInPlay()
		{
			switch (Program.M_Grelha._Dificuldade)
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

		/// <summary>
		/// Função que pretende apagar todos os dados relativo ao jogo anterior (usa-se quando se pretende mudar de dificuldade por exemplo)
		/// </summary>
		private void V_StartForm_DestroyModel()
		{
			ResetTileGridProperties();
		}

		/// <summary>
		/// Faz reset funcional ao jogo
		/// </summary>
		public void ResetModel()
		{
			ResetTileGridProperties();

			SetupModel();

			V_MineSweeperGame.ResetBoardView();
		}

		/// <summary>
		/// Apaga dados presentes do Model
		/// </summary>
		public void ResetTileGridProperties()
		{
			M_Grelha.Matriz = new Dictionary<Point, Tile>();
			M_Grelha.Abertos = new HashSet<Tile>();
			M_Grelha.NumeroElementosAbertos = 0;
			M_Grelha.Fim = false;
			M_Grelha.NumFlagsPosicionadosEmMinas = 0;
			M_Grelha.NumFlags = 0;
			M_Grelha.TimerCounter = 0;
		}
	}
}