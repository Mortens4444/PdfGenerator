using PdfGenerator.Printable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PdfGenerator
{
	public class Printables : List<IPrintable>
	{
		private static readonly PrintablesProvider printablesProvider = new PrintablesProvider();

		public void DrawOnGraphics(Graphics graphics)
		{
			foreach (var printable in this)
			{
				printable.DrawOnGraphics(graphics);
			}
		}

		public string GetFileContent()
		{
			var fileContent = new StringBuilder($"<?xml version=\"1.0\" encoding=\"utf-8\" ?>{Environment.NewLine}<Printings>{Environment.NewLine}");
			foreach (var printable in this)
			{
				fileContent.AppendLine($"\t{printable.ToString()}");
			}
			fileContent.AppendLine("</Printings>");
			return fileContent.ToString();
		}

		public static Printables LoadFromFiles(string printingRulesFilePath)
		{
			return printablesProvider.GetFromFile(printingRulesFilePath);
		}

		public static Printables LoadFromXmlText(string xmlContent)
		{
			return printablesProvider.GetFromXmlText(xmlContent);
		}
	}
}
