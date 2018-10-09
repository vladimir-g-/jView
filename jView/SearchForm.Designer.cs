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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(69, 24);
            this.searchText.Margin = new System.Windows.Forms.Padding(2);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(172, 20);
            this.searchText.TabIndex = 0;
            // 
            // SearchTextWndLabel
            // 
            this.SearchTextWndLabel.AutoSize = true;
            this.SearchTextWndLabel.Location = new System.Drawing.Point(10, 27);
            this.SearchTextWndLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchTextWndLabel.Name = "SearchTextWndLabel";
            this.SearchTextWndLabel.Size = new System.Drawing.Size(55, 13);
            this.SearchTextWndLabel.TabIndex = 0;
            this.SearchTextWndLabel.Text = "Tag name";
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.findButton.Location = new System.Drawing.Point(279, 11);
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
            this.CloseSearchDialogButton.Location = new System.Drawing.Point(279, 43);
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
            this.groupBox1.Size = new System.Drawing.Size(254, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseSearchDialogButton;
            this.ClientSize = new System.Drawing.Size(359, 87);
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
            this.Text = "Search Tag";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Label SearchTextWndLabel;
        private System.Windows.Forms.Button CloseSearchDialogButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}