using GameDevStudy.Monotris.Models;

namespace GameDevStudy.Monotris.Domain
{
    internal class ShapeFactory
    {
        public Shape CreateRandom()
        {
            throw new NotImplementedException();    
        }

        private ShapeType GetRandomType()
        {
            Array values = Enum.GetValues(typeof(ShapeType));
            Random random = new Random();
            return (ShapeType)values.GetValue(random.Next(values.Length));     
        }
    }
}
