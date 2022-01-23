using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.IO;


namespace ShootTheBall
{
    public class HighScore : GameScene
    {
        private Game1 parent;

        private SpriteFont titleFont;
        private SpriteFont regularFont;
        
        public static List<int> highScore = new List<int>();
        
        Texture2D Background;

        public HighScore(Game game, Texture2D texture) : base(game)
        {
            parent = (Game1)game;
            titleFont = parent.Content.Load<SpriteFont>("Fonts/MenuTitle");
            regularFont = parent.Content.Load<SpriteFont>("Fonts/RegularFont");
            Background = texture;
        }

        //Display the highscore
        public override void Draw(GameTime gameTime)
        {
            int x = 80;
            parent.SpriteBatch.Begin();
            parent.SpriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            parent.SpriteBatch.DrawString(titleFont, "High Scores " , new Vector2(310, 20), Color.YellowGreen);
            foreach (var item in highScore)
            {
                parent.SpriteBatch.DrawString(regularFont, item.ToString(), new Vector2(360, x), Color.Gold);
                x += 25;
            }
            parent.SpriteBatch.DrawString(regularFont, "Press Esc for back", new Vector2(290, 400), Color.White);
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }


        public override void Update(GameTime gameTime)
        {
            ReadFile();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {

                parent.Notify(this, "Pause");
            }
            base.Update(gameTime);
        }

        //save the current score to the file
        public static void SaveScore()
        {

            highScore.Clear();
            string line = "";
            if (File.Exists("Highscore.txt"))
            {
                
                using (StreamReader sr = new StreamReader(("Highscore.txt")))
                {
                    
                    while ((line = sr.ReadLine()) != null)
                    {
                        highScore.Add(int.Parse(line));
                    }
                    sr.Close();
                }

                highScore.Add(Score.CurrentScore);
                highScore.Sort();

                highScore.Reverse();

                using(StreamWriter sw = new StreamWriter(("Highscore.txt")))
                {
                    if (highScore.Count > 10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            sw.WriteLine(highScore[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < highScore.Count; i++)
                        {
                            sw.WriteLine(highScore[i]);
                        }
                    }

                    sw.Close();
                }
                
            }
            else
            {
                StreamWriter sw = File.CreateText("Highscore.txt");
                string str = Score.CurrentScore.ToString();
                sw.WriteLine(str);
                sw.Close();
            }
            
        }

        //read file to display high score
        void ReadFile()
        {
            string line = "";
            highScore.Clear();
            if (File.Exists("Highscore.txt"))
            {

                using (StreamReader sr = new StreamReader(("Highscore.txt")))
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        highScore.Add(int.Parse(line));
                    }
                    sr.Close();
                }


            }
        }
    }
}
