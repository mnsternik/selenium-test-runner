using WinFormsTestRunner.Utilities;

namespace WinFormsTestRunner.Core
{
    internal class TestSummary
    {
        private static int _errorCount;
        private static readonly Dictionary<string, string>? _errorDetails = []; 

        public static void RecordError(string stepName, string errorMessage)
        {
            _errorCount++;
            _errorDetails.Add(stepName, errorMessage);
        }

        public static int GetErrorCount()
        {
            return _errorCount;
        }

        public static bool HasErrors()
        {
            return _errorCount > 0;
        }

        public static  void DisplaySummary()
        {
            if (HasErrors())
            {
                Logger.Log($"KONIEC: Test zakończył się z liczbą błędów: {_errorCount}");
                Logger.Log("Lista błędów:");
                
                foreach ( var error in _errorDetails)
                {
                    Logger.Log($"{error.Key}");
                    Logger.Log($"{error.Value}");
                }
            }
            else
            {
                Logger.Log("KONIEC: Test zakończył się bez błędów");
            }
        }

        public static void Reset()
        {
            _errorCount = 0;
        }
    }
}
