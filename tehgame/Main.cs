using Microsoft.Xna.Framework;
using tehgame.game;

namespace tehgame
{
    public class Main : Game
    {
        public Main()
        {
            var deviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = GameSettings.PreferredBackBufferWidth,
                PreferredBackBufferHeight = GameSettings.PreferredBackBufferHeight,
                //IsFullScreen = true,
                SynchronizeWithVerticalRetrace = true,
                PreferMultiSampling = false
            };

            var gameManager = new GameManager(this);
            Components.Add(gameManager);
        }
    }
}
