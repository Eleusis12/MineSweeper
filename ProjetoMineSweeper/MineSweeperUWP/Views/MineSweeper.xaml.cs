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
using Windows.Devices.Input;
using Windows.UI.Xaml.Media.Imaging;
using Library;
using System.Drawing;
using Library.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeperUWP.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MineSweeper : Page
	{
		//public event NotificationTaskHandler AskToRevealAllPieces;

		public event NotificationTaskHandler AskToResetBoard;

		public event RoutedEventHandler LeftButtonPressed;

		public event RightTappedEventHandler RightButtonPressed;

		public event TimeExtractionHandler UpdateTimer;

		private BitmapImage Bomba;
		private BitmapImage Bandeira;

		private Size Tamanho;

		private App Program { get; }

		private List<Button> listaBotoes;

		private brushes brushes = new brushes();

		public static bool firstTimeClickingAButton = true;

		#region AtributosParaOTimer

		private DispatcherTimer dispatcherTimer;
		private DateTimeOffset startTime;
		private DateTimeOffset lastTime;
		private int timesTicked = 1;

		#endregion AtributosParaOTimer

		public MineSweeper()
		{
			Program = App.Current as App;

			listaBotoes = new List<Button>();

			Bomba = new BitmapImage(new Uri("ms-appx:///Assets/BombFlag/Bomb.png",
   UriKind.RelativeOrAbsolute));

			Bandeira = new BitmapImage(new Uri("ms-appx:///Assets/BombFlag/Flag.png",
   UriKind.RelativeOrAbsolute))
		   ;

			this.InitializeComponent();

			GenerateControls();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			if (e.Parameter.ToString() == "Fácil")
			{
				Program.M_Grelha.dificuldade = Dificuldade.Facil;
			}
			else if (e.Parameter.ToString() == "Médio")
			{
				Program.M_Grelha.dificuldade = Dificuldade.Medio;
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}

			SetSizeAccordingToDifficulty(Program.M_Grelha.dificuldade);
			SetLabelDifficulty();
			GenerateGrid();
			GenerateControls();
		}

		private void SetLabelDifficulty()
		{
			LBLDificuldade.Text = Program.M_Grelha.dificuldade.ToString() + " " + Tamanho.Width.ToString() + "x" + Tamanho.Height.ToString();
		}

		private void SetSizeAccordingToDifficulty(Dificuldade dificuldade)
		{
			if (dificuldade == Dificuldade.Facil)
			{
				Tamanho.Height = 9;
				Tamanho.Width = 9;
			}
			else if (dificuldade == Dificuldade.Medio)
			{
				Tamanho.Height = 16;
				Tamanho.Width = 16;
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}
		}

		private void GenerateGrid()
		{
			try
			{
				for (int i = 0; i < Tamanho.Width; i++)
				{
					ColumnDefinition coluna = new ColumnDefinition();

					innergrid.ColumnDefinitions.Add(coluna);
				}

				for (int i = 0; i < Tamanho.Height; i++)
				{
					RowDefinition linha = new RowDefinition();
					innergrid.RowDefinitions.Add(linha);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void GenerateControls()
		{
			for (int i = 0; i < Tamanho.Width; i++)
			{
				for (int j = 0; j < Tamanho.Width; j++)
				{
					Button btn = new Button();
					btn.Name = string.Format($"{i}-{j}");
					btn.VerticalAlignment = VerticalAlignment.Stretch;
					btn.HorizontalAlignment = HorizontalAlignment.Stretch;
					btn.Foreground = brushes.blue;
					btn.BorderThickness = new Thickness(0.5);
					btn.BorderBrush = brushes.gray;
					btn.SizeChanged += new SizeChangedEventHandler(btnSizeChanged);
					btn.Background = brushes.darkSlateGray;
					btn.Click += new RoutedEventHandler(ButtonMouseClick);
					btn.RightTapped += new RightTappedEventHandler(RightMouseClick);
					btn.FontSize = 30;

					Grid.SetRow(btn, i);
					Grid.SetColumn(btn, j);
					innergrid.Children.Add(btn);
					listaBotoes.Add(btn);
				}
			}
			//innergrid.(0, 0, 1.5f);
		}

		internal void ResetTimer()
		{
			dispatcherTimer.Stop();
			AtualizaTempo("0");
			timesTicked = 0;
			firstTimeClickingAButton = true;
		}

		private void btnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			Button btn = (Button)sender;
		}

		public void RightMouseClick(object sender, RightTappedRoutedEventArgs e)
		{
			if (RightButtonPressed != null)
			{
				RightButtonPressed((sender as Button), e);
			}
		}

		public void ResetBoardView()
		{
			foreach (Button Botao in GetButtons())
			{
				ChangeButtonBackGround(Botao, "fechado");
			}
		}

		/// <summary>
		///  Muda A imagem de fundo do botão para a Imagem Bitmap pretendida
		/// </summary>
		public void ChangeButtonBackGround(Button botaoAtual, string file)
		{
			//botaoAtual.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, file)), Stretch = Stretch.None };

			//var brush = new ImageBrush();
			//brush.ImageSource = new BitmapImage(new Uri(file));
			//botaoAtual.Background = brush;

			var image = new Windows.UI.Xaml.Controls.Image();

			switch (file)
			{
				case "0":
					botaoAtual.Background = brushes.green; break;
				case "1":
				case "2":
				case "3":
				case "4":
				case "5":
				case "6":
				case "7":
				case "8":
					botaoAtual.Content = Convert.ToInt32(file); break;

				case "bomba":

					image.Source = Bomba;
					botaoAtual.Content = image;
					break;

				case "bandeira":
					image.Source = Bandeira;
					botaoAtual.Content = image;
					break;

				case "fechado":
					botaoAtual.Content = string.Empty;
					botaoAtual.Background = brushes.LightGray;
					break;
			}
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

		private void ButtonMouseClick(object sender, RoutedEventArgs e)
		{
			// Left button pressed
			if (LeftButtonPressed != null)
			{
				LeftButtonPressed((sender as Button), e);

				if (firstTimeClickingAButton == true)
				{
					DispatcherTimerSetup();
					firstTimeClickingAButton = false;
				}
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

		public void DispatcherTimerSetup()
		{
			dispatcherTimer = new DispatcherTimer();
			dispatcherTimer.Tick += dispatcherTimer_Tick;
			dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
			//IsEnabled defaults to false
			//TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
			startTime = DateTimeOffset.Now;
			lastTime = startTime;
			//TimerLog.Text += "Calling dispatcherTimer.Start()\n";
			dispatcherTimer.Start();
			//IsEnabled should now be true after calling start
			//TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
		}

		private void dispatcherTimer_Tick(object sender, object e)
		{
			DateTimeOffset time = DateTimeOffset.Now;
			TimeSpan span = time - lastTime;
			lastTime = time;
			//Time since last tick should be very very close to Interval
			//TimerLog.Text += timesTicked + "\t time since last tick: " + span.ToString() + "\n";
			AtualizaTempo(timesTicked.ToString());
			timesTicked++;
		}

		public void AtualizaTempo(string tempo)
		{
			// Atualiza o Temporizador
			LBLTimer.Text = "Tempo: " + tempo;
			if (UpdateTimer != null)
			{
				UpdateTimer(Convert.ToInt32(tempo));
			}
		}

		public void AtualizaNumeroMinasDisponiveis(int _num)
		{
			LBLMinas.Text = "Minas: " + _num.ToString();
		}

		/// <summary>
		/// Dá uma forma 3d ao botão smile
		/// </summary>

		//public void Cheater_MouseClick(object sender, MouseEventArgs e)
		//{
		//	if (AskToRevealAllPieces != null)
		//	{
		//		AskToRevealAllPieces();
		//	}
		//}

		public void Reset_MouseClick(object sender, RoutedEventArgs e)
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
	}

	public class brushes
	{
		public SolidColorBrush darkSlateGray = new SolidColorBrush(Colors.DarkSlateGray);
		public SolidColorBrush red = new SolidColorBrush(Colors.Red);
		public SolidColorBrush white = new SolidColorBrush(Colors.White);
		public SolidColorBrush green = new SolidColorBrush(Colors.Green);
		public SolidColorBrush gray = new SolidColorBrush(Colors.Gray);
		public SolidColorBrush blue = new SolidColorBrush(Colors.Blue);
		public SolidColorBrush LightCoral = new SolidColorBrush(Colors.LightCoral);
		public SolidColorBrush LightGray = new SolidColorBrush(Colors.LightGray);
	}
}