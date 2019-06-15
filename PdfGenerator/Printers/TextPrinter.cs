using PdfGenerator.Printable;
using System.Drawing.Printing;

namespace PdfGenerator.Printers
{
	class TextPrinter : PrinterBase
	{
		public void PrintText(IPrintText printText, PrintPageEventArgs eventArgs)
		{
			Setup(eventArgs);
			eventArgs.Graphics.DrawString(printText.Text, printText.Font, printText.Brush, printText.Location.X, printText.Location.Y);
		}

		public override void Print(IPrintable printable, PrintPageEventArgs eventArgs)
		{
			PrintText(printable as IPrintText, eventArgs);
		}
	}
}
