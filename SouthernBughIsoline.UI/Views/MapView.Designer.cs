namespace SouthernBughIsoline.UI.Views
{
    partial class MapView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loadMapBtn = new System.Windows.Forms.ToolStripButton();
            this.buildLevelLinesBtn = new System.Windows.Forms.ToolStripButton();
            this.mapImagePanel = new System.Windows.Forms.Panel();
            this.saveMapBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapBtn,
            this.saveMapBtn,
            this.buildLevelLinesBtn,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(830, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // loadMapBtn
            // 
            this.loadMapBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("loadMapBtn.Image")));
            this.loadMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadMapBtn.Name = "loadMapBtn";
            this.loadMapBtn.Size = new System.Drawing.Size(64, 22);
            this.loadMapBtn.Text = "Load map";
            // 
            // buildLevelLinesBtn
            // 
            this.buildLevelLinesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buildLevelLinesBtn.Image = ((System.Drawing.Image)(resources.GetObject("buildLevelLinesBtn.Image")));
            this.buildLevelLinesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buildLevelLinesBtn.Name = "buildLevelLinesBtn";
            this.buildLevelLinesBtn.Size = new System.Drawing.Size(92, 22);
            this.buildLevelLinesBtn.Text = "Build level lines";
            // 
            // mapImagePanel
            // 
            this.mapImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapImagePanel.Location = new System.Drawing.Point(0, 25);
            this.mapImagePanel.Name = "mapImagePanel";
            this.mapImagePanel.Size = new System.Drawing.Size(830, 499);
            this.mapImagePanel.TabIndex = 1;
            // 
            // saveMapBtn
            // 
            this.saveMapBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveMapBtn.Image")));
            this.saveMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveMapBtn.Name = "saveMapBtn";
            this.saveMapBtn.Size = new System.Drawing.Size(62, 22);
            this.saveMapBtn.Text = "Save map";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(98, 22);
            this.toolStripButton1.Text = "Open MainForm";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 524);
            this.Controls.Add(this.mapImagePanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MapView";
            this.Text = "MapView";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadMapBtn;
        private System.Windows.Forms.Panel mapImagePanel;
        private System.Windows.Forms.ToolStripButton buildLevelLinesBtn;
        private System.Windows.Forms.ToolStripButton saveMapBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}