namespace tehgame.game.map.pathfinding
{
    public class PathGrid
    {
        private byte[,] _grid;

        const byte None = 0;
        const byte Blocked = 1;
        
        public PathGrid(int width, int height)
        {
            _grid = new byte[width, height];
        }

        public Path PathFromTo(int startX, int startY, int destX, int destY)
        {
            return null;
        }
    }
}
