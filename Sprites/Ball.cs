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
        public int i, j;

        public Ball(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Position += Direction * LinearVelocity;
            base.Update(gameTime);

            if (IsMidAir)
            {
                if (Position.X < ((1208 / 3) + (Texture.Width / 2) * 0.2f) || Position.X > ((1208 / 3) * 2))
                {
                    Direction.X *= -1;
                }
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Singleton.Instance.BallTable[i, j] != null)
                        {
                            if (Utils.Collision(this, Singleton.Instance.BallTable[i, j]))
                            {
                                var HitPoint = Position;
                                HitPoint -= Singleton.Instance.BallTable[i, j].Position;

                                var x = i;
                                if (HitPoint.X >= 0)
                                {
                                    Singleton.Instance.BallTable[++i, (x%2==0?j:++j)] = this;
                                }
                                else
                                {
                                    Singleton.Instance.BallTable[++i, (x%2==0?--j:j)] = this;
                                }

                                Direction = Vector2.Zero;
                                IsMidAir = false;
                                Position = new Vector2((i % 2 == 0 ? 0 : 23) + (1280 / 3) + (50 * j), 50 * i);
                                this.i = i;
                                this.j = j;
                                BallCollection(this);
                                if (Singleton.Instance.SameBall.Count > 2)
                                {
                                    Singleton.Instance.SameBall.ForEach((obj) =>
                                    {
                                        Singleton.Instance.BallTable[obj.i, obj.j] = null;
                                    });
                                }
                                Singleton.Instance.SameBall.Clear();
                                Console.WriteLine("-------------------");
                                return;
                            }
                        }
                    }
                }

               

            }
        }

        private void BallCollection(Ball Ball)
        {
            if (!Singleton.Instance.SameBall.Contains(Ball))
            {
                Singleton.Instance.SameBall.Add(Ball);
                Console.WriteLine(Ball.i + " : " + Ball.j);
                if (Ball.i % 2 != 0)
                {
                    if (Ball.i > 0 && Ball.j >= 0)
                    {
                        if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j ] != null)
                            if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j ].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i - 1, Ball.j ]);
                    }
                    if (Ball.i >= 0 && Ball.j < 7)
                    {
                        if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j+1] != null)
                            if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j+1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i - 1, Ball.j+1]);
                    }

                    if (Ball.i >= 0 && Ball.j > 0 && Ball.j < 7)
                    {
                        if (Singleton.Instance.BallTable[Ball.i, Ball.j - 1] != null)
                            if (Singleton.Instance.BallTable[Ball.i, Ball.j - 1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i, Ball.j - 1]);
                    }
                    if (Ball.i >= 0 && Ball.j > 0 && Ball.j < 7)
                    {
                        if (Singleton.Instance.BallTable[Ball.i, Ball.j + 1] != null)
                            if (Singleton.Instance.BallTable[Ball.i, Ball.j + 1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i, Ball.j + 1]);
                    }

                    if (Ball.i > 0 && Ball.i < 11 && Ball.j < 7)
                    {
                        if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j] != null)
                            if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i + 1, Ball.j]);
                    }
                    if (Ball.i > 0 && Ball.i < 11 && Ball.j < 7)
                    {
                        if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j + 1] != null)
                            if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j + 1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i + 1, Ball.j + 1]);
                    }
                }
                else
                {
                    if (Ball.i > 0 && Ball.j > 0)
                    {
                        if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j - 1] != null)
                            if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j - 1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i - 1, Ball.j - 1]);
                    }
                    if (Ball.i > 0 && Ball.j >= 0)
                    {
                        if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j] != null)
                            if (Singleton.Instance.BallTable[Ball.i - 1, Ball.j].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i - 1, Ball.j]);
                    }
                    if (Ball.i >= 0 && Ball.j > 0 && Ball.j < 7)
                    {
                        if (Singleton.Instance.BallTable[Ball.i, Ball.j - 1] != null)
                            if (Singleton.Instance.BallTable[Ball.i, Ball.j - 1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i, Ball.j - 1]);
                    }
                    if (Ball.i >= 0 && Ball.j > 0 && Ball.j < 7)
                    {
                        if (Singleton.Instance.BallTable[Ball.i, Ball.j + 1] != null)
                            if (Singleton.Instance.BallTable[Ball.i, Ball.j + 1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i, Ball.j + 1]);
                    }
                    if (Ball.i > 0 && Ball.i < 11 && Ball.j < 7 && Ball.j >0)
                    {
                        if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j-1] != null)
                            if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j-1].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i + 1, Ball.j-1]);
                    }
                    if (Ball.i > 0 && Ball.i < 11 && Ball.j < 7 && Ball.j > 0)
                    {
                        if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j] != null)
                            if (Singleton.Instance.BallTable[Ball.i + 1, Ball.j].color == Ball.color)
                                BallCollection(Singleton.Instance.BallTable[Ball.i + 1, Ball.j]);
                    }
                }
            }
        }
    }
}
