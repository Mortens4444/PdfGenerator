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

		public PdfRectangle(Pen pen, int x, int y, int width, int height)
		{
			Pen = pen;
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
	}
}
