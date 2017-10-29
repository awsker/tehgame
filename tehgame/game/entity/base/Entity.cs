using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using tehgame.game.scenes.@base;

namespace tehgame.game.entity.@base
{
    public interface IEntity
    {
        Vector3 Position { get; set; }

        void LoadContent(ContentManager contentManager);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Draw(ICamera camera);
    }

    public abstract class Entity : IEntity
    {
        public Vector3 Position { get; set; }

        public virtual void LoadContent(ContentManager contentManager) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void Draw(ICamera camera) { }
    }
}