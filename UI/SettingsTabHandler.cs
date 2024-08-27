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

        public static void SetEditMode()
        {
            SettingsTabHandler.SetButtonState("DriverPathButton", true);
            SettingsTabHandler.SetButtonState("BrowserPathButton", true);
            SettingsTabHandler.SetButtonState("LogsPathButton", true);
            SettingsTabHandler.SetButtonState("EditConfigButton", false);
            SettingsTabHandler.SetButtonState("CancelEditConfigButton", true);
            SettingsTabHandler.SetButtonState("SaveConfigButton", true);

            SettingsTabHandler.SetTextboxState("DriverPathText", false);
            SettingsTabHandler.SetTextboxState("BrowserPathText", false);
            SettingsTabHandler.SetTextboxState("LogsPathText", false);
            SettingsTabHandler.SetTextboxState("WaitingTimeoutText", false);
        }

        public static void SetViewMode()
        {
            SettingsTabHandler.SetButtonState("DriverPathButton", false);
            SettingsTabHandler.SetButtonState("BrowserPathButton", false);
            SettingsTabHandler.SetButtonState("LogsPathButton", false);
            SettingsTabHandler.SetButtonState("EditConfigButton", true);
            SettingsTabHandler.SetButtonState("CancelEditConfigButton", false);
            SettingsTabHandler.SetButtonState("SaveConfigButton", false);

            SettingsTabHandler.SetTextboxState("DriverPathText", true);
            SettingsTabHandler.SetTextboxState("BrowserPathText", true);
            SettingsTabHandler.SetTextboxState("LogsPathText", true);
            SettingsTabHandler.SetTextboxState("WaitingTimeoutText", true);
        }
    }
}
