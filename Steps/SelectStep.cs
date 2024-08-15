using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.Models;

namespace WinFormsTestRunner.Steps
{
    internal class SelectStep(GenericStep step) : Step(step.Name, step.Action, step.ElementXPath, step.ElementId, step.BackupScenarioPath)
    {
        public string OptionType { get; set; } = step.OptionType ?? string.Empty;
        public string Value { get; set; } = step.Value ?? string.Empty;

        public override void HandleAction()
        {
            var selectElement = new SelectElement(GetElement());
            switch (OptionType)
            {
                case "value":
                    selectElement.SelectByValue(Value);
                    break;
                case "text":
                    selectElement.SelectByText(Value);
                    break;
                case "index":
                    selectElement.SelectByIndex(Convert.ToInt32(Value));
                    break;
                default:
                    throw new InvalidStepParameterException($"Wskazano niepoprawny paramter 'OptionType': '{OptionType}', dostępne opcje to 'value', 'text', 'index'");
            }
        }
    }
}
