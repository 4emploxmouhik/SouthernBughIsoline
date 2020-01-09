using System;

namespace Isoline
{
    public class PointF3D
    {
        // DEBUG
        public PointF3D() { }
        
        public PointF3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        // DEBUG
        public Segment Parent { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is PointF3D) || (obj == null))
                throw new ArgumentException("Not a Point3D or equals null.", nameof(obj));

            PointF3D point = (PointF3D)obj;

            return (point.X == X) && (point.Y == Y) && (point.Z == Z);
        }

        public override string ToString()
        {
            return $"[Name = {Name}, X = {X}, Y = {Y}, Z = {Z}]";
        }
    }
}
