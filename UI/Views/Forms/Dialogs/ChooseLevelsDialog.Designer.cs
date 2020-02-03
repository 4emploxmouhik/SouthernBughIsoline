namespace UI.Views.Forms.Dialogs
{
    partial class ChooseLevelsDialog
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.fromTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setStepRadBtn = new System.Windows.Forms.RadioButton();
            this.toTxtBox = new System.Windows.Forms.TextBox();
            this.stepTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.levelsStepGrpBox = new System.Windows.Forms.GroupBox();
            this.levelsListTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.setLevelsListRadBtn = new System.Windows.Forms.RadioButton();
            this.levelsListGrpBox = new System.Windows.Forms.GroupBox();
            this.levelsStepGrpBox.SuspendLayout();
            this.levelsListGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(279, 249);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(12, 249);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // fromTxtBox
            // 
            this.fromTxtBox.Location = new System.Drawing.Point(82, 32);
            this.fromTxtBox.Name = "fromTxtBox";
            this.fromTxtBox.Size = new System.Drawing.Size(46, 20);
            this.fromTxtBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // setStepRadBtn
            // 
            this.setStepRadBtn.AutoSize = true;
            this.setStepRadBtn.Checked = true;
            this.setStepRadBtn.Location = new System.Drawing.Point(98, 12);
            this.setStepRadBtn.Name = "setStepRadBtn";
            this.setStepRadBtn.Size = new System.Drawing.Size(75, 17);
            this.setStepRadBtn.TabIndex = 4;
            this.setStepRadBtn.TabStop = true;
            this.setStepRadBtn.Tag = "step";
            this.setStepRadBtn.Text = "Set step  /";
            this.setStepRadBtn.UseVisualStyleBackColor = true;
            this.setStepRadBtn.Click += new System.EventHandler(this.SetLevelsRadBtn_Click);
            // 
            // toTxtBox
            // 
            this.toTxtBox.Location = new System.Drawing.Point(163, 32);
            this.toTxtBox.Name = "toTxtBox";
            this.toTxtBox.Size = new System.Drawing.Size(46, 20);
            this.toTxtBox.TabIndex = 5;
            // 
            // stepTxtBox
            // 
            this.stepTxtBox.Location = new System.Drawing.Point(253, 32);
            this.stepTxtBox.Name = "stepTxtBox";
            this.stepTxtBox.Size = new System.Drawing.Size(46, 20);
            this.stepTxtBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Step:";
            // 
            // levelsStepGrpBox
            // 
            this.levelsStepGrpBox.Controls.Add(this.stepTxtBox);
            this.levelsStepGrpBox.Controls.Add(this.fromTxtBox);
            this.levelsStepGrpBox.Controls.Add(this.label1);
            this.levelsStepGrpBox.Controls.Add(this.label3);
            this.levelsStepGrpBox.Controls.Add(this.toTxtBox);
            this.levelsStepGrpBox.Controls.Add(this.label2);
            this.levelsStepGrpBox.Location = new System.Drawing.Point(12, 57);
            this.levelsStepGrpBox.Name = "levelsStepGrpBox";
            this.levelsStepGrpBox.Size = new System.Drawing.Size(340, 75);
            this.levelsStepGrpBox.TabIndex = 9;
            this.levelsStepGrpBox.TabStop = false;
            this.levelsStepGrpBox.Text = "Write minimum and maximum levels, and step";
            // 
            // levelsListTxtBox
            // 
            this.levelsListTxtBox.Location = new System.Drawing.Point(18, 32);
            this.levelsListTxtBox.Name = "levelsListTxtBox";
            this.levelsListTxtBox.Size = new System.Drawing.Size(306, 20);
            this.levelsListTxtBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 11;
            // 
            // setLevelsListRadBtn
            // 
            this.setLevelsListRadBtn.AutoSize = true;
            this.setLevelsListRadBtn.Location = new System.Drawing.Point(176, 12);
            this.setLevelsListRadBtn.Name = "setLevelsListRadBtn";
            this.setLevelsListRadBtn.Size = new System.Drawing.Size(86, 17);
            this.setLevelsListRadBtn.TabIndex = 12;
            this.setLevelsListRadBtn.Tag = "list";
            this.setLevelsListRadBtn.Text = "Set levels list";
            this.setLevelsListRadBtn.UseVisualStyleBackColor = true;
            this.setLevelsListRadBtn.Click += new System.EventHandler(this.SetLevelsRadBtn_Click);
            // 
            // levelsListGrpBox
            // 
            this.levelsListGrpBox.Controls.Add(this.levelsListTxtBox);
            this.levelsListGrpBox.Enabled = false;
            this.levelsListGrpBox.Location = new System.Drawing.Point(12, 147);
            this.levelsListGrpBox.Name = "levelsListGrpBox";
            this.levelsListGrpBox.Size = new System.Drawing.Size(340, 71);
            this.levelsListGrpBox.TabIndex = 14;
            this.levelsListGrpBox.TabStop = false;
            this.levelsListGrpBox.Text = "Write levels separated by semicolons, for example (10;0,15;20):";
            // 
            // ChooseLevelsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 284);
            this.Controls.Add(this.levelsListGrpBox);
            this.Controls.Add(this.setLevelsListRadBtn);
            this.Controls.Add(this.setStepRadBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.levelsStepGrpBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseLevelsDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Levels";
            this.levelsStepGrpBox.ResumeLayout(false);
            this.levelsStepGrpBox.PerformLayout();
            this.levelsListGrpBox.ResumeLayout(false);
            this.levelsListGrpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox fromTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton setStepRadBtn;
        private System.Windows.Forms.TextBox toTxtBox;
        private System.Windows.Forms.TextBox stepTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox levelsStepGrpBox;
        private System.Windows.Forms.TextBox levelsListTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton setLevelsListRadBtn;
        private System.Windows.Forms.GroupBox levelsListGrpBox;
    }
}