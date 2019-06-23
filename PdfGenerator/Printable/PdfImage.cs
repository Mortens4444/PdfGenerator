using System;
using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
	public class PdfImage : ISizedPrintable
	{
		public Image Image { get; private set; }

		private readonly string imageFilePath;

		public PdfImage(string imageFilePath, int x = 0, int y = 0) : this(Image.FromFile(imageFilePath), new Point(x, y))
		{
			this.imageFilePath = imageFilePath;
		}

		public PdfImage(string imageFilePath, int x, int y, int width, int height) : this(Image.FromFile(imageFilePath), new Point(x, y), new Size(width, height))
		{
			this.imageFilePath = imageFilePath;
		}

		private PdfImage(Image image, Point location) : this(image, location, new Size(image.Width, image.Height)) { }

		private PdfImage(Image image, Point location, Size size)
		{
			Image = image;
			Location = location;
			Size = size;
		}

		public PdfImage(Dictionary<string, string> attributes)
		{
			imageFilePath = attributes[StrImageFilename];
			Image = Image.FromFile(imageFilePath);
			Location = new Point(attributes.ContainsKey(StrX) ? Convert.ToInt32(attributes[StrX]) : 0, attributes.ContainsKey(StrY) ? Convert.ToInt32(attributes[StrY]) : 0);
			Size = new Size(attributes.ContainsKey(StrWidth) ? Convert.ToInt32(attributes[StrWidth]) : Image.Width, attributes.ContainsKey(StrHeight) ? Convert.ToInt32(attributes[StrHeight]) : Image.Height);
		}

		public override void DrawOnGraphics(Graphics graphics)
		{
			graphics.DrawImage(Image, X, Y, Width, Height);
		}

		public override string ToString()
		{
			return $"<PrintImage {StrImageFilename}=\"{imageFilePath}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrWidth}=\"{Width}\" {StrHeight}=\"{Height}\" />";
		}
	}
}
