using System;
using System.Drawing;

namespace Isoline
{
    public class Node : IEquatable<Node>
    {
        private readonly float x;
        private readonly float y;
        private readonly int id;

        public Node(float x, float y, int id, float level)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.Level = level;
        }

        public Node(PointF location, int id, float level) : this(location.X, location.Y, id, level) { }

        public PointF Location => new PointF(x, y);
        public int Id => id;
        public float Level { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            return other != null &&
                   x == other.x &&
                   y == other.y &&
                   id == other.id &&
                   Level == other.Level;
        }

        public override int GetHashCode()
        {
            var hashCode = 487776672;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Level.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"[{((Name.Length > 0) ? $"Name = {Name}, " : "")}Id = {id}, Location = [{x}; {y}], Level = {Level}]";
        }
    }
}
