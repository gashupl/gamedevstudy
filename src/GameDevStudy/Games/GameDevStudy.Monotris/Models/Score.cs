namespace GameDevStudy.Monotris.Models
{
    internal class Score
    {
        private int _result = 0; 

        public string? PlayerName { get; set; }
        public int Result 
        { 
            get { return _result;} 
            private set { _result = value; } 
        }  

        public void Add(int points)
        {
            _result += points;
        }
    }
}
