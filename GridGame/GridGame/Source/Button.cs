using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridGame
{
    class Button:Drawable
    {
        protected ButtonState buttonState;
        protected Texture2D normalTexture;
        protected Texture2D hoveredTexture;
        protected Texture2D pressedTexture;
        protected Texture2D unpressedTexture;

        public enum ButtonState
        {
            Normal,
            Hovered,
            Pressed,
            Unpressed
        }
        public Button()
        {
            
        }

        public virtual void setState(ButtonState buttonState)
        {
            this.buttonState = buttonState;
            switch (this.buttonState)
            {
                case ButtonState.Normal:
                    myTexture = normalTexture;
                    break;
                case ButtonState.Hovered:
                    myTexture = hoveredTexture;
                    break;
                case ButtonState.Pressed:
                    myTexture = pressedTexture;
                    break;
                case ButtonState.Unpressed:
                    myTexture = unpressedTexture;
                    break;
            }
        }
        
        public virtual ButtonState getState()
        {
            return buttonState;
        }

        public virtual void pressed()
        {

        }
    }
}
