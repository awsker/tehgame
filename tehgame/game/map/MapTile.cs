using System.Collections.Generic;
using tehgame.game.map.generator;
using tehgame.game.util;

namespace tehgame.game.map
{
    public class MapTile : IMapEntity
    {
        public Point Position { get; private set; }
        public TileType Type { get; private set; }

        public MapTile(Point position, TileType type)
        {
            Position = position;
            Type = type;
        }

        public IEnumerable<Point> GetBlockedSquares()
        {
            if (Type == TileType.Blocked)
            {
                //Block 3x3 squares
                for (int x = Position.X - 1; x <= Position.X + 1; ++x)
                    for (int y = Position.Y - 1; y <= Position.Y + 1; ++y)
                        yield return new Point(x, y);
            }
        }
    }
}
