using PdfGenerator.Printable;
using System.Drawing.Printing;

namespace PdfGenerator.Printers
{
	class ImagePrinter : PrinterBase
	{
		public void PrintImage(IPrintImage printImage, PrintPageEventArgs eventArgs)
		{
			Setup(eventArgs);
			eventArgs.Graphics.DrawImage(printImage.Image, printImage.Location.X, printImage.Location.Y, printImage.Size.Width, printImage.Size.Height);
		}

		public override void Print(IPrintable printable, PrintPageEventArgs eventArgs)
		{
			PrintImage(printable as IPrintImage, eventArgs);
		}
	}
}
