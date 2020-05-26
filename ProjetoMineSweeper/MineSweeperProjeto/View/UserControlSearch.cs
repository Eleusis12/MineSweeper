using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeperProjeto.Helpers;

namespace MineSweeperProjeto.View
{
	public partial class UserControlSearch : UserControl
	{
		public event UsernameExtractionHandler AskUserData;

		public UserControlSearch()
		{
			InitializeComponent();
		}

		private void TBSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (groupBox1.Visible == false)
				{
					groupBox1.Visible = true;
				}

				if (AskUserData != null)
				{
					AskUserData(TBSearch.Text);
				}
			}
		}
	}
}