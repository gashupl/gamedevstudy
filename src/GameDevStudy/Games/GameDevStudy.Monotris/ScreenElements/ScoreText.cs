using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Domain.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.ScreenElements
{
    internal class ScoreText
    {
        private Vector2 _scorePosition = new Vector2(0, 0);
        private SpriteFont _scoreFont;

        internal ScoreText(ContentManager content)
        {
            //TODO: Setup font asset
            _scoreFont = content.Load<SpriteFont>(FontNames.HighScoreFont);
        }

        public void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            if (_scoreFont != null)
            {
                _spriteBatch.DrawString(_scoreFont, "0000", _scorePosition, Color.YellowGreen);
            }
        }

    }
}
