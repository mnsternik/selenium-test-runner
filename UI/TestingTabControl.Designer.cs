namespace WinFormsTestRunner
{
    partial class TestingTabControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StopTestButton = new Button();
            EndTestButton = new Button();
            RetryStepButton = new Button();
            NextStepButton = new Button();
            TestMessagesContainer = new ListView();
            ScenarioPathButton = new Button();
            ScenarioPathText = new TextBox();
            ScenarioPathLabel = new Label();
            StartTestButton = new Button();
            TestStatusText = new TextBox();
            TestStatusLabel = new Label();
            SuspendLayout();
            // 
            // StopTestButton
            // 
            StopTestButton.Location = new Point(103, 183);
            StopTestButton.Margin = new Padding(4, 3, 4, 3);
            StopTestButton.Name = "StopTestButton";
            StopTestButton.Size = new Size(78, 26);
            StopTestButton.TabIndex = 21;
            StopTestButton.Text = "Zatrzymaj";
            StopTestButton.UseVisualStyleBackColor = true;
            StopTestButton.Click += StopTestButton_Click;
            // 
            // EndTestButton
            // 
            EndTestButton.Location = new Point(593, 442);
            EndTestButton.Margin = new Padding(4, 3, 4, 3);
            EndTestButton.Name = "EndTestButton";
            EndTestButton.Size = new Size(190, 26);
            EndTestButton.TabIndex = 20;
            EndTestButton.Text = "Zakończ wykonywanie scenariusza";
            EndTestButton.UseVisualStyleBackColor = true;
            EndTestButton.Click += EndTestButton_Click;
            // 
            // RetryStepButton
            // 
            RetryStepButton.Location = new Point(209, 442);
            RetryStepButton.Margin = new Padding(4, 3, 4, 3);
            RetryStepButton.Name = "RetryStepButton";
            RetryStepButton.Size = new Size(175, 26);
            RetryStepButton.TabIndex = 19;
            RetryStepButton.Text = "Wykonaj krok ponownie";
            RetryStepButton.UseVisualStyleBackColor = true;
            RetryStepButton.Click += RetryStepButton_Click;
            // 
            // NextStepButton
            // 
            NextStepButton.Location = new Point(391, 442);
            NextStepButton.Margin = new Padding(4, 3, 4, 3);
            NextStepButton.Name = "NextStepButton";
            NextStepButton.Size = new Size(194, 26);
            NextStepButton.TabIndex = 18;
            NextStepButton.Text = "Przejdź do kolejnego kroku";
            NextStepButton.UseVisualStyleBackColor = true;
            NextStepButton.Click += NextStepButton_Click;
            // 
            // TestMessagesContainer
            // 
            TestMessagesContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TestMessagesContainer.Location = new Point(209, 11);
            TestMessagesContainer.Margin = new Padding(4, 3, 4, 3);
            TestMessagesContainer.Name = "TestMessagesContainer";
            TestMessagesContainer.Size = new Size(579, 420);
            TestMessagesContainer.TabIndex = 17;
            TestMessagesContainer.UseCompatibleStateImageBehavior = false;
            // 
            // ScenarioPathButton
            // 
            ScenarioPathButton.Location = new Point(13, 72);
            ScenarioPathButton.Margin = new Padding(4, 3, 4, 3);
            ScenarioPathButton.Name = "ScenarioPathButton";
            ScenarioPathButton.Size = new Size(171, 26);
            ScenarioPathButton.TabIndex = 16;
            ScenarioPathButton.Text = "Wybierz scenariusz";
            ScenarioPathButton.UseVisualStyleBackColor = true;
            ScenarioPathButton.Click += ScenarioPathButton_Click;
            // 
            // ScenarioPathText
            // 
            ScenarioPathText.Location = new Point(13, 39);
            ScenarioPathText.Margin = new Padding(4, 3, 4, 3);
            ScenarioPathText.Name = "ScenarioPathText";
            ScenarioPathText.Size = new Size(168, 23);
            ScenarioPathText.TabIndex = 15;
            // 
            // ScenarioPathLabel
            // 
            ScenarioPathLabel.AutoSize = true;
            ScenarioPathLabel.Location = new Point(13, 15);
            ScenarioPathLabel.Margin = new Padding(4, 0, 4, 0);
            ScenarioPathLabel.Name = "ScenarioPathLabel";
            ScenarioPathLabel.Size = new Size(109, 15);
            ScenarioPathLabel.TabIndex = 14;
            ScenarioPathLabel.Text = "Scenariusz testowy:";
            // 
            // StartTestButton
            // 
            StartTestButton.Location = new Point(13, 183);
            StartTestButton.Margin = new Padding(4, 3, 4, 3);
            StartTestButton.Name = "StartTestButton";
            StartTestButton.Size = new Size(87, 26);
            StartTestButton.TabIndex = 13;
            StartTestButton.Text = "Uruchom";
            StartTestButton.UseVisualStyleBackColor = true;
            StartTestButton.Click += StartTestButton_Click;
            // 
            // TestStatusText
            // 
            TestStatusText.Location = new Point(13, 150);
            TestStatusText.Margin = new Padding(4, 3, 4, 3);
            TestStatusText.Name = "TestStatusText";
            TestStatusText.Size = new Size(168, 23);
            TestStatusText.TabIndex = 12;
            // 
            // TestStatusLabel
            // 
            TestStatusLabel.AutoSize = true;
            TestStatusLabel.Location = new Point(13, 130);
            TestStatusLabel.Margin = new Padding(4, 0, 4, 0);
            TestStatusLabel.Name = "TestStatusLabel";
            TestStatusLabel.Size = new Size(42, 15);
            TestStatusLabel.TabIndex = 11;
            TestStatusLabel.Text = "Status:";
            // 
            // TestingTabControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(StopTestButton);
            Controls.Add(EndTestButton);
            Controls.Add(RetryStepButton);
            Controls.Add(NextStepButton);
            Controls.Add(TestMessagesContainer);
            Controls.Add(ScenarioPathButton);
            Controls.Add(ScenarioPathText);
            Controls.Add(ScenarioPathLabel);
            Controls.Add(StartTestButton);
            Controls.Add(TestStatusText);
            Controls.Add(TestStatusLabel);
            Name = "TestingTabControl";
            Size = new Size(792, 476);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StopTestButton;
        private Button EndTestButton;
        private Button RetryStepButton;
        private Button NextStepButton;
        private ListView TestMessagesContainer;
        private Button ScenarioPathButton;
        private TextBox ScenarioPathText;
        private Label ScenarioPathLabel;
        private Button StartTestButton;
        private TextBox TestStatusText;
        private Label TestStatusLabel;
    }
}
