using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeperUWP.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MineSweeper : Page
	{
		private Size Tamanho;
		private List<Button> listaBotoes;

		public MineSweeper()
		{
			Tamanho.Height = 9;
			Tamanho.Width = 9;
			//GenerateGrid();
			this.InitializeComponent();
			//IniciaComponentes();
		}

		//private void GenerateGrid()
		//{
		//	StackPanel brickStackPanel = new StackPanel();
		//	brickStackPanel.BorderThickness = new Thickness(1, 1, 1, 1);
		//	brickStackPanel.BorderBrush = new SolidColorBrush(Colors.Gray);

		//	for (int bx = 0; bx < 8; bx++)
		//	{
		//		StackPanel rowStackPanel = new StackPanel();
		//		rowStackPanel.Orientation = Orientation.Horizontal;
		//		for (int by = 0; by < 12; by++)
		//		{
		//			Ellipse pixel = new Ellipse();
		//			pixel.Fill = new SolidColorBrush(Colors.Gray);
		//			pixel.Height = 4;
		//			pixel.Width = 4;
		//			//pixel.Stroke = new SolidColorBrush(Colors.Black);
		//			rowStackPanel.Children.Add(pixel);

		//			Rectangle pixel1 = new Rectangle();
		//			pixel1.Fill = new SolidColorBrush(Colors.White);
		//			pixel1.Height = 1;
		//			pixel1.Width = 1;
		//			rowStackPanel.Children.Add(pixel1);
		//		}
		//		brickStackPanel.Children.Add(rowStackPanel);
		//	}
		//}

		//private void IniciaComponentes()
		//{
		//	// Determinar o valor do lado de cada quadrado (provavelmente não vai funcionar)
		//	//int larguraLado = (int)(FLPPainelBotoes.Height / Tamanho.Height);
		//	//int comprimentoLado = (int)((FLPPainelBotoes.Width) / Tamanho.Width);

		//	for (int i = 0; i < Tamanho.Height; i++)
		//	{
		//		for (int j = 0; j < Tamanho.Width; j++)
		//		{
		//			// TODO: Mudar caracteristicas do botão
		//			// Caracteristicas de cada botão

		//			Button button = new Button();
		//			button.Height = comprimentoLado;
		//			button.Width = larguraLado;
		//			//button.Size = new Size(comprimentoLado, larguraLado);
		//			//button.Location = new Point(localizacao.X + comprimentoLado * i, localizacao.Y + larguraLado * j);
		//			button.Click += Button_Click;
		//			button.Name = string.Format($"{i}-{j}");
		//			//button.FlatStyle = FlatStyle.Popup;
		//			//button.BackColor = Color.Transparent;
		//			//button.Margin = new Padding(0);
		//			//button.Padding = new Padding(0);
		//			// Tag é meio que inútil neste caso , eliminar quando estiver na fase de revisão de código.
		//			button.Tag = i.ToString() + "," + j.ToString();

		//			//button.BackgroundImageLayout = ImageLayout.Stretch;
		//			//button.FlatAppearance.BorderSize = 0;
		//			//button.TabStop = false;

		//			//button.Show();
		//			//button.BringToFront();

		//			//FLPPainelBotoes.Controls.Add(button);
		//			listaBotoes.Add(button);
		//		}
		//	}
		//	FLPPainelBotoes.SendToBack();
		//}
	}
}