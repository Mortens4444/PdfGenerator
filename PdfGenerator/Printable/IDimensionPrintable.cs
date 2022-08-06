using System;
using System.Drawing;
using System.Windows.Forms;

namespace PdfGenerator.Printable
{
    public abstract class IDimensionPrintable : IPrintable
    {
		public Point EndLocation { get; protected set; }

		public int EndX
		{
			get
			{
				return EndLocation.X;
			}
		}

		public int EndY
		{
			get
			{
				return EndLocation.Y;
			}
		}

		public override ListViewItem ToListViewItem()
		{
			var result = base.ToListViewItem();
			result.SubItems.Add(String.Empty);
			result.SubItems.Add(String.Empty);
			result.SubItems.Add($"{StrX2} = {EndX}, {StrY2} = {EndY}");
			return result;
		}
	}
}
