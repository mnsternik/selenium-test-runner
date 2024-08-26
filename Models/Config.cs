using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestRunner.Models
{
    internal class Config : ICloneable
    {
        public string DriverPath { get; set; }
        public string FirefoxPath { get; set; }
        public string LogsFolderPath { get; set; }
        public int ElementWaitingTimeout { get; set; }

        public Config(string driverPath, string firefoxPath, string logsFolderPath, int elementWaitingTimeout)
        {
            DriverPath = driverPath;
            FirefoxPath = firefoxPath;
            LogsFolderPath = logsFolderPath;
            ElementWaitingTimeout = elementWaitingTimeout;
        }

        public Config(Config config)
        {
            DriverPath = config.DriverPath;
            FirefoxPath = config.FirefoxPath;
            LogsFolderPath = config.LogsFolderPath;
            ElementWaitingTimeout = config.ElementWaitingTimeout;
        }

        public Config()
        {
            DriverPath = string.Empty;
            FirefoxPath = string.Empty;
            LogsFolderPath = string.Empty;
            ElementWaitingTimeout = 1;
        }

        public object Clone()
        {
            return new Config
            {
                DriverPath = this.DriverPath,
                FirefoxPath = this.FirefoxPath,
                LogsFolderPath = this.LogsFolderPath,
                ElementWaitingTimeout = this.ElementWaitingTimeout
            };
        }
    }
}
