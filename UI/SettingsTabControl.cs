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
            _config = ConfigManager.Config;

            DriverPathText.Text = _config.DriverPath;
            BrowserPathText.Text = _config.FirefoxPath;
            LogsPathText.Text = _config.LogsFolderPath;
            WaitingTimeoutText.Text = _config.ElementWaitingTimeout.ToString();
        }

        //to delete?
        private void ConfigPathButton_Click(object sender, EventArgs e)
        {
            var configPath = DialogFileHandler.GetFilePath("JSON files (*.json)|*.json|All files (*.*)|*.*");
            ConfigPathText.Text = configPath;
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
            ConfigManager.Config = _config; 
            ConfigManager.SaveConfig();
        }
    }
}
