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
    interface Draggable
    {
        bool currentlyClicked();
        bool moveIfClicked(double X, double Y);
        bool checkClick(Rectangle r, double X, double Y);
        void switchClick();
    }
}