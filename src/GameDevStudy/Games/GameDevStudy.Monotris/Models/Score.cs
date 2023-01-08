namespace GameDevStudy.Monotris.Models
{
    internal class Score
    {
        private int _score = 0; 

        public string? PlayerName { get; set; }

        public int Get()
        {
            return _score;
        }

        public void Add(int points)
        {
            _score += points;
        }
    }
}
