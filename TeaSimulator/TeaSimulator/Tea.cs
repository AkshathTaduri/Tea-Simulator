using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaSimulator
{
    class Tea
    {
        public static Dictionary<string, string> teaMap;
        public static string[] badTeaNames = { "Muddy Mess\nCrap!Something must have gone terribly wrong", "Concerning Brew\nAre you sure this is okay to drink ? It smells...strange", "Botched Concoction\nThis is unfit for human consumption", "!!!\nIs that...smoke ??" };
        public static string defaultName = "tea";
		public static string defaultDescription = "healthy refreshment";
        public static Random rng = new Random();
		
        Texture2D img;

        string name;
        string description;



        public Tea(Herb h1, Herb h2, Herb h3, Texture2D img)
        {
            Herb[] arr = { h1, h2, h3 };
            bool foundKey = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3 && !foundKey; k++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            if (teaMap.ContainsKey(arr[i].getName() + arr[j].getName() + arr[k].getName()))
                            {
                                string[] split = teaMap[arr[i].getName() + arr[j].getName() + arr[k].getName()].Split('\n');
                                name = split[0];
                                description = split[1];
                                foundKey = true;
                            }
                        }
                    }
                }
            }

            if (!foundKey)
            {
                int r = rng.Next(0, badTeaNames.Length);
                string[] split = badTeaNames[r].Split('\n');
                name = split[0];
                description = split[1];
            }


            

            this.img = img;
        }

        public void draw(SpriteBatch spriteBatch, SpriteFont spriteFont, Rectangle rect)
        {
            spriteBatch.Draw(img, rect, Color.White);
            spriteBatch.DrawString(spriteFont, name, new Vector2(rect.X, rect.Y + rect.Height + 50), Color.Black);
            spriteBatch.DrawString(spriteFont, description, new Vector2(rect.X-300, rect.Y + rect.Height + 100), Color.Black);
        }

        public string getName()
        {
            return name;
        }

        public string getDesc()
        {
            return description;
        }


        public static void initializeDictionary()
        {
            teaMap = new Dictionary<string, string>();
            teaMap["leafleafleaf"] = "Basic Blend\nA refreshing, clean drink.";
            teaMap["berrycreamcream"] = "Sugarcream Tea\nA cute cup perfect for anyone with a sweet tooth.";
            teaMap["spicerootcream"] = "Root Chai\nA rich cup with a small kick. It's perfect to sip in the evening, tradition in many places around the world";
            teaMap["berryspiceroot"] = "Spicefruit Tea\nA subtly sweet, complex blend of flavors. Sure to please anyone interested in a more unique cup";
            teaMap["rootleafspice"] = "Earthen Blend\nA bitter, tough drink. Classic for those with a more aged palate";
            teaMap["leafberrycream"] = "Sweetbrew\nA drink popular with youth. Provides great refreshment, with a sweet touch";
            teaMap["berryberryleaf"] = "Iced Refresher\nAlmost more of a juice than a tea, sweet and fruity. Best served chilled";

        }
    }
}