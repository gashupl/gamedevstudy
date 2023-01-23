using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevStudy.Monotris.Domain.Exceptions
{
    internal class ScoreFileException : Exception
    {
        internal ScoreFileException(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}
