using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tehgame.game.scenes;
using tehgame.game.scenes.@base;

namespace tehgame.game
{
    public interface IGameManager
    {
    }

    public class GameManager : DrawableGameComponent, IGameManager
    {
        private readonly Game _game;
        private readonly ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

        private IScene _scene;

        public GameManager(Game game) : base(game)
        {
            _game = game;
            _contentManager = new ContentManager(game.Services, "Content");
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _scene = new GameScene();
            _scene.LoadContent(_contentManager);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Exit();

            _scene.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _scene.Draw(_spriteBatch);
        }
    }
}