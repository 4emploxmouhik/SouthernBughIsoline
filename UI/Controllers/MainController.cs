using Isoline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UI.Controllers
{
    public class MainController : IController
    {
        private Map map;

        public MainController()
        {
            map = new Map();
        }

        public Grid Grid => map.Grid;
        public Image MapImage => map.Image;

        // TODO: Добавить проверки на входные значения.

        public void BuildLevelLines(float[] levelsValues, bool isUsedPointsOnDiagonals, bool isFindLevelsWithOnePoint)
        {
            Grid.IsUsedPointsOnDiagonals = isUsedPointsOnDiagonals;
            Grid.IsFindLevelsWithOnePoint = isFindLevelsWithOnePoint;
            Grid.FindLevelLines(levelsValues);
        }

        public void BuildLevelLines(float levelValue, bool isUsedPointsOnDiagonals, bool isFindLevelsWithOnePoint)
        {
            Grid.IsUsedPointsOnDiagonals = isUsedPointsOnDiagonals;
            Grid.IsFindLevelsWithOnePoint = isFindLevelsWithOnePoint;

            var level = Grid.FindLevelLines(levelValue);
            
            Grid.LevelLinesKits.Add(new LevelLinesKit(levelValue, level));
        }

        public void RebuildLevelLines(float levelValue, bool isUsedPointsOnDiagonals, bool isFindLevelsWithOnePoint)
        {
            Grid.IsUsedPointsOnDiagonals = isUsedPointsOnDiagonals;
            Grid.IsFindLevelsWithOnePoint = isFindLevelsWithOnePoint;

            var levelToRebuild = Grid.LevelLinesKits.Find(x => x.Level == levelValue);
            levelToRebuild.Lines = Grid.FindLevelLines(levelValue);
            
            Grid.LevelLinesKits[Grid.LevelLinesKits.FindIndex(x => x.Level == levelValue)] = levelToRebuild;
        }

        public void ChangeLevelsOfNodes(List<(float Level, int Id)> levelsChangesKit)
        {
            // TODO: Добавить проверку входных параметров.
            map.Grid.ChangeLevelOnNodes(levelsChangesKit);
        }

        public List<LevelLine> GetLevelLines()
        {
            List<LevelLine> lines = new List<LevelLine>();

            foreach (var level in Grid.LevelLinesKits)
            {
                foreach (var line in level.Lines)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        public void LoadMapFromXmlFile(string filePath)
        {
            // TODO: Добавить проверку входных параметров.
            XDocument xDoc = XDocument.Load(filePath);
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
                        nodes.Add(
                            new Node(
                                (float)Convert.ToDouble(xNode.Attribute("x").Value),
                                (float)Convert.ToDouble(xNode.Attribute("y").Value),
                                Convert.ToInt32(xNode.Attribute("id").Value), 0)
                                {
                                    Name = xNode.Attribute("name").Value
                                }
                            );
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

            map.Grid = new Grid(cells);
            map.Image = Image.FromFile(xDoc.Element("map").Element("image_path").Value);
        }

        public void SaveMapToXmlFile(string filePath, string imagePath, Grid grid)
        {
            // TODO: Добавить проверку входных параметров.
            map.Grid = grid;
            map.Image = Image.FromFile(imagePath);

            XDocument xDoc = new XDocument();
            XElement xMap = new XElement("map");
            XElement xGrid = new XElement("grid");
            XElement xImagePath = new XElement("image_path", imagePath);
            XElement xCells = new XElement("cells");

            foreach (var cell in map.Grid.Cells)
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
            xDoc.Save(filePath);
        }

        private struct Map
        {
            public Grid Grid { get; set; }
            public Image Image { get; set; }
        }
    }
}
