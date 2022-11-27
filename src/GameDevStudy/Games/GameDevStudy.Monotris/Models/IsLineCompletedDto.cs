using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevStudy.Monotris.Models
{
    internal class IsLineCompletedDto
    {
        public bool IsLineCompleted { get; set; }
        public List<int> CompletedLinesYCoordinates { get; set; }
    }
}
