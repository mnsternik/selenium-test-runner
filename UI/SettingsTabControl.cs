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

        private void SettingsTabControl_Load(object? sender, EventArgs e)
        {
            InitializeConfigData();

            SettingsTabHandler.ButtonStateChanged += OnButtonStateChanged;
            SettingsTabHandler.TextboxStateChanged += OnTextboxStateChanged;
            SettingsTabHandler.SetViewMode();
        }

        private void InitializeConfigData()
        {
            _config = (Config)ConfigManager.Config.Clone();

            DriverPathText.Text = _config.DriverPath;
            BrowserPathText.Text = _config.FirefoxPath;
            WaitingTimeoutNumericUpDown.Value = _config.ElementWaitingTimeout;
            StepDelayNumericUpDown.Value = _config.StepDelay;
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
                case "WaitingTimeoutText":
                    WaitingTimeoutNumericUpDown.ReadOnly = isReadonly;
                    break;
                case "StepDelayText":
                    StepDelayNumericUpDown.ReadOnly = isReadonly;
                    break;
            }
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

        private void WaitingTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _config.ElementWaitingTimeout = (int)WaitingTimeoutNumericUpDown.Value; 
        }

        private void StepDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _config.StepDelay = (int)StepDelayNumericUpDown.Value;
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            ConfigManager.SaveConfig(_config);
            SettingsTabHandler.SetViewMode();
        }

        private void EditConfigButton_Click(object sender, EventArgs e)
        {
            SettingsTabHandler.SetEditMode();
        }

        private void CancelEditConfigButton_Click(object sender, EventArgs e)
        {
            InitializeConfigData();
            SettingsTabHandler.SetViewMode();
        }
    }
}
