namespace UI.Views.Forms
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNodesLevelsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editLevelLineBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editLevelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.buildLevelLinesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.goNextBtn = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.buildLevelLinesBtn});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1150, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapBtn,
            this.openMapBtn,
            this.toolStripSeparator1,
            this.saveImageBtn,
            this.toolStripSeparator2,
            this.exitBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createMapBtn
            // 
            this.createMapBtn.Name = "createMapBtn";
            this.createMapBtn.Size = new System.Drawing.Size(180, 22);
            this.createMapBtn.Text = "Create map";
            this.createMapBtn.Click += new System.EventHandler(this.CreateMapBtn_Click);
            // 
            // openMapBtn
            // 
            this.openMapBtn.Name = "openMapBtn";
            this.openMapBtn.Size = new System.Drawing.Size(180, 22);
            this.openMapBtn.Text = "Open map";
            this.openMapBtn.Click += new System.EventHandler(this.OpenMapBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(180, 22);
            this.saveImageBtn.Text = "Save image";
            this.saveImageBtn.Click += new System.EventHandler(this.SaveImageBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(180, 22);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editNodesLevelsBtn,
            this.toolStripSeparator3,
            this.editLevelLineBtn,
            this.editLevelBtn});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editNodesLevelsBtn
            // 
            this.editNodesLevelsBtn.Name = "editNodesLevelsBtn";
            this.editNodesLevelsBtn.Size = new System.Drawing.Size(140, 22);
            this.editNodesLevelsBtn.Text = "Nodes levels";
            this.editNodesLevelsBtn.Click += new System.EventHandler(this.EditNodesLevelsBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // editLevelLineBtn
            // 
            this.editLevelLineBtn.Enabled = false;
            this.editLevelLineBtn.Name = "editLevelLineBtn";
            this.editLevelLineBtn.Size = new System.Drawing.Size(140, 22);
            this.editLevelLineBtn.Text = "Level Line";
            this.editLevelLineBtn.Click += new System.EventHandler(this.EditLevelLineBtn_Click);
            // 
            // editLevelBtn
            // 
            this.editLevelBtn.Enabled = false;
            this.editLevelBtn.Name = "editLevelBtn";
            this.editLevelBtn.Size = new System.Drawing.Size(140, 22);
            this.editLevelBtn.Text = "Level";
            this.editLevelBtn.Click += new System.EventHandler(this.EditLevelBtn_Click);
            // 
            // buildLevelLinesBtn
            // 
            this.buildLevelLinesBtn.Name = "buildLevelLinesBtn";
            this.buildLevelLinesBtn.Size = new System.Drawing.Size(100, 20);
            this.buildLevelLinesBtn.Text = "Build level lines";
            this.buildLevelLinesBtn.Click += new System.EventHandler(this.BuildLevelLinesBtn_Click);
            // 
            // goNextBtn
            // 
            this.goNextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goNextBtn.Location = new System.Drawing.Point(376, 708);
            this.goNextBtn.Name = "goNextBtn";
            this.goNextBtn.Size = new System.Drawing.Size(398, 20);
            this.goNextBtn.TabIndex = 2;
            this.goNextBtn.Text = "Go next";
            this.goNextBtn.UseVisualStyleBackColor = true;
            this.goNextBtn.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 706);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1150, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 728);
            this.Controls.Add(this.goNextBtn);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapBtn;
        private System.Windows.Forms.ToolStripMenuItem createMapBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveImageBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editNodesLevelsBtn;
        private System.Windows.Forms.ToolStripMenuItem editLevelLineBtn;
        private System.Windows.Forms.ToolStripMenuItem buildLevelLinesBtn;
        private System.Windows.Forms.ToolStripMenuItem editLevelBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button goNextBtn;
        private System.Windows.Forms.StatusStrip statusStrip;
    }
}