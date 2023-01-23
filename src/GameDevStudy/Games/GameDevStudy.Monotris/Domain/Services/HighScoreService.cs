using GameDevStudy.Monotris.Domain.Exceptions;
using GameDevStudy.Monotris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameDevStudy.Monotris.Domain.Services
{
    internal class HighScoreService
    {
        private readonly IFileWrapper _file;
        private IEnumerable<Score>? _highScore;
        private const string _fileName = ".scores"; 

        public HighScoreService(IFileWrapper file)
        {
            _file = file; 
        }

        public void Load()
        {
            var jsonText = _file.ReadAllText(_fileName);
            try
            {
                var deserialized = JsonSerializer.Deserialize(jsonText, typeof(IEnumerable<Score>));
                _highScore = deserialized as IEnumerable<Score>;
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
            _highScore = scoresList.OrderBy(s => s.Result);

            Save(); 
        }

    }
}
