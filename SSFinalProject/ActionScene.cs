using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace ShootTheBall
{
    public class ActionScene : GameScene
    {
        private Game1 parent;

        private SoundEffect MissSound;
        private SoundEffect GunSound;
       
        private CollisionDetection cd;
        private Explosion explosion;
        private AimPointer aimPointer;
        private Ball ball;
        private Score score;
        private Chance chance;

        private bool gameOver = false;


        private Texture2D Expert_Background;

        public ActionScene(Game game, Texture2D texture) : base(game)
        {
            parent = (Game1)game;
            Expert_Background = texture;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void show()
        {
            if(gameOver)
            {
                gameOver = false;
                ball.Restart();
            }
            base.show();
        }

        public override void Update(GameTime gameTime)
        {



            if (ball.Enabled == false)
            {
                gameOver = true;
                Score.CurrentScore = 0;
                score.Enabled = false;
                parent.Notify(this, "GameOver");


            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                gameOver = false;
                parent.Notify(this, "Pause");
            }
            base.Update(gameTime);
        }

       

        Random random = new Random();
        protected override void LoadContent()
        {

            MissSound = parent.Content.Load<SoundEffect>("Music/MissSound");
            GunSound = parent.Content.Load<SoundEffect>("Music/GunSound");


            chance = new Chance(parent);

            Texture2D ballImage = parent.Content.Load<Texture2D>("Images/Ball");

            ball = new Ball(parent, ballImage, parent.stage, new Vector2((float)random.Next(-5, 5), (float)random.Next(-5, 5)), Expert_Background, chance);
            Components.Add(ball);

            Texture2D AimImage = parent.Content.Load<Texture2D>("Images/Aim");
            aimPointer = new AimPointer(parent, AimImage, parent.stage);
            Components.Add(aimPointer);

            Texture2D expImage = parent.Content.Load<Texture2D>("Images/explosion");
            explosion = new Explosion(parent, expImage, 5, 5);
            Components.Add(explosion);

            score = new Score(parent);
            Components.Add(score);

           
            Components.Add(chance);
            
            cd = new CollisionDetection(parent, aimPointer, ball, explosion, MissSound, GunSound);
            Components.Add(cd);
         
 
            base.LoadContent();
        }
    }
}
