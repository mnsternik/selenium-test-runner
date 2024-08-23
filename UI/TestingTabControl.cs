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

            UIStateHandler.TestStatusChanged += OnTestStatusChanged;
            UIStateHandler.SetTestStatus("Oczekiwanie na wybór scenariusza");
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
                case "StopTestButton":
                    StopTestButton.Enabled = isEnabled;
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
            UIStateHandler.ButtonStateChanged -= OnButtonStateChanged;
        }

        private void ScenarioPathButton_Click(object sender, EventArgs e)
        {
            var scenarioPath = DialogFileHandler.GetFilePath("JSON files (*.json)|*.json|All files (*.*)|*.*");
            ScenarioPathText.Text = scenarioPath;

            TestRunner.CreateTestScenario(scenarioPath);
        }

        private async void StartTestButton_Click(object sender, EventArgs e)
        {
            UIStateHandler.SetButtonState("StartTestButton", false);
            UIStateHandler.SetButtonState("StopTestButton", true);
            UIStateHandler.SetButtonState("EndTestButton", true);
            UIStateHandler.SetButtonState("NextStepButton", false);
            UIStateHandler.SetButtonState("RetryStepButton", false);
            UIStateHandler.SetButtonState("ScenarioPathButton", false);

            await TestRunner.RunAsync(); 
        }

        private void StopTestButton_Click(object sender, EventArgs e)
        {
            UIStateHandler.SetButtonState("StartTestButton", true);
            UIStateHandler.SetButtonState("StopTestButton", false);
            UIStateHandler.SetButtonState("EndTestButton", true);
            UIStateHandler.SetButtonState("NextStepButton", true);
            UIStateHandler.SetButtonState("RetryStepButton", true);
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            UIStateHandler.SetButtonState("StartTestButton", true);
            UIStateHandler.SetButtonState("StopTestButton", false);
            UIStateHandler.SetButtonState("EndTestButton", false);
            UIStateHandler.SetButtonState("NextStepButton", false);
            UIStateHandler.SetButtonState("RetryStepButton", false);
            UIStateHandler.SetButtonState("ScenarioPathButton", true);
        }

        private void RetryStepButton_Click(object sender, EventArgs e)
        {
            UIStateHandler.SetButtonState("StartTestButton", false);
            UIStateHandler.SetButtonState("StopTestButton", true);
            UIStateHandler.SetButtonState("EndTestButton", true);
            UIStateHandler.SetButtonState("NextStepButton", false);
            UIStateHandler.SetButtonState("RetryStepButton", false);
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            UIStateHandler.SetButtonState("StartTestButton", false);
            UIStateHandler.SetButtonState("StopTestButton", true);
            UIStateHandler.SetButtonState("EndTestButton", true);
            UIStateHandler.SetButtonState("NextStepButton", false);
            UIStateHandler.SetButtonState("RetryStepButton", false);
        }

        private void InitializeButtonsState()
        {
            StartTestButton.Enabled = UIStateHandler.GetButtonState("StartTestButton");
            StopTestButton.Enabled = UIStateHandler.GetButtonState("StopTestButton");
            EndTestButton.Enabled = UIStateHandler.GetButtonState("EndTestButton");
            NextStepButton.Enabled = UIStateHandler.GetButtonState("NextStepButton");
            RetryStepButton.Enabled = UIStateHandler.GetButtonState("RetryStepButton");
            ScenarioPathButton.Enabled = UIStateHandler.GetButtonState("ScenarioPathButton");
        }

        private void InitializeButtonEvents()
        {
            UIStateHandler.ButtonStateChanged += OnButtonStateChanged;

            NextStepButton.Click += (s, e) => TestRunner.TriggerUserAction("ContinueStep");
            RetryStepButton.Click += (s, e) => TestRunner.TriggerUserAction("RetryStep");
            StopTestButton.Click += (s, e) => TestRunner.TriggerUserAction("StopTest");
        }
    }


}
