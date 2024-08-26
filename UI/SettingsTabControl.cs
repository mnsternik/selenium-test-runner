using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTestRunner.Utilities;
using WinFormsTestRunner.Configuration;
using WinFormsTestRunner.Models;
using WinFormsTestRunner.UI;

namespace WinFormsTestRunner
{
    public partial class SettingsTabControl : UserControl
    {
        private Config? _config;

        public SettingsTabControl()
        {
            InitializeComponent();

            this.Load += SettingsTabControl_Load;
        }

        private void OnButtonStateChanged(string buttonName, bool isEnabled)
        {
            // Przypadek odwoływania się do kontrolki z innego wątku, niż ten w którym została stworzona
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnButtonStateChanged(buttonName, isEnabled)));
                return;
            }

            switch (buttonName)
            {
                case "DriverPathButton":
                    DriverPathButton.Enabled = isEnabled;
                    break;
                case "BrowserPathButton":
                    BrowserPathButton.Enabled = isEnabled;
                    break;
                case "LogsPathButton":
                    LogsPathButton.Enabled = isEnabled;
                    break;
                case "EditConfigButton":
                    EditConfigButton.Enabled = isEnabled;
                    break;
                case "CancelEditConfigButton":
                    CancelEditConfigButton.Enabled = isEnabled;
                    break;
                case "SaveConfigButton":
                    SaveConfigButton.Enabled = isEnabled;
                    break;
            }
        }

        private void OnTextboxStateChanged(string textboxName, bool isReadonly)
        {
            // Przypadek odwoływania się do kontrolki z innego wątku, niż ten w którym została stworzona
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnButtonStateChanged(textboxName, isReadonly)));
                return;
            }

            switch (textboxName)
            {
                case "DriverPathText":
                    DriverPathText.ReadOnly = isReadonly;
                    break;
                case "BrowserPathText":
                    BrowserPathText.ReadOnly = isReadonly;
                    break;
                case "LogsPathText":
                    LogsPathText.ReadOnly = isReadonly;
                    break;
                case "WaitingTimeoutText":
                    WaitingTimeoutText.ReadOnly = isReadonly;
                    break;
            }
        }

        private void SettingsTabControl_Load(object? sender, EventArgs e)
        {
            InitializeConfigData();
            InitializeButtonsState();
            InitializeTextboxState();

            SettingsTabHandler.ButtonStateChanged += OnButtonStateChanged;
            SettingsTabHandler.TextboxStateChanged += OnTextboxStateChanged;
        }

        private void DriverPathButton_Click(object sender, EventArgs e)
        {
            var driverPath = DialogFileHandler.GetFilePath("Executable files (*.exe)|*.exe");
            DriverPathText.Text = driverPath;
            _config.DriverPath = driverPath;
        }

        private void BrowserPathButton_Click(object sender, EventArgs e)
        {
            var browserPath = DialogFileHandler.GetFilePath("Executable files (*.exe)|*.exe");
            BrowserPathText.Text = browserPath;
            _config.FirefoxPath = browserPath;
        }

        private void LogsPathButton_Click(object sender, EventArgs e)
        {
            var logsPath = DialogFileHandler.GetFolderPath();
            LogsPathText.Text = logsPath;
            _config.LogsFolderPath = logsPath;
        }

        private void WaitingTimeoutText_TextChanged(object sender, EventArgs e)
        {
            _config.ElementWaitingTimeout = int.Parse(WaitingTimeoutText.Text);
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            ConfigManager.Config = (Config)_config.Clone();
            ConfigManager.SaveConfig();

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

        private void EditConfigButton_Click(object sender, EventArgs e)
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

        private void CancelEditConfigButton_Click(object sender, EventArgs e)
        {
            InitializeConfigData(); 

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

        private void InitializeButtonsState()
        {
            DriverPathButton.Enabled = SettingsTabHandler.GetButtonState("DriverPathButton");
            BrowserPathButton.Enabled = SettingsTabHandler.GetButtonState("BrowserPathButton");
            LogsPathButton.Enabled = SettingsTabHandler.GetButtonState("LogsPathButton");
            EditConfigButton.Enabled = SettingsTabHandler.GetButtonState("EditConfigButton");
            CancelEditConfigButton.Enabled = SettingsTabHandler.GetButtonState("CancelEditConfigButton");
            SaveConfigButton.Enabled = SettingsTabHandler.GetButtonState("SaveConfigButton");
        }

        private void InitializeTextboxState()
        {
            DriverPathText.ReadOnly = SettingsTabHandler.GetTextboxState("DriverPathText");
            BrowserPathText.ReadOnly = SettingsTabHandler.GetTextboxState("BrowserPathText");
            LogsPathText.ReadOnly = SettingsTabHandler.GetTextboxState("LogsPathText");
            WaitingTimeoutText.ReadOnly = SettingsTabHandler.GetTextboxState("WaitingTimeoutText");
        }

        private void InitializeConfigData()
        {
            _config = (Config)ConfigManager.Config.Clone(); 

            DriverPathText.Text = _config.DriverPath;
            BrowserPathText.Text = _config.FirefoxPath;
            LogsPathText.Text = _config.LogsFolderPath;
            WaitingTimeoutText.Text = _config.ElementWaitingTimeout.ToString();
        }
    }
}
