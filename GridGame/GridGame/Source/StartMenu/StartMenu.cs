using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class StartMenu
    {
        private Background background;
        private MenuOptions menuOptions;
        private KeyboardState previousKstate;

        public StartMenu(ContentManager Content)
        {
            background = new Background(Content);
            menuOptions = new MenuOptions(Content);
        }

        public virtual void Update(KeyboardState kstate)
        {
            if (kstate.IsKeyDown(Keys.Up) && previousKstate.IsKeyUp(Keys.Up)) menuOptions.setCurrentOption(menuOptions.getCurrentOption() - 1);

            if (kstate.IsKeyDown(Keys.Down) && previousKstate.IsKeyUp(Keys.Down)) menuOptions.setCurrentOption(menuOptions.getCurrentOption() + 1);

            if (kstate.IsKeyDown(Keys.Z) && previousKstate.IsKeyUp(Keys.Z)) menuOptions.pressButton();

            if (kstate.IsKeyDown(Keys.X) && previousKstate.IsKeyUp(Keys.X)) menuOptions.setCurrentOption(3);
            
            previousKstate = kstate;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            background.Draw(spriteBatch, gameTime);
            menuOptions.Draw(spriteBatch, gameTime);
        }
    }
}
