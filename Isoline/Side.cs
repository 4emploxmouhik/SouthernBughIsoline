using System;
using System.Collections.Generic;

namespace Isoline
{
    public enum Dock
    {
        Top, Left, Right, Bottom, None
    }

    public struct Side : IEquatable<Side>
    {
        private Segment segment;
        private Dock dock;

        public Side(Segment segment, Dock dock)
        {
            this.segment = segment;
            this.dock = dock;
        }

        public Side(Segment segment, string dockName)
        {
            this.segment = segment;

            switch (dockName.ToLower())
            {
                case "top":
                    dock = Dock.Top;
                    break;
                case "left":
                    dock = Dock.Left;
                    break;
                case "right":
                    dock = Dock.Right;
                    break;
                case "bottom":
                    dock = Dock.Bottom;
                    break;
                default:
                    dock = Dock.None;
                    break;
            }
        }

        public Segment Segment => segment;
        public Dock Dock { get => dock; set => dock = value; }

        public override bool Equals(object obj)
        {
            return obj is Side side && Equals(side);
        }

        public bool Equals(Side other)
        {
            return EqualityComparer<Segment>.Default.Equals(segment, other.segment) &&
                   dock == other.dock;
        }

        public override int GetHashCode()
        {
            var hashCode = -1799000208;
            hashCode = hashCode * -1521134295 + EqualityComparer<Segment>.Default.GetHashCode(segment);
            hashCode = hashCode * -1521134295 + dock.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"[Segment = {segment.ToString()}, Dock = {dock}]";
        }

        public static bool operator ==(Side left, Side right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Side left, Side right)
        {
            return !(left == right);
        }
    }
}
