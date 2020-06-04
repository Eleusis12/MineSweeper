using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Library.Helpers
{
	public enum Dificuldade { Facil, Medio, Dificil }

	public static class classDificuldade
	{
		public static Size GetTamanho(Dificuldade _dificuldade)
		{
			Size _tamanho = new Size();
			switch (_dificuldade)
			{
				case Dificuldade.Facil:
					_tamanho.Width = _tamanho.Height = 9;
					break;

				case Dificuldade.Medio:
					_tamanho.Width = _tamanho.Height = 16;
					break;

				case Dificuldade.Dificil:
					_tamanho.Width = 30;
					_tamanho.Height = 16;

					break;

				default:
					throw new ArgumentException("Dificuldade não implementada");
			}
			return _tamanho;
		}
	}
}