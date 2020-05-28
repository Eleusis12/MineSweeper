using Library.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static MineSweeperProjeto.Program;

namespace MineSweeperProjeto.Controller
{
	public partial class GameController
	{
		private void V_vencedor_SendUsername(string username)
		{
			string pathFile = string.Empty;
			if (M_Grelha.dificuldade == Dificuldade.Facil)
			{
				pathFile = "BestTimeEasyMode.xml";
			}
			else if (M_Grelha.dificuldade == Dificuldade.Medio)
			{
				pathFile = "BestTimeMediumMode.xml";
			}
			else
			{
				pathFile = "BestTimeHardMode.xml";
			}

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

		private static XDocument CreateXmlFile(string username)
		{
			return new XDocument(
											new XElement("resultado_jogo",
									new XElement("Username", username),

									new XElement("Nivel", M_Grelha.dificuldade.ToString()),

									new XElement("Tempo", M_Grelha.timerCounter)
								)
							);
		}

		private static void UpdateXMLFile(string username, string pathFile)
		{
			XDocument doc = XDocument.Load(pathFile);

			if (M_Grelha.timerCounter < Convert.ToInt32(doc.Element("resultado_jogo").Element("Tempo").Value.ToString()))
			{
				doc.Element("resultado_jogo").Element("Username").Value = username;
				doc.Element("resultado_jogo").Element("Nivel").Value = M_Grelha.dificuldade.ToString();
				doc.Element("resultado_jogo").Element("Tempo").Value = M_Grelha.timerCounter.ToString();
			}
			doc.Save(pathFile);
		}
	}
}