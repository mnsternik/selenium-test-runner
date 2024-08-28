using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Configuration;
using WinFormsTestRunner.Models;
using WinFormsTestRunner.Steps;
using WinFormsTestRunner.Utilities;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.UI;

namespace WinFormsTestRunner.Core
{
    internal class TestRunner
    {
        private static List<Step> _steps = new List<Step>();
        private static string _scenarioName = string.Empty;
        private static int _stepCounter = 0;

        public static FirefoxDriver? Driver { get; set; }

        public static event Action<string>? UserActionOccurred;

        public async static Task RunAsync()
        {
            SetViewBeforeTest();
            try
            {
                InitDriver();
                await ExecuteStepsAsync();
            }
            catch (UserCancelException ex)
            {
                Logger.Log(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
            finally
            {
                SetViewAfterTest();
                FinilizeTest();
            }
        }

        public async static Task ExecuteStepsAsync()
        {
            Logger.Log($"Uruchamianie scenariusza testowego: {_scenarioName}", true);

            foreach (var step in _steps)
            {
                await Task.Run(() => step.ExecuteAndLog(_stepCounter));
                _stepCounter++;
            }
        }

        private static void SetViewBeforeTest()
        {
            TestingTabHandler.SetTestStatus("Trwa wykonywanie scenariusza");
        }

        private static void SetViewAfterTest()
        {
            TestingTabHandler.SetTestNotStartedMode();
            TestingTabHandler.SetTestStatus("Zakończono wykonywanie scenariusza");
        }

        private static void FinilizeTest()
        {
            TestSummary.DisplaySummary();
            TestSummary.Reset();
            Driver?.Dispose();
        }

        public static void CreateTestScenario(string scenarioPath)
        {
            try
            {
                TestScenario ts = TestScenario.LoadScenario(scenarioPath);
                _scenarioName = ts.Name;
                _steps.Clear();
                _steps = CreateListOfSteps(ts);
                TestingTabHandler.SetTestStatus("Gotowy do uruchomienia");
            }
            catch (InvalidScenarioException ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public static List<Step> CreateListOfSteps(TestScenario ts)
        {
            List<Step> steps = new List<Step>();
            foreach (var step in ts.Steps)
            {
                steps.Add(GenericStep.TransformIntoSpecifedStep(step));
            }
            return steps;
        }

        public static void TriggerUserAction(string action)
        {
            UserActionOccurred?.Invoke(action);
        }

        private static void InitDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = ConfigManager.Config?.FirefoxPath;
            Driver = new FirefoxDriver(ConfigManager.Config?.DriverPath, options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigManager.Config.ElementWaitingTimeout); // Ustawienie czekania na nieznalezione elementy
        }
    }
}
