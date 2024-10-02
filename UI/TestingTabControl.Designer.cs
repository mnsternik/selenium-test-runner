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
            EndTestButton = new Button();
            RetryStepButton = new Button();
            NextStepButton = new Button();
            ScenarioPathButton = new Button();
            ScenarioPathText = new TextBox();
            StartTestButton = new Button();
            TestStatusText = new TextBox();
            TestStatusLabel = new Label();
            TestMessagesContainer = new ListView();
            StepCounterColumn = new ColumnHeader();
            StepNameColumn = new ColumnHeader();
            StepStatusColumn = new ColumnHeader();
            ScenarioPathLabel = new Label();
            OpenLogFileButton = new Button();
            SuspendLayout();
            // 
            // EndTestButton
            // 
            EndTestButton.Location = new Point(641, 443);
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
            RetryStepButton.Location = new Point(232, 443);
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
            NextStepButton.Location = new Point(415, 443);
            NextStepButton.Margin = new Padding(4, 3, 4, 3);
            NextStepButton.Name = "NextStepButton";
            NextStepButton.Size = new Size(218, 26);
            NextStepButton.TabIndex = 18;
            NextStepButton.Text = "Przejdź do kolejnego kroku";
            NextStepButton.UseVisualStyleBackColor = true;
            NextStepButton.Click += NextStepButton_Click;
            // 
            // ScenarioPathButton
            // 
            ScenarioPathButton.Location = new Point(13, 72);
            ScenarioPathButton.Margin = new Padding(4, 3, 4, 3);
            ScenarioPathButton.Name = "ScenarioPathButton";
            ScenarioPathButton.Size = new Size(120, 26);
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
            ScenarioPathText.Size = new Size(199, 23);
            ScenarioPathText.TabIndex = 15;
            // 
            // StartTestButton
            // 
            StartTestButton.Location = new Point(13, 183);
            StartTestButton.Margin = new Padding(4, 3, 4, 3);
            StartTestButton.Name = "StartTestButton";
            StartTestButton.Size = new Size(77, 26);
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
            TestStatusText.ReadOnly = true;
            TestStatusText.Size = new Size(199, 23);
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
            // TestMessagesContainer
            // 
            TestMessagesContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TestMessagesContainer.AutoArrange = false;
            TestMessagesContainer.Columns.AddRange(new ColumnHeader[] { StepCounterColumn, StepNameColumn, StepStatusColumn });
            TestMessagesContainer.FullRowSelect = true;
            TestMessagesContainer.LabelWrap = false;
            TestMessagesContainer.Location = new Point(232, 15);
            TestMessagesContainer.Name = "TestMessagesContainer";
            TestMessagesContainer.Size = new Size(874, 421);
            TestMessagesContainer.TabIndex = 22;
            TestMessagesContainer.UseCompatibleStateImageBehavior = false;
            TestMessagesContainer.View = View.Details;
            // 
            // StepCounterColumn
            // 
            StepCounterColumn.Text = "Czas";
            // 
            // StepNameColumn
            // 
            StepNameColumn.Text = "Nazwa kroku";
            StepNameColumn.Width = 750;
            // 
            // StepStatusColumn
            // 
            StepStatusColumn.Text = "Status";
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
            // OpenLogFileButton
            // 
            OpenLogFileButton.Location = new Point(103, 183);
            OpenLogFileButton.Name = "OpenLogFileButton";
            OpenLogFileButton.Size = new Size(109, 26);
            OpenLogFileButton.TabIndex = 23;
            OpenLogFileButton.Text = "Otwórz plik logu";
            OpenLogFileButton.UseVisualStyleBackColor = true;
            OpenLogFileButton.Click += OpenLogFileButton_Click;
            // 
            // TestingTabControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(OpenLogFileButton);
            Controls.Add(TestMessagesContainer);
            Controls.Add(EndTestButton);
            Controls.Add(RetryStepButton);
            Controls.Add(NextStepButton);
            Controls.Add(ScenarioPathButton);
            Controls.Add(ScenarioPathText);
            Controls.Add(ScenarioPathLabel);
            Controls.Add(StartTestButton);
            Controls.Add(TestStatusText);
            Controls.Add(TestStatusLabel);
            Name = "TestingTabControl";
            Size = new Size(1110, 476);
            Load += TestingTabControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button EndTestButton;
        private Button RetryStepButton;
        private Button NextStepButton;
        private Button ScenarioPathButton;
        private TextBox ScenarioPathText;
        private Button StartTestButton;
        private TextBox TestStatusText;
        private Label TestStatusLabel;
        private ListView TestMessagesContainer;
        private ColumnHeader StepCounterColumn;
        private ColumnHeader StepNameColumn;
        private ColumnHeader StepStatusColumn;
        private Label ScenarioPathLabel;
        private Button OpenLogFileButton;
    }
}
