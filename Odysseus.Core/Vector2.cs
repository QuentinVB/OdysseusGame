using System;

namespace Odysseus.Core
{
    internal struct Vector2
    {
        double _x;
        double _y;

        public Vector2(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
            {
                return false;
            }

            var vector = (Vector2)obj;
            return _x == vector._x &&
                   _y == vector._y;
        }

        public double Distance(Vector2 position)
        {
            return Distance(this, position);
        }
        public static double Distance(Vector2 a, Vector2 b)
        {
            return Math.Sqrt(a.X * a.X - b.X * b.X + a.Y * a.Y - b.Y * b.Y);
        }

        public override string ToString()
        {
            return $"{Math.Round(X,2)}:{Math.Round(Y, 2)}";
        }

        public override int GetHashCode()
        {
            var hashCode = 367829482;
            hashCode = hashCode * -1521134295 + _x.GetHashCode();
            hashCode = hashCode * -1521134295 + _y.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}