using Library.Helpers;
using Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static MineSweeperProjeto.Program;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		/// <summary>
		/// Pede para registar resultado num ficheiro xml se as condições forem positivas
		/// </summary>
		/// <param name="username">Nome Introduzido pelo utilizador</param>
		private void V_vencedor_SendUsername(string username)
		{
			string pathFile = GetPathFile(Program.M_Grelha._Dificuldade);

			// O ficheiro está vazio
			if (File.Exists(pathFile) == false)
			{
				XDocument doc = CreateXmlFile(username);

				doc.Save(pathFile);
			}
			else
			{
				UpdateXMLFile(username, pathFile);
			}
		}

		/// <summary>
		/// Cria formato do ficheiro XML
		/// </summary>
		/// <param name="username">Nome Introduzido pelo utilizador</param>
		/// <returns></returns>
		private XDocument CreateXmlFile(string username)
		{
			return new XDocument(
											new XElement("resultado_jogo",
									new XElement("Username", username),

									new XElement("Nivel", M_Grelha._Dificuldade.ToString()),

									new XElement("Tempo", M_Grelha.TimerCounter)
								)
							);
		}

		/// <summary>
		/// Atualiza ficheiro xml quando este já existe
		/// </summary>
		/// <param name="username">Nome Introduzido pelo utilizador</param>
		/// <param name="pathFile">Caminho do ficheiro</param>
		private void UpdateXMLFile(string username, string pathFile)
		{
			XDocument doc = XDocument.Load(pathFile);

			if (M_Grelha.TimerCounter < Convert.ToInt32(doc.Element("resultado_jogo").Element("Tempo").Value.ToString()))
			{
				doc.Element("resultado_jogo").Element("Username").Value = username;
				doc.Element("resultado_jogo").Element("Nivel").Value = M_Grelha._Dificuldade.ToString();
				doc.Element("resultado_jogo").Element("Tempo").Value = M_Grelha.TimerCounter.ToString();
			}
			doc.Save(pathFile);
		}

		/// <summary>
		/// Faz o pedido ao server do top10
		/// e pede ao view para apresentar os dados
		/// </summary>
		private void V_StartForm_AskBestScoreData()
		{
			LoadBestScores();

			Program.V_StartForm.ShowBestScore();

			//Program.V_StartForm.UpdateBestScoreView();
		}

		/// <summary>
		/// Pede e guarda o top 1 offline no Model
		/// </summary>
		private void LoadBestScores()
		{
			BestScores scores = new BestScores();
			XDocument doc = new XDocument();

			string pathfile = GetPathFile(Dificuldade.Facil);
			if (pathfile != null)
			{
				doc = XDocument.Load(pathfile);
				Program.M_BestScores.EasyBestScore = GetBestScore(doc);
			}

			pathfile = GetPathFile(Dificuldade.Medio);
			if (pathfile != null)
			{
				doc = XDocument.Load(pathfile);
				Program.M_BestScores.MediumBestScore = GetBestScore(doc);
			}

			pathfile = GetPathFile(Dificuldade.Dificil);
			if (pathfile != null)
			{
				doc = XDocument.Load(pathfile);
				Program.M_BestScores.HardBestScore = GetBestScore(doc);
			}
		}

		/// <summary>
		/// Faz tratamento do ficheiro xml para obter melhor score
		/// </summary>
		/// <param name="doc"></param>
		/// <returns></returns>
		private static Entry GetBestScore(XDocument doc)
		{
			return new Entry()
			{
				Username = doc.Element("resultado_jogo").Element("Username").Value,
				Nivel = doc.Element("resultado_jogo").Element("Nivel").Value,
				Tempo = doc.Element("resultado_jogo").Element("Tempo").Value,
			};
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="dificuldade"></param>
		/// <returns>Caminho do ficheiro que depende da dificuldade</returns>
		private string GetPathFile(Dificuldade dificuldade)
		{
			string pathFile = string.Empty;
			if (Program.M_Options.ModoJogo == GameMode.Normal)
			{
				if (dificuldade == Dificuldade.Facil)
				{
					pathFile = "BestTimeEasyMode.xml";
				}
				else if (dificuldade == Dificuldade.Medio)
				{
					pathFile = "BestTimeMediumMode.xml";
				}
				else if (dificuldade == Dificuldade.Dificil)
				{
					pathFile = "BestTimeHardMode.xml";
				}
			}
			else
			{
				pathFile = "BestTimeReverseMode.xml";
			}

			if (File.Exists(pathFile) == false)
			{
				return null;
			}
			return pathFile;
		}
	}
}