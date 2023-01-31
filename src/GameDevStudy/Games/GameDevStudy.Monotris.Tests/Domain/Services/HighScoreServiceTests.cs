using GameDevStudy.Monotris.Domain.Services;
using GameDevStudy.Monotris.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameDevStudy.Monotris.Tests.Domain.Services
{
    public class HighScoreServiceTests
    {
        private List<Score> _scores;
        private string _serializedText = "[{\"PlayerName\":\"ABC\",\"Result\":100},{\"PlayerName\":\"XYZ\",\"Result\":100},{\"PlayerName\":\"HEY\",\"Result\":100}]"; 

        public HighScoreServiceTests()
        {
            var score1 = new Score { PlayerName = "ABC" };
            score1.Add(100);
            var score2 = new Score { PlayerName = "XYZ" };
            score2.Add(100);
            var score3 = new Score { PlayerName = "HEY" };
            score3.Add(100);
            _scores = new List<Score>();
            _scores.Add(score1); 
            _scores.Add(score2);
            _scores.Add(score3);
        }
        [Fact]
        public void Load_ValidFile_SetScores()
        {
            throw new NotImplementedException();
            var file = new Mock<IFileWrapper>();
            var service = new HighScoreService(file.Object); 
            service.Load();
        }

        [Fact]
        public void Load_InvalidFile_ThrowsException()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [Fact]
        public void AddScore_ValidCountAndOrder()
        {
            throw new NotImplementedException();
        }

    }
}
