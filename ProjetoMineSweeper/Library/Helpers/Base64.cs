using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library.Helpers
{
	public static class Base64
	{
		public static System.Drawing.Image Base64ToImage(string base64String)
		{
			// Convert base 64 string to byte[]

			try
			{
				byte[] imageBytes = Convert.FromBase64String(base64String);
				// Convert byte[] to Image
				using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
				{
					System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
					return image;
				}
			}
			catch (FormatException)
			{
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static string ImageToBase64(System.Drawing.Image file)
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					file.Save(memoryStream, file.RawFormat);
					byte[] imageBytes = memoryStream.ToArray();
					return Convert.ToBase64String(imageBytes);
				}
			}
			catch (NullReferenceException ex)
			{
				return string.Empty;
			}
		}
	}
}