using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MidTurm_BubblePlanet
{

    public class BubblePlanet : Game
    {
        private Texture2D BallTexture, GameScreen,BG,Arrow;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public BubblePlanet()
        {
            graphics = new GraphicsDeviceManager(this);
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
            Arrow = Content.Load<Texture2D>("Arrow");

        }


        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            base.Draw(gameTime);
        }
    }
}
