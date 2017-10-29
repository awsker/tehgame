using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using tehgame.game.entity.@base;
using tehgame.game.scenes.@base;

namespace tehgame.game.scenes
{
    public interface IGameScene : IScene
    {
    }

    public class GameScene : Scene, IGameScene
    {
        private IEntity3D _entity;
        private ICamera _camera;

        public GameScene(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _entity = new Entity3D(contentManager.Load<Model>("trash/models/berra"));
            _camera = new Camera(GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            _entity.Update(gameTime);
            _camera.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _entity.Draw(_camera);
        }
    }
}