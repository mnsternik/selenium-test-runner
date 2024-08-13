using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestRunner.UI
{
    internal static class ButtonsStateHandler
    {
        private static readonly Dictionary<string, bool> ButtonStates = new Dictionary<string, bool>();

        public static event Action<string, bool>? ButtonStateChanged;

        static ButtonsStateHandler()
        {
            InitializeButtonStates();
        }
        // Ustawienie początkowego stanu aktywności przycisków
        private static void InitializeButtonStates()
        {
            // Testing tab control
            ButtonStates["StartTestButton"] = true;
            ButtonStates["StopTestButton"] = false;
            ButtonStates["EndTestButton"] = false;
            ButtonStates["NextStepButton"] = false;
            ButtonStates["RetryStepButton"] = false;
            ButtonStates["ScenarioPathButton"] = true;

            // Settings tab control

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
    }
}
