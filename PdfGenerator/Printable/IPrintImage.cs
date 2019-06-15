using System.Drawing;

namespace PdfGenerator.Printable
{
	interface IPrintImage : IPrintable
	{
		Image Image { get; }

		Size Size { get; }
	}
}