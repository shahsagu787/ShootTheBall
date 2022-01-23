using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace ShootTheBall
{
    public class Chance : DrawableGameComponent
    {
        private Game1 parent;
        public static int RemainingBullets = 3;
        private SpriteFont titleFont;
        public Chance(Game game) : base(game)
        {
            parent = (Game1)game;
            titleFont = parent.Content.Load<SpriteFont>("Fonts/MenuTitle");
        }

        //Display the remaining missing shots
        public override void Draw(GameTime gameTime)
        {
            parent.SpriteBatch.Begin();
            parent.SpriteBatch.DrawString(titleFont, "Remaining Chance : ", new Vector2(20, 20), Color.GreenYellow);
            parent.SpriteBatch.DrawString(titleFont, RemainingBullets.ToString(), new Vector2(250, 20), Color.Lavender);
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    
    }
}
