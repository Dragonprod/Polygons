namespace Polygons
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.triangleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.squareToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.insideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outsideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.radiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.byDefenitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.byJarvisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.colorDialog2 = new System.Windows.Forms.ColorDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.customLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.shapeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.alToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.ShowItemToolTips = true;
			this.menuStrip1.Size = new System.Drawing.Size(722, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.pluginsToolStripMenuItem});
			this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.saveToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// shapeToolStripMenuItem
			// 
			this.shapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.triangleToolStripMenuItem1,
            this.squareToolStripMenuItem1});
			this.shapeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("shapeToolStripMenuItem.Image")));
			this.shapeToolStripMenuItem.Name = "shapeToolStripMenuItem";
			this.shapeToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.shapeToolStripMenuItem.Text = "Shape";
			// 
			// circleToolStripMenuItem
			// 
			this.circleToolStripMenuItem.Checked = true;
			this.circleToolStripMenuItem.CheckOnClick = true;
			this.circleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
			this.circleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.circleToolStripMenuItem.Text = "Circle";
			this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
			// 
			// triangleToolStripMenuItem1
			// 
			this.triangleToolStripMenuItem1.CheckOnClick = true;
			this.triangleToolStripMenuItem1.Name = "triangleToolStripMenuItem1";
			this.triangleToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
			this.triangleToolStripMenuItem1.Text = "Triangle";
			this.triangleToolStripMenuItem1.Click += new System.EventHandler(this.triangleToolStripMenuItem1_Click);
			// 
			// squareToolStripMenuItem1
			// 
			this.squareToolStripMenuItem1.CheckOnClick = true;
			this.squareToolStripMenuItem1.Name = "squareToolStripMenuItem1";
			this.squareToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
			this.squareToolStripMenuItem1.Text = "Square";
			this.squareToolStripMenuItem1.Click += new System.EventHandler(this.squareToolStripMenuItem1_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.radiusToolStripMenuItem});
			this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// colorToolStripMenuItem
			// 
			this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insideToolStripMenuItem,
            this.outsideToolStripMenuItem});
			this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
			this.colorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.colorToolStripMenuItem.Text = "Color";
			// 
			// insideToolStripMenuItem
			// 
			this.insideToolStripMenuItem.Name = "insideToolStripMenuItem";
			this.insideToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.insideToolStripMenuItem.Text = "Inside";
			this.insideToolStripMenuItem.Click += new System.EventHandler(this.insideToolStripMenuItem_Click);
			// 
			// outsideToolStripMenuItem
			// 
			this.outsideToolStripMenuItem.Name = "outsideToolStripMenuItem";
			this.outsideToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.outsideToolStripMenuItem.Text = "Outside";
			this.outsideToolStripMenuItem.Click += new System.EventHandler(this.outsideToolStripMenuItem_Click);
			// 
			// radiusToolStripMenuItem
			// 
			this.radiusToolStripMenuItem.Name = "radiusToolStripMenuItem";
			this.radiusToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.radiusToolStripMenuItem.Text = "Radius";
			this.radiusToolStripMenuItem.Click += new System.EventHandler(this.radiusToolStripMenuItem_Click);
			// 
			// alToolStripMenuItem
			// 
			this.alToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byDefenitionToolStripMenuItem,
            this.byJarvisToolStripMenuItem});
			this.alToolStripMenuItem.Name = "alToolStripMenuItem";
			this.alToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
			this.alToolStripMenuItem.Text = "Algorithm";
			// 
			// byDefenitionToolStripMenuItem
			// 
			this.byDefenitionToolStripMenuItem.CheckOnClick = true;
			this.byDefenitionToolStripMenuItem.Name = "byDefenitionToolStripMenuItem";
			this.byDefenitionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.byDefenitionToolStripMenuItem.Text = "By Defenition";
			this.byDefenitionToolStripMenuItem.Click += new System.EventHandler(this.byDefenitionToolStripMenuItem_Click);
			// 
			// byJarvisToolStripMenuItem
			// 
			this.byJarvisToolStripMenuItem.Checked = true;
			this.byJarvisToolStripMenuItem.CheckOnClick = true;
			this.byJarvisToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.byJarvisToolStripMenuItem.Name = "byJarvisToolStripMenuItem";
			this.byJarvisToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.byJarvisToolStripMenuItem.Text = "By Jarvis";
			this.byJarvisToolStripMenuItem.Click += new System.EventHandler(this.byJarvisToolStripMenuItem_Click);
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.undoToolStripMenuItem.Text = "Undo";
			this.undoToolStripMenuItem.ToolTipText = "Undo (Ctrl+Z)";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.redoToolStripMenuItem.Text = "Redo";
			this.redoToolStripMenuItem.ToolTipText = "Redo (Ctrl+Shift+Bkscpce)";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(636, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(48, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(576, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Interval";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(690, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 15);
			this.label2.TabIndex = 5;
			this.label2.Text = "ms";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// playToolStripMenuItem
			// 
			this.playToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("playToolStripMenuItem.Image")));
			this.playToolStripMenuItem.Name = "playToolStripMenuItem";
			this.playToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.playToolStripMenuItem.Text = "Play";
			this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
			// 
			// pluginsToolStripMenuItem
			// 
			this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.customLoadToolStripMenuItem});
			this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
			this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.pluginsToolStripMenuItem.Text = "Plugins";
			// 
			// loadToolStripMenuItem1
			// 
			this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
			this.loadToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem1.Text = "Load";
			// 
			// customLoadToolStripMenuItem
			// 
			this.customLoadToolStripMenuItem.Name = "customLoadToolStripMenuItem";
			this.customLoadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.customLoadToolStripMenuItem.Text = "Custom Load";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 448);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(738, 487);
			this.Name = "Form1";
			this.Text = "Polygons";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outsideToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ToolStripMenuItem alToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDefenitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byJarvisToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem customLoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
	}
}

