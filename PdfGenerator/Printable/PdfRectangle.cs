using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
    public class PdfRectangle : ISizedPrintable
	{
		public Pen Pen { get; private set; }

		public PdfRectangle(Color color, int lineWidth, Point location1, Point location2, bool fill)
		{
			if (location2.X < location1.X)
			{
				var temp = location1.X;
				location1.X = location2.X;
				location2.X = temp;
			}
			if (location2.Y < location1.Y)
			{
				var temp = location1.Y;
				location1.Y = location2.Y;
				location2.Y = temp;
			}

			Pen = new Pen(color, lineWidth);
			Location = location1;
			Size = new Size(location2.X - location1.X, location2.Y - location1.Y);
			Fill = fill;
		}

		public PdfRectangle(Color color, int lineWidth, int x, int y, int width, int height, bool fill)
		{
			Pen = new Pen(color, lineWidth);
			Location = new Point(x, y);
			Size = new Size(width, height);
			Fill = fill;
		}

		public PdfRectangle(Dictionary<string, string> attributes)
		{
			var lineWidth = GetLineWidthFromAttributes(attributes);
			Pen = new Pen(GetColorFromAttributes(attributes), lineWidth);
			Location = GetLocationFromAttributes(attributes);
			Size = GetSizeFromAttributes(attributes);
			Fill = attributes.ContainsKey(StrFill);
		}

		public override void DrawOnGraphics(Graphics graphics)
		{
			if (Fill)
            {
				var fillColor = new SolidBrush(Pen.Color);
				graphics.FillRectangle(fillColor, X, Y, Width, Height);
			}
			else
            {
				graphics.DrawRectangle(Pen, X, Y, Width, Height);
			}
		}

		public override string ToString()
		{
			return $"<PrintRectangle {StrColor}=\"{Pen.Color.Name}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrWidth}=\"{Width}\" {StrHeight}=\"{Height}\" {StrLineWidth}=\"{Pen.Width}\" {StrFill}=\"{Fill}\" />";
		}
	}
}
