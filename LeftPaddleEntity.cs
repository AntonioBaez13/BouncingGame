using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BouncingGame
{
    public class LeftPaddleEntity
    {
        Texture2D paddlesTexture;
        int bufferBackWidth;
        int bufferBackHeight;
        int leftBarY;
        int leftBarWidth = 10;
        int leftBarHeight = 100;
        int leftBarX = 10;
        public Rectangle leftPaddleRectangle = new Rectangle();

        public LeftPaddleEntity(GraphicsDevice graphicsDevice, int width, int height)
        {
            paddlesTexture = new Texture2D(graphicsDevice, 1, 1);
            paddlesTexture.SetData(new Color[] { Color.White });
            //set the height at which the bar should be located (middle of total height) - half size of the bar 
            this.leftBarY = (height / 2) - 50;
            this.bufferBackWidth = width;
            this.bufferBackHeight = height;
        }

        public void Update()
        {
            if (leftBarY == 0)
            {
                //Only allowed to move down
                leftBarY += (Keyboard.GetState().IsKeyDown(Keys.S)) ? 10 : 0;  
            }
            else if(leftBarY == bufferBackHeight - 100)
            {
                //Only allowed to go up
                leftBarY += (Keyboard.GetState().IsKeyDown(Keys.W)) ? -10 : 0;
            }
            else
            {
                //default
                leftBarY += (Keyboard.GetState().IsKeyDown(Keys.S)) ? 10 : 0;
                leftBarY += (Keyboard.GetState().IsKeyDown(Keys.W)) ? -10 : 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.leftPaddleRectangle = new Rectangle(leftBarX, leftBarY, leftBarWidth, leftBarHeight);
            spriteBatch.Draw(paddlesTexture, leftPaddleRectangle, Color.Black);
        }
    }
}
