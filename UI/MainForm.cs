using WinFormsTestRunner.Configuration;

namespace WinFormsTestRunner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            ConfigManager.LoadConfig();
            InitializeComponent();
        }
    }
}
