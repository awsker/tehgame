using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tehgame.game.debugging;
using tehgame.game.scenes;
using tehgame.game.scenes.@base;

namespace tehgame.game
{
    public interface IGameManager
    {
        GraphicsDevice GraphicsDevice { get; }
    }

    public class GameManager : DrawableGameComponent, IGameManager
    {
        private readonly Game _game;
        private readonly ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

        private IScene _scene;

        private SpriteFont _debugFont;

        public GameManager(Game game) : base(game)
        {
            _game = game;
            _contentManager = new ContentManager(game.Services, "Content");
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scene = new GameScene(GraphicsDevice);
            _scene.LoadContent(_contentManager);
            _debugFont = _contentManager.Load<SpriteFont>("fonts/debug");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Exit();

            _scene.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _scene.Draw(_spriteBatch);

            for (var i = 0; i < GameDebug.Messages.Count; i++)
            {
                var message = GameDebug.Messages[i];
                _spriteBatch.DrawString(_debugFont, message, new Vector2(10, 10 + i * 16), Color.White);
            }
            GameDebug.Messages.Clear();

            _spriteBatch.End();
        }
    }
}