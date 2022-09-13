using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Models
{
    //TODO: Split calculation and drawing logic into separate classes
    internal class Wall : ScreenElement, IDisposable
    {
        private bool[,] _matrix;
        private Point _leftTopCornerLocation = new Point(20, 50);
        private int _wallBlockSize = 35;
        private int _xBlocksCount = 10; 
        private int _yBlocksCount = 20;
        private Texture2D _wallRectangle;

        internal Wall(GraphicsDevice graphicsDevice)
        {
            _matrix = new bool[_xBlocksCount, _yBlocksCount];
            _wallRectangle = new Texture2D(graphicsDevice, 1, 1);
            _wallRectangle.SetData(new[] { Color.Black });
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            _spriteBatch.Draw(_wallRectangle, 
                new Rectangle(
                    _leftTopCornerLocation.X,
                    _leftTopCornerLocation.Y,
                    _wallBlockSize * _xBlocksCount, 
                    _wallBlockSize * _yBlocksCount), 
                Color.Black);
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

        private void removeLines(int[] linesNumbers)
        {

        }

        public void Dispose()
        {
            _wallRectangle.Dispose();
        }
    }
}
