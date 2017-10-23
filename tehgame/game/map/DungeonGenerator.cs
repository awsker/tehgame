using System;

namespace tehgame.game.map
{
    public class DungeonGenerator : MapGenerator
    {
        public override Map GenerateMap(int xSize, int ySize)
        {
            var map = new Map(xSize, ySize);
            return map;
        }
    }
}
