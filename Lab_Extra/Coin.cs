using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_Extra.Player;

namespace Lab_Extra
{
    public class Coin
    {
        public Vector2 coinPosition = new Vector2 (300 , 300);
        Rectangle coinRec;
        AnimatedTexture SpriteTexture;

        public Coin(AnimatedTexture SpriteTexture, Vector2 coinPosition)
        {
            this.SpriteTexture = SpriteTexture;
            this.coinPosition = coinPosition;
            coinRec = new Rectangle((int)coinPosition.X, (int)coinPosition.Y, 64, 64);
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SpriteTexture.UpdateFrame(elapsed);

            if(Game1._player.playerBox.Intersects(coinRec))
            {
                OnCollied();
            }




            coinRec = new Rectangle((int)coinPosition.X, (int)coinPosition.Y, 64, 64);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            SpriteTexture.DrawFrame(_spriteBatch, coinPosition);
        }
        public void OnCollied()
        {
            Game1.bag.Add(this);
            Game1.coinList.Remove(this);
        }
    }
}
