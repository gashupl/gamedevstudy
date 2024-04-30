using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pg.MonoGame.Learn.ScreensNavigation.Screens;
using System.Drawing;

namespace Pg.MonoGame.Learn.ScreensNavigation
{
    public class MyGame : Game
    {
        public SpriteBatch spriteBatch;
        public SpriteFont defaultFont;
        public GraphicsDeviceManager graphics;
        
        private ScreenManager _screenManager;

        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _screenManager = new ScreenManager(this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            defaultFont = Content.Load<SpriteFont>("MyFont");        
        }

        protected override void Update(GameTime gameTime)
        {
            _screenManager.CurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //graphics.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

            base.Draw(gameTime);
        }
    }
}
