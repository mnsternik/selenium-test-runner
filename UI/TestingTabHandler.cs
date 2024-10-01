namespace WinFormsTestRunner.UI
{
    internal static class TestingTabHandler
    {
        private static readonly Dictionary<string, bool> ButtonStates = new Dictionary<string, bool>();

        public static event Action<string, bool>? ButtonStateChanged;
        public static event Action<string>? TestStatusChanged;

        public static void SetButtonStates(Dictionary<string, bool> buttonStates)
        {
            foreach(var button in buttonStates)
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

        public static void SetTestStatus(string status)
        {
            TestStatusChanged?.Invoke(status);
        }

        public static void SetAfterAppInitMode()
        {
            SetButtonStates(afterAppStartedButtonStates);
            SetTestStatus("Oczekiwanie na wybór scenriusza"); 
        }

        public static void SetAfterScenarioSelectMode()
        {
            SetButtonStates(afterSelectingScenarioButtonStates);
            SetTestStatus("Gotowy do uruchomienia");
        }

        public static void SetDuringTestMode()
        {
            SetButtonStates(duringTestButtonStates);
            SetTestStatus("Trwa wykonywanie scenariusza");
        }

        public static void SetDuringManualStepMode()
        {
            SetButtonStates(duringManualStepButtonStates);
            SetTestStatus("Oczekiwanie na akcje użytkownika");
        }

        public static void SetDuringFailedStepMode()
        {
            SetButtonStates(duringFailedStepButtonStates);
            SetTestStatus("Oczekiwanie na akcje użytkownika");
        }

        public static void SetAfterTestEndedMode()
        {
            SetButtonStates(afterTestEndedButtonStates);
            SetTestStatus("Test zakończony");
        }

        private static readonly Dictionary<string, bool> afterAppStartedButtonStates = new Dictionary<string, bool>
        {
            { "StartTestButton", false },
            { "EndTestButton", false },
            { "NextStepButton", false },
            { "RetryStepButton", false },
            { "ScenarioPathButton", true },
            { "OpenLogFileButton", false },
        };

        private static readonly Dictionary<string, bool> afterSelectingScenarioButtonStates = new Dictionary<string, bool>
        {
            { "StartTestButton", true },
            { "EndTestButton", false },
            { "NextStepButton", false },
            { "RetryStepButton", false },
            { "ScenarioPathButton", true },
            { "OpenLogFileButton", false },
        };

        private static readonly Dictionary<string, bool> duringTestButtonStates = new Dictionary<string, bool>
        {
            { "StartTestButton", false },
            { "EndTestButton", false },
            { "NextStepButton", false },
            { "RetryStepButton", false },
            { "ScenarioPathButton", false },
            { "OpenLogFileButton", false },
        };

        private static readonly Dictionary<string, bool> duringManualStepButtonStates = new Dictionary<string, bool>
        {
            { "StartTestButton", false },
            { "EndTestButton", true },
            { "NextStepButton", true },
            { "RetryStepButton", false },
            { "ScenarioPathButton", false },
            { "OpenLogFileButton", false },
        };

        private static readonly Dictionary<string, bool> duringFailedStepButtonStates = new Dictionary<string, bool>
        {
            { "StartTestButton", false },
            { "EndTestButton", true },
            { "NextStepButton", true },
            { "RetryStepButton", true },
            { "ScenarioPathButton", false },
            { "OpenLogFileButton", false },
        };

        private static readonly Dictionary<string, bool> afterTestEndedButtonStates = new Dictionary<string, bool>
        {
            { "StartTestButton", true },
            { "EndTestButton", false },
            { "NextStepButton", false },
            { "RetryStepButton", false },
            { "ScenarioPathButton", true },
            { "OpenLogFileButton", true },
        };
    }
}
