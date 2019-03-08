using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MidTurm_BubblePlanet
{
    class Arrow : Sprite
    {

        private KeyboardState keyboardPreviousState, keyboardCurrentState;

        public Arrow(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Rotation <= 1.55f)
            {
                Rotation += MathHelper.ToRadians(RotationVelocity);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && Rotation >= -1.55f)
            {
                Rotation -= MathHelper.ToRadians(RotationVelocity);
            }

            Direction = new Vector2((float)Math.Cos(Rotation - 1.57f), (float)Math.Sin(Rotation - 1.57f));

            keyboardCurrentState = Keyboard.GetState();

            if ((keyboardCurrentState.IsKeyDown(Keys.Space) != keyboardPreviousState.IsKeyDown(Keys.Space)) && !keyboardCurrentState.IsKeyUp(Keys.Space))
            {
                FireBall();
            }

            keyboardPreviousState = keyboardCurrentState;

            base.Update(gameTime);
        }

        private void FireBall()
        {
            var temp = Singleton.Instance.Bullet.Clone() as Ball;
            temp.Direction = Direction;
            temp.IsMidAir = true;
            Singleton.Instance.MidAirObjects.Add(temp);
            Singleton.Instance.Bullet.color = Utils.RandomColor();
        }
    }
}
