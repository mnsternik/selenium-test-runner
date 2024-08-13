using WinFormsTestRunner.Configuration;

namespace WinFormsTestRunner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            ConfigManager.LoadConfig(); 
        }
    }
}
