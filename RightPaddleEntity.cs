using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BouncingGame
{
    public class RightPaddleEntity
    {
        Texture2D paddlesTexture;
        int bufferBackWidth;
        int bufferBackHeight;
        int rightBarY;
        int rightBarWidth = 10;
        int rightBarHeight =100;
        int rightBarX;
        public Rectangle rightPaddleRectangle = new Rectangle();

        public RightPaddleEntity(GraphicsDevice graphicsDevice, int width, int height)
        {
            paddlesTexture = new Texture2D(graphicsDevice, 1, 1);
            paddlesTexture.SetData(new Color[] { Color.White });
            //set the height at which the bar should be located (middle of total height) - half size of the bar 
            this.rightBarY = (height / 2) - 50;
            this.bufferBackWidth = width;
            this.bufferBackHeight = height;
            this.rightBarX = width - 20;
        }

        public void Update()
        {
            if (rightBarY == 0)
            {
                //only allowed to move down 
                rightBarY += (Keyboard.GetState().IsKeyDown(Keys.Down)) ? 10 : 0;
            }
            else if (rightBarY == bufferBackHeight - 100)
            {
                //Only allowed to go up
                rightBarY += (Keyboard.GetState().IsKeyDown(Keys.Up)) ? -10 : 0;
            }
            else
            {
                //default
                rightBarY += (Keyboard.GetState().IsKeyDown(Keys.Down)) ? 10 : 0;
                rightBarY += (Keyboard.GetState().IsKeyDown(Keys.Up)) ? -10 : 0;
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            this.rightPaddleRectangle = new Rectangle(rightBarX, rightBarY, rightBarWidth, rightBarHeight);
            spriteBatch.Draw(paddlesTexture, rightPaddleRectangle, Color.Black);
        }
    }
}
