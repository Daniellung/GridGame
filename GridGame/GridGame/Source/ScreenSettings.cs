using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class ScreenSettings
    {
        private static int SCREEN_LENGTH;
        private static int SCREEN_HEIGHT;
        private static bool FULLSCREEN;

        public ScreenSettings()
        {
        }

        public ScreenSettings(int length, int height, bool fullscreen)
        {
            SCREEN_LENGTH = length;
            SCREEN_HEIGHT = height;
            FULLSCREEN = fullscreen;
        }

        public void setLength(int length)
        {
            SCREEN_LENGTH = length;
        }

        public void setHeight(int height)
        {
            SCREEN_HEIGHT = height;
        }

        public void setFullscreen(bool fullscreen)
        {
            FULLSCREEN = fullscreen;
        }

        public int getLength()
        {
            return SCREEN_LENGTH;
        }

        public int getHeight()
        {
            return SCREEN_HEIGHT;
        }

        public bool getFullscreen()
        {
            return FULLSCREEN;
        }
    }
}
