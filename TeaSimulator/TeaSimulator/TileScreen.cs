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
    class TileScreen
    {
        private Tile[,] tileScreen;

        public TileScreen(Tile[,] tileScreen)
        {
            this.tileScreen = tileScreen;
        }

        public void Translate(Vector2 translation)
        {
            for (int i = 0; i < tileScreen.GetLength(0); i++)
            {
                for (int j = 0; j < tileScreen.GetLength(1); j++)
                {
                    tileScreen[i, j].Translate(translation);
                }
            }
        }

        public Tile[,] getTileScreen()
        {
            return tileScreen;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tileScreen.GetLength(0); i++)
            {
                for (int j = 0; j < tileScreen.GetLength(1); j++)
                {
                    tileScreen[i, j].Draw(spriteBatch);
                }
            }
        }

    }
}
