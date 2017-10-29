using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tehgame.game.scenes.@base;

namespace tehgame.game.scenes
{
    public interface IGameScene : IScene
    {
    }

    public class GameScene : Scene, IGameScene
    {
        private Model _model;
        private Vector3 _modelRotation;
        private Vector3 _cameraPosition;

        public override void LoadContent(ContentManager contentManager)
        {
            _model = contentManager.Load<Model>("trash/models/berra");
        }

        public override void Update(GameTime gameTime)
        {
            var modelRotation = _modelRotation;
            modelRotation.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            modelRotation.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            modelRotation.Z += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            _modelRotation = modelRotation;

            var cameraPosition = _cameraPosition;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cameraPosition.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            if (Keyboard.GetState().IsKeyDown(Keys.L))
                cameraPosition.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            _cameraPosition = cameraPosition;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawModel(_model);
        }

        private void DrawModel(Model model)
        {
            foreach (var mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.World = GetWorldMatrix();

                    var cameraPosition = new Vector3(0, -30, 0);
                    var cameraLookAtVector = Vector3.Zero;
                    var cameraUpVector = Vector3.UnitZ;

                    effect.View = Matrix.CreateLookAt(cameraPosition, cameraLookAtVector, cameraUpVector);

                    var aspectRatio = GameSettings.PreferredBackBufferWidth / GameSettings.PreferredBackBufferHeight;
                    var fieldOfView = MathHelper.PiOver4;
                    var nearClipPlane = 1;
                    var farClipPlane = 200;

                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
                }

                mesh.Draw();
            }
        }

        private Matrix GetWorldMatrix()
        {
            const float circleRadius = 8;
            const float heightOffGround = 3;

            // this matrix moves the model "out" from the origin
            var translationMatrix = Matrix.CreateTranslation(circleRadius, 0, heightOffGround);

            // this matrix rotates everything around the origin
            var rotationX = Matrix.CreateRotationX(_modelRotation.X);
            var rotationY = Matrix.CreateRotationY(_modelRotation.Y);
            var rotationZ = Matrix.CreateRotationZ(_modelRotation.Z);

            // We combine the two to have the model move in a circle:
            var combined = translationMatrix * rotationX * rotationY * rotationZ;

            return combined;
        }
    }
}