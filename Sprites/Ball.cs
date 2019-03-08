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
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if(Singleton.Instance.BallTable[i,j] != null)
                        {
                           if(Utils.Collision(this, Singleton.Instance.BallTable[i, j]))
                            {
                                var HitPoint = Position;
                                HitPoint -= Singleton.Instance.BallTable[i, j].Position;
                                Console.WriteLine(i + " " + j);
                                if (HitPoint.X>=0 &&HitPoint.Y>=0)//TR
                                {
                                    Singleton.Instance.BallTable[i - 1, j] = this;
                                    
                                }
                                else if(HitPoint.X<=0 &&HitPoint.Y>=0)
                                {
                                    Singleton.Instance.BallTable[i - 1, j] = this;
                                }
                                else if(HitPoint.X<=0 &&HitPoint.Y<=0)//DL
                                {
                                    Singleton.Instance.BallTable[i + 1, j] = this;
                                }
                                else if(HitPoint.X>=0 &&HitPoint.Y<=0)//DR
                                {
                                    Singleton.Instance.BallTable[i + 1, j] = this;
                                }
                               
                            }
                        }
                    }
                }
            }
        }

    }
}
