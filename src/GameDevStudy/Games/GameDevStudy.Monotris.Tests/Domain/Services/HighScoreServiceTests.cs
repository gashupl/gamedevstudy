using GameDevStudy.Monotris.Domain.Exceptions;
using GameDevStudy.Monotris.Domain.Services;
using GameDevStudy.Monotris.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace GameDevStudy.Monotris.Tests.Domain.Services
{
    public class HighScoreServiceTests
    {
        private List<Score> _scores;
        private string _serializedText = "[{\"PlayerName\":\"ABC\",\"Result\":100},{\"PlayerName\":\"XYZ\",\"Result\":150},{\"PlayerName\":\"HEY\",\"Result\":300}]"; 

        private string _player1Name = "ABC"; 
        private string _player2Name = "XYZ";
        private string _player3Name = "HEY";
        public HighScoreServiceTests()
        {
            var score1 = new Score { PlayerName = _player1Name  };
            score1.Add(100);
            var score2 = new Score { PlayerName = _player2Name };
            score2.Add(150);
            var score3 = new Score { PlayerName = _player3Name };
            score3.Add(300);
            _scores = new List<Score>();
            _scores.Add(score1); 
            _scores.Add(score2);
            _scores.Add(score3);
        }
        [Fact]
        public void Load_ValidFile_SetScores()
        {
            var file = new Mock<IFileWrapper>();
            file.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns(_serializedText);
            var service = new HighScoreService(file.Object); 
            service.Load();
            Assert.Equal(3, service.HighScore?.Count());

        }

        [Fact]
        public void Load_InvalidFile_ThrowsException()
        {
            var file = new Mock<IFileWrapper>();
            file.Setup(f => f.ReadAllText(It.IsAny<string>())).Throws<IOException>();
            var service = new HighScoreService(file.Object);
            Assert.Throws<ScoreFileException>(() => service.Load());
        }

        [Fact]
        public void Save_OperationCompleted()
        {
            var file = new Mock<IFileWrapper>();
            file.Setup(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>())); 
            var service = new HighScoreService(file.Object, _scores);
 
            service.Save();

            file.Verify(f => f.WriteAllText(
                ".scores", 
                _serializedText), 
                Times.Once); 
        }

        [Fact]
        public void Save_OperationFiled_ThrowsException()
        {
            var file = new Mock<IFileWrapper>();
            file.Setup(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Throws<IOException>();
            var service = new HighScoreService(file.Object, _scores);

            Assert.Throws<ScoreFileException>(() => service.Save());
        }

        [Fact]
        public void AddScore_ValidCountAndOrder()
        {
            List<Score> previousScores = new List<Score>(_scores);

            var newPlayerName = "Player X"; 
            var score = new Score { PlayerName = newPlayerName };
            score.Add(160);

            var file = new Mock<IFileWrapper>();

            var service = new HighScoreService(file.Object, _scores);
            service.AddScore(score);

            Assert.Multiple(
                () => Assert.Equal(_player3Name, service.HighScore?.ToList()[0].PlayerName),
                () => Assert.Equal(newPlayerName, service.HighScore?.ToList()[1].PlayerName),
                () => Assert.Equal(_player2Name, service.HighScore?.ToList()[2].PlayerName),
                () => Assert.Equal(_player1Name, service.HighScore?.ToList()[3].PlayerName));

        }

    }
}
