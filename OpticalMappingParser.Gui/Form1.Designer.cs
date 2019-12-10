namespace OpticalMappingParser.Gui
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCompleteResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.parametrsGroupBox = new System.Windows.Forms.GroupBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.numericUpDownMaxSeqBetweenMarks = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownConsecutiveMarks = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownMaxSeqNoMarks = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.newProcessButton = new System.Windows.Forms.Button();
            this.FilterButton = new System.Windows.Forms.Button();
            this.clearFiltersButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownEndPos = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartPos = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chromosomeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.parametrsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSeqBetweenMarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsecutiveMarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSeqNoMarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.filterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartPos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.saveFileToCSVToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFileToolStripMenuItem_Click);
            // 
            // saveFileToCSVToolStripMenuItem
            // 
            this.saveFileToCSVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCompleteResultMenuItem,
            this.saveFilteredResultMenuItem});
            this.saveFileToCSVToolStripMenuItem.Enabled = false;
            this.saveFileToCSVToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.saveFileToCSVToolStripMenuItem.Name = "saveFileToCSVToolStripMenuItem";
            this.saveFileToCSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveFileToCSVToolStripMenuItem.Text = "Save File to CSV";
            // 
            // saveCompleteResultMenuItem
            // 
            this.saveCompleteResultMenuItem.Enabled = false;
            this.saveCompleteResultMenuItem.Name = "saveCompleteResultMenuItem";
            this.saveCompleteResultMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveCompleteResultMenuItem.Text = "Save complete result";
            this.saveCompleteResultMenuItem.Click += new System.EventHandler(this.saveCompleteResultMenuItem_Click);
            // 
            // saveFilteredResultMenuItem
            // 
            this.saveFilteredResultMenuItem.Enabled = false;
            this.saveFilteredResultMenuItem.Name = "saveFilteredResultMenuItem";
            this.saveFilteredResultMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveFilteredResultMenuItem.Text = "Save filtered result";
            this.saveFilteredResultMenuItem.Click += new System.EventHandler(this.saveFilteredResultMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // parametrsGroupBox
            // 
            this.parametrsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.parametrsGroupBox.Controls.Add(this.generateButton);
            this.parametrsGroupBox.Controls.Add(this.numericUpDownMaxSeqBetweenMarks);
            this.parametrsGroupBox.Controls.Add(this.label3);
            this.parametrsGroupBox.Controls.Add(this.numericUpDownConsecutiveMarks);
            this.parametrsGroupBox.Controls.Add(this.label2);
            this.parametrsGroupBox.Controls.Add(this.numericUpDownMaxSeqNoMarks);
            this.parametrsGroupBox.Controls.Add(this.label1);
            this.parametrsGroupBox.Location = new System.Drawing.Point(13, 28);
            this.parametrsGroupBox.Name = "parametrsGroupBox";
            this.parametrsGroupBox.Size = new System.Drawing.Size(241, 410);
            this.parametrsGroupBox.TabIndex = 1;
            this.parametrsGroupBox.TabStop = false;
            this.parametrsGroupBox.Text = "Parametrs";
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(6, 381);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(229, 23);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Process";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // numericUpDownMaxSeqBetweenMarks
            // 
            this.numericUpDownMaxSeqBetweenMarks.Location = new System.Drawing.Point(10, 151);
            this.numericUpDownMaxSeqBetweenMarks.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMaxSeqBetweenMarks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxSeqBetweenMarks.Name = "numericUpDownMaxSeqBetweenMarks";
            this.numericUpDownMaxSeqBetweenMarks.Size = new System.Drawing.Size(195, 20);
            this.numericUpDownMaxSeqBetweenMarks.TabIndex = 5;
            this.numericUpDownMaxSeqBetweenMarks.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Maximal sequence length between marks:";
            // 
            // numericUpDownConsecutiveMarks
            // 
            this.numericUpDownConsecutiveMarks.Location = new System.Drawing.Point(10, 97);
            this.numericUpDownConsecutiveMarks.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownConsecutiveMarks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownConsecutiveMarks.Name = "numericUpDownConsecutiveMarks";
            this.numericUpDownConsecutiveMarks.Size = new System.Drawing.Size(192, 20);
            this.numericUpDownConsecutiveMarks.TabIndex = 3;
            this.numericUpDownConsecutiveMarks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of consecutive makrs:";
            // 
            // numericUpDownMaxSeqNoMarks
            // 
            this.numericUpDownMaxSeqNoMarks.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownMaxSeqNoMarks.Location = new System.Drawing.Point(10, 45);
            this.numericUpDownMaxSeqNoMarks.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMaxSeqNoMarks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxSeqNoMarks.Name = "numericUpDownMaxSeqNoMarks";
            this.numericUpDownMaxSeqNoMarks.Size = new System.Drawing.Size(192, 20);
            this.numericUpDownMaxSeqNoMarks.TabIndex = 1;
            this.numericUpDownMaxSeqNoMarks.ThousandsSeparator = true;
            this.numericUpDownMaxSeqNoMarks.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownMaxSeqNoMarks.ValueChanged += new System.EventHandler(this.numericUpDownMaxSeqNoMarks_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maximal sequence length without marks:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(260, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(542, 410);
            this.dataGridView1.TabIndex = 2;
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filterGroupBox.Controls.Add(this.newProcessButton);
            this.filterGroupBox.Controls.Add(this.FilterButton);
            this.filterGroupBox.Controls.Add(this.clearFiltersButton);
            this.filterGroupBox.Controls.Add(this.label6);
            this.filterGroupBox.Controls.Add(this.numericUpDownEndPos);
            this.filterGroupBox.Controls.Add(this.numericUpDownStartPos);
            this.filterGroupBox.Controls.Add(this.label5);
            this.filterGroupBox.Controls.Add(this.chromosomeComboBox);
            this.filterGroupBox.Controls.Add(this.label4);
            this.filterGroupBox.Location = new System.Drawing.Point(5, 28);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(249, 410);
            this.filterGroupBox.TabIndex = 3;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filter settings";
            // 
            // newProcessButton
            // 
            this.newProcessButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newProcessButton.Location = new System.Drawing.Point(10, 381);
            this.newProcessButton.Name = "newProcessButton";
            this.newProcessButton.Size = new System.Drawing.Size(222, 23);
            this.newProcessButton.TabIndex = 8;
            this.newProcessButton.Text = "New Process";
            this.newProcessButton.UseVisualStyleBackColor = true;
            this.newProcessButton.Click += new System.EventHandler(this.NewProcessButton_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterButton.Location = new System.Drawing.Point(10, 323);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(222, 23);
            this.FilterButton.TabIndex = 7;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // clearFiltersButton
            // 
            this.clearFiltersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearFiltersButton.Location = new System.Drawing.Point(10, 352);
            this.clearFiltersButton.Name = "clearFiltersButton";
            this.clearFiltersButton.Size = new System.Drawing.Size(222, 23);
            this.clearFiltersButton.TabIndex = 6;
            this.clearFiltersButton.Text = "Clear Filters";
            this.clearFiltersButton.UseVisualStyleBackColor = true;
            this.clearFiltersButton.Click += new System.EventHandler(this.ClearFiltersButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Help;
            this.label6.Location = new System.Drawing.Point(7, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "End position:";
            this.toolTip1.SetToolTip(this.label6, "End position is optional parametr, set 0 to skip this parametr");
            // 
            // numericUpDownEndPos
            // 
            this.numericUpDownEndPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownEndPos.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEndPos.Location = new System.Drawing.Point(10, 151);
            this.numericUpDownEndPos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEndPos.Name = "numericUpDownEndPos";
            this.numericUpDownEndPos.Size = new System.Drawing.Size(233, 20);
            this.numericUpDownEndPos.TabIndex = 4;
            this.numericUpDownEndPos.ThousandsSeparator = true;
            // 
            // numericUpDownStartPos
            // 
            this.numericUpDownStartPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownStartPos.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownStartPos.Location = new System.Drawing.Point(10, 96);
            this.numericUpDownStartPos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownStartPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownStartPos.Name = "numericUpDownStartPos";
            this.numericUpDownStartPos.Size = new System.Drawing.Size(233, 20);
            this.numericUpDownStartPos.TabIndex = 3;
            this.numericUpDownStartPos.ThousandsSeparator = true;
            this.numericUpDownStartPos.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Help;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(7, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Start position:";
            this.toolTip1.SetToolTip(this.label5, "Start position is optional parametr, set -1 to skip this parameter");
            // 
            // chromosomeComboBox
            // 
            this.chromosomeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chromosomeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chromosomeComboBox.FormattingEnabled = true;
            this.chromosomeComboBox.Location = new System.Drawing.Point(9, 43);
            this.chromosomeComboBox.Name = "chromosomeComboBox";
            this.chromosomeComboBox.Size = new System.Drawing.Size(234, 21);
            this.chromosomeComboBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chromosome:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.filterGroupBox);
            this.Controls.Add(this.parametrsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Difficult area indentifier";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.parametrsGroupBox.ResumeLayout(false);
            this.parametrsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSeqBetweenMarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsecutiveMarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSeqNoMarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToCSVToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox parametrsGroupBox;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSeqNoMarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownConsecutiveMarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSeqBetweenMarks;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.ComboBox chromosomeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownEndPos;
        private System.Windows.Forms.NumericUpDown numericUpDownStartPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Button clearFiltersButton;
        private System.Windows.Forms.Button newProcessButton;
        private System.Windows.Forms.ToolStripMenuItem saveCompleteResultMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredResultMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

