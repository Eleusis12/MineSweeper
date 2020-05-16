using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperProjeto.Model
{
	public class TileGrid
	{
		// Lado * Altura = tamanho da matriz de elementos
		public Size Tamanho { get; set; }

		// Número Total de minas na lista
		public int NumMinasTotal { get; set; }

		public int NumeroElementosAbertos { get; set; } = 0;

		// Indica se todos os espaços sem minas já foram explorados
		public bool Fim { get; set; } = false;

		// Coleção Dictionary que vai permitir guardar todos os "tiles" num único lugar
		// Foi escolhido Dictionary porque permite guardar apenas um tile único tendo em conta o valor da chave : Fácil de controlar erros
		// Coleção genérica: melhor que hastable
		public Dictionary<Point, Tile> Matriz { get; set; }

		public HashSet<Tile> Abertos { get; set; }

		// Numero de flags selecionadas, para depois apresentar no ecrã (Lembrar: flag é quando se carrega no rato direito sobre a tile)
		public int NumFlags { get; set; }

		public Random NumeroAleatorio { get; set; }

		public Dificuldade dificuldade { get; set; }

		public int timerCounter { get; set; } = 0;

		public bool SoundOnOrOFF { get; set; } = true;

		// Dificuldade vai determinar o tamanho da matriz de tile

		//private void SetupBoard(Dificuldade dificuldade)
		//{
		//	Tamanho = GetTamanho(dificuldade);
		//	SetAmountOfMines();
		//	LoadTileGrid();
		//	LoadAdjacentsMines();
		//}

		//private void SetAmountOfMines()
		//{
		//	switch (dificuldade)
		//	{
		//		case Dificuldade.Facil:

		//			NumMinasTotal = 10;
		//			break;

		//		case Dificuldade.Medio:

		//			NumMinasTotal = 40;
		//			break;

		//		case Dificuldade.Dificil:
		//			NumMinasTotal = 99;
		//			break;

		//		default:
		//			throw new InvalidOperationException("Dificuldade não implementada");
		//	}
		//}

		//public void AlteraDificuldade(Dificuldade _dificuldade)
		//{
		//	this.dificuldade = _dificuldade;
		//	SetupBoard(dificuldade);
		//	if (AlteraDificuldadeNoView != null)
		//	{
		//		AlteraDificuldadeNoView(this.dificuldade);
		//	}
		//}

		/// <summary>
		/// Função simples que retorna um bool que indica se o jogador já explorou todos elementos sem minas
		/// </summary>
		/// <returns></returns>
		//public bool TestarFim(Tile currentTile)
		//{
		//	// É suposto receber um tile que foi recentemente aberto
		//	if (currentTile.Aberto == false)
		//		throw new ArgumentException();

		//	// Incrementamos um a NumeroElementosAbertos uma vez que foi aberto um tile

		//	if (Abertos.Contains(currentTile) == false)
		//	{
		//		NumeroElementosAbertos++;
		//	}
		//	else
		//	{
		//		return false;
		//	}
		//	Abertos.Add(currentTile);

		//	foreach (var item in Matriz)
		//	{
		//		Debug.WriteLine("Ponto:" + item.Value.Ponto + ":" + item.Value.Aberto);
		//	}
		//	Debug.WriteLine("Numero de elementos abertos: " + NumeroElementosAbertos);
		//	Debug.WriteLine((Matriz.Count - numMinasTotal));
		//	if (NumeroElementosAbertos < (Matriz.Count - numMinasTotal))
		//	{
		//		fim = false;
		//		return false;
		//	}
		//	else if (NumeroElementosAbertos == (Matriz.Count - numMinasTotal))
		//	{
		//		fim = true;
		//		return true;
		//	}
		//	else
		//	{
		//		throw new ArgumentOutOfRangeException("numero Elementos Abertos > numero Elementos na Matriz");
		//	}
		//}

		//public static Size GetTamanho(Dificuldade _dificuldade)
		//{
		//	Size _tamanho = new Size();
		//	switch (_dificuldade)
		//	{
		//		// TODO: Valores a confirmar com o protocolo
		//		case Dificuldade.Facil:
		//			_tamanho.Width = _tamanho.Height = 9;
		//			break;

		//		case Dificuldade.Medio:
		//			_tamanho.Width = _tamanho.Height = 16;
		//			break;

		//		case Dificuldade.Dificil:
		//			_tamanho.Width = 30;
		//			_tamanho.Height = 16;

		//			break;

		//		default:
		//			throw new InvalidOperationException("Dificuldade não implementada");
		//	}
		//	return _tamanho;
		//}

		//TODO: INCOMPLETO: COMPOR O ALGORITMO PARA ADICIONAR ESPAÇOS EM BRANCO TAMBÉM
		// Preenche o nosso dicionário com todos os tiles
		//private void LoadTileGrid()
		//{
		//	// Gerar Minas
		//	// TODO: BUG, ÀS VEZES SÓ APARECE 9 MINAS NO MODO FÁCIL, QUANDO DEVERIAM APARECER 10
		//	// Problema: Elementos repetiam-se
		//	List<Point> indexMinas = new List<Point>();
		//	Point minaPonto;
		//	for (int i = 0; i < numMinasTotal; i++)
		//	{
		//		do
		//		{
		//			minaPonto = new Point(random.Next(Tamanho.Height), random.Next(Tamanho.Width));
		//		} while (indexMinas.Contains(minaPonto) == true);
		//		indexMinas.Add(minaPonto);
		//	}
		//	int index = 0;
		//	for (int i = 0; i < Tamanho.Height; i++)
		//	{
		//		for (int j = 0; j < Tamanho.Width; j++)
		//		{
		//			Point location = new Point(i, j);

		//			// Se a mina foi gerada para este lugar
		//			if (indexMinas.Contains(new Point(i, j)))
		//			{
		//				// Adiciona um elemento com mina
		//				Tile elemento = new Tile(location);
		//				elemento.temMina = true;
		//				Matriz.Add(location, elemento);
		//			}
		//			else
		//			{
		//				// Adiciona um elemento sem mina
		//				Tile elemento = new Tile(location);
		//				elemento.temMina = false;
		//				Matriz.Add(location, elemento);
		//			}
		//			index++;
		//		}
		//	}
		//	//Debug.WriteLine(Matriz.Count);
		//	//foreach (var item in Matriz)

		//	//{
		//	//	Debug.WriteLine(item.Value.Ponto.ToString() + " " + item.Value.temMina.ToString());
		//	//}
		//}

		//public void ResetModelBoard()
		//{
		//	Matriz = new Dictionary<Point, Tile>();
		//	Abertos = new HashSet<Tile>();
		//	SetupBoard(dificuldade);

		//	if (ResetBoardView != null)

		//	{
		//		ResetBoardView();
		//	}
		//}

		//TODO: UTILIZAR DEBUGGER PARA VERIFICAR SE AO ALTERAR O VALOR DE TEMPFILE, É ALTERADO O VALOR NA MATRIZ TAMBÉM
		// Função para calcular o numero de minas adjacentes para cada elemento da Matriz

		//private void LoadAdjacentsMines()
		//{
		//	Point _pontoTemporario;
		//	Tile tempTile;

		//	foreach (KeyValuePair<Point, Tile> espaco in Matriz)
		//	{
		//		// Se o espaco em questñao possuir uma mina, a contagem de minas nñao é necessária
		//		if (espaco.Value.temMina == true)
		//			continue;

		//		foreach (Point coordenada in Tile.adjacentCoords)
		//		{
		//			_pontoTemporario = new Point(espaco.Value.Ponto.X + coordenada.X, espaco.Value.Ponto.Y + coordenada.Y);
		//			// Se estivermos perante um ponto válido
		//			if (PointIsValid(ref _pontoTemporario))
		//			{
		//				if (Matriz.TryGetValue(_pontoTemporario, out tempTile) == true)
		//				{
		//					if (tempTile.temMina == true)
		//					{
		//						espaco.Value.NumeroMinas++;
		//					}
		//				}
		//			}
		//		}

		//		if (espaco.Value.NumeroMinas == 0)
		//			espaco.Value.Vazio = true;
		//		else
		//		{
		//			espaco.Value.Vazio = false;
		//		}
		//	}
		//}

		//public bool PointIsValid(ref Point _pontoTemporario)
		//{
		//	return (_pontoTemporario.X >= 0 && _pontoTemporario.X < Tamanho.Height && _pontoTemporario.Y >= 0
		//							&& _pontoTemporario.Y < Tamanho.Width);
		//}

		//public Tile GetTile(Point _point)
		//{
		//	Tile temp;
		//	Matriz.TryGetValue(_point, out temp);
		//	return temp;
		//}
	}
}