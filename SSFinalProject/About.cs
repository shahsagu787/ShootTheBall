using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace ShootTheBall
{
    public class About : GameScene
    {
        private Game1 parent;
        private SpriteFont titleFont;
        private SpriteFont regularFont;
        private Texture2D Background;
        public About(Game game, Texture2D texture) : base(game)
        {
            parent = (Game1)game;
            titleFont = parent.Content.Load<SpriteFont>("Fonts/GameTitle");
            regularFont = parent.Content.Load<SpriteFont>("Fonts/RegularFont");
           
            Background = texture;
        }

        public override void Draw(GameTime gameTime)
        {
            parent.SpriteBatch.Begin();
            parent.SpriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            parent.SpriteBatch.DrawString(titleFont, "Student Name : Sagar Shah", new Vector2(150, 100), Color.Yellow);
            parent.SpriteBatch.DrawString(titleFont, "Student Number : 8717655", new Vector2(150, 140), Color.Black);
            parent.SpriteBatch.DrawString(regularFont, "Press Esc for back", new Vector2(290, 400), Color.White);
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
               
                parent.Notify(this, "Pause");
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();
        }
    }
}
