using WinFormsTestRunner.Exceptions;

namespace WinFormsTestRunner.Steps
{
    internal class ClickStep : Step
    {
        public ClickStep(Step step)
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
            GetElement().Click();
        }
    }
}
