using PdfGenerator.Printable;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace PdfGenerator
{
    public class PdfPrinter
	{
		private PrintDocument printDocument;

		/// <summary>
		/// Generate a PDF file
		/// </summary>
		/// <param name="printOutputPath">Output filename</param>
		/// <param name="printingRulesFilePath">Printing rules file</param>
		/// <param name="replaceables">Replace key value pairs in the printing be this map</param>
		public void Print(string printOutputPath, string printingRulesFilePath, Dictionary<string, string> replaceables = null)
		{
			var printables = Printables.LoadFromFiles(printingRulesFilePath);
			Print(printOutputPath, printables, replaceables);
		}

		/// <summary>
		/// Generate a PDF file
		/// </summary>
		/// <param name="printOutputPath">Output filename</param>
		/// <param name="printables">Printables elements</param>
		/// <param name="replaceables">Replace key value pairs in the printing be this map</param>
		public void Print(string printOutputPath, Printables printables, Dictionary<string, string> replaceables = null)
		{
			if (replaceables != null && replaceables.Any())
			{
				var texts = printables.Where(printable => printable is PdfText);
				foreach (PdfText text in texts)
				{
					foreach (var replacable in replaceables)
					{
						text.Text = text.Text.Replace(replacable.Key, replacable.Value);
					}
				}
			}

			if (File.Exists(printOutputPath))
			{
				File.Delete(printOutputPath);
			}

			printDocument = new PrintDocument();
			printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
			printDocument.PrinterSettings.PrintFileName = printOutputPath;
			printDocument.PrinterSettings.PrintToFile = true;
			Print(printables);
		}

		private void Print(IEnumerable<IPrintable> printables)
		{
			foreach (var printable in printables)
			{
				printDocument.PrintPage += (_, eventArgs) =>
				{
					eventArgs.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					eventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;
					eventArgs.Graphics.CompositingQuality = CompositingQuality.HighQuality;
					eventArgs.Graphics.CompositingMode = CompositingMode.SourceCopy;
					eventArgs.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
					printable.DrawOnGraphics(eventArgs.Graphics);
				};
			}

			printDocument.Print();
		}
	}
}
