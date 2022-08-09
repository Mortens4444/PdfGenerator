using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PdfGenerator.Printable
{
	public class PdfText : IPrintable
	{
        public Font Font { get; set; }
		
		public string Text { get; set; }

		public Color FontColor { get; private set; }

		public Brush Brush
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
			var numberOfLines = Text.Count(c => c == '\n') + 1;
			if (Text.StartsWith("@"))
            {
				var fileName = Text.Substring(1);
				var currentFile = Path.Combine(Application.StartupPath, "Resources", fileName);
				var content = File.ReadAllText(currentFile);
				numberOfLines = content.Count(c => c == '\n') + 1;
			}
			LastY += (int)Math.Ceiling(numberOfLines * Font.Size * 1.9) + 5;
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
	}
}
