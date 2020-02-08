using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Isoline;
using UI.Views.Containers;
using UI.Controllers;
using System.Collections;
using UI.Views.Forms.ToolForm;
using UI.Views.Forms;

namespace UI.Views.UC
{
    public partial class LevelLinesViewUC : UserControl
    {
        private LevelLine[] levelLines;
        public Image originalMapImage;

        private List<LevelLineViewContainer> levelLineViews;
        private LevelRegionToolForm levelRegionToolForm;
        private List<Polygon<Point>> levelRegions;
        private List<Point> pointsToRegion;
        private Point topShift;

        private bool isDrawing;
        private bool isDrawGrid;
        private bool isDrawNodes;
        private bool isDrawLevelOfLine;

        private bool isEditLinesModeOn;
        private bool isEditLevelsModeOn;
        private bool isLevelLinesBuilded;

        private Font font;

        private Color colorOfNode;
        private Color colorOfGrid;

        public LevelLinesViewUC()
        {
            InitializeComponent();

            levelLineViews = new List<LevelLineViewContainer>();
            levelRegionToolForm = new LevelRegionToolForm();
            levelRegions = new List<Polygon<Point>>();
            pointsToRegion = new List<Point>();

            canvas.BackgroundImageLayout = ImageLayout.Stretch;
            canvas.MouseClick += Canvas_MouseClick;
            canvas.Paint += Canvas_Paint;

            topShift = new Point(0, toolStrip.Height);

            isDrawing = false;
            isDrawGrid = false;
            isDrawNodes = false;
            isDrawLevelOfLine = false;

            font = DefaultFont;

            colorOfNode = Color.Blue;
            colorOfGrid = Color.Orange;

            NodeSize = 3;
            LineSize = 3;
            GridLineSize = 2;

            showNodesValuesBtn.Tag = "node";
            showLevelsOfLinesBtn.Tag = "level";
            showGridBtn.Tag = "grid";

            changeColorOfNodeBtn.Tag = "node";
            changeGridColorBtn.Tag = "grid";
        }

        #region Properties
        public List<LevelLine> LevelLines
        {
            get
            {
                return new List<LevelLine>(levelLines);
            }
            set
            {
                levelLines = value.ToArray();
                levelLineViews = new List<LevelLineViewContainer>();

                foreach (var line in levelLines)
                {
                    var lineContainer = new LevelLineViewContainer(line, NodeUC_MouseDown, NodeUC_MouseMove, NodeUC_MouseUp, NodeUC_KeyUp);

                    foreach (PointUC pointUC in lineContainer.Components)
                        pointUC.SetLocation(new Point(pointUC.Location.X + topShift.X, pointUC.Location.Y + topShift.Y));

                    levelLineViews.Add(lineContainer);
                }
            }
        }
        public List<Node> Nodes { get; set; }
        public List<Segment> Segments { get; set; }
        public Image MapImage
        {
            get => canvas.BackgroundImage;
            set => canvas.BackgroundImage = value;
        }

        private int NodeSize
        {
            get => Convert.ToInt32(nodeSizeTxtBox.Text);
            set => nodeSizeTxtBox.Text = value.ToString();
        }
        private int LineSize
        {
            get => Convert.ToInt32(lineSizeTxtBox.Text);
            set => lineSizeTxtBox.Text = value.ToString();
        }
        private int GridLineSize
        {
            get => Convert.ToInt32(gridLineSizeTxtBox.Text);
            set => gridLineSizeTxtBox.Text = value.ToString();
        }

        #endregion

        public bool IsEditLevelModeOn
        {
            get => isEditLevelsModeOn;
            set
            {
                isEditLevelsModeOn = value;

                levelToRebuildTxtBox.Visible = isEditLevelsModeOn;
                rebuildLevelBtn.Visible = isEditLevelsModeOn;
                rebuildTxt.Visible = isEditLevelsModeOn;
            }
        }
        public bool IsLevelLinesBuilded
        {
            get => isLevelLinesBuilded;
            set
            {
                isLevelLinesBuilded = value;

                foreach (ToolStripItem item in toolStrip.Items)
                    item.Enabled = true;
            }
        }

        public void DrawLevelLines()
        {
            isDrawing = true;
            Refresh();
        }

        public void EditLines(bool isEditLinesModeOn)
        {
            this.isEditLinesModeOn = isEditLinesModeOn;

            // TODO: Сделать проверку на количество линий.
            foreach (var lineView in levelLineViews)
            {
                foreach (PointUC pointUC in lineView.Components)
                {
                    if (isEditLinesModeOn)
                    {
                        pointUC.SetLocation(new Point((int)pointUC.Center.X, (int)pointUC.Center.Y));

                        Controls.Add(pointUC);

                        pointUC.BringToFront();
                    }
                    else
                    {
                        Controls.Remove(pointUC);
                    }
                }
            }

            if (!isEditLinesModeOn)
                DrawLevelLines();
        }

        public void SaveImage(string imagePath)
        {
            toolStrip.Visible = false;

            Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            Graphics.FromImage(bmp).CopyFromScreen(this.PointToScreen(Point.Empty), Point.Empty, bmp.Size);
            bmp.Save(imagePath);

            toolStrip.Visible = true;
        }

        public void SetMapImage(Image mapImage)
        {
            originalMapImage = mapImage;
            MapImage = mapImage;
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Отрисовка узлов и их уровней.
                if (isDrawNodes)
                {
                    foreach (var node in Nodes)
                    {
                        g.FillEllipse(new SolidBrush(colorOfNode), node.Location.X - NodeSize / 2, node.Location.Y - NodeSize / 2, NodeSize, NodeSize);
                        g.DrawString(((int)node.Level).ToString(), font, new SolidBrush(colorOfNode), node.Location.X + 5, node.Location.Y - 10);
                    }
                }

                // Отрисовка сетки.
                if (isDrawGrid)
                {
                    foreach (var segment in Segments)
                        g.DrawLine(new Pen(colorOfGrid, GridLineSize), segment.Nodes[0].Location, segment.Nodes[1].Location);

                }

                // Отрисовка линий уровня.
                foreach (var lineView in levelLineViews)
                {
                    var line = lineView.LevelLine;
                    var pointUcs = lineView.Components;

                    PointF[] points = new PointF[pointUcs.Count];

                    for (int i = 0; i < points.Length; i++)
                    {
                        var centerOfPointUC = ((PointUC)pointUcs[i]).Center;

                        points[i] = new PointF(centerOfPointUC.X - topShift.X, centerOfPointUC.Y - topShift.Y);
                    }

                    // Отрисовка линий.
                    if (points.Length >= 3)
                    {
                        g.DrawCurve(new Pen(Color.Black, LineSize), points);
                    }
                    // TODO: Добавить вариант действий, если точек в линии одна.

                    // Отрисовка уровней.
                    if (isDrawLevelOfLine)
                    {
                        PointUC start = (PointUC)pointUcs[0];
                        PointUC end = (PointUC)pointUcs[pointUcs.Count - 1];

                        // Настройка отступов.
                        int x0 = 15;
                        int y0 = topShift.Y + DefaultFont.Height / 2;
                        int x1 = start.Width * 3;
                        int x2 = 0;

                        if (start.Location.X > end.Location.X)
                        {
                            x0 *= -1;
                            x2 = x1;
                            x1 = 0;
                        }

                        g.DrawString(line.Level.ToString(), font, Brushes.Black, start.Location.X - x0 - x1, start.Location.Y - y0);
                        g.DrawString(line.Level.ToString(), font, Brushes.Black, end.Location.X + x0 - x2, end.Location.Y - y0);
                    }
                }

                isDrawing = false;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            canvas.CreateGraphics().Clear(Color.White);
            canvas.Refresh();
            SetMapImage(MapImage);

            if (levelLineViews.Count > 0 && LevelLines.Count > 0 && levelRegions.Count > 0 && pointsToRegion.Count > 0)
            {
                levelLineViews.Clear();
                LevelLines.Clear();
                levelRegions.Clear();
                pointsToRegion.Clear();
            }
        }

        
        #region NodeUC events handlers
        private void NodeUC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (var lineView in levelLineViews)
                {
                    foreach (PointUC pointUC in lineView.Components)
                    {
                        if (pointUC == (PointUC)sender)
                        {
                            foreach (PointUC pointUCToRemove in lineView.Components)
                                Controls.Remove(pointUCToRemove);

                            levelLineViews.Remove(lineView);
                            DrawLevelLines();

                            goto EndForeach;
                        }
                    }
                }

            EndForeach:;
            }
        }

        private void NodeUC_MouseDown(object sender, MouseEventArgs e)
        {
            ((PointUC)sender).IsDown = true;
        }

        private void NodeUC_MouseMove(object sender, MouseEventArgs e)
        {
            PointUC pointUC = (PointUC)sender;

            if (pointUC.IsDown)
            {
                pointUC.SetLocation(PointToClient(MousePosition));
                DrawLevelLines();
            }
        }

        private void NodeUC_MouseUp(object sender, MouseEventArgs e)
        {
            ((PointUC)sender).IsDown = false;
        }

        #endregion


        /* Обработчик перестроения уровня */
        private void RebuildLevelBtn_Click(object sender, EventArgs e)
        {
            if (isEditLinesModeOn)
            {
                MessageBox.Show("If want to rebuild a level, turn off a line edit mode.");
            }
            else
            {
                float level = (float)Convert.ToDouble(levelToRebuildTxtBox.Text);

                var controller = (MainController)((IView)Parent).Controller;
                controller.RebuildLevelLines(level, false, false);

                LevelLines = controller.GetLevelLines();

                canvas.CreateGraphics().Clear(Color.White);
                DrawLevelLines();
            }
        }


        /* Обработчики настройки выводимой информации */
        private void ChangeColorOfMapComponentBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    switch (menuItem.Tag)
                    {
                        case "node":
                            colorOfNode = cd.Color;
                            colorOfNodeTxtBox.Text = colorOfNode.Name;

                            break;
                        case "grid":
                            colorOfGrid = cd.Color;
                            colorOfGridTxtBox.Text = colorOfGrid.Name;

                            break;
                    }
                }
            }
        }

        private void ShowMapComponentBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = !menuItem.Checked;

            switch (menuItem.Tag)
            {
                case "node":
                    isDrawNodes = showNodesValuesBtn.Checked;
                    break;
                case "level":
                    isDrawLevelOfLine = showLevelsOfLinesBtn.Checked;
                    break;
                case "grid":
                    isDrawGrid = showGridBtn.Checked;
                    break;
            }

            DrawLevelLines();
        }

        private void ShowMapImageBtn_Click(object sender, EventArgs e)
        {
            showMapImageBtn.Checked = !showMapImageBtn.Checked;

            MapImage = showMapImageBtn.Checked ? originalMapImage : null;
        }

        private void FontBtn_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    font = fd.Font;
                    fontTxtBox.Text = $"{font.Name}, {font.Size}";
                }
            }
        }


        /* Обработчики построения и отрисовки областей заливки */
        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (((MainForm)Parent).IsNodeSetModeOn)
            {
                canvas.CreateGraphics().FillRectangle(Brushes.Red, e.X - 1, e.Y - 1, 3, 3);
                ((MainForm)Parent).Nodes.Add(e.Location);

                Console.WriteLine(e.Location);
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    pointsToRegion.Add(e.Location);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    var colorRegion = Color.FromArgb(levelRegionToolForm.Transparency, levelRegionToolForm.Color);

                    levelRegions.Add(new Polygon<Point>(colorRegion, pointsToRegion));
                    pointsToRegion.Clear();

                    using (Brush brush = new SolidBrush(colorRegion))
                    {
                        canvas.CreateGraphics().FillPolygon(brush, levelRegions[levelRegions.Count - 1].Points.ToArray());
                    }
                }
            }
        }

        private void FillRegionsBtn_Click(object sender, EventArgs e)
        {
            fillRegionsBtn.Checked = !fillRegionsBtn.Checked;

            if (fillRegionsBtn.Checked)
            {
                levelRegions = new List<Polygon<Point>>();
                pointsToRegion = new List<Point>();

                if (levelRegionToolForm == null || levelRegionToolForm.IsDisposed)
                {
                    levelRegionToolForm = new LevelRegionToolForm();
                    levelRegionToolForm.UndoRegion += LevelRegionToolForm_CancelReion;
                }

                levelRegionToolForm.Show();
            }
            else
            {
                levelRegionToolForm.UndoRegion -= LevelRegionToolForm_CancelReion;
                levelRegionToolForm.Close();

                DrawLevelLines();
            }
        }

        private void LevelRegionToolForm_CancelReion(object sender, EventArgs e)
        {
            var canvasGraphics = canvas.CreateGraphics();
            var removingRegion = levelRegions[levelRegions.Count - 1];

            levelRegions.Remove(removingRegion);

            canvasGraphics.Clear(Color.White);
            DrawLevelLines();

            foreach (var region in levelRegions)
            {
                using (Brush brush = new SolidBrush(region.Color))
                {
                    canvasGraphics.FillPolygon(brush, region.Points.ToArray());
                }
            }
        }



        private struct Polygon<T>
        {
            private readonly T[] points;
            private readonly Color color;

            public Polygon(Color color, List<T> points)
            {
                this.color = color;
                this.points = new T[points.Count];

                points.CopyTo(this.points);
            }

            public Color Color => color;
            public List<T> Points => points.ToList();
        }

    }
}
