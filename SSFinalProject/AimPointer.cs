using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ShootTheBall
{
    public class AimPointer : DrawableGameComponent
    {
        private Game1 parent;
        private Texture2D AimImage;
        private Vector2 stage;


        private Vector2 pos;
       
        public AimPointer(Game game, Texture2D image, Vector2 stage) : base(game)
        {
            parent = (Game1)game;
            AimImage = image;
            this.stage = stage;
            pos = new Vector2(stage.X / 2 - AimImage.Width / 2, stage.Y - AimImage.Height);

           
        }

        //Display the aim
        public override void Draw(GameTime gameTime)
        {
            parent.SpriteBatch.Begin();

            parent.SpriteBatch.Draw(AimImage, pos, new Rectangle(0, 0, AimImage.Width, AimImage.Height), Color.DimGray, 0f, new Vector2(AimImage.Width / 2, AimImage.Height / 2), 1f, SpriteEffects.None, 0f);
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        //Update the position of Aim
        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            pos.X = ms.Position.X;
            pos.Y = ms.Position.Y;



            pos.X = MathHelper.Clamp(pos.X, 0, stage.X - AimImage.Width);

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public Rectangle GetBound()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, AimImage.Width, AimImage.Height);
        }
    }
}
