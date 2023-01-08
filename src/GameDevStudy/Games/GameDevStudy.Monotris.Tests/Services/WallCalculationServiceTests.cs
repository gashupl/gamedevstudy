using GameDevStudy.Monotris.Domain.Services;
using System;
using Xunit;

namespace GameDevStudy.Monotris.ScreenElements
{
    public class WallCalculationServiceTests
    {

        [Fact]
        public void IsLineCompleted_Yes()
        {
            var xBlocksCount = 5;
            var yBlocksCount = 10; 
            var blocksMatrix = new bool[xBlocksCount, yBlocksCount];

            for(var i = 0; i < xBlocksCount; i++)
            {
                blocksMatrix[i, 0] = true;
            }

            var service = new WallCalculationService(xBlocksCount, yBlocksCount); 
            var result = service.IsLineCompleted(blocksMatrix);

            Assert.True(result.IsLineCompleted); 
        }


        [Fact]
        public void IsLineCompleted_No()
        {
            var xBlocksCount = 5;
            var yBlocksCount = 10;
            var blocksMatrix = new bool[xBlocksCount, yBlocksCount];

            for (var i = 0; i < xBlocksCount - 1; i++)
            {
                blocksMatrix[i, 0] = true;
            }

            var service = new WallCalculationService(xBlocksCount, yBlocksCount);
            var result = service.IsLineCompleted(blocksMatrix);

            Assert.False(result.IsLineCompleted);
        }
    }
}
