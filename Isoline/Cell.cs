using System;
using System.Collections.Generic;

namespace Isoline
{
    public class Cell
    {
        private readonly Segment[] sides = new Segment[4];

        public Cell(Segment top, Segment left, Segment right, Segment bottom)
        {
            sides[0] = top;
            sides[1] = left;
            sides[2] = right;
            sides[3] = bottom;

            // DEBUG
            HashSet<string> leters = new HashSet<string>();

            foreach (var side in sides)
            {
                leters.Add(side.Start.Name);
                leters.Add(side.End.Name);
            }

            foreach (var letter in leters)
                Name += letter;
        }

        // DEBUG
        public string Name { get; set; }
        public bool IsMarked { get; set; } = false;


        public bool ContainsSegment(Segment segment)
        {
            foreach (var side in sides)
            {
                if (side.Equals(segment))
                    return true;
            }

            return false;
        }

        public Segment[] GetCrossedSides()
        {
            List<Segment> crossedSegment = new List<Segment>();

            foreach (var side in sides)
            {
                if (side.IsCrossed && !side.IsMarked && !side.IsStartOfLevelLine)
                    crossedSegment.Add(side);
            }

            return crossedSegment.ToArray();
        }

        public Segment GetOppositeSide(Segment currentSide)
        {
            foreach (var side in sides)
            {
                if (!side.Start.Equals(currentSide.Start) && !side.End.Equals(currentSide.End)
                    && !side.Start.Equals(currentSide.End) && !side.End.Equals(currentSide.Start))
                {
                    return side;
                }
            }

            return null;
        }

        public Segment[] GetOppositeSidesByNodes(Segment commonSide)
        {
            List<Segment> oppositeSides = new List<Segment>();
            Segment oppositeSide = GetOppositeSide(commonSide);

            foreach (var side in sides)
            {
                if (!side.Equals(oppositeSide) && !side.Equals(commonSide))
                    oppositeSides.Add(side);
            }

            return oppositeSides.ToArray();
        }

        public Segment GetSideWithCommonNode(Segment currentSide, Segment exceptionSide)
        {
            foreach (var side in sides)
            {
                if (side.Equals(currentSide) || side.Equals(exceptionSide))
                    continue;

                if (side.Start.Equals(currentSide.Start) || side.End.Equals(currentSide.End))
                    return side;
            }

            return null;
        }

        public override string ToString()
        {
            string str = $"Name = {Name} ";

            foreach (var side in sides)
                str += side.ToString() + " ";

            return str;
        }

    }
}
