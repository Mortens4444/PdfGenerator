using PdfGenerator.Printable;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace PdfGenerator.Printers
{
	abstract class PrinterBase
	{
		public abstract void Print(IPrintable printable, PrintPageEventArgs eventArgs);

		protected static void Setup(PrintPageEventArgs eventArgs)
		{
			eventArgs.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			eventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			eventArgs.Graphics.CompositingQuality = CompositingQuality.HighQuality;
			eventArgs.Graphics.CompositingMode = CompositingMode.SourceCopy;
			eventArgs.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
	}
}
