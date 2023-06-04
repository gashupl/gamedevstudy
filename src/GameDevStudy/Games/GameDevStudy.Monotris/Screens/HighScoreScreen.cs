using GameDevStudy.Monotris.Common;
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
            _scoresFont = content.Load<SpriteFont>(Names.Font.HighScoreFont);
            backgroundImage = content.Load<Texture2D>(Names.Image.GameScreenBackground);
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            GoToMainScreen(keyboardState);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            var fontColor = Color.Black; 

            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, new Vector2(0, 0), Color.White);
            if (_scoresFont != null)
            {
                spriteBatch.DrawString(_scoresFont, $"-- HIGH SCORE -- ", _highScoreTablePosition, fontColor);

                for(int i = 1; i <= 10; i++)
                {
                    spriteBatch.DrawString(_scoresFont, $"USER { i.ToString("00") } 000000", new Vector2(110, 120 + 20 * i), fontColor);
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
        }

        public void Cleanup()
        {
        }
    }
}
