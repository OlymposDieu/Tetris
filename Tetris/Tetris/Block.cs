using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class Block
    {
        public static int size = 40;

        public Color color;

        public Block()
        {
            color = Color.White;
        }

        public Block(Color color)
        {
            this.color = color;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(ResourceManager.GetTexture("Block"), new Rectangle(x * size, y * size, size, size), color);
        }
    }
}