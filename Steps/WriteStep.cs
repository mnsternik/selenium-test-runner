using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Models;

namespace WinFormsTestRunner.Steps
{
    internal class WriteStep(GenericStep step) : Step(step.Name, step.Action, step.ElementXPath, step.ElementId, step.BackupScenarioPath)
    {
        public string Value { get; set; } = step.Value ?? string.Empty;

        public override void HandleAction()
        {
            var element = GetElement();
            string targetValue;
            switch (ActionType)
            {
                //case "write-password":
                //    targetValue = UserInputUtility.ConvertSecureStringToString(UserInputUtility.ReadPassword());
                //    break;
                //case "write-login":
                //    targetValue = UserInputUtility.ReadLogin();
                //    break;
                default:
                    targetValue = Value;
                    break;
            }
            element.Clear();
            element.SendKeys(targetValue);
        }
    }
}
