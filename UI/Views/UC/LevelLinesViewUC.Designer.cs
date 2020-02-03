namespace UI.Views.UC
{
    partial class LevelLinesViewUC
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelLinesViewUC));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.showMapImageBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fillRegionsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.showNodesValuesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeSizeTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.colorOfNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorOfNodeTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.changeColorOfNodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.showLevelsOfLinesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorOfGridTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.changeGridColorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridLineSizeTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.fontTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lineSizeTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.rebuildTxt = new System.Windows.Forms.ToolStripLabel();
            this.levelToRebuildTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.rebuildLevelBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMapImageBtn,
            this.toolStripSeparator1,
            this.fillRegionsBtn,
            this.toolStripSeparator2,
            this.toolStripSplitButton1,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.lineSizeTxtBox,
            this.toolStripSeparator7,
            this.rebuildTxt,
            this.levelToRebuildTxtBox,
            this.rebuildLevelBtn,
            this.toolStripSeparator8,
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1150, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // showMapImageBtn
            // 
            this.showMapImageBtn.Checked = true;
            this.showMapImageBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMapImageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showMapImageBtn.Image = ((System.Drawing.Image)(resources.GetObject("showMapImageBtn.Image")));
            this.showMapImageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showMapImageBtn.Name = "showMapImageBtn";
            this.showMapImageBtn.Size = new System.Drawing.Size(103, 22);
            this.showMapImageBtn.Text = "Show map image";
            this.showMapImageBtn.Click += new System.EventHandler(this.ShowMapImageBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // fillRegionsBtn
            // 
            this.fillRegionsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillRegionsBtn.Enabled = false;
            this.fillRegionsBtn.Image = ((System.Drawing.Image)(resources.GetObject("fillRegionsBtn.Image")));
            this.fillRegionsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillRegionsBtn.Name = "fillRegionsBtn";
            this.fillRegionsBtn.Size = new System.Drawing.Size(68, 22);
            this.fillRegionsBtn.Text = "Fill regions";
            this.fillRegionsBtn.Click += new System.EventHandler(this.FillRegionsBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showNodesValuesBtn,
            this.showLevelsOfLinesBtn,
            this.showGridBtn,
            this.toolStripSeparator3,
            this.fontBtn});
            this.toolStripSplitButton1.Enabled = false;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(130, 22);
            this.toolStripSplitButton1.Text = "Information on map";
            // 
            // showNodesValuesBtn
            // 
            this.showNodesValuesBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nodeSizeToolStripMenuItem,
            this.colorOfNodeToolStripMenuItem});
            this.showNodesValuesBtn.Name = "showNodesValuesBtn";
            this.showNodesValuesBtn.Size = new System.Drawing.Size(176, 22);
            this.showNodesValuesBtn.Text = "Show nodes values";
            this.showNodesValuesBtn.Click += new System.EventHandler(this.ShowMapComponentBtn_Click);
            // 
            // nodeSizeToolStripMenuItem
            // 
            this.nodeSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nodeSizeTxtBox});
            this.nodeSizeToolStripMenuItem.Name = "nodeSizeToolStripMenuItem";
            this.nodeSizeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.nodeSizeToolStripMenuItem.Text = "Node size";
            // 
            // nodeSizeTxtBox
            // 
            this.nodeSizeTxtBox.Name = "nodeSizeTxtBox";
            this.nodeSizeTxtBox.Size = new System.Drawing.Size(35, 23);
            // 
            // colorOfNodeToolStripMenuItem
            // 
            this.colorOfNodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorOfNodeTxtBox,
            this.toolStripSeparator5,
            this.changeColorOfNodeBtn});
            this.colorOfNodeToolStripMenuItem.Name = "colorOfNodeToolStripMenuItem";
            this.colorOfNodeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.colorOfNodeToolStripMenuItem.Text = "Color of node";
            // 
            // colorOfNodeTxtBox
            // 
            this.colorOfNodeTxtBox.Name = "colorOfNodeTxtBox";
            this.colorOfNodeTxtBox.Size = new System.Drawing.Size(100, 23);
            this.colorOfNodeTxtBox.Text = "Blue";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // changeColorOfNodeBtn
            // 
            this.changeColorOfNodeBtn.Name = "changeColorOfNodeBtn";
            this.changeColorOfNodeBtn.Size = new System.Drawing.Size(160, 22);
            this.changeColorOfNodeBtn.Text = "Change";
            this.changeColorOfNodeBtn.Click += new System.EventHandler(this.ChangeColorOfMapComponentBtn_Click);
            // 
            // showLevelsOfLinesBtn
            // 
            this.showLevelsOfLinesBtn.Name = "showLevelsOfLinesBtn";
            this.showLevelsOfLinesBtn.Size = new System.Drawing.Size(176, 22);
            this.showLevelsOfLinesBtn.Text = "Show levels of lines";
            this.showLevelsOfLinesBtn.Click += new System.EventHandler(this.ShowMapComponentBtn_Click);
            // 
            // showGridBtn
            // 
            this.showGridBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.lineSizeToolStripMenuItem});
            this.showGridBtn.Name = "showGridBtn";
            this.showGridBtn.Size = new System.Drawing.Size(176, 22);
            this.showGridBtn.Text = "Show grid";
            this.showGridBtn.Click += new System.EventHandler(this.ShowMapComponentBtn_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorOfGridTxtBox,
            this.toolStripSeparator6,
            this.changeGridColorBtn});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // colorOfGridTxtBox
            // 
            this.colorOfGridTxtBox.Name = "colorOfGridTxtBox";
            this.colorOfGridTxtBox.Size = new System.Drawing.Size(100, 23);
            this.colorOfGridTxtBox.Text = "Orange";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
            // 
            // changeGridColorBtn
            // 
            this.changeGridColorBtn.Name = "changeGridColorBtn";
            this.changeGridColorBtn.Size = new System.Drawing.Size(160, 22);
            this.changeGridColorBtn.Text = "Change";
            this.changeGridColorBtn.Click += new System.EventHandler(this.ChangeColorOfMapComponentBtn_Click);
            // 
            // lineSizeToolStripMenuItem
            // 
            this.lineSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridLineSizeTxtBox});
            this.lineSizeToolStripMenuItem.Name = "lineSizeToolStripMenuItem";
            this.lineSizeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.lineSizeToolStripMenuItem.Text = "Line size";
            // 
            // gridLineSizeTxtBox
            // 
            this.gridLineSizeTxtBox.Name = "gridLineSizeTxtBox";
            this.gridLineSizeTxtBox.Size = new System.Drawing.Size(35, 23);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // fontBtn
            // 
            this.fontBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontTxtBox});
            this.fontBtn.Name = "fontBtn";
            this.fontBtn.Size = new System.Drawing.Size(176, 22);
            this.fontBtn.Text = "Font";
            this.fontBtn.Click += new System.EventHandler(this.FontBtn_Click);
            // 
            // fontTxtBox
            // 
            this.fontTxtBox.Name = "fontTxtBox";
            this.fontTxtBox.ReadOnly = true;
            this.fontTxtBox.Size = new System.Drawing.Size(220, 23);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Enabled = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel1.Text = "Line size:";
            // 
            // lineSizeTxtBox
            // 
            this.lineSizeTxtBox.Enabled = false;
            this.lineSizeTxtBox.Name = "lineSizeTxtBox";
            this.lineSizeTxtBox.Size = new System.Drawing.Size(35, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // rebuildTxt
            // 
            this.rebuildTxt.Name = "rebuildTxt";
            this.rebuildTxt.Size = new System.Drawing.Size(77, 22);
            this.rebuildTxt.Text = "Rebuild level:";
            this.rebuildTxt.Visible = false;
            // 
            // levelToRebuildTxtBox
            // 
            this.levelToRebuildTxtBox.Name = "levelToRebuildTxtBox";
            this.levelToRebuildTxtBox.Size = new System.Drawing.Size(35, 25);
            this.levelToRebuildTxtBox.Visible = false;
            // 
            // rebuildLevelBtn
            // 
            this.rebuildLevelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rebuildLevelBtn.Image = ((System.Drawing.Image)(resources.GetObject("rebuildLevelBtn.Image")));
            this.rebuildLevelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rebuildLevelBtn.Name = "rebuildLevelBtn";
            this.rebuildLevelBtn.Size = new System.Drawing.Size(51, 22);
            this.rebuildLevelBtn.Text = "Rebuild";
            this.rebuildLevelBtn.Visible = false;
            this.rebuildLevelBtn.Click += new System.EventHandler(this.RebuildLevelBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton1.Text = "Clear";
            this.toolStripButton1.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 25);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1150, 657);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // LevelLinesViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Name = "LevelLinesViewUC";
            this.Size = new System.Drawing.Size(1150, 682);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton showMapImageBtn;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton fillRegionsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem showNodesValuesBtn;
        private System.Windows.Forms.ToolStripMenuItem showLevelsOfLinesBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fontBtn;
        private System.Windows.Forms.ToolStripTextBox fontTxtBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox lineSizeTxtBox;
        private System.Windows.Forms.ToolStripMenuItem nodeSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox nodeSizeTxtBox;
        private System.Windows.Forms.ToolStripMenuItem colorOfNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox colorOfNodeTxtBox;
        private System.Windows.Forms.ToolStripMenuItem changeColorOfNodeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showGridBtn;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox colorOfGridTxtBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem changeGridColorBtn;
        private System.Windows.Forms.ToolStripMenuItem lineSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox gridLineSizeTxtBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel rebuildTxt;
        private System.Windows.Forms.ToolStripTextBox levelToRebuildTxtBox;
        private System.Windows.Forms.ToolStripButton rebuildLevelBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
