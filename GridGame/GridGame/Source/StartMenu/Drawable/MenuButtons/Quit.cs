using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Quit:Button
    {

        public Quit(ContentManager Content)
        {
            normalTexture = Content.Load<Texture2D>("Quit");
            hoveredTexture = Content.Load<Texture2D>("QuitHovered");

            ScreenSettings screenSettings = new ScreenSettings();
            position = new Vector2(screenSettings.getLength() / 2 - 250, screenSettings.getHeight() / 2 + 300);
            setState(ButtonState.Normal);
        }

        public override void setState(ButtonState buttonState)
        {
            base.setState(buttonState);
        }

        public override void pressed()
        {
            Game1.ThisGame.Exit();
            base.pressed();
        }
    }
}
