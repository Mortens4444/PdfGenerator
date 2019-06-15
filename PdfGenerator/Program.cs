using PdfGenerator.Printable;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
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

			var printables = ConfigurationManager.GetSection("Printings") as List<IPrintable>;
			foreach (var result in results)
			{
				var nameAndPosition = result.Split(';');

				var actualPrintables = new List<IPrintable>(printables);
				actualPrintables.AddRange(new IPrintable[] {
							new PrintText($"{nameAndPosition[1]}{PositionPostfixProvider.Get(Convert.ToUInt32(nameAndPosition[1]))}", 430, 150, Color.Green, "Times New Roman", 22),
							new PrintText($"{nameAndPosition[0]}", 430, 200)
						});

				var outputFile = Path.Combine(Application.StartupPath, $"{nameAndPosition[1]}. {nameAndPosition[0]}.pdf");
				var printer = new Printer(outputFile);
				printer.Print(actualPrintables);
			}
		}
	}
}
