using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class Cursor : Grid
    {
        public Point position;

        public Cursor() : base(2, 3)
        {
            
        }

        public void GenerateRandom()
        {
            Color color = Color.White;

            int rng = new Random().Next(0, 4); //MEER SHAPES AH MATTIE
            if (rng == 0) //Vierkant
            {
                blocks = new Block[2, 2];
                blocks[0, 0] = new Block();
                blocks[0, 1] = new Block();
                blocks[1, 0] = new Block();
                blocks[1, 1] = new Block();

                color = Color.Red;
            }
            else if (rng == 1) //L 1
            {
                blocks = new Block[2, 3];
                blocks[1, 0] = new Block();
                blocks[1, 1] = new Block();
                blocks[1, 2] = new Block();
                blocks[0, 2] = new Block();

                color = Color.Green;
            }
            else if (rng == 2) //L 2
            {
                blocks = new Block[2, 3];
                blocks[0, 0] = new Block();
                blocks[0, 1] = new Block();
                blocks[0, 2] = new Block();
                blocks[1, 2] = new Block();

                color = Color.Blue;
            }
            else if (rng == 3) //I
            {
                blocks = new Block[1, 4];
                blocks[0, 0] = new Block();
                blocks[0, 1] = new Block();
                blocks[0, 2] = new Block();
                blocks[0, 3] = new Block();

                color = Color.Cyan;
            }

            foreach (Block block in blocks)
                if (block != null)
                    block.color = color;
        }

        public Cursor Rotate()
        {
            Cursor result = new Cursor();
            result.blocks = new Block[Height, Width];
            result.position = position; 

            for (int x = 0; x < Height; x++)
                for (int y = 0; y < Width; y++)
                    result.blocks[x, y] = blocks[y, x];

            result = result.Mirror();

            return result;
        }

        public Cursor Mirror()
        {
            Cursor result = new Cursor();
            result.blocks = new Block[Width, Height];
            result.position = position;

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    result.blocks[x, y] = blocks[Width - x - 1, y];

            return result;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (blocks[x, y] != null)
                        blocks[x, y].Draw(spriteBatch, position.X + x, position.Y + y);
        }
    }
}