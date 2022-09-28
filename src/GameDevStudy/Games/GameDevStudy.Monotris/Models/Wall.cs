﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Models
{
    //TODO: Split calculation and drawing logic into separate classes
    internal class Wall : ScreenElement, IDisposable
    {
        private const int _wallBlockSize = 35;
        private const int _xBlocksCount = 10;
        private const int _yBlocksCount = 20;
        private readonly Color _wallColor = Color.Black;
        private readonly Color _blockColor = Color.Green; 

        private Texture2D _wallRectangle;
        private Texture2D _blockRectangle;
        private bool[,] _matrix;
        private Point _leftTopCornerLocation = new Point(20, 50);

        internal Wall(GraphicsDevice graphicsDevice)
        {
            _matrix = new bool[_xBlocksCount, _yBlocksCount];
            
            _wallRectangle = new Texture2D(graphicsDevice, 1, 1);
            _wallRectangle.SetData(new[] { _wallColor });

            _blockRectangle = new Texture2D(graphicsDevice, 1, 1);
            _blockRectangle.SetData(new[] { _blockColor });
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            _matrix[0, 0] = true;
            _matrix[9, 19] = true;
            DrawWall(_spriteBatch); 
        }

        public void AddShape(Shape shape)
        {
            throw new NotImplementedException();
        }

        public void RotateActiveShape(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void MoveActiveShape(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void LowerActiveShape()
        {
            throw new NotImplementedException();
        }

        private void RemoveLines(int[] linesNumbers)
        {

        }
        private void DrawWall(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < _matrix.GetLength(0); x++)
            {
                for (int y = 0; y < _matrix.GetLength(1); y++)
                {
                    if (_matrix[x, y] == true)
                    {
                        DrawBlock(spriteBatch, x, y); 
                    }
                    else
                    {
                        DrawEmptyBlockSpace(spriteBatch, x, y);
                    }
                }
            }

        }

        private void DrawBlock(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(_blockRectangle,
                new Rectangle(
                    _leftTopCornerLocation.X + x * _wallBlockSize,
                    _leftTopCornerLocation.Y + y * _wallBlockSize,
                    _wallBlockSize,
                    _wallBlockSize),
                _blockColor);
        }

        private void DrawEmptyBlockSpace(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(_wallRectangle,
                new Rectangle(
                    _leftTopCornerLocation.X + x * _wallBlockSize,
                    _leftTopCornerLocation.Y + y * _wallBlockSize,
                    _wallBlockSize,
                    _wallBlockSize),
                _wallColor);
        }
        private void AddBlock(int x, int y)
        {
            _matrix[x, y] = true;
        }

        private void RemoveBlock(int x, int y)
        {
            _matrix[x, y] = false;
        }

        public void Dispose()
        {
            _wallRectangle.Dispose();
        }
    }
}
