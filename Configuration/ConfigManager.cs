using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Utilities;
using WinFormsTestRunner.Models;
using WinFormsTestRunner.Exceptions;

namespace WinFormsTestRunner.Configuration
{
    internal class ConfigManager
    {
        private static Config? _config;

        public static Config Config
        {
            get => _config ?? new Config();
            set
            {
                ValidateConfig(value);
                _config = value;
            }
        }

        private static readonly string ConfigFileName = "config.json";
        //private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", ConfigFileName);
        private static readonly string ConfigFilePath = Path.Combine("C:\\Users\\mnste\\OneDrive\\Pulpit\\TestRunnerData\\Configuration", ConfigFileName);

        public static void LoadConfig()
        {
            Config = JSONFileHandler.Deserialize<Config>(ConfigFilePath);
        }

        public static void SaveConfig()
        {
            JSONFileHandler.Serialize(Config, ConfigFilePath);
        }

        private static void ValidateConfig(Config config)
        {
            if (config == null)
            {
                throw new ConfigException($"Plik konfiguracyjny jest pusty lub nie istnieje. Sprawdzana lokalizacja: '{ConfigFilePath}'");
            }
            if (string.IsNullOrEmpty(config.DriverPath) || !File.Exists(config.DriverPath))
            {
                throw new ConfigException($"Wskazano błędną ścieżke do pliku geckodriver.exe w pliku konfiguracyjnym: '{config.DriverPath}'");
            }
            if (string.IsNullOrEmpty(config.FirefoxPath) || !File.Exists(config.FirefoxPath))
            {
                throw new ConfigException($"Wskazano błędną ścieżke do pliku firefox.exe w pliku konfiguracyjnym: '{config.FirefoxPath}'");
            }
            if (string.IsNullOrEmpty(config.LogsFolderPath) || !Directory.Exists(config.LogsFolderPath))
            {
                throw new ConfigException($"Wskazano błędną ścieżke do folderu, w którym mają tworzyć się logi: '{config.LogsFolderPath}'");
            }
            if (config.ElementWaitingTimeout <= 0)
            {
                throw new ConfigException($"Czas oczekiwania na elementy na stronie musi być większy niż 0, aktualna wartość: '{config.ElementWaitingTimeout}'");
            }
        }
    }
}
