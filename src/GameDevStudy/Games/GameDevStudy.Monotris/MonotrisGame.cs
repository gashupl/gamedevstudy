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
        private Well _well;
        private Score _score = new Score(); 

        private DateTime _lastUpdate = DateTime.Now; 
        private DateTime _lastMove = DateTime.Now;

        private ScoreText _scoreText; 
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

            _scoreText = new ScoreText(Content, new Vector2(gameResolutionWidth - 100, 0));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _well = new Well(GraphicsDevice);
            _well.OnLineRemoved += (point) => _score.Add(point); 
            
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            _spriteBatch?.Dispose();
            _well.Dispose(); 
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!_well.IsLineCompleted)
            {
                if ((DateTime.Now - _lastUpdate).TotalSeconds > 1)
                {
                    _well.MoveActiveShape(Direction.Down);
                    _lastUpdate = DateTime.Now;
                }

                if ((DateTime.Now - _lastMove).TotalSeconds > 0.2)
                {
                    var keyBoardState = Keyboard.GetState();
                    if (keyBoardState.IsKeyDown(Keys.Left))
                    {
                        _well.MoveActiveShape(Direction.Left);
                    }
                    else if (keyBoardState.IsKeyDown(Keys.Right))
                    {
                        _well.MoveActiveShape(Direction.Right);
                    }
                    else if (keyBoardState.IsKeyDown(Keys.Down))
                    {
                        _well.MoveActiveShape(Direction.Down);
                    }
                    _lastMove = DateTime.Now;
                }
            }
            else
            {
                if ((DateTime.Now - _lastMove).TotalSeconds > 0.2)
                {
                    _well.RemoveCompletedLines();
                    _lastMove = DateTime.Now;
                }
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            base.Draw(gameTime);

            if(_spriteBatch != null)
            {
                _spriteBatch.Begin();
                _well.Draw(_spriteBatch, gameTime);

                _scoreText.Draw(_score.Result, _spriteBatch, gameTime);

                _spriteBatch.End();
            }
            

        }
    }
}
