using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MidTurm_BubblePlanet
{

    public class BubblePlanet : Game
    {
        private Texture2D BallTexture, GameScreen,BG,ArrowTexture, BG_GAMEOVER,FinalBar;
        private SpriteFont bauhaus93,_timerfont;
        private float timer;
        private Arrow arrow;
        private float _timer;
        private bool IsGameOver;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public BubblePlanet()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameScreen = Content.Load<Texture2D>("GameScreen");
            BG = Content.Load<Texture2D>("BG");
            BG_GAMEOVER = Content.Load<Texture2D>("BG_GAMEOVER");
            FinalBar = Content.Load<Texture2D>("FinalBar");
            BallTexture = Content.Load<Texture2D>("Ball");
            ArrowTexture = Content.Load<Texture2D>("Arrow");
            bauhaus93 = Content.Load<SpriteFont>("font");
            _timerfont = Content.Load<SpriteFont>("timerfont");
            Start();
        }

        private void Start()
        {
            Singleton.Instance.Bullet = new Ball(BallTexture)
            {
                Position = new Vector2(640 - ((BallTexture.Width*0.2f) / 2), 650),
                color = Utils.RandomColor(),
                scale = 0.2f,
            };

            arrow = new Arrow(ArrowTexture)
            {
                Position = new Vector2(640, 680),
                scale = 1,
                color = Color.White,
                Origin = new Vector2(ArrowTexture.Width / 2, 100)
        };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Singleton.Instance.BallTable[i, j] = new Ball(BallTexture)
                    {
                        color = Utils.RandomColor(),
                        Position = new Vector2((i % 2 == 0 ? 0 : 23) + (1280 / 3) + (50 * j), 50 * i),
                        scale = 0.2f,
                        i = i,
                        j =j,
                    };
                }
            }
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!IsGameOver)
            {
                timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
                _timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
               
               

                if (timer > 10f)
                {
                    timer -= 10f;


                    for (int j = 0; j < 8; j++)
                    {
                        if (Singleton.Instance.BallTable[9, j] != null)
                        {
                            IsGameOver = true;
                        }
                    }

                    for (int i = 8; i >= 0; i--)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if(Singleton.Instance.BallTable[i,j] != null)
                            {
                                Singleton.Instance.BallTable[i + 2, j] = Singleton.Instance.BallTable[i, j];
                                Singleton.Instance.BallTable[i + 2, j].Position = new Vector2(((i + 2) % 2 == 0 ? 0 : 23) + (1280 / 3) + (50 * j), 50 * (i+2));
                                Singleton.Instance.BallTable[i + 2, j].i = i + 2;
                                Singleton.Instance.BallTable[i + 2, j].j = j;
                            }
                        }
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            Singleton.Instance.BallTable[i, j] = new Ball(BallTexture)
                            {
                                color = Utils.RandomColor(),
                                Position = new Vector2((i % 2 == 0 ? 0 : 23) + (1280 / 3) + (50 * j), 50 * i),
                                scale = 0.2f,
                                i = i,
                                j = j,
                            };
                        }
                    }
                }

                arrow.Update(gameTime);
                Singleton.Instance.Bullet.Update(gameTime);

                Singleton.Instance.MidAirObjects.ForEach((Object) =>
                {
                    Object.Update(gameTime);
                });

                for (int i = 1; i < 12; i++)
                {
                    for (int j = 1; j < 8 - (i % 2); j++)
                    {
                            if (i % 2 != 0)
                            {
                                if (Singleton.Instance.BallTable[i - 1, j] == null && Singleton.Instance.BallTable[i - 1, j + 1] == null)
                                {
                                    Singleton.Instance.BallTable[i, j] = null;
                                }
                                if (Singleton.Instance.BallTable[i, 1] == null && Singleton.Instance.BallTable[i - 1, 0] == null && Singleton.Instance.BallTable[i - 1, 1] == null)
                                {
                                    Singleton.Instance.BallTable[i, 0] = null;
                                }
                                if (Singleton.Instance.BallTable[i, 6] == null && Singleton.Instance.BallTable[i - 1, 7] == null)
                                {
                                    Singleton.Instance.BallTable[i, 7] = null;
                                }
                            }
                            else
                            {
                                if (Singleton.Instance.BallTable[i - 1, j - 1] == null && Singleton.Instance.BallTable[i - 1, j] == null)
                                {
                                    Singleton.Instance.BallTable[i, j] = null;
                                }
                                if (Singleton.Instance.BallTable[i - 1, 0] == null && Singleton.Instance.BallTable[i, 1] == null)
                                {
                                    Singleton.Instance.BallTable[i, 0] = null;
                                }
                                if (Singleton.Instance.BallTable[i - 1, 6] == null && Singleton.Instance.BallTable[i - 1, 7] == null && Singleton.Instance.BallTable[i, 6] == null)
                                {
                                    Singleton.Instance.BallTable[i, 7] = null;
                                }
                            }
                    }
                }

                for (int j = 0; j < 8; j++)
                {
                    if (Singleton.Instance.BallTable[11, j] != null)
                    {
                        IsGameOver = true;
                    }
                }
                //Console.WriteLine(Singleton.Instance.Score);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(BG, new Rectangle(0, 0, 1280, 720), Color.White);
            spriteBatch.Draw(GameScreen, new Rectangle(1280 / 3, 0, 1280 / 3, 720), Color.White);
            spriteBatch.Draw(FinalBar, new Rectangle(1280 / 3, 560, 1280 / 3, 15), Color.White);

            var fontSize = _timerfont.MeasureString("Timer : ");
            spriteBatch.DrawString(_timerfont, "Timer : " + _timer.ToString("F"), new Vector2(900,300), Color.White);

            fontSize = _timerfont.MeasureString("Score : ");
            spriteBatch.DrawString(_timerfont, "Score : " + Singleton.Instance.Score , new Vector2(50, 300), Color.White);

            arrow.Draw(spriteBatch);
            Singleton.Instance.Bullet.Draw(spriteBatch);

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(Singleton.Instance.BallTable[i, j]!=null)
                        Singleton.Instance.BallTable[i, j].Draw(spriteBatch);
                }
            }

            Singleton.Instance.MidAirObjects.ForEach((Object) =>
            {
                if (Object.IsMidAir)
                    Object.Draw(spriteBatch);
            });

            if (IsGameOver)
            {
                spriteBatch.Draw(BG_GAMEOVER, new Rectangle(0, 0, 1280, 720), new Color(255,255,255,160));
                fontSize = bauhaus93.MeasureString("Score : ");
                spriteBatch.DrawString(bauhaus93, "Score : "+ Singleton.Instance.Score , new Vector2(800,820)/2 - fontSize/2 ,Color.White );
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
