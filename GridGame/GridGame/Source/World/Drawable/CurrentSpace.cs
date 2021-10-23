using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class CurrentSpace:Drawable
    {
        private (int, int) coordinates;
        private Space mySpace;
        private Unit unit;
        private List<Space> spaceList;
        private List<Space> rangeList;

        public CurrentSpace(ContentManager Content, (int, int) coordinates, Grid grid)
        {
            spaceList = new List<Space>();
            rangeList = new List<Space>();
            setSpace(coordinates, grid);
            myTexture = Content.Load<Texture2D>("highlightedSquare");
        }

        /* Select the unit on the current tile if there is no unit 
         * selected, or move the unit if there is a unit already
         * selected and the unit has not already been used, and 
         * changes the tile overlay. Return if all of current player's
         * units have been used
         * @Param grid - grid of spaces for overlay
         */
        public bool selectUnit(Grid grid, CurrentPlayer currentPlayer)
        {
            bool usedUnits = false;
            //if no unit currently selected, select unit
            if (unit == null)
            {
                if (mySpace.isOccupied() && currentPlayer.unusedUnit(mySpace.getUnit()))
                {
                    unit = mySpace.getUnit();
                    gridTraversal(grid, unit.getMovement(), coordinates, spaceList, Space.OverlayState.move);
                    foreach(Space space in spaceList)
                    {
                        gridTraversal(grid, unit.getRange(), space.getCoordinates(), rangeList, Space.OverlayState.attack);
                    }
                }
            }
            //if unit selected, move unit
            else if(spaceList.Contains(mySpace))
            {
                if(unit.move(coordinates.Item1, coordinates.Item2, mySpace))
                {
                    usedUnits = currentPlayer.useUnit(unit);
                    unselectUnit();
                }
            }
            return usedUnits;
        }

        /* Unselect the unit and clear the currently drawn overlay
         * spaces
         */
        public void unselectUnit()
        {
            unit = null;
            foreach(Space space in spaceList)
            {
                space.setOverlayState(Space.OverlayState.none);
            }

            foreach (Space space in rangeList)
            {
                space.setOverlayState(Space.OverlayState.none);
            }
            spaceList.Clear();
            rangeList.Clear();
        }

        /* DFS traversal with range limit, sets state of each space to overlayState
         * and adds the space to its respective List<Space>
         * @Param grid - grid of spaces
         * @Param movement - range of dfs search
         * @Param coords - coordinates of current Space
         * @Param myList - list to add current space to
         * @Param overlayState - state to set current space to
         */
        public void gridTraversal(Grid grid, int movement, (int, int) coords, List<Space> myList, Space.OverlayState overlayState)
        {

            //if (grid.get(coords).isOccupied() && isenemy)
            //{
            //    grid.get(coords).setOverlayState(Space.OverlayState.enemy);
            //    return;
            //}

            if (!spaceList.Contains(grid.get(coords)))
            {
                myList.Add(grid.get(coords));
                if (movement >= 0) grid.get(coords).setOverlayState(overlayState);
            }

            if (movement > 0)
            {
                if(coords.Item1 > 0)
                    gridTraversal(grid, movement - 1, (coords.Item1 - 1, coords.Item2), myList, overlayState);
                if(coords.Item1 < grid.getMaxColumn() - 1) 
                    gridTraversal(grid, movement - 1, (coords.Item1 + 1, coords.Item2), myList, overlayState);
                if (coords.Item2 > 0) 
                    gridTraversal(grid, movement - 1, (coords.Item1, coords.Item2 - 1), myList, overlayState);
                if (coords.Item2 < grid.getMaxRow() - 1) 
                    gridTraversal(grid, movement - 1, (coords.Item1, coords.Item2 + 1), myList, overlayState);
            }
        }

        /* move the current space marker if the new space is valid,
         * and if a unit is selected then do not move outside its
         * movement range
         * @Param coordinates - coordinates of the new space
         * @Param grid - grid of spaces
         */
        public void setSpace((int, int) coordinates, Grid grid)
        {
            if(grid.get(coordinates) != null)
            {
                if(unit == null)
                {
                    this.coordinates = coordinates;
                    mySpace = grid.get(coordinates);
                }
                else if (spaceList.Contains(grid.get(coordinates)))
                {
                    this.coordinates = coordinates;
                    mySpace = grid.get(coordinates);
                }
            }
        }

        public void setColumn(int column, Grid grid)
        {
            setSpace((column, coordinates.Item2), grid);
        }

        public void setRow(int row, Grid grid)
        {
            setSpace((coordinates.Item1, row), grid);
        }

        public (int, int) getCoordinates()
        {
            return coordinates;
        }
        public int getColumn()
        {
            return coordinates.Item1;
        }
        public int getRow()
        {
            return coordinates.Item2;
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (mySpace != null) position = mySpace.getPosition();
            base.Draw(spriteBatch, gameTime);
        }
    }
}
