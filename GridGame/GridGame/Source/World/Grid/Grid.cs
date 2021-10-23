using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Grid
    {
        private List<List<Space>> grid;
        private int maxColumn;
        private int maxRow;

        /* Initialize 2d array with specified number of columns and rows,
         * then populate each entry with Spaces
         * @Param int column - number of columns in the 2d array
         * @Param int row - number of rows in the 2d array
         */
        public Grid(int column, int row, ContentManager Content)
        {
            maxColumn = column;
            maxRow = row;
            grid = new List<List<Space>>();
            for (int i = 0; i < column; i++)
            {
                List<Space> rowList = new List<Space>();
                for (int j = 0; j < row; j++)
                {
                    Vector2 position = new Vector2(64f * i, 64f * j);
                    Space space = new Space(Content, position, (i, j));
                    rowList.Add(space);
                }
                grid.Add(rowList);
            }
        }

        public int getMaxColumn()
        {
            return maxColumn;
        }

        public int getMaxRow()
        {
            return maxRow;
        }

        /* Return Space element at (column, row)
         * If out of bounds, return null
         * @Param column - column index
         * @Param row - row index
         */
        public Space get(int column, int row)
        {
            if (column < 0 || column >= maxColumn) return null;
            if (row < 0 || row >= maxRow) return null;
            return grid[column][row];
        }

        /* Return Space element at (column, row)
         * If out of bounds, return null
         * @Param coordinates - tuple of (column, row) indices
         */
        public Space get((int, int) coordinates)
        {
            return get(coordinates.Item1, coordinates.Item2);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (List<Space> list in grid)
            {
                foreach (Space space in list)
                {
                    space.Draw(spriteBatch, gameTime);
                }
            }
        }
    }
}
