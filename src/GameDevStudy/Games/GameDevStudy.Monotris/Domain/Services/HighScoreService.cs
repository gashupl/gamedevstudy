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
        private readonly IEncryptionService _encryptionService; 
        private IEnumerable<Score>? _highScore;
        private const string _fileName = "scores.json"; 

        public HighScoreService(IFileWrapper file, IEncryptionService encryptionService)
        {
            _file = file; 
            _encryptionService = encryptionService;
        }

        public void Load()
        {
            var jsonEncryptedText = _file.ReadAllText(_fileName);
            var jsonText = _encryptionService.Decrypt(jsonEncryptedText); 
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
                var encryptedText = _encryptionService.Encrypt(jsonText);
                _file.WriteAllText(_fileName, encryptedText);
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
