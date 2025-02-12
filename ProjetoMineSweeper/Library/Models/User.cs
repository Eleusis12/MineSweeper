﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Library.Models
{
	// Class Simples que permite guardar informações sobre o Vencedor

	[Serializable]
	public class User
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Firstname { get; set; }
		public string LastName { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public System.Drawing.Image Perfil { get; set; }

		// Para o UWP
		public string PerfilBase64 { get; set; }

		public int WinStats { get; set; }
		public int LoseStats { get; set; }

		//public Image Photo { get; set; }
		public string Country { get; set; }

		public string BestTimeEasy { get; set; }
		public string BestTimeMedium { get; set; }

		public User()
		{
		}

		public User(string Username, string Password)
		{
			this.Username = Username;
			this.Password = Password;
		}

		//public User(string Firstname, string Surname, string Email, Image Photo, string Country)
		//{
		//	this.Firstname = Firstname;
		//	this.Surname = Surname;
		//	this.Email = Email;
		//	this.Photo = Photo;
		//	this.Country = Country;
		//}
	}
}