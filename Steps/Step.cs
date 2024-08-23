using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WinFormsTestRunner.Core;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.Models;
using WinFormsTestRunner.UI;
using WinFormsTestRunner.Utilities;

namespace WinFormsTestRunner.Steps
{
    internal class Step(string name, string actionType, string? elementXPath, string? elementId, string? backupScenarioPath)
    {
        public string Name { get; set; } = name ?? string.Empty;
        public string ActionType { get; set; } = actionType ?? string.Empty;
        public string? ElementXPath { get; set; } = elementXPath;
        public string? ElementId { get; set; } = elementId;
        public string? BackupScenarioPath { get; set; } = backupScenarioPath;

        private static ManualResetEvent _waitHandle = new ManualResetEvent(false);
        private static string _userAction;

        public void ExecuteAndLog(int stepCounter)
        {
            try
            {
                HandleAction();
                Logger.Log($"{Name}", true);
            }
            catch (TestRunnerException ex)
            {
                Logger.Log(ex.Message, false);
                HandleFailure(stepCounter, ex.Message);
            }
        }

        public virtual void HandleAction()
        {
            // Każdy klasa pochodna posiada własną implementacje metody HandleAction
        }

        public void HandleFailure(int stepCounter, string message)
        {
            UIStateHandler.SetButtonState("RetryStepButton", true);
            UIStateHandler.SetButtonState("NextStepButton", true);
            UIStateHandler.SetButtonState("StopTestButton", true);

            _waitHandle.Reset(); 
            TestRunner.UserActionOccurred += OnUserActionOccurred; 

            _waitHandle.WaitOne(); // Czekanie na wywołanie eventu UserActionOccurred
            TestRunner.UserActionOccurred -= OnUserActionOccurred; 

            switch (_userAction)
            {
                case "ContinueStep":
                    break;
                case "RetryStep":
                    ExecuteAndLog(stepCounter);
                    break;
                case "StopTest":
                    throw new TestRunnerException("Wykonywanie scenariusza testowego zostało zatrzymane przez użytkownika.");
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
