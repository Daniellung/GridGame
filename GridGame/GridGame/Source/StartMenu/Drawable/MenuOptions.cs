using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class MenuOptions
    {
        private List<Button> menuButtons;
        private int currentOption;
        private readonly int MAX_OPTION_NUMBER = 3;

        public MenuOptions(ContentManager Content)
        {
            menuButtons = new List<Button>(4);
            menuButtons.Add(new StartGame(Content));
            menuButtons.Add(new LoadGame(Content));
            menuButtons.Add(new Options(Content));
            menuButtons.Add(new Quit(Content));

            currentOption = 0;
            menuButtons[currentOption].setState(Button.ButtonState.Hovered);
        }

        public void pressButton()
        {
            menuButtons[currentOption].pressed();
        }

        public int getCurrentOption()
        {
            return currentOption;
        }

        /* Set the currently selected menu option to 
         * optionNumber
         * @Param optionNumber - index for menuButtons list
         */
        public void setCurrentOption(int optionNumber)
        {
            menuButtons[currentOption].setState(Button.ButtonState.Normal);

            currentOption = optionNumber;
            if (currentOption > MAX_OPTION_NUMBER) currentOption = 0;
            else if (currentOption < 0) currentOption = MAX_OPTION_NUMBER;

            menuButtons[currentOption].setState(Button.ButtonState.Hovered);
        }
        
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach(Button button in menuButtons)
            {
                button.Draw(spriteBatch, gameTime);
            }
        }
    }
}
