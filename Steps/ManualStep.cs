using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Core;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.Models;
using WinFormsTestRunner.UI;
using WinFormsTestRunner.Utilities;

namespace WinFormsTestRunner.Steps
{
    internal class ManualStep(GenericStep step) : Step(step.Name, step.Action, step.ElementXPath, step.ElementId, step.BackupScenarioPath)
    {

        private static ManualResetEvent _waitHandle = new ManualResetEvent(false);
        private static string? _userAction;

        public override void HandleAction()
        {
            TestingTabHandler.SetButtonState("NextStepButton", true);
            TestingTabHandler.SetButtonState("EndTestButton", true);
            TestingTabHandler.SetTestStatus("Oczekiwanie na akcje użytkownika");

            Logger.Log("Uruchomiono krok ręczny - oczekiwanie na akcje użytkownika");

            _waitHandle.Reset();
            TestRunner.UserActionOccurred += OnUserActionOccurred;
            _waitHandle.WaitOne(); // Czekanie na wywołanie eventu UserActionOccurred
            TestRunner.UserActionOccurred -= OnUserActionOccurred;

            switch (_userAction)
            {
                case "ContinueStep":
                    break;
                case "EndTest":
                    TestRunner.EndTest();
                    break;
            }
        }

        private void OnUserActionOccurred(string action)
        {
            _userAction = action;
            _waitHandle.Set(); // Odblokowanie wątku
        }
    }
}
