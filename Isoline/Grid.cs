using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Isoline
{
    public class Grid
    {
        public const float LevelShift = 0.001f;

        private List<Cell> cells = new List<Cell>();
        private List<LevelLinesKit> levelLinesKits;

        private LinkedList<PointF> pointsOfLine;
        private bool isGotEdge;

        private Cell startCell;
        private Cell curCell;
        private Side startSide;
        private Side curSide;

        public Grid()
        {
            levelLinesKits = new List<LevelLinesKit>();
            pointsOfLine = new LinkedList<PointF>();

            IsUsedPointsOnDiagonals = false;
            LevelLines = new List<LevelLinesKit>();

            SetDefaultState();
        }

        public Grid(List<Cell> cells) : this()
        {
            this.cells = cells;
        }

        public bool IsUsedPointsOnDiagonals { get; set; }
        public List<LevelLinesKit> LevelLines { get; set; }

        public List<Node> Nodes
        {
            get
            {
                var nodes = from cell in cells
                            from side in cell.Sides
                            from node in side.Segment.Nodes
                            select node;

                HashSet<Node> nodesSet = new HashSet<Node>();

                foreach (var node in nodes)
                    nodesSet.Add(node);
                
                return nodesSet.OrderBy(n => n.Id).ToList();
            }
        }
        public List<Segment> Segments
        {
            get
            {
                var segments = from cell in cells
                               from side in cell.Sides
                               select side.Segment;

                HashSet<Segment> segmentsSet = new HashSet<Segment>();

                foreach (var segment in segments)
                    segmentsSet.Add(segment);

                return segmentsSet.ToList();
            }
        }
        public List<Cell> Cells => cells;

        public void ChangeLevelOnNodes(List<(float Level, int Id)> levelsChangesKit)
        {
            for (int i = 0; i < levelsChangesKit.Count; i++)
            {
                foreach (var cell in cells)
                {
                    foreach (var side in cell.Sides)
                    {
                        foreach (var node in side.Segment.Nodes)
                        {
                            if (node.Id == levelsChangesKit[i].Id)
                                node.Level = levelsChangesKit[i].Level + LevelShift;
                        }
                    }
                }
            }
        }

        public void FindLevelLines(float[] levels)
        {
            float minLvl = Nodes.Min(node => node.Level) - LevelShift
                , maxLvl = Nodes.Max(node => node.Level) - LevelShift;

            foreach (var level in levels)
            {
                if (level < minLvl || level > maxLvl)
                    continue;

                LevelLines.Add(new LevelLinesKit()
                {
                    Lines = FindLevelLines(level),
                    Level = level
                });
            }
        }

        public List<LevelLine> FindLevelLines(float level)
        {
            List<LevelLine> levelLines = new List<LevelLine>();
            Side[] crossedSides;
            PointF crossPoint;
            Random rand = new Random();

            SetDefaultState();

            // Нулевой шаг.
            FindCrossedSegments(level);

            // Шаг первый.
            InitialNewLine(level);

        // Шаг второй.
        FindNextPoint:
            crossedSides = curCell.GetCrossedSides();

            switch (crossedSides.Length)
            {
                // Нашли начало линии.
                case 0:
                    if (!isGotEdge)
                        AddPoint(startSide.Segment.GetCrossPoint(level));

                    levelLines.Add(InitialNewLine(level));

                    if (GetCrossedSegmentsCount() > 0)
                        goto FindNextPoint;

                    break;

                // Нашли обычное ребро с пересечением.
                case 1:
                    curSide = crossedSides[0];
                    goto default;

                // Нашли два обычных ребра и возможно начало линии.
                case 2:
                    if (curCell.GetOppositeSide(curSide) != startSide)
                        levelLines.Add(InitialNewLine(level));
                    else
                        goto case 3;

                    goto FindNextPoint;

                // Нашли три обычных ребра с пересечением.
                case 3:
                    // Случайный выбор ребра из двух возможных(смежных).
                    crossedSides = curCell.GetOppositeSidesByNodes(curSide);

                    curSide = (rand.Next(10) % 2 == 0) ? crossedSides[0] : crossedSides[1];
                    goto default;

                // Добавление точки в последовательность.
                default:
                    curSide.Segment.IsMarked = true;

                    // Найдем конец локальной линии.
                    crossPoint = curSide.Segment.GetCrossPoint(level);

                    // Найдем и добавим точки на диагоналях в последовательность.
                    if (IsUsedPointsOnDiagonals)
                    {
                        foreach (var point in curCell.GetCrossPointsOfDiagonals(level, crossPoint))
                        {
                            AddPoint(point);
                        }
                    }

                    // Добавим конец локальной линии в последовательность. 
                    AddPoint(crossPoint);

                    // Меняем текущую ячейку.
                    if (curSide.Segment.IsEdge && !curSide.Segment.IsStartOfLevelLine && !isGotEdge)
                    {
                        curCell = GetAdjacentCell(startCell, startSide);
                        isGotEdge = true;

                        goto FindNextPoint;
                    }

                    if (crossedSides.Length >= 2) curCell.IsMarked = false;

                    curCell = GetAdjacentCell(curCell, curSide);
                    curCell.IsMarked = true;

                    goto FindNextPoint;
            }

            levelLines.AddRange(FindLevelLinesOfOnePoint(level));

            return levelLines;
        }

        public LevelLine[] FindLevelLinesOfOnePoint(float level)
        {
            HashSet<LevelLine> levelLines = new HashSet<LevelLine>();
            float levelWithShift = level + LevelShift;

            foreach (var cell in cells)
            {
                foreach (var side in cell.Sides)
                {
                    foreach (var node in side.Segment.Nodes)
                    {
                        if (node.Level == levelWithShift)
                        {
                            if (CheckCrossingSegments(GetSidesWithCommonNode(node)) == false)
                                levelLines.Add(new LevelLine(new PointF[] { node.Location }, level));
                        }
                    }
                }
            }

            return levelLines.ToArray();
        }

        private void AddPoint(PointF point)
        {
            if (isGotEdge)
                pointsOfLine.AddFirst(point);
            else
                pointsOfLine.AddLast(point);
        }

        private bool CheckCrossingSegments(Side[] sides)
        {
            bool result = false;

            foreach (var side in sides)
            {
                if (side.Segment.IsCrossed)
                    result = true;
            }

            return result;
        }

        private void FindCrossedSegments(float level)
        {
            foreach (var cell in cells)
            {
                foreach (var side in cell.Sides)
                    side.Segment.IsCrossing(level);
            }
        }

        private Cell GetAdjacentCell(Cell currentCell, Side commonSide)
        {
            foreach (var cell in cells)
            {
                if (cell.ContainsSide(commonSide) && cell != currentCell)
                    return cell;
            }

            return currentCell;
        }

        private int GetCrossedSegmentsCount()
        {
            HashSet<Segment> crossedSegments = new HashSet<Segment>();

            foreach (var cell in cells)
            {
                foreach (var side in cell.Sides)
                {
                    if (side.Segment.IsCrossed && !side.Segment.IsMarked)
                        crossedSegments.Add(side.Segment);
                }
            }

            return crossedSegments.Count;
        }

        private Side[] GetSidesWithCommonNode(Node node)
        {
            HashSet<Side> sides = new HashSet<Side>();

            foreach (var cell in cells)
            {
                foreach (var side in cell.Sides)
                {
                    if (side.Segment.ContainsNode(node))
                        sides.Add(side);
                }
            }

            return sides.ToArray();
        }

        private LevelLine InitialNewLine(float level)
        {
            LevelLine levelLine = new LevelLine(pointsOfLine.ToArray(), level);

            // Поиск не маркированного ребра.
            foreach (var cell in cells)
            {
                foreach (var side in cell.Sides)
                {
                    if (side.Segment.IsCrossed && !side.Segment.IsMarked)
                    {
                        pointsOfLine.Clear();
                        isGotEdge = false;

                        startSide = side;

                        curSide = side;
                        curSide.Segment.IsMarked = true;
                        curSide.Segment.IsStartOfLevelLine = true;

                        if (GetCrossedSegmentsCount() != 0)
                            AddPoint(curSide.Segment.GetCrossPoint(level));

                        startCell = cell;
                        curCell = cell;

                        goto EndInitialNewLine;
                    }
                }
            }

        EndInitialNewLine:
            return levelLine;
        }

        private void SetDefaultState()
        {
            startCell = null;
            curCell = null;

            foreach (var cell in cells)
            {
                cell.IsMarked = false;

                foreach (var side in cell.Sides)
                {
                    side.Segment.IsCrossed = false;
                    side.Segment.IsMarked = false;
                    side.Segment.IsStartOfLevelLine = false;
                }
            }
        }
    }
}
