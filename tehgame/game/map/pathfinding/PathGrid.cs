namespace tehgame.game.map.pathfinding
{
    public class PathGrid
    {
        private byte[,] _grid;

        public const byte None = 0;
        public const byte Blocked = 1;

        private int _width, _height;
        
        public PathGrid(int width, int height)
        {
            _width = width;
            _height = height;
            _grid = new byte[width, height];
        }

        public void SetValue(byte value, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                _grid[x, y] = value;
            }
        }

        public Path PathFromTo(int startX, int startY, int destX, int destY)
        {
            return null;
        }
    }
}
