
namespace FraxMemoryEditor
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.processComboBox = new System.Windows.Forms.ComboBox();
            this.attachedLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.processLabel = new System.Windows.Forms.Label();
            this.searchValuePanel = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.valueLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.searchPanelLabel = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.ListView();
            this.Address = new System.Windows.Forms.ColumnHeader();
            this.Value = new System.Windows.Forms.ColumnHeader();
            this.resultMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeValueStripItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeValueStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countLabel = new System.Windows.Forms.Label();
            this.savedValuesBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.savedMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.freezeMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedValuesLabel = new System.Windows.Forms.Label();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.FreezeTimer = new System.Windows.Forms.Timer(this.components);
            this.searchValuePanel.SuspendLayout();
            this.resultMenuStrip.SuspendLayout();
            this.savedMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // processComboBox
            // 
            this.processComboBox.FormattingEnabled = true;
            this.processComboBox.Location = new System.Drawing.Point(26, 40);
            this.processComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.processComboBox.Name = "processComboBox";
            this.processComboBox.Size = new System.Drawing.Size(240, 23);
            this.processComboBox.TabIndex = 1;
            this.processComboBox.DropDown += new System.EventHandler(this.UpdateProcessList);
            this.processComboBox.SelectedIndexChanged += new System.EventHandler(this.ProcessChanged);
            // 
            // attachedLabel
            // 
            this.attachedLabel.AutoSize = true;
            this.attachedLabel.BackColor = System.Drawing.Color.Transparent;
            this.attachedLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attachedLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.attachedLabel.Location = new System.Drawing.Point(268, 43);
            this.attachedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.attachedLabel.Name = "attachedLabel";
            this.attachedLabel.Size = new System.Drawing.Size(94, 19);
            this.attachedLabel.TabIndex = 2;
            this.attachedLabel.Text = "DEATTACHED";
            // 
            // typeComboBox
            // 
            this.typeComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Int8",
            "Int16",
            "Int32",
            "Int64",
            "UInt8",
            "UInt16",
            "UInt32",
            "UInt64",
            "Float",
            "Double"});
            this.typeComboBox.Location = new System.Drawing.Point(21, 90);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(116, 25);
            this.typeComboBox.TabIndex = 3;
            // 
            // scanButton
            // 
            this.scanButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scanButton.Location = new System.Drawing.Point(21, 225);
            this.scanButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(171, 50);
            this.scanButton.TabIndex = 4;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButtonClicked);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.valueTextBox.Location = new System.Drawing.Point(21, 154);
            this.valueTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(235, 25);
            this.valueTextBox.TabIndex = 5;
            // 
            // processLabel
            // 
            this.processLabel.AutoSize = true;
            this.processLabel.BackColor = System.Drawing.Color.Transparent;
            this.processLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.processLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.processLabel.Location = new System.Drawing.Point(25, 21);
            this.processLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(59, 19);
            this.processLabel.TabIndex = 6;
            this.processLabel.Text = "Process:";
            // 
            // searchValuePanel
            // 
            this.searchValuePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.searchValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchValuePanel.Controls.Add(this.resetButton);
            this.searchValuePanel.Controls.Add(this.valueLabel);
            this.searchValuePanel.Controls.Add(this.typeLabel);
            this.searchValuePanel.Controls.Add(this.searchPanelLabel);
            this.searchValuePanel.Controls.Add(this.typeComboBox);
            this.searchValuePanel.Controls.Add(this.valueTextBox);
            this.searchValuePanel.Controls.Add(this.scanButton);
            this.searchValuePanel.Location = new System.Drawing.Point(354, 103);
            this.searchValuePanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.searchValuePanel.Name = "searchValuePanel";
            this.searchValuePanel.Size = new System.Drawing.Size(419, 315);
            this.searchValuePanel.TabIndex = 7;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resetButton.Location = new System.Drawing.Point(220, 225);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(129, 50);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetValues);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.BackColor = System.Drawing.Color.Transparent;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.valueLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.valueLabel.Location = new System.Drawing.Point(18, 132);
            this.valueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(46, 19);
            this.valueLabel.TabIndex = 8;
            this.valueLabel.Text = "Value:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.typeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.typeLabel.Location = new System.Drawing.Point(18, 68);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(41, 19);
            this.typeLabel.TabIndex = 7;
            this.typeLabel.Text = "Type:";
            // 
            // searchPanelLabel
            // 
            this.searchPanelLabel.AutoSize = true;
            this.searchPanelLabel.BackColor = System.Drawing.Color.Transparent;
            this.searchPanelLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchPanelLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.searchPanelLabel.Location = new System.Drawing.Point(4, 0);
            this.searchPanelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchPanelLabel.Name = "searchPanelLabel";
            this.searchPanelLabel.Size = new System.Drawing.Size(90, 19);
            this.searchPanelLabel.TabIndex = 6;
            this.searchPanelLabel.Text = "Search value:";
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.resultBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Address,
            this.Value});
            this.resultBox.ContextMenuStrip = this.resultMenuStrip;
            this.resultBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultBox.ForeColor = System.Drawing.SystemColors.Window;
            this.resultBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.resultBox.HideSelection = false;
            this.resultBox.Location = new System.Drawing.Point(26, 103);
            this.resultBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(273, 311);
            this.resultBox.TabIndex = 10;
            this.resultBox.UseCompatibleStateImageBehavior = false;
            this.resultBox.View = System.Windows.Forms.View.Details;
            // 
            // Address
            // 
            this.Address.Text = "Address";
            this.Address.Width = 120;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 149;
            // 
            // resultMenuStrip
            // 
            this.resultMenuStrip.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.changeValueStripItem2});
            this.resultMenuStrip.Name = "contextMenuStrip1";
            this.resultMenuStrip.Size = new System.Drawing.Size(157, 48);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveValue);
            // 
            // changeValueStripItem2
            // 
            this.changeValueStripItem2.Name = "changeValueStripItem2";
            this.changeValueStripItem2.Size = new System.Drawing.Size(156, 22);
            this.changeValueStripItem2.Text = "Change Value";
            this.changeValueStripItem2.Click += new System.EventHandler(this.ChangeValue);
            // 
            // changeValueStripItem
            // 
            this.changeValueStripItem.Name = "changeValueStripItem";
            this.changeValueStripItem.Size = new System.Drawing.Size(146, 22);
            this.changeValueStripItem.Text = "Change value";
            this.changeValueStripItem.Click += new System.EventHandler(this.ChangeValue);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.BackColor = System.Drawing.Color.Transparent;
            this.countLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.countLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.countLabel.Location = new System.Drawing.Point(25, 84);
            this.countLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(62, 19);
            this.countLabel.TabIndex = 11;
            this.countLabel.Text = "Count: 0";
            // 
            // savedValuesBox
            // 
            this.savedValuesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.savedValuesBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.savedValuesBox.ContextMenuStrip = this.savedMenuStrip;
            this.savedValuesBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.savedValuesBox.ForeColor = System.Drawing.SystemColors.Window;
            this.savedValuesBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.savedValuesBox.HideSelection = false;
            this.savedValuesBox.Location = new System.Drawing.Point(26, 462);
            this.savedValuesBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.savedValuesBox.Name = "savedValuesBox";
            this.savedValuesBox.Size = new System.Drawing.Size(747, 182);
            this.savedValuesBox.TabIndex = 12;
            this.savedValuesBox.UseCompatibleStateImageBehavior = false;
            this.savedValuesBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 149;
            // 
            // savedMenuStrip
            // 
            this.savedMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freezeMenuStrip,
            this.changeValueStripItem,
            this.removeStripItem});
            this.savedMenuStrip.Name = "contextMenuStrip1";
            this.savedMenuStrip.Size = new System.Drawing.Size(147, 70);
            // 
            // freezeMenuStrip
            // 
            this.freezeMenuStrip.Name = "freezeMenuStrip";
            this.freezeMenuStrip.Size = new System.Drawing.Size(146, 22);
            this.freezeMenuStrip.Text = "Freeze";
            this.freezeMenuStrip.Click += new System.EventHandler(this.FreezeValue);
            // 
            // removeStripItem
            // 
            this.removeStripItem.Name = "removeStripItem";
            this.removeStripItem.Size = new System.Drawing.Size(146, 22);
            this.removeStripItem.Text = "Remove";
            this.removeStripItem.Click += new System.EventHandler(this.RemoveSavedValues);
            // 
            // savedValuesLabel
            // 
            this.savedValuesLabel.AutoSize = true;
            this.savedValuesLabel.BackColor = System.Drawing.Color.Transparent;
            this.savedValuesLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.savedValuesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.savedValuesLabel.Location = new System.Drawing.Point(25, 440);
            this.savedValuesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.savedValuesLabel.Name = "savedValuesLabel";
            this.savedValuesLabel.Size = new System.Drawing.Size(91, 19);
            this.savedValuesLabel.TabIndex = 13;
            this.savedValuesLabel.Text = "Saved values:";
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateValues);
            // 
            // FreezeTimer
            // 
            this.FreezeTimer.Enabled = true;
            this.FreezeTimer.Interval = 50;
            this.FreezeTimer.Tick += new System.EventHandler(this.HoldFrozenValues);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(831, 670);
            this.Controls.Add(this.savedValuesLabel);
            this.Controls.Add(this.savedValuesBox);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.searchValuePanel);
            this.Controls.Add(this.processLabel);
            this.Controls.Add(this.attachedLabel);
            this.Controls.Add(this.processComboBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Frax";
            this.searchValuePanel.ResumeLayout(false);
            this.searchValuePanel.PerformLayout();
            this.resultMenuStrip.ResumeLayout(false);
            this.savedMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox processComboBox;
        private System.Windows.Forms.Label attachedLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label processLabel;
        private System.Windows.Forms.Panel searchValuePanel;
        private System.Windows.Forms.Label searchPanelLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.ListView resultBox;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ListView savedValuesBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label savedValuesLabel;
        private System.Windows.Forms.ContextMenuStrip resultMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeValueStripItem;
        private System.Windows.Forms.ContextMenuStrip savedMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem freezeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeStripItem;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.ToolStripMenuItem changeValueStripItem2;
        private System.Windows.Forms.Timer FreezeTimer;
    }
}

