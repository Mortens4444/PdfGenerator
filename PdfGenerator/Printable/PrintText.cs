using System.Drawing;

namespace PdfGenerator.Printable
{
	class PrintText : IPrintText
	{
		public string Text { get; private set; }

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

		public PrintText(string text, int x, int y) : this(text, new Point(x, y), Color.Black) { }

		public PrintText(string text, int x, int y, Color color, string fontName = "Arial", float fontSize = 16) : this(text, new Point(x, y), color, fontName, fontSize) { }

		public PrintText(string text, Point location) : this(text, location, Color.Black) { }

		public PrintText(string text, Point location, Color color, string fontName = "Arial", float fontSize = 16)
		{
			Text = text;
			Location = location;
			Color = color;
			FontName = fontName;
			FontSize = fontSize;
		}
	}
}
