using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestRunner.Exceptions
{
    internal class ScenarioException : Exception
    {
        public ScenarioException(string message) : base(message) { }
        public ScenarioException(string message, Exception innerException) : base(message, innerException) { }
    }

    internal class InvalidStepParameterException : ScenarioException
    {
        private const string Prefix = "Błąd w parametrze kroku testowego: ";
        public InvalidStepParameterException(string message) : base(Prefix + message) { }
        public InvalidStepParameterException(string message, Exception innerException) : base(Prefix + message, innerException) { }
    }

    internal class InvalidScenarioException : ScenarioException
    {
        private const string Prefix = "Błąd scenariusza testowego: ";
        public InvalidScenarioException(string message) : base(message) { }
        public InvalidScenarioException(string message, Exception innerException) : base(Prefix + message, innerException) { }
    }
}
