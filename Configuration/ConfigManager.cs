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
            set => _config = value;
        }

        private static readonly string _configFileName;
        private static readonly string _configDirectoryPath;
        private static readonly string _configFilePath;

        static ConfigManager()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            _configFileName = "config.json";
            _configDirectoryPath = Path.Combine(directoryInfo.Parent.FullName, "config");
            _configFilePath = Path.Combine(_configDirectoryPath, _configFileName);
            EnsureConfigFileIsCreated();
        }

        private static void EnsureConfigFileIsCreated()
        {
            try
            {
                Directory.CreateDirectory(_configDirectoryPath);
                if (!File.Exists(_configFilePath))
                {
                    JSONFileHandler.Serialize(Config, _configFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas tworzenia pliku konfiguracyjnego: {ex.Message}", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadConfig()
        {
            Config = JSONFileHandler.Deserialize<Config>(_configFilePath);
        }

        public static void SaveConfig(Config config)
        {
            ValidateConfig(config);
            Config = config;
            JSONFileHandler.Serialize(Config, _configFilePath);
        }

        private static void ValidateConfig(Config config)
        {
            if (config == null)
            {
                throw new ConfigException($"Plik konfiguracyjny jest pusty lub nie istnieje. Sprawdzana lokalizacja: '{_configFilePath}'");
            }
            if (string.IsNullOrEmpty(config.DriverPath) || !File.Exists(config.DriverPath))
            {
                throw new ConfigException($"Wskazano błędną ścieżke do pliku geckodriver.exe w pliku konfiguracyjnym: '{config.DriverPath}'");
            }
            if (string.IsNullOrEmpty(config.FirefoxPath) || !File.Exists(config.FirefoxPath))
            {
                throw new ConfigException($"Wskazano błędną ścieżke do pliku firefox.exe w pliku konfiguracyjnym: '{config.FirefoxPath}'");
            }
            if (config.ElementWaitingTimeout <= 0)
            {
                throw new ConfigException($"Czas oczekiwania na elementy na stronie musi być większy niż 0, aktualna wartość: '{config.ElementWaitingTimeout}'");
            }
        }
    }
}
