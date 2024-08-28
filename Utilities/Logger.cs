using System;
using System.IO;
using System.Windows.Forms;
using WinFormsTestRunner.Configuration;

namespace WinFormsTestRunner.Utilities
{
    internal class Logger
    {
        private static ListView? _listView;
        private static readonly string _logsDirectoryPath;
        private static readonly string _logFilePath;

        static Logger()
        {
            _logsDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            _logFilePath = Path.Combine(_logsDirectoryPath, DateTime.Now.ToString("ddMMyyyy") + ".log");
            EnsureLogFileExists();
        }

        public static void InitializeListView(ListView listView)
        {
            _listView = listView;
        }

        public static void Log(string message, bool isSuccess)
        {
            AddMessage(message, isSuccess ? "Sukces" : "Błąd");
        }

        public static void Log(string message)
        {
            AddMessage(message);
        }

        private static void AddMessage(string message, string? status = null)
        {
            // Logowanie w aplikacji
            if (_listView != null)
            {
                if (_listView.InvokeRequired)
                {
                    _listView.Invoke(new Action(() => AddMessageToListView(message, status)));
                }
                else
                {
                    AddMessageToListView(message, status);
                }
            }

            // Logowanie do pliku
            WriteLogToFile(message, status);
        }

        private static void AddMessageToListView(string message, string? status = null)
        {
            var listViewItem = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"))
            {
                SubItems = { message }
            };

            if (status != null)
            {
                listViewItem.SubItems.Add(status);
            }

            _listView.Items.Add(listViewItem);
            _listView.EnsureVisible(_listView.Items.Count - 1);
        }

        private static void WriteLogToFile(string message, string? status = null)
        {
            string logMessage = $"{DateTime.Now:HH:mm:ss} - {message}";

            if (status != null)
            {
                logMessage += $" - {status}";
            }

            logMessage += Environment.NewLine;

            try
            {
                File.AppendAllText(_logFilePath, logMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania do pliku logu: {ex.Message}", "Log error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void EnsureLogFileExists()
        {
            try
            {
                Directory.CreateDirectory(_logsDirectoryPath);
                if (!File.Exists(_logFilePath))
                {
                    File.Create(_logFilePath).Dispose(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas tworzenia pliku logu: {ex.Message}", "Log error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}