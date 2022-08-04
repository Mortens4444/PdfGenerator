using PdfGenerator;
using PdfGenerator.Printable;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PrintPageEditor
{
	public partial class MainForm : Form
	{
		private Point? mouseDownLocation = null, mouseUpLocation;
		private Printables printables = new Printables();
		private Color foregroundColor = Color.Black, fontColor = Color.Black;
		private int fontSize = 12;
		private string fontName = "Arial", imageFilePath;
		private IPrintable temporarlyPrintable;
		private bool showHorizontalHelper, showVerticalHelper;
		private int mouseX, mouseY;

		public MainForm()
		{
			InitializeComponent();
            cbFontSize.SelectedIndex = 4;
		}

		private void tsmiExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				mouseDownLocation = e.Location;
			}
		}

		private void pForeColor_DoubleClick(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog(this) == DialogResult.OK)
			{
				foregroundColor = colorDialog1.Color;
				pForeColor.BackColor = colorDialog1.Color;
			}
		}

		private void pbCanvas_Paint(object sender, PaintEventArgs e)
		{
			if (showHorizontalHelper)
			{
				e.Graphics.DrawLine(new Pen(Color.Red), 0, mouseY, pbCanvas.Width, mouseY);				
			}
			if (showVerticalHelper)
			{
				e.Graphics.DrawLine(new Pen(Color.Red), mouseX, 0, mouseX, pbCanvas.Height);
			}

			printables.DrawOnGraphics(e.Graphics);
			DrawPrintable(temporarlyPrintable, e);
		}

		private void DrawPrintable(IPrintable printable, PaintEventArgs e)
		{
			if (printable != null)
			{
				printable.DrawOnGraphics(e.Graphics);
				Update();
			}
		}

		private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
		{
            if (tabControl.SelectedTab == tpText || tabControl.SelectedTab == tpImage)
            {
                mouseDownLocation = e.Location;
            }
            mouseX = e.X;
			mouseY = e.Y;
			showHorizontalHelper = printables.Any(printable => printable.Y == mouseY);
			showVerticalHelper = printables.Any(printable => printable.X == mouseX);
			tssLabel.Text = $"X: {mouseX}, Y: {mouseY}";

			if (mouseDownLocation.HasValue)
			{
				CreateNewObject(e.Location);
			}
			pbCanvas.Invalidate();
		}

		private void CreateNewObject(Point? mouseButtonRelesedLocation = null)
		{
			mouseUpLocation = mouseButtonRelesedLocation;
			if (tabControl.SelectedTab == tpShapes && mouseDownLocation.HasValue && mouseUpLocation.HasValue && mouseDownLocation.Value.X != mouseUpLocation.Value.X && mouseDownLocation.Value.Y != mouseUpLocation.Value.Y)
			{
				if (rbRectangle.Checked)
				{
					temporarlyPrintable = new PdfRectangle(foregroundColor, (int)nudLineWidth.Value, mouseDownLocation.Value, mouseUpLocation.Value);					
				}
				else if (rbEllipse.Checked)
				{
					temporarlyPrintable = new PdfEllipse(foregroundColor, (int)nudLineWidth.Value, mouseDownLocation.Value, mouseUpLocation.Value);
				}
			}
			if (mouseDownLocation.HasValue)
			{
				if (tabControl.SelectedTab == tpText && !String.IsNullOrWhiteSpace(tbText.Text))
				{
					temporarlyPrintable = new PdfText(tbText.Text, mouseDownLocation.Value, fontColor, fontName, fontSize);
				}
				else if (tabControl.SelectedTab == tpImage && !String.IsNullOrWhiteSpace(imageFilePath))
				{
					temporarlyPrintable = new PdfImage(imageFilePath, mouseDownLocation.Value.X, mouseDownLocation.Value.Y, (int)nudImageWidth.Value, (int)nudImageHeight.Value);
				}
			}

			Update();
		}

		private void tsmi_Save_Click(object sender, EventArgs e)
		{
			SavePrintingRuleFileWithDialog();
		}

		private string SavePrintingRuleFileWithDialog()
		{
			saveFileDialog1.InitialDirectory = Application.StartupPath;
			if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				var fileContent = printables.GetFileContent();
				File.WriteAllText(saveFileDialog1.FileName, fileContent);
				return saveFileDialog1.FileName;
			}
			return null;
		}

		private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}

			CreateNewObject(e.Location);
			if (temporarlyPrintable != null)
			{
				printables.Add(temporarlyPrintable);
				AddItem(temporarlyPrintable);
			}
			mouseDownLocation = null;
		}

		private void AddItem(IPrintable printable)
		{
			var item = printable.ToListViewItem();
			if (lvPrintables.Items.Count % 2 == 0)
			{
				item.BackColor = Color.LightCyan;
			}
			lvPrintables.Items.Add(item);
		}

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			Update();
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog(this) == DialogResult.OK)
			{
				fontName = fontDialog1.Font.Name;
				fontColor = fontDialog1.Color;
				cbFontSize.Text = fontDialog1.Font.Size.ToString();
			}
		}

		private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			fontSize = Convert.ToInt32(cbFontSize.Items[cbFontSize.SelectedIndex]);
		}

		private void tsmi_Load_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				printables = Printables.LoadFromFiles(openFileDialog1.FileName);
				lvPrintables.Items.Clear();
				foreach (var printable in printables)
				{
					AddItem(printable);
				}
				temporarlyPrintable = null;
				pbCanvas.Select();
				Update();
			}
		}

		private void btnLoadImage_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				imageFilePath = openFileDialog1.FileName;
				var image = Image.FromFile(imageFilePath);
				nudImageWidth.Value = image.Width;
				nudImageHeight.Value = image.Height;
				Update();
			}
		}

		private void pbCanvas_MouseLeave(object sender, EventArgs e)
		{
			tssLabel.Text = "Ready";
		}

		private void tsmiDeletePrintable_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem selectedItem in lvPrintables.SelectedItems)
			{
				var printable = selectedItem.Tag as IPrintable;
				printables.Remove(printable);
				lvPrintables.Items.Remove(selectedItem);
			}
			pbCanvas.Invalidate();
		}

		private void tsmiPrint_Click(object sender, EventArgs e)
		{
			var printingRulesFilePath = SavePrintingRuleFileWithDialog();
			if (printingRulesFilePath != null)
			{
				var pdfPrinter = new PdfPrinter();
				var printOutputPath = $"{printingRulesFilePath}.pdf";
				pdfPrinter.Print(printOutputPath, printingRulesFilePath);
			}
		}

		private void nudImageSizeChanged(object sender, EventArgs e)
		{
			CreateNewObject();
		}

		private void tbText_TextChanged(object sender, EventArgs e)
		{
			CreateNewObject();
		}

		private void cbFontSize_TextChanged(object sender, EventArgs e)
		{
			try
			{
				fontSize = Convert.ToInt32(cbFontSize.Text);
			}
			catch
			{
				cbFontSize.Text = fontSize.ToString();
			}
		}
	}
}
