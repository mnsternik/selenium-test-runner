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
        private static int _stepCounter = 0;
        private static string _scenarioName = string.Empty; 

        public static FirefoxDriver? Driver { get; set; }

        public static event Action<string>? UserActionOccurred;

        public async static Task RunAsync() 
        {
            Logger.Log($"Uruchamianie scenariusza testowego: {_scenarioName}", true);
            TestingTabHandler.SetTestStatus("Trwa wykonywanie scenariusza");

            InitDriver();
            foreach (var step in _steps)
            {
                await Task.Run(() => step.ExecuteAndLog(_stepCounter));
                _stepCounter++;
            }

            TestingTabHandler.SetTestStatus("Zakończono wykonywanie scenariusza");
            TestSummary.DisplaySummary();
            Driver?.Dispose();
        }

        public static void EndTest()
        {
            TestingTabHandler.SetTestStatus("Zakończono wykonywanie scenariusza");
            throw new TestRunnerException("Test został zakończony");
        }

        public static void CreateTestScenario(string scenarioPath)
        {
            TestScenario ts = TestScenario.LoadScenario(scenarioPath);
            _scenarioName = ts.Name; 

            _steps.Clear();
            _steps = CreateListOfSteps(ts);

            TestingTabHandler.SetTestStatus("Gotowy do uruchomienia");
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
