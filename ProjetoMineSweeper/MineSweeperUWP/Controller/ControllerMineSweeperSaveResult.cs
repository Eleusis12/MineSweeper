using Library.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MineSweeperUWP.Controller
{
	public partial class ControllerMineSweeperGameCode
	{
		private void V_vencedor_SendUsername(string username)
		{
			string pathFile = string.Empty;
			if (Program.M_Grelha.dificuldade == Dificuldade.Facil)
			{
				pathFile = "BestTimeEasyMode.xml";
			}
			else if (Program.M_Grelha.dificuldade == Dificuldade.Medio)
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

		private XDocument CreateXmlFile(string username)
		{
			return new XDocument(
											new XElement("resultado_jogo",
									new XElement("Username", username),

									new XElement("Nivel", Program.M_Grelha.dificuldade.ToString()),

									new XElement("Tempo", Program.M_Grelha.timerCounter)
								)
							);
		}

		private void UpdateXMLFile(string username, string pathFile)
		{
			XDocument doc = XDocument.Load(pathFile);

			if (Program.M_Grelha.timerCounter < Convert.ToInt32(doc.Element("resultado_jogo").Element("Tempo").Value.ToString()))
			{
				doc.Element("resultado_jogo").Element("Username").Value = username;
				doc.Element("resultado_jogo").Element("Nivel").Value = Program.M_Grelha.dificuldade.ToString();
				doc.Element("resultado_jogo").Element("Tempo").Value = Program.M_Grelha.timerCounter.ToString();
			}
			doc.Save(pathFile);
		}
	}
}