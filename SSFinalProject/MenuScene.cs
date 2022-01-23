using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace ShootTheBall
{
    public class MenuScene : GameScene
    {
        private Game1 parent;
        private string title;
        private List<string> menuItems;
        
        private SpriteFont regularFont;
        private SpriteFont hilightFont;
        private SpriteFont titleFont;

        private Vector2 pos;

        private int selectedItem;
        private KeyboardState oldstate;

        Texture2D Main_Background;


        public MenuScene(Game game,string title, List<string> menuItems, Texture2D background) : base(game)
        {
            parent = (Game1)game;
            this.menuItems = menuItems;
            this.title = title;
            this.Main_Background = background;
            
        }
        protected override void LoadContent()
        {
            regularFont = parent.Content.Load<SpriteFont>("Fonts/RegularFont");
            hilightFont = parent.Content.Load<SpriteFont>("Fonts/MenuTitle");
            titleFont = parent.Content.Load<SpriteFont>("Fonts/GameTitle");

           
            
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);
            Vector2 tpos = pos;
            parent.SpriteBatch.Begin();
            parent.SpriteBatch.Draw(Main_Background, new Rectangle(0, 0, 800, 480), Color.White);
            parent.SpriteBatch.DrawString(titleFont, title, tpos, Color.Red);
            tpos.Y += titleFont.LineSpacing + 10;
            tpos.X += 20;
            for (int i = 0; i < menuItems.Count; i++)
            {

                if (i == selectedItem)
                {
                    parent.SpriteBatch.DrawString(hilightFont, menuItems[i], tpos, Color.Green);
                    tpos.Y += hilightFont.LineSpacing + 10;
                }
                else
                {
                    parent.SpriteBatch.DrawString(regularFont, menuItems[i], tpos, Color.Blue);
                    tpos.Y += regularFont.LineSpacing + 10;
                }

                
            }
            parent.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            selectedItem = 2;
            pos = new Vector2(parent.stage.X / 10, parent.stage.Y / 4);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //Moving selected item index
            KeyboardState ks = Keyboard.GetState();
            if (oldstate.IsKeyUp(Keys.Down) && ks.IsKeyDown(Keys.Down))
            {
                selectedItem = MathHelper.Clamp(selectedItem + 1, 0, menuItems.Count - 1);

            }

            if (oldstate.IsKeyUp(Keys.Up) && ks.IsKeyDown(Keys.Up))
            {
                selectedItem = MathHelper.Clamp(selectedItem - 1, 0, menuItems.Count - 1);

            }

            //select the item 
            if (oldstate.IsKeyUp(Keys.Enter) && ks.IsKeyDown(Keys.Enter))
            {
                parent.Notify(this, menuItems[selectedItem]);
            }


            oldstate = ks;

            base.Update(gameTime);
        }

    }
}
