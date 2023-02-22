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
using System.IO;

namespace TeaSimulator
{
    class ScreenMap
    {
        private TileScreen[,] screenMap;
        private int mapX, mapY;

        public ScreenMap(TileScreen[,] screenMap, int mapX, int mapY)
        {
            this.screenMap = new TileScreen[8, 8];
            for (int i = 0; i < screenMap.GetLength(0); i++)
            {
                for (int j = 0; j < screenMap.GetLength(1); j++)
                {
                    this.screenMap[i, j] = screenMap[i, j];
                }
            }
            this.mapX = mapX;
            this.mapY = mapY;
        }

        public TileScreen getCurrentScreen()
        {
            return screenMap[mapX, mapY];
        }

        public void setScreen(int mapX, int mapY)
        {
            this.mapX = mapX;
            this.mapY = mapY;
        }

        public bool changeScreen(int translationX, int translationY)
        {
            if (mapX + translationX >= 0 && mapX + translationX < 8 && mapY + translationY >= 0 && mapY + translationY < 8)
            {
                mapX += translationX;
                mapY += translationY;
                return true;
            }
            if (mapX + translationX >= 0 && mapX + translationX < 8)
            {
                mapX += translationX;
                return true;
            }
            if (mapY + translationY >= 0 && mapY + translationY < 8)
            {
                mapY += translationY;
                return true;
            }
            return false;
        }

        public TileScreen getScreen(int mapX, int mapY)
        {
            if (mapX >= 0 && mapY >= 0 && mapX < 8 && mapY < 8)
            {
                return screenMap[mapX, mapY];
            } else
            {
                return null;
            }
            
        }
    }
}
