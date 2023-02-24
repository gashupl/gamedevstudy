using GameDevStudy.Monotris.Models;

namespace GameDevStudy.Monotris.Domain.Services
{
    internal class WellCalculationService
    {
        private int _xBlocksCount;
        private int _yBlocksCount;

        internal WellCalculationService(int xBlocksCount, int yBlocksCount)
        {
            _xBlocksCount = xBlocksCount;
            _yBlocksCount = yBlocksCount;
        }
        public IsLineCompletedDto IsLineCompleted(bool[,] wellMatrix)
        {
            var completedLines = new List<int>();
            for (int y = 0; y < _yBlocksCount; y++)
            {
                var isCompleted = true;
                for (int x = 0; x < _xBlocksCount; x++)
                {
                    if (wellMatrix[x, y] == false)
                    {
                        isCompleted = false;
                        break;
                    }
                }
                if (isCompleted)
                {
                    completedLines.Add(y);
                }
            }

            return new IsLineCompletedDto()
            {
                IsLineCompleted = (completedLines.Count > 0),
                CompletedLinesYCoordinates = completedLines

            };
        }

        public void RemoveCompletedLines(ref bool[,] matrix, List<int> completedLines)
        {
            //Checking completed lines from top to the bottm 
            for (int y = _yBlocksCount - 1; y >= 0; y--)
            {
                if (completedLines.Contains(y))
                {
                    //Clean current line 
                    for (int x = 0; x < _xBlocksCount; x++)
                    {
                        matrix[x, y] = false;
                    }

                    //Move all the line from top till removed line 1 down
                    for (int _y = y; _y > 0; _y--)
                    {
                        for (int x = 0; x < _xBlocksCount; x++)
                        {
                            matrix[x, _y] = matrix[x, _y - 1];
                            matrix[x, _y - 1] = false;
                        }
                    }
                }
            }
        }

        public void ClearCurrentActiveBlock(ref bool[,] matrix, int activeBlockX, int activeBlockY)
        {
            matrix[activeBlockX, activeBlockY] = false;
        }
        
        public bool IsNextDownMoveAllowed(bool[,] matrix, int activeBlockX, int activeBlockY)
        {
            return activeBlockY < _yBlocksCount - 1 && !matrix[activeBlockX, activeBlockY + 1];
        }
    }
}
