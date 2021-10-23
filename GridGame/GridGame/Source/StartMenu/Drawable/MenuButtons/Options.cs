using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Options:Button
    {
        public Options(ContentManager Content)
        {
            normalTexture = Content.Load<Texture2D>("Options");
            hoveredTexture = Content.Load<Texture2D>("OptionsHovered");
            ScreenSettings screenSettings = new ScreenSettings();
            position = new Vector2(screenSettings.getLength() / 2 - 250, screenSettings.getHeight() / 2 + 200);
            setState(ButtonState.Normal);
        }

        public override void setState(ButtonState buttonState)
        {
            base.setState(buttonState);
        }

        public override void pressed()
        {
            base.pressed();
        }
    }
}
