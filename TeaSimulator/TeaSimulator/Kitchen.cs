using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaSimulator
{
    class Kitchen
    {
        
        Herb[] herbs;
        Texture2D kitchenImg;
        Texture2D bar;
        Kettle kettle;
        Rectangle kettleRect;
        Tea tea;
        Texture2D teaImg;

        public Kitchen(Herb[] herbs, Texture2D kitchenImg, Texture2D bar, Texture2D kettleImg, Rectangle kettleRect, Texture2D teaImg)
        {
            this.herbs = herbs;
            this.kitchenImg = kitchenImg;
            this.bar = bar;
            kettle = new TeaSimulator.Kettle(kettleImg, kettleRect);
            this.kettleRect = kettleRect;
            this.teaImg = teaImg;
        }

        public void reset()
        {
            kettle.reset();
            tea = null;
        }

        public void drawKitchen(SpriteBatch spriteBatch, Rectangle rect)
        {
            spriteBatch.Draw(kitchenImg, rect, Color.PeachPuff);
        }

        public void drawHerbBar(SpriteBatch spriteBatch, Rectangle rect)
        {
            spriteBatch.Draw(bar, rect, Color.White);
            for (int i = 0; i < herbs.Length; i++)
            {
                if (herbs[i] != null)
                herbs[i].draw(spriteBatch);

            }
        }

        public void drawKettle(SpriteBatch spriteBatch)
        {
            kettle.draw(spriteBatch);
        }

        public void drawTeaDesc(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            tea.draw(spriteBatch, spriteFont, kettleRect);
        }

        public void makeTea()
        {
            tea = kettle.makeTea(teaImg);
            bool addTea = true;
            for (int i = 0;i < Tea.badTeaNames.Length; i++)
            {
                if (Tea.badTeaNames[i].Contains(tea.getName()))
                {
                    addTea = false;
                }
            }
            if (addTea)
                Menu.menu.Add(tea);
        }

        public bool isFull()
        {
            return kettle.fullCapacity();
        }

        public bool kettlePressed(MouseState oldM, MouseState m)
        {
            if (oldM.LeftButton == ButtonState.Pressed && m.LeftButton == ButtonState.Released && kettle.getRect().Contains(new Point(oldM.X, oldM.Y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public void update(MouseState oldM, MouseState m)
        {
            
            if (kettle.fullCapacity() == false)
            {
                bool click = oldM.LeftButton == ButtonState.Pressed && m.LeftButton == ButtonState.Released;
                foreach (Herb h in herbs)
                {
                    if (click && h != null)
                    {
                        if (h.currentlyClicked())
                        {
                            h.switchClick();
                        }
                        else if (h.checkClick(m.X, m.Y) && h != null)
                        {
                            h.switchClick();
                        }
                    }
                    if (h != null)
                    h.moveIfClicked(m.X, m.Y);
                }

                for (int i = 0; i < herbs.Length; i++)
                {
                    if (herbs[i] != null && herbs[i].getRect().Intersects(kettle.getRect()) && !herbs[i].currentlyClicked())
                    {
                        kettle.addHerb(herbs[i]);
                        herbs[i].goBack();
                    }
                    if (kettle.fullCapacity())
                    {
                        break;
                    }
                }
            }
            
        }
        
    }
}
