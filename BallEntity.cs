using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingGame
{
    public class BallEntity
    {
        Texture2D ballTexture;
        Random r = new Random();
        public float xPos, yPos;
        private float xVel, yVel;
        public int bufferWith, bufferHeight;
        public int ballWidth = 10;
        public int ballHeight = 10;
        public Rectangle ball = new Rectangle();

        public BallEntity(GraphicsDevice graphicsDevice, int width, int height)
        {
            ballTexture = new Texture2D(graphicsDevice, 1, 1);
            ballTexture.SetData(new Color[] { Color.White });
            this.xPos = r.Next(0, width);
            this.yPos = r.Next(0, height);
            this.xVel = 3f;
            this.yVel = 3f;
            this.bufferWith = width;
            this.bufferHeight = height;
        }

       
        public void OutOfGrid()
        {
            //Logic to say when the ball has hit the borders of the buffer 
            if ((xPos > bufferWith - 10) || (xPos < 0))
            {
                Bounce(false);
            }

            if((yPos > bufferHeight - 10) || (yPos < 0))
            {
                Bounce(true);
            }
        }

        public void Bounce(bool floor)
        {
            if (floor)
            {
                this.yVel *= -1f;
                //this.xVel *= Math.Abs(1f + (float)(new Random()).NextDouble() * (.5f) / this.xVel);
            }
            else
            {
                //this.xVel *= -1f;
                //Uncomment to reset the ball position after it hits the borders
                this.xPos = bufferWith / 2;
                this.yPos = bufferHeight / 2;
                this.yVel *= Math.Abs(1f + (float)(new Random()).NextDouble() * (.5f) / this.yVel);
            }

        }

        public void Paddle()
        {
            this.xVel *= -1f;
        }

        public void Update()
        {
            this.xPos += this.xVel;
            this.yPos += this.yVel;
        }
        
        public void Draw (SpriteBatch spriteBatch)
        {
            ball = new Rectangle((int)this.xPos, (int)this.yPos, ballWidth, ballHeight);
            spriteBatch.Draw(ballTexture, ball, Color.White);
        }
    }
}
