using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Models;
using GameDevStudy.Monotris.ScreenElements;
using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevStudy.Monotris.Screens
{
    internal class GameplayScreen : ScreenBase, IScreen
    {
        private Well _well;
        private ScoreText _scoreText;

        private DateTime _lastUpdate = DateTime.Now;
        private DateTime _lastMove = DateTime.Now;

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content, GameWindow window)
        {
            Global.CurrentScore = new Score(); 
            _well = new Well(graphicsDevice);
            _well.OnLineRemoved += (point) => Global.CurrentScore.Add(point);
            _well.OnGameOver += () => Global.ScreenManager?.SwitchScreen(Screen.GameOverScreen);
            _scoreText = new ScoreText(content, new Vector2(MonotrisGame.GameResolutionWidth - 100, 0));
            backgroundImage = content.Load<Texture2D>(Names.Image.GameScreenBackground);
        }

        public void UnLoadContent()
        {
            _well.Dispose();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (spriteBatch != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(backgroundImage, new Vector2(0, 0), Color.White);
                _well.Draw(spriteBatch, gameTime);

                _scoreText.Draw(Global.CurrentScore.Result, spriteBatch, gameTime);

                spriteBatch.End();
            }
        }

        public void Update(GameTime gameTime)
        {
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

        public void OnStart()
        {
        }

        public void Cleanup()
        {
        }
    }
}
