using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Lab_Extra
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        AnimatedTexture spriteTexture;
        AnimatedTexture _playerTexture;
        AnimatedTexture coinTexture;
        AnimatedTexture _enemyTexture;
        public static Player _player;
        Coin _coin;
        Enemy _enemy;
        
        Texture2D bg1;
        Texture2D bg2;
        Texture2D bg3;
        Texture2D bg4;
        Texture2D bg5;
        Texture2D bg6;

        int FrameRows = 4;
        int Frame = 4;
        int FramePerSec = 10;
        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;

        Vector2 playerPosition = new Vector2(100,250);
        Vector2 coinPosition = new Vector2(300, 300);
        Vector2 EnemyPosition = new Vector2(400, 500);
        Rectangle coinRec = new Rectangle(0,0,64,64);

        public static List<Coin> bag = new List<Coin>();
        public static List<Coin> coinList = new List<Coin>();
        public static List<Enemy> enemyList = new List<Enemy>();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 960;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteTexture = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            _playerTexture = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            coinTexture = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            _enemyTexture = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bg1 = Content.Load<Texture2D>("TilesetElement");
            bg2 = Content.Load<Texture2D>("TilesetFloor");
            bg3 = Content.Load<Texture2D>("TilesetFloorDetail");
            bg4 = Content.Load<Texture2D>("TilesetHouse");
            bg5 = Content.Load<Texture2D>("TilesetNature");
            bg6 = Content.Load<Texture2D>("TilesetWater");
            _player = new Player(_playerTexture, playerPosition);
            _coin = new Coin(coinTexture,coinPosition);
            _enemy = new Enemy(_enemyTexture, EnemyPosition);
            spriteTexture.Load(Content, "FlowerSheet", 4, 1, 10);
            coinTexture.Load(Content,"Coin", 4 , 1 , 1);
            _enemyTexture.Load(Content, "Cyclope" , 4 , 4 , 4);
            _playerTexture.Load(Content, "MaskFrog", Frame, FrameRows, FramePerSec);
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 2 , 64 * 10)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 2, 64 * 9)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 2, 64 * 8)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 2, 64 * 7)));
            //upper
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 12 , 64 * 4)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 7, 64 * 4)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 8, 64 * 4)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 9, 64 * 4)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 10, 64 * 4)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 11, 64 * 4)));
            //right
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 17, 64 * 10)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 17, 64 * 9)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 17, 64 * 8)));
            coinList.Add(new Coin(coinTexture, new Vector2(64 * 17, 64 * 7)));
            //enemy
            enemyList.Add(new Enemy(_enemyTexture, new Vector2(400, 500)));
            enemyList.Add(new Enemy(_enemyTexture, new Vector2(500, 500)));
            enemyList.Add(new Enemy(_enemyTexture, new Vector2(600, 500)));


            // TODO: use this.Content to load your game content here
        }
        int enemymove;

        public int Speed = 3;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteTexture.UpdateFrame(elapsed);
            for(int i = 0; i < coinList.Count; i++)
            {
                coinList[i].Update(gameTime);
            }
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update(gameTime);
            }
        
                if (enemyList[1].EnemyPosition.X == 0)
                {
                    enemymove = 1;
                }
                if (enemyList[1].EnemyPosition.X == 799)
                {
                    enemymove = 0;
                }







                _player.Update(gameTime);

            if(bag.Count >= 14)
            {
                _player.IsWin = true;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0; i < 30; i++)
            {
                for (int k = 0; k < 30; k++)
                {
                    _spriteBatch.Draw(bg2, new Vector2(64 * i, 64 * k), new Rectangle(64 * 0, 64 * 5, 64, 64), Color.White);
                }
                for (int j = 0; j < 3; j++)
                {
                    _spriteBatch.Draw(bg2, new Vector2(64 * i, 64 * j), new Rectangle(64, 64, 64, 64), Color.White);
                }
                _spriteBatch.Draw(bg2, new Vector2(64 * i, 64 * 3), new Rectangle(64, 64 * 2, 64, 64), Color.White);
            }

            for(int i = 0 ; i < 30 ; i++)
            {
                _spriteBatch.Draw(bg5, new Vector2(-128, 0) + new Vector2(128 * i, 0), new Rectangle(0, 64 * 2, 64 * 4, 64 * 3), Color.White);
            }
            //พุ่มไม้
            for (int i = 0; i < 30; i++)
            {
                _spriteBatch.Draw(bg5, new Vector2(0, 256 ) + new Vector2(0, 64 * i), new Rectangle(64 * 4, 64 * 11, 64, 64), Color.White);
                _spriteBatch.Draw(bg5, new Vector2(0, 256) + new Vector2(1216, 64 * i), new Rectangle(64 * 4, 64 * 11, 64, 64), Color.White);
            }
            //fence
            for (int i = 0; i < 30; i++)
            {
                _spriteBatch.Draw(bg1 ,new Vector2(64 * i, 64 * 3), new Rectangle( 64 * 2 , 64 * 0, 64 , 64 ), Color.White);
            }
            //rectangle
            _spriteBatch.Draw(bg2, new Vector2(64 * 8, 64 * 8), new Rectangle(0 ,0, 64 * 2, 64 * 2), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 8), new Rectangle(64, 0, 64* 2, 64 ), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 8, 64 * 10), new Rectangle(0, 64, 64 * 2, 64 ), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 8, 64 * 11), new Rectangle(0, 64 * 2, 64 * 2 , 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 9), new Rectangle(64 * 1, 64, 64 * 2, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 10), new Rectangle(64 * 1, 64, 64 * 2, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 11), new Rectangle(64 * 1, 64 * 2, 64 * 2, 64), Color.White);
            //way
            _spriteBatch.Draw(bg2, new Vector2(64 * 9, 64 * 11.5f ), new Rectangle(0, 64 * 1, 64, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 11.5f), new Rectangle(64 * 2 , 64 * 1, 64, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 9, 64 * 12.5f), new Rectangle(0, 64 * 1, 64, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 12.5f), new Rectangle(64 * 2, 64 * 1, 64, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 9, 64 * 13.5f), new Rectangle(0, 64 * 1, 64, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 13.5f), new Rectangle(64 * 2, 64 * 1, 64, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 9, 64 * 14.5f), new Rectangle(0, 64 * 1, 64, 64), Color.White);
            _spriteBatch.Draw(bg2, new Vector2(64 * 10, 64 * 14.5f), new Rectangle(64 * 2, 64 * 1, 64, 64), Color.White);
            //flower
            _spriteBatch.Draw(bg5, new Vector2(64 * 8, 64 * 8), new Rectangle(64 * 3, 64 * 10, 64, 64 ), Color.White);
            _spriteBatch.Draw(bg3, new Vector2(64 * 11, 64 * 8), new Rectangle(64 * 15, 64 * 0, 64, 64), Color.White);
            _spriteBatch.Draw(bg3, new Vector2(64 * 8, 64 * 10), new Rectangle(64 * 0, 64 * 2, 64, 64), Color.White);
            _spriteBatch.Draw(bg3, new Vector2(64 * 11, 64 * 11), new Rectangle(64 * 5, 64 * 2, 64, 64), Color.White);
            _spriteBatch.Draw(bg3, new Vector2(64 * 11, 64 * 9), new Rectangle(64 * 3, 64 * 0, 64, 64), Color.White);
            //ศาล
            _spriteBatch.Draw(bg4, new Vector2(64 * 3, 64 * 4), new Rectangle(64 * 1, 64 * 19, 64 * 2, 64 * 3), Color.White);
            _spriteBatch.Draw(bg4, new Vector2(64 * 15, 64 * 4), new Rectangle(64 * 1, 64 * 19, 64 * 2, 64 * 3), Color.White);
            //water
            _spriteBatch.Draw(bg6, new Vector2(64 * 7, 64 * 9), new Rectangle(64 * 3, 64 , 64 , 64*2 ), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 7, 64 * 8), new Rectangle(64 * 3, 64, 64, 64), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 12, 64 * 9), new Rectangle(64 * 3, 64, 64, 64 * 2), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 12, 64 * 8), new Rectangle(64 * 3, 64, 64, 64), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 7, 64 * 7), new Rectangle(64 * 4, 0 , 64, 64 ), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 12, 64 * 7), new Rectangle(64 * 7, 0, 64, 64), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 8, 64 * 7), new Rectangle(64 , 64 * 3, 64, 64), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 9, 64 * 7), new Rectangle(64, 64 * 3, 64, 64), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 10, 64 * 7), new Rectangle(64, 64 * 3, 64, 64), Color.White);
            _spriteBatch.Draw(bg6, new Vector2(64 * 11, 64 * 7), new Rectangle(64, 64 * 3, 64, 64), Color.White);
            //กบ
            _spriteBatch.Draw(bg4, new Vector2(64 * 9, 64 * 8), new Rectangle(64 * 3, 64 * 21, 64 * 2, 64 * 2), Color.White);
            //player
            _player.Draw(_spriteBatch);
            //tree/down
            _spriteBatch.Draw(bg5, new Vector2(64 * 1, 64 * 12), new Rectangle(64 * 3, 64 * 18, 64 * 3, 64 * 3), Color.White);
            _spriteBatch.Draw(bg5, new Vector2(64 * 16, 64 * 12), new Rectangle(64 * 3, 64 * 18, 64 * 3, 64 * 3), Color.White);
            //เด็ก
            _spriteBatch.Draw(bg4, new Vector2(64 * 5, 64 * 13), new Rectangle(64 * 5, 64 * 19, 64 * 2, 64 * 2), Color.White);
            _spriteBatch.Draw(bg4, new Vector2(64 * 13, 64 * 13), new Rectangle(64 * 3, 64 * 19, 64 * 2, 64 * 2), Color.White);
            _spriteBatch.Draw(bg1, new Vector2(64 * 7, 64 * 14), new Rectangle(64 * 2, 64 * 0, 64, 64), Color.White);
            _spriteBatch.Draw(bg1, new Vector2(64 * 12, 64 * 14), new Rectangle(64 * 2, 64 * 0, 64, 64), Color.White);
            //ทางเข้า
            _spriteBatch.Draw(bg1, new Vector2(64 * 11, 64 * 13), new Rectangle(64 * 6, 64 * 3, 64, 64 * 2), Color.White);
            _spriteBatch.Draw(bg1, new Vector2(64 * 8, 64 * 13), new Rectangle(64 * 6, 64 * 3, 64, 64 * 2), Color.White);


            if(_player.IsWin == false)
            {
                _spriteBatch.Draw(bg1, new Vector2(64 * 9, 64 * 13), new Rectangle(64 * 11, 64 * 2, 64, 64 * 2), Color.White);
                _spriteBatch.Draw(bg1, new Vector2(64 * 10, 64 * 13), new Rectangle(64 * 13, 64 * 2, 64, 64 * 2), Color.White);
            }
            


            //animation flower
            spriteTexture.DrawFrame(_spriteBatch, new Vector2(64 * 1, 64 * 14));
            spriteTexture.DrawFrame(_spriteBatch, new Vector2(64 * 3, 64 * 14));
            spriteTexture.DrawFrame(_spriteBatch, new Vector2(64 * 4, 64 * 14));
            spriteTexture.DrawFrame(_spriteBatch, new Vector2(64 * 15, 64 * 14));
            spriteTexture.DrawFrame(_spriteBatch, new Vector2(64 * 16, 64 * 14));
            spriteTexture.DrawFrame(_spriteBatch, new Vector2(64 * 18, 64 * 14));
            //coin
            for (int i = 0; i < coinList.Count; i++)
            {
                coinList[i].Draw(_spriteBatch);
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Draw(_spriteBatch);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
