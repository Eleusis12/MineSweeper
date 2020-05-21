using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperProjeto.Model
{
	// Class Simples que permite guardar informações sobre o Vencedor
	internal class User
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }

		public Image Photo { get; set; }
		public string Country { get; set; }

		public User()
		{
		}

		public User(string Username, string Password)
		{
			this.Username = Username;
			this.Password = Password;
		}

		public User(string Firstname, string Surname, string Email, Image Photo, string Country)
		{
			this.Firstname = Firstname;
			this.Surname = Surname;
			this.Email = Email;
			this.Photo = Photo;
			this.Country = Country;
		}
	}
}