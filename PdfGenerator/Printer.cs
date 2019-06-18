using PdfGenerator.Printable;
using PdfGenerator.Printers;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;

namespace PdfGenerator
{
	class Printer
	{
		public PrintDocument PrintDocument;

		private readonly IEnumerable<Type> printers = TypeExtensions.GetDerivedTypesOf<PrinterBase>();

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

		public void Print(IEnumerable<IPrintable> printables)
		{
			foreach (var printable in printables)
			{
				PrintDocument.PrintPage += (_, eventArgs) =>
				{
					var supportedPrinterType = printers.First(printer => printer.BaseType.GenericTypeArguments.First().FullName == printable.GetType().FullName);
					var supportedPrinter = Activator.CreateInstance(supportedPrinterType) as PrinterBase;
					supportedPrinter.Print(printable, eventArgs);
				};
			}

			PrintDocument.Print();
		}
	}
}
