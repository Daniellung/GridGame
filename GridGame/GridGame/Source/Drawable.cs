using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Drawable
    {
        protected Texture2D myTexture;
        protected Vector2 position;
        protected Vector2 dimensions;
        protected Color color;
        public Drawable()
        {
            color = Color.White;
        }
        
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {            
            spriteBatch.Draw(
                myTexture,
                position,
                color
            );
        }
    }
}
