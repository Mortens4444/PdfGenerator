using PdfGenerator.Printable;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PdfGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			string resultsFile = Path.Combine(Application.StartupPath, "Results.txt");
			var results = File.ReadAllLines(resultsFile);

			foreach (var result in results)
			{
				var nameAndPosition = result.Split(';');

				var printables = new List<IPrintable>
				{
					new PrintImage(Path.Combine(Application.StartupPath, "Background.png")),
					new PrintImage(Path.Combine(Application.StartupPath, "Orange round.png"), 300, 100),
					new PrintImage(Path.Combine(Application.StartupPath, "Blue rectangle.png"), 10, 500),
					new PrintText($"Gratulálunk a(z) {nameAndPosition[1]}. helyezéshez {nameAndPosition[0]}", 50, 150),
					new PrintText("Have a nice day", 50, 170)
				};

				var pdfFile = Path.Combine(Application.StartupPath, $"{nameAndPosition[0]}.pdf");
				var printer = new Printer(pdfFile);
				foreach (var printable in printables)
				{
					printer.PrintDocument.PrintPage += (_, eventArgs) =>
					{
						printer.Print(printable, eventArgs);
					};
				}
				printer.PrintDocument.Print();
			}
		}
	}
}
