namespace Isoline
{
    public class LevelLine
    {
        public LevelLine() { }
        public LevelLine(float level, PointF3D[] points)
        {
            Level = level;
            Points = points;
        }

        public float Level { get; set; }
        public PointF3D[] Points { get; set; }

        public override string ToString()
        {
            string str = null;

            foreach (PointF3D point in Points)
                str += point.Parent.Name + " ";

            return str;
        }
    }
}
