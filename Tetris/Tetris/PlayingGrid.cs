using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
    class PlayingGrid : Grid
    {
        public Cursor cursor;

        public PlayingGrid(int width, int height) : base(width, height)
        {
            cursor = new Cursor();
            resetCursor();
        }

        public void Update(Input input)
        {
            if (input.WasPressed(Keys.Left))
            {
                cursor.position.X--;
                if (!isCursorValid(cursor))
                    cursor.position.X++;
            }
            if (input.WasPressed(Keys.Right))
            {
                cursor.position.X++;
                if (!isCursorValid(cursor))
                    cursor.position.X--;
            }
            if (input.WasPressed(Keys.Space))
            {
                Cursor rotated = cursor.Rotate();
                if (isCursorValid(rotated))
                    cursor = rotated;
            }
            
            cursor.position.Y++;
            if (!isCursorValid(cursor))
            {
                cursor.position.Y--;

                for (int x = 0; x < cursor.Width; x++)
                    for (int y = 0; y < cursor.Height; y++)
                        if (cursor.blocks[x, y] != null)
                            blocks[cursor.position.X + x, cursor.position.Y + y] = cursor.blocks[x, y];

                resetCursor();

                if (!isCursorValid(cursor))
                    TetrisGame.isGameOver = true;
            }

            checkRows();
        }

        public void resetCursor()
        {
            cursor.position = new Point(Width / 2 - 1, 0);
            cursor.GenerateRandom();
        }

        public void checkRows()
        {
            for (int y = 0; y < Height; y++)
            {
                bool isFullRow = true;

                for (int x = 0; x < Width; x++)
                    if (blocks[x, y] == null)
                        isFullRow = false;

                if (isFullRow)
                    for (int i = y; i > 0; i--)
                        for (int x = 0; x < Width; x++)
                            blocks[x, i] = blocks[x, i - 1];
            }
        }

        bool isCursorValid(Cursor cursor)
        {
            Point pos = cursor.position;

            if (pos.X < 0 || pos.X > Width - cursor.Width || pos.Y > Height - cursor.Height)
                return false;

            for (int x = 0; x < cursor.Width; x++)
                for (int y = 0; y < cursor.Height; y++)
                    if (cursor.blocks[x, y] != null && blocks[pos.X + x, pos.Y + y] != null)
                        return false;

            return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (blocks[x, y] != null)
                        blocks[x, y].Draw(spriteBatch, x, y);
                    else
                        spriteBatch.Draw(ResourceManager.GetTexture("Block"),
                            new Rectangle(x * Block.size, y * Block.size, Block.size, Block.size), Color.Gray);

            cursor.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}   