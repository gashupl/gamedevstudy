﻿using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameDevStudy.Monotris.Screens
{
    internal class MainScreen : ScreenBase, IScreen
    {
        private enum SelectedMenuPosition
        {
            Start,
            HighScore
        }

        private Vector2 _titlePosition = new Vector2(100, 100);
        private Vector2 _gameStartPosition = new Vector2(150, 200);
        private Vector2 _highScorePosition = new Vector2(150, 250);
        private SelectedMenuPosition _selectedMenuPosition = SelectedMenuPosition.Start;
        private bool _enterPressed = false; 


        private SpriteFont _titleFont;
        private SpriteFont _menuFont;
        private Song _backgroundMusic;

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
           //OnWindowSizeChanged();

            _titleFont = content.Load<SpriteFont>(Names.Font.MainScreenBigFont);
            _menuFont = content.Load<SpriteFont>(Names.Font.MainScreenSmallFont);

            backgroundImage = content.Load<Texture2D>(Names.Image.MainScreenBackground); 
            _backgroundMusic = content.Load<Song>(SoundPaths.TitleScreenMusic);
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _selectedMenuPosition = SelectedMenuPosition.HighScore;
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                _selectedMenuPosition = SelectedMenuPosition.Start;
            }
            else if (keyboardState.IsKeyDown(Keys.Enter))
            {
                _enterPressed = true;
            }
            else if (_enterPressed && keyboardState.IsKeyUp(Keys.Enter))
            {
                _enterPressed = false;
                if (_selectedMenuPosition == SelectedMenuPosition.HighScore)
                {
                    Global.ScreenManager?.SwitchScreen(Screen.HighScoreScreen);
                }
                else if (_selectedMenuPosition == SelectedMenuPosition.Start)
                {
                    Global.ScreenManager?.SwitchScreen(Screen.GameplayScreen);
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();

            if (_titleFont != null)
            {
                spriteBatch.Draw(backgroundImage, new Vector2(0,0), Color.White);
                spriteBatch.DrawString(_titleFont, $"-- Monotris -- ", _titlePosition, Color.DarkGreen);

                var startTextColor = _selectedMenuPosition == SelectedMenuPosition.Start ? Color.Yellow : Color.Black;
                var creditsTextColor = _selectedMenuPosition == SelectedMenuPosition.Start ? Color.DarkGreen : Color.Yellow;

                spriteBatch.DrawString(_menuFont, $"Start the game ", _gameStartPosition, startTextColor);
                spriteBatch.DrawString(_menuFont, $"High Score ", _highScorePosition, creditsTextColor);
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
    }
}
