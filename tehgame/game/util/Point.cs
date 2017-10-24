using System;

namespace tehgame.game.util
{
    public class Point : IEquatable<Point>
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return (X + " " + Y).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return point != null && Equals(point);
        }

        public bool Equals(Point other)
        {
            return other != null && other.X == X && other.Y == Y;
        }
    }
}
