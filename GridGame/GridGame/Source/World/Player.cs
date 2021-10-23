using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Player
    {
        private int playerNumber;
        List<Unit> unitList;
        private int money;


        public Player(int playerNumber)
        {
            this.playerNumber = playerNumber;
            unitList = new List<Unit>();
        }

        public int getPlayerNumber()
        {
            return playerNumber;
        }

        public void addUnit(Unit unit)
        {
            unitList.Add(unit);
        }

        public List<Unit> getUnitList()
        {
            return unitList;
        }
    }
}
