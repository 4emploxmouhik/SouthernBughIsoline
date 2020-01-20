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

using Map = SouthernBughIsoline.UI.Properties.Resources;

namespace SouthernBughIsoline.UI.Views
{
    public partial class MainForm : Form
    {
        private List<Node> nodes = new List<Node>();
        public Grid grid = new Grid();
        

        public MainForm()
        {
            InitializeComponent();

            panel1.BackgroundImage = Map.map_1;

            diagonalsSwitchBtn.Checked = true;
            diagonalsSwitchBtn.Click += toolStripButton5_Click;

            drawSegmentsBtn.Click += DrawSegmentsBtn_Click;
        }

        private void DrawSegmentsBtn_Click(object sender, EventArgs e)
        {
            if (grid.Segments.Count > 0)
            {
                Graphics g = panel1.CreateGraphics();

                foreach (var segment in grid.Segments)
                {
                    g.DrawLine(new Pen(backgroundSwitchBtn.Checked ? Color.Black : Color.White), 
                        segment.Start.X, segment.Start.Y, segment.End.X, segment.End.Y);
                }
            }
        }

        int indx = 0;
        char[] names = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V' };
        float[] levelsOfNodes = { 16, 0, 3, 16, 10, 7, 12, 10, 18, 14, 13, 1, 6, 10, 3, 17, 13, 19, 2, 19, 12, 4 };
        bool debugFlag = true;

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            //Point mouseLocation = e.Location;

            //Graphics g = panel1.CreateGraphics();
            //g.DrawRectangle(new Pen(Color.Red), new Rectangle(mouseLocation, new Size(1, 1)));

            //if (indx < names.Length)
            //{
            //    nodes.Add(new PointF3D(mouseLocation.X, mouseLocation.Y, 0f) { Name = "" + names[indx] });
            //    richTextBox1.Text += $"{nodes[indx].Name}: X = {nodes[indx].X}; Y = {nodes[indx].Y};\n";
            //    indx++;
            //}
        }

        // Print
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

        // Clear
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            nodes.Clear();
            panel1.CreateGraphics().Clear(DefaultBackColor);

            if (backgroundSwitchBtn.Checked)
                panel1.BackgroundImage = Map.map_1;
            else
                panel1.CreateGraphics().Clear(Color.Black);
        }

        // Build
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

            nodes.AddRange(new[] 
            {
                new Node(219,   95, 47) { Name = "A", Id = 0 },
                new Node(359,   70, 46) { Name = "B", Id = 1 },
                new Node(522,  124, 63) { Name = "C", Id = 2 },
                new Node(682,  133, 46) { Name = "D", Id = 3 },
                new Node(798,  161, 49) { Name = "E", Id = 4 },
                new Node(910,  208, 41) { Name = "F", Id = 5 },
                new Node(1004, 260, 44) { Name = "G", Id = 6 },
                new Node(986,  352, 37) { Name = "H", Id = 7 },
                new Node(1030, 475, 33) { Name = "I", Id = 8 },
                new Node(777,  550, 22) { Name = "J", Id = 9 },
                new Node(679,  581, 29) { Name = "K", Id = 10 },
                new Node(647,  489, 32) { Name = "L", Id = 11 },
                new Node(497,  293, 47) { Name = "M", Id = 12 },
                new Node(389,  174, 53) { Name = "N", Id = 13 },
                new Node(644,  299, 43) { Name = "O", Id = 14 },
                new Node(576,  214, 43) { Name = "P", Id = 15 },
                new Node(455,  133, 50) { Name = "Q", Id = 16 }, 
                new Node(701,  221, 45) { Name = "R", Id = 17 },
                new Node(705,  393, 41) { Name = "S", Id = 18 },
                new Node(791,  355, 39) { Name = "T", Id = 19 },
                new Node(871,  319, 38) { Name = "U", Id = 20 },
                new Node(863,  445, 28) { Name = "V", Id = 21 }
            });

            foreach (var node in nodes)
            {
                g.FillRectangle(Brushes.Red, node.X - 1, node.Y - 1, 3, 3);
                //node.Z = (float)rand.NextDouble() * 10;
            }

            #region
            grid = new Grid(nodes)
            {
                Segments =
                {
                    new Segment(nodes[0], nodes[1]) { IsEdge = true },      // AB
                    new Segment(nodes[0], nodes[13]){ IsEdge = true },      // AN
                    new Segment(nodes[1], nodes[2]) { IsEdge = true },      // BC
                    new Segment(nodes[1], nodes[16]),                       // BQ
                    new Segment(nodes[2], nodes[3]) { IsEdge = true },      // CD
                    new Segment(nodes[2], nodes[15]),                       // CP
                    new Segment(nodes[3], nodes[4]) { IsEdge = true },      // DE
                    new Segment(nodes[3], nodes[17]),                       // DR
                    new Segment(nodes[4], nodes[5]) { IsEdge = true },      // EF
                    new Segment(nodes[4], nodes[19]),                       // ET 
                    new Segment(nodes[5], nodes[6]) { IsEdge = true },      // FG
                    new Segment(nodes[5], nodes[20]),                       // FU
                    new Segment(nodes[6], nodes[7]) { IsEdge = true },      // GH
                    new Segment(nodes[7], nodes[8]) { IsEdge = true },      // HI
                    new Segment(nodes[7], nodes[20]),                       // HU
                    new Segment(nodes[7], nodes[21]),                       // HV
                    new Segment(nodes[8], nodes[9]) { IsEdge = true },      // IJ
                    new Segment(nodes[9], nodes[10]) { IsEdge = true },     // JK
                    new Segment(nodes[9], nodes[18]),                       // JS
                    new Segment(nodes[9], nodes[21]),                       // JV
                    new Segment(nodes[10], nodes[11]) { IsEdge = true },    // KL
                    new Segment(nodes[11], nodes[12]) { IsEdge = true },    // LM
                    new Segment(nodes[11], nodes[18]),                      // LS
                    new Segment(nodes[12], nodes[13]) { IsEdge = true },    // MN
                    new Segment(nodes[12], nodes[14]),                      // MO
                    new Segment(nodes[12], nodes[15]),                      // MP
                    new Segment(nodes[13], nodes[16]),                      // NQ
                    new Segment(nodes[14], nodes[17]),                      // OR
                    new Segment(nodes[14], nodes[18]),                      // OS
                    new Segment(nodes[15], nodes[16]),                      // PQ
                    new Segment(nodes[15], nodes[17]),                      // PR
                    new Segment(nodes[17], nodes[19]),                      // RT
                    new Segment(nodes[18], nodes[19]),                      // ST
                    new Segment(nodes[19], nodes[20]),                      // TU
                    new Segment(nodes[19], nodes[21]),                      // TV
                },

            };

            grid.Cells = new List<Cell>()
            {
                new Cell( grid.Segments[0],  grid.Segments[1],  grid.Segments[3], grid.Segments[26]),      // ABQN
                new Cell( grid.Segments[2],  grid.Segments[3],  grid.Segments[5], grid.Segments[29]),      // BCPQ
                new Cell( grid.Segments[4],  grid.Segments[5],  grid.Segments[7], grid.Segments[30]),      // CDRP
                new Cell( grid.Segments[6],  grid.Segments[7],  grid.Segments[9], grid.Segments[31]),      // DETR
                new Cell( grid.Segments[8],  grid.Segments[9],  grid.Segments[11], grid.Segments[33]),     // EFUT
                new Cell( grid.Segments[10],  grid.Segments[11],  grid.Segments[12], grid.Segments[14]),   // FGHU
                new Cell( grid.Segments[15],  grid.Segments[19],  grid.Segments[13], grid.Segments[16]),   // VHIJ
                new Cell( grid.Segments[33],  grid.Segments[34],  grid.Segments[14], grid.Segments[15]),   // TUHV
                new Cell( grid.Segments[32],  grid.Segments[18],  grid.Segments[34], grid.Segments[19]),   // STVJ 
                new Cell( grid.Segments[22],  grid.Segments[20],  grid.Segments[18], grid.Segments[17]),   // LSJK
                new Cell( grid.Segments[27],  grid.Segments[28],  grid.Segments[31], grid.Segments[32]),   // ORTS
                new Cell( grid.Segments[24],  grid.Segments[21],  grid.Segments[28], grid.Segments[22]),   // MOSL
                new Cell( grid.Segments[25],  grid.Segments[24],  grid.Segments[30], grid.Segments[27]),   // MPRO
                new Cell( grid.Segments[26],  grid.Segments[23],  grid.Segments[29], grid.Segments[25]),   // NQPM
            };
            #endregion

            grid.IsUsedPointsOnDiagonals = debugFlag;

            if (!backgroundSwitchBtn.Checked)
            {
                foreach (var node in grid.Nodes)
                {
                    panel1.CreateGraphics().DrawString(node.Name, DefaultFont, Brushes.White, node.X - 15, node.Y - 15);
                }
            }
        }

        // Draw
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (grid.Nodes.Count != 0)
            {
                Graphics g = panel1.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Color[] colors = { Color.Black, Color.Red, Color.Purple, Color.Lime, Color.DarkOrange, Color.Blue, Color.Yellow, Color.Fuchsia };
                int i = 1;

                //float[] levels = { 5f, 8f, 11f, 15f };
                float[] levels = { 25f, 30f, 35f, 40f, 45f, 50f, 60f };

                grid.FindLevelLines(levels);

                foreach (var level in grid.LevelLines)
                {
                    foreach (var line in level.Lines)
                    {
                        try
                        {
                            if (!toolStripButton6.Checked)
                                g.DrawLines(new Pen(/*Color.Black*/colors[i], 1f), ConvertPoints(line.Points));
                            else
                                g.DrawCurve(new Pen(/*Color.Black*/colors[i], 1f), ConvertPoints(line.Points), 0.5f);

                            foreach (var point in line.Points)
                            {
                                g.FillRectangle(Brushes.Green, point.X - 1, point.Y - 1, 3f, 3f);
                            }

                            g.DrawString("" + line.Level, new Font(DefaultFont, FontStyle.Bold), Brushes.Black, line.Points[0].X - 30, line.Points[0].Y);
                            g.DrawString("" + line.Level, new Font(DefaultFont, FontStyle.Bold), Brushes.Black, line.Points[line.Points.Length - 1].X - 30, line.Points[line.Points.Length - 1].Y);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("\nWe catch ArgumentException\n");
                        }
                    }

                    i++;
                }
            }
        }



        private PointF[] ConvertPoints(Node[] points)
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;

            button.Checked = !button.Checked;

            if ((string)button.Tag == "Diagonals") debugFlag = button.Checked;

            if (button.Checked)
            {
                button.ForeColor = Color.Green;

                if ((string)button.Tag == "Background") panel1.BackgroundImage = Map.map_1; 
            }
            else
            {
                button.ForeColor = Color.Red;

                if ((string)button.Tag == "Background")
                {
                    panel1.CreateGraphics().Clear(Color.Black);
                }
            }
        }
    }
}
