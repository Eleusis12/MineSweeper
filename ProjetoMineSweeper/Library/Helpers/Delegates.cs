using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library;
using Library.Model;

namespace Library.Helpers
{
	public delegate void UITaskFinishedHandler();

	public delegate void NotificationTaskHandler();

	public delegate void DifficultyChangedHandler(Dificuldade _dificuldade);

	public delegate void PointExtractorHandler(Point ponto);

	public delegate void AccountCredentialsExtractionHandler(string username, string password);

	public delegate void UsernameExtractionHandler(string username);

	public delegate void UserExtractionHandler(User temp);

	public delegate void DifficultyExtractionHandler(Dificuldade dificuldade);

	public delegate void TimeExtractionHandler(int tempo);
}