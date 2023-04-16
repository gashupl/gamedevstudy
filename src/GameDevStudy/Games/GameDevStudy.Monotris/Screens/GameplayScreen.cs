﻿using GameDevStudy.Monotris.Models;
using GameDevStudy.Monotris.ScreenElements;
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
    internal class GameplayScreen : ScreenBase, IScreen
    {
        private Well _well;
        private Score _score = new Score();
        private ScoreText _scoreText;

        private DateTime _lastUpdate = DateTime.Now;
        private DateTime _lastMove = DateTime.Now;

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _scoreText = new ScoreText(content, new Vector2(MonotrisGame.GameResolutionWidth - 100, 0));
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            _well = new Well(graphicsDevice);
            _well.OnLineRemoved += (point) => _score.Add(point);
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
                _well.Draw(spriteBatch, gameTime);

                _scoreText.Draw(_score.Result, spriteBatch, gameTime);

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

        public void UnloadContent()
        {
        }

        public void OnStart()
        {
        }

        public void Cleanup()
        {
        }
    }
}