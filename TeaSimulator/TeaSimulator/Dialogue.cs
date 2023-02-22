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
    class Dialogue
    {
        private List<string> lines;
        private int line;

        public Dialogue(List<string> lines)
        {
            this.lines = lines;
            line = 0;
        }

        public void SetLine(int line)
        {
            this.line = line;
        }

        public bool NextLine()
        {
            if (line < lines.Count-1)
            {
                line++;
                return true;
            } else
            {
                return false;
            }
        }

        public bool NextLineLoop()
        {
            if (line < lines.Count - 1)
            {
                line++;
                return true;
            }
            else
            {
                line = 0;
                return false;
            }
        }

        public string GetLine()
        {
            return lines[line];
        }
    }
}
