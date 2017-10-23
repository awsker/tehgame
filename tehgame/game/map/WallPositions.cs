namespace tehgame.game.map
{
    public class WallPositions
    {
        private int _x, _y;
        /// <summary>
        ///  Helper class to calculate the positions of the neigbouring walls in the wall array in relation to a tile
        /// </summary>
        /// <param name="tileX">X Position of tile</param>
        /// <param name="tileY">Y Position of tile</param>
        public WallPositions(int tileX, int tileY)
        {
            _x = tileX;
            _y = tileY;
        }

        public Point NorthWall
        {
            get { return new Point(_x / 2 + 1, y / 2); }
        } 

        public Point WestWall
        {
            get { return new Point(_x / 2, y / 2 + 1); }
        }
        
        public Point EastWall
        {
            get { return new Point(_x / 2 + 2, _y + 1); }
        }

        public Point SouthWall
        {
            get { return new Point(_x / 2 + 1, _y / 2 + 2); }
        }

        public Point MiddleWall
        {
            get { return new Point(_x / 2 + 1, _y / 2 + 1); }
        }
    }
}
