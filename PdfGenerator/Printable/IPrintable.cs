using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PdfGenerator.Printable
{
	public abstract class IPrintable
	{
		protected const string StrX = "x";

		protected const string StrY = "y";

		protected const string StrX2 = "x2";

		protected const string StrY2 = "y2";

		protected const string StrFill = "fill";

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

		protected Point GetLocationFromAttributes(Dictionary<string, string> attributes)
		{
			var x = attributes.ContainsKey(StrX) ? Convert.ToInt32(attributes[StrX]) : 0;
			var y = attributes.ContainsKey(StrY) ? Convert.ToInt32(attributes[StrY]) : 0;
			return new Point(x, y);
		}

		protected Size GetSizeFromAttributes(Dictionary<string, string> attributes)
		{
			return attributes.ContainsKey(StrWidth) && attributes.ContainsKey(StrHeight) ?
				new Size(Convert.ToInt32(attributes[StrWidth]), Convert.ToInt32(attributes[StrHeight])) :
				Size.Empty;
		}

		protected Color GetColorFromAttributes(Dictionary<string, string> attributes)
		{
			if (attributes.ContainsKey(StrColor))
            {
				if (Color.FromName(attributes[StrColor]).ToArgb() != Color.Empty.ToArgb())
				{
					return Color.FromName(attributes[StrColor]);
				}

				return Color.FromArgb(Convert.ToInt32(attributes[StrColor], 16));
            }

			return Color.Black;
		}

		protected int GetLineWidthFromAttributes(Dictionary<string, string> attributes)
		{
			return attributes.ContainsKey(StrLineWidth) ? Convert.ToInt32(attributes[StrLineWidth]) : 1;
		}

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
