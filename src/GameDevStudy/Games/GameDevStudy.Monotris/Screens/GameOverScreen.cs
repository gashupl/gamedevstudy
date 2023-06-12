﻿using GameDevStudy.Monotris.Common;
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
        private SpriteFont _gameOverFont;
        

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content, GameWindow window)
        {
            this.graphicsDevice = graphicsDevice;
            _gameOverFont = content.Load<SpriteFont>(Names.Font.MainScreenBigFont);
            backgroundImage = content.Load<Texture2D>(Names.Image.GameScreenBackground);
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
            if (_gameOverFont != null)
            {
                spriteBatch.DrawString(_gameOverFont, $"-- GAME OVER -- ", _gameOverTextPosition, Color.DarkGreen);

            }
            else
            {
                throw new Exception("Cannot load game over fonts");
            }

            spriteBatch.End();
        }

        public void OnStart()
        {
        }

        public void Cleanup()
        {
        }

    }
}
