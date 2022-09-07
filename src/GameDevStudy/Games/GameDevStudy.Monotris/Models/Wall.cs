using Microsoft.Xna.Framework; 

namespace GameDevStudy.Monotris.Models
{
    internal class Wall
    {
        private bool[,] _matrix;
        private Point _leftDownCornerLocation;
        private int _wallBlockSize = 20; 

        internal Wall()
        {
            _matrix = new bool[10, 20];
            _leftDownCornerLocation = new Point(10,10);
        }

        internal Wall(Point leftDownCornerLocation)
        {
            _matrix = new bool[10,20];
            _leftDownCornerLocation = leftDownCornerLocation;  
        }

        internal Wall(Point leftDownCornerLocation, int width, int height)
        {
            _matrix = new bool[width, height];
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
    }
}
