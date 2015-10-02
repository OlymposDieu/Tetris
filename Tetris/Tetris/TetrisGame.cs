using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tetris
{
    public class TetrisGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Input input;

        PlayingGrid grid;

        float time = 0;
        float updateTime = 200;

        public static bool isGameOver;

        public TetrisGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
            //graphics.IsFullScreen = true;

            Content.RootDirectory = "Content";

            input = new Input();
            grid = new PlayingGrid(12, 20);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.AddTexture("Block", Content.Load<Texture2D>("Block"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (isGameOver)
                Exit();

            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            input.UpdateKeys();

            if (time >= updateTime)
            {
                grid.Update(input);
                time = 0;
                input.Clear();
            }

            input.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            grid.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}