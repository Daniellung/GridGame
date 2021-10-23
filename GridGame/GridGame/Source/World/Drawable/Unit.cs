using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Unit:Drawable
    {
        protected Weapon weapon;
        protected Armor armor;
        protected int maxHealth;
        protected int currentHealth;
        protected int strength;
        protected int magic;
        protected int skill;
        protected int luck;
        protected int speed;
        protected int movement;
        protected int defense;
        protected int resistance;
        protected int cost;
        protected UnitType unitType;
        protected Faction faction;
        protected bool used;

        public enum Faction
        {
            GoodFaction,
            OtherGoodFaction,
            NeutralFaction,
            EvilFaction
        }

        public enum UnitType
        {
            Lord,
            Swordsman,
            Spearman,
            Berserker,
            Rogue,
            Archer,
            Mage,
            Cleric,
            Giant,
            Knight,
            ArcherCavalry,
            Flyer,
            Amphibian
        }

        protected Space mySpace;
        protected (int, int) coordinates;

        public Unit(ContentManager Content)
        {
            used = false;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if(mySpace != null) position = mySpace.getPosition();
            base.Draw(spriteBatch, gameTime);
        }

        /* Move the unit from one space to another
         * Removes the unit from its current space if currently 
         * in a space sets new coordinates and moves it to 
         * the new space
         * Returns bool for successful movement
         * @Param column - Column index
         * @Param row - Row index
         * @Param grid - Grid map containing spaces
         */
        public bool move(int column, int row, Space space)
        {
            if (!space.isOccupied())
            {
                if (mySpace != null)
                {
                    mySpace.removeUnit();
                    removeSpace(mySpace); 
                }
                setCoordinates(column, row);
                setSpace(space);
                return true;
            }
            return false;
        }

        public void setState(bool isUsed)
        {
            used = isUsed;
            if (used) color = Color.DarkGray;
            else color = Color.White;
        }

        /* Set the coordinates of the unit, which corresponds to
         * a space in a grid map
         * @Param int column - Column index
         * @Param int row - Row index
         */
        public void setCoordinates(int column, int row)
        {
            coordinates = (column, row);
        }

        /* set mySpace to the space corresponding to current
         * coordinates, and set the unit the space to this unit
         * @Param grid - grid map containing spaces
         */
        public void setSpace(Space space)
        {
            space.addUnit(this);
            mySpace = space;
        }

        /* set mySpace to null, and remove this unit from its space
         * @Param grid - grid map containing spaces
         */
        public void removeSpace(Space space)
        {
            space.removeUnit();
            mySpace = null;
        }

        public int getMovement()
        {
            return movement;
        }

        public int getRange()
        {
            return weapon.getRange();
        }
    }
}
