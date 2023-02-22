using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TeaSimulator
{
    class Button
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private bool isPressed;

        public Button(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public Rectangle getRectangle()
        {
            return rectangle;
        }

        public void switchState()
        {
            isPressed = !isPressed;
        }

        public bool getState()
        {
            return isPressed;
        }
    }
}