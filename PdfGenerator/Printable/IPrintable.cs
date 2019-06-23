using System.Drawing;
using System.Windows.Forms;

namespace PdfGenerator.Printable
{
	public abstract class IPrintable
	{
		protected const string StrX = "x";

		protected const string StrY = "y";

		protected const string StrWidth = "width";

		protected const string StrHeight = "height";

		protected const string StrImageFilename = "image_filename";

		protected const string StrText = "text";

		protected const string StrFontName = "font_name";

		protected const string StrFontSize = "font_size";

		protected const string StrColor = "color";

		protected const string StrLineWidth = "line_width";

		public Point Location { get; protected set; }

		public int X
		{
			get
			{
				return Location.X;
			}
		}

		public int Y
		{
			get
			{
				return Location.Y;
			}
		}

		public abstract void DrawOnGraphics(Graphics graphics);

		public new abstract string ToString();

		public virtual ListViewItem ToListViewItem()
		{
			var result = new ListViewItem(GetType().Name);
			result.SubItems.Add(X.ToString());
			result.SubItems.Add(Y.ToString());
			result.Tag = this;
			return result;
		}
	}
}
