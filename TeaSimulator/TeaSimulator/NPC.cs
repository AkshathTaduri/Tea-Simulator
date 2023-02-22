using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaSimulator
{
    class NPC
    {
        private string name;
        private Texture2D img;

        public NPC (string name, Texture2D img)
        {
            this.name = name;
            this.img = img;
        }

        public void draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            spriteBatch.Draw(img, rect, Color.White);
        }
    }
}
