using System;
using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
	class PdfRectangle : IPrintable
	{
		public Pen Pen { get; private set; }

		public int X { get; private set; }

		public int Y { get; private set; }

		public int Width { get; private set; }

		public int Height { get; private set; }

		public PdfRectangle(Color color, int lineWidth, int x, int y, int width, int height)
		{
			Pen = new Pen(color, lineWidth);
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public static PdfRectangle Create(Dictionary<string, string> attributes)
		{
			var lineWidth = attributes.ContainsKey(StrLineWidth) ? Convert.ToInt32(attributes[StrLineWidth]) : 1;
			return new PdfRectangle(Color.FromName(attributes[StrColor]), lineWidth, Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Convert.ToInt32(attributes[StrWidth]), Convert.ToInt32(attributes[StrHeight]));
		}
	}
}
