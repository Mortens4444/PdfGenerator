using System.Drawing;
using System.Drawing.Printing;
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
			string backgroundFile = Path.Combine(Application.StartupPath, "Background.png");

			var fontFamily = new FontFamily("Arial");
			var font = new Font(fontFamily, 16);
			var brush = new SolidBrush(Color.Black);

			foreach (var result in results)
			{
				var nameAndPosition = result.Split(';');
				var pdfFile = Path.Combine(Application.StartupPath, $"{nameAndPosition[0]}.pdf");
				if (File.Exists(pdfFile))
				{
					File.Delete(pdfFile);
				}
				var pdoc = new PrintDocument();
				pdoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
				pdoc.PrinterSettings.PrintFileName = pdfFile;
				pdoc.PrinterSettings.PrintToFile = true;
				pdoc.PrintPage += (s, ev) =>
				{
					var fs = File.Open(backgroundFile, FileMode.Open, FileAccess.Read);
					var image = Image.FromStream(fs);
					try
					{
						ev.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
						ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
						ev.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
						ev.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
						ev.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

						ev.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
						ev.Graphics.DrawString($"Gratulálunk a(z) {nameAndPosition[1]}. helyezéshez {nameAndPosition[0]}", font, brush, 50, 150);
					}
					finally
					{
						fs.Close();
						image.Dispose();
					}
				};
				pdoc.Print();
			}
		}
	}
}
