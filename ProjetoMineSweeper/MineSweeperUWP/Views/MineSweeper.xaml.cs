using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

using Microsoft.Toolkit.Uwp;
using MineSweeperProjeto.Helpers;
using Windows.Devices.Input;
using Windows.UI.Xaml.Media.Imaging;
using Library;
using System.Drawing;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeperUWP.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MineSweeper : Page
	{
		public event NotificationTaskHandler AskToRevealAllPieces;

		public event NotificationTaskHandler AskToResetBoard;

		public event RoutedEventHandler LeftButtonPressed;

		public event RightTappedEventHandler RightButtonPressed;

		private Size Tamanho;
		private Dificuldade dificuldade { get; set; }

		private App Program { get; }

		private List<Button> listaBotoes;

		private brushes brushes = new brushes();

		public MineSweeper()
		{
			Program = App.Current as App;

			listaBotoes = new List<Button>();

			Tamanho.Height = 9;
			Tamanho.Width = 9;

			this.InitializeComponent();
			generateControls();
		}

		private void generateControls()
		{
			for (int i = 1; i <= 9; i++)
			{
				for (int j = 1; j <= 9; j++)
				{
					Button btn = new Button();
					btn.Name = string.Format($"{i - 1}-{j - 1}");
					btn.VerticalAlignment = VerticalAlignment.Stretch;
					btn.HorizontalAlignment = HorizontalAlignment.Stretch;
					btn.Foreground = brushes.blue;
					btn.BorderThickness = new Thickness(0.5);
					btn.BorderBrush = brushes.gray;
					btn.SizeChanged += new SizeChangedEventHandler(btnSizeChanged);
					btn.Background = brushes.darkSlateGray;
					btn.Click += new RoutedEventHandler(ButtonMouseClick);
					btn.RightTapped += new RightTappedEventHandler(RightMouseClick);

					Grid.SetRow(btn, i);
					Grid.SetColumn(btn, j);
					innergrid.Children.Add(btn);
					listaBotoes.Add(btn);
				}
			}
			//innergrid.(0, 0, 1.5f);
		}

		private void RightMouseClick(object sender, RightTappedRoutedEventArgs e)
		{
			if (RightButtonPressed != null)
			{
				RightButtonPressed((sender as Button), e);
			}
		}

		private void btnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			Button btn = (Button)sender;
		}

		public void ResetBoardView()
		{
			foreach (Button Botao in GetButtons())
			{
				ChangeButtonBackGround(Botao, @"Assets\tiles\unopened.jpg");
			}
		}

		/// <summary>
		///  Muda A imagem de fundo do botão para a Imagem Bitmap pretendida
		/// </summary>
		public void ChangeButtonBackGround(Button botaoAtual, string file)
		{
			botaoAtual.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, file)), Stretch = Stretch.None };
		}

		//public void AlteraDificuldadeNoView(Dificuldade _dificuldade)
		//{
		//	this.dificuldade = Program.M_Grelha.dificuldade;
		//	Tamanho = Program.C_Master.GetTamanho(this.dificuldade);
		//	//if (Tamanho.Width == 30 && Tamanho.Height == 16)
		//	//{
		//	//	this.Size = new Size(new Point(635, 470));
		//	//	FLPPainelBotoes.Size = new Size(new Point(604, 324));
		//	//}
		//}

		/// <summary>
		/// Retorna um a um cada botao (testando funcionamento de yield)
		/// </summary>
		public IEnumerable<Button> GetButtons()
		{
			foreach (var botao in listaBotoes)
			{
				yield return botao;
			}
		}

		//private void _InicializaGrid()
		//{
		//	ColumnDefinition umaColuna = null;
		//	RowDefinition umaLinha = null;

		//	try
		//	{
		//		gridPrincipal = new Grid();

		//		for (int i = 0; i < Tamanho.Height; i++)
		//		{
		//			umaColuna = new ColumnDefinition();

		//			umaColuna.Width = new GridLength(0, GridUnitType.Auto);
		//			gridPrincipal.ColumnDefinitions.Add(umaColuna);
		//		}

		//		for (int i = 0; i < Tamanho.Width; i++)
		//		{
		//			umaLinha = new RowDefinition();
		//			umaLinha.Height = new GridLength(0, GridUnitType.Auto);

		//			gridPrincipal.RowDefinitions.Add(umaLinha);
		//		}

		//		 .Children.Add(gridPrincipal);
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

		//private void _InicializaTabuleiro()
		//{
		//	Button button = null;
		//	try
		//	{
		//		for (int i = 0; i < Tamanho.Height; i++)
		//		{
		//			for (int j = 0; j < Tamanho.Width; j++)
		//			{
		//				button = new Button
		//				{
		//					Name = string.Format($"{i}-{j}"),
		//					//Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, @"Assets\tiles\unopened.jpg")), Stretch = Stretch.None }
		//				};

		//				button.PointerPressed += ButtonMouseClick; ;
		//				listaBotoes.Add(button);
		//				gridPrincipal.Children.Add(button);
		//				Grid.SetColumn(button, j);
		//				Grid.SetRow(button, i);
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

		public void ButtonMouseClick(object sender, RoutedEventArgs e)
		{
			// Left button pressed
			if (LeftButtonPressed != null)
			{
				LeftButtonPressed((sender as Button), e);
			}

			//switch (e.Button)
			//{
			//	case MouseButtons.Left:
			//		LeftClick((sender as Button), e);
			//		break;

			//	case MouseButtons.Right:
			//		RightClick((sender as Button), e);
			//		break;
			//}
		}

		public void AtualizaTempo(string _tempo)
		{
			// Atualiza o Temporizador
			LBLTimer.Text = _tempo;
		}

		public void AtualizaNumeroMinasDisponiveis(int _num)
		{
			LBLMinas.Text = _num.ToString();
		}

		/// <summary>
		/// Dá uma forma 3d ao botão smile
		/// </summary>

		public void Cheater_MouseClick(object sender, MouseEventArgs e)
		{
			if (AskToRevealAllPieces != null)
			{
				AskToRevealAllPieces();
			}
		}

		public void Reset_MouseClick(object sender, MouseEventArgs e)
		{
			if (AskToResetBoard != null)
			{
				AskToResetBoard();
			}
		}

		public Button GetButton(Point _point)
		{
			// DEBUG: Testar linq e lambda
			//var Botao = listaBotoes.Where(x => x.Name == string.Format($"{_point.X}-{_point.Y}"));
			// TESTAR:
			var Botao = (from Button item in listaBotoes
						 where (item.Name == string.Format($"{_point.X}-{_point.Y}"))
						 select item).First();
			return Botao;
		}

		public void BTSmile_Click(object sender, EventArgs e)
		{
			if (AskToResetBoard != null)
			{
				AskToResetBoard();
			}
		}
	}

	public class brushes
	{
		public SolidColorBrush darkSlateGray = new SolidColorBrush(Colors.DarkSlateGray);
		public SolidColorBrush red = new SolidColorBrush(Colors.Red);
		public SolidColorBrush white = new SolidColorBrush(Colors.White);
		public SolidColorBrush green = new SolidColorBrush(Colors.Green);
		public SolidColorBrush gray = new SolidColorBrush(Colors.Gray);
		public SolidColorBrush blue = new SolidColorBrush(Colors.Blue);
	}
}