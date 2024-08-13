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
            testingTab = new TabPage();
            testingTabControl = new TestingTabControl();
            tab = new TabControl();
            settingsTab.SuspendLayout();
            testingTab.SuspendLayout();
            tab.SuspendLayout();
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
            settingsTab.Size = new Size(793, 483);
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
            // testingTab
            // 
            testingTab.BackColor = SystemColors.Control;
            testingTab.Controls.Add(testingTabControl);
            testingTab.Location = new Point(4, 24);
            testingTab.Margin = new Padding(4, 3, 4, 3);
            testingTab.Name = "testingTab";
            testingTab.Padding = new Padding(4, 3, 4, 3);
            testingTab.Size = new Size(793, 483);
            testingTab.TabIndex = 0;
            testingTab.Text = "Testowanie";
            // 
            // testingTabControl
            // 
            testingTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testingTabControl.AutoSize = true;
            testingTabControl.Location = new Point(4, 3);
            testingTabControl.Name = "testingTabControl";
            testingTabControl.Size = new Size(1005, 477);
            testingTabControl.TabIndex = 0;
            // 
            // tab
            // 
            tab.Controls.Add(testingTab);
            tab.Controls.Add(settingsTab);
            tab.Location = new Point(-4, -1);
            tab.Margin = new Padding(4, 3, 4, 3);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(801, 511);
            tab.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 507);
            Controls.Add(tab);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "TestRunner";
            settingsTab.ResumeLayout(false);
            testingTab.ResumeLayout(false);
            testingTab.PerformLayout();
            tab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage settingsTab;
        private SettingsTabControl settingsTabControl1;
        private TabPage testingTab;
        private TestingTabControl testingTabControl;
        private TabControl tab;
    }
}
