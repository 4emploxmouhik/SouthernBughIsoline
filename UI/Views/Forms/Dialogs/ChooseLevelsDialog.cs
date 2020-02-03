using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.Forms.Dialogs
{
    public partial class ChooseLevelsDialog : Form
    {
        public ChooseLevelsDialog()
        {
            InitializeComponent();
        }

        public List<float> Levels { get; private set; }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            Levels = new List<float>();

            if (setStepRadBtn.Checked)
            {
                float from = (float)Convert.ToDouble(fromTxtBox.Text);
                float to = (float)Convert.ToDouble(toTxtBox.Text);
                float step = (float)Convert.ToDouble(stepTxtBox.Text);

                for (float level = from; level <= to; level += step)
                    Levels.Add(level);

            }

            if (setLevelsListRadBtn.Checked)
            {
                string[] strLevels = levelsListTxtBox.Text.Split(';');

                foreach (var level in strLevels)
                {
                    Levels.Add((float)Convert.ToDouble(level));
                }
            }

            DialogResult = DialogResult.OK;
            Hide();
        }

        private void SetLevelsRadBtn_Click(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Tag)
            {
                case "step":
                    levelsStepGrpBox.Enabled = true;
                    levelsListGrpBox.Enabled = false;
                    break;
                case "list":
                    levelsStepGrpBox.Enabled = false;
                    levelsListGrpBox.Enabled = true;
                    break;
            }
        }
    }
}
