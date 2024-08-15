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

namespace WinFormsTestRunner
{
    public partial class TestingTabControl : UserControl
    {
        public TestingTabControl()
        {
            InitializeComponent();

            ButtonsStateHandler.ButtonStateChanged += OnButtonStateChanged;

            Logger.Initialize(TestMessagesContainer);

            StartTestButton.Enabled = ButtonsStateHandler.GetButtonState("StartTestButton");
            StopTestButton.Enabled = ButtonsStateHandler.GetButtonState("StopTestButton");
            EndTestButton.Enabled = ButtonsStateHandler.GetButtonState("EndTestButton");
            NextStepButton.Enabled = ButtonsStateHandler.GetButtonState("NextStepButton");
            RetryStepButton.Enabled = ButtonsStateHandler.GetButtonState("RetryStepButton");
            ScenarioPathButton.Enabled = ButtonsStateHandler.GetButtonState("ScenarioPathButton");
        }

        private void OnButtonStateChanged(string buttonName, bool isEnabled)
        {
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ButtonsStateHandler.ButtonStateChanged -= OnButtonStateChanged;
        }

        private void ScenarioPathButton_Click(object sender, EventArgs e)
        {
            var scenarioPath = DialogFileHandler.GetFilePath("JSON files (*.json)|*.json|All files (*.*)|*.*");
            ScenarioPathText.Text = scenarioPath;
        }

        private void StartTestButton_Click(object sender, EventArgs e)
        {
            ButtonsStateHandler.SetButtonState("StartTestButton", false);
            ButtonsStateHandler.SetButtonState("StopTestButton", true);
            ButtonsStateHandler.SetButtonState("EndTestButton", true);
            ButtonsStateHandler.SetButtonState("NextStepButton", false);
            ButtonsStateHandler.SetButtonState("RetryStepButton", false);
            ButtonsStateHandler.SetButtonState("ScenarioPathButton", false);

            // Logic
            Logger.Log("Start został kilknięty", true);
        }

        private void StopTestButton_Click(object sender, EventArgs e)
        {
            ButtonsStateHandler.SetButtonState("StartTestButton", true);
            ButtonsStateHandler.SetButtonState("StopTestButton", false);
            ButtonsStateHandler.SetButtonState("EndTestButton", true);
            ButtonsStateHandler.SetButtonState("NextStepButton", true);
            ButtonsStateHandler.SetButtonState("RetryStepButton", true);

            Logger.Log("Przycisk o nazwie Stop został pomyślnie kilknięty, i wszystkie inne akcje związane z tym eventem również zostały zakończone pomyślnie. ", true);

            // Logic
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            ButtonsStateHandler.SetButtonState("StartTestButton", true);
            ButtonsStateHandler.SetButtonState("StopTestButton", false);
            ButtonsStateHandler.SetButtonState("EndTestButton", false);
            ButtonsStateHandler.SetButtonState("NextStepButton", false);
            ButtonsStateHandler.SetButtonState("RetryStepButton", false);
            ButtonsStateHandler.SetButtonState("ScenarioPathButton", true);

            // Logic
        }

        private void RetryStepButton_Click(object sender, EventArgs e)
        {
            ButtonsStateHandler.SetButtonState("StartTestButton", false);
            ButtonsStateHandler.SetButtonState("StopTestButton", true);
            ButtonsStateHandler.SetButtonState("EndTestButton", true);
            ButtonsStateHandler.SetButtonState("NextStepButton", false);
            ButtonsStateHandler.SetButtonState("RetryStepButton", false);
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            ButtonsStateHandler.SetButtonState("StartTestButton", false);
            ButtonsStateHandler.SetButtonState("StopTestButton", true);
            ButtonsStateHandler.SetButtonState("EndTestButton", true);
            ButtonsStateHandler.SetButtonState("NextStepButton", false);
            ButtonsStateHandler.SetButtonState("RetryStepButton", false);
        }
    }


}
