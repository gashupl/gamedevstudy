using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pg.MonoGame.Learn.ScreensNavigation.Screens;

namespace Pg.MonoGame.Learn.ScreensNavigation
{
    public class MyGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager _screenManager;

        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
          
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var defaultFont = Content.Load<SpriteFont>("MyFont");
            _screenManager = new ScreenManager(_graphics, _spriteBatch, defaultFont);

            
        }

        protected override void Update(GameTime gameTime)
        {
            _screenManager.CurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);

            //TODO: Verify why text is not being drawn on the screen when code is called from current screen?
            _screenManager.CurrentScreen.Draw(gameTime);
        }
    }
}
