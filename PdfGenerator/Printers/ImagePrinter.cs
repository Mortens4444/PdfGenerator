using PdfGenerator.Printable;
using System.Drawing;

namespace PdfGenerator.Printers
{
	class ImagePrinter : PrinterBase<PdfImage>
	{
		public override void SpecificPrint(PdfImage pdfImage, Graphics graphics)
		{
			graphics.DrawImage(pdfImage.Image, pdfImage.Location.X, pdfImage.Location.Y, pdfImage.Size.Width, pdfImage.Size.Height);
		}
	}
}
