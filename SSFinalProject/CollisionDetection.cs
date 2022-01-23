using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootTheBall
{
    public class CollisionDetection : GameComponent
    {

        private Game1 parent;
        private AimPointer AP;
        private Ball ball;
       
        private Explosion exp;
        private SoundEffect missSound;
        private SoundEffect gunSound;

        MouseState oldmouseState;
        public CollisionDetection(Game game, AimPointer AP , Ball ball, Explosion exp, SoundEffect misssound, SoundEffect gunsound) : base(game)
        {
            parent = (Game1)game;
            this.ball = ball;
            this.AP = AP;
            this.exp = exp;
            missSound = misssound;
            gunSound = gunsound;
            
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            
            if(ball.Enabled)
            {
                if (ms.LeftButton == ButtonState.Pressed && oldmouseState.LeftButton == ButtonState.Released)
                {
                    Rectangle ballRect = ball.GetBound();
                    Rectangle AimRect = AP.GetBound();

                    //Checking the collision between ball and aim
                    if (AimRect.Intersects(ballRect))
                    {
                        gunSound.Play();
                        Score.CurrentScore += 1;
                        ball.Shooted();
                       
                        exp.StartAnimation(ballRect.Center.ToVector2());
                        
                       

                    }
                    else
                    {
                        Chance.RemainingBullets -= 1;
                        
                        missSound.Play();
                    }
                }

                oldmouseState = ms;
            }
            



            base.Update(gameTime);
        }

        
    }
}
