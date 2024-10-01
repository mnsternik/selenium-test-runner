using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WinFormsTestRunner.Core;
using WinFormsTestRunner.Exceptions;

namespace WinFormsTestRunner.Steps
{
    internal class VerifyStep : Step
    {
        private IWebElement? _element;

        public VerifyStep(Step step)
        {
            if (step.CheckType != "is-displayed" && step.CheckType != "text" && step.CheckType != "text-is-not" && step.CheckType != "value" && step.CheckType != "value-is-not")
            {
                throw new InvalidStepParameterException($"Wskazano niepoprawny paramter {nameof(step.CheckType)}: '{CheckType}' w kroku:" +
                    $" {step.Name}. Dostępne opcje to 'is-displayed', 'text', 'text-is-not', 'value', 'value-is-not");
            }

            if (string.IsNullOrEmpty(step.Value))
            {
                throw new InvalidStepParameterException($"Wskazano niepoprawną wartość paramteru {nameof(step.Value)}: '{Value}' w kroku: {step.Name}");
            }

            Name = step.Name;
            Action = step.Action;
            ElementId = step.ElementId;
            ElementXPath = step.ElementXPath;
            CheckType = step.CheckType;
            Value = step.Value;
            CheckInsideSelect = step.CheckInsideSelect;
        }

        public override void HandleAction()
        {
            _element = CheckInsideSelect ? GetOptionInsideSelectElement() : GetElement();
            VerifyBasedOnCheckType();
        }

        public void VerifyBasedOnCheckType()
        {
            switch (CheckType)
            {
                case "is-displayed":
                    CheckIfElementIsDisplayed();
                    break;
                case "text":
                    AssertTextIs();
                    break;
                case "text-is-not":
                    AssertTextIsNot();
                    break;
                case "value":
                    AssertValueIs();
                    break;
                case "value-is-not":
                    AssertValueIsNot();
                    break;
                default:
                    throw new InvalidStepParameterException($"Niepoprawna wartość paramteru {nameof(CheckType)}: '{CheckType}'");
            }
        }

        private void CheckIfElementIsDisplayed()
        {
            if (_element == null || !_element.Displayed)
            {
                if (ElementId != null)
                {
                    throw new InavlidVerificationException($"Nie znaleziono elemenetu z ID: {ElementId}");
                }
                else if (ElementXPath != null)
                {
                    throw new InavlidVerificationException($"Nie znaleziono elemenetu z XPath: {ElementXPath}");
                }
            }
        }

        private void AssertTextIsNot()
        {
            bool isTextValid = WaitForAndCheckCondtition(driver => _element?.Text != Value && !string.IsNullOrEmpty(_element?.Text));
            if (isTextValid)
            {
                
                messageAfterLog = $"Sukces: Oczekiwano tekstu innego niż: '{Value}', znaleziono tekst: '{_element?.Text}'";
            }
            else
            {
                throw new InavlidVerificationException($"Oczekiwano tekstu innego niż: '{Value}', znaleziono tekst: '{_element?.Text}'");
            }
        }

        private void AssertTextIs()
        {
            bool isTextEqualToExpected = WaitForAndCheckCondtition(driver => _element?.Text == Value);
            if (isTextEqualToExpected)
            {
                messageAfterLog = $"Sukces: Oczekiwano tekstu: '{Value}', znaleziono tekst: '{_element?.Text}'";
            }
            else
            {
                throw new InavlidVerificationException($"Oczekiwano tekstu: '{Value}', znaleziono tekst: '{_element?.Text}'");
            }
        }

        private void AssertValueIsNot()
        {
            bool isValueValid = WaitForAndCheckCondtition(driver =>
                _element?.GetAttribute("value") != Value
                && !string.IsNullOrEmpty(_element?.GetAttribute("Value"))
            );

            if (isValueValid)
            {
                messageAfterLog = $"Sukces: Oczekiwano wartości innej niż: '{Value}', znaleziono wartość: '{_element?.GetAttribute("value")}'";
            }
            else
            {
                throw new InavlidVerificationException($"Oczekiwano wartości innej niż: '{Value}', znaleziono wartość: '{_element?.GetAttribute("value")}'");
            }
        }

        private void AssertValueIs()
        {
            bool isValueEqualToExpected = WaitForAndCheckCondtition(driver => _element?.GetAttribute("value") == Value);
            if (isValueEqualToExpected)
            {
                messageAfterLog = $"Sukces: Oczekiwano wartości: '{Value}', znaleziono wartość: '{_element?.GetAttribute("value")}'";
            }
            else
            {
                throw new InavlidVerificationException($"Oczekiwano wartości: '{Value}', znaleziono wartość: '{_element?.GetAttribute("value")}'");
            }
        }

        private static bool WaitForAndCheckCondtition(Func<IWebDriver, bool> condition)
        {
            try
            {
                WebDriverWait wait = new(TestRunner.Driver, TimeSpan.FromSeconds(5));
                wait.Until(condition);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        private IWebElement? GetOptionInsideSelectElement()
        {
            return GetElement().FindElements(By.TagName("option")).FirstOrDefault(option => option.Selected);
        }

    }
}
