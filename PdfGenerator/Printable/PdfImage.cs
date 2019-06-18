using System;
using System.Collections.Generic;
using System.Drawing;

namespace PdfGenerator.Printable
{
	class PdfImage : IPrintable
	{
		public Image Image { get; private set; }

		public Point Location { get; private set; }

		public Size Size { get; private set; }

		public int X
		{
			get
			{
				return Location.X;
			}
		}

		public int Y
		{
			get
			{
				return Location.Y;
			}
		}

		public PdfImage(string imagePath, int x = 0, int y = 0) : this(Image.FromFile(imagePath), new Point(x, y)) { }

		public PdfImage(string imagePath, int x, int y, int width, int height) : this(Image.FromFile(imagePath), new Point(x, y), new Size(width, height)) { }

		public PdfImage(Image image, int x = 0, int y = 0) : this(image, new Point(x, y), new Size(image.Width, image.Height)) { }

		public PdfImage(Image image, Point location) : this(image, location, new Size(image.Width, image.Height)) { }

		public PdfImage(Image image, Point location, Size size)
		{
			Image = image;
			Location = location;
			Size = size;
		}

		public static PdfImage Create(Dictionary<string, string> attributes)
		{
			if (attributes.ContainsKey(StrX) && attributes.ContainsKey(StrY))
			{
				if (attributes.ContainsKey(StrWidth) && attributes.ContainsKey(StrHeight))
				{
					return new PdfImage(attributes[StrImageFilename], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]), Convert.ToInt32(attributes[StrWidth]), Convert.ToInt32(attributes[StrHeight]));
				}
				return new PdfImage(attributes[StrImageFilename], Convert.ToInt32(attributes[StrX]), Convert.ToInt32(attributes[StrY]));
			}
			return new PdfImage(attributes[StrImageFilename]);
		}
	}
}
