using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tehgame.game.scenes.@base;

namespace tehgame.game.entity.@base
{
    public interface IEntity3D : IEntity
    {
        Model Model { get; }
    }

    public class Entity3D : Entity, IEntity3D
    {
        public Entity3D(Model model)
        {
            Model = model;

            Transform = new Transform(Vector3.Zero, new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f));
        }

        public Model Model { get; }
        
        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(ICamera camera)
        {
            foreach (var mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;

                    effect.World = GetWorldMatrix();
                    effect.View = camera.GetViewMatrix();
                    effect.Projection = camera.GetProjectionMatrix();
                }

                mesh.Draw();
            }
        }

        private Matrix GetWorldMatrix()
        {
            var translation = Matrix.CreateTranslation(Transform.Position);
            var rotationX = Matrix.CreateRotationX(Transform.Rotation.X);
            var rotationY = Matrix.CreateRotationY(Transform.Rotation.Y);
            var rotationZ = Matrix.CreateRotationZ(Transform.Rotation.Z);
            var scale = Matrix.CreateScale(Transform.Scale);

            return translation * rotationX * rotationY * rotationZ * scale;
        }
    }
}