using PdfGenerator;
using PdfGenerator.Printable;
using PrintPageEditor.Properties;
using System;
using System.Collections.Generic;
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
		private Font font;
		private string imageFilePath;
		private IPrintable temporarilyPrintable;
		private bool showHorizontalHelper, showVerticalHelper;
		private int mouseX, mouseY;

		public MainForm()
		{
			InitializeComponent();
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
			if (colorDialog1.ShowDialog() == DialogResult.OK)
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
			DrawPrintable(temporarilyPrintable, e);
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
            if ((tabControl.SelectedTab == tpText || tabControl.SelectedTab == tpImage) && mouseDownLocation != null)
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
				if (rbLine.Checked)
				{
					temporarilyPrintable = new PdfLine(foregroundColor, (int)nudLineWidth.Value, mouseDownLocation.Value, mouseUpLocation.Value);
				}
				else if (rbRectangle.Checked)
				{
					temporarilyPrintable = new PdfRectangle(foregroundColor, (int)nudLineWidth.Value, mouseDownLocation.Value, mouseUpLocation.Value, chkFill.Checked);
				}
				else if (rbEllipse.Checked)
				{
					temporarilyPrintable = new PdfEllipse(foregroundColor, (int)nudLineWidth.Value, mouseDownLocation.Value, mouseUpLocation.Value, chkFill.Checked);
				}
			}
			if (mouseDownLocation.HasValue)
			{
				if (tabControl.SelectedTab == tpText && !String.IsNullOrWhiteSpace(tbText.Text))
				{
					temporarilyPrintable = new PdfText(tbText.Text, mouseDownLocation.Value, fontColor, font);
				}
				else if (tabControl.SelectedTab == tpImage && !String.IsNullOrWhiteSpace(imageFilePath))
				{
					temporarilyPrintable = new PdfImage(imageFilePath, mouseDownLocation.Value.X, mouseDownLocation.Value.Y, (int)nudImageWidth.Value, (int)nudImageHeight.Value);
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
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
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
			if (temporarilyPrintable != null)
			{
				printables.Add(temporarilyPrintable);
				AddItem(temporarilyPrintable);
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
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				font = fontDialog1.Font;
				fontColor = fontDialog1.Color;
			}
		}

		private void tsmi_Load_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "XML files|*.xml";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				printables = Printables.LoadFromFiles(openFileDialog1.FileName);
				LoadPrintables();
			}
		}

		private void btnLoadImage_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Bmp files|*.bmp|Jpeg files|*.jpg|Png files|*.png|All files|*.*";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
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

        private void tsmiMoveUp_Click(object sender, EventArgs e)
        {
			var item = lvPrintables.SelectedItems[0];
			int newIndex = item.Index - 1;
			lvPrintables.Items.RemoveAt(item.Index);
			lvPrintables.Items.Insert(newIndex, item);
		}

		private void tsmiMoveDown_Click(object sender, EventArgs e)
		{
			var item = lvPrintables.SelectedItems[0];
			int newIndex = item.Index + 1;
			lvPrintables.Items.RemoveAt(item.Index);
			lvPrintables.Items.Insert(newIndex, item);
		}

		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
			tsmiDeletePrintable.Enabled = lvPrintables.SelectedItems.Count > 0;
			tsmiMoveUp.Enabled = lvPrintables.SelectedItems.Count == 1 && lvPrintables.SelectedItems[0].Index > 0;
			tsmiMoveDown.Enabled = lvPrintables.SelectedItems.Count == 1 && lvPrintables.SelectedItems[0].Index < lvPrintables.Items.Count - 1;
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
				try
				{
					pdfPrinter.Print(printOutputPath, printingRulesFilePath);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
			}
		}

		private void tsmiChildPaint_Click(object sender, EventArgs e)
        {
			printables = Printables.LoadFromXmlText(Resources.ChildPaint);
            LoadPrintables();
			pbCanvas.Invalidate();
		}

        private void tsmiCurriculumVitæ_Click(object sender, EventArgs e)
		{
			var files = new string[]
			{
				"personal_data.yaml",
				"work_experience.yaml",
				"internship.yaml",
				"education.yaml",
				"computer_skills.yaml",
				"languages.yaml",
				"other_abilities.yaml",
				"interests.yaml"
			};
			
			var replaceables = new Dictionary<string, string>();
			foreach (var file in files)
            {
				var currentFile = Path.Combine(Application.StartupPath, "Resources", file);
				var content = File.ReadAllText(currentFile);
				replaceables.Add($"@{file}", content);
			}

			printables = Printables.LoadFromXmlText(Resources.CurriculumVitæ);
			LoadPrintables();

			var pdfPrinter = new PdfPrinter();
			var printOutputPath = Path.Combine(Application.StartupPath, "Curriculum vitæ.pdf");
			try
			{
				pdfPrinter.Print(printOutputPath, printables, replaceables);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			pbCanvas.Invalidate();
		}

		private void LoadPrintables()
		{
			lvPrintables.Items.Clear();
			foreach (var printable in printables)
			{
				AddItem(printable);
			}
			temporarilyPrintable = null;
			pbCanvas.Select();
			Update();
		}

		private void nudImageSizeChanged(object sender, EventArgs e)
		{
			CreateNewObject();
		}

		private void tbText_TextChanged(object sender, EventArgs e)
		{
			CreateNewObject();
		}
	}
}
