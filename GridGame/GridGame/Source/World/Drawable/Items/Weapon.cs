using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Weapon
    {
        protected int range;
        
        public Weapon(int range)
        {
            this.range = range;
        }

        public int getRange()
        {
            return range;
        }
    }
}
