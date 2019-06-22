using PdfGenerator.Printable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PdfGenerator
{
	class PrintablesProvider
	{
		public Printables Get(string printingFilePath)
		{
			var result = new Printables();
			var printables = TypeExtensions.GetDerivedTypesOf<IPrintable>();
			if (File.Exists(printingFilePath))
			{
				var xmlStr = File.ReadAllText(printingFilePath);
				var doc = XElement.Parse(xmlStr);

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
			}
			else
			{
				MessageBox.Show($"Cannot find printing rules file: {printingFilePath}{Environment.NewLine}You can create one with the Print Page Editor", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			return result;
		}
	}
}
