namespace tehgame.game.map
{
    public class ItemGrid<T>
    {
        private T[,] _items;
        private int _xSize, _ySize;

        public ItemGrid(int xSize, int ySize)
        {
            _xSize = xSize;
            _ySize = ySize;
            _items = new T[xSize, ySize];
        }

        public int XSize => _xSize;
        public int YSize => _ySize;

        public T this[int x, int y]
        {
            get
            {
                return _items[x, y];
            }
            set
            {
                if (x < 0 || y < 0 || x >= _xSize || y >= _ySize)
                    return;
                _items[x, y] = value;
            }
        }

        public T this[Point point]
        {
            get { return this[point.X, point.Y] }
            set { this[point.X, point.Y] = value; }
        }

        public void PasteInto(ItemGrid<T> target, int xOffset, int yOffset)
        {
            for (int x = 0; x < _xSize; ++x)
            {
                var tx = x + xOffset;
                //Not yet within target columns
                if (tx < 0)
                    continue;

                //Past target columns, no need to continue loop
                if (tx >= target.XSize)
                    break;

                for (int y = 0; y < _ySize; ++y)
                {
                    var ty = y + yOffset;
                    //Not yet within target rows
                    if (ty < 0)
                        continue;

                    //Past target rows, no need to continue loop
                    if (ty >= target.YSize)
                        break;

                    target[tx, ty] = this[x, y];
                }
            }
        }
    }
}
