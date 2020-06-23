using Library.Helpers;
using Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MineSweeperUWP.Controller
{
	public partial class GameController
	{
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

		private XDocument CreateXmlFile(string username)
		{
			return new XDocument(
											new XElement("resultado_jogo",
									new XElement("Username", username),

									new XElement("Nivel", Program.M_Grelha._Dificuldade.ToString()),

									new XElement("Tempo", Program.M_Grelha.TimerCounter)
								)
							);
		}

		private void UpdateXMLFile(string username, string pathFile)
		{
			XDocument doc = XDocument.Load(pathFile);

			if (Program.M_Grelha.TimerCounter < Convert.ToInt32(doc.Element("resultado_jogo").Element("Tempo").Value.ToString()))
			{
				doc.Element("resultado_jogo").Element("Username").Value = username;
				doc.Element("resultado_jogo").Element("Nivel").Value = Program.M_Grelha._Dificuldade.ToString();
				doc.Element("resultado_jogo").Element("Tempo").Value = Program.M_Grelha.TimerCounter.ToString();
			}
			doc.Save(pathFile);
		}

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

		private static Entry GetBestScore(XDocument doc)
		{
			return new Entry()
			{
				Username = doc.Element("resultado_jogo").Element("Username").Value,
				Nivel = doc.Element("resultado_jogo").Element("Nivel").Value,
				Tempo = doc.Element("resultado_jogo").Element("Tempo").Value,
			};
		}

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