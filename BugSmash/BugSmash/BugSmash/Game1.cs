#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Linq;
#endregion

namespace BugSmash
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        //found this line of code on a website
        //used it to fix problem of random nums generating too fast (created too similar numbers)
        Random random = new Random(Guid.NewGuid().GetHashCode());
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fontPlay, titleFont, gameOverFont;
        //pixel texture allows us to draw simple rectangles
        //will be replaced with actual textures later
        private Texture2D pixel;
        private Texture2D blanket;
        private Texture2D menuSplash, menuSplashPlay, menuSplashSettings;
        private Texture2D background;
        private Texture2D bugUp, bugDown, bugLeft, bugRight;
        private Texture2D splat;
        private Texture2D arm;
        public SoundEffect splatSound, menuSong, splat2;
        public SoundEffectInstance instance1, instance2;
        //lists that update and maintain bugs & splats in game
        private List<Splat> splatlist = new List<Splat>();
        private List<Bug> buglist = new List<Bug>();
        private int level = 1;
        public int score = 0;
        public int highScore;
        private int lives = 3;
        private int lifeReplenish;
        public int screen = 0;
        public bool gameOver;
        public bool soundStarted = false;
        public int splatSelect;
        private int buttonHoverScreen;
        Vector2 fontPos;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 25;
        //creates menu screen
        MenuScreen menu = new MenuScreen();
        //used for drawing color filled rectangles
        Color[] colordata = { Color.White };
        //used to make game fullscreen
        public int screenWidth { get; set; }
        public int screenHeight { get; set; }
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
       
        protected override void Initialize()
        {
            if(File.Exists("gameName.txt"))
            {
                File.Delete("gameName.txt");
            }
            if (File.Exists("newEnemy.png"))
            {
                File.Delete("newEnemy.png");
            }
            if (File.Exists("newObjective.png"))
            {
                File.Delete("newObjective.png");
            }
            if (File.Exists("newBackground.png"))
            {
                File.Delete("newBackground.png");
            }
            //creates bugs for level 1
            int num = ((Vars.screenWidth * 17) / 16);
            for (int i = buglist.Count; i < (level); i++)
            {
                switch (random.Next(0, 2))
                {
                    case 0: buglist.Add(new Bug(random.Next(0, num), 0 - (Vars.screenWidth / 16), 0)); break;
                    case 1: buglist.Add(new Bug(((Vars.screenWidth * 17) / 16), random.Next(0, ((Vars.screenHeight * 90) / 100)), 0)); break;
                }
            }
            this.IsMouseVisible = true;
            gameOver = false;
            graphics.IsFullScreen = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //create spritebatch
            //loads background, bug, splat, and blanket image files
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menuSplash = Content.Load<Texture2D>("MenuSplash");
            menuSplashPlay = Content.Load<Texture2D>("MenuSplashPlay");
            menuSplashSettings = Content.Load<Texture2D>("MenuSplashSettings");
            blanket = Content.Load<Texture2D>("Blanket");
            background = Content.Load<Texture2D>("Grass");
            bugUp = Content.Load<Texture2D>("BugUp");
            bugDown = Content.Load<Texture2D>("BugDown");
            bugLeft = Content.Load<Texture2D>("BugLeft");
            bugRight = Content.Load<Texture2D>("BugRight");
            splat = Content.Load<Texture2D>("splat");
            fontPlay = Content.Load<SpriteFont>("playFont");
            titleFont = Content.Load<SpriteFont>("TitleFont");
            gameOverFont = Content.Load<SpriteFont>("GameOverFont");
            arm = Content.Load<Texture2D>("FINGER");
            splatSound = Content.Load<SoundEffect>("SPLAT.wav");
            splat2 = Content.Load<SoundEffect>("Splat2.wav");
            menuSong = Content.Load<SoundEffect>("IntroBugSmash.wav");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //states keep track of what screen the game should be displaying
            //0 = menu
            //1 = game
            //2 = gameOver
            //might replace with enums later on
            if (screen == 0)
            {
                //draws colored rectangles
                pixel = new Texture2D(GraphicsDevice, 1, 1);
                pixel.SetData<Color>(colordata);
                if (soundStarted == false)
                {
                    instance1 = menuSong.CreateInstance();
                    instance1.IsLooped = true;
                    instance1.Play();
                    soundStarted = true;
                }
                //checks if play button is clicked
                //if true the screen is changed and variables are reset (allows games to be played in succession)
                buttonHoverScreen = menu.buttonHover();
                menu.checkButton();
                if (menu.clicked == true) { screen = 1; buglist.Clear(); splatlist.Clear(); level = 0; instance1.Stop(); soundStarted = false; menu.clicked = false; }
            }
            else if (screen == 1)
            {
                this.IsMouseVisible = false;
                //each level lasts until all bugs are killed
                if (buglist.Count > 0)
                {
                    //can't edit amount of bugs in the list (due to foreach restrictions)
                    //workaround by using an array
                    foreach (Bug b in buglist) b.checkDeath();
                    foreach (Bug b in buglist.ToArray())
                    {
                        //if a bug dies, remove it from buglist and add to splatlist
                        if (b.dead == true)
                        {
                            splatlist.Add(new Splat(b.X, b.Y));
                            buglist.Remove(b);
                            score++;
                            lifeReplenish++;

                            splatSelect = random.Next(0, 2);
                            //change up splat sound effects
                            switch(splatSelect)
                            {
                                case 0:
                                    instance1 = splatSound.CreateInstance();
                                    instance1.Play();
                                    break;
                                case 1:
                                    instance1 = splat2.CreateInstance();
                                    instance1.Play();
                                    break;
                            }

                        }
                        //player gets a life for every 25 kills
                        if (lifeReplenish == 25)
                        {
                            lives++;
                            lifeReplenish = 0;
                        }
                    }
                    //we had framerate issues (everything was moving superfast)
                    //regulates time between frames
                    timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        timeSinceLastFrame -= millisecondsPerFrame;
                        //checks to see if any bugs made it to the blanket
                        //if bug made it to the blanket subtract lives and score
                        //if a bug hits the blanket and there are no more lives end the game
                        //shows game over screen
                        foreach (Bug a in buglist)
                        {
                            gameOver = a.Move();
                            if (gameOver) { lives -= 1; a.Dead = true; score -= 1; }
                            if (gameOver && lives == 0) { screen = 2; break; }

                        }
                    }
                }
                //if no game over criteria are met
                //go to the next level (repopulates bug list)
                else
                {
                    level += 1;
                    splatlist.Clear();
                    for (int i = buglist.Count; i < (level * level); i++)
                    {
                        int ranny = random.Next(0, 2);
                        switch (ranny)
                        {
                            case 0: buglist.Add(new Bug(random.Next(0, (Vars.screenWidth * 17) / 16), 0 - (Vars.screenWidth / 16), 0)); break;
                            case 1: buglist.Add(new Bug(((Vars.screenWidth * 17) / 16), random.Next(0, ((Vars.screenHeight * 90) / 100)), 0)); break;
                        }

                    }
                }
            }
            //if player clicks on the gameover screen transition back to menu screen
            else if (screen == 2)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    score = 0;
                    lives = 3;
                    lifeReplenish = 0;
                    screen = 0;
                    this.IsMouseVisible = true;
                }
            }
            base.Update(gameTime);
        }


        public void WriteScore()
        {
            StreamWriter output = null;
            output = new StreamWriter("score.txt");
            output.WriteLine();
            output.Write(this.score);
            output.Close();
        }
        public int ReadScore()
        {
            int scoreAdd;
            string line = "";
            List<int> scores = new List<int>();
            StreamReader input = null;
            input = new StreamReader("score.txt");
            String[] splitLine;
            while ((line = input.ReadLine()) != null)
            {
                splitLine = line.Split('\n');

                for (int i = 0; i < splitLine.Length; i++)
                {
                    if (splitLine[i] != "")
                    {
                        scoreAdd = Int32.Parse(splitLine[i]);
                        scores.Add(scoreAdd);
                    }
                    else { continue; }
                }
            }
            input.Close();
            foreach (int i in scores)
            {
                if (i > highScore)
                {
                    highScore = i;
                }
            }
            return highScore;
        }

        protected override void Draw(GameTime gameTime)
        {
            Vars.screenHeight = Window.ClientBounds.Height;
            Vars.screenWidth = Window.ClientBounds.Width;
            spriteBatch.Begin();
           
            if (screen == 0)
            {
                GraphicsDevice.Clear(Color.Bisque);
                //draws menu screen background, changes if user mouses over buttons
                if(buttonHoverScreen == 0)
                {
                    spriteBatch.Draw(menuSplash, new Rectangle(0, 0, Vars.screenWidth, Vars.screenHeight), Color.White);
                }
                else if(buttonHoverScreen == 1)
                {
                    spriteBatch.Draw(menuSplashPlay, new Rectangle(0, 0, Vars.screenWidth, Vars.screenHeight), Color.White);
                }
                else if(buttonHoverScreen == 2)
                {
                    spriteBatch.Draw(menuSplashSettings, new Rectangle(0, 0, Vars.screenWidth, Vars.screenHeight), Color.White);
                }
                fontPos.X = Vars.screenWidth / 4;
                fontPos.Y = Vars.screenHeight / 4;


                if (File.Exists("gameName.txt"))
                {
                    StreamReader input = new StreamReader("gameName.txt");
                    string newName = input.ReadLine();
                    input.Close();
                    spriteBatch.DrawString(titleFont, newName + " Smash", fontPos, Color.Black);
                }
                else
                {
                    spriteBatch.DrawString(titleFont, "Bug Smash", fontPos, Color.Black);
                }
            }

            else if (screen == 1)
            {
                string imageLocation = Directory.GetCurrentDirectory();
                GraphicsDevice.Clear(Color.CornflowerBlue);
                if(File.Exists("newBackground.png"))
                {
                    background = Content.Load<Texture2D>("newBackground");
                }
                else
                {
                    background = Content.Load<Texture2D>("Grass");
                }
                if (File.Exists("newEnemy.png"))
                {
                    bugUp = Content.Load<Texture2D>("newEnemy");
                    bugDown = bugUp;
                    bugLeft = bugUp;
                    bugRight = bugUp;
                }
                else
                {
                    bugUp = Content.Load<Texture2D>("BugUp");
                    bugDown = Content.Load<Texture2D>("BugDown");
                    bugLeft = Content.Load<Texture2D>("BugLeft");
                    bugRight = Content.Load<Texture2D>("BugRight");
                }
                if (File.Exists("newObjective.png"))
                {
                    blanket = Content.Load<Texture2D>("newObjective");
                }
                else
                {
                    blanket = Content.Load<Texture2D>("Blanket");
                }
                spriteBatch.Draw(background, new Rectangle(0, 0, Vars.screenWidth, Vars.screenHeight), Color.WhiteSmoke);
                spriteBatch.Draw(blanket, new Rectangle(0, ((Vars.screenHeight * 2) / 3), Vars.screenWidth / 4, Vars.screenHeight / 3), Color.White);
                foreach (Splat s in splatlist)
                {
                    spriteBatch.Draw(splat, new Rectangle(s.X, s.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.Blue);
                }
                //draw each bug based on its current direction (we used ratios to maintain object sizes)
                foreach (Bug b in buglist)
                {
                    switch (b.Direction)
                    {
                        case 0: spriteBatch.Draw(bugUp, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.White); break;
                        case 1: spriteBatch.Draw(bugRight, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.White); break;
                        case 2: spriteBatch.Draw(bugDown, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.White); break;
                        case 3: spriteBatch.Draw(bugLeft, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.White); break;
                    }
                }

                MouseState mouseLoc = new MouseState();
                mouseLoc = Mouse.GetState();

                spriteBatch.Draw(arm, new Rectangle((mouseLoc.X - (Vars.screenWidth*15) /100), mouseLoc.Y - (Vars.screenHeight*4)/100, (Vars.screenWidth * 25) / 100, (Vars.screenHeight * 65) / 100), Color.White);
                fontPos.X = (Vars.screenWidth * 4) / 6;
                fontPos.Y = (Vars.screenHeight / 20);
                spriteBatch.DrawString(fontPlay, "Score: " + score + "  Lives: " + lives + "  Level: " + level, fontPos, Color.Black);
            }
            //prevents score from being less than 0
            //happens if first three bugs hit the blanket
            //will be handled better in later milestones
            else if (screen == 2)
            {
                GraphicsDevice.Clear(Color.Black);
                if (score < 0)
                {
                    score = 0;
                }
                WriteScore();
                fontPos.X = (Vars.screenWidth * 32) / 100;
                fontPos.Y = (Vars.screenHeight * 35) / 100;
                spriteBatch.DrawString(gameOverFont, "Game Over", fontPos, Color.White);
                fontPos.X = (Vars.screenWidth * 43) / 100;
                fontPos.Y = (Vars.screenHeight * 66) / 100;
                spriteBatch.DrawString(fontPlay, "Your score: " + score, fontPos, Color.White);
                fontPos.X = (Vars.screenWidth * 42) / 100;
                fontPos.Y = (Vars.screenHeight * 70) / 100;
                spriteBatch.DrawString(fontPlay, "Score to beat: " + ReadScore(), fontPos, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
    //had issues with variable accessibility
    //solved by creating Vars class
    public static class Vars
    {
        public static int screenHeight { get; set; }
        public static int screenWidth { get; set; }
    }
}
