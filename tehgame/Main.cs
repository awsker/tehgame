using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tehgame
{
    public class Main : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly IList<Tuple<Model, Vector3>> _models = new List<Tuple<Model, Vector3>>();

        private Vector3 _rotation;
        private Vector3 _cameraPosition;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _models.Add(Tuple.Create(Content.Load<Model>("trash/models/berra"), new Vector3(0, 0, 0)));
            //_models.Add(Tuple.Create(Content.Load<Model>("trash/models/berra"), new Vector3(10, 10, 10)));
            //_models.Add(Tuple.Create(Content.Load<Model>("trash/models/berra"), new Vector3(-10, -10, -10)));
            //_models.Add(Tuple.Create(Content.Load<Model>("trash/models/berra"), new Vector3(4, 2, 1)));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var modelRotation = _rotation;
            modelRotation.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            modelRotation.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            modelRotation.Z += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            _rotation = modelRotation;

            var cameraPosition = _cameraPosition;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cameraPosition.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            if (Keyboard.GetState().IsKeyDown(Keys.L))
                cameraPosition.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds * .001f;
            _cameraPosition = cameraPosition;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (var model in _models)
                DrawModel(model.Item1, model.Item2);

            base.Draw(gameTime);
        }

        private void DrawModel(Model model, Vector3 position)
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

                    var aspectRatio = _graphics.PreferredBackBufferWidth / (float)_graphics.PreferredBackBufferHeight;
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
            var rotationX = Matrix.CreateRotationX(_rotation.X);
            var rotationY = Matrix.CreateRotationY(_rotation.Y);
            var rotationZ = Matrix.CreateRotationZ(_rotation.Z);

            // We combine the two to have the model move in a circle:
            var combined = translationMatrix * rotationX * rotationY * rotationZ;

            return combined;
        }
    }
}
