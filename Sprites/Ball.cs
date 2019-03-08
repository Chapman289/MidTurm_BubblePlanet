using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MidTurm_BubblePlanet
{
    public class Ball : Sprite
    {


        public Ball(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Position += Direction * LinearVelocity;
            base.Update(gameTime);

            if (IsMidAir)
            {
                if (Position.X < (1208 / 3) || Position.X > (1208 / 3) * 2)
                {
                    Direction.X *= -1;
                }
            }
        }

    }
}
