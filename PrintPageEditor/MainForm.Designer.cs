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
			this.components = new System.ComponentModel.Container();
			this.pMain = new System.Windows.Forms.Panel();
			this.pCanvas = new System.Windows.Forms.Panel();
			this.pbCanvas = new System.Windows.Forms.PictureBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pToolbar = new System.Windows.Forms.Panel();
			this.gbTools = new System.Windows.Forms.GroupBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpText = new System.Windows.Forms.TabPage();
			this.lblFont = new System.Windows.Forms.Label();
			this.cbFontSize = new System.Windows.Forms.ComboBox();
			this.tbText = new System.Windows.Forms.TextBox();
			this.btnFont = new System.Windows.Forms.Button();
			this.tpShapes = new System.Windows.Forms.TabPage();
			this.rbRectangle = new System.Windows.Forms.RadioButton();
			this.rbEllipse = new System.Windows.Forms.RadioButton();
			this.pForeColor = new System.Windows.Forms.Panel();
			this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
			this.lblLineColor = new System.Windows.Forms.Label();
			this.lblLineWidth = new System.Windows.Forms.Label();
			this.tpImage = new System.Windows.Forms.TabPage();
			this.lblHeight = new System.Windows.Forms.Label();
			this.lblWidth = new System.Windows.Forms.Label();
			this.btnLoadImage = new System.Windows.Forms.Button();
			this.nudImageWidth = new System.Windows.Forms.NumericUpDown();
			this.nudImageHeight = new System.Windows.Forms.NumericUpDown();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.lvPrintables = new System.Windows.Forms.ListView();
			this.chPrintable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chOther = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiDeletePrintable = new System.Windows.Forms.ToolStripMenuItem();
			this.msMenu = new System.Windows.Forms.MenuStrip();
			this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_Load = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.tssSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.pMain.SuspendLayout();
			this.pCanvas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
			this.pToolbar.SuspendLayout();
			this.gbTools.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tpText.SuspendLayout();
			this.tpShapes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
			this.tpImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.msMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// pMain
			// 
			this.pMain.Controls.Add(this.pCanvas);
			this.pMain.Controls.Add(this.splitter1);
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
			this.pCanvas.Size = new System.Drawing.Size(762, 554);
			this.pCanvas.TabIndex = 2;
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
			this.pbCanvas.MouseLeave += new System.EventHandler(this.pbCanvas_MouseLeave);
			this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
			this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(762, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 554);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
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
			this.gbTools.Controls.Add(this.tabControl);
			this.gbTools.Controls.Add(this.statusStrip1);
			this.gbTools.Controls.Add(this.lvPrintables);
			this.gbTools.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbTools.Location = new System.Drawing.Point(0, 24);
			this.gbTools.Name = "gbTools";
			this.gbTools.Size = new System.Drawing.Size(281, 530);
			this.gbTools.TabIndex = 1;
			this.gbTools.TabStop = false;
			this.gbTools.Text = "Tools";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tpText);
			this.tabControl.Controls.Add(this.tpShapes);
			this.tabControl.Controls.Add(this.tpImage);
			this.tabControl.Location = new System.Drawing.Point(3, 19);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(272, 217);
			this.tabControl.TabIndex = 19;
			// 
			// tpText
			// 
			this.tpText.Controls.Add(this.lblFont);
			this.tpText.Controls.Add(this.cbFontSize);
			this.tpText.Controls.Add(this.tbText);
			this.tpText.Controls.Add(this.btnFont);
			this.tpText.Location = new System.Drawing.Point(4, 22);
			this.tpText.Name = "tpText";
			this.tpText.Padding = new System.Windows.Forms.Padding(3);
			this.tpText.Size = new System.Drawing.Size(264, 191);
			this.tpText.TabIndex = 0;
			this.tpText.Text = "Text";
			this.tpText.UseVisualStyleBackColor = true;
			// 
			// lblFont
			// 
			this.lblFont.AutoSize = true;
			this.lblFont.Location = new System.Drawing.Point(3, 13);
			this.lblFont.Name = "lblFont";
			this.lblFont.Size = new System.Drawing.Size(28, 13);
			this.lblFont.TabIndex = 8;
			this.lblFont.Text = "Font";
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
			this.cbFontSize.Location = new System.Drawing.Point(62, 9);
			this.cbFontSize.Name = "cbFontSize";
			this.cbFontSize.Size = new System.Drawing.Size(39, 21);
			this.cbFontSize.TabIndex = 9;
			this.cbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbFontSize_SelectedIndexChanged);
			this.cbFontSize.TextChanged += new System.EventHandler(this.cbFontSize_TextChanged);
			// 
			// tbText
			// 
			this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbText.Location = new System.Drawing.Point(6, 37);
			this.tbText.Multiline = true;
			this.tbText.Name = "tbText";
			this.tbText.Size = new System.Drawing.Size(252, 148);
			this.tbText.TabIndex = 11;
			this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
			// 
			// btnFont
			// 
			this.btnFont.Location = new System.Drawing.Point(37, 8);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(23, 23);
			this.btnFont.TabIndex = 10;
			this.btnFont.Text = "A";
			this.btnFont.UseVisualStyleBackColor = true;
			this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
			// 
			// tpShapes
			// 
			this.tpShapes.Controls.Add(this.rbRectangle);
			this.tpShapes.Controls.Add(this.rbEllipse);
			this.tpShapes.Controls.Add(this.pForeColor);
			this.tpShapes.Controls.Add(this.nudLineWidth);
			this.tpShapes.Controls.Add(this.lblLineColor);
			this.tpShapes.Controls.Add(this.lblLineWidth);
			this.tpShapes.Location = new System.Drawing.Point(4, 22);
			this.tpShapes.Name = "tpShapes";
			this.tpShapes.Padding = new System.Windows.Forms.Padding(3);
			this.tpShapes.Size = new System.Drawing.Size(264, 191);
			this.tpShapes.TabIndex = 1;
			this.tpShapes.Text = "Shapes";
			this.tpShapes.UseVisualStyleBackColor = true;
			// 
			// rbRectangle
			// 
			this.rbRectangle.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbRectangle.AutoSize = true;
			this.rbRectangle.Checked = true;
			this.rbRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rbRectangle.Location = new System.Drawing.Point(6, 16);
			this.rbRectangle.Name = "rbRectangle";
			this.rbRectangle.Size = new System.Drawing.Size(66, 23);
			this.rbRectangle.TabIndex = 1;
			this.rbRectangle.TabStop = true;
			this.rbRectangle.Text = "Rectangle";
			this.rbRectangle.UseVisualStyleBackColor = true;
			// 
			// rbEllipse
			// 
			this.rbEllipse.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbEllipse.AutoSize = true;
			this.rbEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rbEllipse.Location = new System.Drawing.Point(78, 16);
			this.rbEllipse.Name = "rbEllipse";
			this.rbEllipse.Size = new System.Drawing.Size(47, 23);
			this.rbEllipse.TabIndex = 3;
			this.rbEllipse.Text = "Ellipse";
			this.rbEllipse.UseVisualStyleBackColor = true;
			// 
			// pForeColor
			// 
			this.pForeColor.BackColor = System.Drawing.Color.Black;
			this.pForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pForeColor.Location = new System.Drawing.Point(65, 52);
			this.pForeColor.Name = "pForeColor";
			this.pForeColor.Size = new System.Drawing.Size(15, 15);
			this.pForeColor.TabIndex = 4;
			this.pForeColor.DoubleClick += new System.EventHandler(this.pForeColor_DoubleClick);
			// 
			// nudLineWidth
			// 
			this.nudLineWidth.Location = new System.Drawing.Point(191, 50);
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
			// lblLineColor
			// 
			this.lblLineColor.AutoSize = true;
			this.lblLineColor.Location = new System.Drawing.Point(6, 52);
			this.lblLineColor.Name = "lblLineColor";
			this.lblLineColor.Size = new System.Drawing.Size(53, 13);
			this.lblLineColor.TabIndex = 6;
			this.lblLineColor.Text = "Line color";
			// 
			// lblLineWidth
			// 
			this.lblLineWidth.AutoSize = true;
			this.lblLineWidth.Location = new System.Drawing.Point(132, 52);
			this.lblLineWidth.Name = "lblLineWidth";
			this.lblLineWidth.Size = new System.Drawing.Size(55, 13);
			this.lblLineWidth.TabIndex = 7;
			this.lblLineWidth.Text = "Line width";
			// 
			// tpImage
			// 
			this.tpImage.Controls.Add(this.lblHeight);
			this.tpImage.Controls.Add(this.lblWidth);
			this.tpImage.Controls.Add(this.btnLoadImage);
			this.tpImage.Controls.Add(this.nudImageWidth);
			this.tpImage.Controls.Add(this.nudImageHeight);
			this.tpImage.Location = new System.Drawing.Point(4, 22);
			this.tpImage.Name = "tpImage";
			this.tpImage.Size = new System.Drawing.Size(264, 191);
			this.tpImage.TabIndex = 2;
			this.tpImage.Text = "Image";
			this.tpImage.UseVisualStyleBackColor = true;
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(158, 10);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(38, 13);
			this.lblHeight.TabIndex = 17;
			this.lblHeight.Text = "Height";
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(97, 10);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(35, 13);
			this.lblWidth.TabIndex = 16;
			this.lblWidth.Text = "Width";
			// 
			// btnLoadImage
			// 
			this.btnLoadImage.Location = new System.Drawing.Point(4, 25);
			this.btnLoadImage.Name = "btnLoadImage";
			this.btnLoadImage.Size = new System.Drawing.Size(91, 23);
			this.btnLoadImage.TabIndex = 13;
			this.btnLoadImage.Text = "Select image";
			this.btnLoadImage.UseVisualStyleBackColor = true;
			this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
			// 
			// nudImageWidth
			// 
			this.nudImageWidth.Location = new System.Drawing.Point(100, 26);
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
			// nudImageHeight
			// 
			this.nudImageHeight.Location = new System.Drawing.Point(161, 26);
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
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel});
			this.statusStrip1.Location = new System.Drawing.Point(3, 505);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(275, 22);
			this.statusStrip1.TabIndex = 18;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssLabel
			// 
			this.tssLabel.Name = "tssLabel";
			this.tssLabel.Size = new System.Drawing.Size(39, 17);
			this.tssLabel.Text = "Ready";
			// 
			// lvPrintables
			// 
			this.lvPrintables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvPrintables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPrintable,
            this.chX,
            this.chY,
            this.chWidth,
            this.chHeight,
            this.chOther});
			this.lvPrintables.ContextMenuStrip = this.contextMenuStrip1;
			this.lvPrintables.FullRowSelect = true;
			this.lvPrintables.HideSelection = false;
			this.lvPrintables.Location = new System.Drawing.Point(6, 306);
			this.lvPrintables.Name = "lvPrintables";
			this.lvPrintables.Size = new System.Drawing.Size(269, 191);
			this.lvPrintables.TabIndex = 17;
			this.lvPrintables.UseCompatibleStateImageBehavior = false;
			this.lvPrintables.View = System.Windows.Forms.View.Details;
			// 
			// chPrintable
			// 
			this.chPrintable.Text = "Type";
			// 
			// chX
			// 
			this.chX.Text = "X";
			this.chX.Width = 30;
			// 
			// chY
			// 
			this.chY.Text = "Y";
			this.chY.Width = 30;
			// 
			// chWidth
			// 
			this.chWidth.Text = "Width";
			this.chWidth.Width = 45;
			// 
			// chHeight
			// 
			this.chHeight.Text = "Height";
			this.chHeight.Width = 45;
			// 
			// chOther
			// 
			this.chOther.Text = "Other";
			this.chOther.Width = 300;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeletePrintable});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
			// 
			// tsmiDeletePrintable
			// 
			this.tsmiDeletePrintable.Name = "tsmiDeletePrintable";
			this.tsmiDeletePrintable.Size = new System.Drawing.Size(107, 22);
			this.tsmiDeletePrintable.Text = "Delete";
			this.tsmiDeletePrintable.Click += new System.EventHandler(this.tsmiDeletePrintable_Click);
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
            this.tsmiPrint,
            this.tssSeparator,
            this.tsmiExit});
			this.tsmiFile.Name = "tsmiFile";
			this.tsmiFile.Size = new System.Drawing.Size(37, 20);
			this.tsmiFile.Text = "File";
			// 
			// tsmi_Load
			// 
			this.tsmi_Load.Name = "tsmi_Load";
			this.tsmi_Load.Size = new System.Drawing.Size(137, 22);
			this.tsmi_Load.Text = "Load";
			this.tsmi_Load.Click += new System.EventHandler(this.tsmi_Load_Click);
			// 
			// tsmi_Save
			// 
			this.tsmi_Save.Name = "tsmi_Save";
			this.tsmi_Save.Size = new System.Drawing.Size(137, 22);
			this.tsmi_Save.Text = "Save";
			this.tsmi_Save.Click += new System.EventHandler(this.tsmi_Save_Click);
			// 
			// tsmiPrint
			// 
			this.tsmiPrint.Name = "tsmiPrint";
			this.tsmiPrint.Size = new System.Drawing.Size(137, 22);
			this.tsmiPrint.Text = "Print as PDF";
			this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
			// 
			// tssSeparator
			// 
			this.tssSeparator.Name = "tssSeparator";
			this.tssSeparator.Size = new System.Drawing.Size(134, 6);
			// 
			// tsmiExit
			// 
			this.tsmiExit.Name = "tsmiExit";
			this.tsmiExit.Size = new System.Drawing.Size(137, 22);
			this.tsmiExit.Text = "Exit";
			this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.CheckFileExists = true;
			this.saveFileDialog1.CreatePrompt = true;
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
			this.tabControl.ResumeLayout(false);
			this.tpText.ResumeLayout(false);
			this.tpText.PerformLayout();
			this.tpShapes.ResumeLayout(false);
			this.tpShapes.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
			this.tpImage.ResumeLayout(false);
			this.tpImage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.msMenu.ResumeLayout(false);
			this.msMenu.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pMain;
		private System.Windows.Forms.Panel pToolbar;
		private System.Windows.Forms.MenuStrip msMenu;
		private System.Windows.Forms.ToolStripMenuItem tsmiFile;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Load;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Save;
		private System.Windows.Forms.ToolStripSeparator tssSeparator;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
		private System.Windows.Forms.GroupBox gbTools;
		private System.Windows.Forms.RadioButton rbEllipse;
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
		private System.Windows.Forms.ListView lvPrintables;
		private System.Windows.Forms.ColumnHeader chPrintable;
		private System.Windows.Forms.ColumnHeader chX;
		private System.Windows.Forms.ColumnHeader chY;
		private System.Windows.Forms.ColumnHeader chWidth;
		private System.Windows.Forms.ColumnHeader chHeight;
		private System.Windows.Forms.ColumnHeader chOther;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabel;
		private System.Windows.Forms.Panel pCanvas;
		private System.Windows.Forms.PictureBox pbCanvas;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem tsmiDeletePrintable;
		private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tpText;
		private System.Windows.Forms.TabPage tpShapes;
		private System.Windows.Forms.TabPage tpImage;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.Label lblWidth;
	}
}

