namespace SouthernBughIsoline.UI.Views.Dialog
{
    partial class CreateMapDialog
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
            this.backBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.footerPnl = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.removeRowBtn = new System.Windows.Forms.Button();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.firstStepPnl = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mapSettingsPathBox = new System.Windows.Forms.TextBox();
            this.chooseMapFolderBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imagePathBox = new System.Windows.Forms.TextBox();
            this.chooseImageBtn = new System.Windows.Forms.Button();
            this.footerPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.firstStepPnl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(563, 12);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // footerPnl
            // 
            this.footerPnl.Controls.Add(this.nextBtn);
            this.footerPnl.Controls.Add(this.backBtn);
            this.footerPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPnl.Location = new System.Drawing.Point(0, 358);
            this.footerPnl.Name = "footerPnl";
            this.footerPnl.Size = new System.Drawing.Size(650, 47);
            this.footerPnl.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(547, 358);
            this.dataGridView.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.removeRowBtn);
            this.panel2.Controls.Add(this.addRowBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(547, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(103, 358);
            this.panel2.TabIndex = 2;
            // 
            // removeRowBtn
            // 
            this.removeRowBtn.Location = new System.Drawing.Point(16, 109);
            this.removeRowBtn.Name = "removeRowBtn";
            this.removeRowBtn.Size = new System.Drawing.Size(75, 23);
            this.removeRowBtn.TabIndex = 1;
            this.removeRowBtn.Text = "Remove";
            this.removeRowBtn.UseVisualStyleBackColor = true;
            this.removeRowBtn.Click += new System.EventHandler(this.RemoveRowBtn_Click);
            // 
            // addRowBtn
            // 
            this.addRowBtn.Location = new System.Drawing.Point(16, 52);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(75, 23);
            this.addRowBtn.TabIndex = 0;
            this.addRowBtn.Text = "Add";
            this.addRowBtn.UseVisualStyleBackColor = true;
            this.addRowBtn.Click += new System.EventHandler(this.AddRowBtn_Click);
            // 
            // firstStepPnl
            // 
            this.firstStepPnl.Controls.Add(this.groupBox2);
            this.firstStepPnl.Controls.Add(this.groupBox1);
            this.firstStepPnl.Location = new System.Drawing.Point(0, 0);
            this.firstStepPnl.Name = "firstStepPnl";
            this.firstStepPnl.Size = new System.Drawing.Size(650, 358);
            this.firstStepPnl.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mapSettingsPathBox);
            this.groupBox2.Controls.Add(this.chooseMapFolderBtn);
            this.groupBox2.Location = new System.Drawing.Point(39, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose folder for save map settings file";
            // 
            // mapSettingsPathBox
            // 
            this.mapSettingsPathBox.Location = new System.Drawing.Point(30, 31);
            this.mapSettingsPathBox.Name = "mapSettingsPathBox";
            this.mapSettingsPathBox.Size = new System.Drawing.Size(363, 20);
            this.mapSettingsPathBox.TabIndex = 0;
            // 
            // chooseMapFolderBtn
            // 
            this.chooseMapFolderBtn.Location = new System.Drawing.Point(399, 30);
            this.chooseMapFolderBtn.Name = "chooseMapFolderBtn";
            this.chooseMapFolderBtn.Size = new System.Drawing.Size(26, 23);
            this.chooseMapFolderBtn.TabIndex = 1;
            this.chooseMapFolderBtn.Tag = "saveFile";
            this.chooseMapFolderBtn.Text = "...";
            this.chooseMapFolderBtn.UseVisualStyleBackColor = true;
            this.chooseMapFolderBtn.Click += new System.EventHandler(this.ChoosePathBtn);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imagePathBox);
            this.groupBox1.Controls.Add(this.chooseImageBtn);
            this.groupBox1.Location = new System.Drawing.Point(39, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose image for map";
            // 
            // imagePathBox
            // 
            this.imagePathBox.Location = new System.Drawing.Point(30, 31);
            this.imagePathBox.Name = "imagePathBox";
            this.imagePathBox.Size = new System.Drawing.Size(363, 20);
            this.imagePathBox.TabIndex = 0;
            // 
            // chooseImageBtn
            // 
            this.chooseImageBtn.Location = new System.Drawing.Point(399, 30);
            this.chooseImageBtn.Name = "chooseImageBtn";
            this.chooseImageBtn.Size = new System.Drawing.Size(26, 23);
            this.chooseImageBtn.TabIndex = 1;
            this.chooseImageBtn.Tag = "openFile";
            this.chooseImageBtn.Text = "...";
            this.chooseImageBtn.UseVisualStyleBackColor = true;
            this.chooseImageBtn.Click += new System.EventHandler(this.ChoosePathBtn);
            // 
            // CreateMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 405);
            this.Controls.Add(this.firstStepPnl);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.footerPnl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateMapDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateMapDialog";
            this.footerPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.firstStepPnl.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Panel footerPnl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button removeRowBtn;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.Panel firstStepPnl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox mapSettingsPathBox;
        private System.Windows.Forms.Button chooseMapFolderBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox imagePathBox;
        private System.Windows.Forms.Button chooseImageBtn;
    }
}