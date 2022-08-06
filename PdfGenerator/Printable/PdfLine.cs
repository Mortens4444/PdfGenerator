using System;
using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
	public class PdfLine : IDimensionPrintable
	{
		public Pen Pen { get; private set; }

		public PdfLine(Color color, int lineWidth, Point location1, Point location2)
		{
			Pen = new Pen(color, lineWidth);
			Location = location1;
			EndLocation = location2;
		}

		public PdfLine(Color color, int lineWidth, int x, int y, int x2, int y2)
			: this(color, lineWidth, new Point(x, y), new Point(x2, y2))
		{
		}

		public PdfLine(Dictionary<string, string> attributes)
		{
			var lineWidth = GetLineWidthFromAttributes(attributes);
			Pen = new Pen(GetColorFromAttributes(attributes), lineWidth);
			Location = GetLocationFromAttributes(attributes);
			EndLocation = new Point(Convert.ToInt32(attributes[StrX2]), Convert.ToInt32(attributes[StrY2]));
		}

		public override void DrawOnGraphics(Graphics graphics)
		{
			graphics.DrawLine(Pen, X, Y, EndX, EndY);
		}

		public override string ToString()
		{
			return $"<PrintLine {StrColor}=\"{Pen.Color.Name}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrX2}=\"{EndX}\" {StrY2}=\"{EndY}\" {StrLineWidth}=\"{Pen.Width}\" />";
		}
	}
}
