using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace ShootTheBall
{
    public class Score : DrawableGameComponent
    {
        private Game1 parent;

        private SpriteFont titleFont;
        public static int CurrentScore = 0;
        public Score(Game game) : base(game)
        {
            parent = (Game1)game;
            titleFont = parent.Content.Load<SpriteFont>("Fonts/MenuTitle");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        //Display the current score
        public override void Draw(GameTime gameTime)
        {
            parent.SpriteBatch.Begin();
            parent.SpriteBatch.DrawString(titleFont, "Score : " + CurrentScore, new Vector2(650, 20), Color.Red);
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
