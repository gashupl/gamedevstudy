using GameDevStudy.Monotris.Domain.Exceptions;
using GameDevStudy.Monotris.Models;
using System.Text.Json;
using System.Linq; 

namespace GameDevStudy.Monotris.Domain.Services
{
    internal class HighScoreService
    {
        private readonly IFileWrapper _file;
        private IEnumerable<Score>? _highScore;
        private const string _fileName = ".scores";
        private const int _maxScoreCount = 10; 

        public IEnumerable<Score>? HighScore
        {
            get 
            {
                if(_highScore == null)
                {
                    Load(); 
                }
                return _highScore;
            }
            private set { _highScore = value; }
        }

        public Score CurrentScore { get; set; }

        public HighScoreService(IFileWrapper file)
        {
            _file = file; 
        }

        public HighScoreService(IFileWrapper file, IEnumerable<Score>? highScore)
        {
            _file = file;
            _highScore = highScore;
        }

        public void Load()
        {    
            try
            {
                var jsonText = _file.ReadAllText(_fileName);
                if (!String.IsNullOrEmpty(jsonText))
                {
                    var deserialized = JsonSerializer.Deserialize(jsonText, typeof(IEnumerable<Score>));
                    _highScore = deserialized as IEnumerable<Score>;
                }
                else
                {
                    _highScore = new List<Score>();
                }

            }
            catch(Exception ex)
            {
                throw new ScoreFileException("Exception when deserializing score file content", ex); 
            }
        }

        public void Save()
        {
            try
            {
                var jsonText = JsonSerializer.Serialize(_highScore);
                _file.WriteAllText(_fileName, jsonText);
            }
            catch (Exception ex)
            {
                throw new ScoreFileException("Exception when saving high score to file", ex);
            }
        }

        public void AddScore(Score score)
        {
            if(_highScore == null)
            {
                Load(); 
            }

            var scoresList = _highScore != null ? _highScore.ToList() : new List<Score>(); 
            scoresList.Add(score);
            _highScore = scoresList.OrderByDescending(s => s.Result);

            if(_highScore.Count() > _maxScoreCount)
            {
                //Remove the smallest result
                scoresList = _highScore.ToList();  ;
                scoresList.RemoveAt(_highScore.Count() - 1);
                _highScore = scoresList; 
            }
        }

        public bool ShouldScoreBeSaved(Score score)
        {
            if (_highScore == null)
            {
                Load();
            }

            if (_highScore?.Count() < _maxScoreCount) { 
                return true; //Always add new score in case number of results is less then max nuber
            }

            var minResult = _highScore?.Select(s => s.Result).ToList().Min();
            if (score.Result > minResult)
            {
                return true; 
            }
            return false; 
        }

    }
}
