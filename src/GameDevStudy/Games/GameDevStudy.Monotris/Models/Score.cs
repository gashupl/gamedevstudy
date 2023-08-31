namespace GameDevStudy.Monotris.Models
{
    internal class Score
    {

        public string? PlayerName { get; set; }
        public int Result { get; set; } = 0;  

        public void Add(int points)
        {
            Result += points;
        }
    }
}
