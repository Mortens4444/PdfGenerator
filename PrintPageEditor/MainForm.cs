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
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);

			cbFontSize.SelectedIndex = 4;
		}

		private void tsmiExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDownLocation = e.Location;
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

			DrawPrintable(temporarlyPrintable, e);
			printables.DrawOnGraphics(e.Graphics);
		}

		private void DrawPrintable(IPrintable printable, PaintEventArgs e)
		{
			if (printable != null)
			{
				printable.DrawOnGraphics(e.Graphics);
				RefreshScreen();
			}
		}

		private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			showHorizontalHelper = printables.Any(printable => printable.Y == e.Y);
			showVerticalHelper = printables.Any(printable => printable.X == e.X);
			mouseX = e.X;
			mouseY = e.Y;

			if (mouseDownLocation.HasValue)
			{
				CreateNewObject(e.Location);
			}
		}

		private void CreateNewObject(Point? mouseButtonRelesedLocation = null)
		{
			mouseUpLocation = mouseButtonRelesedLocation;
			if (mouseDownLocation.HasValue && mouseUpLocation.HasValue)
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
				if (rbText.Checked)
				{
					temporarlyPrintable = new PdfText(tbText.Text, mouseDownLocation.Value, fontColor, fontName, fontSize);
				}
				else if (rbImage.Checked)
				{
					temporarlyPrintable = new PdfImage(imageFilePath, mouseDownLocation.Value.X, mouseDownLocation.Value.Y, (int)nudImageWidth.Value, (int)nudImageHeight.Value);
				}
			}
			
			RefreshScreen();
		}

		private void tsmi_Save_Click(object sender, EventArgs e)
		{
			saveFileDialog1.InitialDirectory = Application.StartupPath;
			if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				var fileContent = printables.GetFileContent();
				File.WriteAllText(saveFileDialog1.FileName, fileContent);
			}
		}

		private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
		{
			CreateNewObject(e.Location);
			printables.Add(temporarlyPrintable);
			mouseDownLocation = null;
		}

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			RefreshScreen(true);
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog(this) == DialogResult.OK)
			{
				fontName = fontDialog1.Font.Name;
				fontColor = fontDialog1.Color;
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
				RefreshScreen(true);
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

		private void rbText_CheckedChanged(object sender, EventArgs e)
		{
			tbText.Enabled = rbText.Checked;
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

		private void RefreshScreen(bool forceSynchronousPaint = false)
		{
			// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.invalidate?redirectedfrom=MSDN&view=netframework-4.8#System_Windows_Forms_Control_Invalidate
			Invalidate(true);
			if (forceSynchronousPaint)
			{
				Update();
			}
		}
	}
}
