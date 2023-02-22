using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaSimulator
{

    class Menu
    {
        enum Page { pageOne, pageTwo}

        public static HashSet<Tea> menu;
        Page pageState;
        
        public Menu(Texture2D background)
        {
            menu = new HashSet<Tea>();
            pageState = Page.pageOne;
        }

        public void draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            List<Tea> teas = getTeaList();
            Tea[] t = new Tea[10];
            for (int i = 0;i < teas.Count; i++)
            {
                t[i] = teas[i];
            }
            if (pageState == Page.pageOne)
            {
                for (int i = 0;i < 5; i++)
                {
                    if (t[i] == null)
                    {
                        spriteBatch.DrawString(spriteFont, "???????????", new Vector2(10, i*60 + 50), Color.Black);
                        spriteBatch.DrawString(spriteFont, "?????????????????????????????????????", new Vector2(10, i*60 + 70), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(spriteFont, t[i].getName(), new Vector2(10, i*60 + 50), Color.Black);
                        spriteBatch.DrawString(spriteFont, t[i].getDesc(), new Vector2(10, i*60 + 70), Color.Black);
                    }
                }
                spriteBatch.DrawString(spriteFont, "1", new Vector2(400, 460), Color.Black);
            }
            else
            {
                for (int i = 5;i < t.Length; i++)
                {
                    if (t[i] == null)
                    {
                        spriteBatch.DrawString(spriteFont, "???????????", new Vector2(10, (i-5)*60 + 50), Color.Black);
                        spriteBatch.DrawString(spriteFont, "?????????????????????????????????????", new Vector2(10, (i-5)*60 + 70), Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(spriteFont, t[i].getName(), new Vector2(10, (i-5)*60 + 50), Color.Black);
                        spriteBatch.DrawString(spriteFont, t[i].getDesc(), new Vector2(10, (i-5)*60 + 100), Color.Black);
                    }
                }
                spriteBatch.DrawString(spriteFont, "2", new Vector2(400, 460), Color.Black);
            }
        }

        private List<Tea> getTeaList()
        {
            return new List<Tea>(menu);
        }

        public void Update(KeyboardState oldK, KeyboardState k)
        {
            if (oldK.IsKeyDown(Keys.Left) && !k.IsKeyDown(Keys.Left))
            {
                pageState = Page.pageOne;
            }
            else if (oldK.IsKeyDown(Keys.Right) && !k.IsKeyDown(Keys.Right))
            {
                pageState = Page.pageTwo;
            }
        }
        
        
    }
}
