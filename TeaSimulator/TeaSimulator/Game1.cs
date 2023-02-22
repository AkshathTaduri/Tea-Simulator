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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Menu menu;
        private SpriteFont spriteFont;
        private Kitchen kitchen;
        private MouseState oldM;
        private bool teaMade;
        private bool showTeaDesc;
        private Herb[] herbs;
        private GameState gameState;
        private Rectangle menuRect;
        private Rectangle kitchenRect;
        private Rectangle overWorldRect;

        private KeyboardState oldKB;
        private MouseState oldMouse;
        private int mouseX, mouseY;

        private SpriteFont font1;
        private Texture2D simple;
        private Texture2D grassT;
        private Texture2D doorT;
        private Texture2D rockT;
        private Texture2D NPC1T;
        private Texture2D leafTile;
        private Texture2D creamTile;
        private Texture2D spiceTile;
        private Texture2D rootTile;
        private Texture2D berryTile;
        private Texture2D brickT;
        private Texture2D woodT;
        private Texture2D[,] player;
        private Texture2D playerShown;
        private List<string> lines;

        private Button buttonTest;
        private Button nextDialogue;
        private Button toOverworld;
        private Button leaveOverworld;
        private Dialogue dialogueTest;
        private Dialogue johnDialogue;
        private Dialogue adamDialogue;
        private Dialogue quincyDialogue;
        private ScreenMap overworld;
        private Rectangle playerTest;
        private int playerSize;
        private Rectangle rightBounds;
        private Rectangle leftBounds;
        private Rectangle topBounds;
        private Rectangle bottomBounds;
        private string currentText;
        private int timer;
        private int playerDirection; //0 = up, 1 = right, 2 = down, 3 = left

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            timer = 0;
            playerDirection = 0;
            player = new Texture2D[4, 4];
            //player = new Texture2D[2, 2];
            IsMouseVisible = true;
            showTeaDesc = false;
            oldM = Mouse.GetState();
            oldKB = Keyboard.GetState();
            teaMade = false;
            Tea.initializeDictionary();
            gameState = GameState.Kitchen;
            overWorldRect = new Rectangle(700, 0, 50, 50);
            kitchenRect = new Rectangle(700, 50, 50, 50);
            menuRect = new Rectangle(700, 100, 50, 50);
            rightBounds = new Rectangle(1920, 0, 15, 1080);
            leftBounds = new Rectangle(-15, 0, 15, 1080);
            topBounds = new Rectangle(0, -15, 1920, 15);
            bottomBounds = new Rectangle(0, 1024, 1920, 15);
            playerSize = 48;
            playerTest = new Rectangle(1920 / 2 - playerSize / 2, 1080 / 2 - playerSize / 2, playerSize, playerSize);
            lines = new List<string>();
            currentText = "";
            mouseX = oldM.X;
            mouseY = oldM.Y;
            oldKB = Keyboard.GetState();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            herbs = new TeaSimulator.Herb[5];
            
            

            kitchen = new Kitchen(herbs, this.Content.Load<Texture2D>("phasor"), this.Content.Load<Texture2D>("wood"), this.Content.Load<Texture2D>("kettle"), new Rectangle(300, 150, 150, 150), this.Content.Load<Texture2D>("Teacup"));
            menu = new Menu(this.Content.Load<Texture2D>("phasor"));
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = this.Content.Load<SpriteFont>("SpriteFont1");
            font1 = this.Content.Load<SpriteFont>("SpriteFont1");
            simple = this.Content.Load<Texture2D>("blank");
            rockT = this.Content.Load<Texture2D>("rock");
            grassT = this.Content.Load<Texture2D>("grass");
            NPC1T = this.Content.Load<Texture2D>("NPCFiller");
            leafTile = this.Content.Load<Texture2D>("Leaftile");
            berryTile = this.Content.Load<Texture2D>("Berrytile");
            spiceTile = this.Content.Load<Texture2D>("Spicetile");
            rootTile = this.Content.Load<Texture2D>("Roottile");
            creamTile = this.Content.Load<Texture2D>("Creamtile");
            doorT = this.Content.Load<Texture2D>("door");
            brickT = this.Content.Load<Texture2D>("Brick");
            woodT = this.Content.Load<Texture2D>("WoodTile");
            player[0, 0] = this.Content.Load<Texture2D>("PlayerUp");
            player[1, 0] = this.Content.Load<Texture2D>("PlayerUpMove1");
            player[2, 0] = this.Content.Load<Texture2D>("PlayerUpMove2");
            player[3, 0] = this.Content.Load<Texture2D>("PlayerUpMove3");
            player[0, 1] = this.Content.Load<Texture2D>("PlayerRight");
            player[1, 1] = this.Content.Load<Texture2D>("PlayerRightMove1");
            player[2, 1] = this.Content.Load<Texture2D>("PlayerRightMove2");
            player[3, 1] = this.Content.Load<Texture2D>("PlayerRightMove3");
            player[0, 2] = this.Content.Load<Texture2D>("PlayerDown");
            player[1, 2] = this.Content.Load<Texture2D>("PlayerDownMove1");
            player[2, 2] = this.Content.Load<Texture2D>("PlayerDownMove2");
            player[3, 2] = this.Content.Load<Texture2D>("PlayerDownMove3");
            player[0, 3] = this.Content.Load<Texture2D>("PlayerLeft");
            player[1, 3] = this.Content.Load<Texture2D>("PlayerLeftMove1");
            player[2, 3] = this.Content.Load<Texture2D>("PlayerLeftMove2");
            player[3, 3] = this.Content.Load<Texture2D>("PlayerLeftMove3");
            playerShown = player[0, 0];
            leaveOverworld = new Button(simple, new Rectangle(1920 - 100, 1080 - 100, 100, 100));
            ReadFile(@"Content/DialogueTest.txt");
            dialogueTest = new Dialogue(lines);
            lines = new List<String>();
            ReadFile(@"Content/John.txt");
            johnDialogue = new Dialogue(lines);
            lines = new List<String>();
            ReadFile(@"Content/Adam.txt");
            adamDialogue = new Dialogue(lines);
            lines = new List<String>();
            ReadFile(@"Content/Quincy.txt");
            quincyDialogue = new Dialogue(lines);
            lines = new List<String>();
            ReadFile(@"Content/overworld.txt");
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Equals("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||"))
                {
                    lines.Remove(lines[i]);
                    i--;
                }
                else
                {
                    lines[i] = lines[i].Replace("|", String.Empty);
                }
            }
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i]);
            }
            TileScreen[,] screenMap = new TileScreen[8, 8];
            for (int m = 0; m < screenMap.GetLength(0); m++)
            {
                for (int n = 0; n < screenMap.GetLength(1); n++)
                {
                    Tile[,] tileScreen = new Tile[30, 16];
                    for (int i = 0; i < tileScreen.GetLength(0); i++)
                    {
                        for (int j = 0; j < tileScreen.GetLength(1); j++)
                        {
                            if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'g')
                            {
                                tileScreen[i, j] = new Tile(grassT, new Rectangle(64 * i, 64 * j, 64, 64), true);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'x')
                            {
                                tileScreen[i, j] = new Tile(woodT, new Rectangle(64 * i, 64 * j, 64, 64), true);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'i')
                            {
                                tileScreen[i, j] = new Tile(rockT, new Rectangle(64 * i, 64 * j, 64, 64), true);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 's')
                            {
                                tileScreen[i, j] = new Tile(rockT, new Rectangle(64 * i, 64 * j, 64, 64), false);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'v')
                            {
                                tileScreen[i, j] = new Tile(brickT, new Rectangle(64 * i, 64 * j, 64, 64), false);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'N')
                            {
                                tileScreen[i, j] = new Tile(NPC1T, new Rectangle(64 * i, 64 * j, 64, 64), false, dialogueTest);
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'J')
                            {
                                tileScreen[i, j] = new Tile(NPC1T, new Rectangle(64 * i, 64 * j, 64, 64), false, johnDialogue);
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'A')
                            {
                                tileScreen[i, j] = new Tile(NPC1T, new Rectangle(64 * i, 64 * j, 64, 64), false, adamDialogue);
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'Q')
                            {
                                tileScreen[i, j] = new Tile(NPC1T, new Rectangle(64 * i, 64 * j, 64, 64), false, quincyDialogue);
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'l')
                            {
                                tileScreen[i, j] = new Tile(leafTile, new Rectangle(64 * i, 64 * j, 64, 64), true, "leaf");
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'b')
                            {
                                tileScreen[i, j] = new Tile(berryTile, new Rectangle(64 * i, 64 * j, 64, 64), true, "berry");
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'r')
                            {
                                tileScreen[i, j] = new Tile(rootTile, new Rectangle(64 * i, 64 * j, 64, 64), true, "root");
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'p')
                            {
                                tileScreen[i, j] = new Tile(spiceTile, new Rectangle(64 * i, 64 * j, 64, 64), true, "spice");
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == 'c')
                            {
                                tileScreen[i, j] = new Tile(creamTile, new Rectangle(64 * i, 64 * j, 64, 64), true, "cream");
                                tileScreen[i, j].setActiveArea(i, j);
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == '1')
                            {
                                tileScreen[i, j] = new Tile(doorT, new Rectangle(64 * i, 64 * j, 64, 64), true, true, new int[]{ 7, 7 }, new int[] {28, 4});
                            }
                            else if (lines[j + 16 * (n)].ToCharArray()[i + 30 * (m)] == '2')
                            {
                                tileScreen[i, j] = new Tile(doorT, new Rectangle(64 * i, 64 * j, 64, 64), true, true, new int[] { 0, 0 }, new int[] { 12, 6 });
                            }
                            else
                            {
                                tileScreen[i, j] = new Tile(simple, new Rectangle(64 * i, 64 * j, 64, 64), false);
                            }
                        }
                    }
                    screenMap[m, n] = new TileScreen(tileScreen);
                }
            }
            overworld = new ScreenMap(screenMap, 0, 0);
            toOverworld = new Button(simple, new Rectangle(0, 1080 - 100, 100, 100));
            // TODO: use this.Content to load your game content here
        }

        private void ReadFile(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public void playerStuckCollision()
        {
            for (int i = 0; i < overworld.getCurrentScreen().getTileScreen().GetLength(0); i++)
            {
                for (int j = 0; j < overworld.getCurrentScreen().getTileScreen().GetLength(1); j++)
                {
                    if (playerTest.Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                    {
                        if (!overworld.getCurrentScreen().getTileScreen()[i, j].IsPassable())
                        {
                            if (!new Rectangle(playerTest.X + playerSize, playerTest.Y, playerSize, playerSize).Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                            {
                                playerTest = new Rectangle(playerTest.X + playerSize, playerTest.Y, playerSize, playerSize);
                            }
                            else if (!new Rectangle(playerTest.X - playerSize, playerTest.Y, playerSize, playerSize).Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                            {
                                playerTest = new Rectangle(playerTest.X - playerSize, playerTest.Y, playerSize, playerSize);
                            }
                            else if (!new Rectangle(playerTest.X, playerTest.Y + playerSize, playerSize, playerSize).Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                            {
                                playerTest = new Rectangle(playerTest.X, playerTest.Y + playerSize, playerSize, playerSize);
                            }
                            else if (!new Rectangle(playerTest.X, playerTest.Y - playerSize, playerSize, playerSize).Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                            {
                                playerTest = new Rectangle(playerTest.X, playerTest.Y - playerSize, playerSize, playerSize);
                            }
                            else
                            {
                                playerTest = new Rectangle(1920 / 2 - playerSize / 2, 1080 / 2 - playerSize / 2, playerSize, playerSize);
                            }
                        }
                    }
                }
            }
        }

        public void playerMoveCollision(Vector2 translation)
        {
            playerTest.Y += (int)translation.Y;
            playerTest.X += (int)translation.X;
            for (int i = 0; i < overworld.getCurrentScreen().getTileScreen().GetLength(0); i++)
            {
                for (int j = 0; j < overworld.getCurrentScreen().getTileScreen().GetLength(1); j++)
                {
                    if (playerTest.Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                    {
                        if (!overworld.getCurrentScreen().getTileScreen()[i, j].IsPassable())
                        {
                            playerTest.Y -= (int)translation.Y;
                            playerTest.X -= (int)translation.X;
                        }
                    }
                }
            }
        }

        public string CheckDialogue(KeyboardState kb)
        {
            for (int i = 0; i < overworld.getCurrentScreen().getTileScreen().GetLength(0); i++)
            {
                for (int j = 0; j < overworld.getCurrentScreen().getTileScreen().GetLength(1); j++)
                {
                    if (overworld.getCurrentScreen().getTileScreen()[i, j].IsNPC())
                    {
                        int[,] x = overworld.getCurrentScreen().getTileScreen()[i, j].getActiveAreaX();
                        int[,] y = overworld.getCurrentScreen().getTileScreen()[i, j].getActiveAreaY();
                        for (int m = 0; m < 3; m++)
                        {
                            for (int n = 0; n < 3; n++)
                            {
                                if (playerTest.Intersects(overworld.getCurrentScreen().getTileScreen()[x[m, n], y[m, n]].getRectangle()))
                                {
                                    if (kb.IsKeyDown(Keys.Enter) && !oldKB.IsKeyDown(Keys.Enter))
                                    {
                                        overworld.getCurrentScreen().getTileScreen()[i, j].NextLine();
                                    }
                                    return overworld.getCurrentScreen().getTileScreen()[i, j].GetDialogue().GetLine();
                                }
                            }
                        }
                    } else if (overworld.getCurrentScreen().getTileScreen()[i, j].IsHerb())
                    {
                        if (playerTest.Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                        {
                            if (overworld.getCurrentScreen().getTileScreen()[i, j].Herb().Equals("leaf"))
                            {
                                herbs[0] = new Herb("leaf", this.Content.Load<Texture2D>("leaf"), new Rectangle(30 + 150 * 0, 380, 100, 100));
                                overworld.getCurrentScreen().getTileScreen()[i, j].SwitchTexture(grassT);
                            }
                            if (overworld.getCurrentScreen().getTileScreen()[i, j].Herb().Equals("berry"))
                            {
                                herbs[1] = new Herb("berry", this.Content.Load<Texture2D>("berry"), new Rectangle(30 + 150 * 1, 380, 100, 100));
                                overworld.getCurrentScreen().getTileScreen()[i, j].SwitchTexture(grassT);
                            }
                            if (overworld.getCurrentScreen().getTileScreen()[i, j].Herb().Equals("root"))
                            {
                                
                                herbs[3] = new Herb("root", this.Content.Load<Texture2D>("root"), new Rectangle(30 + 150 * 3, 380, 100, 100));
                                overworld.getCurrentScreen().getTileScreen()[i, j].SwitchTexture(grassT);
                            }
                            if (overworld.getCurrentScreen().getTileScreen()[i, j].Herb().Equals("cream"))
                            {
                                herbs[2] = new Herb("cream", this.Content.Load<Texture2D>("cream"), new Rectangle(30 + 150 * 2, 380, 100, 100));
                                overworld.getCurrentScreen().getTileScreen()[i, j].SwitchTexture(grassT);
                            }
                            if (overworld.getCurrentScreen().getTileScreen()[i, j].Herb().Equals("spice"))
                            {
                                herbs[4] = new Herb("spice", this.Content.Load<Texture2D>("spice"), new Rectangle(30 + 150 * 4, 380, 100, 100));
                                overworld.getCurrentScreen().getTileScreen()[i, j].SwitchTexture(grassT);
                            }
                        }
                    } else if (overworld.getCurrentScreen().getTileScreen()[i, j].IsDoor())
                    {
                        if (playerTest.Intersects(overworld.getCurrentScreen().getTileScreen()[i, j].getRectangle()))
                        {
                            playerTest.X = overworld.getCurrentScreen().getTileScreen()[i, j].GetTelePosition()[0] * 64;
                            playerTest.Y = overworld.getCurrentScreen().getTileScreen()[i, j].GetTelePosition()[1] * 64;
                            overworld.setScreen(overworld.getCurrentScreen().getTileScreen()[i, j].GetTo()[0], overworld.getCurrentScreen().getTileScreen()[i, j].GetTo()[1]);
                        }
                    }
                }
            }
            for (int i = 0; i < overworld.getCurrentScreen().getTileScreen().GetLength(0); i++)
            {
                for (int j = 0; j < overworld.getCurrentScreen().getTileScreen().GetLength(1); j++)
                {
                    if (overworld.getCurrentScreen().getTileScreen()[i, j].IsNPC())
                    {
                        overworld.getCurrentScreen().getTileScreen()[i, j].SetLine(0);
                    }
                }
            }
            return "";
        }

        public void animationCycle()
        {
            if (timer < 15)
            {
                playerShown = player[1, playerDirection];
            }
            else if (timer <30)
            {
                playerShown = player[2, playerDirection];
            }
            else if (timer < 45)
            {
                playerShown = player[3, playerDirection];
            }
            else if (timer < 60)
            {
                playerShown = player[2, playerDirection];
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();
            MouseState m = Mouse.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (kb.IsKeyDown(Keys.Escape) && !oldKB.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            if (gameState == GameState.Kitchen)
            {
                if (kitchen.isFull() == false)
                {
                    kitchen.update(oldM, m);
                    if (goToMenu(oldM, m))
                    {
                        kitchen.reset();
                        gameState = GameState.Menu;
                    }
                    if (goToOverworld(oldM, m))
                    {
                        graphics.IsFullScreen = true;
                        graphics.PreferredBackBufferHeight = 1080;
                        graphics.PreferredBackBufferWidth = 1920;
                        graphics.ApplyChanges();
                        kitchen.reset();
                        gameState = GameState.Overworld;
                    }
                }
                else
                {
                    if (teaMade == false)
                    {
                        kitchen.makeTea();
                        teaMade = true;
                    }

                    if (kitchen.kettlePressed(oldM, m))
                    {
                        showTeaDesc = true;
                        Console.Out.WriteLine("kettle pressed");

                    }
                    if (goToKitchen(oldM, m))
                    {
                        Console.Out.WriteLine("kitchen");
                        kitchen.reset();
                        showTeaDesc = false;
                        teaMade = false;
                    }
                    if (goToOverworld(oldM, m))
                    {
                        graphics.IsFullScreen = true;
                        graphics.PreferredBackBufferHeight = 1080;
                        graphics.PreferredBackBufferWidth = 1920;
                        graphics.ApplyChanges();
                        gameState = GameState.Overworld;
                        kitchen.reset();
                        showTeaDesc = false;
                        teaMade = false;
                    }
                    if (goToMenu(oldM, m))
                    {
                        gameState = GameState.Menu;
                        kitchen.reset();
                        showTeaDesc = false;
                        teaMade = false;
                    }
                }
                
            }
            else if (gameState == GameState.Menu)
            {
                menu.Update(oldKB, kb);
                if (goToKitchen(oldM, m))
                {
                    gameState = GameState.Kitchen;
                    kitchen.reset();
                    showTeaDesc = false;
                    teaMade = false;
                }
                if (goToOverworld(oldM, m))
                {
                    gameState = GameState.Overworld;
                    kitchen.reset();
                    showTeaDesc = false;
                    teaMade = false;
                }
            }
            else if (gameState == GameState.Menu)
            {

            }
            else if (gameState == GameState.Overworld)
            {
                if (new Rectangle(mouseX, mouseY, 1, 1).Intersects(leaveOverworld.getRectangle()) && m.LeftButton == ButtonState.Pressed && oldMouse.LeftButton != ButtonState.Pressed)
                {
                    leaveOverworld.switchState();
                    if (leaveOverworld.getState() == true)
                    {
                        graphics.IsFullScreen = false;
                        graphics.PreferredBackBufferHeight = 480;
                        graphics.PreferredBackBufferWidth = 800;
                        graphics.ApplyChanges();
                        gameState = GameState.Kitchen;
                        leaveOverworld.switchState();
                    }
                }
                if (kb.IsKeyDown(Keys.Up)|| kb.IsKeyDown(Keys.Down)|| kb.IsKeyDown(Keys.Left)|| kb.IsKeyDown(Keys.Right))
                {
                    timer++;
                    if (timer == 60)
                    {
                        timer = 0;
                    }
                    animationCycle();
                }
                if (kb.IsKeyUp(Keys.Up) && kb.IsKeyUp(Keys.Down) && kb.IsKeyUp(Keys.Left) && kb.IsKeyUp(Keys.Right))
                {
                    playerShown = player[0, playerDirection];
                    timer = 0;
                }
                if (kb.IsKeyDown(Keys.Up))
                {
                    playerDirection = 0;
                    playerMoveCollision(new Vector2(0, -1));
                    playerMoveCollision(new Vector2(0, -1));
                    playerMoveCollision(new Vector2(0, -1));
                    playerMoveCollision(new Vector2(0, -1));
                    playerMoveCollision(new Vector2(0, -1));
                }
                if (kb.IsKeyDown(Keys.Down))
                {
                    playerDirection = 2;
                    playerMoveCollision(new Vector2(0, 1));
                    playerMoveCollision(new Vector2(0, 1));
                    playerMoveCollision(new Vector2(0, 1));
                    playerMoveCollision(new Vector2(0, 1));
                    playerMoveCollision(new Vector2(0, 1));
                }
                if (kb.IsKeyDown(Keys.Left))
                {
                    playerDirection = 3;
                    playerMoveCollision(new Vector2(-1, 0));
                    playerMoveCollision(new Vector2(-1, 0));
                    playerMoveCollision(new Vector2(-1, 0));
                    playerMoveCollision(new Vector2(-1, 0));
                    playerMoveCollision(new Vector2(-1, 0));
                }
                if (kb.IsKeyDown(Keys.Right))
                {
                    playerDirection = 1;
                    playerMoveCollision(new Vector2(1, 0));
                    playerMoveCollision(new Vector2(1, 0));
                    playerMoveCollision(new Vector2(1, 0));
                    playerMoveCollision(new Vector2(1, 0));
                    playerMoveCollision(new Vector2(1, 0));
                }
                playerStuckCollision();
                if (playerTest.Intersects(topBounds) == true)
                {
                    if (overworld.changeScreen(0, -1))
                    {
                        playerTest.Y = 1024 - playerSize;
                    }
                }
                else if (playerTest.Intersects(bottomBounds))
                {
                    if (overworld.changeScreen(0, 1))
                    {
                        playerTest.Y = 0;
                    }
                }
                else if (playerTest.Intersects(rightBounds))
                {
                    if (overworld.changeScreen(1, 0))
                    {
                        playerTest.X = 0;
                    }
                }
                else if (playerTest.Intersects(leftBounds))
                {
                    if (overworld.changeScreen(-1, 0))
                    {
                        playerTest.X = 1920 - playerSize;
                    }
                }
                currentText = CheckDialogue(kb);
            }
            mouseX = m.X;
            mouseY = m.Y;
            oldM = m;
            oldKB = kb;
            base.Update(gameTime);
        }

        public bool goToKitchen(MouseState oldm, MouseState m)
        {
            if (oldm.LeftButton == ButtonState.Pressed && m.LeftButton == ButtonState.Released && kitchenRect.Contains(new Point(oldm.X, oldm.Y)))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool goToOverworld(MouseState oldm, MouseState m)
        {
            if (oldm.LeftButton == ButtonState.Pressed && m.LeftButton == ButtonState.Released && overWorldRect.Contains(new Point(oldm.X, oldm.Y)))
            {
                graphics.IsFullScreen = true;
                graphics.PreferredBackBufferHeight = 1080;
                graphics.PreferredBackBufferWidth = 1920;
                graphics.ApplyChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool goToMenu(MouseState oldM, MouseState m)
        {
            if (oldM.LeftButton == ButtonState.Pressed && m.LeftButton == ButtonState.Released && menuRect.Contains(new Point(oldM.X, oldM.Y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here


            spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null);
            kitchen.drawKitchen(spriteBatch, new Rectangle(0, 0, 800, 480));
            if (gameState == GameState.Kitchen)
            {
                if (kitchen.isFull() == false)
                {

                    kitchen.drawHerbBar(spriteBatch, new Rectangle(0, 380, 800, 100));
                    kitchen.drawKettle(spriteBatch);
                    spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), menuRect, Color.White);
                    spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), overWorldRect, Color.White);

                }
                else
                {
                    if (kitchen.isFull() == true)
                    {
                        if (showTeaDesc)
                        {
                            spriteBatch.DrawString(spriteFont, "kettle pressed", new Vector2(0, 0), Color.Black);
                            kitchen.drawTeaDesc(spriteBatch, spriteFont);
                            spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), new Rectangle(600, 100, 100, 100), Color.Red);
                            spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), new Rectangle(600, 200, 100, 100), Color.Blue);
                            spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), menuRect, Color.White);
                            spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), overWorldRect, Color.White);
                            spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), kitchenRect, Color.Blue);
                        }
                        else
                        {
                            spriteBatch.DrawString(spriteFont, "Your tea is done! \nPress the kettle to pour tea", new Vector2(0, 0), Color.Black);
                            kitchen.drawKettle(spriteBatch);
                        }

                    }


                }
            }
            else if (gameState == GameState.Menu)
            {
                menu.draw(spriteBatch, spriteFont);
                spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), overWorldRect, Color.White);
                spriteBatch.Draw(this.Content.Load<Texture2D>("phasor"), kitchenRect, Color.Blue);

            }
            else if (gameState == GameState.Overworld)
            {
                overworld.getCurrentScreen().Draw(spriteBatch);
                spriteBatch.Draw(playerShown, playerTest, Color.White);
                spriteBatch.DrawString(font1, currentText, new Vector2(0, 1060), Color.Yellow);
                leaveOverworld.Draw(spriteBatch);
                spriteBatch.DrawString(spriteFont, "overworld", new Vector2(10, 10), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
