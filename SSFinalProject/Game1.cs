/*
 * Project : SSFinalProject
 * Purpose : To Submit Final Project
 * Revision History : Created by Sagar Shah on December 2021
 * 
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ShootTheBall
{

   
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SpriteBatch SpriteBatch { get => _spriteBatch; }
        public GraphicsDeviceManager Graphics { get => _graphics; }

        private Texture2D Beginner_Background;
        private Texture2D Intermediate_Background;
        private Texture2D Expert_Background;
        private Texture2D Main_Background;
        private Texture2D Other_Background;

        
        public Vector2 stage;
        
        private List<string> menuItem = new List<string>
        {
            "Start Game","Help","High Score",
            "About us", "Exit"
        };
        private MenuScene menuScene;

        private ActionScene actionScene;

        private GameScene currentScene;

        private About about;

        private Help help;

        private HighScore hScore;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Beginner_Background = Content.Load<Texture2D>("Images/Beginner_Background");
            Intermediate_Background = Content.Load<Texture2D>("Images/Intermediate_Background");
            Expert_Background = Content.Load<Texture2D>("Images/Expert_Background");
            Main_Background = Content.Load<Texture2D>("Images/Main_Background");
            Other_Background = Content.Load<Texture2D>("Images/Other_Background");


            stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            menuScene = new MenuScene(this, "Shoot The Ball", menuItem, Main_Background);
            Components.Add(menuScene);

            actionScene = new ActionScene(this, Expert_Background);
            Components.Add(actionScene);

            about = new About(this, Other_Background);
            Components.Add(about);

            help = new Help(this, Beginner_Background);
            Components.Add(help);

            hScore = new HighScore(this, Intermediate_Background);
            Components.Add(hScore);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            currentScene = menuScene;
            currentScene.show();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
         
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
             // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.End();
            base.Draw(gameTime);
        }


        //set the Scene according the sender and menu
        public void Notify(GameScene sender, string action)
        {

            currentScene.hide();
            if (sender is MenuScene)
            {
                switch (action)
                {


                    case "Start Game":
                        currentScene = actionScene;
                        break;
                    case "Help":
                        currentScene = help;
                        break;
                    case "High Score":
                        currentScene = hScore;
                        break;
                    case "About us":
                        currentScene = about;
                        break;
                    case "Exit":
                        Exit();
                        break;
                }

            }
            else if (sender is ActionScene)
            {
                currentScene = menuScene;
            }
            else if(sender is About)
            {
                currentScene = menuScene;
            }
            else if(sender is Help)
            {
                currentScene = menuScene;
            }
            else if (sender is HighScore)
            {
                currentScene = menuScene;
            }
            currentScene.show();
        }
    }
}
