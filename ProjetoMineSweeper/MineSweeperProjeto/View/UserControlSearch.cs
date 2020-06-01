using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Helpers;

namespace MineSweeperProjeto.View
{
	public partial class UserControlSearch : UserControl
	{
		public event UsernameExtractionHandler AskUserData;

		public UserControlSearch()
		{
			InitializeComponent();
		}

		public GroupBox GroupBoxDados
		{
			get { return groupBox1; }
			set { groupBox1 = value; }
		}

		public PictureBox PictureBoxProfilePic
		{
			get { return PBProfilePic; }
			set { PBProfilePic = value; }
		}

		private void TBSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (groupBox1.Visible == false)
				{
					groupBox1.Visible = true;
					PBProfilePic.Visible = true;
				}

				if (AskUserData != null)
				{
					AskUserData(TBSearch.Text);
				}
			}
		}
	}
}