using System.Drawing;

namespace PdfGenerator.Printable
{
	interface IPrintText : IPrintable
	{
		Color Color { get; }

		string FontName { get; }

		float FontSize { get; }

		string Text { get; }

		Font Font { get; }

		Brush Brush { get; }
	}
}