using System.Drawing;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views.UC
{
    public partial class PointUC : UserControl
    {
        public PointUC()
        {
            InitializeComponent();
        }

        public PointUC(PointF locationOfCenter) : this()
        {
            SetLocation(locationOfCenter);
        }

        public Point Center
        {
            get
            {
                return new Point(Location.X + Width / 2, Location.Y + Height / 2);
            }
        }
        public bool IsMove { get; set; } = false;

        public void SetLocation(PointF locationOfCenter)
        {
            Location = new Point((int)locationOfCenter.X - Width / 2, (int)locationOfCenter.Y - Height / 2);
        }
    }
}
