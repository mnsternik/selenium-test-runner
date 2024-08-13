namespace WinFormsTestRunner
{
    partial class SettingsTabControl
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
            SaveConfigButton = new Button();
            WaitingTimeoutText = new TextBox();
            WaitingTimeoutLabel = new Label();
            LogsPathButton = new Button();
            LogsPathText = new TextBox();
            LogsPathLabel = new Label();
            BrowserPathButton = new Button();
            BrowserPathText = new TextBox();
            BrowserPathLabel = new Label();
            DriverPathButton = new Button();
            DriverPathText = new TextBox();
            DriverPathLabel = new Label();
            ConfigPathButton = new Button();
            ConfigPathText = new TextBox();
            ConfigPathLabel = new Label();
            EditConfigButton = new Button();
            CancelEditConfigButton = new Button();
            ConfigContentLabel = new Label();
            SuspendLayout();
            // 
            // SaveConfigButton
            // 
            SaveConfigButton.Location = new Point(194, 379);
            SaveConfigButton.Margin = new Padding(4, 3, 4, 3);
            SaveConfigButton.Name = "SaveConfigButton";
            SaveConfigButton.Size = new Size(116, 26);
            SaveConfigButton.TabIndex = 29;
            SaveConfigButton.Text = "Zapisz zmiany";
            SaveConfigButton.UseVisualStyleBackColor = true;
            SaveConfigButton.Click += SaveConfigButton_Click;
            // 
            // WaitingTimeoutText
            // 
            WaitingTimeoutText.Location = new Point(15, 341);
            WaitingTimeoutText.Margin = new Padding(4, 3, 4, 3);
            WaitingTimeoutText.Name = "WaitingTimeoutText";
            WaitingTimeoutText.Size = new Size(392, 23);
            WaitingTimeoutText.TabIndex = 28;
            WaitingTimeoutText.TextChanged += WaitingTimeoutText_TextChanged;
            // 
            // WaitingTimeoutLabel
            // 
            WaitingTimeoutLabel.AutoSize = true;
            WaitingTimeoutLabel.Location = new Point(15, 320);
            WaitingTimeoutLabel.Margin = new Padding(4, 0, 4, 0);
            WaitingTimeoutLabel.Name = "WaitingTimeoutLabel";
            WaitingTimeoutLabel.Size = new Size(240, 15);
            WaitingTimeoutLabel.TabIndex = 27;
            WaitingTimeoutLabel.Text = "Czas oczekiwania na elementy na stronie (s):";
            // 
            // LogsPathButton
            // 
            LogsPathButton.Location = new Point(412, 278);
            LogsPathButton.Margin = new Padding(4, 3, 4, 3);
            LogsPathButton.Name = "LogsPathButton";
            LogsPathButton.Size = new Size(74, 26);
            LogsPathButton.TabIndex = 26;
            LogsPathButton.Text = "Wybierz";
            LogsPathButton.UseVisualStyleBackColor = true;
            LogsPathButton.Click += LogsPathButton_Click;
            // 
            // LogsPathText
            // 
            LogsPathText.Location = new Point(15, 278);
            LogsPathText.Margin = new Padding(4, 3, 4, 3);
            LogsPathText.Name = "LogsPathText";
            LogsPathText.Size = new Size(392, 23);
            LogsPathText.TabIndex = 25;
            // 
            // LogsPathLabel
            // 
            LogsPathLabel.AutoSize = true;
            LogsPathLabel.Location = new Point(15, 258);
            LogsPathLabel.Margin = new Padding(4, 0, 4, 0);
            LogsPathLabel.Name = "LogsPathLabel";
            LogsPathLabel.Size = new Size(162, 15);
            LogsPathLabel.TabIndex = 24;
            LogsPathLabel.Text = "Ścieżka do katalogu z logami:";
            // 
            // BrowserPathButton
            // 
            BrowserPathButton.Location = new Point(412, 216);
            BrowserPathButton.Margin = new Padding(4, 3, 4, 3);
            BrowserPathButton.Name = "BrowserPathButton";
            BrowserPathButton.Size = new Size(74, 26);
            BrowserPathButton.TabIndex = 23;
            BrowserPathButton.Text = "Wybierz";
            BrowserPathButton.UseVisualStyleBackColor = true;
            BrowserPathButton.Click += BrowserPathButton_Click;
            // 
            // BrowserPathText
            // 
            BrowserPathText.Location = new Point(15, 216);
            BrowserPathText.Margin = new Padding(4, 3, 4, 3);
            BrowserPathText.Name = "BrowserPathText";
            BrowserPathText.Size = new Size(392, 23);
            BrowserPathText.TabIndex = 22;
            // 
            // BrowserPathLabel
            // 
            BrowserPathLabel.AutoSize = true;
            BrowserPathLabel.Location = new Point(15, 196);
            BrowserPathLabel.Margin = new Padding(4, 0, 4, 0);
            BrowserPathLabel.Name = "BrowserPathLabel";
            BrowserPathLabel.Size = new Size(152, 15);
            BrowserPathLabel.TabIndex = 21;
            BrowserPathLabel.Text = "Ścieżka do pliku firefox.exe:";
            // 
            // DriverPathButton
            // 
            DriverPathButton.Location = new Point(412, 151);
            DriverPathButton.Margin = new Padding(4, 3, 4, 3);
            DriverPathButton.Name = "DriverPathButton";
            DriverPathButton.Size = new Size(74, 26);
            DriverPathButton.TabIndex = 20;
            DriverPathButton.Text = "Wybierz";
            DriverPathButton.UseVisualStyleBackColor = true;
            DriverPathButton.Click += DriverPathButton_Click;
            // 
            // DriverPathText
            // 
            DriverPathText.Location = new Point(15, 152);
            DriverPathText.Margin = new Padding(4, 3, 4, 3);
            DriverPathText.Name = "DriverPathText";
            DriverPathText.Size = new Size(392, 23);
            DriverPathText.TabIndex = 19;
            // 
            // DriverPathLabel
            // 
            DriverPathLabel.AutoSize = true;
            DriverPathLabel.Location = new Point(15, 131);
            DriverPathLabel.Margin = new Padding(4, 0, 4, 0);
            DriverPathLabel.Name = "DriverPathLabel";
            DriverPathLabel.Size = new Size(180, 15);
            DriverPathLabel.TabIndex = 18;
            DriverPathLabel.Text = "Ścieżka do pliku geckodriver.exe:";
            // 
            // ConfigPathButton
            // 
            ConfigPathButton.Location = new Point(412, 41);
            ConfigPathButton.Margin = new Padding(4, 3, 4, 3);
            ConfigPathButton.Name = "ConfigPathButton";
            ConfigPathButton.Size = new Size(74, 26);
            ConfigPathButton.TabIndex = 17;
            ConfigPathButton.Text = "Wybierz";
            ConfigPathButton.UseVisualStyleBackColor = true;
            ConfigPathButton.Click += ConfigPathButton_Click;
            // 
            // ConfigPathText
            // 
            ConfigPathText.Location = new Point(15, 43);
            ConfigPathText.Margin = new Padding(4, 3, 4, 3);
            ConfigPathText.Name = "ConfigPathText";
            ConfigPathText.Size = new Size(392, 23);
            ConfigPathText.TabIndex = 16;
            // 
            // ConfigPathLabel
            // 
            ConfigPathLabel.AutoSize = true;
            ConfigPathLabel.Location = new Point(15, 23);
            ConfigPathLabel.Margin = new Padding(4, 0, 4, 0);
            ConfigPathLabel.Name = "ConfigPathLabel";
            ConfigPathLabel.Size = new Size(190, 15);
            ConfigPathLabel.TabIndex = 15;
            ConfigPathLabel.Text = "Ścieżka do pliku konfiguracyjnego:";
            // 
            // EditConfigButton
            // 
            EditConfigButton.Location = new Point(15, 379);
            EditConfigButton.Name = "EditConfigButton";
            EditConfigButton.Size = new Size(75, 26);
            EditConfigButton.TabIndex = 30;
            EditConfigButton.Text = "Edytuj";
            EditConfigButton.UseVisualStyleBackColor = true;
            // 
            // CancelEditConfigButton
            // 
            CancelEditConfigButton.Location = new Point(96, 379);
            CancelEditConfigButton.Name = "CancelEditConfigButton";
            CancelEditConfigButton.Size = new Size(91, 26);
            CancelEditConfigButton.TabIndex = 31;
            CancelEditConfigButton.Text = "Anuluj";
            CancelEditConfigButton.UseVisualStyleBackColor = true;
            // 
            // ConfigContentLabel
            // 
            ConfigContentLabel.AutoSize = true;
            ConfigContentLabel.Font = new Font("Segoe UI", 12F);
            ConfigContentLabel.Location = new Point(15, 87);
            ConfigContentLabel.Name = "ConfigContentLabel";
            ConfigContentLabel.Size = new Size(244, 21);
            ConfigContentLabel.TabIndex = 32;
            ConfigContentLabel.Text = "Zawartość pliku konfiguracyjnego";
            // 
            // SettingsTabControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ConfigContentLabel);
            Controls.Add(CancelEditConfigButton);
            Controls.Add(EditConfigButton);
            Controls.Add(SaveConfigButton);
            Controls.Add(WaitingTimeoutText);
            Controls.Add(WaitingTimeoutLabel);
            Controls.Add(LogsPathButton);
            Controls.Add(LogsPathText);
            Controls.Add(LogsPathLabel);
            Controls.Add(BrowserPathButton);
            Controls.Add(BrowserPathText);
            Controls.Add(BrowserPathLabel);
            Controls.Add(DriverPathButton);
            Controls.Add(DriverPathText);
            Controls.Add(DriverPathLabel);
            Controls.Add(ConfigPathButton);
            Controls.Add(ConfigPathText);
            Controls.Add(ConfigPathLabel);
            Name = "SettingsTabControl";
            Size = new Size(792, 476);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveConfigButton;
        private TextBox WaitingTimeoutText;
        private Label WaitingTimeoutLabel;
        private Button LogsPathButton;
        private TextBox LogsPathText;
        private Label LogsPathLabel;
        private Button BrowserPathButton;
        private TextBox BrowserPathText;
        private Label BrowserPathLabel;
        private Button DriverPathButton;
        private TextBox DriverPathText;
        private Label DriverPathLabel;
        private Button ConfigPathButton;
        private TextBox ConfigPathText;
        private Label ConfigPathLabel;
        private Button EditConfigButton;
        private Button CancelEditConfigButton;
        private Label ConfigContentLabel;
    }
}
