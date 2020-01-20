using System;
using System.Collections.Generic;
using System.Drawing;

namespace Isoline
{
    public class Segment : IEquatable<Segment>
    {
        private protected readonly Node start;
        private protected readonly Node end;
        private protected readonly int id;

        public Segment(Node first, Node second)
        {
            if ((first.Location.X + first.Location.Y) <= (second.Location.X + second.Location.Y))
            {
                start = first;
                end = second;
            }
            else
            {
                start = second;
                end = first;
            }

            IsCrossed = false;
            IsEdge = false;
            IsMarked = false;
            IsStartOfLevelLine = false;
        }

        public Segment(Node first, Node second, int id) : this(first, second)
        {
            this.id = id;
        }

        public Node[] Nodes => new[] { start, end };
        public int Id => id;
        public bool IsCrossed { get; set; }
        public bool IsEdge { get; set; }
        public bool IsMarked { get; set; }
        public bool IsStartOfLevelLine { get; set; }
        public string Name { get; set; }

        public static double GetDistance(Node start, Node end)
        {
            return Math.Sqrt(Math.Pow(end.Location.X - start.Location.X, 2) + Math.Pow(end.Location.Y - start.Location.Y, 2));
        }

        public static double GetDistance(PointF start, PointF end)
        {
            return Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
        }

        public bool ContainsNode(Node point)
        {
            return start == point || end == point;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Segment);
        }

        public bool Equals(Segment other)
        {
            return other != null &&
                   EqualityComparer<Node>.Default.Equals(start, other.start) &&
                   EqualityComparer<Node>.Default.Equals(end, other.end) &&
                   id == other.id;
        }

        public PointF GetCrossPoint(float level)
        {
            float t = Math.Abs((level - start.Level) / Math.Abs(start.Level - end.Level));

            PointF crossPoint = new PointF()
            {
                X = ((1 - t) * start.Location.X) + (t * end.Location.X),
                Y = ((1 - t) * start.Location.Y) + (t * end.Location.Y)
            };

            return crossPoint;
        }

        public override int GetHashCode()
        {
            var hashCode = 399783785;
            hashCode = hashCode * -1521134295 + EqualityComparer<Node>.Default.GetHashCode(start);
            hashCode = hashCode * -1521134295 + EqualityComparer<Node>.Default.GetHashCode(end);
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            return hashCode;
        }

        public bool IsCrossing(float level)
        {
            if (level == start.Level)
            {
                return IsCrossed = true;
            }
            else
            {
                return IsCrossed = ((level < start.Level) && (level > end.Level)) || ((level > start.Level) && (level < end.Level));
            }
        }

        public override string ToString()
        {
            return $"[{((Name.Length > 0) ? $"Name = {Name}, " : "")}Id = {id}, IsCrossed = {IsCrossed}, IsEdge = {IsEdge}, "
                + $"IsMarked = {IsMarked}, IsStartOfLevelLine = {IsStartOfLevelLine}, Start = {start.ToString()}], End = {end.ToString()}]";
        }
    }
}
