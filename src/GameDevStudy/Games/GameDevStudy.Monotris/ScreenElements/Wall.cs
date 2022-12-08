using GameDevStudy.Monotris.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.ScreenElements
{
    //TODO: This class is too big to be called "model". Should be splitted into smaller ones
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

        private int _activeBlockX;
        private int _activeBlockY;  

        internal Wall(GraphicsDevice graphicsDevice)
        {
            SetInitialActiveBlockCoordinates(); 

            _matrix = new bool[_xBlocksCount, _yBlocksCount];
            
            _wallRectangle = new Texture2D(graphicsDevice, 1, 1);
            _wallRectangle.SetData(new[] { _wallColor });

            _blockRectangle = new Texture2D(graphicsDevice, 1, 1);
            _blockRectangle.SetData(new[] { _blockColor });
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            _matrix[_activeBlockX, _activeBlockY] = true; //TODO: Let's assume for now it is active shape
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

        public void MoveActiveShape(Direction? direction = null)
        {
            if(direction == Direction.Down)
            {
                if (IsNextDownMoveAllowed())
                {
                    ClearCurrentActiveBlock();
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
                ClearCurrentActiveBlock(); 
                _activeBlockX -= 1;
            }
            else if(direction == Direction.Right && _activeBlockX < _xBlocksCount - 1)
            {
                ClearCurrentActiveBlock();
                _activeBlockX += 1; 
            }
        }

        //TODO: Change into property
        public bool IsLineCompleted()
        {
            return Wall.IsLineCompleted(_matrix, _xBlocksCount, _yBlocksCount).IsLineCompleted; 
        }


        //TODO: Static public method called only internally (this design should be changed)
        public static IsLineCompletedDto IsLineCompleted(bool[,] wallMatrix, int xBlocksCount, int yBlocksCount)
        {
            var completedLines = new List<int>(); 
            for(int y = 0; y < yBlocksCount; y++)
            {
                var isCompleted = true; 
                for(int x = 0; x < xBlocksCount; x++)
                {
                    if(wallMatrix[x,y] == false)
                    {
                        isCompleted = false;
                        break; 
                    }
                }
                if (isCompleted)
                {
                    completedLines.Add(y);
                }
            }

            return new IsLineCompletedDto()
            {
                IsLineCompleted = (completedLines.Count > 0),
                CompletedLinesYCoordinates = completedLines

            }; 
        }

        //TODO: To be tested
        public void RemoveCompletedLines()
        {
            var completedLines = Wall.IsLineCompleted(_matrix, _xBlocksCount, _yBlocksCount)
                .CompletedLinesYCoordinates;

            //Checking completed lines from top to the bottm 
            for (int y = _yBlocksCount - 1; y == 0; y--)
            {
                if (completedLines.Contains(y))
                {
                    //Clean current line 
                    for (int x = 0; x < _xBlocksCount; x++)
                    {
                        _matrix[x, y] = false; 
                    }

                    //Move all the line from top till removed line 1 down
                    for (int _y = _yBlocksCount - 1; _y == y; _y--)
                    {
                        for (int x = 0; x < _xBlocksCount; x++)
                        {
                            _matrix[x, y] = _matrix[x, y + 1];
                            _matrix[x, y + 1] = false; 
                        }
                    }
                }
            }
        }

        public void LowerActiveShape()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _wallRectangle.Dispose();
        }

        private void SetInitialActiveBlockCoordinates()
        {
            _activeBlockX = 4;
            _activeBlockY = 0;
        }

        private void ClearCurrentActiveBlock()
        {
            _matrix[_activeBlockX, _activeBlockY] = false;
        }

        private bool IsNextDownMoveAllowed()
        {
            return _activeBlockY < _yBlocksCount - 1 && !_matrix[_activeBlockX, _activeBlockY + 1]; 
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

    }
}
