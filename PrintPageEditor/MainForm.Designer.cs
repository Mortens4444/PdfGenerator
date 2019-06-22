namespace PrintPageEditor
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pMain = new System.Windows.Forms.Panel();
			this.pCanvas = new System.Windows.Forms.Panel();
			this.pbCanvas = new System.Windows.Forms.PictureBox();
			this.pToolbar = new System.Windows.Forms.Panel();
			this.gbTools = new System.Windows.Forms.GroupBox();
			this.nudImageHeight = new System.Windows.Forms.NumericUpDown();
			this.nudImageWidth = new System.Windows.Forms.NumericUpDown();
			this.btnLoadImage = new System.Windows.Forms.Button();
			this.tbText = new System.Windows.Forms.TextBox();
			this.btnFont = new System.Windows.Forms.Button();
			this.cbFontSize = new System.Windows.Forms.ComboBox();
			this.lblFont = new System.Windows.Forms.Label();
			this.lblLineWidth = new System.Windows.Forms.Label();
			this.lblLineColor = new System.Windows.Forms.Label();
			this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
			this.pForeColor = new System.Windows.Forms.Panel();
			this.rbEllipse = new System.Windows.Forms.RadioButton();
			this.rbText = new System.Windows.Forms.RadioButton();
			this.rbRectangle = new System.Windows.Forms.RadioButton();
			this.msMenu = new System.Windows.Forms.MenuStrip();
			this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_Load = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.tssSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.rbImage = new System.Windows.Forms.RadioButton();
			this.pMain.SuspendLayout();
			this.pCanvas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
			this.pToolbar.SuspendLayout();
			this.gbTools.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
			this.msMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// pMain
			// 
			this.pMain.Controls.Add(this.pCanvas);
			this.pMain.Controls.Add(this.pToolbar);
			this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pMain.Location = new System.Drawing.Point(0, 0);
			this.pMain.Name = "pMain";
			this.pMain.Size = new System.Drawing.Size(1046, 554);
			this.pMain.TabIndex = 0;
			// 
			// pCanvas
			// 
			this.pCanvas.AutoScroll = true;
			this.pCanvas.Controls.Add(this.pbCanvas);
			this.pCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pCanvas.Location = new System.Drawing.Point(0, 0);
			this.pCanvas.Name = "pCanvas";
			this.pCanvas.Size = new System.Drawing.Size(765, 554);
			this.pCanvas.TabIndex = 1;
			// 
			// pbCanvas
			// 
			this.pbCanvas.BackColor = System.Drawing.Color.White;
			this.pbCanvas.Location = new System.Drawing.Point(0, 0);
			this.pbCanvas.Name = "pbCanvas";
			this.pbCanvas.Size = new System.Drawing.Size(2480, 3508);
			this.pbCanvas.TabIndex = 0;
			this.pbCanvas.TabStop = false;
			this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
			this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
			this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
			this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
			// 
			// pToolbar
			// 
			this.pToolbar.Controls.Add(this.gbTools);
			this.pToolbar.Controls.Add(this.msMenu);
			this.pToolbar.Dock = System.Windows.Forms.DockStyle.Right;
			this.pToolbar.Location = new System.Drawing.Point(765, 0);
			this.pToolbar.Name = "pToolbar";
			this.pToolbar.Size = new System.Drawing.Size(281, 554);
			this.pToolbar.TabIndex = 0;
			// 
			// gbTools
			// 
			this.gbTools.Controls.Add(this.rbImage);
			this.gbTools.Controls.Add(this.nudImageHeight);
			this.gbTools.Controls.Add(this.nudImageWidth);
			this.gbTools.Controls.Add(this.btnLoadImage);
			this.gbTools.Controls.Add(this.tbText);
			this.gbTools.Controls.Add(this.btnFont);
			this.gbTools.Controls.Add(this.cbFontSize);
			this.gbTools.Controls.Add(this.lblFont);
			this.gbTools.Controls.Add(this.lblLineWidth);
			this.gbTools.Controls.Add(this.lblLineColor);
			this.gbTools.Controls.Add(this.nudLineWidth);
			this.gbTools.Controls.Add(this.pForeColor);
			this.gbTools.Controls.Add(this.rbEllipse);
			this.gbTools.Controls.Add(this.rbText);
			this.gbTools.Controls.Add(this.rbRectangle);
			this.gbTools.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbTools.Location = new System.Drawing.Point(0, 24);
			this.gbTools.Name = "gbTools";
			this.gbTools.Size = new System.Drawing.Size(281, 530);
			this.gbTools.TabIndex = 1;
			this.gbTools.TabStop = false;
			this.gbTools.Text = "Tools";
			// 
			// nudImageHeight
			// 
			this.nudImageHeight.Location = new System.Drawing.Point(159, 213);
			this.nudImageHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudImageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudImageHeight.Name = "nudImageHeight";
			this.nudImageHeight.Size = new System.Drawing.Size(55, 20);
			this.nudImageHeight.TabIndex = 15;
			this.nudImageHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudImageHeight.ValueChanged += new System.EventHandler(this.nudImageSizeChanged);
			// 
			// nudImageWidth
			// 
			this.nudImageWidth.Location = new System.Drawing.Point(98, 213);
			this.nudImageWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudImageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudImageWidth.Name = "nudImageWidth";
			this.nudImageWidth.Size = new System.Drawing.Size(55, 20);
			this.nudImageWidth.TabIndex = 14;
			this.nudImageWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudImageWidth.ValueChanged += new System.EventHandler(this.nudImageSizeChanged);
			// 
			// btnLoadImage
			// 
			this.btnLoadImage.Location = new System.Drawing.Point(53, 210);
			this.btnLoadImage.Name = "btnLoadImage";
			this.btnLoadImage.Size = new System.Drawing.Size(27, 23);
			this.btnLoadImage.TabIndex = 13;
			this.btnLoadImage.Text = "...";
			this.btnLoadImage.UseVisualStyleBackColor = true;
			this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
			// 
			// tbText
			// 
			this.tbText.Enabled = false;
			this.tbText.Location = new System.Drawing.Point(53, 138);
			this.tbText.Name = "tbText";
			this.tbText.Size = new System.Drawing.Size(219, 20);
			this.tbText.TabIndex = 11;
			this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
			// 
			// btnFont
			// 
			this.btnFont.Location = new System.Drawing.Point(38, 109);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(23, 23);
			this.btnFont.TabIndex = 10;
			this.btnFont.Text = "A";
			this.btnFont.UseVisualStyleBackColor = true;
			this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
			// 
			// cbFontSize
			// 
			this.cbFontSize.FormattingEnabled = true;
			this.cbFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "72"});
			this.cbFontSize.Location = new System.Drawing.Point(63, 110);
			this.cbFontSize.Name = "cbFontSize";
			this.cbFontSize.Size = new System.Drawing.Size(39, 21);
			this.cbFontSize.TabIndex = 9;
			this.cbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbFontSize_SelectedIndexChanged);
			this.cbFontSize.TextChanged += new System.EventHandler(this.cbFontSize_TextChanged);
			// 
			// lblFont
			// 
			this.lblFont.AutoSize = true;
			this.lblFont.Location = new System.Drawing.Point(4, 114);
			this.lblFont.Name = "lblFont";
			this.lblFont.Size = new System.Drawing.Size(28, 13);
			this.lblFont.TabIndex = 8;
			this.lblFont.Text = "Font";
			// 
			// lblLineWidth
			// 
			this.lblLineWidth.AutoSize = true;
			this.lblLineWidth.Location = new System.Drawing.Point(132, 55);
			this.lblLineWidth.Name = "lblLineWidth";
			this.lblLineWidth.Size = new System.Drawing.Size(55, 13);
			this.lblLineWidth.TabIndex = 7;
			this.lblLineWidth.Text = "Line width";
			// 
			// lblLineColor
			// 
			this.lblLineColor.AutoSize = true;
			this.lblLineColor.Location = new System.Drawing.Point(6, 55);
			this.lblLineColor.Name = "lblLineColor";
			this.lblLineColor.Size = new System.Drawing.Size(53, 13);
			this.lblLineColor.TabIndex = 6;
			this.lblLineColor.Text = "Line color";
			// 
			// nudLineWidth
			// 
			this.nudLineWidth.Location = new System.Drawing.Point(191, 53);
			this.nudLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudLineWidth.Name = "nudLineWidth";
			this.nudLineWidth.Size = new System.Drawing.Size(39, 20);
			this.nudLineWidth.TabIndex = 5;
			this.nudLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// pForeColor
			// 
			this.pForeColor.BackColor = System.Drawing.Color.Black;
			this.pForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pForeColor.Location = new System.Drawing.Point(65, 55);
			this.pForeColor.Name = "pForeColor";
			this.pForeColor.Size = new System.Drawing.Size(15, 15);
			this.pForeColor.TabIndex = 4;
			this.pForeColor.DoubleClick += new System.EventHandler(this.pForeColor_DoubleClick);
			// 
			// rbEllipse
			// 
			this.rbEllipse.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbEllipse.AutoSize = true;
			this.rbEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rbEllipse.Location = new System.Drawing.Point(78, 19);
			this.rbEllipse.Name = "rbEllipse";
			this.rbEllipse.Size = new System.Drawing.Size(47, 23);
			this.rbEllipse.TabIndex = 3;
			this.rbEllipse.Text = "Ellipse";
			this.rbEllipse.UseVisualStyleBackColor = true;
			// 
			// rbText
			// 
			this.rbText.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbText.AutoSize = true;
			this.rbText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rbText.Location = new System.Drawing.Point(9, 138);
			this.rbText.Name = "rbText";
			this.rbText.Size = new System.Drawing.Size(38, 23);
			this.rbText.TabIndex = 2;
			this.rbText.Text = "Text";
			this.rbText.UseVisualStyleBackColor = true;
			this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
			// 
			// rbRectangle
			// 
			this.rbRectangle.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbRectangle.AutoSize = true;
			this.rbRectangle.Checked = true;
			this.rbRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rbRectangle.Location = new System.Drawing.Point(6, 19);
			this.rbRectangle.Name = "rbRectangle";
			this.rbRectangle.Size = new System.Drawing.Size(66, 23);
			this.rbRectangle.TabIndex = 1;
			this.rbRectangle.TabStop = true;
			this.rbRectangle.Text = "Rectangle";
			this.rbRectangle.UseVisualStyleBackColor = true;
			// 
			// msMenu
			// 
			this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
			this.msMenu.Location = new System.Drawing.Point(0, 0);
			this.msMenu.Name = "msMenu";
			this.msMenu.Size = new System.Drawing.Size(281, 24);
			this.msMenu.TabIndex = 0;
			this.msMenu.Text = "Menu";
			// 
			// tsmiFile
			// 
			this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Load,
            this.tsmi_Save,
            this.tssSeparator,
            this.tsmiExit});
			this.tsmiFile.Name = "tsmiFile";
			this.tsmiFile.Size = new System.Drawing.Size(37, 20);
			this.tsmiFile.Text = "File";
			// 
			// tsmi_Load
			// 
			this.tsmi_Load.Name = "tsmi_Load";
			this.tsmi_Load.Size = new System.Drawing.Size(100, 22);
			this.tsmi_Load.Text = "Load";
			this.tsmi_Load.Click += new System.EventHandler(this.tsmi_Load_Click);
			// 
			// tsmi_Save
			// 
			this.tsmi_Save.Name = "tsmi_Save";
			this.tsmi_Save.Size = new System.Drawing.Size(100, 22);
			this.tsmi_Save.Text = "Save";
			this.tsmi_Save.Click += new System.EventHandler(this.tsmi_Save_Click);
			// 
			// tssSeparator
			// 
			this.tssSeparator.Name = "tssSeparator";
			this.tssSeparator.Size = new System.Drawing.Size(97, 6);
			// 
			// tsmiExit
			// 
			this.tsmiExit.Name = "tsmiExit";
			this.tsmiExit.Size = new System.Drawing.Size(100, 22);
			this.tsmiExit.Text = "Exit";
			this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// fontDialog1
			// 
			this.fontDialog1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.fontDialog1.ShowColor = true;
			// 
			// rbImage
			// 
			this.rbImage.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbImage.AutoSize = true;
			this.rbImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rbImage.Location = new System.Drawing.Point(6, 210);
			this.rbImage.Name = "rbImage";
			this.rbImage.Size = new System.Drawing.Size(46, 23);
			this.rbImage.TabIndex = 16;
			this.rbImage.Text = "Image";
			this.rbImage.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1046, 554);
			this.Controls.Add(this.pMain);
			this.MainMenuStrip = this.msMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Print page editor";
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.pMain.ResumeLayout(false);
			this.pCanvas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
			this.pToolbar.ResumeLayout(false);
			this.pToolbar.PerformLayout();
			this.gbTools.ResumeLayout(false);
			this.gbTools.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
			this.msMenu.ResumeLayout(false);
			this.msMenu.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pMain;
		private System.Windows.Forms.Panel pCanvas;
		private System.Windows.Forms.PictureBox pbCanvas;
		private System.Windows.Forms.Panel pToolbar;
		private System.Windows.Forms.MenuStrip msMenu;
		private System.Windows.Forms.ToolStripMenuItem tsmiFile;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Load;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Save;
		private System.Windows.Forms.ToolStripSeparator tssSeparator;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
		private System.Windows.Forms.GroupBox gbTools;
		private System.Windows.Forms.RadioButton rbEllipse;
		private System.Windows.Forms.RadioButton rbText;
		private System.Windows.Forms.RadioButton rbRectangle;
		private System.Windows.Forms.Panel pForeColor;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.NumericUpDown nudLineWidth;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label lblLineWidth;
		private System.Windows.Forms.Label lblLineColor;
		private System.Windows.Forms.Label lblFont;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.ComboBox cbFontSize;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.TextBox tbText;
		private System.Windows.Forms.NumericUpDown nudImageHeight;
		private System.Windows.Forms.NumericUpDown nudImageWidth;
		private System.Windows.Forms.Button btnLoadImage;
		private System.Windows.Forms.RadioButton rbImage;
	}
}

