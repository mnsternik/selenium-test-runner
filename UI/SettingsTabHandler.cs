namespace WinFormsTestRunner.UI
{
    internal class SettingsTabHandler
    {
        private static readonly Dictionary<string, bool> ButtonStates = new Dictionary<string, bool>();
        private static readonly Dictionary<string, bool> TextboxStates = new Dictionary<string, bool>();

        public static event Action<string, bool>? ButtonStateChanged;
        public static event Action<string, bool>? TextboxStateChanged; 

        public static void SetButtonStates(Dictionary<string, bool> buttonStates)
        {
            foreach (var button in buttonStates)
            {
                if (!ButtonStates.TryAdd(button.Key, button.Value))
                {
                    ButtonStates[button.Key] = button.Value;
                }

                ButtonStateChanged?.Invoke(button.Key, button.Value);
            }
        }

        public static bool GetButtonState(string buttonName)
        {
            return ButtonStates.TryGetValue(buttonName, out var isEnabled) && isEnabled;
        }

        public static void SetTextboxStates(Dictionary<string, bool> textboxStates)
        {
            foreach (var textbox in textboxStates)
            {
                if (!TextboxStates.TryAdd(textbox.Key, textbox.Value))
                {
                    TextboxStates[textbox.Key] = textbox.Value;
                }

                TextboxStateChanged?.Invoke(textbox.Key, textbox.Value);
            }
        }

        public static bool GetTextboxState(string textboxName)
        {
            return TextboxStates.TryGetValue(textboxName, out var isReadonly) && isReadonly;
        }

        public static void SetEditMode()
        {
            SetButtonStates(editModeButtonStates);
            SetTextboxStates(editModeTextboxStates);
        }

        public static void SetReadonlyMode()
        {
            SetButtonStates(readonlyModeButtonStates);
            SetTextboxStates(readonlyModeTextboxStates);
        }

        private static readonly Dictionary<string, bool> editModeButtonStates = new Dictionary<string, bool>
        {
            { "DriverPathButton", true },
            { "BrowserPathButton", true },
            { "EditConfigButton", false },
            { "CancelEditConfigButton", true },
            { "SaveConfigButton", true },
        };

        private static readonly Dictionary<string, bool> editModeTextboxStates = new Dictionary<string, bool>
        {
            { "DriverPathText", false },
            { "BrowserPathText", false },
            { "WaitingTimeoutText", false },
            { "StepDelayText", false },
        };

        private static readonly Dictionary<string, bool> readonlyModeButtonStates = new Dictionary<string, bool>
        {
            { "DriverPathButton", false },
            { "BrowserPathButton", false },
            { "EditConfigButton", true },
            { "CancelEditConfigButton", false },
            { "SaveConfigButton", false },
        };

        private static readonly Dictionary<string, bool> readonlyModeTextboxStates = new Dictionary<string, bool>
        {
            { "DriverPathText", true},
            { "BrowserPathText", true },
            { "WaitingTimeoutText", true },
            { "StepDelayText", true },
        };
    }
}
