using WinFormsTestRunner.Exceptions;

namespace WinFormsTestRunner.Steps
{
    internal class WriteStep: Step
    {
        public WriteStep(Step step) 
        {
            if (string.IsNullOrEmpty(step.Value))
            {
                throw new InvalidStepParameterException($"Wskazano niepoprawną wartość paramteru {nameof(step.Value)}: '{Value}' w kroku {step.Name}");
            }

            Name = step.Name;
            Action = step.Action;
            ElementId = step.ElementId;
            ElementXPath = step.ElementXPath;
            Value = step.Value;
        }

        public override void HandleAction()
        {
            var element = GetElement();
            element.Clear();
            element.SendKeys(Value);
        }
    }
}
