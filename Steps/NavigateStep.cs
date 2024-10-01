using WinFormsTestRunner.Core;
using WinFormsTestRunner.Exceptions;

namespace WinFormsTestRunner.Steps
{
    internal class NavigateStep : Step
    { 
        public NavigateStep(Step step)
        {
            if (string.IsNullOrEmpty(step.Url))
            {
                throw new InvalidStepParameterException($"Nie wskazano adresu URL w kroku: {step.Name}"); 
            }
            else
            {
                Url = step.Url;
            }

            Name = step.Name;
            Action = step.Action;
        }

        public override void HandleAction()
        {
            TestRunner.Driver?.Navigate().GoToUrl(Url);
        }
    }
}
