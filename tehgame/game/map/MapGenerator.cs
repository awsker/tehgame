namespace tehgame.game.map
{
    public abstract class MapGenerator
    {
        public abstract Map GenerateMap(int xSize, int ySize);

        public Map CreateRoom(int xSize, int ySize, Tile floor)
        {
            var room = new Map(xSize, ySize);
            for(int x = 0; x < xSize; ++x)
            {
                for(int y = 0; y < ySize; ++y)
                {
                    var wallPositions = new WallPositions(x, y);
                    room.Tiles[x, y] = floor;
                    if (x == 0)
                        room.Walls[wallPositions.WestWall] = Wall.Vertical;
                    if (y == 0)
                        room.Walls[wallPositions.NorthWall] = Wall.Horizontal;
                    //Last column
                    if (x == xSize - 1)
                        room.Walls[wallPositions.EastWall] = Wall.Vertical;
                    //Last row
                    if (y == ySize - 1)
                        room.Walls[wallPositions.SouthWall] = Wall.Vertical;

                }
            }
            return room
        }
    }
}
