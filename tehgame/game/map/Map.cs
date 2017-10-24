using tehgame.game.map.pathfinding;
using tehgame.game.util;

namespace tehgame.game.map
{
    public class Map
    {
        private PathGrid _grid;
        private SparseGrid<IMapEntity> _mapEntities;
        //private readonly IList<Entity> _static;
        //private readonly IList<Entity> _active;

        public Map(int xSize, int ySize)
        {
            _grid = new PathGrid(xSize * 2 + 1, ySize * 2 + 1);
            _mapEntities = new SparseGrid<IMapEntity>();
            //_static = new List<Entity>();
            //_active = new List<Entity>();
        }

        public void AddMapEntity(IMapEntity entity)
        {
            _mapEntities.AddValue(entity, entity.Position);
        }
    }
}
