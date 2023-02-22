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
    class Tile
    {
        private bool isNPC;
        private bool isDoor;
        private Texture2D texture;
        private Rectangle rectangle;
        private bool passable;
        private Dialogue dialogue;
        private int[,] activeAreaX;
        private int[,] activeAreaY;
        private int[] to;
        private bool isHerb;
        private string herb;
        private int[] telePosition;

        public Tile(Texture2D texture, Rectangle rectangle, bool passable)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.passable = passable;
            isDoor = false;
            isNPC = false;
            isHerb = false;
            herb = "";
        }

        public Tile(Texture2D texture, Rectangle rectangle, bool passable, bool isDoor, int[] to, int[] telePosition)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.passable = passable;
            this.isDoor = isDoor;
            this.to = to;
            this.telePosition = telePosition;
            isNPC = false;
            isHerb = false;
            herb = "";
        }

        public Tile(Texture2D texture, Rectangle rectangle, bool passable, string herb)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.passable = passable;
            isDoor = false;
            isNPC = false;
            isHerb = true;
            this.herb = herb;
        }

        public Tile(Texture2D texture, Rectangle rectangle, bool passable, Dialogue dialogue)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.passable = passable;
            this.dialogue = dialogue;
            activeAreaX = new int[3, 3];
            activeAreaY = new int[3, 3];
            isDoor = false;
            isNPC = true;
            isHerb = false;
            herb = "";
        }

        public void SwitchTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        public int[] GetTelePosition()
        {
            return telePosition;
        }

        public int[] GetTo()
        {
            return to;
        }

        public bool IsDoor()
        {
            return isDoor;
        }

        public bool IsHerb()
        {
            return isHerb;
        }

        public string Herb()
        {
            return herb;
        }

        public bool IsNPC()
        {
            return isNPC;
        }

        public void setActiveArea(int centerX, int centerY)
        {
            if (isNPC == true)
            {
                activeAreaX = new int[,] {
                {centerX -1, centerX, centerX + 1},
                {centerX -1, centerX, centerX + 1},
                {centerX -1, centerX, centerX +1 }
            };
                activeAreaY = new int[,] {
                {centerY + 1, centerY +1, centerY +1},
                {centerY, centerY, centerY},
                {centerY-1, centerY-1, centerY -1}
            };
            } else
            {

            }
        }

        public int[,] getActiveAreaX()
        {
            if (isNPC == true)
            {
                return activeAreaX;
            }
            else
            {
                return null;
            }
        }

        public int[,] getActiveAreaY()
        {
            if (isNPC == true)
            {
                return activeAreaY;
            }
            else
            {
                return null;
            }
        }

        public Dialogue GetDialogue()
        {
            if (isNPC == true)
            {
                return dialogue;
            } else
            {
                return null;
            }
            
        }

        public void NextLine()
        {
            if (isNPC == true)
            {
                dialogue.NextLine();
            }
            else
            {
            }
        }

        public string GetLine()
        {
            if (isNPC == true)
            {
                return dialogue.GetLine();
            }
            else
            {
                return null;
            }
        }

        public void SetLine(int line)
        {
            if (isNPC == true)
            {
                dialogue.SetLine(line);
            }
            else
            {
            }
            
        }

        public bool IsPassable()
        {
            return passable;
        }

        public void SetPosition(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        public Texture getTexture()
        {
            return texture;
        }

        public Rectangle getRectangle()
        {
            return rectangle;
        }

        public void Translate(Vector2 translation)
        {
            rectangle.X += (int)translation.X;
            rectangle.Y += (int)translation.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
