using OpenQA.Selenium;
using WinFormsTestRunner.Core;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.UI;
using WinFormsTestRunner.Utilities;

namespace WinFormsTestRunner.Steps
{
    internal class Step
    {
        public string Action { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? ElementId { get; set; } = string.Empty;
        public string? ElementXPath { get; set; } = string.Empty;
        public string? Url { get; set; } = string.Empty;
        public string? Value { get; set; } = string.Empty;
        public string? OptionType { get; set; } = string.Empty;
        public string? CheckType { get; set; } = string.Empty;
        public bool CheckInsideSelect { get; set; } = false;

        private static ManualResetEvent _waitHandle = new ManualResetEvent(false);
        private static string? _userAction;

        protected string? messageAfterLog;

        public void ExecuteAndLog(int stepCounter)
        {
            try
            {
                HandleAction();
                Logger.Log($"{Name}", true);
                ShowAdditionalMessageAfterLog();
            }
            catch (TestRunnerException ex)
            {
                Logger.Log(ex.Message, false);
                HandleFailure(stepCounter, ex.Message);
            }
            catch (OpenQA.Selenium.ElementNotInteractableException ex)
            {
                Logger.Log($"{Name} - Nie można podjąć interkacji ze wskazanym elementem.", false);
                HandleFailure(stepCounter, ex.Message);
            }
            catch (OpenQA.Selenium.NoSuchElementException ex)
            {
                Logger.Log($"{Name} - Nie odnaleziono oczekiwanego elementu na stronie.", false);
                HandleFailure(stepCounter, ex.Message);
            }
        }

        public virtual void HandleAction()
        {
            // Każdy klasa pochodna posiada własną implementacje metody 
        }

        public void HandleFailure(int stepCounter, string message)
        {
            TestingTabHandler.SetDuringFailedStepMode();

            _waitHandle.Reset();
            TestRunner.UserActionOccurred += OnUserActionOccurred;
            _waitHandle.WaitOne(); // Czekanie na wywołanie eventu UserActionOccurred
            TestRunner.UserActionOccurred -= OnUserActionOccurred;

            switch (_userAction)
            {
                case "NextStep":
                    TestSummary.RecordError(Name, message);
                    break;
                case "RetryStep":
                    ExecuteAndLog(stepCounter);
                    break;
                case "EndTest":
                    TestSummary.RecordError(Name, message);
                    throw new UserCancelException();
            }

            TestingTabHandler.SetDuringTestMode();
        }

        public void ShowAdditionalMessageAfterLog()
        {
            if (!string.IsNullOrEmpty(messageAfterLog))
            {
                Logger.Log(messageAfterLog);
            }
        }

        private void OnUserActionOccurred(string action)
        {
            _userAction = action;
            _waitHandle.Set(); // Odblokowanie wątku
        }

        public virtual IWebElement GetElement()
        {
            if (TestRunner.Driver == null)
            {
                throw new DriverInitException("Driver nie został poprawnie zaninicjowany.");
            }

            if (!string.IsNullOrEmpty(ElementXPath))
            {
                return TestRunner.Driver.FindElement(By.XPath(ElementXPath));
            }
            else if (!string.IsNullOrEmpty(ElementId))
            {
                return TestRunner.Driver.FindElement(By.Id(ElementId));
            }
            else
            {
                throw new InvalidStepParameterException($"Wykryto próbe odnalezienia elementu bez podania jego ID lub XPath - potrzebna weryfikacja poprawności scenariusza testowego.");
            }
        }
    }
}
