using Isoline;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Views
{
    public partial class MainForm : Form
    {
        private List<PointF3D> nodes = new List<PointF3D>();
        private Grid grid = new Grid();

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = e.Location;

            Graphics g = panel1.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Red), new Rectangle(point, new Size(1, 1)));

            nodes.Add(new PointF3D(point.X, point.Y, 0f));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (var node in nodes)
                richTextBox1.Text += node.ToString() + "\n";

            richTextBox1.Text += "\nSegments:\n";

            foreach (var segment in grid.Segments)
                richTextBox1.Text += segment.ToString() + "\n";

            richTextBox1.Text += "\nCells:\n";

            foreach (var cell in grid.Cells)
                richTextBox1.Text += cell.Name + "\n";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            nodes.Clear();
            panel1.CreateGraphics().Clear(DefaultBackColor);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

            char[] names = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' };
            float[] levels = { 16, 0, 3, 16, 10, 7, 12, 10, 18, 14, 13, 1, 6, 10, 3, 17, 13, 19, 2, 19 };
            int i = 0;
            
            foreach (var node in nodes)
            {
                node.Name = "" + names[i];
                node.Z = levels[i];
                i++;

                g.DrawString(node.Name, DefaultFont, Brushes.Orange, node.X - 10, node.Y - 10);
            }

            grid = new Grid(nodes)
            {
                Segments =
                {
                    new Segment(nodes[0], nodes[1]) { IsEdge = true },
                    new Segment(nodes[0], nodes[5]),
                    new Segment(nodes[1], nodes[2]) { IsEdge = true },
                    new Segment(nodes[1], nodes[6]),
                    new Segment(nodes[2], nodes[3]) { IsEdge = true },
                    new Segment(nodes[2], nodes[7]),
                    new Segment(nodes[3], nodes[4]) { IsEdge = true },
                    new Segment(nodes[3], nodes[8]),
                    new Segment(nodes[4], nodes[9]) { IsEdge = true },

                    new Segment(nodes[5], nodes[6]),
                    new Segment(nodes[5], nodes[10]) { IsEdge = true },
                    new Segment(nodes[6], nodes[7]),
                    new Segment(nodes[6], nodes[11]),
                    new Segment(nodes[7], nodes[8]),
                    new Segment(nodes[7], nodes[12]),
                    new Segment(nodes[8], nodes[9]),
                    new Segment(nodes[8], nodes[13]),
                    new Segment(nodes[9], nodes[14]) { IsEdge = true },

                    new Segment(nodes[10], nodes[11]),
                    new Segment(nodes[10], nodes[15]) { IsEdge = true },
                    new Segment(nodes[11], nodes[12]),
                    new Segment(nodes[11], nodes[16]),
                    new Segment(nodes[12], nodes[13]),
                    new Segment(nodes[12], nodes[17]),
                    new Segment(nodes[13], nodes[14]),
                    new Segment(nodes[13], nodes[18]),
                    new Segment(nodes[14], nodes[19]) { IsEdge = true },

                    new Segment(nodes[15], nodes[16]) { IsEdge = true },
                    new Segment(nodes[16], nodes[17]) { IsEdge = true },
                    new Segment(nodes[17], nodes[18]) { IsEdge = true },
                    new Segment(nodes[18], nodes[19]) { IsEdge = true }
                },
                
            };

            grid.Cells = new List<Cell>()
                {
                new Cell(grid.Segments[0], grid.Segments[1], grid.Segments[3], grid.Segments[9]),
                    new Cell(grid.Segments[2], grid.Segments[3], grid.Segments[5], grid.Segments[11]),
                    new Cell(grid.Segments[4], grid.Segments[5], grid.Segments[7], grid.Segments[13]),
                    new Cell(grid.Segments[6], grid.Segments[7], grid.Segments[8], grid.Segments[15]),

                    new Cell(grid.Segments[9], grid.Segments[10], grid.Segments[12], grid.Segments[18]),
                    new Cell(grid.Segments[11], grid.Segments[12], grid.Segments[14], grid.Segments[20]),
                    new Cell(grid.Segments[13], grid.Segments[14], grid.Segments[16], grid.Segments[22]),
                    new Cell(grid.Segments[15], grid.Segments[16], grid.Segments[17], grid.Segments[24]),

                    new Cell(grid.Segments[18], grid.Segments[19], grid.Segments[21], grid.Segments[27]),
                    new Cell(grid.Segments[20], grid.Segments[21], grid.Segments[23], grid.Segments[28]),
                    new Cell(grid.Segments[22], grid.Segments[23], grid.Segments[25], grid.Segments[29]),
                    new Cell(grid.Segments[24], grid.Segments[25], grid.Segments[26], grid.Segments[30]),
                };
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Color[] colors = { Color.Blue, Color.Purple, Color.YellowGreen, Color.Yellow };
            int i = 0;

            float[] levels = { 5f, 8f, 10f, 15f };

            grid.FindLevelLines(levels);

            foreach (var level in grid.LevelLines)
            {
                foreach (var line in level.Lines)
                {
                    try
                    {
                        g.DrawLines(new Pen(colors[i]), ConvertPoints(line.Points));
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("\nWe catch ArgumentException\n");
                    }
                }

                i++;
            }
        }

        private PointF[] ConvertPoints(PointF3D[] points)
        {
            PointF[] convertPoints = new PointF[points.Length];

            Console.WriteLine("Line points:\n");

            for (int i = 0; i < convertPoints.Length; i++)
            {
                convertPoints[i] = new PointF(points[i].X, points[i].Y);

                Console.WriteLine("parent = {0}; level = {1}; X = {2}; Y = {3};", points[i].Parent.Name, points[i].Z, points[i].X, points[i].Y);
            }

            return convertPoints;
        }
    }
}
