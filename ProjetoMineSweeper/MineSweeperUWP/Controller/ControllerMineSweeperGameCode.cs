using Library.Helpers;
using Library.Models;
using Library.ServerEndpoint;
using MineSweeperProjeto.Helpers;
using MineSweeperUWP.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MineSweeperUWP.Controller
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

		private void V_MineSweeperGame_UpdateTimer(int tempo)
		{
			Program.M_Grelha.TimerCounter = tempo;
		}

		private async void V_MineSweeperGame_RightButtonPressed(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
		{
			if (Program.M_Options.ModoJogo == GameMode.Normal)
			{
				Button botaoAtual = (sender as Button);
				GetCoordinates(botaoAtual, out int x, out int y);

				// Obtém as Coordenadas do Tile
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Aberto != true)
				{
					if (Program.M_Options.SoundOnOrOFF == true)
					{
						if (Program.M_Grelha.SoundOnOrOFF == true)
						{
							await App.SoundPlayer.Play(SoundEfxEnum.FLAG);
						}
					}

					if (currentTile.Flagged == true)
					{
						//Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/unopened.jpg");
						Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "fechado");
						currentTile.Flagged = false;
						Program.M_Grelha.NumFlags--;
						Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal - Program.M_Grelha.NumFlags);
					}
					else if (currentTile.Flagged == false)
					{
						Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "bandeira");
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
			else if (Program.M_Options.ModoJogo == GameMode.Inverso)
			{
				return;
			}
		}

		private async void V_MineSweeperGame_LeftButtonPressed(object sender, RoutedEventArgs e)
		{
			if (Program.M_Options.ModoJogo == GameMode.Normal)
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

					Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "bomba");
					Reveal();
					BombaFimJogo();

					await Task.Delay(TimeSpan.FromSeconds(2));

					// O jogo acaba
					V_MineSweeperGame_AskToResetBoard();
				}
				else if (currentTile.Vazio == false && currentTile.Aberto == false)
				{
					SwitchBackground(botaoAtual, currentTile);

					currentTile.Aberto = true;
					if (Program.M_Options.SoundOnOrOFF == true)
					{
						await App.SoundPlayer.Play(SoundEfxEnum.CLICK);
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
			else if (Program.M_Options.ModoJogo == GameMode.Inverso)
			{
				Button botaoAtual = (sender as Button);
				GetCoordinates(botaoAtual, out int x, out int y);

				// Obtém as Coordenadas do Tile
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Aberto != true)
				{
					if (Program.M_Options.SoundOnOrOFF == true)
					{
						if (Program.M_Grelha.SoundOnOrOFF == true)
						{
							await App.SoundPlayer.Play(SoundEfxEnum.FLAG);
						}
					}

					if (currentTile.Flagged == true)
					{
						//Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/unopened.jpg");
						Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "fechado");
						currentTile.Flagged = false;
						Program.M_Grelha.NumFlags--;
						Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal - Program.M_Grelha.NumFlags);
					}
					else if (currentTile.Flagged == false)
					{
						if (Program.M_Grelha.NumMinasTotal == Program.M_Grelha.NumFlags)
						{
							return;
						}
						Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "bandeira");
						currentTile.Flagged = true;
						Program.M_Grelha.NumFlags++;
						Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal - Program.M_Grelha.NumFlags);
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
		}

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
				Program.M_Grelha.Fim = true;
				return true;
			}

			return false;
		}

		public void Reveal()
		{
			foreach (Button Botao in Program.V_MineSweeperGame.GetButtons())
			{
				GetCoordinates(Botao, out int x, out int y);
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Vazio == false && currentTile.TemMina == false)
				{
					SwitchBackground(Botao, currentTile);
				}
				else if (currentTile.TemMina == true)
				{
					Program.V_MineSweeperGame.ChangeButtonBackGround(Botao, "bomba");
				}
				else if (currentTile.Vazio == true)
				{
					Program.V_MineSweeperGame.ChangeButtonBackGround(Botao, "0");
				}
			}
		}

		public void RevealPiecesWithAdjacentMines()
		{
			foreach (Button Botao in Program.V_MineSweeperGame.GetButtons())
			{
				GetCoordinates(Botao, out int x, out int y);
				Tile currentTile = GetTile(new System.Drawing.Point(x, y));

				if (currentTile.Vazio == false && currentTile.TemMina == false)
				{
					currentTile.Aberto = true;
					SwitchBackground(Botao, currentTile);
				}
				else
				{
					continue;
				}
			}
		}

		// Dá um Reset ao Jogo
		public void V_MineSweeperGame_AskToResetBoard()
		{
			ResetModel();
			//Temporizador.Stop();
			//Temporizador.Dispose();
			//Temporizador = new Timer();
			//SetupTimer();
			Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal);
			//SetupTimer();
			if (Program.M_Options.ModoJogo == GameMode.Inverso)
			{
				RevealPiecesWithAdjacentMines();
			}
		}

		//public void V_GameMode_ChangeDifficulty(Dificuldade dificuldade)
		//{
		//	AlteraDificuldade(dificuldade);
		//	Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal);
		//}

		//public void AlteraDificuldade(Dificuldade _dificuldade)
		//{
		//	this.dificuldade = _dificuldade;
		//	SetModel(dificuldade);

		//}

		//public void OnButtonClicked(object sender, RoutedEventArgs e)
		//{
		//	// Botão esquerdo, abre espaço
		//	if (e.Button == MouseButtons.Left)
		//	{
		//		//Temporizador.Start();
		//		//// Obter Botão premido e guardar
		//		var botaoAtual = (sender as Button);

		//		// Obtém as Coordenadas do Tile
		//		GetCoordinates(botaoAtual, out int x, out int y);

		//		Tile currentTile = GetTile(new System.Drawing.Point(x, y));

		//		if (currentTile.TemMina == true)
		//		{
		//			//	Jogo perdido
		//			//Temporizador.Stop();

		//			Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/bomb.jpg");
		//			Reveal();
		//			BombaFimJogo();

		//			// O jogo acaba
		//			Program.V_MineSweeperGame_AskToResetBoard();
		//		}
		//		else if (currentTile.Vazio == false && currentTile.Aberto == false)
		//		{
		//			SwitchBackground(botaoAtual, currentTile);

		//			currentTile.Aberto = true;
		//			//if (Program.M_Grelha.SoundOnOrOFF == true)
		//			//{
		//			//	Thread soundThread = new Thread(Sound.PlayOpenTile)
		//			//	{
		//			//		IsBackground = true
		//			//	};
		//			//	soundThread.Start();
		//			//}

		//			// Se a condição for verdadeira a condição acaba
		//			if (TestarFim(currentTile) == true)
		//			{
		//				GanhouJogo();
		//			}
		//			//soundThread.Abort();
		//		}
		//		// O jogo tem que abrir todos os vazios adjacentes.
		//		// Primeira Questão: Como pedir os botões adjacentes ao view?
		//		else if (currentTile.Vazio == true && currentTile.Aberto == false)
		//		{
		//			Flood_Fill(currentTile, Program.V_MineSweeperGame.GetButton(currentTile.Ponto));
		//		}
		//	}

		//	// Botão direito, coloca flag
		//	else if (e.Button == MouseButtons.Right)
		//	{
		//		Button botaoAtual = (sender as Button);
		//		GetCoordinates(botaoAtual, out int x, out int y);

		//		// Obtém as Coordenadas do Tile
		//		Tile currentTile = GetTile(new System.Drawing.Point(x, y));

		//		if (currentTile.Aberto != true)
		//		{
		//			//if (Program.M_Grelha.SoundOnOrOFF == true)
		//			//{
		//			//	Thread soundThread = new Thread(Sound.PlayPutFlag)
		//			//	{
		//			//		IsBackground = true
		//			//	};
		//			//	soundThread.Start();
		//			//}

		//			if (currentTile.Flagged == true)
		//			{
		//				Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.unopened);
		//				currentTile.Flagged = false;
		//				Program.M_Grelha.NumFlags--;
		//				Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal - Program.M_Grelha.NumFlags);
		//			}
		//			else if (currentTile.Flagged == false)
		//			{
		//				Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, Resources.flag1);
		//				currentTile.Flagged = true;
		//				Program.M_Grelha.NumFlags++;
		//				Program.V_MineSweeperGame.AtualizaNumeroMinasDisponiveis(Program.M_Grelha.NumMinasTotal - Program.M_Grelha.NumFlags);
		//			}
		//			//soundThread.Abort();
		//		}
		//		else
		//		{
		//			return;
		//		}
		//	}
		//}

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

		//public void SwitchBackground(Button botaoAtual, Tile currentTile)
		//{
		//	switch (currentTile.NumeroMinas)

		//	{
		//		case 1: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_1.jpg"); break;
		//		case 2: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_2.jpg"); break;
		//		case 3: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_3.jpg"); break;
		//		case 4: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_4.jpg"); break;
		//		case 5: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_5.jpg"); break;
		//		case 6: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_6.jpg"); break;
		//		case 7: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_7.jpg"); break;
		//		case 8: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_8.jpg"); break;
		//		default:
		//			throw new ArgumentException("O número de minas adjacentes não pode ser superior a 8 nem inferior a 1");
		//	}
		//}

		public void SwitchBackground(Button botaoAtual, Tile currentTile)
		{
			switch (currentTile.NumeroMinas)

			{
				case 1: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "1"); break;
				case 2: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "2"); break;
				case 3: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "3"); break;
				case 4: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "4"); break;
				case 5: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "5"); break;
				case 6: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "6"); break;
				case 7: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "7"); break;
				case 8: Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "8"); break;
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

					//Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "Assets/tiles/tile_0.jpg");
					Program.V_MineSweeperGame.ChangeButtonBackGround(botaoAtual, "0");

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

		// Procura e retorna um tile de acordo com o seu ponto
		public Tile GetTile(Point _point)
		{
			Tile temp;
			try
			{
				Program.M_Grelha.Matriz.TryGetValue(_point, out temp);
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

			if (Program.M_Grelha.Abertos.Contains(currentTile) == false)
			{
				Program.M_Grelha.NumeroElementosAbertos++;
			}
			else
			{
				return false;
			}
			Program.M_Grelha.Abertos.Add(currentTile);

			//foreach (var item in Program.M_Grelha.Matriz)
			//{
			//	Debug.WriteLine("Ponto:" + item.Value.Ponto + ":" + item.Value.Aberto);
			//}
			//Debug.WriteLine("Numero de elementos abertos: " + Program.M_Grelha.NumeroElementosAbertos);
			//Debug.WriteLine((Program.M_Grelha.Matriz.Count - Program.M_Grelha.NumMinasTotal));

			//
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
				throw new ArgumentOutOfRangeException("Número Elementos Abertos > numero Elementos na Matriz");
			}
		}

		// Fim do jogo
		public async void GanhouJogo()
		{
			//Temporizador.Stop();
			if (Program.M_Grelha.SoundOnOrOFF == true)
			{
				await App.SoundPlayer.Play(SoundEfxEnum.GAMEWIN);
			}

			//// Abre uma messabox que informa o utilizador que ganhou o jogo
			//MessageBox.Show("Muito bem: " + GetTimeString(), "Ganhou!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			////soundThread.Abort();

			//if (V_vencedor.ShowDialog() == DialogResult.OK)
			//	// O jogo acaba
			//	Program.V_MineSweeperGame.Close();
			if (Program.M_Status.PlayingWithTheOnlineBoard == true)
			{
				Server.RegistarResultado(Program.M_Grelha._Dificuldade.ToString(), Program.M_Grelha.TimerCounter.ToString(), "true", Program.M_Status.ID);
				//Server.RegistarResultado(Program.M_Grelha.dificuldade.ToString(), Program.M_Grelha.timerCounter.ToString(), "True", Program.M_Status.ID);
			}

			var dlg = new ContentDialog2();
			var result = await dlg.ShowAsync();
			string text = string.Empty;
			if (result == ContentDialogResult.Primary)
			{
				text = dlg.Text;
			}

			V_vencedor_SendUsername(text);
		}

		/// <summary>
		/// Função apresenta uma messagem de erro em como clicou numa mina a perdeu
		/// </summary>
		public async void BombaFimJogo()
		{
			if (Program.M_Grelha.SoundOnOrOFF == true)
			{
				await App.SoundPlayer.Play(SoundEfxEnum.GAMEOVER);
			}

			//// Criar uma thread que funcione em background para emitir um som, neste caso o som de uma mina a explodir

			//// Abre uma messabox que informa o utilizador que perdeu o jogo
			//MessageBox.Show("BOOOM!", "Perdeu o jogo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			////soundThread.Abort();

			if (Program.M_Status.PlayingWithTheOnlineBoard == true)
			{
				Server.RegistarResultado(Program.M_Grelha._Dificuldade.ToString(), Program.M_Grelha.TimerCounter.ToString(), "False", Program.M_Status.ID);
			}

			var dlg = new MessageDialog("Perdeu. Tente Novamente");

			dlg.Commands.Clear();
			dlg.Commands.Add(new UICommand { Label = "Ok", Id = 0 });

			await dlg.ShowAsync();
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