using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace ShootTheBall
{
    public class Help : GameScene
    {
        private Game1 parent;
        private SpriteFont titleFont;
        private SpriteFont regularFont;
        private Texture2D Background;
        private Texture2D BallImage;
        private Texture2D AimImage;

        public Help(Game game, Texture2D texture) : base(game)
        {
            parent = (Game1)game;
            titleFont = parent.Content.Load<SpriteFont>("Fonts/MenuTitle");
            regularFont = parent.Content.Load<SpriteFont>("Fonts/RegularFont");
            Background = texture;
            BallImage = parent.Content.Load<Texture2D>("Images/Ball");
            AimImage = parent.Content.Load<Texture2D>("Images/Aim"); ;

        }

        //Display the instructions for game
        public override void Draw(GameTime gameTime)
        {
            parent.SpriteBatch.Begin();
            parent.SpriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            parent.SpriteBatch.DrawString(titleFont, "HELP", new Vector2(350, 40), Color.Black);
            parent.SpriteBatch.Draw(BallImage, new Rectangle(40, 100, 40, 40), Color.White);
            parent.SpriteBatch.DrawString(regularFont, "Shoot the Ball by clicking on it \nBefore Ball hit the down wall 2nd Time", new Vector2(100, 100), Color.Yellow);

            parent.SpriteBatch.Draw(AimImage, new Rectangle(40, 200, 40, 40), Color.White);
            parent.SpriteBatch.DrawString(regularFont, "Player needs to place pointer on ball and pressed left click", new Vector2(100, 200), Color.Yellow);

            parent.SpriteBatch.DrawString(regularFont, "Everytime when player shoot the ball properly\nScore will be increas by 1 point", new Vector2(100, 250), Color.Yellow);
            parent.SpriteBatch.DrawString(regularFont, "Player can miss 3 bullets maximum \nAt 3rd missed bullet game will over", new Vector2(100, 320), Color.Yellow);

            parent.SpriteBatch.DrawString(regularFont, "Press Esc for back", new Vector2(290, 400), Color.Red);
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {

                parent.Notify(this, "Pause");
            }
            base.Update(gameTime);
        }
    }
}
