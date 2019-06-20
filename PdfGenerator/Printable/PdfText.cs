using System;
using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
	class PdfText : IPrintable
	{
		public string Text { get; set; }

		public Point Location { get; private set; }

		public Color Color { get; private set; }

		public string FontName { get; private set; }

		public float FontSize { get; private set; }

		public Font Font
		{
			get
			{
				var fontFamily = new FontFamily(FontName);
				return new Font(fontFamily, FontSize);
			}
		}

		public Brush Brush
		{
			get
			{
				return new SolidBrush(Color);
			}
		}

		public PdfText(string text, int x, int y) : this(text, new Point(x, y), Color.Black) { }

		public PdfText(string text, int x, int y, Color color, string fontName = "Arial", float fontSize = 16) : this(text, new Point(x, y), color, fontName, fontSize) { }

		public PdfText(string text, Point location) : this(text, location, Color.Black) { }

		public PdfText(string text, Point location, Color color, string fontName = "Arial", float fontSize = 16)
		{
			Text = text;
			Location = location;
			Color = color;
			FontName = fontName;
			FontSize = fontSize;
		}

		public static PdfText Create(Dictionary<string, string> attributes)
		{
			if (attributes.ContainsKey(StrColor))
			{
				if (attributes.ContainsKey(StrFontName) && (attributes.ContainsKey(StrFontSize)))
				{
					return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Color.FromName(attributes[StrColor]), attributes[StrFontName], Convert.ToSingle(attributes[StrFontSize]));
				}
				else if (attributes.ContainsKey(StrFontName))
				{
					return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Color.FromName(attributes[StrColor]), attributes[StrFontName]);
				}
				else if (attributes.ContainsKey(StrFontSize))
				{
					return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Color.FromName(attributes[StrColor]), fontSize: Convert.ToSingle(attributes[StrFontSize]));
				}
				return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Color.FromName(attributes[StrColor]));
			}
			else
			{
				if (attributes.ContainsKey(StrFontName) && (attributes.ContainsKey(StrFontSize)))
				{
					return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Color.Black, attributes[StrFontName], Convert.ToSingle(attributes[StrFontSize]));
				}
				else if (attributes.ContainsKey(StrFontName))
				{
					return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Color.Black, attributes[StrFontName]);
				}
				else if (attributes.ContainsKey(StrFontSize))
				{
					return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Color.Black, fontSize: Convert.ToSingle(attributes[StrFontSize]));
				}
				return new PdfText(attributes[StrText], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]));
			}
		}
	}
}
