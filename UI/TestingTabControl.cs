using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTestRunner.Utilities;
using WinFormsTestRunner.UI;
using System.Windows.Forms.VisualStyles;
using WinFormsTestRunner.Core;

namespace WinFormsTestRunner
{
    public partial class TestingTabControl : UserControl
    {
        //private string _scenarioPath = string.Empty; 

        public TestingTabControl()
        {
            InitializeComponent();
        }

        private void TestingTabControl_Load(object sender, EventArgs e)
        {
            InitializeButtonEvents();
            InitializeTestStatus();
            Logger.Initialize(TestMessagesContainer);
            TestingTabHandler.SetTestNotStartedMode();
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
            var scenarioPath = DialogFileHandler.GetFilePath("JSON files (*.json)|*.json|All files (*.*)|*.*");
            ScenarioPathText.Text = scenarioPath;
            //_scenarioPath = scenarioPath; 
            TestRunner.CreateTestScenario(scenarioPath);
        }

        private async void StartTestButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetTestStartedMode();
            //await TestRunner.RunAsync(_scenarioPath);
            await TestRunner.RunAsync();
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetTestNotStartedMode();
        }

        private void RetryStepButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetTestStartedMode();
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetTestStartedMode();
        }

        private void InitializeButtonEvents()
        {
            TestingTabHandler.ButtonStateChanged += OnButtonStateChanged;
            NextStepButton.Click += (s, e) => TestRunner.TriggerUserAction("NextStep");
            RetryStepButton.Click += (s, e) => TestRunner.TriggerUserAction("RetryStep");
            EndTestButton.Click += (s, e) => TestRunner.TriggerUserAction("EndTest");
        }

        private void InitializeTestStatus()
        {
            TestingTabHandler.TestStatusChanged += OnTestStatusChanged;
            TestingTabHandler.SetTestStatus("Oczekiwanie na wybór scenariusza");
        }
    }
}
