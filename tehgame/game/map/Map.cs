namespace tehgame.game.map
{
    public class Map
    {
        private readonly ItemGrid<Tile> _tiles;
        private readonly ItemGrid<Wall> _walls;

        public Map(int xSize, int ySize)
        {
            _tiles = new ItemGrid<Tile>(xSize, ySize);
            _walls = new ItemGrid<Wall>(xSize*2 + 1, ySize*2 + 1);
        }

        public void PasteInto(Map target, int xOffset, int yOffset)
        {
            _tiles.PasteInto(target._tiles, xOffset, yOffset);
            _walls.PasteInto(target._walls, xOffset, yOffset);
        }
        
        public ItemGrid<Tile> Tiles => _tiles;
        public ItemGrid<Wall> Walls => _walls;
    }
}
