namespace GameDevStudy.Monotris.Models
{
    internal class Wall
    {
        private bool[,] _matrix; 
        internal Wall()
        {
            _matrix = new bool[10,20];
        }

        internal Wall(int width, int height)
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
