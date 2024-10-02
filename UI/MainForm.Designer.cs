namespace WinFormsTestRunner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            settingsTab = new TabPage();
            settingsTabControl1 = new SettingsTabControl();
            tab = new TabControl();
            testingTab = new TabPage();
            testingTabControl = new TestingTabControl();
            settingsTab.SuspendLayout();
            tab.SuspendLayout();
            testingTab.SuspendLayout();
            SuspendLayout();
            // 
            // settingsTab
            // 
            settingsTab.BackColor = Color.Transparent;
            settingsTab.Controls.Add(settingsTabControl1);
            settingsTab.Location = new Point(4, 24);
            settingsTab.Margin = new Padding(4, 3, 4, 3);
            settingsTab.Name = "settingsTab";
            settingsTab.Padding = new Padding(4, 3, 4, 3);
            settingsTab.Size = new Size(1220, 482);
            settingsTab.TabIndex = 1;
            settingsTab.Text = "Ustawienia";
            // 
            // settingsTabControl1
            // 
            settingsTabControl1.Location = new Point(3, 3);
            settingsTabControl1.Name = "settingsTabControl1";
            settingsTabControl1.Size = new Size(787, 477);
            settingsTabControl1.TabIndex = 0;
            // 
            // tab
            // 
            tab.Controls.Add(testingTab);
            tab.Controls.Add(settingsTab);
            tab.Location = new Point(-4, 0);
            tab.Margin = new Padding(4, 3, 4, 3);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(1125, 510);
            tab.TabIndex = 0;
            // 
            // testingTab
            // 
            testingTab.BackColor = SystemColors.Control;
            testingTab.Controls.Add(testingTabControl);
            testingTab.Location = new Point(4, 24);
            testingTab.Margin = new Padding(4, 3, 4, 3);
            testingTab.Name = "testingTab";
            testingTab.Padding = new Padding(4, 3, 4, 3);
            testingTab.Size = new Size(1117, 482);
            testingTab.TabIndex = 0;
            testingTab.Text = "Testowanie";
            // 
            // testingTabControl
            // 
            testingTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testingTabControl.AutoSize = true;
            testingTabControl.Location = new Point(0, 0);
            testingTabControl.Margin = new Padding(0);
            testingTabControl.Name = "testingTabControl";
            testingTabControl.Size = new Size(1109, 474);
            testingTabControl.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 507);
            Controls.Add(tab);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "TestRunner";
            settingsTab.ResumeLayout(false);
            tab.ResumeLayout(false);
            testingTab.ResumeLayout(false);
            testingTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabPage settingsTab;
        private SettingsTabControl settingsTabControl1;
        private TabControl tab;
        private TabPage testingTab;
        private TestingTabControl testingTabControl;
    }
}
