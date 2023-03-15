using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Domain.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.ScreenElements
{
    internal class ScoreText
    {
        private Vector2 _scorePosition;
        private SpriteFont _scoreFont;
        private const int _digitsNumber = 6; 

        internal ScoreText(ContentManager content, Vector2 position)
        {
            _scoreFont = content.Load<SpriteFont>(FontNames.HighScoreFont);
            _scorePosition = position;
        }

        public void Draw(int result, SpriteBatch _spriteBatch, GameTime gameTime)
        {
            if (_scoreFont != null)
            {
                _spriteBatch.DrawString(_scoreFont, result.ToString().PadLeft(_digitsNumber, '0'), _scorePosition, Color.Black);
            }
        }

    }
}
