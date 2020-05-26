using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;
using MineSweeperProjeto.Model;
using static System.Net.Mime.MediaTypeNames;

namespace G12.MineSweep.Common.ServerEndPoint
{
	public static class Server
	{
		private class EndPoint
		{
			public static string BaseUrl => "https://prateleira.utad.priv:1234/LPDSW/2019-2020";
			public static string PostRegisto => "/registo";
			public static string PostLogin => "/autentica";
			public static string GetNovoJogo => "/novo";
			public static string PostRegistoResultado => "/resultado";
			public static string GetPerfil => "/perfil";
			public static string GetTop10 => "/top10";
		}

		public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		public static string RegistarUtilizador(User novoUtilizador)
		{
			try
			{
				XDocument xmlPedido = XDocument.Parse("<registo><nomeabreviado></nomeabreviado><username></username><password></password><email></email><fotografia></fotografia><pais></pais></registo>");
				xmlPedido.Element("registo").Element("nomeabreviado").Value = novoUtilizador.Firstname + novoUtilizador.LastName;
				xmlPedido.Element("registo").Element("username").Value = novoUtilizador.Username;
				xmlPedido.Element("registo").Element("password").Value = novoUtilizador.Password;
				xmlPedido.Element("registo").Element("email").Value = novoUtilizador.Email;
				//xmlPedido.Element("registo").Element("fotografia").Value = novoUtilizador.Perfil;
				xmlPedido.Element("registo").Element("fotografia").Value = "teste";
				xmlPedido.Element("registo").Element("pais").Value = novoUtilizador.Country;

				XDocument xmlResposta = PostService(xmlPedido, EndPoint.PostRegisto);
				// ...interpretar o resultado de acordo com a lógica da aplicação (exemplificativo)
				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error
					//);
				}
				else
				{
					// Autenticação efetuada com sucesso
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return "OK";
		}

		public static bool Login(string username, string password)
		{
			bool Logado = false;

			try
			{
				// prepara os dados do pedido a partir de uma string só com a estrutura do XML (sem dados)
				XDocument xmlPedido = XDocument.Parse("<credenciais><username></username><password></password></credenciais>");
				//preenche os dados no XML
				xmlPedido.Element("credenciais").Element("username").Value = username; // colocar aqui o username do utilizador
				xmlPedido.Element("credenciais").Element("password").Value = password; // colocar aqui a palavra passe do utilizador

				XDocument xmlResposta = PostService(xmlPedido, EndPoint.PostLogin);
				// ...interpretar o resultado de acordo com a lógica da aplicação (exemplificativo)
				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error
					//);
					Logado = false;
				}
				else
				{
					// Autenticação efetuada com sucesso
					Logado = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Logado;
		}

		public static string NovoJogo()
		{
			try
			{
				XDocument xmlResposta = GetService(EndPoint.GetNovoJogo);

				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error 29.    );

					return "ERROR";
				}
				else
				{
					// obtem todos os elementos do perfil do jogador...
					// ...como, por exemplo, a fotografia:

					//string base64Imagem = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("fotografia").Value;
					//string base64 = base64Imagem.Split(',')[1]; // retira a parte da string correspondente aos bytes da imagem..
					//byte[] bytes = Convert.FromBase64String(base64); //...converte para array de bytes...
					//Image image = Image.FromStream(new MemoryStream(bytes));//... e, por fim, para Image 40.
					//														// pode mostrar a imagem num qualquer componente...como por exemplo:
					//pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
					//pictureBox1.BackgroundImage = image;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return "OK";
		}

		public static string RegistarResultado(string dificuldade, string tempo, string vitoria)
		{
			try
			{
				XDocument xmlPedido = XDocument.Parse("<resultado_jogo><nivel></nivel><tempo></tempo><vitoria></vitoria></resultado_jogo>");
				xmlPedido.Element("resultado_jogo").Element("nivel").Value = dificuldade;
				xmlPedido.Element("resultado_jogo").Element("tempo").Value = tempo;
				xmlPedido.Element("resultado_jogo").Element("vitoria").Value = vitoria;

				XDocument xmlResposta = PostService(xmlPedido, EndPoint.PostRegisto);
				// ...interpretar o resultado de acordo com a lógica da aplicação (exemplificativo)
				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error
					//);
				}
				else
				{
					// Autenticação efetuada com sucesso
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return "OK";
		}

		public static string ConsultaPerfil(string username)
		{
			try
			{
				XDocument xmlResposta = GetService(EndPoint.GetPerfil);
				// ...interpretar o resultado de acordo com a lógica da aplicação (exemplificativo)
				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error 29.    );

					return "ERROR";
				}
				else
				{
					// obtem todos os elementos do perfil do jogador...
					// ...como, por exemplo, a fotografia:

					//string base64Imagem = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("fotografia").Value;
					//string base64 = base64Imagem.Split(',')[1]; // retira a parte da string correspondente aos bytes da imagem..
					//byte[] bytes = Convert.FromBase64String(base64); //...converte para array de bytes...
					//Image image = Image.FromStream(new MemoryStream(bytes));//... e, por fim, para Image 40.
					//														// pode mostrar a imagem num qualquer componente...como por exemplo:
					//pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
					//pictureBox1.BackgroundImage = image;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return "OK";
		}

		public static string ConsultaTop10(string username)
		{
			try
			{
				XDocument xmlResposta = GetService(EndPoint.GetTop10);

				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error 29.    );

					return "ERROR";
				}
				else
				{
					// obtem todos os elementos do perfil do jogador...
					// ...como, por exemplo, a fotografia:

					//string base64Imagem = xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("fotografia").Value;
					//string base64 = base64Imagem.Split(',')[1]; // retira a parte da string correspondente aos bytes da imagem..
					//byte[] bytes = Convert.FromBase64String(base64); //...converte para array de bytes...
					//Image image = Image.FromStream(new MemoryStream(bytes));//... e, por fim, para Image 40.
					//														// pode mostrar a imagem num qualquer componente...como por exemplo:
					//pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
					//pictureBox1.BackgroundImage = image;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return "OK";
		}

		private static XDocument GetService(string endpoint)
		{
			//Prepara o pedido ao servidor com o URL adequado
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020" + endpoint);

			// Com o acesso usa HTTPS e o servidor usar cerificados autoassinados, tempos de configurar o cliente para aceitar sempre o certificado.
			ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
			request.Method = "GET"; // método usado para enviar o pedido

			HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // faz o envio do pedido 10.
			Stream receiveStream = response.GetResponseStream(); // obtem o stream associado à resposta.
			StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); // Canaliza o stream para um leitor de stream de nível superior com o formato de codificação necessário.
			string resultado = readStream.ReadToEnd();
			response.Close();
			readStream.Close();

			// converte para objeto XML para facilitar a extração da informação e ...
			XDocument xmlResposta = XDocument.Parse(resultado);
			return xmlResposta;
		}

		private static XDocument PostService(XDocument xmlPedido, string endpoint)
		{
			//Prepara o pedido ao servidor com o URL adequado
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020" + endpoint);

			// Com o acesso usa HTTPS e o servidor usar cerificados autoassinados, temos de configurar o cliente para aceitar sempre o certificado.
			ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

			string mensagem = xmlPedido.Root.ToString();

			byte[] data = Encoding.Default.GetBytes(mensagem); // note: choose appropriate encoding
			request.Method = "POST";// método usado para enviar o pedido
			request.ContentType = "application/xml"; // tipo de dados que é enviado com o pedido
			request.ContentLength = data.Length; // comprimento dos dados enviado no pedido

			Stream newStream = request.GetRequestStream(); // obtem a referência do stream associado ao pedido...
			newStream.Write(data, 0, data.Length);// ... que permite escrever os dados a ser enviados ao servidor
			newStream.Close();

			HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // faz o envio do pedido
			Stream receiveStream = response.GetResponseStream(); // obtem o stream associado à resposta
			StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); // Canaliza o stream para um leitor de stream de nível superior com o formato de codificação necessário.
			string resultado = readStream.ReadToEnd();
			response.Close();
			readStream.Close();
			// converte para objeto XML para facilitar a extração da informação e ...
			XDocument xmlResposta = XDocument.Parse(resultado);
			return xmlResposta;
		}
	}
}