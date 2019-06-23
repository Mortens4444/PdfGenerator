using PdfGenerator.Printable;
using System.Drawing;

namespace PdfGenerator.Printers
{
	class EllipsePrinter : PrinterBase<PdfEllipse>
	{
		public override void SpecificPrint(PdfEllipse pdfEllipse, Graphics graphics)
		{
			graphics.DrawEllipse(pdfEllipse.Pen, pdfEllipse.X, pdfEllipse.Y, pdfEllipse.Width, pdfEllipse.Height);
		}
	}
}
