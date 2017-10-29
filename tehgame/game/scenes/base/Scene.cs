using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace tehgame.game.scenes.@base
{
    public interface IScene
    {
        void LoadContent(ContentManager contentManager);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }

    public abstract class Scene : IScene
    {
        public virtual void LoadContent(ContentManager contentManager) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}