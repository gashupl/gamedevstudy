using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevStudy.Monotris.Screens
{
    internal class MainScreen : ScreenBase, IScreen
    {
        private enum SelectedMenuPosition
        {
            Start,
            HighScore
        }

        private Vector2 _titlePosition = new Vector2(0, 0);
        private Vector2 _gameStartPosition = new Vector2(0, 0);
        private Vector2 _creditsPosition = new Vector2(0, 0);
        private SelectedMenuPosition _selectedMenuPosition = SelectedMenuPosition.Start;

        private SpriteFont _titleFont;
        private SpriteFont _menuFont;
        private Song _backgroundMusic;

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
           //OnWindowSizeChanged();

            _titleFont = content.Load<SpriteFont>(FontNames.MainScreenBigFont);
            _menuFont = content.Load<SpriteFont>(FontNames.MainScreenSmallFont);

            _backgroundMusic = content.Load<Song>(SoundPaths.TitleScreenMusic);
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            var keyBoardState = Keyboard.GetState();
            if (keyBoardState.IsKeyDown(Keys.Down))
            {
                _selectedMenuPosition = SelectedMenuPosition.HighScore;
            }
            else if (keyBoardState.IsKeyDown(Keys.Up))
            {
                _selectedMenuPosition = SelectedMenuPosition.Start;
            }
            else if (keyBoardState.IsKeyDown(Keys.Enter))
            {
                if (_selectedMenuPosition == SelectedMenuPosition.HighScore)
                {
                    MonotrisGame.ScreenManager.SwitchScreen(Screen.HighScoreScreen);
                }
                else if (_selectedMenuPosition == SelectedMenuPosition.Start)
                {
                    MonotrisGame.ScreenManager.SwitchScreen(Screen.GameplayScreen);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();

            if (_titleFont != null)
            {
                spriteBatch.DrawString(_titleFont, $"-- Monotris -- ", _titlePosition, Color.Black);

                var startTextColor = _selectedMenuPosition == SelectedMenuPosition.Start ? Color.Yellow : Color.Black;
                var creditsTextColor = _selectedMenuPosition == SelectedMenuPosition.Start ? Color.Black : Color.Yellow;

                spriteBatch.DrawString(_menuFont, $"Start the game ", _gameStartPosition, startTextColor);
                spriteBatch.DrawString(_menuFont, $"High Score ", _creditsPosition, creditsTextColor);
            }
            else
            {
                throw new Exception("Cannot load main screen fonts");
            }

            spriteBatch.End();
        }

        public void OnStart()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(_backgroundMusic);
        }
        public void Cleanup()
        {
            MediaPlayer.Stop();
        }

        public void UnloadContent()
        {
            throw new NotImplementedException();
        }
    }
}
