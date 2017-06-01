using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SpanceInvadersUltra
{
    class SpaceShipGeneral : SpriteGameObject
    {
        protected float fireRate;
        protected float shield;
        protected float health;
        protected float armour;
        protected float bullets;
        protected float speed = 300;
        protected float minSpeed = -300;
        protected float rotation;
        protected bool shieldUsed = false;

        public SpaceShipGeneral() : base("spaceship")
        {
            position = new Vector2(Main.Screen.X / 2, Main.Screen.Y / 2);
            origin = new Vector2(Width / 2, Height / 2);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            //movement
            velocity = Vector2.Zero;
            if (inputHelper.IsKeyDown(Keys.Left))
                velocity.X = minSpeed;
            if (inputHelper.IsKeyDown(Keys.Right))
                velocity.X = speed;
            if (inputHelper.IsKeyDown(Keys.Up))
                velocity.Y = minSpeed;
            if (inputHelper.IsKeyDown(Keys.Down))
                velocity.Y = speed;

            //shield key
            if (inputHelper.IsKeyDown(Keys.Z))
                shieldUsed = true;
            else shieldUsed = false;
            
            
            base.HandleInput(inputHelper);
        }

        protected void Stats()
        {
            fireRate = 20;
            shield = 20;
            health = 200;
            armour = 100;
            bullets = 50;
        }

        public override void Update(GameTime gameTime)
        {
            //rotation math
            if(velocity != Vector2.Zero)
            {
                var angle = (float)Math.Atan2(velocity.Y, velocity.X);
                rotation = angle + (float)Math.PI / 2;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || sprite == null)
                return;

            //for the rotation, need to fix the scale.
            //spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0.0f);
            base.Draw(gameTime, spriteBatch);
        }
    }
}
