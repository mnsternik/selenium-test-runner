using WinFormsTestRunner.Configuration;
using WinFormsTestRunner.Utilities;

namespace WinFormsTestRunner
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        // Handles UI thread exceptions
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        // Handles non-UI thread exceptions
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        static void HandleException(Exception ex)
        {
            if (!string.IsNullOrEmpty(ConfigManager.Config.LogsFolderPath))
            {
                Logger.Log($"Wyst¹pi³ nieoczekiwany b³¹d: {ex.Message}"); // or write only to file?
            }
            MessageBox.Show($"Wyst¹pi³ nieoczekiwany b³¹d: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}