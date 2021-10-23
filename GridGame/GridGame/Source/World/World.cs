using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class World
    {
        private Grid grid;
        private Map map;
        private CurrentSpace currentSpace;
        private KeyboardState previousKstate;
        private List<Player> playerList;
        private CurrentPlayer currentPlayer;


        public World(ContentManager Content)
        {
            //bunch of hardcoded stuff for now
            //initialize map dimensions, fix this later
            grid = new Grid(30, 17, Content);
            map = new Map(Content, "map");

            Lord myUnit = new Lord(Content);
            Lord myOtherUnit = new Lord(Content);
            Lord myThirdUnit = new Lord(Content);
            myUnit.move(3, 4, grid.get(3, 4));
            myOtherUnit.move(6, 3, grid.get(6, 3));
            myThirdUnit.move(3, 5, grid.get(3, 5));

            playerList = new List<Player>();
            playerList.Add(new Player(0));
            playerList[0].addUnit(myUnit);
            playerList[0].addUnit(myThirdUnit);
            playerList.Add(new Player(1));
            playerList[1].addUnit(myOtherUnit);

            currentSpace = new CurrentSpace(Content, (0, 0), grid);
            currentPlayer = new CurrentPlayer(playerList[0]);
        }
        public virtual void Update(KeyboardState kstate)
        {

            if (kstate.IsKeyDown(Keys.Up) && previousKstate.IsKeyUp(Keys.Up)) currentSpace.setRow(currentSpace.getRow() - 1, grid);

            if (kstate.IsKeyDown(Keys.Down) && previousKstate.IsKeyUp(Keys.Down)) currentSpace.setRow(currentSpace.getRow() + 1, grid);

            if (kstate.IsKeyDown(Keys.Left) && previousKstate.IsKeyUp(Keys.Left)) currentSpace.setColumn(currentSpace.getColumn() - 1, grid);

            if (kstate.IsKeyDown(Keys.Right) && previousKstate.IsKeyUp(Keys.Right)) currentSpace.setColumn(currentSpace.getColumn() + 1, grid);

            if (kstate.IsKeyDown(Keys.Z) && previousKstate.IsKeyUp(Keys.Z)) 
                if(currentSpace.selectUnit(grid, currentPlayer))
                    currentPlayer.nextPlayer(playerList);

            if (kstate.IsKeyDown(Keys.X) && previousKstate.IsKeyUp(Keys.X)) currentSpace.unselectUnit();

            previousKstate = kstate;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            map.Draw(spriteBatch, gameTime);

            grid.Draw(spriteBatch, gameTime);

            currentSpace.Draw(spriteBatch, gameTime);
        }
    }
}
