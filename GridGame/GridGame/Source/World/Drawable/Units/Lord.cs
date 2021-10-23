using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Lord:Unit
    {
        public Lord(ContentManager Content): base(Content)
        {
            myTexture = Content.Load<Texture2D>("player");
            movement = 6;
            unitType = UnitType.Lord;
            weapon = new Weapon(1);
        }
    }
}
