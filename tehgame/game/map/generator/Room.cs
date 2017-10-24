using System;
using System.Collections.Generic;
using tehgame.game.util;

namespace tehgame.game.map.generator
{
    public class SquareRoom : IRoom
    {
        private int _width, _height, _xOffset, _yOffset;

        public SquareRoom(int width, int height, int xOffset, int yOffset)
        {
            _width = width;
            _height = height;
            _xOffset = xOffset;
            _yOffset = yOffset;
        }

        public int Width => _width;
        public int Height => _height;
        public int XOffset { get => _xOffset; set => _xOffset = value; }
        public int YOffset { get => _yOffset; set => _yOffset = value; }
        
        public IEnumerable<MapWall> GetWalls()
        {
            foreach(var p in GetSquaresOccupied())
            {
                if(p.X == XOffset)
                    yield return MapWall.WestWall(p);
                if (p.Y == YOffset)
                    yield return MapWall.NorthWall(p);
                if (p.X == XOffset + Width - 1)
                    yield return MapWall.EastWall(p);
                if (p.Y == YOffset + Height - 1)
                    yield return MapWall.SouthWall(p);
            }
        }
        /*
        public ICollection<Entity> GetActiveEntities()
        {
            throw new NotImplementedException();
        }
        
        public ICollection<Entity> GetStaticEntities()
        {
            throw new NotImplementedException();
        }*/

        public IEnumerable<Point> GetSquaresOccupied()
        {
            for (int x = XOffset; x < XOffset + Width; ++x)
            {
                for (int y = YOffset; y < YOffset + Height; ++y)
                {
                    yield return new Point(x, y);
                }
            }
        }

    }
}
