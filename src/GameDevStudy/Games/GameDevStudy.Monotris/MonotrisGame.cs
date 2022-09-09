using GameDevStudy.Monotris.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace GameDevStudy.Monotris
{
    public class MonotrisGame : Game
    {
        private GraphicsDeviceManager graphics;
        private int gameResolutionWidth = 1280; //1920;
        private int gameResolutionHeigth = 800; //1080;

        private SpriteBatch? _spriteBatch;
        private Wall _wall;
        public Texture2D _wallRectangle;

        public MonotrisGame()
        {
            if (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width < gameResolutionWidth ||
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height < gameResolutionHeigth)
            {
                throw new Exception("Required resolution not supported");
            }

            graphics = new GraphicsDeviceManager(this);
            graphics.HardwareModeSwitch = false;

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = gameResolutionWidth;
            graphics.PreferredBackBufferHeight = gameResolutionHeigth;

#if !DEBUG
            graphics.ToggleFullScreen();
#endif
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _wall = new Wall();
            _wallRectangle = new Texture2D(GraphicsDevice, 1, 1);
            _wallRectangle.SetData(new[] { Color.Black });
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            _spriteBatch?.Dispose();
            _wallRectangle.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Handle input
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            base.Draw(gameTime);

            if(_spriteBatch != null)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(_wallRectangle, new Rectangle(0, 0, 500, 500),
                        Color.Black);
                _spriteBatch.End();
            }

        }
    }
}
