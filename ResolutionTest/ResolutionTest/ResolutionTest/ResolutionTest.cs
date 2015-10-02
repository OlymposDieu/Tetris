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

namespace ResolutionTest
{
    public class ResolutionTest : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        protected static Point ResolutionPreference = new Point(640, 480);
        Texture2D Test;

        public ResolutionTest()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += new EventHandler<EventArgs>(ClientSizeChanged());
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SetResolution(false);
            Test = Content.Load<Texture2D>("BlockBase");
        }

        public void ClientSizeChanged(object sender, EventArgs e)
        {
            SetResolution();
        }

        public void SetResolution(bool FullScreen = true)
        {
            float screenScalex = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (float)ResolutionPreference.X;
            float screenScaley = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (float)ResolutionPreference.Y;
            float finalScale = 1f;

            if(FullScreen)
            {
                finalScale = screenScalex;
                if (Math.Abs(1f - screenScaley) < Math.Abs(1f - screenScalex))
                    finalScale = screenScaley;

                graphics.IsFullScreen = FullScreen;
            }
            else
            {
                if (screenScalex > 1f || screenScaley > 1f)
                    finalScale = Math.Min(screenScalex, screenScaley);

                graphics.IsFullScreen = FullScreen;
            }
            graphics.PreferredBackBufferWidth = (int)(ResolutionPreference.X * finalScale);
            graphics.PreferredBackBufferHeight = (int)(ResolutionPreference.Y * finalScale);
            graphics.ApplyChanges();
        }


        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Test, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
