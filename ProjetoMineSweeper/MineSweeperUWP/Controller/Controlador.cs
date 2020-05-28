using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Library;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;
using Windows.UI.Xaml.Input;
using Library.Helpers;
using Library.Model;

namespace MineSweeperUWP.Controller
{
	public class GameController
	{
		public static Timer Temporizador { get; private set; }

		public Dificuldade dificuldade { get; set; }

		public readonly Point[] adjacentCoords =
				{
			new Point (-1, -1),
			new Point (0, -1),
			new Point (1, -1),
			new Point (1, 0),
			new Point (1, 1),
			new Point (0, 1),
			new Point (-1,1),
			new Point (-1, 0)
		};

		private App Program;

		public GameController()
		{
			//Obtenção do apontador para a classe App
			Program = App.Current as App;

			Program.V_MineSweeperGame.LeftButtonPressed += V_MineSweeperGame_LeftButtonPressed;
			Program.V_MineSweeperGame.RightButtonPressed += V_MineSweeperGame_RightButtonPressed;

			Program.V_MineSweeperGame.AskToRevealAllPieces += Reveal;
			Program.V_MineSweeperGame.AskToResetBoard += V_MineSweeperGame_AskToResetBoard;
			//Program.V_StartForm.ChangeDifficultyInGame += V_GameMode_ChangeDifficulty;
			//Program.V_StartForm.TurnSoundEffectsInGame += V_StartForm_TurnSoundEffectsInGame;

			//Temporizador = new Timer(timerCallback, null, (int)TimeSpan.FromMinutes(1).TotalMilliseconds, Timeout.Infinite);
			//V_JOGO.ResetTileGrid += Reset;
			SetupModel();
			SetupTimer();
			AlteraDificuldade(Dificuldade.Facil);
		}

		//private async void timerCallback(object state)
		//{
		//	// do some work not connected with UI

		//	await Window.Current.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
		//		() =>
		//		{
		//			// do some work on UI here;
		//		});
		//}

		private void V_MineSweeperGame_LeftButtonPressed(object sender, RoutedEventArgs e)
		{
			//Temporizador.Start();
			//// Obter Botão premido e guardar
			var botaoAtual = (sender as Button);

			// Obtém as Coordenadas do Tile
			GetCoordinates(botaoAtual, out int x, out int y);

			Tile currentTile = GetTile(new System.Drawing.Point(x, y));

			if (currentTile.TemMina == true)
			{
				//	Jogo perdido
				//Temporizador.Stop();

				Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/bomb.jpg");
				Reveal();
				BombaFimJogo();

				// O jogo acaba
				//Program.V_MineSweeperGame_AskToResetBoard();
			}
			else if (currentTile.Vazio == false && currentTile.Aberto == false)
			{
				// TODO: Arranjar maneira de por isto mais bonito
				SwitchBackground(botaoAtual, currentTile);

				currentTile.Aberto = true;
				if (Program.M_Grelha.SoundOnOrOFF == true)
				{
					////Thread soundThread = new Thread(Sound.PlayOpenTile)
					//{
					//	IsBackground = true
					////};
					//soundThread.Start();
				}

				// Se a condição for verdadeira a condição acaba
				if (TestarFim(currentTile) == true)
				{
					GanhouJogo();
				}
				//soundThread.Abort();
			}
			// O jogo tem que abrir todos os vazios adjacentes.
			// Primeira Questão: Como pedir os botões adjacentes ao view?
			else if (currentTile.Vazio == true && currentTile.Aberto == false)
			{
				Flood_Fill(currentTile, Program.V_MineSweeperGame.GetButton(currentTile.Ponto));
			}
		}

		private void V_MineSweeperGame_RightButtonPressed(object sender, RightTappedRoutedEventArgs e)
		{
			Button botaoAtual = (sender as Button);
			GetCoordinates(botaoAtual, out int x, out int y);

			// Obtém as Coordenadas do Tile
			Tile currentTile = GetTile(new System.Drawing.Point(x, y));

			if (currentTile.Aberto != true)
			{
				if (Program.M_Grelha.SoundOnOrOFF == true)
				{
					//Thread soundThread = new Thread(Sound.PlayPutFlag)
					//{
					//	IsBackground = true
					//};
					//soundThread.Start();
				}

				if (currentTile.Flagged == true)
				{
					Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/unopened.jpg");
					currentTile.Flagged = false;
					Program.M_Grelha.NumFlags--;
					Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal - Program.M_Grelha.NumFlags);
				}
				else if (currentTile.Flagged == false)
				{
					Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/flag1.jpg");
					currentTile.Flagged = true;
					Program.M_Grelha.NumFlags++;
					Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal - Program.M_Grelha.NumFlags);
				}
				//soundThread.Abort();
			}
			else
			{
				return;
			}
		}

		public void SetupModel()
		{
			Program.M_Grelha.NumeroAleatorio = new Random();
			Program.M_Grelha.Matriz = new Dictionary<Point, Tile>();
			Program.M_Grelha.Abertos = new HashSet<Tile>();
		}

		public void AlteraDificuldade(Dificuldade _dificuldade)
		{
			this.dificuldade = _dificuldade;
			SetModel(dificuldade);
			//Program.V_MineSweeperGame.AlteraDificuldadeNoView(this.dificuldade);
		}

		public void V_MineSweeperGame_AskToResetBoard()
		{
			ResetModel();
			//Temporizador.Stop();
			Temporizador.Dispose();
			//Temporizador = new Timer();
			SetupTimer();
			Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal);
			//SetupTimer();
		}

		public void ResetModel()
		{
			Program.M_Grelha.Matriz = new Dictionary<Point, Tile>();
			Program.M_Grelha.Abertos = new HashSet<Tile>();
			Program.M_Grelha.NumeroElementosAbertos = 0;
			Program.M_Grelha.Fim = false;

			SetModel(dificuldade);

			Program.V_MineSweeperGame.ResetBoardView();
		}

		public void SetModel(Dificuldade dificuldade)
		{
			Program.M_Grelha.Tamanho = GetTamanho(dificuldade);
			SetAmountOfMines();
			LoadTileGrid();
			LoadAdjacentsMines();
		}

		private void LoadAdjacentsMines()
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

		public Tile GetTile(Point _point)
		{
			Tile temp;
			Program.M_Grelha.Matriz.TryGetValue(_point, out temp);
			return temp;
		}

		private void LoadTileGrid()
		{
			// Gerar Minas
			List<Point> indexMinas = new List<Point>();
			Point minaPonto;
			for (int i = 0; i < Program.M_Grelha.NumMinasTotal; i++)
			{
				do
				{
					minaPonto = new Point(Program.M_Grelha.NumeroAleatorio.Next(Program.M_Grelha.Tamanho.Height), Program.M_Grelha.NumeroAleatorio.Next(Program.M_Grelha.Tamanho.Width));
				} while (indexMinas.Contains(minaPonto) == true);
				indexMinas.Add(minaPonto);
			}
			int index = 0;
			for (int i = 0; i < Program.M_Grelha.Tamanho.Height; i++)
			{
				for (int j = 0; j < Program.M_Grelha.Tamanho.Width; j++)
				{
					Point location = new Point(i, j);

					// Se a mina foi gerada para este lugar
					if (indexMinas.Contains(new Point(i, j)))
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

		private void SetAmountOfMines()
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

		public Size GetTamanho(Dificuldade _dificuldade)
		{
			Size _tamanho = new Size();
			switch (_dificuldade)
			{
				// TODO: Valores a confirmar com o protocolo
				case Dificuldade.Facil:
					_tamanho.Width = _tamanho.Height = 9;
					break;

				case Dificuldade.Medio:
					_tamanho.Width = _tamanho.Height = 16;
					break;

				case Dificuldade.Dificil:
					_tamanho.Width = 30;
					_tamanho.Height = 16;

					break;

				default:
					throw new InvalidOperationException("Dificuldade não implementada");
			}
			return _tamanho;
		}

		/// <summary>
		/// Função simples que retorna um bool que indica se o jogador já explorou todos elementos sem minas
		/// </summary>
		/// <returns></returns>
		public bool TestarFim(Tile currentTile)
		{
			// É suposto receber um tile que foi recentemente aberto
			if (currentTile.Aberto == false)
				throw new ArgumentException();

			// Incrementamos um a NumeroElementosAbertos uma vez que foi aberto um tile

			if (Program.M_Grelha.Abertos.Contains(currentTile) == false)
			{
				Program.M_Grelha.NumeroElementosAbertos++;
			}
			else
			{
				return false;
			}
			Program.M_Grelha.Abertos.Add(currentTile);

			foreach (var item in Program.M_Grelha.Matriz)
			{
				Debug.WriteLine("Ponto:" + item.Value.Ponto + ":" + item.Value.Aberto);
			}
			Debug.WriteLine("Numero de elementos abertos: " + Program.M_Grelha.NumeroElementosAbertos);
			Debug.WriteLine((Program.M_Grelha.Matriz.Count - Program.M_Grelha.NumMinasTotal));
			if (Program.M_Grelha.NumeroElementosAbertos < (Program.M_Grelha.Matriz.Count - Program.M_Grelha.NumMinasTotal))
			{
				Program.M_Grelha.Fim = false;
				return false;
			}
			else if (Program.M_Grelha.NumeroElementosAbertos == (Program.M_Grelha.Matriz.Count - Program.M_Grelha.NumMinasTotal))
			{
				Program.M_Grelha.Fim = true;
				return true;
			}
			else
			{
				throw new ArgumentOutOfRangeException("numero Elementos Abertos > numero Elementos na Matriz");
			}
		}

		public void V_StartForm_TurnSoundEffectsInGame()
		{
			// Faz um flip ao valor do boolean
			Program.M_Grelha.SoundOnOrOFF = !Program.M_Grelha.SoundOnOrOFF;
		}

		public void V_GameMode_ChangeDifficulty(Dificuldade dificuldade)
		{
			AlteraDificuldade(dificuldade);
			Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal);
		}

		public void SetupTimer()
		{
			Program.V_MineSweeperGame.AtualizaTempo("00:00");
			// Temporizador
			//Temporizador.Interval = 1000; //1 sec
			//Temporizador.Tick += TimerTick;
			Program.M_Grelha.timerCounter = 0;
		}

		//public void Reset(object sender, MouseEventArgs e)
		//{
		//	foreach (Button Botao in V_JOGO.GetButtons())
		//	{
		//		Program.V_MineSweeperGame.ChangeButtonBackGround(Botao, Resources.tile_0);
		//	}
		//	M_tileGrid = new TileGrid(dificuldade);
		//	timer = new Timer();
		//	V_JOGO.AtualizaNumeroMinasDisponiveis(M_tileGrid.NumMinasTotal);
		//	// TODO: BUG: A VELOCIDADE DO TEMPO DUPLICA???
		//	SetupTimer();
		//}

		// Revela o mapa completo
		public void Reveal()
		{
			foreach (Button Botao in Program.V_MineSweeperGame.GetButtons())
			{
				GetCoordinates(Botao, out int x, out int y);
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Vazio == false && currentTile.TemMina == false)
				{
					// TODO: Arranjar maneira de por isto mais bonito
					SwitchBackground(Botao, currentTile);
				}
				else if (currentTile.TemMina == true)
				{
					Program.V_MineSweeperGame.ChangeButtonBackGround(Botao, "Assets/tiles/bomb.jpg");
				}
				else if (currentTile.Vazio == true)
				{
					Program.V_MineSweeperGame.ChangeButtonBackGround(Botao, "Assets/tiles/tile_0.jpg");
				}
			}
		}

		public void OnButtonClicked(Button botaoAtual, Tile currentTile)
		{
			SwitchBackground(botaoAtual, currentTile);
			currentTile.Aberto = true;
			// Se a condição for verdadeira a condição acaba
			if (TestarFim(currentTile) == true)
			{
				GanhouJogo();
			}
		}

		public void SwitchBackground(Button botaoAtual, Tile currentTile)
		{
			switch (currentTile.NumeroMinas)

			{
				case 1: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_1.jpg"); break;
				case 2: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_2.jpg"); break;
				case 3: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_3.jpg"); break;
				case 4: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_4.jpg"); break;
				case 5: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_5.jpg"); break;
				case 6: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_6.jpg"); break;
				case 7: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_7.jpg"); break;
				case 8: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_8.jpg"); break;
				default:
					throw new ArgumentException("O número de minas adjacentes não pode ser superior a 8 nem inferior a 1");
			}
		}

		public void Flood_Fill(Tile currentTile, Button botaoAtual)
		{
			if (currentTile != null || botaoAtual != null)
			{
				if (currentTile.Aberto == true)
				{
					return;
				}
				else if (currentTile.Vazio == false)
				{
					OnButtonClicked(botaoAtual, currentTile);

					return;
				}
				else if (currentTile.Vazio == true && currentTile.Aberto == false)
				{
					currentTile.Aberto = true;
					// Se a condição for verdadeira o jogo acaba
					if (TestarFim(currentTile) == true)
					{
						GanhouJogo();
					}

					Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_0.jpg");

					// Norte
					Point ponto = new Point(currentTile.Ponto.X, currentTile.Ponto.Y + 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));
					// Sul
					ponto = new Point(currentTile.Ponto.X, currentTile.Ponto.Y - 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));
					// Este
					ponto = new Point(currentTile.Ponto.X + 1, currentTile.Ponto.Y);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));

					// Oeste
					ponto = new Point(currentTile.Ponto.X - 1, currentTile.Ponto.Y);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));

					// Nordeste
					ponto = new Point(currentTile.Ponto.X + 1, currentTile.Ponto.Y + 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));

					// Noroeste
					ponto = new Point(currentTile.Ponto.X - 1, currentTile.Ponto.Y + 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));

					// Sudoeste
					ponto = new Point(currentTile.Ponto.X - 1, currentTile.Ponto.Y - 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));

					// Sudeste
					ponto = new Point(currentTile.Ponto.X + 1, currentTile.Ponto.Y - 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), Program.V_MineSweeperGame.GetButton(ponto));
				}
				else
				{
					return;
				}
			}
			else
			{
				return;
			}
		}

		public void GanhouJogo()
		{
			//Temporizador.Stop();
			//if (Program.M_Grelha.SoundOnOrOFF == true)
			//{
			//	//Thread soundThread = new Thread(Sound.PlayWinning);
			//	soundThread.IsBackground = true;
			//	soundThread.Start();
			//}

			//// Abre uma messabox que informa o utilizador que ganhou o jogo
			//MessageBox.Show("Muito bem: " + GetTimeString(), "Ganhou!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			////soundThread.Abort();

			//Program.V_Vencedor = new FormVencedor();
			//if (_vencedor.ShowDialog() == DialogResult.OK)
			//	// O jogo acaba
			//	Program.V_MineSweeperGame.Close();
		}

		/// <summary>
		/// Função apresenta uma messagem de erro em como clicou numa mina a perdeu
		/// </summary>
		public void BombaFimJogo()
		{
			if (Program.M_Grelha.SoundOnOrOFF == true)
			{
				//Thread soundThread = new Thread(Sound.PlayGameOver)
				//{
				//	IsBackground = true
				//};
				//soundThread.Start();
			}//// Criar uma thread que funcione em background para emitir um som, neste caso o som de uma mina a explodir

			// Abre uma messabox que informa o utilizador que perdeu o jogo
			//MessageBox.Show("BOOOM!", "Perdeu o jogo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//soundThread.Abort();
		}

		// O nome do botão é do género {x}-{y}, a partir desse facto vamos extrair os números para variáveis int
		public static void GetCoordinates(Button botaoAtual, out int x, out int y)
		{
			var parts = botaoAtual.Name.Split('-');
			x = Convert.ToInt32(parts[0]);
			y = Convert.ToInt32(parts[1]);
		}

		public string GetTimeString()
		{
			//create time span from our counter
			TimeSpan time = TimeSpan.FromSeconds(Program.M_Grelha.timerCounter);

			//format that into a string
			string timeString = time.ToString(@"mm\:ss");

			//return it
			return timeString;
		}

		public void TimerTick(object sender, EventArgs e)
		{
			Program.M_Grelha.timerCounter++;
			Program.V_MineSweeperGame.AtualizaTempo(GetTimeString());
		}
	}
}