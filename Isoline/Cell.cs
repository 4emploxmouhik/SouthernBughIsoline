using System;
using System.Collections.Generic;
using System.Drawing;

namespace Isoline
{
    public class Cell : IEquatable<Cell>
    {
        private readonly Side[] sides;
        private readonly int id;

        public Cell(Segment top, Segment left, Segment right, Segment bottom)
        {
            sides = new Side[4];
            sides[0] = new Side(top, Dock.Top);
            sides[1] = new Side(left, Dock.Left);
            sides[2] = new Side(right, Dock.Right);
            sides[3] = new Side(bottom, Dock.Bottom);

            IsMarked = false;
        }

        public Cell(Segment top, Segment left, Segment right, Segment bottom, int id) : this(top, left, right, bottom)
        {
            this.id = id;
        }

        public Cell(Side[] sides, int id)
        {
            this.sides = sides;
            this.id = id;
        }

        public Side[] Sides => sides;
        public int Id => id;
        public string Name { get; set; }
        public bool IsMarked { get; set; }

        public bool ContainsSide(Side someSide)
        {
            foreach (var side in sides)
            {
                if (side == someSide)
                    return true;
            }

            return false;
        }

        public PointF[] GetCrossPointsOfDiagonals(float level, PointF endOfLocalLine)
        {
            Segment[] diagonals = new[] {
                new Segment(sides[0].Segment.Nodes[0], sides[3].Segment.Nodes[1]),
                new Segment(sides[3].Segment.Nodes[0], sides[0].Segment.Nodes[1]),
            };
            List<PointF> points = new List<PointF>();

            foreach (var diagonal in diagonals)
            {
                if (diagonal.IsCrossing(level))
                    points.Add(diagonal.GetCrossPoint(level));
            }

            if (points.Count == 2)
            {
                double d1 = Segment.GetDistance(points[0], endOfLocalLine),
                       d2 = Segment.GetDistance(points[1], endOfLocalLine);

                if (d1 < d2)
                    points.Reverse();
            }

            return points.ToArray();
        }

        public Side[] GetCrossedSides()
        {
            List<Side> crossedSegment = new List<Side>();

            foreach (var side in sides)
            {
                if (side.Segment.IsCrossed && !side.Segment.IsMarked && !side.Segment.IsStartOfLevelLine)
                    crossedSegment.Add(side);
            }

            return crossedSegment.ToArray();
        }

        public Side GetOppositeSide(Side currentSide)
        {
            foreach (var side in sides)
            {
                var sideNodes = side.Segment.Nodes;
                var curSideNodes = currentSide.Segment.Nodes;

                if (sideNodes[0].Location != curSideNodes[0].Location && sideNodes[1].Location != curSideNodes[1].Location &&
                    sideNodes[0].Location != curSideNodes[1].Location && sideNodes[1].Location != curSideNodes[0].Location)
                {
                    return side;
                }

            }

            return currentSide;
        }

        public Side[] GetOppositeSidesByNodes(Side commonSide)
        {
            List<Side> oppositeSides = new List<Side>();
            Side oppositeSide = GetOppositeSide(commonSide);

            foreach (var side in sides)
            {
                if (side != oppositeSide && side != commonSide)
                    oppositeSides.Add(side);
            }

            return oppositeSides.ToArray();
        }

        public Side GetSideWithCommonNode(Side currentSide, Side exceptionSide)
        {
            foreach (var side in sides)
            {
                if (side == currentSide || side == exceptionSide)
                    continue;

                if (side.Segment.ContainsNode(currentSide.Segment.Nodes[0]) || side.Segment.ContainsNode(currentSide.Segment.Nodes[1]))
                    return side;
            }

            return currentSide;
        }
        
        public override bool Equals(object obj)
        {
            return Equals(obj as Cell);
        }

        public bool Equals(Cell other)
        {
            return other != null &&
                   EqualityComparer<Side[]>.Default.Equals(sides, other.sides) &&
                   id == other.id;
        }

        public override int GetHashCode()
        {
            var hashCode = -1612763057;
            hashCode = hashCode * -1521134295 + EqualityComparer<Side[]>.Default.GetHashCode(sides);
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string str = $"[{(Name.Length > 0 ? $"Name = {Name}, " : "")}Id = {id}, IsMarked = {IsMarked}, Sides:";

            foreach (var side in sides)
                str += "\n\t" + side.ToString();

            return str;
        }
    }
}
