using System;

namespace tehgame.game.map.generator
{
    public class DungeonGenerator : MapGenerator
    {
        Random _random;
        public DungeonGenerator() : this(new Random().Next()) { }
        
        public DungeonGenerator(int seed) {
            _random = new Random(seed);
        }

        public override Map GenerateMap(int width, int height)
        {
            var blueprint = createBlueprint(width, height);
            return blueprint.GenerateMapFromBlueprint();
        }

        private MapBlueprint createBlueprint(int width, int height)
        {
            var blueprint = new MapBlueprint(width, height);
            for (int i = 0; i < 10; ++i)
            {
                var rWidth = 3 + _random.Next(15);
                var rHeight = 3 + _random.Next(15);
                var xOffset = _random.Next(width - rWidth - 1);
                var yOffset = _random.Next(height - rHeight - 1);
                var room = new SquareRoom(rWidth, rHeight, xOffset, yOffset);

                blueprint.AddRoom(room);
            }
            return null;
        }
    }
}
