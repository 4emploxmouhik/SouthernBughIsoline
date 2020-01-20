using Isoline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace SouthernBughIsoline.UI.Controllers
{
    public class MapController
    {
        private List<Node> nodes = new List<Node>();
        private Grid grid = new Grid();
        private Image map;
        private string mapImagePath;

        public Grid Grid { set => grid = value; } // DEBUG

        public void BulidLevelLines(Graphics canvas, Color colorOfLines, float[] nodesValues, float[] levels)
        {
            foreach (var cell in grid.Cells)
            {
                foreach (var side in cell.Sides)
                {
                    Console.WriteLine(side.ToString());
                }
            }

            foreach (var segment in grid.Segments)
            {
                canvas.DrawLine(new Pen(Color.Black, 1f), segment.Nodes[0].Location, segment.Nodes[1].Location);
            }

            var nodes = grid.Nodes;
            List<(float Level, int Id)> levelsChangesKit = new List<(float, int)>();

            for (int i = 0; i < nodes.Count; i++)
            {
                levelsChangesKit.Add((nodesValues[i], i));

                canvas.FillRectangle(Brushes.Red, nodes[i].Location.X - 1, nodes[i].Location.Y - 1, 3, 3);
                canvas.DrawString(nodes[i].Name, new Font("Arial", 14, FontStyle.Bold), Brushes.Red, nodes[i].Location.X - 20, nodes[i].Location.Y - 20);
            }

            grid.ChangeLevelOnNodes(levelsChangesKit);
            grid.IsUsedPointsOnDiagonals = false;
            grid.FindLevelLines(levels);

            foreach (var level in grid.LevelLines)
            {
                foreach (var line in level.Lines)
                {
                    try
                    {
                        canvas.DrawCurve(new Pen(colorOfLines, 2f), line.Points, 0.5f);

                        foreach (var point in line.Points)
                        {
                            canvas.FillRectangle(Brushes.Green, point.X - 1, point.Y - 1, 3f, 3f);
                        }
                    }
                    catch (ArgumentException) { }
                }
            }

        }

        public void SaveMap(string mapSettingsFilePath, string mapImagePath)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(mapSettingsFilePath) || string.IsNullOrWhiteSpace(mapImagePath))
            {
                throw new ArgumentException("Incorrect path to map settings file.");
            }
            else if (grid == null)
            {
                throw new NullReferenceException("Grid equals null.");
            }
            #endregion

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
            xDoc.Save(mapSettingsFilePath);
        }

        public Image LoadMap(string mapSettingsFilePath)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(mapSettingsFilePath))
            {
                throw new ArgumentException("Incorrect path to map settings file.");
            }
            #endregion

            XDocument xDoc = XDocument.Load(mapSettingsFilePath);
            var xCells = xDoc.Element("map").Element("grid").Element("cells").Elements("cell");

            List<Cell> cells = new List<Cell>();

            foreach (var xCell in xCells)
            {
                //List<Segment> segments = new List<Segment>();
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

                    
                    //Segment segment = new Segment(nodes[0], nodes[1], Convert.ToInt32(xSegment.Attribute("id").Value))
                    //{
                    //    IsEdge = Convert.ToBoolean(xSegment.Attribute("edge").Value),
                    //    Name = xSegment.Attribute("name").Value
                    //};
                    sides.Add(new Side(
                        new Segment(nodes[0], nodes[1], Convert.ToInt32(xSegment.Attribute("id").Value))
                        {
                            IsEdge = Convert.ToBoolean(xSegment.Attribute("edge").Value),
                            Name = xSegment.Attribute("name").Value
                        },
                        xSegment.Attribute("side").Value
                        ));

                    //segments.Add(segment);
                }

                cells.Add(new Cell(sides.ToArray(), Convert.ToInt32(xCell.Attribute("id").Value)) 
                {
                    Name = xCell.Attribute("name").Value
                });

                //cells.Add(new Cell(segments[0], segments[1], segments[2], segments[3], Convert.ToInt32(xCell.Attribute("id").Value))
                //{
                //    Name = xCell.Attribute("name").Value
                //});

                //Console.WriteLine("{0} {1} {2} {3}", sides[0].Name, sides[1].Name, sides[2].Name, sides[3].Name);
            }

            grid = new Grid(cells);

            mapImagePath = xDoc.Element("map").Element("image_path").Value;

            return map = Image.FromFile(mapImagePath);
        }

    }
}
