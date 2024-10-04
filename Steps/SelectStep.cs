using OpenQA.Selenium.Support.UI;
using WinFormsTestRunner.Exceptions;

namespace WinFormsTestRunner.Steps
{
    internal class SelectStep : Step
    {
        public SelectStep(Step step)
        {
            if (string.IsNullOrEmpty(step.ElementId) && string.IsNullOrEmpty(step.ElementXPath))
            {
                throw new InvalidStepParameterException($"Nie wskazano ID lub XPath elementu docelowego w kroku: {step.Name}");
            }

            if (step.OptionType != "value" && step.OptionType != "text" && step.OptionType != "index")
            {
                throw new InvalidStepParameterException($"Wskazano niepoprawny paramter {nameof(step.OptionType)}: '{OptionType}' w kroku {step.Name}, dostępne opcje to 'value', 'text', 'index'");
            }

            if (string.IsNullOrEmpty(step.Value))
            {
                throw new InvalidStepParameterException($"Wskazano niepoprawną wartość paramteru {nameof(step.Value)}: '{Value}' w kroku {step.Name}");
            }

            Name = step.Name;
            Action = step.Action;
            ElementId = step.ElementId;
            ElementXPath = step.ElementXPath;
            OptionType = step.OptionType;
            Value = step.Value; 
        }

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
            }
        }
    }
}