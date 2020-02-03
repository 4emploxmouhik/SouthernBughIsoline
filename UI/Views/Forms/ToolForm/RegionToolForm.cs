using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.Forms.ToolForm
{
    public partial class LevelRegionToolForm : Form
    {
        public LevelRegionToolForm()
        {
            InitializeComponent();

            transparencyTxtBox.Text = trackBar.Value.ToString();
            
            colorDialog.Color = Color.Red;
            colorPnl.BackColor = colorDialog.Color;
            Color = colorDialog.Color;

            colorPnl.MouseDoubleClick += ColorPnl_MouseDoubleClick;
            trackBar.Scroll += TrackBar_Scroll;
        }

        public event EventHandler UndoRegion;

        public Color Color { get; private set; }
        public int Transparency => trackBar.Value;

        private void ColorPnl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorPnl.BackColor = colorDialog.Color;
                Color = Color.FromArgb(Transparency, colorDialog.Color);
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            transparencyTxtBox.Text = trackBar.Value.ToString();
        }

        private void TransparencyTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (transparencyTxtBox.Focused)
                trackBar.Value = Convert.ToInt32(transparencyTxtBox.Text);
        }
        
        private void UndoRegionBtn_Click(object sender, EventArgs e)
        {
            UndoRegion?.Invoke(sender, e);
        }

       
    }
}
