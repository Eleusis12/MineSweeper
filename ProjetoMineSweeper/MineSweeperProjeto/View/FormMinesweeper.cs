using MineSweeperProjeto.Model;
using MineSweeperProjeto.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using static MineSweeperProjeto.Program;
using Library;
using Library.Helpers;
using Library.Interfaces;

namespace MineSweeperProjeto
{
	public partial class FormMinesweeper : Form, MineSweeperView
	{
		public event NotificationTaskHandler AskToRevealAllPieces;

		public event NotificationTaskHandler AskToResetBoard;

		public event MouseEventHandler ButtonPressed;

		private Size Tamanho;
		private Dificuldade dificuldade { get; set; }

		// Varíavel que vai guardar Botoes
		private List<Button> listaBotoes;

		public FormMinesweeper()
		{
			listaBotoes = new List<Button>();
			InitializeComponent();
		}

		public void ResetBoardView()
		{
			foreach (Button Botao in GetButtons())
			{
				ChangeButtonBackGround(Botao, Resources.unopened);
			}
		}

		/// <summary>
		///  Muda A imagem de fundo do botão para a Imagem Bitmap pretendida
		/// </summary>
		public void ChangeButtonBackGround(Button botaoAtual, Bitmap Imagem)
		{
			botaoAtual.BackgroundImage = Imagem;
			botaoAtual.BackgroundImageLayout = ImageLayout.Stretch;
		}

		public void AlteraDificuldadeNoView(Dificuldade _dificuldade)
		{
			this.dificuldade = M_Grelha.dificuldade;
			Tamanho = classDificuldade.GetTamanho(this.dificuldade);
			if (Tamanho.Width == 30 && Tamanho.Height == 16)
			{
				this.Size = new Size(new Point(635, 470));
				FLPPainelBotoes.Size = new Size(new Point(604, 324));
			}

			IniciaComponentes();
		}

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

		/// <summary>
		/// Gera os inúmeros botões
		/// </summary>
		public void IniciaComponentes()
		{
			// Determinar o valor do lado de cada quadrado (provavelmente não vai funcionar)
			int larguraLado = (FLPPainelBotoes.Size.Height) / Tamanho.Height;
			int comprimentoLado = (FLPPainelBotoes.Size.Width) / Tamanho.Width;
			var localizacao = FLPPainelBotoes.Location;

			for (int i = 0; i < Tamanho.Height; i++)
			{
				for (int j = 0; j < Tamanho.Width; j++)
				{
					// Caracteristicas de cada botão
					Button button = new Button();
					button.Size = new Size(comprimentoLado, larguraLado);
					button.Location = new Point(localizacao.X + comprimentoLado * i, localizacao.Y + larguraLado * j);
					button.MouseDown += new MouseEventHandler(ButtonMouseClick);
					button.Name = string.Format($"{i}-{j}");
					button.FlatStyle = FlatStyle.Popup;
					button.BackColor = Color.Transparent;
					button.Margin = new Padding(0);
					button.Padding = new Padding(0);
					// Tag é meio que inútil neste caso , eliminar quando estiver na fase de revisão de código.
					button.Tag = i.ToString() + "," + j.ToString();
					button.BackgroundImage = Resources.unopened;
					button.BackgroundImageLayout = ImageLayout.Stretch;
					button.FlatAppearance.BorderSize = 0;
					button.TabStop = false;

					button.Show();
					button.BringToFront();

					FLPPainelBotoes.Controls.Add(button);
					listaBotoes.Add(button);
				}
			}
			FLPPainelBotoes.SendToBack();
		}

		public void ButtonMouseClick(object sender, MouseEventArgs e)
		{
			if (ButtonPressed != null)
			{
				ButtonPressed((sender as Button), e);
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
		public void BTSmile_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, (sender as Button).ClientRectangle,
			SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
			SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
			SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
			SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset);
		}

		public void Cheater_MouseClick(object sender, MouseEventArgs e)
		{
			if (AskToRevealAllPieces != null)
			{
				AskToRevealAllPieces();
			}
		}

		public void Reset_MouseClick(object sender, MouseEventArgs e)
		{
			AskToResetBoard?.Invoke();
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

		// DEBUG: EVENTO FAZ CRASHAR APLICAÇÃO...
		public void FormMinesweeper_Load(object sender, EventArgs e)
		{
			////Create your public font collection object.
			//PrivateFontCollection pfc = new PrivateFontCollection();

			////Select your font from the resources.
			////My font here is ".ttf"
			//int fontLength = Properties.Resources.Seven_Segment.Length;

			//// create a buffer to read in to
			//byte[] fontdata = Properties.Resources.Seven_Segment;

			//// create an unsafe memory block for the font data
			//System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

			//// copy the bytes to the unsafe memory block
			//Marshal.Copy(fontdata, 0, data, fontLength);

			//// pass the font to the font collection
			//pfc.AddMemoryFont(data, fontLength);

			//this.LBLTimer.Font = new Font(pfc.Families[0], this.LBLTimer.Font.Size);
			//this.LBLMinas.Font = new Font(pfc.Families[0], this.LBLTimer.Font.Size);
		}

		public void BTSmile_Click(object sender, EventArgs e)
		{
			if (AskToResetBoard != null)
			{
				AskToResetBoard();
			}
		}
	}
}