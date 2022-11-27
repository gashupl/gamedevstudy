using GameDevStudy.Monotris.Models;
using GameDevStudy.Monotris.ScreenElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameDevStudy.Monotris
{
    public class MonotrisGame : Game
    {
        private GraphicsDeviceManager graphics;
        private int gameResolutionWidth = 1280; //1920;
        private int gameResolutionHeigth = 800; //1080;

        private SpriteBatch? _spriteBatch;
        private Wall _wall;
        private DateTime _lastUpdate = DateTime.Now; 
        private DateTime _lastMove = DateTime.Now;

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
            _wall = new Wall(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            _spriteBatch?.Dispose();
            _wall.Dispose(); 
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if((DateTime.Now - _lastUpdate).TotalSeconds > 1)
            {
                _wall.MoveActiveShape(Direction.Down);
                _lastUpdate = DateTime.Now;
            }

            if((DateTime.Now - _lastMove).TotalSeconds > 0.2)
            {
                var keyBoardState = Keyboard.GetState();
                if (keyBoardState.IsKeyDown(Keys.Left))
                {
                    _wall.MoveActiveShape(Direction.Left);
                }
                else if (keyBoardState.IsKeyDown(Keys.Right))
                {
                    _wall.MoveActiveShape(Direction.Right);
                }
                else if (keyBoardState.IsKeyDown(Keys.Down))
                {
                    _wall.MoveActiveShape(Direction.Down);
                }
                _lastMove = DateTime.Now;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            base.Draw(gameTime);

            if(_spriteBatch != null)
            {
                _spriteBatch.Begin();
                _wall.Draw(_spriteBatch, gameTime); 
                _spriteBatch.End();
            }

        }
    }
}
