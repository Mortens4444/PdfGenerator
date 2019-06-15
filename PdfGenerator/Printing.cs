using PdfGenerator.Printable;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace PdfGenerator
{
	class Printing : IConfigurationSectionHandler
	{
		private const string ImageFilename = "image_filename";
		private const string X = "x";
		private const string Y = "y";
		private const string Width = "width";
		private const string Height = "height";
		private const string Colour = "color";
		private const string FontName = "font_name";
		private const string FontSize = "font_size";
		private const string Text = "text";

		public object Create(object parent, object configContext, XmlNode section)
		{
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

					switch (childNode.Name)
					{
						case "PrintImage":
							PrintImage printImage = null;
							if (attributes.ContainsKey(X) && attributes.ContainsKey(Y))
							{
								if (attributes.ContainsKey(Width) && attributes.ContainsKey(Height))
								{
									printImage = new PrintImage(attributes[ImageFilename], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Convert.ToInt32(attributes[Width]), Convert.ToInt32(attributes[Height]));
								}
								else
								{
									printImage = new PrintImage(attributes[ImageFilename], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]));
								}
							}
							else
							{
								printImage = new PrintImage(attributes[ImageFilename]);
							}
							result.Add(printImage);
							break;

						case "PrintText":
							PrintText printText;
							if (attributes.ContainsKey(Colour))
							{
								if (attributes.ContainsKey(FontName) && (attributes.ContainsKey(FontSize)))
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Color.FromName(attributes[Colour]), attributes[FontName], Convert.ToSingle(attributes[FontSize]));
								}
								else if (attributes.ContainsKey(FontName))
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Color.FromName(attributes[Colour]), attributes[FontName]);
								}
								else if (attributes.ContainsKey(FontSize))
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Color.FromName(attributes[Colour]), fontSize: Convert.ToSingle(attributes[FontSize]));
								}
								else
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Color.FromName(attributes[Colour]));
								}
							}
							else
							{
								if (attributes.ContainsKey(FontName) && (attributes.ContainsKey(FontSize)))
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Color.Black, attributes[FontName], Convert.ToSingle(attributes[FontSize]));
								}
								else if (attributes.ContainsKey(FontName))
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Color.Black, attributes[FontName]);
								}
								else if (attributes.ContainsKey(FontSize))
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]), Color.Black, fontSize: Convert.ToSingle(attributes[FontSize]));
								}
								else
								{
									printText = new PrintText(attributes[Text], Convert.ToInt32(attributes[X]), Convert.ToInt32(attributes[Y]));
								}
							}
							result.Add(printText);
							break;
					}
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
