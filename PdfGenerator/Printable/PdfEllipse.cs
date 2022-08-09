using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
    public class PdfEllipse : ISizedPrintable
	{
		public Pen Pen { get; private set; }

		public PdfEllipse(Color color, int lineWidth, Point location1, Point location2, bool fill)
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

		public PdfEllipse(Color color, int lineWidth, int x, int y, int width, int height, bool fill)
			: this(new Pen(color, lineWidth), new Point(x, y), new Size(width, height), fill)
		{ }

		public PdfEllipse(Pen pen, Point location, Size size, bool fill)
		{
			Pen = pen;
			Location = location;
			Size = size;
			Fill = fill;
		}

		public PdfEllipse(Dictionary<string, string> attributes)
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
				graphics.FillEllipse(fillColor, X, Y, Width, Height);
			}
			else
			{
				graphics.DrawEllipse(Pen, X, Y, Width, Height);
			}
		}

		public override string ToString()
		{
			return $"<PrintEllipse {StrColor}=\"{Pen.Color.Name}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrWidth}=\"{Width}\" {StrHeight}=\"{Height}\" {StrLineWidth}=\"{Pen.Width}\" {StrFill}=\"{Fill}\" />";
		}

        public override object Clone()
		{
			return new PdfEllipse(Pen, Location, Size, Fill);
        }
    }
}
