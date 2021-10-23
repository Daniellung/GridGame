using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class LoadGame:Button
    {
        public LoadGame(ContentManager Content)
        {
            normalTexture = Content.Load<Texture2D>("LoadGame");
            hoveredTexture = Content.Load<Texture2D>("LoadGameHovered");
            ScreenSettings screenSettings = new ScreenSettings();
            position = new Vector2(screenSettings.getLength() / 2 - 250, screenSettings.getHeight() / 2 + 100);
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
