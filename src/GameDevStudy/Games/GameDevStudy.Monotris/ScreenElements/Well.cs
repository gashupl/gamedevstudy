using GameDevStudy.Monotris.Models;
using GameDevStudy.Monotris.Domain.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.ScreenElements
{
    internal class Well : IDisposable
    {
        private const int _wellBlockSize = 35;
        private const int _xBlocksCount = 10;
        private const int _yBlocksCount = 20;
        private readonly Color _wellColor = Color.Black;
        private readonly Color _blockColor = Color.Green; 

        private Texture2D _wellRectangle;
        private Texture2D _blockRectangle;
        private bool[,] _matrix;
        private Point _leftTopCornerLocation = new Point(20, 50);

        private int _activeBlockX;
        private int _activeBlockY;

        private WellCalculationService _wellCalculator;

        internal Action<int>? OnLineRemoved { get; set; }
        internal Action? OnGameOver { get; set; }

        internal Well(GraphicsDevice graphicsDevice)
        {
            SetInitialActiveBlockCoordinates(); 
            
            _wellCalculator = new WellCalculationService(_xBlocksCount, _yBlocksCount);
            _matrix = new bool[_xBlocksCount, _yBlocksCount];
            
            _wellRectangle = new Texture2D(graphicsDevice, 1, 1);
            _wellRectangle.SetData(new[] { _wellColor });

            _blockRectangle = new Texture2D(graphicsDevice, 1, 1);
            _blockRectangle.SetData(new[] { _blockColor });

            //TODO: This is only for testing purposes
            //Set initial state of matrix not to waste time for filling empty space
            //for (int i = 1; i < 10; i++)
            //{
            //    _matrix[i, 19] = true;
            //}

        }

        public bool IsLineCompleted
        {
            get => _wellCalculator.IsLineCompleted(_matrix).IsLineCompleted;        
        }

        //Checked
        public void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            _matrix[_activeBlockX, _activeBlockY] = true; //TODO: Let's assume for now it is active shape      
            DrawWell(_spriteBatch); 
        }

        //Checked
        public void MoveActiveShape(Direction? direction = null)
        {
            if(direction == Direction.Down)
            {
                if (_wellCalculator.IsNextDownMoveAllowed(_matrix, _activeBlockX, _activeBlockY))
                {
                    _wellCalculator.ClearCurrentActiveBlock(ref _matrix, _activeBlockX, _activeBlockY);
                    _activeBlockY += 1;
                }
                else
                {
                    _matrix[_activeBlockX, _activeBlockY] = true;
                    SetInitialActiveBlockCoordinates(); 
                }          
            }
            else if(direction == Direction.Left && _activeBlockX > 0)
            {
                _wellCalculator.ClearCurrentActiveBlock(ref _matrix, _activeBlockX, _activeBlockY); 
                _activeBlockX -= 1;
            }
            else if(direction == Direction.Right && _activeBlockX < _xBlocksCount - 1)
            {
                _wellCalculator.ClearCurrentActiveBlock(ref _matrix, _activeBlockX, _activeBlockY);
                _activeBlockX += 1; 
            }
        }

        public void RemoveCompletedLines()
        {
            var completedLines = _wellCalculator.IsLineCompleted(_matrix)
                .CompletedLinesYCoordinates;

            _wellCalculator.RemoveCompletedLines(ref _matrix, completedLines);

            OnLineRemoved?.Invoke(1); 

            SetInitialActiveBlockCoordinates(); 
        }

        public void Dispose()
        {
            _wellRectangle.Dispose();
        }

        private void SetInitialActiveBlockCoordinates()
        {
            if(_matrix != null && _matrix[4,0] == true)
            {
                OnGameOver?.Invoke();
            }
            _activeBlockX = 4;
            _activeBlockY = 0;
        }

        //Checked
        private void DrawWell(SpriteBatch spriteBatch)
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

        //Checked
        private void DrawBlock(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(_blockRectangle,
                new Rectangle(
                    _leftTopCornerLocation.X + x * _wellBlockSize,
                    _leftTopCornerLocation.Y + y * _wellBlockSize,
                    _wellBlockSize,
                    _wellBlockSize),
                _blockColor);
        }

        //Checked
        private void DrawEmptyBlockSpace(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(_wellRectangle,
                new Rectangle(
                    _leftTopCornerLocation.X + x * _wellBlockSize,
                    _leftTopCornerLocation.Y + y * _wellBlockSize,
                    _wellBlockSize,
                    _wellBlockSize),
                _wellColor);
        }

    }
}
