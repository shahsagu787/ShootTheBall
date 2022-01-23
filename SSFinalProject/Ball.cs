using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;



namespace ShootTheBall
{
    public class Ball : DrawableGameComponent
    {
        private Game1 parent;
        private Chance chance;

        private Texture2D ballImage;
        private Texture2D Background;

        private Vector2 stage;
        private Vector2 pos;
        private Vector2 speed;
    
        private SpriteFont titleFont;


        private bool gameOver = false;
        int flag = 0;
       
        public Ball(Game game, Texture2D image, Vector2 stage, Vector2 speed, Texture2D Background, Chance chance) : base(game)
        {
            parent = (Game1)game;
            ballImage = image;
            this.stage = stage;
            this.speed = speed;
            pos = new Vector2(stage.X / 2 - ballImage.Width / 2, stage.Y / 2 - ballImage.Height / 2);
            
            this.Background = Background;
            titleFont = parent.Content.Load<SpriteFont>("Fonts/GameName");
            this.chance = chance;

        }

        public override void Draw(GameTime gameTime)
        {
           
            parent.SpriteBatch.Begin();
            parent.SpriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            if (Chance.RemainingBullets > 0)
            {


                if (gameOver)
                {
                    parent.SpriteBatch.DrawString(titleFont, "Game Over ", new Vector2(330, 200), Color.GreenYellow);
                    parent.SpriteBatch.DrawString(titleFont, "Press Space to go to main menu", new Vector2(250, 400), Color.Lavender);
                }
                else
                {
                    parent.SpriteBatch.Draw(
                    ballImage, //Image to show
                    pos, //Position,
                    Color.White //Fill color
                    );
                }

            }
            else
            {
                parent.SpriteBatch.DrawString(titleFont, "Game Over You Don't Have Any More Bullets ", new Vector2(190, 200), Color.GreenYellow);
                parent.SpriteBatch.DrawString(titleFont, "Press Space to go to main menu", new Vector2(250, 400), Color.Lavender);
            }
           
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (Chance.RemainingBullets > 0)
            {
                //Checking Game id over or not
                if (!gameOver)
                {
                    pos += speed; // pos.x += speed.x ; pos.y += speed.y;

                    //right wall
                    if (pos.X + ballImage.Width >= stage.X)
                    {
                        BounceRight();

                    }
                    //left wall
                    if (pos.X <= 0)
                    {
                        BounceLeft();

                    }
                    //Top wall
                    if (pos.Y <= 0)
                    {
                        BounceTop();
                    }
                    //bottom wall
                    if (pos.Y + ballImage.Height >= stage.Y)
                    {

                        if (flag == 1)
                        {


                            
                            gameOver = true;


                        }
                        else
                        {

                            BounceBottom();
                            flag = 1;

                        }

                    }
                }
                else
                {
                    if (ks.IsKeyDown(Keys.Space))
                    {
                        this.Enabled = false;
                        this.Visible = false;
                        Chance.RemainingBullets = 3;

                        HighScore.SaveScore();
                    }
                    chance.Enabled = false;
                    chance.Visible = false;
                }
                
            }
            else
            {
                

                if (ks.IsKeyDown(Keys.Space))
                {
                    this.Enabled = false;
                    this.Visible = false;
                    Chance.RemainingBullets = 3;
              
                    HighScore.SaveScore();
                }
                chance.Enabled = false;
                chance.Visible = false;
            }
            
           

            

            base.Update(gameTime);
        }

        private void BounceTop()
        {
            speed.Y = Math.Abs(speed.Y);
           
        }

        private void BounceBottom()
        {
            speed.Y = -Math.Abs(speed.Y);
          
        }

        //Method to restart the ball when it is shooted
        public void Shooted()
        {
            Random random = new Random();
            pos = new Vector2(stage.X / 2 - ballImage.Width / 2, stage.Y / 2 - ballImage.Height / 2);
            speed = new Vector2((float)random.Next(-7, 7), (float)random.Next(-8, 8));
            if(speed.Y == 0)
            {
                speed.Y += 1;
            }
            this.Enabled = true;
            this.Visible = true;
            flag = 0;
        }
        private void BounceLeft()
        {
            speed.X = Math.Abs(speed.X);
          
        }

        private void BounceRight()
        {
            speed.X = -Math.Abs(speed.X);
         
        }

        protected override void LoadContent()
        {
           
            base.LoadContent();
        }

        public Rectangle GetBound()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, ballImage.Width, ballImage.Height);
        }


      
        //Method to restart the game
        public void Restart()
        {
            Random random = new Random();
            pos = new Vector2(stage.X / 2 - ballImage.Width / 2, stage.Y / 2 - ballImage.Height / 2);
            speed = new Vector2((float)random.Next(-8, 8), (float)random.Next(-8, 8));
            if (speed.Y == 0)
            {
                speed.Y += 1;
            }
            this.Enabled = true;
            this.Visible = true;
            flag = 0;
            gameOver = false;
        }
    }
}
