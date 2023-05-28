﻿using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevStudy.Monotris.Screens
{
    internal class HighScoreScreen : ScreenBase, IScreen
    {
        private Vector2 _highScoreTablePosition = new Vector2(100, 100);
        private SpriteFont _scoresFont;

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
            _scoresFont = content.Load<SpriteFont>(FontNames.HighScoreFont);
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            GoToMainScreen(keyboardState);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();

            if (_scoresFont != null)
            {
                spriteBatch.DrawString(_scoresFont, $"-- HIGH SCORE -- ", _highScoreTablePosition, Color.DarkGreen);

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
