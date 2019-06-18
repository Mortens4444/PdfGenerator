using PdfGenerator.Printable;
using System.Drawing;

namespace PdfGenerator.Printers
{
	class TextPrinter : PrinterBase<PdfText>
	{
		public override void SpecificPrint(PdfText pdfText, Graphics graphics)
		{
			graphics.DrawString(pdfText.Text, pdfText.Font, pdfText.Brush, pdfText.Location.X, pdfText.Location.Y);
		}
	}
}
