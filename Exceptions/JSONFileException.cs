using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestRunner.Exceptions
{
    internal class JSONFileException : Exception
    {
        public JSONFileException(string message) : base(message) { }
        public JSONFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}
