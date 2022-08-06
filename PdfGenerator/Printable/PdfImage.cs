using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
			Location = GetLocationFromAttributes(attributes);
			var size = GetSizeFromAttributes(attributes);
			Size = size != Size.Empty ? size : Image.Size;
		}

		public override void DrawOnGraphics(Graphics graphics)
		{
			graphics.DrawImage(Image, X, Y, Width, Height);
		}

		public override string ToString()
		{
			return $"<PrintImage {StrImageFilename}=\"{imageFilePath}\" {StrX}=\"{X}\" {StrY}=\"{Y}\" {StrWidth}=\"{Width}\" {StrHeight}=\"{Height}\" />";
		}

		public override ListViewItem ToListViewItem()
		{
			var result = base.ToListViewItem();
			result.SubItems.Add(imageFilePath);
			return result;
		}
	}
}
