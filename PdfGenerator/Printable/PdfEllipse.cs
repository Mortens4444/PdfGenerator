using System;
using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
	public class PdfEllipse : ISizedPrintable
	{
		public Pen Pen { get; private set; }

		public PdfEllipse(Color color, int lineWidth, Point location1, Point location2)
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
		}

		public PdfEllipse(Color color, int lineWidth, int x, int y, int width, int height)
		{
			Pen = new Pen(color, lineWidth);
			Location = new Point(x, y);
			Size = new Size(width, height);
		}

		public PdfEllipse(Dictionary<string, string> attributes)
		{
			var lineWidth = attributes.ContainsKey(StrLineWidth) ? Convert.ToInt32(attributes[StrLineWidth]) : 1;
			Pen = new Pen(Color.FromName(attributes[StrColor]), lineWidth);
			Location = new Point(Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]));
			Size = new Size(Convert.ToInt32(attributes[StrWidth]), Convert.ToInt32(attributes[StrHeight]));
		}

		public override void DrawOnGraphics(Graphics graphics)
		{
			graphics.DrawEllipse(Pen, X, Y, Width, Height);
		}

		public override string ToString()
		{
			return $"<PrintEllipse {StrColor}=\"{Pen.Color.Name}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrWidth}=\"{Width}\" {StrHeight}=\"{Height}\" {StrLineWidth}=\"{Pen.Width}\" />";
		}
	}
}
