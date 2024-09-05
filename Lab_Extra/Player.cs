using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Extra
{
    public class Player
    {
        public Vector2 playerPosition = new Vector2( 100 , 250 );
        AnimatedTexture SpriteTexture;
        public enum Direction { Down , Up, Left , Right }
        public Direction direction { get; set; }

        public Rectangle playerBox;
        public bool IsWin = false;

        public Player(AnimatedTexture SpriteTexture, Vector2 playerPosition)
        {

            this.SpriteTexture = SpriteTexture;
            this.playerPosition = playerPosition;
            direction = Direction.Down;
            playerBox = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 64, 64);

        }
        Rectangle bgRec = new Rectangle(64, 64 * 2, 64 * 18, 64);
        Rectangle treeRec = new Rectangle(0, 0, 64, 64 * 18);
        Rectangle treeRec2 = new Rectangle(64 * 19, 0, 64, 64 * 18);
        Rectangle objRec = new Rectangle(64 * 15, 64 * 4, 64 * 2, 64 * 3);
        Rectangle objRec2 = new Rectangle(64 * 3, 64 * 4, 64 * 2, 64 * 3);
        //down
        Rectangle bgRec2 = new Rectangle(64, 64 * 14, 64 * 18, 64);
        Rectangle door1 = new Rectangle(64, 64 * 14, 64 * 7, 64);
        Rectangle door2 = new Rectangle(64 * 11, 64 * 14, 64 * 5, 64);
        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SpriteTexture.UpdateFrame(elapsed);
            SpriteTexture.Pause();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerPosition.Y -= 3;
                SpriteTexture.Play();
                direction = Direction.Up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerPosition.X += 3;
                SpriteTexture.Play();
                direction = Direction.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerPosition.Y += 3;
                SpriteTexture.Play();
                direction = Direction.Down;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                playerPosition.X -= 3;
                SpriteTexture.Play();
                direction = Direction.Left;
            }

            //OnCollision
            if (playerBox.Intersects(bgRec))
            {
                playerPosition.Y += 3;
            }
            if(IsWin == true)
            {
                if (playerBox.Intersects(door1) || playerBox.Intersects(door2))
                {
                    playerPosition.Y -= 3;
                }
            }
            else
            {
                if (playerBox.Intersects(bgRec2))
                {
                    playerPosition.Y -= 3;
                }
            }
            if (playerBox.Intersects(treeRec))
            {
                playerPosition.X += 3;
            }
            if (playerBox.Intersects(treeRec2))
            {
                playerPosition.X -= 3;
            }
            //if (playerBox.Intersects(objRec) || playerBox.Intersects(objRec2))
            //{
            //    playerPosition += new Vector2(3,0);
            //}


            playerBox = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 64, 64);
        }



        public void Draw(SpriteBatch _spriteBatch)
        {

            SpriteTexture.DrawFrame(_spriteBatch, playerPosition, (int)direction + 1);

        }



    }
}
