using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace GameDevStudy.Monotris.Screens
{
    internal class HighScoreScreen : ScreenBase, IScreen
    {
        private Vector2 _highScoreTablePosition = new Vector2(100, 100);
        private SpriteFont _scoresFont;
        private string _savedScoresText; 

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content, GameWindow window)
        {
            this.graphicsDevice = graphicsDevice;
            _scoresFont = content.Load<SpriteFont>(Names.Font.HighScoreFont);
            backgroundImage = content.Load<Texture2D>(Names.Image.GameScreenBackground);
            var _highScore = Global.HighScoreService?.HighScore; 
            if (_highScore != null)
            {
                var resultsBuilder = new StringBuilder();
                foreach (var score in _highScore)
                {
                    resultsBuilder.AppendLine($"{score.PlayerName} : {score.Result.ToString("000000")}");
                }
                _savedScoresText = resultsBuilder.ToString(); 
            }
            
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


                spriteBatch.DrawString(_scoresFont, _savedScoresText, new Vector2(140, 140), fontColor);

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
