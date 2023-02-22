using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaSimulator
{
    
    class Kettle
    {
        private Texture2D img;
        private Rectangle rect;
        private Herb h1;
        private Herb h2;
        private Herb h3;

        public Kettle(Texture2D img, Rectangle rect)
        {
            this.img = img;
            this.rect = rect;
        }

        public bool validCombination(Herb h1, Herb h2, Herb h3)
        {
            return false;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, rect, Color.White);
        }

        public void addHerb(Herb b)
        {
            if (h1 == null)
            {
                h1 = b;
            }
            else if (h2 == null)
            {
                h2 = b;
            }
            else if (h3 == null)
            {
                h3 = b;
            }
        }

        public bool fullCapacity()
        {
            return h1 != null && h2 != null && h3 != null;
        }

        public Tea makeTea(Texture2D teaImg)
        {
            return new Tea(h1, h2, h3, teaImg);
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public void reset()
        {
            h1 = null;
            h2 = null;
            h3 = null;
        }
    }
}
