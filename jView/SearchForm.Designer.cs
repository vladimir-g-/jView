namespace jView
{
    partial class SearchForm
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
            this.searchText = new System.Windows.Forms.TextBox();
            this.SearchTextWndLabel = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            this.CloseSearchDialogButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupSearchOptions = new System.Windows.Forms.GroupBox();
            this.checkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.checkSearchInValues = new System.Windows.Forms.CheckBox();
            this.checkSearchInNames = new System.Windows.Forms.CheckBox();
            this.statusSearchBar = new System.Windows.Forms.StatusStrip();
            this.FindResultsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupSearchOptions.SuspendLayout();
            this.statusSearchBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(42, 24);
            this.searchText.Margin = new System.Windows.Forms.Padding(2);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(233, 20);
            this.searchText.TabIndex = 0;
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
            // 
            // SearchTextWndLabel
            // 
            this.SearchTextWndLabel.AutoSize = true;
            this.SearchTextWndLabel.Location = new System.Drawing.Point(10, 27);
            this.SearchTextWndLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchTextWndLabel.Name = "SearchTextWndLabel";
            this.SearchTextWndLabel.Size = new System.Drawing.Size(28, 13);
            this.SearchTextWndLabel.TabIndex = 0;
            this.SearchTextWndLabel.Text = "Text";
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.findButton.Location = new System.Drawing.Point(315, 11);
            this.findButton.Margin = new System.Windows.Forms.Padding(2);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(71, 28);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // CloseSearchDialogButton
            // 
            this.CloseSearchDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseSearchDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseSearchDialogButton.Location = new System.Drawing.Point(315, 43);
            this.CloseSearchDialogButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseSearchDialogButton.Name = "CloseSearchDialogButton";
            this.CloseSearchDialogButton.Size = new System.Drawing.Size(71, 29);
            this.CloseSearchDialogButton.TabIndex = 2;
            this.CloseSearchDialogButton.Text = "Cancel";
            this.CloseSearchDialogButton.UseVisualStyleBackColor = true;
            this.CloseSearchDialogButton.Click += new System.EventHandler(this.CloseSearchDialogButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchText);
            this.groupBox1.Controls.Add(this.SearchTextWndLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find";
            // 
            // groupSearchOptions
            // 
            this.groupSearchOptions.Controls.Add(this.checkCaseSensitive);
            this.groupSearchOptions.Controls.Add(this.checkSearchInValues);
            this.groupSearchOptions.Controls.Add(this.checkSearchInNames);
            this.groupSearchOptions.Location = new System.Drawing.Point(12, 78);
            this.groupSearchOptions.Name = "groupSearchOptions";
            this.groupSearchOptions.Size = new System.Drawing.Size(289, 82);
            this.groupSearchOptions.TabIndex = 5;
            this.groupSearchOptions.TabStop = false;
            this.groupSearchOptions.Text = "Search Options";
            // 
            // checkCaseSensitive
            // 
            this.checkCaseSensitive.AutoSize = true;
            this.checkCaseSensitive.Location = new System.Drawing.Point(167, 34);
            this.checkCaseSensitive.Name = "checkCaseSensitive";
            this.checkCaseSensitive.Size = new System.Drawing.Size(94, 17);
            this.checkCaseSensitive.TabIndex = 2;
            this.checkCaseSensitive.Text = "Case sensitive";
            this.checkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // checkSearchInValues
            // 
            this.checkSearchInValues.AutoSize = true;
            this.checkSearchInValues.Location = new System.Drawing.Point(13, 57);
            this.checkSearchInValues.Name = "checkSearchInValues";
            this.checkSearchInValues.Size = new System.Drawing.Size(105, 17);
            this.checkSearchInValues.TabIndex = 1;
            this.checkSearchInValues.Text = "Search in values";
            this.checkSearchInValues.UseVisualStyleBackColor = true;
            // 
            // checkSearchInNames
            // 
            this.checkSearchInNames.AutoSize = true;
            this.checkSearchInNames.Checked = true;
            this.checkSearchInNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSearchInNames.Location = new System.Drawing.Point(13, 34);
            this.checkSearchInNames.Name = "checkSearchInNames";
            this.checkSearchInNames.Size = new System.Drawing.Size(105, 17);
            this.checkSearchInNames.TabIndex = 0;
            this.checkSearchInNames.Text = "Search in names";
            this.checkSearchInNames.UseVisualStyleBackColor = true;
            // 
            // statusSearchBar
            // 
            this.statusSearchBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindResultsLabel});
            this.statusSearchBar.Location = new System.Drawing.Point(0, 176);
            this.statusSearchBar.Name = "statusSearchBar";
            this.statusSearchBar.Size = new System.Drawing.Size(395, 22);
            this.statusSearchBar.TabIndex = 6;
            this.statusSearchBar.Text = "Found: ";
            // 
            // FindResultsLabel
            // 
            this.FindResultsLabel.Name = "FindResultsLabel";
            this.FindResultsLabel.Size = new System.Drawing.Size(47, 17);
            this.FindResultsLabel.Text = "Found: ";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseSearchDialogButton;
            this.ClientSize = new System.Drawing.Size(395, 198);
            this.Controls.Add(this.statusSearchBar);
            this.Controls.Add(this.groupSearchOptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseSearchDialogButton);
            this.Controls.Add(this.findButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Search Node";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupSearchOptions.ResumeLayout(false);
            this.groupSearchOptions.PerformLayout();
            this.statusSearchBar.ResumeLayout(false);
            this.statusSearchBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Label SearchTextWndLabel;
        private System.Windows.Forms.Button CloseSearchDialogButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupSearchOptions;
        private System.Windows.Forms.CheckBox checkSearchInValues;
        private System.Windows.Forms.CheckBox checkSearchInNames;
        private System.Windows.Forms.StatusStrip statusSearchBar;
        private System.Windows.Forms.ToolStripStatusLabel FindResultsLabel;
        private System.Windows.Forms.CheckBox checkCaseSensitive;
    }
}