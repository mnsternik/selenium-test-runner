using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestRunner.UI
{
    internal static class TestingTabHandler
    {
        private static readonly Dictionary<string, bool> ButtonStates = new Dictionary<string, bool>();
        private static readonly Dictionary<string, bool> TextboxStates = new Dictionary<string, bool>(); 

        public static event Action<string, bool>? ButtonStateChanged;
        public static event Action<string>? TestStatusChanged; 

        static TestingTabHandler()
        {
            InitializeButtonStates();
        }
        // Ustawienie początkowego stanu aktywności przycisków
        private static void InitializeButtonStates()
        {
            // Testing tab control
            ButtonStates["StartTestButton"] = true;
            ButtonStates["EndTestButton"] = false;
            ButtonStates["NextStepButton"] = false;
            ButtonStates["RetryStepButton"] = false;
            ButtonStates["ScenarioPathButton"] = true;
        }

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
    }
}
