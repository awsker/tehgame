using System.Collections.Generic;
using tehgame.game.util;

namespace tehgame.game.map.generator
{
    public interface IRoom
    {
        int Width { get; }
        int Height { get; }
        int XOffset { get; set; }
        int YOffset { get; set; }

        IEnumerable<Point> GetSquaresOccupied();
        IEnumerable<MapWall> GetWalls();
        /*
        ICollection<Entity> GetStaticEntities();
        ICollection<Entity> GetActiveEntities();
        */
    }
}
