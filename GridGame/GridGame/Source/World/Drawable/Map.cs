using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Map:Drawable
    {
        private String mapName;
        public Map(ContentManager Content, String mapName)
        {
            this.mapName = mapName;
            this.myTexture = Content.Load<Texture2D>(mapName);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }
}
