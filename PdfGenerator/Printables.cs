using PdfGenerator.Printable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PdfGenerator
{
	public class Printables : List<IPrintable>
	{
		public void DrawOnGraphics(Graphics graphics)
		{
			foreach (var printable in this)
			{
				printable.DrawOnGraphics(graphics);
			}
		}

		public void ReplaceMultilinePdfTexts(Dictionary<string, string> replaceables)
        {
			foreach (var replaceable in replaceables)
			{
				int itemY = 0;
				PdfText newPdfText = null;
				int itemIndex = -1;
				var newItems = new List<PdfText>();

				foreach (var item in this)
				{
					if (item is PdfText pdfText && pdfText.Text == replaceable.Key)
					{
						itemY = item.Y;
						itemIndex = IndexOf(item);
						var lines = replaceable.Value.Split(new[] { "\r\n" }, StringSplitOptions.None);

						for (int i = 0; i < lines.Length; i++)
						{
							var line = lines[i];
							var location = pdfText.Location;
							location.Y += (int)Math.Ceiling(i * pdfText.Font.Size * 1.9) + (i == 0 ? 0 : 5);
							newPdfText = new PdfText(line, location, pdfText.Brush.Color, pdfText.Font);
							newItems.Add(newPdfText);
                        }
					}
					else
					{
						if (newPdfText != null && !item.IsFixedLocation)
						{
							item.Y = newPdfText.Y + (item.Y - itemY);
							if (item is PdfLine pdfLine)
                            {
								pdfLine.EndY = item.Y;
                            }
						}
					}
				}
				if (itemIndex != -1)
                {
					RemoveAt(itemIndex);
                    foreach (var item in newItems)
                    {
						Insert(++itemIndex, item);
					}
				}
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
			if (File.Exists(printingRulesFilePath))
			{
				var xmlContent = File.ReadAllText(printingRulesFilePath);
				return LoadFromXmlText(xmlContent);
			}
			else
			{
				MessageBox.Show($"Cannot find printing rules file: {printingRulesFilePath}{Environment.NewLine}You can create one with the Print Page Editor", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			return new Printables();
		}

		public static Printables LoadFromXmlText(string xmlContent)
		{
			var result = new Printables();
			var printables = TypeExtensions.GetDerivedTypesOf<IPrintable>();
			var doc = XElement.Parse(xmlContent);

			foreach (XElement childNode in doc.Elements())
			{
				try
				{
					var attributes = new Dictionary<string, string>();
					foreach (XAttribute attribute in childNode.Attributes())
					{
						attributes.Add(attribute.Name.LocalName, attribute.Value);
					}

					var printable = printables.FirstOrDefault(p => childNode.Name == p.Name.Replace("Pdf", "Print"));
					var createdObject = Activator.CreateInstance(printable, attributes) as IPrintable;
					result.Add(createdObject);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
			}
			return result;
		}
	}
}
