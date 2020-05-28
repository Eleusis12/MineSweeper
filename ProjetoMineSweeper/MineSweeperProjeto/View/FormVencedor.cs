using Library.Helpers;
using System.Linq;
using System.Windows.Forms;

namespace MineSweeperProjeto.View
{
	public partial class FormVencedor : Form
	{
		public event UsernameExtractionHandler SendUsername;

		public FormVencedor()
		{
			InitializeComponent();
		}

		private void TBNomeVencedor_KeyPress(object sender, KeyPressEventArgs e)
		{
			//We only want to allow numeric style chars
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
				(e.KeyChar != '.'))
			{
				if ((sender as TextBox).Text.Count() >= 12)
					e.Handled = true;
			}
		}

		private void TBNomeVencedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BTSubmeter.PerformClick();
			}
		}

		private void BTSubmeter_Click(object sender, System.EventArgs e)
		{
			if (SendUsername != null)
			{
				SendUsername(TBNomeVencedor.Text);
			}
			this.Close();
		}
	}
}