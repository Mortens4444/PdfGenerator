using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PdfGenerator.Printable
{
	public class PdfText : IPrintable
	{
		public Font Font { get; set; }

		public string Text { get; set; }

		public Color FontColor { get; private set; }

		public SolidBrush Brush
		{
			get
			{
				return new SolidBrush(FontColor);
			}
		}

        public PdfText(string text, Point location, Color fontColor)
            : this(text, location, fontColor, new Font("Arial", 12))
        { }

        public PdfText(string text, Point location, Color fontColor, Font font)
		{
			Text = text;
			Location = location;
			FontColor = fontColor;
			Font = font;
		}

        public PdfText(Dictionary<string, string> attributes)
        {
            Location = GetLocationFromAttributes(attributes);
            FontColor = GetColorFromAttributes(attributes);
            Text = attributes[StrText];
            var fontName = attributes.ContainsKey(StrFontName) ? attributes[StrFontName] : "Arial";
            var fontSize = attributes.ContainsKey(StrFontSize) ? Convert.ToSingle(attributes[StrFontSize]) : 12;
            var fontStyle = GetFontStyle(attributes);
            Font = new Font(fontName, fontSize, fontStyle);
			LastY += (int)Math.Ceiling(Font.Size * 1.9) + 5;
			IsFixedLocation = attributes.ContainsKey(StrFixedLocation);
		}

        public override void DrawOnGraphics(Graphics graphics)
		{
			graphics.DrawString(Text, Font, Brush, Location);
		}

		public override string ToString()
		{
			return $"<PrintText {StrText}=\"{Text}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrFontName}=\"{Font.FontFamily.Name}\" {StrFontSize}=\"{Font.Size}\" {StrColor}=\"{FontColor.Name}\" />";
		}

		public override ListViewItem ToListViewItem()
		{
			var result = base.ToListViewItem();
			result.SubItems.Add(String.Empty);
			result.SubItems.Add(String.Empty);
			result.SubItems.Add(Text);
			return result;
		}
		public override object Clone()
		{
			return new PdfText(Text, Location, FontColor, Font);
		}
	}
}
