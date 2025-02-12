﻿using Library.Helpers;
using Library.Models;
using MineSweeperProjeto.Model;
using MineSweeperProjeto.Properties;
using MineSweeperProjeto.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using static MineSweeperProjeto.Program;
using Library.ServerEndpoint;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
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

		/// <summary>
		/// Mostra visualmente todas as peças no jogo
		/// </summary>
		public void Reveal()
		{
			foreach (Button Botao in V_MineSweeperGame.GetButtons())
			{
				GetCoordinates(Botao, out int x, out int y);
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Vazio == false && currentTile.TemMina == false)
				{
					ButtonChangeBackground(Botao, currentTile);
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

		/// <summary>
		/// Mostra visualmente todas as peças que possuem número de adjacência; função chamada apenas no modo jogo inverso
		/// </summary>
		public void RevealPiecesWithAdjacentMines()
		{
			foreach (Button Botao in V_MineSweeperGame.GetButtons())
			{
				GetCoordinates(Botao, out int x, out int y);
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Vazio == false && currentTile.TemMina == false)
				{
					currentTile.Aberto = true;
					ButtonChangeBackground(Botao, currentTile);
				}
				else
				{
					continue;
				}
			}
		}

		/// <summary>
		/// Inicia Modo Inverso
		/// </summary>
		/// <param name="dificuldade"></param>
		private void V_StartForm_StartReverseMode(Dificuldade dificuldade)
		{
			V_GameMode_ChangeDifficulty(dificuldade);
			RevealPiecesWithAdjacentMines();
		}

		/// <summary>
		/// Reset ao jogo
		/// </summary>
		public void V_MineSweeperGame_AskToResetBoard()
		{
			ResetModel();
			Temporizador.Stop();
			Temporizador.Dispose();
			Temporizador = new Timer();
			SetupTimer();
			V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal);

			if (Program.M_Options.ModoJogo == GameMode.Inverso)
			{
				RevealPiecesWithAdjacentMines();
			}
			//SetupTimer();
		}

		/// <summary>
		/// Altera as definições do jogo consoante a decisão de escolha pelo utilizador na dificuldade
		/// </summary>
		/// <param name="dificuldade">Dificuldade do jogo escolhida pelo utilizador</param>
		public void V_GameMode_ChangeDifficulty(Dificuldade dificuldade)
		{
			Program.M_Grelha._Dificuldade = dificuldade;
			SetupModel();
			V_MineSweeperGame.AlteraDificuldadeNoView(Program.M_Grelha._Dificuldade);
			V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal);
		}

		/// <summary>
		/// Tratamento do evento clicar no botão, a função vai desencadear o fucionamento do jogo consoante o modo de jogo (Modo Normal ou Inverso).
		/// Faz o tratamento do botão esquerdo assim como do botão direito.
		/// </summary>
		/// <param name="sender">Botão</param>
		/// <param name="e">Foi premido rato esquerdo ou direito</param>
		public void OnButtonClicked(object sender, MouseEventArgs e)
		{
			// Se o Jogador se encontra a jogar no Modo normal, os botões funcionam desta maneira...
			if (Program.M_Options.ModoJogo == GameMode.Normal)
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
						ButtonChangeBackground(botaoAtual, currentTile);

						currentTile.Aberto = true;
						if (M_Options.SoundOnOrOFF == true)
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
					Button botaoAtual = sender as Button;
					GetCoordinates(botaoAtual, out int x, out int y);

					// Obtém as Coordenadas do Tile
					Tile currentTile = GetTile(new System.Drawing.Point(x, y));

					if (currentTile.Aberto != true)
					{
						if (M_Options.SoundOnOrOFF == true)
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

			// O jogo funciona em modo inverso, o jogador tem que detetar o posicionamento das minas
			else if (Program.M_Options.ModoJogo == GameMode.Inverso)
			{
				if (e.Button == MouseButtons.Left)
				{
					Temporizador.Start();

					Button botaoAtual = sender as Button;
					GetCoordinates(botaoAtual, out int x, out int y);

					// Obtém as Coordenadas do Tile
					Tile currentTile = GetTile(new System.Drawing.Point(x, y));

					if (currentTile.Aberto != true)
					{
						if (M_Options.SoundOnOrOFF == true)
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
							if (Program.M_Grelha.NumMinasTotal == M_Grelha.NumFlags)
							{
								return;
							}
							V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.flag1);
							currentTile.Flagged = true;
							M_Grelha.NumFlags++;
							V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal - M_Grelha.NumFlags);
						}
						//soundThread.Abort();
					}

					if (TestarFimModoInverso(currentTile) == true)
					{
						GanhouJogo();
					}
					else
					{
						return;
					}
				}
				else if (e.Button == MouseButtons.Right)
				{
					return;
				}
			}
		}

		/// <summary>
		/// Função simula premir no botão, útil quando usada recursiva como nos exemplos de abrir consecutivamente os espaços brancos adjacentes
		/// </summary>
		/// <param name="botaoAtual"></param>
		/// <param name="currentTile"></param>
		/// <param name="left"></param>
		public void OnButtonClicked(Button botaoAtual, Tile currentTile, MouseButtons left)
		{
			ButtonChangeBackground(botaoAtual, currentTile);
			currentTile.Aberto = true;
			// Se a condição for verdadeira a condição acaba
			if (TestarFim(currentTile) == true)
			{
				GanhouJogo();
			}
		}

		/// <summary>
		/// Altera imagem de fundo do botão enviado
		/// </summary>
		/// <param name="botaoAtual">Botão a alterar</param>
		/// <param name="currentTile">Para obter o número de Minas</param>
		public static void ButtonChangeBackground(Button botaoAtual, Tile currentTile)
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

		/// <summary>
		/// Permite abrir recursivamente todos os espaços em branco adjacentes
		/// </summary>
		/// <param name="currentTile"></param>
		/// <param name="botaoAtual"></param>
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

		// Procura e retorna um tile de acordo com o seu ponto
		public Tile GetTile(Point _point)
		{
			Tile temp;
			try
			{
				M_Grelha.Matriz.TryGetValue(_point, out temp);
			}
			catch (ArgumentNullException e)
			{
				throw e;
			}

			return temp;
		}

		/// <summary>
		/// Função simples que retorna um bool que indica se o jogador já explorou todos elementos sem minas
		/// </summary>
		/// <returns>True quando foi atingido o fim do jogo</returns>
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

			//
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
				throw new ArgumentOutOfRangeException("Número Elementos Abertos > numero Elementos na Matriz");
			}
		}

		/// <summary>
		/// Função simples que retorna um bool que indica se o jogador já plantou flags em todas sobre as minas
		/// </summary>
		/// <returns>True quando foi atingido o fim do jogo</returns>
		public bool TestarFimModoInverso(Tile currentTile)
		{
			if (currentTile.TemMina == true && currentTile.Flagged == true)
			{
				Program.M_Grelha.NumFlagsPosicionadosEmMinas++;
			}
			else if (currentTile.TemMina == true && currentTile.Flagged == false)
			{
				Program.M_Grelha.NumFlagsPosicionadosEmMinas--;
			}

			if (Program.M_Grelha.NumFlagsPosicionadosEmMinas == Program.M_Grelha.NumMinasTotal)
			{
				M_Grelha.Fim = true;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Apresenta mensagem de Fim do Jogo e pede para registar o score
		/// </summary>
		public void GanhouJogo()
		{
			Temporizador.Stop();
			if (M_Options.SoundOnOrOFF == true)
			{
				Thread soundThread = new Thread(Sound.PlayWinning);
				soundThread.IsBackground = true;
				soundThread.Start();
			}

			// Abre uma messabox que informa o utilizador que ganhou o jogo
			MessageBox.Show("Muito bem: " + GetTimeString(), "Ganhou!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//soundThread.Abort();

			if (M_Status.PlayingWithTheOnlineBoard == true)
			{
				Server.RegistarResultado(Program.M_Grelha._Dificuldade.ToString(), Program.M_Grelha.TimerCounter.ToString(), "true", Program.M_Status.ID);
				//Server.RegistarResultado(Program.M_Grelha.dificuldade.ToString(), Program.M_Grelha.timerCounter.ToString(), "True", Program.M_Status.ID);
			}
			if (V_Vencedor.ShowDialog() == DialogResult.OK)
				// O jogo acaba
				V_MineSweeperGame.Close();
		}

		/// <summary>
		/// Função apresenta uma messagem de erro em como clicou numa mina a perdeu
		/// </summary>
		public void BombaFimJogo()
		{
			if (M_Options.SoundOnOrOFF == true)
			{
				Thread soundThread = new Thread(Sound.PlayGameOver)
				{
					IsBackground = true
				};
				soundThread.Start();
			}//// Criar uma thread que funcione em background para emitir um som, neste caso o som de uma mina a explodir

			// Abre uma messabox que informa o utilizador que perdeu o jogo
			if (M_Status.PlayingWithTheOnlineBoard == true)
			{
				Server.RegistarResultado(Program.M_Grelha._Dificuldade.ToString(), Program.M_Grelha.TimerCounter.ToString(), "False", Program.M_Status.ID);
			}
			MessageBox.Show("BOOOM!", "Perdeu o jogo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//soundThread.Abort();
		}

		// O nome do botão é do género {x}-{y}, a partir desse facto vamos extrair os números para variáveis int
		public void GetCoordinates(Button botaoAtual, out int x, out int y)
		{
			var parts = botaoAtual.Name.Split('-');
			x = Convert.ToInt32(parts[0]);
			y = Convert.ToInt32(parts[1]);
		}
	}
}