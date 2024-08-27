using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Core;

namespace WinFormsTestRunner.UI
{
    internal static class TestingTabHandler
    {
        private static readonly Dictionary<string, bool> ButtonStates = new Dictionary<string, bool>();
        private static readonly Dictionary<string, bool> TextboxStates = new Dictionary<string, bool>(); 

        public static event Action<string, bool>? ButtonStateChanged;
        public static event Action<string>? TestStatusChanged; 

        public static void SetButtonState(string buttonName, bool isEnabled)
        {
            if (!ButtonStates.TryAdd(buttonName, isEnabled))
            {
                ButtonStates[buttonName] = isEnabled;
            }

            ButtonStateChanged?.Invoke(buttonName, isEnabled);
        }

        public static bool GetButtonState(string buttonName)
        {
            return ButtonStates.TryGetValue(buttonName, out var isEnabled) && isEnabled;
        }

        public static void SetTestStatus(string status)
        {
            TestStatusChanged?.Invoke(status); 
        }

        public static void SetTestStartedMode()
        {
            TestingTabHandler.SetButtonState("StartTestButton", false);
            TestingTabHandler.SetButtonState("EndTestButton", true);
            TestingTabHandler.SetButtonState("NextStepButton", false);
            TestingTabHandler.SetButtonState("RetryStepButton", false);
            TestingTabHandler.SetButtonState("ScenarioPathButton", false);
        }

        public static void SetTestNotStartedMode()
        {
            TestingTabHandler.SetButtonState("StartTestButton", true);
            TestingTabHandler.SetButtonState("EndTestButton", false);
            TestingTabHandler.SetButtonState("NextStepButton", false);
            TestingTabHandler.SetButtonState("RetryStepButton", false);
            TestingTabHandler.SetButtonState("ScenarioPathButton", true);
        }
    }
}
