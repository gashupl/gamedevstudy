using System;
using Xunit;

namespace GameDevStudy.Monotris.ScreenElements
{
    public class WallTests
    {

        [Fact]
        public void IsLineCompleted_Yes_()
        {
            var xBlocksCount = 5;
            var yBlocksCount = 10; 
            var blocksMatrix = new bool[xBlocksCount, yBlocksCount];

            for(var i = 0; i < xBlocksCount; i++)
            {
                blocksMatrix[i, 0] = true;
            }
            
            var result = Wall.IsLineCompleted(blocksMatrix, xBlocksCount, yBlocksCount);

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

            var result = Wall.IsLineCompleted(blocksMatrix, xBlocksCount, yBlocksCount);

            Assert.False(result.IsLineCompleted);
        }
    }
}
