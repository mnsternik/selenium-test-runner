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

namespace WinFormsTestRunner.Core
{
    internal class TestRunner
    {
        public static FirefoxDriver? Driver { get; set; }
        private static List<Step> Steps { get; set; } = new List<Step>();
        private static int _stepCounter = 0;

        public static void Run()
        {
            InitDriver();

            Logger.Log($"Uruchamianie scenariusza testowego: [nazwa]", true);;
            foreach (var step in Steps)
            {
                step.ExecuteAndLog(_stepCounter);
                _stepCounter++;
            }
        }

        public static void CreateTestScenario(string scenarioPath)
        {
            TestScenario ts = TestScenario.LoadScenario(scenarioPath); 
            Steps.Clear();
            Steps = CreateListOfSteps(ts);
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

        private static void InitDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = ConfigManager.Config?.FirefoxPath;
            Driver = new FirefoxDriver(ConfigManager.Config?.DriverPath, options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigManager.Config.ElementWaitingTimeout); // Ustawienie czekania na nieznalezione elementy
        }
    }
}
