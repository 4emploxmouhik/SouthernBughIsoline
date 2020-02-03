using System.Collections.Generic;
using System.Drawing;

namespace Isoline
{
    public class LevelLine
    {
        private PointF[] points;
        private readonly float level;

        public LevelLine(PointF[] points, float level)
        {
            this.level = level;
            this.points = points;
        }

        public PointF[] Points { get => points; set => points = value; }
        public float Level => level;
        public bool IsClossed
        {
            get
            {
                return (points[0] == points[points.Length - 1]);
            }
        }

        public override string ToString()
        {
            string str = $"Level = {level}, IsClossed = {IsClossed} Points:\n\t";

            foreach (var point in points)
            {
                str += $"{point.ToString()}, ";
            }

            return str;
        }
    }

    public struct LevelLinesKit
    {
        private float levelValue;
        private List<LevelLine> level;

        public LevelLinesKit(float levelValue, List<LevelLine> level) : this()
        {
            this.levelValue = levelValue;
            this.level = level;
        }

        public List<LevelLine> Lines { get; set; }
        public float Level { get; set; }
    }
}
