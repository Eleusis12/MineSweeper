﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Library.Helpers;
using Library.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Library.ServerEndpoint
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
				xmlPedido.Element("registo").Element("nomeabreviado").Value = novoUtilizador.Firstname + " " + novoUtilizador.LastName;
				xmlPedido.Element("registo").Element("username").Value = novoUtilizador.Username;
				xmlPedido.Element("registo").Element("password").Value = novoUtilizador.Password;
				xmlPedido.Element("registo").Element("email").Value = novoUtilizador.Email;
				//xmlPedido.Element("registo").Element("fotografia").Value = novoUtilizador.Perfil;

				if (novoUtilizador.PerfilBase64 != string.Empty)
				{
					xmlPedido.Element("registo").Element("fotografia").Value = novoUtilizador.PerfilBase64;
				}
				else
				{
					xmlPedido.Element("registo").Element("fotografia").Value = Base64.ImageToBase64(novoUtilizador.Perfil);
				}

				xmlPedido.Element("registo").Element("pais").Value = novoUtilizador.Country;

				XDocument xmlResposta = PostService(xmlPedido, EndPoint.PostRegisto, new string[] { });
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
					return "Erro";
				}
				else
				{
					return "OK";
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public static bool Login(string username, string password, out string id)
		{
			bool Logado = false;

			try
			{
				// prepara os dados do pedido a partir de uma string só com a estrutura do XML (sem dados)
				XDocument xmlPedido = XDocument.Parse("<credenciais><username></username><password></password></credenciais>");
				//preenche os dados no XML
				xmlPedido.Element("credenciais").Element("username").Value = username; // colocar aqui o username do utilizador
				xmlPedido.Element("credenciais").Element("password").Value = password; // colocar aqui a palavra passe do utilizador

				XDocument xmlResposta = PostService(xmlPedido, EndPoint.PostLogin, new string[] { });
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
					id = "null";
					Logado = false;
				}
				else
				{
					// Autenticação efetuada com sucesso
					Logado = true;
					id = xmlResposta.Element("resultado").Element("objeto").Element("ID").Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Logado;
		}

		public static List<Point> NovoJogo(string nivel, string id)
		{
			try
			{
				XDocument xmlResposta = GetService(EndPoint.GetNovoJogo, new string[] { nivel, id });

				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error 29.    );

					return null;
				}
				else
				{
					//string[][] PosicoesFacil = new string[8][];
					//string[][] PosicoesMedio = new string[16][];
					//IEnumerable<XElement> Nodes;
					//if ((Nodes = xmlResposta.Descendants("campo").Where(e => ((string)e.Attribute("nivel")) == "facil")) != null)
					//{
					//	foreach (var posicao in Nodes)
					//	{
					//		PosicoesFacil[Convert.ToInt32(posicao.Element("posicao").Attribute("linha").Value)][Convert.ToInt32(posicao.Element("posicao").Attribute("coluna").Value)] = "mina";
					//	}
					//	return PosicoesFacil;
					//}
					//else if ((Nodes = xmlResposta.Descendants("campo").Where(e => ((string)e.Attribute("nivel")) == "medio")) != null)
					//{
					//	foreach (var posicao in Nodes)
					//	{
					//		string[][] Posicoes = new string[16][];
					//		PosicoesMedio[Convert.ToInt32(posicao.Element("posicao").Attribute("linha").Value)][Convert.ToInt32(posicao.Element("posicao").Attribute("coluna").Value)] = "mina";
					//	}
					//	return PosicoesMedio;
					//}
					//else
					//{
					//	return null;
					//}
					List<Point> indexMinas = new List<Point>();

					IEnumerable<XElement> minas = xmlResposta
						.Descendants("campo")
						.Where(g => g.Attribute("nivel").Value == nivel)
						.Elements("posicao")
						.Where(s => s.Value == "-1");  // or Attribute("ID") == "A"

					foreach (XElement element in minas)
					{
						int x = 0;
						int y = 0;
						x = Convert.ToInt32(element.Attribute("linha").Value);
						y = Convert.ToInt32(element.Attribute("coluna").Value);

						Point ponto = new Point(x, y);
						indexMinas.Add(ponto);
					}

					return indexMinas;
					//for()
					//	xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("fotografia").Value

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
		}

		public static string RegistarResultado(string dificuldade, string tempo, string vitoria, string id)
		{
			try
			{
				XDocument xmlPedido = XDocument.Parse("<resultado_jogo><nivel></nivel><tempo></tempo><vitoria></vitoria></resultado_jogo>");
				xmlPedido.Element("resultado_jogo").Element("nivel").Value = dificuldade;
				xmlPedido.Element("resultado_jogo").Element("tempo").Value = tempo;
				xmlPedido.Element("resultado_jogo").Element("vitoria").Value = vitoria;

				XDocument xmlResposta = PostService(xmlPedido, EndPoint.PostRegistoResultado, new string[] { id });
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

		public static string ConsultaPerfil(string username, out User consultado)
		{
			consultado = new User();

			try
			{
				XDocument xmlResposta = GetService(EndPoint.GetPerfil, new string[] { username });
				// ...interpretar o resultado de acordo com a lógica da aplicação (exemplificativo)
				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					consultado = null;

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
					string nomeAbreviado = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("nomeabreviado"));

					string email = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("email"));

					string pais = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("pais"));

					string jogosGanhos = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("jogos").Element("ganhos"));

					string jogosPerdidos = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("jogos").Element("perdidos"));

					string bestTimeEasy = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("tempos").Element("Facil"));

					string bestTimeMedium = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("tempos").Element("Medio"));

					string base64Imagem = GetValueFromElement(xmlResposta.Element("resultado").Element("objeto").Element("perfil").Element("fotografia"));

					consultado.Username = nomeAbreviado;
					consultado.Email = (email);
					consultado.Country = pais;
					consultado.WinStats = Convert.ToInt32(jogosGanhos);
					consultado.LoseStats = Convert.ToInt32(jogosPerdidos);
					consultado.BestTimeEasy = bestTimeEasy;
					consultado.BestTimeMedium = bestTimeMedium;

					if (base64Imagem != string.Empty)
					{
						consultado.PerfilBase64 = base64Imagem;
						consultado.Perfil = Base64.Base64ToImage(base64Imagem);
					}

					//if (base64Imagem != string.Empty)
					//{
					//	string base64 = base64Imagem.Split(',')[1]; // retira a parte da string correspondente aos bytes da imagem..
					//	byte[] bytes = Convert.FromBase64String(base64); //...converte para array de bytes...
					//	System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(bytes));
					//	consultado.Perfil = image;
					//}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return "OK";
		}

		public static string GetValueFromElement(XElement element)
		{
			if (element != null)
			{
				return element.Value;
			}
			return string.Empty;
		}

		public static List<Top10Resultado> ConsultaTop10()
		{
			try
			{
				XDocument xmlResposta = GetService(EndPoint.GetTop10, new string[] { });

				if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
				{
					//// apresenta mensagem de erro usando o texto (contexto) da resposta
					//MessageBox.Show(
					//xmlResposta.Element("resultado").Element("contexto").Value,
					//"Erro",
					//MessageBoxButtons.OK,
					//MessageBoxIcon.Error 29.    );

					return null;
				}
				else
				{
					//IEnumerable<XElement> NodesEasyMode = xmlResposta.Descendants("nivel").Where(e => ((string)e.Attribute("dificuldade")) == "facil");
					//IEnumerable<XElement> NodesMediumMode = xmlResposta.Descendants("nivel").Where(e => ((string)e.Attribute("dificuldade")) == "medio");

					List<Top10Resultado> TOP10 = new List<Top10Resultado>();
					AddToList(TOP10, xmlResposta);

					return TOP10;

					//string Nome = xmlResposta.Root.Element("jogador").Attribute("username").Value;
					//string Tempo = xmlResposta.Root.Element("jogador").Attribute("tempo").Value;
					//string Quando = xmlResposta.Root.Element("jogador").Attribute("quando").Value;

					//string Jogador = xmlResposta.Element("resultado").Element("objeto").Element("top").Element("nivel dificuldade").Value;

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
		}

		private static void AddToList(List<Top10Resultado> TOP10, XDocument xmlResposta)
		{
			foreach (XElement element in xmlResposta.Descendants("nivel"))
			{
				string dificuldade = element.Attribute("dificuldade").Value.ToString();

				foreach (XElement element1 in element.Descendants("jogador"))
				{
					Top10Resultado temp = new Top10Resultado();

					temp.Nome = element1.Attribute("username").Value;
					temp.Tempo = element1.Attribute("tempo").Value;
					temp.Quando = element1.Attribute("quando").Value;
					temp.dificuldade = dificuldade.ToString();

					TOP10.Add(temp);
				}
			}
		}

		private static XDocument GetService(string endpoint, string[] parametros)
		{
			//Prepara o pedido ao servidor com o URL adequado

			string requestUriString = EndPoint.BaseUrl + endpoint;
			foreach (var parametro in parametros)
			{
				requestUriString += '/';
				requestUriString += parametro;
			}
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
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

		private static XDocument PostService(XDocument xmlPedido, string endpoint, string[] parametros)
		{
			string requestUriString = EndPoint.BaseUrl + endpoint;
			foreach (var parametro in parametros)
			{
				requestUriString += '/';
				requestUriString += parametro;
			}
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);

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