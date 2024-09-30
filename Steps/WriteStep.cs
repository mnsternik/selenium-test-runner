using WinFormsTestRunner.Models;

namespace WinFormsTestRunner.Steps
{
    internal class WriteStep(GenericStep step) : Step(step.Name, step.Action, step.ElementXPath, step.ElementId)
    {
        public string Value { get; set; } = step.Value ?? string.Empty;

        public override void HandleAction()
        {
            var element = GetElement();
            element.Clear();
            element.SendKeys(Value);
        }
    }
}
