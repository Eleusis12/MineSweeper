using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeperProjeto;
using MineSweeperProjeto.Model;
using MineSweeperProjeto.Properties;
using MineSweeperProjeto.View;
using static MineSweeperProjeto.Program;
using Timer = System.Windows.Forms.Timer;
using Library;

namespace MineSweeperProjeto.Controller
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

		public GameController()
		{
			V_MineSweeperGame.ButtonPressed += OnButtonClicked;

			V_MineSweeperGame.AskToRevealAllPieces += Reveal;
			V_MineSweeperGame.AskToResetBoard += V_MineSweeperGame_AskToResetBoard;
			V_StartForm.ChangeDifficultyInGame += V_GameMode_ChangeDifficulty;
			V_StartForm.TurnSoundEffectsInGame += V_StartForm_TurnSoundEffectsInGame;

			Temporizador = new Timer();
			//V_JOGO.ResetTileGrid += Reset;
			SetupModel();
			SetupTimer();
		}

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

		public void V_MineSweeperGame_AskToResetBoard()
		{
			ResetModel();
			Temporizador.Stop();
			Temporizador.Dispose();
			Temporizador = new Timer();
			SetupTimer();
			V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal);
			//SetupTimer();
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

		public void SetModel(Dificuldade dificuldade)
		{
			M_Grelha.Tamanho = GetTamanho(dificuldade);
			SetAmountOfMines();
			LoadTileGrid();
			LoadAdjacentsMines();
		}

		private void LoadAdjacentsMines()
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

		public Tile GetTile(Point _point)
		{
			Tile temp;
			M_Grelha.Matriz.TryGetValue(_point, out temp);
			return temp;
		}

		private void LoadTileGrid()
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

		private void SetAmountOfMines()
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

			if (M_Grelha.Abertos.Contains(currentTile) == false)
			{
				M_Grelha.NumeroElementosAbertos++;
			}
			else
			{
				return false;
			}
			M_Grelha.Abertos.Add(currentTile);

			foreach (var item in M_Grelha.Matriz)
			{
				Debug.WriteLine("Ponto:" + item.Value.Ponto + ":" + item.Value.Aberto);
			}
			Debug.WriteLine("Numero de elementos abertos: " + M_Grelha.NumeroElementosAbertos);
			Debug.WriteLine((M_Grelha.Matriz.Count - M_Grelha.NumMinasTotal));
			if (M_Grelha.NumeroElementosAbertos < (M_Grelha.Matriz.Count - M_Grelha.NumMinasTotal))
			{
				M_Grelha.Fim = false;
				return false;
			}
			else if (M_Grelha.NumeroElementosAbertos == (M_Grelha.Matriz.Count - M_Grelha.NumMinasTotal))
			{
				M_Grelha.Fim = true;
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
			M_Grelha.SoundOnOrOFF = !M_Grelha.SoundOnOrOFF;
		}

		public void V_GameMode_ChangeDifficulty(Dificuldade dificuldade)
		{
			AlteraDificuldade(dificuldade);
			V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal);
		}

		public void SetupTimer()
		{
			V_MineSweeperGame.AtualizaTempo("00:00");
			// Temporizador
			Temporizador.Interval = 1000; //1 sec
			Temporizador.Tick += TimerTick;
			M_Grelha.timerCounter = 0;
		}

		//public void Reset(object sender, MouseEventArgs e)
		//{
		//	foreach (Button Botao in V_JOGO.GetButtons())
		//	{
		//		V_MineSweeperGame.ChangeButtonBackGround(Botao, Resources.tile_0);
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
			foreach (Button Botao in V_MineSweeperGame.GetButtons())
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
					V_MineSweeperGame.ChangeButtonBackGround(Botao, Resources.bomb);
				}
				else if (currentTile.Vazio == true)
				{
					V_MineSweeperGame.ChangeButtonBackGround(Botao, Resources.tile_0);
				}
			}
		}

		public void OnButtonClicked(object sender, MouseEventArgs e)
		{
			// Botão esquerdo, abre espaço
			if (e.Button == MouseButtons.Left)
			{
				Temporizador.Start();
				//// Obter Botão premido e guardar
				var botaoAtual = (sender as Button);

				// Obtém as Coordenadas do Tile
				GetCoordinates(botaoAtual, out int x, out int y);

				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.TemMina == true)
				{
					//	Jogo perdido
					Temporizador.Stop();

					V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.bomb);
					Reveal();
					BombaFimJogo();

					// O jogo acaba
					V_MineSweeperGame_AskToResetBoard();
				}
				else if (currentTile.Vazio == false && currentTile.Aberto == false)
				{
					// TODO: Arranjar maneira de por isto mais bonito
					SwitchBackground(botaoAtual, currentTile);

					currentTile.Aberto = true;
					if (M_Grelha.SoundOnOrOFF == true)
					{
						Thread soundThread = new Thread(Sound.PlayOpenTile)
						{
							IsBackground = true
						};
						soundThread.Start();
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
					Flood_Fill(currentTile, V_MineSweeperGame.GetButton(currentTile.Ponto));
				}
			}

			// Botão direito, coloca flag
			else if (e.Button == MouseButtons.Right)
			{
				Button botaoAtual = (sender as Button);
				GetCoordinates(botaoAtual, out int x, out int y);

				// Obtém as Coordenadas do Tile
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Aberto != true)
				{
					if (M_Grelha.SoundOnOrOFF == true)
					{
						Thread soundThread = new Thread(Sound.PlayPutFlag)
						{
							IsBackground = true
						};
						soundThread.Start();
					}

					if (currentTile.Flagged == true)
					{
						V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.unopened);
						currentTile.Flagged = false;
						M_Grelha.NumFlags--;
						V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal - M_Grelha.NumFlags);
					}
					else if (currentTile.Flagged == false)
					{
						V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.flag1);
						currentTile.Flagged = true;
						M_Grelha.NumFlags++;
						V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal - M_Grelha.NumFlags);
					}
					//soundThread.Abort();
				}
				else
				{
					return;
				}
			}
		}

		public void OnButtonClicked(Button botaoAtual, Tile currentTile, MouseButtons left)
		{
			SwitchBackground(botaoAtual, currentTile);
			currentTile.Aberto = true;
			// Se a condição for verdadeira a condição acaba
			if (TestarFim(currentTile) == true)
			{
				GanhouJogo();
			}
		}

		public static void SwitchBackground(Button botaoAtual, Tile currentTile)
		{
			switch (currentTile.NumeroMinas)
			{
				case 1: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_1); break;
				case 2: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_2); break;
				case 3: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_3); break;
				case 4: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_4); break;
				case 5: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_5); break;
				case 6: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_6); break;
				case 7: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_7); break;
				case 8: V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_8); break;
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
					OnButtonClicked(botaoAtual, currentTile, MouseButtons.Left);

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

					V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.tile_0);

					// Norte
					Point ponto = new Point(currentTile.Ponto.X, currentTile.Ponto.Y + 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));
					// Sul
					ponto = new Point(currentTile.Ponto.X, currentTile.Ponto.Y - 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));
					// Este
					ponto = new Point(currentTile.Ponto.X + 1, currentTile.Ponto.Y);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));

					// Oeste
					ponto = new Point(currentTile.Ponto.X - 1, currentTile.Ponto.Y);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));

					// Nordeste
					ponto = new Point(currentTile.Ponto.X + 1, currentTile.Ponto.Y + 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));

					// Noroeste
					ponto = new Point(currentTile.Ponto.X - 1, currentTile.Ponto.Y + 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));

					// Sudoeste
					ponto = new Point(currentTile.Ponto.X - 1, currentTile.Ponto.Y - 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));

					// Sudeste
					ponto = new Point(currentTile.Ponto.X + 1, currentTile.Ponto.Y - 1);
					if (PointIsValid(ref ponto))
						Flood_Fill(GetTile(ponto), V_MineSweeperGame.GetButton(ponto));
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
			Temporizador.Stop();
			if (M_Grelha.SoundOnOrOFF == true)
			{
				Thread soundThread = new Thread(Sound.PlayWinning);
				soundThread.IsBackground = true;
				soundThread.Start();
			}

			// Abre uma messabox que informa o utilizador que ganhou o jogo
			MessageBox.Show("Muito bem: " + GetTimeString(), "Ganhou!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//soundThread.Abort();

			FormVencedor _vencedor = new FormVencedor();
			if (_vencedor.ShowDialog() == DialogResult.OK)
				// O jogo acaba
				V_MineSweeperGame.Close();
		}

		/// <summary>
		/// Função apresenta uma messagem de erro em como clicou numa mina a perdeu
		/// </summary>
		public void BombaFimJogo()
		{
			if (M_Grelha.SoundOnOrOFF == true)
			{
				Thread soundThread = new Thread(Sound.PlayGameOver)
				{
					IsBackground = true
				};
				soundThread.Start();
			}//// Criar uma thread que funcione em background para emitir um som, neste caso o som de uma mina a explodir

			// Abre uma messabox que informa o utilizador que perdeu o jogo
			MessageBox.Show("BOOOM!", "Perdeu o jogo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			TimeSpan time = TimeSpan.FromSeconds(M_Grelha.timerCounter);

			//format that into a string
			string timeString = time.ToString(@"mm\:ss");

			//return it
			return timeString;
		}

		public void TimerTick(object sender, EventArgs e)
		{
			M_Grelha.timerCounter++;
			V_MineSweeperGame.AtualizaTempo(GetTimeString());
		}
	}
}