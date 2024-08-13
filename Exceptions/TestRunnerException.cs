using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestRunner.Exceptions
{
    internal class TestRunnerException : Exception
    {
        public TestRunnerException(string message) : base(message) { }
        public TestRunnerException(string message, Exception innerException) : base(message, innerException) { }
    }

    internal class InavlidVerificationException : TestRunnerException
    {
        private const string Prefix = "Błąd weryfikacji: ";
        public InavlidVerificationException(string message) : base(Prefix + message) { }
        public InavlidVerificationException(string message, Exception innerException) : base(Prefix + message, innerException) { }
    }

    internal class FailedStepException : TestRunnerException
    {
        private const string Prefix = "Wystąpił błąd w kroku: ";
        public FailedStepException(string message) : base(Prefix + message) { }
        public FailedStepException(string message, Exception innerException) : base(Prefix + message, innerException) { }
    }
}
