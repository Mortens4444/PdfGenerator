using System.Drawing;
using System.Windows.Forms;

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

		public override ListViewItem ToListViewItem()
		{
			var result = base.ToListViewItem();
			result.SubItems.Add(Width.ToString());
			result.SubItems.Add(Height.ToString());
			return result;
		}
	}
}
