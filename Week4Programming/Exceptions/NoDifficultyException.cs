using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Exceptions
{
    public class BaseDifficultyException : Exception
    {
        public BaseDifficultyException() { }
        public BaseDifficultyException(string message) : base(message) { }
        public BaseDifficultyException(string message, Exception inner) : base(message, inner) { }
    }
}
