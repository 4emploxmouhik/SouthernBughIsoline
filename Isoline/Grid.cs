using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isoline
{
    public class Grid
    {
        private LinkedList<PointF3D> points;
        private bool isGotEdge;

        private Cell curCell = null;            // Ссылка на текущую ячейку.
        private Cell startCell = null;          // Ссылка на начальную ячейку.
        private Segment curSegment = null;      // Ссылка на теукщее ребро.
        private Segment startOfLine = null;     // Ссылка на условное начало линии уровня.

        public Grid() 
        {
            points = new LinkedList<PointF3D>();
            isGotEdge = false;
        }

        public List<PointF3D> Nodes { get; set; } = new List<PointF3D>();
        public List<Segment> Segments { get; set; } = new List<Segment>();
        public List<Cell> Cells { get; set; } = new List<Cell>();
        public List<LevelLinesKit> LevelLines { get; private set; } = new List<LevelLinesKit>();

        public void FindLevelLines(float[] levels)
        {
            foreach (var level in levels)
            {
                LevelLines.Add(new LevelLinesKit() {
                    Level = level,
                    Lines = FindLevelLines(level)
                });
            }
        }

        public LevelLine[] FindLevelLines(float level)
        {
            List<LevelLine> levelLines = new List<LevelLine>();
            Segment[] crossedSegments;
            Random rand = new Random();

            SetDefaultState();

            // Нулевой шаг.
            FindCrossedSegments(level);

            // Шаг первый.
            InitialNewLine(level);

        // Шаг второй.
        FindNextPoint:
            crossedSegments = curCell.GetCrossedSides();

            switch (crossedSegments.Length)
            {
                // Нашли начало линии.
                case 0:
                    if (!isGotEdge)
                        AddPoint(startOfLine.GetCrossPoint(level));

                    levelLines.Add(InitialNewLine(level));

                    if (GetCrossedSegmentsCount(false) > 0)
                        goto FindNextPoint;

                    break;
                // Нашли обычное ребро с пересечением.
                case 1:
                    curSegment = crossedSegments[0];
                    goto default;
                // Нашли два обычных ребра и возможно начало линии.
                case 2:
                    if (!curCell.GetOppositeSide(curSegment).Equals(startOfLine))
                        levelLines.Add(InitialNewLine(level));
                    else
                        goto case 3;

                    goto FindNextPoint;
                // Нашли три обычных ребра с пересечением.
                case 3:
                    //curSegment = curCell.GetSideWithCommonNode(curSegment, curCell.GetOppositeSide(curSegment));
                    // Случайный выбор ребра из двух возможных(смежных).
                    crossedSegments = curCell.GetOppositeSidesByNodes(curSegment);
                    
                    curSegment = (rand.Next(10) % 2 == 0) ? crossedSegments[0] : crossedSegments[1];
                    goto default;
                // Добавление точки в последовательность.
                default:
                    curSegment.IsMarked = true;

                    AddPoint(curSegment.GetCrossPoint(level));

                    if (curSegment.IsEdge && !curSegment.IsStartOfLevelLine && !isGotEdge)
                    {
                        curCell = GetAdjacentCell(startCell, startOfLine);
                        isGotEdge = true;
                        
                        goto FindNextPoint;
                    }

                    if (crossedSegments.Length >= 2) curCell.IsMarked = false;

                    curCell = GetAdjacentCell(curCell, curSegment);
                    curCell.IsMarked = true;

                    goto FindNextPoint;
            }
            
            //// Добавим последнию линию.
            //levelLines.Add(new LevelLine(level, points.ToArray()));

            return levelLines.ToArray();
        }
        
        private void AddPoint(PointF3D point)
        {
            // DEBUG
            //Console.WriteLine("point parent is " + point.Parent.Name);

            if (isGotEdge)
                points.AddFirst(point);
            else
                points.AddLast(point);
        }

        private int FindCrossedSegments(float level)
        {
            int countOfCrossedSegments = 0;

            foreach (var segment in Segments)
            {
                segment.IsCrossing(level);

                if (segment.IsCrossed)
                    countOfCrossedSegments++;
            }

            return countOfCrossedSegments;
        }

        private void SetDefaultState()
        {
            curCell = null;
            curSegment = null;
            startCell = null;
            startOfLine = null;
            
            foreach (var segment in Segments)
                segment.SetDefaultState();

            foreach (var cell in Cells)
                cell.IsMarked = false;
        }

        private Cell GetAdjacentCell(Cell currentCell, Segment commonSide)
        {
            foreach (var cell in Cells)
            {
                if (cell.ContainsSegment(commonSide) && !cell.Equals(currentCell))
                    return cell;
            }

            return currentCell;
        }

        private int GetCrossedSegmentsCount(bool isMarked)
        {
            int crossedSegmetnsCount = 0;

            foreach (var segment in Segments)
            {
                if (segment.IsCrossed && segment.IsMarked == isMarked)
                {
                    crossedSegmetnsCount++;
                }
            }

            return crossedSegmetnsCount;
        }

        private LevelLine InitialNewLine(float level)
        {
            LevelLine levelLine = new LevelLine(level, points.ToArray());

            // Поиск не маркированного ребра.
            foreach (var segment in Segments)
            {
                if (segment.IsCrossed && !segment.IsMarked)
                {
                    points.Clear();
                    isGotEdge = false;

                    startOfLine = segment;

                    curSegment = segment;
                    curSegment.IsMarked = true;
                    curSegment.IsStartOfLevelLine = true;

                    if (GetCrossedSegmentsCount(false) != 0)
                        AddPoint(curSegment.GetCrossPoint(level));

                    foreach (var cell in Cells)
                    {
                        if (cell.ContainsSegment(curSegment) && !cell.IsMarked)
                        {
                            curCell = cell;
                            startCell = cell;

                            break;
                        }
                    }

                    break;
                }
            }

            return levelLine;
        }

        public struct LevelLinesKit
        {
            public LevelLine[] Lines { get; set; }
            public float Level { get; set; }
        }

    }
}
