using PdfGenerator.Printable;
using System.Collections.Generic;
using System.Linq;

namespace PdfGenerator
{
	public class PdfPrinter
	{
		/// <summary>
		/// Generate a PDF file
		/// </summary>
		/// <param name="printOutputPath">Output filename</param>
		/// <param name="printingRulesFilePath">Printing rules file</param>
		/// <param name="replacables">Replace key value pairs in the printing be this map</param>
		public void Print(string printOutputPath, string printingRulesFilePath, Dictionary<string, string> replacables = null)
		{
			var printablesProvider = new PrintablesProvider();
			var printables = printablesProvider.Get(printingRulesFilePath);
			if (replacables != null && replacables.Any())
			{
				var texts = printables.Where(printable => printable is PdfText);
				foreach (PdfText text in texts)
				{
					foreach (var replacable in replacables)
					{
						text.Text = text.Text.Replace(replacable.Key, replacable.Value);
					}
				}
			}

			var printer = new Printer(printOutputPath);
			printer.Print(printables);
		}
	}
}
