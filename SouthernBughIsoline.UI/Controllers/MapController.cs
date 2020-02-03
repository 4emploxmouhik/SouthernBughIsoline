using Isoline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace SouthernBughIsoline.UI.Controllers
{
    public partial class MapController : IController
    {
        private Grid grid = new Grid();
        private Image map;
        private string mapImagePath;

        public Image MapImage { get => map; }
        public Grid Grid { get => grid; }

        public List<LevelLine> BuildLevelLine(float level, bool isUsedPointsOnDiagonals)
        {
            grid.IsUsedPointsOnDiagonals = isUsedPointsOnDiagonals;

            return grid.FindLevelLines(level);
        }

        public Image BulidLevelLines(Color[] colorOfLines, float[] levels, bool isUsedPointsOnDiagonals)
        {
            grid.IsUsedPointsOnDiagonals = isUsedPointsOnDiagonals;
            grid.FindLevelLines(levels);

            return DrawLevelLines(colorOfLines);
        }

        public void ChangeLevelOnNodes(List<(float Level, int Id)> levelsChangesKit)
        {
            grid.ChangeLevelOnNodes(levelsChangesKit);
        }

        public Image DrawLevelLine(Image image, List<LevelLine> lines, Color colorOfLine)
        {
            Bitmap bmp = new Bitmap(image);
            Graphics canvas = Graphics.FromImage(bmp);
            canvas.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var line in lines)
            {
                try
                {
                    canvas.DrawCurve(new Pen(colorOfLine, 3f), line.Points);
                }
                catch (ArgumentException) { /*Console.WriteLine(line.ToString());*/ }
            }

            return bmp;
        }

        public Image DrawLevelLines(Color[] colorOfLines)
        {
            Bitmap bmp = new Bitmap(map);
            Graphics canvas = Graphics.FromImage(bmp);
            canvas.SmoothingMode = SmoothingMode.AntiAlias;

            //foreach (var segment in grid.Segments)
            //    canvas.DrawLine(new Pen(Color.Black, 1f), segment.Nodes[0].Location, segment.Nodes[1].Location);

            //foreach (var node in grid.Nodes)
            //{
            //    canvas.FillRectangle(Brushes.Red, node.Location.X - 1, node.Location.Y - 1, 3, 3);
            //    canvas.DrawString("" + (node.Level - Grid.LevelShift), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, node.Location.X - 20, node.Location.Y - 20);
            //}

            int indx = 0;

            foreach (var level in grid.LevelLinesKits)
            {
                foreach (var line in level.Lines)
                {
                    try
                    {
                        canvas.DrawCurve(new Pen(colorOfLines[indx], 3f), line.Points);

                        //foreach (var point in line.Points)
                        //{
                        //    canvas.FillRectangle(Brushes.Green, point.X - 1, point.Y - 1, 3f, 3f);
                        //}

                        //canvas.DrawString("" + line.Level, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, line.Points[0].X - 10, line.Points[0].Y - 10);
                        //canvas.DrawString("" + line.Level, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, line.Points[line.Points.Length - 1].X - 10, line.Points[line.Points.Length - 1].Y - 10);
                    }
                    catch (ArgumentException) {/* Console.WriteLine(line.ToString());*/ }
                }

                if (colorOfLines.Length > 1 && indx < colorOfLines.Length)
                    indx++;
            }

            return bmp;

        }

        public Image LoadMap(string mapSettingsPath)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(mapSettingsPath))
            {
                throw new ArgumentException("Incorrect path to map settings file.");
            }
            #endregion

            XDocument xDoc = XDocument.Load(mapSettingsPath);
            var xCells = xDoc.Element("map").Element("grid").Element("cells").Elements("cell");

            List<Cell> cells = new List<Cell>();

            foreach (var xCell in xCells)
            {
                List<Side> sides = new List<Side>();

                foreach (var xSegment in xCell.Elements("segment"))
                {
                    List<Node> nodes = new List<Node>(2);

                    foreach (var xNode in xSegment.Elements("node"))
                    {
                        Node node = new Node(
                            (float)Convert.ToDouble(xNode.Attribute("x").Value),
                            (float)Convert.ToDouble(xNode.Attribute("y").Value),
                            Convert.ToInt32(xNode.Attribute("id").Value), 0)
                        {
                            Name = xNode.Attribute("name").Value
                        };

                        nodes.Add(node);
                    }

                    sides.Add(new Side(
                        new Segment(nodes[0], nodes[1], Convert.ToInt32(xSegment.Attribute("id").Value))
                        {
                            IsEdge = Convert.ToBoolean(xSegment.Attribute("edge").Value),
                            Name = xSegment.Attribute("name").Value
                        },
                        xSegment.Attribute("side").Value));
                }

                cells.Add(new Cell(sides.ToArray(), Convert.ToInt32(xCell.Attribute("id").Value))
                {
                    Name = xCell.Attribute("name").Value
                });
            }

            grid = new Grid(cells);

            mapImagePath = xDoc.Element("map").Element("image_path").Value;

            return map = Image.FromFile(mapImagePath);
        }

        public void SaveMap(string mapSettingsPath, string mapImagePath, Grid grid)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(mapSettingsPath) || string.IsNullOrWhiteSpace(mapImagePath))
            {
                throw new ArgumentException("Incorrect path to map settings file.");
            }
            else if (grid == null)
            {
                throw new NullReferenceException("Grid equals null.");
            }
            #endregion

            this.grid = grid;

            XDocument xDoc = new XDocument();
            XElement xMap = new XElement("map");
            XElement xGrid = new XElement("grid");
            XElement xImagePath = new XElement("image_path", mapImagePath);
            XElement xCells = new XElement("cells");

            foreach (var cell in grid.Cells)
            {
                XElement xCell = new XElement("cell",
                    new XAttribute("name", cell.Name),
                    new XAttribute("id", cell.Id));

                foreach (var side in cell.Sides)
                {
                    XElement xSegment = new XElement("segment",
                        new XAttribute("name", side.Segment.Name),
                        new XAttribute("id", side.Segment.Id),
                        new XAttribute("edge", side.Segment.IsEdge),
                        new XAttribute("side", side.Dock));

                    foreach (var node in side.Segment.Nodes)
                    {
                        XElement xPoint = new XElement("node",
                            new XAttribute("name", node.Name),
                            new XAttribute("id", node.Id),
                            new XAttribute("x", node.Location.X),
                            new XAttribute("y", node.Location.Y));

                        xSegment.Add(xPoint);
                    }

                    xCell.Add(xSegment);
                }

                xCells.Add(xCell);
            }

            xGrid.Add(xCells);
            xMap.Add(xImagePath, xGrid);

            xDoc.Add(xMap);
            xDoc.Save(mapSettingsPath);
        }

        
    }
}
