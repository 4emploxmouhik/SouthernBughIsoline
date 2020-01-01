using System;

namespace Isoline
{
    public class Segment
    {
        public Segment(PointF3D first, PointF3D second)
        {
            if ((first.X + first.Y) <= (second.X + second.Y))
            {
                Start = first;
                End = second;
            }
            else
            {
                Start = second;
                End = first;
            }

            IsCrossed = false;


            // DEBUG
            Start.Parent = this;
            End.Parent = this;
        }

        // DEBUG
        public string Name { get; set; }


        public int Number { get; set; }
        public PointF3D Start { get; private set; }
        public PointF3D End { get; private set; }
        
        public bool IsCrossed { get; private set; }
        public bool IsEdge { get; set; } = false;
        public bool IsMarked { get; set; } = false;
        public bool IsStartOfLevelLine { get; set; } = false;

        public void CopyTo(out Segment segmentCopy)
        {
            segmentCopy = new Segment(Start, End)
            {
                Number = this.Number,
                IsCrossed = this.IsCrossed,
                IsEdge = this.IsEdge,
                IsMarked = this.IsMarked,
                IsStartOfLevelLine = this.IsStartOfLevelLine
            };
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Segment) || (obj == null))
                throw new ArgumentException("Not a Segment or equals null.", nameof(obj));

            Segment edge = (Segment)obj;

            return (edge.Number == Number) && edge.Start.Equals(Start) && edge.End.Equals(End);
        }

        public PointF3D GetCrossPoint(float level)
        {
            float t = (level - Start.Z) / Math.Abs(Start.Z - End.Z);

            PointF3D crossPoint = new PointF3D()
            {
                X = ((1 - t) * Start.X) + (t * End.X),
                Y = ((1 - t) * Start.Y) + (t * End.Y),
                Z = level

                // DEBUG
                , Parent = this
            };

            return crossPoint;
        }

        public bool IsCrossing(float level)
        {
            if (level == Start.Z)
            {
                return IsCrossed = true;
            }
            else
            {
                return IsCrossed = ((level < Start.Z) && (level > End.Z)) || ((level > Start.Z) && (level < End.Z));
            }
        }

        public void SetDefaultState()
        {
            IsCrossed = false;
            IsMarked = false;
            IsStartOfLevelLine = false;
        }

        public override string ToString()
        {
            return $"[Name = {Name}, Number = {Number}, Start = {Start.ToString()}, End = {End.ToString()}, IsCrossed = {IsCrossed}, IsMarked = {IsMarked}]";
        }
    }
}
