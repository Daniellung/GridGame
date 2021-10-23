using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Background:Drawable
    {
        public Background(ContentManager Content)
        {
            myTexture = Content.Load<Texture2D>("StartMenu");
        }
    }
}
