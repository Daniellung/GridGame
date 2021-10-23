using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GridGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World world;
        private StartMenu startMenu;
        private GameState gameState;
        private ScreenSettings screenSettings;
        public static Game1 ThisGame;


        public enum GameState
        {
            StartMenu,
            Map
        }


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ThisGame = this;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();


            // TODO: Add your initialization logic here

            screenSettings = new ScreenSettings(1920, 1080, false);
            gameState = GameState.StartMenu;

            base.Initialize();
        }

        public GameState getGamestate()
        {
            return gameState;
        }
        
        public void setGamestate(GameState gameState)
        {
            this.gameState = gameState;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            startMenu = new StartMenu(Content);
            world = new World(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            switch (gameState)
            {
                case GameState.StartMenu:
                    startMenu.Update(kstate);
                    break;
                case GameState.Map:
                    world.Update(kstate);
                    break;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.StartMenu:
                    startMenu.Draw(_spriteBatch, gameTime);
                    break;
                case GameState.Map:
                    world.Draw(_spriteBatch, gameTime);
                    break;
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
