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
        public TestingTabControl()
        {
            InitializeComponent();
            InitializeButtonsState();
            InitializeButtonEvents(); 
            Logger.Initialize(TestMessagesContainer);

            TestingTabHandler.TestStatusChanged += OnTestStatusChanged;
            TestingTabHandler.SetTestStatus("Oczekiwanie na wybór scenariusza");
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

            TestRunner.CreateTestScenario(scenarioPath);
        }

        private async void StartTestButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetButtonState("StartTestButton", false);
            TestingTabHandler.SetButtonState("EndTestButton", true);
            TestingTabHandler.SetButtonState("NextStepButton", false);
            TestingTabHandler.SetButtonState("RetryStepButton", false);
            TestingTabHandler.SetButtonState("ScenarioPathButton", false);

            await TestRunner.RunAsync(); 
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetButtonState("StartTestButton", true);
            TestingTabHandler.SetButtonState("EndTestButton", false);
            TestingTabHandler.SetButtonState("NextStepButton", false);
            TestingTabHandler.SetButtonState("RetryStepButton", false);
            TestingTabHandler.SetButtonState("ScenarioPathButton", true);
        }

        private void RetryStepButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetButtonState("StartTestButton", false);
            TestingTabHandler.SetButtonState("EndTestButton", true);
            TestingTabHandler.SetButtonState("NextStepButton", false);
            TestingTabHandler.SetButtonState("RetryStepButton", false);
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            TestingTabHandler.SetButtonState("StartTestButton", false);
            TestingTabHandler.SetButtonState("EndTestButton", true);
            TestingTabHandler.SetButtonState("NextStepButton", false);
            TestingTabHandler.SetButtonState("RetryStepButton", false);
        }

        private void InitializeButtonsState()
        {
            StartTestButton.Enabled = TestingTabHandler.GetButtonState("StartTestButton");
            EndTestButton.Enabled = TestingTabHandler.GetButtonState("EndTestButton");
            NextStepButton.Enabled = TestingTabHandler.GetButtonState("NextStepButton");
            RetryStepButton.Enabled = TestingTabHandler.GetButtonState("RetryStepButton");
            ScenarioPathButton.Enabled = TestingTabHandler.GetButtonState("ScenarioPathButton");
        }

        private void InitializeButtonEvents()
        {
            TestingTabHandler.ButtonStateChanged += OnButtonStateChanged;

            NextStepButton.Click += (s, e) => TestRunner.TriggerUserAction("ContinueStep");
            RetryStepButton.Click += (s, e) => TestRunner.TriggerUserAction("RetryStep");
            EndTestButton.Click += (s, e) => TestRunner.TriggerUserAction("EndTest");
        }
    }


}
