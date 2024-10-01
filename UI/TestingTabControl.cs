using WinFormsTestRunner.Utilities;
using WinFormsTestRunner.UI;
using WinFormsTestRunner.Core;
using System.Diagnostics;

namespace WinFormsTestRunner
{
    public partial class TestingTabControl : UserControl
    {
        public TestingTabControl()
        {
            InitializeComponent();
        }

        private void TestingTabControl_Load(object sender, EventArgs e)
        {
            InitializeEvents();

            Logger.InitializeListView(TestMessagesContainer);

            TestingTabHandler.SetAfterAppInitMode();
        }

        private void OnButtonStateChanged(string buttonName, bool isEnabled)
        {
            // Przypadek odwoływania się do kontrolki z innego wątku, niż ten w którym została stworzona
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnButtonStateChanged(buttonName, isEnabled)));
                return;
            }

            switch (buttonName)
            {
                case "StartTestButton":
                    StartTestButton.Enabled = isEnabled;
                    break;
                case "EndTestButton":
                    EndTestButton.Enabled = isEnabled;
                    break;
                case "NextStepButton":
                    NextStepButton.Enabled = isEnabled;
                    break;
                case "RetryStepButton":
                    RetryStepButton.Enabled = isEnabled;
                    break;
                case "ScenarioPathButton":
                    ScenarioPathButton.Enabled = isEnabled;
                    break;
                case "OpenLogFileButton":
                    OpenLogFileButton.Enabled = isEnabled;
                    break;
            }
        }

        private void OnTestStatusChanged(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnTestStatusChanged(status)));
                return;
            }

            TestStatusText.Text = status;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TestingTabHandler.ButtonStateChanged -= OnButtonStateChanged;
        }

        private void ScenarioPathButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string initialDirectory  = Path.Combine(directoryInfo.Parent.FullName, "scenarios");
            var scenarioPath = DialogFileHandler.GetFilePath("JSON files (*.json)|*.json|All files (*.*)|*.*", initialDirectory);
            if (!string.IsNullOrEmpty(scenarioPath))
            {
                ScenarioPathText.Text = scenarioPath;
                TestRunner.LoadScenario(scenarioPath);
            }
        }

        private async void StartTestButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetDuringTestMode();
            await TestRunner.RunAsync();
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetAfterTestEndedMode();
        }

        private void RetryStepButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetDuringTestMode();
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetDuringTestMode();
        }

        private void OpenLogFileButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Logger.LogFilePath,
                UseShellExecute = true 
            });
        }

        private void InitializeEvents()
        {
            TestingTabHandler.ButtonStateChanged += OnButtonStateChanged;
            TestingTabHandler.TestStatusChanged += OnTestStatusChanged;

            NextStepButton.Click += (s, e) => TestRunner.TriggerUserAction("NextStep");
            RetryStepButton.Click += (s, e) => TestRunner.TriggerUserAction("RetryStep");
            EndTestButton.Click += (s, e) => TestRunner.TriggerUserAction("EndTest");
        }
    }
}
