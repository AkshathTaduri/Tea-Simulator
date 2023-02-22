using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaSimulator
{
    class Herb
    {
        private string name;
        private Texture2D img;
        private Rectangle rect;
        private Rectangle ogRect;


        private bool clicked;

    public Herb(string name, Texture2D img, Rectangle rect)
    {
        this.name = name;
        this.img = img;
        this.rect = rect;
            ogRect = rect;
    }

    public void draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(img, rect, Color.White);
    }

    public string getName()
    {
        return name;
    }
    
    public Rectangle getRect()
        {
            return rect;
        }

    //Draggable nonsense
    public bool currentlyClicked() { return clicked; }

    public bool moveIfClicked(double X, double Y)
    {
        if (clicked)
        {
            rect = new Rectangle((int)X, (int)Y, rect.Width, rect.Height);
        }
        return false;
    }

    public bool checkClick(double X, double Y)
    {
        if (rect.Contains(new Point((int)X, (int)Y)))
        {
            return true;
        }
        return false;
    }

    public void switchClick() { clicked = !clicked; }

    public void goBack()
        {
            rect = ogRect;
        }
    }
}