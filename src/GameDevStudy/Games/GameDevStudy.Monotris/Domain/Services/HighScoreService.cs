﻿using GameDevStudy.Monotris.Models;
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
        private IEnumerable<Score> _highScore;
        private const string _fileName = "scores.json"; 

        public HighScoreService(IFileWrapper file, IEncryptionService encryptionService)
        {
            _file = file; 
            _encryptionService = encryptionService;
        }

        public IEnumerable<Score> Get()
        {
            var jsonText = _file.ReadAllText(_fileName);
            try
            {
                var deserialized = JsonSerializer.Deserialize(jsonText, typeof(IEnumerable<Score>));
                return (IEnumerable<Score>)deserialized;
            }
            catch (JsonException ex)
            {
                //TODO: Handle exception
                throw; 
            }
        }

        public void AddScore(Score score)
        {
            if(_highScore == null)
            {
                _highScore = Get(); 
            }

            var scoresList = _highScore.ToList(); 
            scoresList.Add(score);
            _highScore = scoresList.OrderBy(s => s.Result); 

            var jsonText = JsonSerializer.Serialize(score);
            var encryptedText = _encryptionService.Encrypt(jsonText); 
            _file.WriteAllText(_fileName, encryptedText);
        }

    }
}
