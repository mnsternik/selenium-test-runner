using WinFormsTestRunner.Core;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.Models;

namespace WinFormsTestRunner.Steps
{
    internal class ChangeContextStep : Step
    {
        public ChangeContextStep(Step step)
        {
            if (string.IsNullOrEmpty(step.ElementId) && string.IsNullOrEmpty(step.ElementXPath))
            {
                throw new InvalidStepParameterException($"Nie wskazano ID lub XPath elementu docelowego w kroku: {step.Name}");
            }

            Name = step.Name;
            Action = step.Action;
            ElementId = step.ElementId;
            ElementXPath = step.ElementXPath;
        }

        public override void HandleAction()
        {
            if (ElementId == "default")
            {
                TestRunner.Driver?.SwitchTo().DefaultContent();
            }
            else
            {
                var iframe = GetElement();
                TestRunner.Driver?.SwitchTo().Frame(iframe);
            }
        }
    }
}
