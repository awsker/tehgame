using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tehgame.game.util;

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
        private Vector3 _position = new Vector3(0, 0, 0);
        private readonly Vector3 _upVector = Vector3.UnitZ;

        private float _rotationZ;
        private float _rotationX;

        private float _velocity = .01f;

        private Vector3 _lookAtVector = new Vector3(0f, -1f, 0f);

        private MouseState _previousMouseState;

        public Camera(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            Mouse.SetPosition(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);
            _previousMouseState = Mouse.GetState();
        }

        public Matrix GetViewMatrix()
        {
            _lookAtVector=  new Vector3(0, -5f, -.5f);
            //var lookAtVector  = new Vector3(0, -1f, 0f);
            //var lookAtVector  = new Vector3(0, 0, 0);
            var rotationZMatrix = Matrix.CreateRotationZ(_rotationZ);
            var rotationXMatrix = Matrix.CreateRotationX(_rotationX);

            _lookAtVector = Vector3.Transform(_lookAtVector, rotationZMatrix);
            _lookAtVector = Vector3.Transform(_lookAtVector, rotationXMatrix);

            _lookAtVector += _position;

            return Matrix.CreateLookAt(_position, _lookAtVector, _upVector);
            //return Matrix.CreateLookAt(_position, _position + _direction, _upVector);
        }

        public Matrix GetProjectionMatrix()
        {
            var fieldOfView = MathHelper.PiOver4;
            var nearClipPlane = 1;
            var farClipPlane = 200;
            var aspectRatio = _graphicsDevice.Viewport.Width / (float) _graphicsDevice.Viewport.Height;

            return Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
        }

        public void Update(GameTime gameTime)
        {
            var deltaX = Mouse.GetState().X - _previousMouseState.X;
            var deltaY = Mouse.GetState().Y - _previousMouseState.Y;
            
            _rotationZ -= deltaX * (float) gameTime.ElapsedGameTime.TotalMilliseconds * .0001f;
            _rotationX += deltaY * (float) gameTime.ElapsedGameTime.TotalMilliseconds * .0001f;

            var rotationZMatrix = Matrix.CreateRotationZ(_rotationZ);
            var rotationXMatrix = Matrix.CreateRotationX(_rotationX);

            var forwardVector = new Vector3(0f, -1f, 0f);
            forwardVector = Vector3.Transform(forwardVector, rotationZMatrix);
            forwardVector = Vector3.Transform(forwardVector, rotationXMatrix);

            var sideVector = new Vector3(-1f, 0f, 0f);
            sideVector = Vector3.Transform(sideVector, rotationZMatrix);
            sideVector = Vector3.Transform(sideVector, rotationXMatrix);

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                _position += forwardVector * _velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                _position -= forwardVector * _velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _position -= sideVector * _velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                _position += sideVector * _velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;

            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            //    _position -= _direction * _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //if (Keyboard.GetState().IsKeyDown(Keys.A))
            //    _position -= Vector3.Cross(_upVector, _direction) * _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //if (Keyboard.GetState().IsKeyDown(Keys.S))
            //    _position += _direction * _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //    _position += Vector3.Cross(_upVector, _direction) * _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //_direction = Vector3.Transform(_direction, Matrix.CreateFromAxisAngle(_upVector, (-MathHelper.PiOver4 / 360) * (Mouse.GetState().X - _previousMouseState.X)));
            //_direction = Vector3.Transform(_direction, Matrix.CreateFromAxisAngle(Vector3.Cross(_upVector, _direction), (MathHelper.PiOver4 / 100) * (Mouse.GetState().Y - _previousMouseState.Y)));
            //_upVector = Vector3.Transform(_upVector, Matrix.CreateFromAxisAngle(Vector3.Cross(_upVector, _direction), (MathHelper.PiOver4 / 100) * (Mouse.GetState().Y - _previousMouseState.Y)));

            GameDebug.Log("MouseDeltaX", deltaX);
            GameDebug.Log("MouseDeltaY", deltaY);
            GameDebug.Log("RotationZ", _rotationZ);
            GameDebug.Log("RotationX", _rotationX);

            Mouse.SetPosition(_graphicsDevice.Viewport.Width / 2, _graphicsDevice.Viewport.Height / 2);
            _previousMouseState = Mouse.GetState();

            //GameDebug.Log("Direction", _direction);
        }
    }
}