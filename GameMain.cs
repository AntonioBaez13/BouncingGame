using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BouncingGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    ///
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        BallEntity ball;
        RightPaddleEntity rightPaddle;
        LeftPaddleEntity leftPaddle;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //set the size of the screen
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 400;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            //set the height at which the bar should be located (middle of total height) - half size of the bar 
            rightPaddle = new RightPaddleEntity(this.GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            leftPaddle = new LeftPaddleEntity(this.GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            ball = new BallEntity(this.GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (this.ball.ball.Intersects(this.leftPaddle.leftPaddleRectangle) || this.ball.ball.Intersects(this.rightPaddle.rightPaddleRectangle))
            {
                ball.Paddle();
            }

            this.rightPaddle.Update();
            this.leftPaddle.Update();
            this.ball.OutOfGrid();

            this.ball.Update();

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //draw the bars separeted 10 pixels from the border 
            rightPaddle.Draw(spriteBatch);
            leftPaddle.Draw(spriteBatch);
            //Draw the ball 
            ball.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
