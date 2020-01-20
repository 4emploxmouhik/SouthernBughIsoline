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
    }

    public struct LevelLinesKit
    {
        public List<LevelLine> Lines { get; set; }
        public float Level { get; set; }
    }
}
