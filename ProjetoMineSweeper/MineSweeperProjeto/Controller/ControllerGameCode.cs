using Library.Helpers;
using Library.Model;
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

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
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

		// Dá um Reset ao Jogo
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

		public void V_GameMode_ChangeDifficulty(Dificuldade dificuldade)
		{
			AlteraDificuldade(dificuldade);
			V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(M_Grelha.NumMinasTotal);
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

			//foreach (var item in M_Grelha.Matriz)
			//{
			//	Debug.WriteLine("Ponto:" + item.Value.Ponto + ":" + item.Value.Aberto);
			//}
			//Debug.WriteLine("Numero de elementos abertos: " + M_Grelha.NumeroElementosAbertos);
			//Debug.WriteLine((M_Grelha.Matriz.Count - M_Grelha.NumMinasTotal));

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

		// Fim do jogo
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

			if (V_vencedor.ShowDialog() == DialogResult.OK)
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
		public void GetCoordinates(Button botaoAtual, out int x, out int y)
		{
			var parts = botaoAtual.Name.Split('-');
			x = Convert.ToInt32(parts[0]);
			y = Convert.ToInt32(parts[1]);
		}

		// -------------------------------------------------------------------------------------------------------
	}
}