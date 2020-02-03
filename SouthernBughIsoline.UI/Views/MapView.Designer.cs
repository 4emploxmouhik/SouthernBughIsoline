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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.createMapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.setValuesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.setValuesFromDatabaseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.setValuesByYourselfBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.bulidMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildStepByStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildByLevelsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.byLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editLevelLinesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mapImagePnl = new System.Windows.Forms.Panel();
            this.goNextBtn = new System.Windows.Forms.Button();
            this.rebuildBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.mapImagePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1245, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileBtn,
            this.setValuesBtn,
            this.bulidMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1245, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileBtn
            // 
            this.fileBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapBtn,
            this.openMapBtn,
            this.editMapToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveImageBtn,
            this.toolStripSeparator2,
            this.exitBtn});
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(37, 20);
            this.fileBtn.Text = "File";
            // 
            // createMapBtn
            // 
            this.createMapBtn.Name = "createMapBtn";
            this.createMapBtn.Size = new System.Drawing.Size(135, 22);
            this.createMapBtn.Text = "Create map";
            this.createMapBtn.Click += new System.EventHandler(this.createMapBtn_Click);
            // 
            // openMapBtn
            // 
            this.openMapBtn.Name = "openMapBtn";
            this.openMapBtn.Size = new System.Drawing.Size(135, 22);
            this.openMapBtn.Text = "Open map";
            this.openMapBtn.Click += new System.EventHandler(this.openMapBtn_Click);
            // 
            // editMapToolStripMenuItem
            // 
            this.editMapToolStripMenuItem.Name = "editMapToolStripMenuItem";
            this.editMapToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.editMapToolStripMenuItem.Text = "Edit map";
            this.editMapToolStripMenuItem.Click += new System.EventHandler(this.editMapBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(132, 6);
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(135, 22);
            this.saveImageBtn.Text = "Save image";
            this.saveImageBtn.Click += new System.EventHandler(this.saveImageBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(132, 6);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(135, 22);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // setValuesBtn
            // 
            this.setValuesBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setValuesFromDatabaseBtn,
            this.setValuesByYourselfBtn});
            this.setValuesBtn.Name = "setValuesBtn";
            this.setValuesBtn.Size = new System.Drawing.Size(120, 20);
            this.setValuesBtn.Text = "Set values of nodes";
            // 
            // setValuesFromDatabaseBtn
            // 
            this.setValuesFromDatabaseBtn.Enabled = false;
            this.setValuesFromDatabaseBtn.Name = "setValuesFromDatabaseBtn";
            this.setValuesFromDatabaseBtn.Size = new System.Drawing.Size(180, 22);
            this.setValuesFromDatabaseBtn.Text = "From database";
            // 
            // setValuesByYourselfBtn
            // 
            this.setValuesByYourselfBtn.Name = "setValuesByYourselfBtn";
            this.setValuesByYourselfBtn.Size = new System.Drawing.Size(180, 22);
            this.setValuesByYourselfBtn.Text = "By yourself";
            this.setValuesByYourselfBtn.Click += new System.EventHandler(this.setValuesByYourselfBtn_Click);
            // 
            // bulidMenuItem
            // 
            this.bulidMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildAllToolStripMenuItem,
            this.buildStepByStepToolStripMenuItem,
            this.toolStripSeparator1,
            this.editLevelLinesBtn});
            this.bulidMenuItem.Name = "bulidMenuItem";
            this.bulidMenuItem.Size = new System.Drawing.Size(73, 20);
            this.bulidMenuItem.Text = "Level lines";
            // 
            // buildAllToolStripMenuItem
            // 
            this.buildAllToolStripMenuItem.Name = "buildAllToolStripMenuItem";
            this.buildAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.buildAllToolStripMenuItem.Text = "Build all";
            this.buildAllToolStripMenuItem.Click += new System.EventHandler(this.buildAllBtn_Click);
            // 
            // buildStepByStepToolStripMenuItem
            // 
            this.buildStepByStepToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildByLevelsBtn,
            this.byLinesToolStripMenuItem});
            this.buildStepByStepToolStripMenuItem.Name = "buildStepByStepToolStripMenuItem";
            this.buildStepByStepToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.buildStepByStepToolStripMenuItem.Text = "Build step by step";
            // 
            // buildByLevelsBtn
            // 
            this.buildByLevelsBtn.Name = "buildByLevelsBtn";
            this.buildByLevelsBtn.Size = new System.Drawing.Size(119, 22);
            this.buildByLevelsBtn.Text = "By levels";
            this.buildByLevelsBtn.Click += new System.EventHandler(this.buildByLevelsBtn_Click);
            // 
            // byLinesToolStripMenuItem
            // 
            this.byLinesToolStripMenuItem.Enabled = false;
            this.byLinesToolStripMenuItem.Name = "byLinesToolStripMenuItem";
            this.byLinesToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.byLinesToolStripMenuItem.Text = "By lines";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // editLevelLinesBtn
            // 
            this.editLevelLinesBtn.Name = "editLevelLinesBtn";
            this.editLevelLinesBtn.Size = new System.Drawing.Size(167, 22);
            this.editLevelLinesBtn.Text = "Edit level lines";
            this.editLevelLinesBtn.Click += new System.EventHandler(this.editLevelLinesBtn_Click);
            // 
            // mapImagePnl
            // 
            this.mapImagePnl.BackColor = System.Drawing.Color.Transparent;
            this.mapImagePnl.Controls.Add(this.goNextBtn);
            this.mapImagePnl.Controls.Add(this.rebuildBtn);
            this.mapImagePnl.Controls.Add(this.cancelBtn);
            this.mapImagePnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapImagePnl.Location = new System.Drawing.Point(0, 24);
            this.mapImagePnl.Name = "mapImagePnl";
            this.mapImagePnl.Size = new System.Drawing.Size(1245, 715);
            this.mapImagePnl.TabIndex = 8;
            this.mapImagePnl.Paint += new System.Windows.Forms.PaintEventHandler(this.mapImagePnl_Paint);
            this.mapImagePnl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapImagePnl_MouseClick);
            // 
            // goNextBtn
            // 
            this.goNextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.goNextBtn.Location = new System.Drawing.Point(1158, 659);
            this.goNextBtn.Name = "goNextBtn";
            this.goNextBtn.Size = new System.Drawing.Size(75, 42);
            this.goNextBtn.TabIndex = 11;
            this.goNextBtn.Text = "Go Next";
            this.goNextBtn.UseVisualStyleBackColor = true;
            this.goNextBtn.Visible = false;
            this.goNextBtn.Click += new System.EventHandler(this.goNextBtnCreateMap_Click);
            // 
            // rebuildBtn
            // 
            this.rebuildBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rebuildBtn.Location = new System.Drawing.Point(1077, 659);
            this.rebuildBtn.Name = "rebuildBtn";
            this.rebuildBtn.Size = new System.Drawing.Size(75, 42);
            this.rebuildBtn.TabIndex = 10;
            this.rebuildBtn.Text = "Rebuild";
            this.rebuildBtn.UseVisualStyleBackColor = true;
            this.rebuildBtn.Visible = false;
            this.rebuildBtn.Click += new System.EventHandler(this.rebuildBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(996, 659);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 42);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 761);
            this.Controls.Add(this.mapImagePnl);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MapView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapView";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mapImagePnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileBtn;
        private System.Windows.Forms.ToolStripMenuItem createMapBtn;
        private System.Windows.Forms.ToolStripMenuItem openMapBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveImageBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private System.Windows.Forms.ToolStripMenuItem bulidMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildStepByStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildByLevelsBtn;
        private System.Windows.Forms.ToolStripMenuItem byLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setValuesBtn;
        private System.Windows.Forms.ToolStripMenuItem setValuesFromDatabaseBtn;
        private System.Windows.Forms.ToolStripMenuItem setValuesByYourselfBtn;
        private System.Windows.Forms.ToolStripMenuItem editMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editLevelLinesBtn;
        private System.Windows.Forms.Panel mapImagePnl;
        private System.Windows.Forms.Button goNextBtn;
        private System.Windows.Forms.Button rebuildBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}