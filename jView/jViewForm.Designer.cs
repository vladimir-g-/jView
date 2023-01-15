namespace jView
{
    partial class jViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(jViewForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadTreeFromTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureFontsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTreeFontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTextFontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jNodesTree = new System.Windows.Forms.TreeView();
            this.treeNodetMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseNodesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.originalFileText = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadFromTextButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.treeNodetMenuStrip.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.aboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.toolStripSeparator2,
            this.ExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(123, 22);
            this.OpenMenuItem.Text = "Open";
            this.OpenMenuItem.ToolTipText = "Open file";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Enabled = false;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Enabled = false;
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsMenuItem.Text = "Save As...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(120, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.ToolTipText = "Close program";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchNodeMenuItem,
            this.reloadTreeFromTextMenuItem,
            this.configureFontsMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.searchToolStripMenuItem.Text = "Tools";
            // 
            // SearchNodeMenuItem
            // 
            this.SearchNodeMenuItem.Image = global::jView.Properties.Resources.Search2_48;
            this.SearchNodeMenuItem.Name = "SearchNodeMenuItem";
            this.SearchNodeMenuItem.Size = new System.Drawing.Size(185, 22);
            this.SearchNodeMenuItem.Text = "Search Node";
            this.SearchNodeMenuItem.ToolTipText = "Search Node in the Tree";
            this.SearchNodeMenuItem.Click += new System.EventHandler(this.SearchNodeMenuItem_Click);
            // 
            // reloadTreeFromTextMenuItem
            // 
            this.reloadTreeFromTextMenuItem.Image = global::jView.Properties.Resources.refresh;
            this.reloadTreeFromTextMenuItem.Name = "reloadTreeFromTextMenuItem";
            this.reloadTreeFromTextMenuItem.Size = new System.Drawing.Size(185, 22);
            this.reloadTreeFromTextMenuItem.Text = "Reload tree from text";
            this.reloadTreeFromTextMenuItem.ToolTipText = "Refresh tree from text";
            this.reloadTreeFromTextMenuItem.Click += new System.EventHandler(this.reloadTreeFromTextToolMenuItem_Click);
            // 
            // configureFontsMenuItem
            // 
            this.configureFontsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeTreeFontMenuItem,
            this.changeTextFontMenuItem});
            this.configureFontsMenuItem.Name = "configureFontsMenuItem";
            this.configureFontsMenuItem.Size = new System.Drawing.Size(189, 26);
            this.configureFontsMenuItem.Text = "Configure Fonts";
            // 
            // changeTreeFontMenuItem
            // 
            this.changeTreeFontMenuItem.Name = "changeTreeFontMenuItem";
            this.changeTreeFontMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeTreeFontMenuItem.Text = "Change Tree Font";
            this.changeTreeFontMenuItem.ToolTipText = "Change font in the tree view";
            this.changeTreeFontMenuItem.Click += new System.EventHandler(this.changeTreeFontMenuItem_Click);
            // 
            // changeTextFontMenuItem
            // 
            this.changeTextFontMenuItem.Name = "changeTextFontMenuItem";
            this.changeTextFontMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeTextFontMenuItem.Text = "Change Text Font";
            this.changeTextFontMenuItem.ToolTipText = "Change font in the source view";
            this.changeTextFontMenuItem.Click += new System.EventHandler(this.changeTextFontMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.ToolTipText = "Show about information";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(505, 247);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jNodesTree);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(497, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tree";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jNodesTree
            // 
            this.jNodesTree.AllowDrop = true;
            this.jNodesTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jNodesTree.ContextMenuStrip = this.treeNodetMenuStrip;
            this.jNodesTree.ImageIndex = 0;
            this.jNodesTree.ImageList = this.treeImageList;
            this.jNodesTree.Location = new System.Drawing.Point(0, 3);
            this.jNodesTree.Name = "jNodesTree";
            this.jNodesTree.SelectedImageIndex = 0;
            this.jNodesTree.Size = new System.Drawing.Size(496, 218);
            this.jNodesTree.TabIndex = 0;
            this.jNodesTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.jNodesTree_DragDrop);
            this.jNodesTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.jNodesTree_DragEnter);
            // 
            // treeNodetMenuStrip
            // 
            this.treeNodetMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandNodeMenuItem,
            this.collapseNodesMenuItem});
            this.treeNodetMenuStrip.Name = "treeNodetMenuStrip";
            this.treeNodetMenuStrip.Size = new System.Drawing.Size(137, 48);
            this.treeNodetMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.treeNodetMenuStrip_Opening);
            // 
            // expandNodeMenuItem
            // 
            this.expandNodeMenuItem.Name = "expandNodeMenuItem";
            this.expandNodeMenuItem.Size = new System.Drawing.Size(136, 22);
            this.expandNodeMenuItem.Text = "Expand All";
            this.expandNodeMenuItem.ToolTipText = "Expand a node including all child nodes";
            this.expandNodeMenuItem.Click += new System.EventHandler(this.expandNodeMenuItem_Click);
            // 
            // collapseNodesMenuItem
            // 
            this.collapseNodesMenuItem.Name = "collapseNodesMenuItem";
            this.collapseNodesMenuItem.Size = new System.Drawing.Size(136, 22);
            this.collapseNodesMenuItem.Text = "Collapse All";
            this.collapseNodesMenuItem.ToolTipText = "Collape a node including all child nodes";
            this.collapseNodesMenuItem.Click += new System.EventHandler(this.collapseNodesMenuItem_Click);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "object.png");
            this.treeImageList.Images.SetKeyName(1, "array.png");
            this.treeImageList.Images.SetKeyName(2, "Dot.png");
            this.treeImageList.Images.SetKeyName(3, "Text_3.png");
            this.treeImageList.Images.SetKeyName(4, "Boolean.png");
            this.treeImageList.Images.SetKeyName(5, "Number.png");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.originalFileText);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(497, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Source";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // originalFileText
            // 
            this.originalFileText.AcceptsTab = true;
            this.originalFileText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originalFileText.Location = new System.Drawing.Point(0, 3);
            this.originalFileText.Name = "originalFileText";
            this.originalFileText.Size = new System.Drawing.Size(496, 218);
            this.originalFileText.TabIndex = 0;
            this.originalFileText.Text = "";
            this.originalFileText.TextChanged += new System.EventHandler(this.originalFileText_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileButton,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.loadFromTextButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(505, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(24, 24);
            this.OpenFileButton.Text = "toolStripButton1";
            this.OpenFileButton.ToolTipText = "Open file";
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::jView.Properties.Resources.Search2_48;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "Search node";
            this.toolStripButton1.Click += new System.EventHandler(this.SearchNodeMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // loadFromTextButton
            // 
            this.loadFromTextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadFromTextButton.Image = global::jView.Properties.Resources.refresh;
            this.loadFromTextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadFromTextButton.Name = "loadFromTextButton";
            this.loadFromTextButton.Size = new System.Drawing.Size(24, 24);
            this.loadFromTextButton.Text = "toolStripButton2";
            this.loadFromTextButton.ToolTipText = "Refresh tree from text";
            this.loadFromTextButton.Click += new System.EventHandler(this.loadFromTextButton_Click);
            // 
            // jViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(505, 298);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "jViewForm";
            this.Text = "jView";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.treeNodetMenuStrip.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView jNodesTree;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchNodeMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton loadFromTextButton;
        private System.Windows.Forms.ToolStripMenuItem reloadTreeFromTextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.RichTextBox originalFileText;
        private System.Windows.Forms.ContextMenuStrip treeNodetMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem expandNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseNodesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureFontsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTreeFontMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTextFontMenuItem;
    }
}

