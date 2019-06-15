using System.Drawing;

namespace PdfGenerator.Printable
{
	class PrintImage : IPrintImage
	{
		public Image Image { get; private set; }

		public Point Location { get; private set; }

		public Size Size { get; private set; }
		
		public PrintImage(string imagePath, int x = 0, int y = 0) : this(Image.FromFile(imagePath), new Point(x, y)) { }

		public PrintImage(string imagePath, int x, int y, int width, int height) : this(Image.FromFile(imagePath), new Point(x, y), new Size(width, height)) { }

		public PrintImage(Image image, int x = 0, int y = 0) : this(image, new Point(x, y), new Size(image.Width, image.Height)) { }

		public PrintImage(Image image, Point location) : this(image, location, new Size(image.Width, image.Height)) { }

		public PrintImage(Image image, Point location, Size size)
		{
			Image = image;
			Location = location;
			Size = size;
		}
	}
}
