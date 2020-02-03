using Isoline;
using SouthernBughIsoline.UI.Views.UC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views
{
    public class LevelLineView
    {
        private LevelLine line;
        private PointUC[] pointsViews;

        public LevelLineView(LevelLine line)
        {
            this.line = line;

            pointsViews = new PointUC[line.Points.Length];

            for (int i = 0; i < pointsViews.Length; i++)
            {
                pointsViews[i] = new PointUC(line.Points[i]);
                pointsViews[i].MouseDown += PointUC_MouseDown;
                pointsViews[i].MouseMove += PointUC_MouseMove;
                pointsViews[i].MouseUp += PointUC_MouseUp;
            }
        }

        public event EventHandler LevelLineViewPointMouseDown;
        public event EventHandler LevelLineViewPointMouseMove;
        public event EventHandler LevelLineViewPointMouseUp;

        public List<PointUC> PointUCs { get => new List<PointUC>(pointsViews); }
        public List<PointF> Points
        {
            get
            {
                for (int i = 0; i < pointsViews.Length; i++)
                {
                    line.Points[i] = pointsViews[i].Center;
                }

                return new List<PointF>(line.Points);
            }
        }

        public void Draw(Graphics canvas)
        {
            canvas.DrawCurve(Pens.Black, line.Points);
        }

        private void PointUC_MouseDown(object sender, MouseEventArgs e)
        {
            LevelLineViewPointMouseDown?.Invoke(sender, e);
        }

        private void PointUC_MouseMove(object sender, MouseEventArgs e)
        {
            LevelLineViewPointMouseMove?.Invoke(sender, e);
        }

        private void PointUC_MouseUp(object sender, MouseEventArgs e)
        {
            LevelLineViewPointMouseUp?.Invoke(sender, e);
        }
    }
}
