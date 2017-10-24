using System;
using System.Collections.Generic;
using tehgame.game.util;

namespace tehgame.game.map.generator
{
    public class MapBlueprint
    {
        private IRoom[,] _roomsArray;
        private IList<IRoom> _roomsList;
        private int _width, _height;
        
        public MapBlueprint(int width, int height)
        {
            _width = width;
            _height = height;
            _roomsArray = new IRoom[width, height];
            _roomsList = new List<IRoom>();
        }
        
        public void AddRoom(IRoom room)
        {
            AddRoom(room, room.XOffset, room.YOffset);
        }

        public void AddRoom(IRoom room, int xOffset, int yOffset)
        {
            room.XOffset = xOffset;
            room.YOffset = yOffset;
            if (room.XOffset < 0 || room.YOffset < 0 || room.XOffset + room.Width >= _width || room.YOffset + room.Height >= _height)
                throw new Exception("Room can not fit in map");

            foreach(var square in room.GetSquaresOccupied())
            {
                _roomsArray[square.X, square.Y] = room;
            }
            _roomsList.Add(room);
        }

        public Map GenerateMapFromBlueprint()
        {
            var map = new Map(_width * 2 + 1, _height * 2 + 1);
            
            for(int x = 0;  x < _width; ++x)
            {
                for(int y = 0; y < _height; ++y)
                {
                    var room = _roomsArray[x, y];
                    if (room == null)
                        continue;

                    var point = new Point(x, y);
                    var px = 1 + x * 2;
                    var py = 1 + y * 2;

                    if (x == 0 || _roomsArray[x - 1, y] != room)
                        map.AddMapEntity(MapWall.WestWall(point));
                    if (x == _width - 1 || _roomsArray[x + 1, y] != room)
                        map.AddMapEntity(MapWall.EastWall(point));
                    if (y == 0 || _roomsArray[x, y - 1] != room)
                        map.AddMapEntity(MapWall.NorthWall(point));
                    if (y == _height - 1 || _roomsArray[x, y + 1] != room)
                        map.AddMapEntity(MapWall.SouthWall(point));

                    map.AddMapEntity(new MapTile(new Point(px, py), TileType.Empty));
                }
            }
            return map;
        }
    }
}
