namespace UI.Views.Forms.ToolForm
{
    partial class LevelRegionToolForm
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.colorPnl = new System.Windows.Forms.Panel();
            this.undoRegionBtn = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.transparencyTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Red;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current color:";
            // 
            // colorPnl
            // 
            this.colorPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorPnl.Location = new System.Drawing.Point(85, 12);
            this.colorPnl.Name = "colorPnl";
            this.colorPnl.Size = new System.Drawing.Size(23, 23);
            this.colorPnl.TabIndex = 1;
            // 
            // undoRegionBtn
            // 
            this.undoRegionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.undoRegionBtn.Location = new System.Drawing.Point(12, 156);
            this.undoRegionBtn.Name = "undoRegionBtn";
            this.undoRegionBtn.Size = new System.Drawing.Size(96, 23);
            this.undoRegionBtn.TabIndex = 0;
            this.undoRegionBtn.Text = "Undo region";
            this.undoRegionBtn.UseVisualStyleBackColor = true;
            this.undoRegionBtn.Click += new System.EventHandler(this.UndoRegionBtn_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(4, 27);
            this.trackBar.Maximum = 255;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(137, 45);
            this.trackBar.TabIndex = 1;
            this.trackBar.TickFrequency = 5;
            this.trackBar.Value = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.transparencyTxtBox);
            this.groupBox1.Controls.Add(this.trackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 79);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transparency";
            // 
            // transparencyTxtBox
            // 
            this.transparencyTxtBox.BackColor = System.Drawing.SystemColors.Control;
            this.transparencyTxtBox.Location = new System.Drawing.Point(147, 27);
            this.transparencyTxtBox.Name = "transparencyTxtBox";
            this.transparencyTxtBox.Size = new System.Drawing.Size(45, 20);
            this.transparencyTxtBox.TabIndex = 4;
            this.transparencyTxtBox.TextChanged += new System.EventHandler(this.TransparencyTxtBox_TextChanged);
            // 
            // LevelRegionToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 190);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.undoRegionBtn);
            this.Controls.Add(this.colorPnl);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelRegionToolForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegionsToolForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel colorPnl;
        private System.Windows.Forms.Button undoRegionBtn;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox transparencyTxtBox;
    }
}