using tehgame.game.map.pathfinding;
using tehgame.game.util;

namespace tehgame.game.map
{
    public class Map
    {
        private PathGrid _grid;
        private int _width, _height;
        private int _actualWidth, _actualHeight;
        private SparseGrid<IMapEntity> _mapEntities;
        //private readonly IList<Entity> _static;
        //private readonly IList<Entity> _active;

        public Map(int width, int height)
        {
            _width = width;
            _height = height;
            _actualWidth = width * 2 + 1;
            _actualHeight = height * 2 + 1;
            _mapEntities = new SparseGrid<IMapEntity>();
            //_static = new List<Entity>();
            //_active = new List<Entity>();
        }

        public void AddMapEntity(IMapEntity entity)
        {
            if (entity.Position.X >= 0 && entity.Position.X < _actualWidth &&
                entity.Position.Y >= 0 && entity.Position.Y < _actualHeight)
                _mapEntities.AddValue(entity, entity.Position);
        }

        public void UpdatePathGrid()
        {
            _grid = new PathGrid(_actualWidth, _actualHeight);
            foreach (var entity in _mapEntities)
            {
                foreach (var pos in entity.GetBlockedSquares())
                {
                    _grid.SetValue(PathGrid.Blocked, pos.X, pos.Y);
                }
            }
        }
    }
}
