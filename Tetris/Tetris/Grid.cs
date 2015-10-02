using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
    class Grid
    {
        public Block[,] blocks;
        //public int width, height;

        public int Width
        {
            get
            {
                return blocks.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return blocks.GetLength(1);
            }
        }

        public Grid(int width, int height)
        {
            blocks = new Block[width, height];
        }
    }
}