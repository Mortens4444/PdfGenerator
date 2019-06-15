using PdfGenerator.Printable;
using PdfGenerator.Printers;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;

namespace PdfGenerator
{
	class Printer
	{
		public PrintDocument PrintDocument;

		private readonly Dictionary<Type, PrinterBase> printers = new Dictionary<Type, PrinterBase>()
		{
			{ typeof(PrintImage), new ImagePrinter() },
			{ typeof(PrintText), new TextPrinter() }
		};

		public Printer(string pdfFile)
		{
			if (File.Exists(pdfFile))
			{
				File.Delete(pdfFile);
			}

			PrintDocument = new PrintDocument();
			PrintDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
			PrintDocument.PrinterSettings.PrintFileName = pdfFile;
			PrintDocument.PrinterSettings.PrintToFile = true;
		}

		public void Print(IPrintable printable, PrintPageEventArgs eventArgs)
		{
			printers[printable.GetType()].Print(printable, eventArgs);
		}
	}
}
