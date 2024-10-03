namespace WinFormsTestRunner.Utilities
{
    internal class Logger
    {
        private static ListView? _listView;
        private static readonly string _logsDirectoryPath;
        public static readonly string LogFilePath;

        static Logger()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            _logsDirectoryPath = Path.Combine(directoryInfo.Parent.FullName, "logs");
            LogFilePath = Path.Combine(_logsDirectoryPath, DateTime.Now.ToString("ddMMyyyy") + ".log");
            EnsureLogFileExists();
        }

        public static void InitializeListView(ListView listView)
        {
            _listView = listView;
        }

        // Log method with optional time and status
        public static void Log(string message, bool showTime = false, string? status = null)
        {
            string timestamp = showTime ? DateTime.Now.ToString("HH:mm:ss") : string.Empty;
            AddMessage(timestamp, message, status);
        }

        private static void AddMessage(string timestamp, string message, string? status = null)
        {
            // Log in application
            if (_listView != null)
            {
                void action() => AddMessageToListView(timestamp, message, status);
                if (_listView.InvokeRequired)
                {
                    _listView.Invoke(new Action(action));
                }
                else
                {
                    action();
                }
            }

            // Log to file
            WriteLogToFile(timestamp, message, status);
        }

        private static void AddMessageToListView(string timestamp, string message, string? status = null)
        {
            var listViewItem = timestamp != string.Empty ? new ListViewItem(timestamp) : new ListViewItem();
            listViewItem.SubItems.Add(message);
            if (status != null)
            {
                listViewItem.SubItems.Add(status);
            }
            _listView.Items.Add(listViewItem);
            _listView.EnsureVisible(_listView.Items.Count - 1);
        }

        private static void WriteLogToFile(string timestamp, string message, string? status = null)
        {
            string logMessage = timestamp != string.Empty ? $"{timestamp} - {message}" : message;
            if (status != null)
            {
                logMessage += $" - {status}";
            }
            logMessage += Environment.NewLine;

            try
            {
                File.AppendAllText(LogFilePath, logMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to log file: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void EnsureLogFileExists()
        {
            try
            {
                Directory.CreateDirectory(_logsDirectoryPath);
                if (!File.Exists(LogFilePath))
                {
                    File.Create(LogFilePath).Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating log file: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
