using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MineSweeperProjeto.Program;
using Library;

namespace MineSweeperProjeto.Helpers
{
	public delegate void UITaskFinishedHandler();

	public delegate void NotificationTaskHandler();

	public delegate void DifficultyChangedHandler(Dificuldade _dificuldade);

	public delegate void PointExtractorHandler(Point ponto);
}