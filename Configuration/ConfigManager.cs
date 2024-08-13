using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Utilities;
using WinFormsTestRunner.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsTestRunner.Configuration
{
    internal class ConfigManager
    {
        public static string DriverPath { get; set; } = string.Empty;
        public static string FirefoxPath { get; set; } = string.Empty;
        public static string LogsFolderPath { get; set; } = string.Empty;
        public static int ElementWaitingTimeout { get; set; } = 0;

        
        private static readonly string ConfigFileName = "config.json";
        //private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", ConfigFileName);
        private static readonly string ConfigFilePath = Path.Combine("C:\\Users\\mnste\\OneDrive\\Pulpit\\TestRunnerData", "Configuration", ConfigFileName);

        public static void LoadConfig()
        {
            var config = JSONFileHandler.Deserialize<Config>(ConfigFilePath);

            DriverPath = config.DriverPath;
            FirefoxPath = config.FirefoxPath; 
            LogsFolderPath = config.LogsFolderPath;
            ElementWaitingTimeout = config.ElementWaitingTimeout;
        }

        public static void SaveConfig() 
        {
            Config config = new Config(DriverPath, FirefoxPath, LogsFolderPath, ElementWaitingTimeout);
            JSONFileHandler.Serialize(config, ConfigFilePath);
        }
    }
}
