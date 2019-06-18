using PdfGenerator.Printable;
using System.Drawing;

namespace PdfGenerator.Printers
{
	class RectanglePrinter : PrinterBase<PdfRectangle>
	{
		public override void SpecificPrint(PdfRectangle pdfRectangle, Graphics graphics)
		{
			graphics.DrawRectangle(pdfRectangle.Pen, pdfRectangle.X, pdfRectangle.Y, pdfRectangle.Width, pdfRectangle.Height);
		}
	}
}
