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
    public class Enemy
    {
        public Vector2 EnemyPosition = new Vector2( 300 , 300 );
        AnimatedTexture SpriteTexture;
        public enum Direction { Down , Up, Left , Right }
        public Direction direction { get; set; }

        public Rectangle enemyBox;
        int Speed = 3;

        public Enemy(AnimatedTexture SpriteTexture, Vector2 EnemyPosition)
        {

            this.SpriteTexture = SpriteTexture;
            this.EnemyPosition = EnemyPosition;
            direction = Direction.Down;
            enemyBox = new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, 64, 64);

        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SpriteTexture.UpdateFrame(elapsed);
            SpriteTexture.Play();

            //if(EnemyPosition.X > 500 && EnemyPosition.X < 200)
            //{
            //    EnemyPosition.X += 3;
            //    direction = Direction.Right;
            //}


            enemyBox = new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, 64, 64);

        }



        public void Draw(SpriteBatch _spriteBatch)
        {

            SpriteTexture.DrawFrame(_spriteBatch, EnemyPosition , (int)direction + 1);

        }



    }
}
