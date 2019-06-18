using PdfGenerator.Printable;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace PdfGenerator
{
	class Printing : IConfigurationSectionHandler
	{
		public object Create(object parent, object configContext, XmlNode section)
		{
			var printables = TypeExtensions.GetDerivedTypesOf<IPrintable>();

			var result = new List<IPrintable>();
			foreach (XmlNode childNode in section.ChildNodes)
			{
				try
				{
					var attributes = new Dictionary<string, string>();
					foreach (XmlAttribute attribute in childNode.Attributes)
					{
						attributes.Add(attribute.Name, attribute.Value);
					}

					var printable = printables.FirstOrDefault(p => childNode.Name == p.Name.Replace("Pdf", "Print"));
					var createdObject = printable.GetMethod("Create").Invoke(null, new[] { attributes }) as IPrintable;
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
