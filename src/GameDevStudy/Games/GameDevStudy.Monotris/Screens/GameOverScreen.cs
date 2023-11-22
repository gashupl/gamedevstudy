using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Models;
using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevStudy.Monotris.Screens
{
    internal class GameOverScreen : ScreenBase, IScreen
    {
        private Vector2 _gameOverTextPosition = new Vector2(100, 100);
        private Vector2 _playerNameTextPosition = new Vector2(100, 150);
        private SpriteFont _bigFont;
        private SpriteFont _smallFont;
        private GameWindow _window;
        private string _playerName = String.Empty;
        private bool? _saveScore = false; 


        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content, GameWindow window)
        {
            this.graphicsDevice = graphicsDevice;
            _window = window; 
            _bigFont = content.Load<SpriteFont>(Names.Font.MainScreenBigFont);
            _smallFont = content.Load<SpriteFont>(Names.Font.MainScreenSmallFont);
            backgroundImage = content.Load<Texture2D>(Names.Image.GameScreenBackground);
            _saveScore = Global.HighScoreService?.ShouldScoreBeSaved(Global.CurrentScore); 
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            GoToMainScreen(keyboardState); 
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, new Vector2(0, 0), Color.White);
            if (_bigFont != null)
            {
                spriteBatch.DrawString(_bigFont, $"-- GAME OVER -- ", _gameOverTextPosition, Color.DarkGreen);
                if (_saveScore == true)
                {
                    spriteBatch.DrawString(_smallFont, $"-- ENTER YOUR NAME: {_playerName } -- ", _playerNameTextPosition, Color.DarkGreen);
                }
                else
                {
                    spriteBatch.DrawString(_smallFont, "-- PRESS ENTER TO QUIT --", _playerNameTextPosition, Color.DarkGreen);
                }

            }
            else
            {
                throw new Exception("Cannot load game over fonts");
            }

            spriteBatch.End();
        }

        public void OnStart()
        {
            _window.TextInput += TextInputHandler;
        }

        public void Cleanup()
        {
            _window.TextInput -= TextInputHandler;
        }

        private void TextInputHandler(object? sender, TextInputEventArgs args)
        {
            if (_saveScore == true)
            {
                if (_playerName.Length < 3)
                {
                    _playerName += args.Character;
                }
                else
                {
                    if (args.Key == Keys.Enter)
                    {
                        Global.CurrentScore.PlayerName = _playerName;
                        Global.HighScoreService.AddScore(Global.CurrentScore);
                        Global.HighScoreService.Save();             
                        Global.ScreenManager?.SwitchScreen(Screen.HighScoreScreen);
                    }
                }
            }
            else
            {
                if (args.Key == Keys.Enter)
                {
                    Global.ScreenManager?.SwitchScreen(Screen.MainScreen);
                }
            }

            Global.CurrentScore = new Score();

        }

    }
}
