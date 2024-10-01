﻿using OpenQA.Selenium.Firefox;
using WinFormsTestRunner.Configuration;
using WinFormsTestRunner.Steps;
using WinFormsTestRunner.Utilities;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.UI;
using WinFormsTestRunner.Models;

namespace WinFormsTestRunner.Core
{
    internal class TestRunner
    {
        private static TestScenario? ts = null; 
        private static int _stepCounter = 0;

        public static FirefoxDriver? Driver { get; set; }

        public static event Action<string>? UserActionOccurred;

        public static void LoadScenario(string path)
        {
            ts = TestScenario.LoadScenario(path);
        }

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
            finally
            {
                SetViewAfterTest();
                FinilizeTest();
            }
        }

        public async static Task ExecuteStepsAsync()
        {
            Logger.Log($"Uruchamianie scenariusza testowego: {ts.Name}", true);

            foreach (var step in ts.Steps)
            {
                await Task.Run(() => step.ExecuteAndLog(_stepCounter));
                await Task.Delay(ConfigManager.Config.StepDelay * 1000);
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
            TestingTabHandler.SetButtonState("OpenLogFileButton", true); 
        }

        private static void FinilizeTest()
        {
            TestSummary.DisplaySummary();
            TestSummary.Reset();
            Driver?.Dispose();
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
