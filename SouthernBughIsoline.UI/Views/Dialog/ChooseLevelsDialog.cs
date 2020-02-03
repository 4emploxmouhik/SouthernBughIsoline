using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views.Dialog
{
    public partial class ChooseLevelsDialog : Form
    {
        public ChooseLevelsDialog()
        {
            InitializeComponent();

            DataGridViewComboBoxColumn comboBoxColummn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Color",
                Name = "Color"
            };

            foreach (var colorName in Enum.GetNames(typeof(KnownColor)))
                comboBoxColummn.Items.Add(colorName);

            dataGridView.Columns.Add("Level", "Level");
            dataGridView.Columns.Add(comboBoxColummn);

            Levels = new List<float>();
            Colors = new List<Color>();
        }

        public List<float> Levels { get; private set; }
        public List<Color> Colors { get; private set; }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var level = row.Cells["Level"].Value;
                var colorName = row.Cells["Color"].Value;

                if (level == null)
                    continue;

                if (string.IsNullOrEmpty((string)colorName))
                    colorName = "Black";

                Levels.Add((float)Convert.ToDouble(level.ToString()));
                Colors.Add(Color.FromName((string)colorName));
            }

            Hide();
            DialogResult = DialogResult.OK;
        }
    }
}
