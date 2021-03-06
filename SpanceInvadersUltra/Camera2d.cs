﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpanceInvadersUltra
{
    public class Camera2D
    {

        #region Fields

        protected float _zoom; //Camera Zoom Value
        protected Matrix _transform; //Camera Transform Matrix
        protected Matrix _inverseTransform; //Inverse of Transform Matrix
        protected Vector2 _pos; //Camera Position
        protected float _rotation; //Camera Rotation Value (Radians)
        protected Viewport _viewport; //Cameras Viewport
        protected MouseState _mState; //Mouse state
        protected KeyboardState _keyState; //Keyboard state
        protected Int32 _scroll; //Previous Mouse Scroll Wheel Value

        #endregion

        #region properties

        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; }
        }
        /// <summary>
        /// Camera View Matrix Property
        /// </summary>
        public Matrix Transform
        {
            get { return _transform; }
            set { _transform = value; }
        }
        /// <summary>
        /// Inverse of the view matrix, can be used to get objects screen coordinates
        /// from its object coordinates
        /// </summary>
        public Matrix InverseTransform
        {
            get { return _inverseTransform; }
        }
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        #endregion

        #region Constructor

        public Camera2D(Viewport viewport)
        {
            _zoom = 1.0f;
            _scroll = 1;
            _rotation = 0.0f;
            _pos = Vector2.Zero;
            _viewport = viewport;
        }

        #endregion

        #region Methods

        public void Update(GameTime gameTime)
        {
            //Call camera input
            Input();
            //Clamp zoom value
            MathHelper.Clamp(_zoom, 0.01f, 10.0f);
            //Clamp rotation value
            _rotation = ClampAngle(_rotation);
            //create view  matrix
            _transform = Matrix.CreateRotationZ(_rotation) *
                         Matrix.CreateScale(new Vector3(_zoom, _zoom, 1)) *
                         Matrix.CreateTranslation(_pos.X, _pos.Y, 0);
            //update inverse matrix
            _inverseTransform = Matrix.Invert(_transform);
        }

        /// <summery>
        /// Example Input Method, rotates using cursor keys and zooms using mouse wheel, I want to make one of my own, but have to find out how to do this first
        /// </summery>
        protected virtual void Input()
        {
            _mState = Mouse.GetState();
            _keyState = Keyboard.GetState();
            //check zoom
            if (_mState.ScrollWheelValue > _scroll)
            {
                _zoom += 0.1f;
                _scroll = _mState.ScrollWheelValue;
            }
            else if (_mState.ScrollWheelValue < _scroll)
            {
                _zoom -= 0.1f;
                _scroll = _mState.ScrollWheelValue;
            }
            //check rotation
            if (_keyState.IsKeyDown(Keys.Left))
                _rotation -= 0.1f;
            if (_keyState.IsKeyDown(Keys.Right))
                _rotation += 0.1f;
            //check move
            if (_keyState.IsKeyDown(Keys.A))
                _pos.X += 0.5f;
            if (_keyState.IsKeyDown(Keys.D))
                _pos.X -= 0.5f;
            if (_keyState.IsKeyDown(Keys.W))
                _pos.Y += 0.5f;
            if (_keyState.IsKeyDown(Keys.S))
                _pos.Y -= 0.5f;
        }

        ///<summery>
        ///Clamps a radian value between -pi and pi
        ///</summery>
        ///<param name="radians">angle to be clamped </param>
        ///<returns>clamped angle</returns>
        protected float ClampAngle(float radians)
        {
            while (radians < -MathHelper.Pi)
            {
                radians += MathHelper.TwoPi;
            }
            while (radians > MathHelper.Pi)
            {
                radians -= MathHelper.TwoPi;
            }
            return radians;
        }

        #endregion
    }
}
