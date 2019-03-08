using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MidTurm_BubblePlanet
{

    public class BubblePlanet : Game
    {
        private Texture2D BallTexture, GameScreen,BG,ArrowTexture;

        private Arrow arrow;

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
            BallTexture = Content.Load<Texture2D>("Ball");
            ArrowTexture = Content.Load<Texture2D>("Arrow");

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
                        Position = new Vector2((i%2 == 0? 0:23)+(1280 / 3) + (50 * j), 50 * i),
                        scale = 0.2f,
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

            arrow.Update(gameTime);
            Singleton.Instance.Bullet.Update(gameTime);

            Singleton.Instance.MidAirObjects.ForEach((Object) => {
                Object.Update(gameTime);
            });

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(BG, new Rectangle(0, 0, 1280, 720), Color.White);
            spriteBatch.Draw(GameScreen, new Rectangle(1280 / 3, 0, 1280 / 3, 720), Color.White);

            arrow.Draw(spriteBatch);
            Singleton.Instance.Bullet.Draw(spriteBatch);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Singleton.Instance.BallTable[i, j].Draw(spriteBatch);
                }
            }

            Singleton.Instance.MidAirObjects.ForEach((Object)=> {
                Object.Draw(spriteBatch);
            });

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
