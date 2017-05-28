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
        protected float speed = 100;
        protected float rotation;

        public SpaceShipGeneral(float scale) : base("")
        {
            position = new Vector2(Main.Screen.X / 2, Main.Screen.Y / 2);     
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Left))
                velocity.X -= speed;
            else if (inputHelper.KeyPressed(Keys.Right))
                velocity.X += speed;
            else if (inputHelper.KeyPressed(Keys.Up))
                velocity.Y -= speed;
            else if (inputHelper.KeyPressed(Keys.Down))
                velocity.Y += speed;
            
            base.HandleInput(inputHelper);
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

            //spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0.0f);
            base.Draw(gameTime, spriteBatch);
        }
    }
}
