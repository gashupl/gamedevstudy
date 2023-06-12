using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Domain.Services;

namespace GameDevStudy.Monotris
{
    public class MonotrisGame : Game
    {      
        internal static int GameResolutionWidth = 1280; //1920;
        internal static int GameResolutionHeigth = 800; //1080;

        private GraphicsDeviceManager graphics;
        private SpriteBatch? _spriteBatch;

        public MonotrisGame()
        {
            if (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width < GameResolutionWidth ||
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height < GameResolutionHeigth)
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
            graphics.PreferredBackBufferWidth = GameResolutionWidth;
            graphics.PreferredBackBufferHeight = GameResolutionHeigth;

#if !DEBUG
            graphics.ToggleFullScreen();
#endif
            graphics.ApplyChanges();

            base.Initialize();
       
            Global.ScreenManager?.CurrentScreen.Initialize(GraphicsDevice, Content, Window);           
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.ScreenManager = new ScreenManager(Screen.MainScreen, GraphicsDevice, Content, Window);
            Global.HighScoreService = new HighScoreService(new FileWrapper());
            Global.HighScoreService.Load(); 
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            _spriteBatch?.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Global.ScreenManager?.CurrentScreen.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            base.Draw(gameTime);

            Global.ScreenManager?.CurrentScreen.Draw(_spriteBatch, gameTime); 
 
        }
    }
}
