using System.Drawing;

namespace PdfGenerator.Printable
{
	public abstract class ISizedPrintable : IPrintable
	{
		public Size Size { get; protected set; }

		public int Width
		{
			get
			{
				return Size.Width;
			}
		}

		public int Height
		{
			get
			{
				return Size.Height;
			}
		}
	}
}
