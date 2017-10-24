using System.Collections.Generic;
using tehgame.game.util;

namespace tehgame.game.map
{
    public interface IMapEntity
    {
        Point Position { get; }
        IEnumerable<Point> BlockedSquares();
    }
}
