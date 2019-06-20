using PdfGenerator;
using System;
using System.Collections.Generic;
using System.IO;

namespace MultiPdfGeneration
{
	class Program
	{
		static void Main(string[] args)
		{
			var resultsFilePath = @".\Results.txt";
			var printingRulesFilePath = @".\Printings.xml";

			var results = File.ReadAllLines(resultsFilePath);
			var pdfPrinter = new PdfPrinter();

			foreach (var result in results)
			{
				var nameAndPosition = result.Split(';');
				uint position = Convert.ToUInt32(nameAndPosition[1]);
				var replaceables = new Dictionary<string, string>
				{
					{ "@Name", nameAndPosition[0] },
					{ "@Position", $"{position}{PositionPostfixProvider.Get(position)}" }
				};
				var printOutputPath = $".\\{position}. {nameAndPosition[0]}.pdf";
				pdfPrinter.Print(printOutputPath, printingRulesFilePath, replaceables);
			}
		}
	}
}
