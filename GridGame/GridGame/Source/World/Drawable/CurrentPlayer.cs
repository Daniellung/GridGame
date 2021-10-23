using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class CurrentPlayer
    {
        private Player myPlayer;
        private List<Unit> usedUnitList;

        public CurrentPlayer(Player player)
        {
            myPlayer = player;
            usedUnitList = new List<Unit>();
        }

        public Player getPlayer()
        {
            return myPlayer;
        }

        /* Change current player reference to next player
         * in playerList
         * @Param playerList - List of all players
         */
        public void nextPlayer(List<Player> playerList)
        {
            int indexOf = playerList.IndexOf(myPlayer);
            myPlayer = playerList[indexOf == playerList.Count - 1 ? 0 : indexOf + 1];
            resetUnits();
        }

        /* Clear current list of used units
         */
        public void resetUnits()
        {
            foreach(Unit unit in usedUnitList)
            {
                unit.setState(false);
            }
            usedUnitList.Clear();
        }

        /* Check to see if passed in unit is part of current
         * player's roster, and also unused.
         * @Param unit - unit to check for status
         */
        public bool unusedUnit(Unit unit)
        {
            return myPlayer.getUnitList().Contains(unit) && !usedUnitList.Contains(unit);
        }

        /* Set current unit to used state, and add unit to 
         * list of used units. If all units are used, return true.
         * @Param unit - unit to be marked as used
         */
        public bool useUnit(Unit unit)
        {
            usedUnitList.Add(unit);
            unit.setState(true);
            return (myPlayer.getUnitList().Count == usedUnitList.Count);
        }
    }
}
