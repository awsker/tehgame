using System.Collections.Generic;
using tehgame.game.map.generator;
using tehgame.game.util;

namespace tehgame.game.map
{
    public class MapWall : IMapEntity
    {
        public Point Position { get; private set; }
        public WallType Type { get; private set; }

        public MapWall(Point position, WallType type)
        {
            Position = position;
            Type = type;
        }

        public IEnumerable<Point> BlockedSquares()
        {    
            if(Type == WallType.Horizontal)
            {
                return new List<Point> { new Point(Position.X - 1, Position.Y), new Point(Position.X, Position.Y), new Point(Position.X + 1, Position.Y) };
            }
            else if(Type == WallType.Vertical)
            {
                return new List<Point> { new Point(Position.X, Position.Y - 1), new Point(Position.X, Position.Y), new Point(Position.X, Position.Y + 1) };
            }
            return new List<Point>();        
        }

        public static MapWall NorthWall(Point point)
        {
            return NorthWall(point.X, point.Y);
        }

        public static MapWall NorthWall(int x, int y)
        {
            var p = new Point(x * 2 + 1, y * 2);
            return new MapWall(p, WallType.Horizontal);
        }

        public static MapWall SouthWall(Point point)
        {
            return SouthWall(point.X, point.Y);
        }

        public static MapWall SouthWall(int x, int y)
        {
            var p = new Point(x * 2 + 1, y * 2 + 2);
            return new MapWall(p, WallType.Horizontal);
        }

        public static MapWall WestWall(Point point)
        {
            return WestWall(point.X, point.Y);
        }

        public static MapWall WestWall(int x, int y)
        {
            var p = new Point(x * 2, y * 2 + 1);
            return new MapWall(p, WallType.Vertical);
        }

        public static MapWall EastWall(Point point)
        {
            return EastWall(point.X, point.Y);
        }
        
        public static MapWall EastWall(int x, int y)
        {
            var p = new Point(x * 2 + 2, y * 2 + 1);
            return new MapWall(p, WallType.Vertical);
        }
    }
}
