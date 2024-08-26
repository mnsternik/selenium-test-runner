using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTestRunner.UI
{
    internal class SettingsTabHandler
    {
        private static readonly Dictionary<string, bool> ButtonEnabledStates = new Dictionary<string, bool>();
        private static readonly Dictionary<string, bool> TextboxReadonlyStates = new Dictionary<string, bool>();

        public static event Action<string, bool>? ButtonStateChanged;
        public static event Action<string, bool>? TextboxStateChanged; 

        static SettingsTabHandler()
        {
            InitializeButtonStates();
            InitializeTextboxStates();
        }

        private static void InitializeButtonStates()
        {
            ButtonEnabledStates["DriverPathButton"] = false;
            ButtonEnabledStates["FirefoxPathButton"] = false;
            ButtonEnabledStates["LogsPathButton"] = false;
            ButtonEnabledStates["EditConfigButton"] = true;
            ButtonEnabledStates["CancelEditConfigButton"] = false;
            ButtonEnabledStates["SaveConfigButton"] = false;
        }

        private static void InitializeTextboxStates()
        {
            TextboxReadonlyStates["DriverPathText"] = true;
            TextboxReadonlyStates["BrowserPathText"] = true;
            TextboxReadonlyStates["LogsPathText"] = true;
            TextboxReadonlyStates["WaitingTimeoutText"] = true;
        }

        public static void SetButtonState(string buttonName, bool isEnabled)
        {
            if (!ButtonEnabledStates.TryAdd(buttonName, isEnabled))
            {
                ButtonEnabledStates[buttonName] = isEnabled;
            }

            ButtonStateChanged?.Invoke(buttonName, isEnabled);
        }

        public static bool GetButtonState(string buttonName)
        {
            return ButtonEnabledStates.TryGetValue(buttonName, out var isEnabled) && isEnabled;
        }

        public static void SetTextboxState(string textboxName, bool isReadonly)
        {
            if (!TextboxReadonlyStates.TryAdd(textboxName, isReadonly))
            {
                TextboxReadonlyStates[textboxName] = isReadonly;
            }

            TextboxStateChanged?.Invoke(textboxName, isReadonly);
        }

        public static bool GetTextboxState(string textboxName)
        {
            return TextboxReadonlyStates.TryGetValue(textboxName, out var isReadonly) && isReadonly;
        }
    }
}
