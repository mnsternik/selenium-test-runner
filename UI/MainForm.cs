using WinFormsTestRunner.Configuration;
using WinFormsTestRunner.Exceptions;

namespace WinFormsTestRunner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            try
            {
                ConfigManager.LoadConfig();
            }
            catch (ConfigException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� nieoczekiwany b��d: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitializeComponent();
        }
    }
}
