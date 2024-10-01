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
        public int ElementWaitingTimeout { get; set; }
        public int StepDelay { get; set; }

        public Config(string driverPath, string firefoxPath, int elementWaitingTimeout, int stepDelay)
        {
            DriverPath = driverPath;
            FirefoxPath = firefoxPath;
            ElementWaitingTimeout = elementWaitingTimeout;
            StepDelay = stepDelay;
        }

        public Config(Config config)
        {
            DriverPath = config.DriverPath;
            FirefoxPath = config.FirefoxPath;
            ElementWaitingTimeout = config.ElementWaitingTimeout;
            StepDelay = config.StepDelay;
        }

        public Config()
        {
            DriverPath = string.Empty;
            FirefoxPath = string.Empty;
            ElementWaitingTimeout = 1;
            StepDelay = 1;
        }

        public object Clone()
        {
            return new Config
            {
                DriverPath = this.DriverPath,
                FirefoxPath = this.FirefoxPath,
                ElementWaitingTimeout = this.ElementWaitingTimeout,
                StepDelay = this.StepDelay
            };
        }
    }
}
