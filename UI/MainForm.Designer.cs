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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            settingsTab = new TabPage();
            settingsTabControl1 = new SettingsTabControl();
            testingTab = new TabPage();
            testingTabControl = new TestingTabControl();
            tab = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            StepNumberColumn = new DataGridViewTextBoxColumn();
            StepNameColumn = new DataGridViewTextBoxColumn();
            StepStatusColumn = new DataGridViewTextBoxColumn();
            settingsTab.SuspendLayout();
            testingTab.SuspendLayout();
            tab.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            testingTabControl.Size = new Size(787, 477);
            testingTabControl.TabIndex = 0;
            // 
            // tab
            // 
            tab.Controls.Add(testingTab);
            tab.Controls.Add(settingsTab);
            tab.Controls.Add(tabPage1);
            tab.Location = new Point(-4, -1);
            tab.Margin = new Padding(4, 3, 4, 3);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(801, 511);
            tab.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(793, 483);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { StepNumberColumn, StepNameColumn, StepStatusColumn });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(106, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Size = new Size(569, 420);
            dataGridView1.TabIndex = 0;
            // 
            // StepNumberColumn
            // 
            StepNumberColumn.HeaderText = "Krok";
            StepNumberColumn.Name = "StepNumberColumn";
            StepNumberColumn.ReadOnly = true;
            StepNumberColumn.Width = 75;
            // 
            // StepNameColumn
            // 
            StepNameColumn.HeaderText = "Nazwa";
            StepNameColumn.Name = "StepNameColumn";
            StepNameColumn.ReadOnly = true;
            StepNameColumn.Width = 376;
            // 
            // StepStatusColumn
            // 
            StepStatusColumn.HeaderText = "Status";
            StepStatusColumn.Name = "StepStatusColumn";
            StepStatusColumn.ReadOnly = true;
            StepStatusColumn.Width = 75;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 507);
            Controls.Add(tab);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "TestRunner";
            settingsTab.ResumeLayout(false);
            testingTab.ResumeLayout(false);
            testingTab.PerformLayout();
            tab.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage settingsTab;
        private SettingsTabControl settingsTabControl1;
        private TabPage testingTab;
        private TestingTabControl testingTabControl;
        private TabControl tab;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn StepNumberColumn;
        private DataGridViewTextBoxColumn StepNameColumn;
        private DataGridViewTextBoxColumn StepStatusColumn;
    }
}
