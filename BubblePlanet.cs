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
            arrow = new Arrow(ArrowTexture)
            {
                Position = new Vector2(640, 600),
                scale = 1,
                color = Color.White,
        };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Singleton.Instance.BallTable[i, j] = new Ball(BallTexture)
                    {
                        ball.Draw(spriteBatch),
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(BG, new Rectangle(0, 0, 1280, 720), Color.White);
            spriteBatch.Draw(GameScreen, new Rectangle(1280 / 3, 0, 1280 / 3, 720), Color.White);

            arrow.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
