using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.UC
{
    public partial class PointUC : UserControl, IComponent
    {
        public PointUC()
        {
            InitializeComponent();
        }

        public bool IsDown { get; set; } = false;

        public PointF Center
        {
            get => new PointF(Location.X + Width / 2, Location.Y + Height / 2);
        }

        public void SetLocation(PointF locationOfCenter)
        {
            // TODO: Добавить проверку входных параметров.
            Location = new Point((int)locationOfCenter.X - Width / 2, (int)locationOfCenter.Y - Height / 2);
        }

    }
}
