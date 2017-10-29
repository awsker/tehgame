using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tehgame.game.debug;

namespace tehgame.game.scenes.@base
{
    public interface ICamera
    {
        Matrix GetViewMatrix();
        Matrix GetProjectionMatrix();

        void Update(GameTime gameTime);
    }

    public class Camera : ICamera
    {
        readonly GraphicsDevice _graphicsDevice;
        private Vector3 _position = new Vector3(15, 10, 10);
        private Vector3 _direction = new Vector3(1, 1, 1);
        private Vector3 _up = Vector3.UnitZ;

        private float _velocity = .05f;

        private MouseState _previousMouseState;

        public Camera(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            Mouse.SetPosition(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);
            _previousMouseState = Mouse.GetState();
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateLookAt(_position, _position + _direction, _up);
        }

        public Matrix GetProjectionMatrix()
        {
            var fieldOfView = MathHelper.PiOver4;
            var nearClipPlane = 1;
            var farClipPlane = 200;
            var aspectRatio = _graphicsDevice.Viewport.Width / _graphicsDevice.Viewport.Height;

            return Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                _position += _direction * _velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _position += Vector3.Cross(_up, _direction) * _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                _position -= _direction * _velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                _position -= Vector3.Cross(_up, _direction) * _velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;

            _direction = Vector3.Transform(_direction, Matrix.CreateFromAxisAngle(_up, (-MathHelper.PiOver4 / 360) * (Mouse.GetState().X - _previousMouseState.X)));
            _direction = Vector3.Transform(_direction, Matrix.CreateFromAxisAngle(Vector3.Cross(_up, _direction), (MathHelper.PiOver4 / 100) * (Mouse.GetState().Y - _previousMouseState.Y)));
            _up = Vector3.Transform(_up, Matrix.CreateFromAxisAngle(Vector3.Cross(_up, _direction), (MathHelper.PiOver4 / 100) * (Mouse.GetState().Y - _previousMouseState.Y)));

            GameDebug.Log("MouseDeltaX", Mouse.GetState().X - _previousMouseState.X);
            GameDebug.Log("MouseDeltaY", Mouse.GetState().Y - _previousMouseState.Y);

            _previousMouseState = Mouse.GetState();
            //Mouse.SetPosition(_graphicsDevice.Viewport.Width / 2, _graphicsDevice.Viewport.Height / 2);

            GameDebug.Log("Direction", _direction);
        }
    }
}