using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PdfGenerator.Printable
{
	public class PdfText : IPrintable
	{
		public string Text { get; set; }

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

		public PdfText(string text, int x, int y, Color color, string fontName = "Arial", float fontSize = 12) : this(text, new Point(x, y), color, fontName, fontSize) { }

		public PdfText(string text, Point location) : this(text, location, Color.Black) { }

		public PdfText(string text, Point location, Color color, string fontName = "Arial", float fontSize = 12)
		{
			Text = text;
			Location = location;
			Color = color;
			FontName = fontName;
			FontSize = fontSize;
		}

		public PdfText(Dictionary<string, string> attributes)
		{
			Location = new Point(Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]));
			Color = attributes.ContainsKey(StrColor) ? Color.FromName(attributes[StrColor]) : Color.Black;
			Text = attributes[StrText];
			FontName = attributes.ContainsKey(StrFontName) ? attributes[StrFontName] : "Arial";
			FontSize = attributes.ContainsKey(StrFontSize) ? Convert.ToSingle(attributes[StrFontSize]) : 12;
		}

		public override void DrawOnGraphics(Graphics graphics)
		{
			graphics.DrawString(Text, Font, Brush, Location);
		}

		public override string ToString()
		{
			return $"<PrintText {StrText}=\"{Text}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrFontName}=\"{Font.FontFamily.Name}\" {StrFontSize}=\"{FontSize}\" {StrColor}=\"{Color.Name}\" />";
		}

		public override ListViewItem ToListViewItem()
		{
			var result = base.ToListViewItem();
			result.SubItems.Add(String.Empty);
			result.SubItems.Add(String.Empty);
			result.SubItems.Add(Text);
			return result;
		}
	}
}
