/*
 * TouchedFiles project, main form designer class
 * Copyright (C) 2014, Petros Kyladitis
 *
 * This program is free software distributed under the  GNU GPL 3, 
 * for license details see at 'license.txt' file, distributed with 
 * this program, or see at <http://www.gnu.org/licenses/gpl-3.0.txt>
 */
 
namespace TouchedFiles{
	partial class MainForm	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing){
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent(){
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.labelWait = new System.Windows.Forms.Label();
			this.listBoxFiles = new System.Windows.Forms.ListBox();
			this.menuStripTop = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkBoxSubdirs = new System.Windows.Forms.CheckBox();
			this.labelDateAfter = new System.Windows.Forms.Label();
			this.labelFolder = new System.Windows.Forms.Label();
			this.dateTimePickerAfter = new System.Windows.Forms.DateTimePicker();
			this.buttonSelectFolder = new System.Windows.Forms.Button();
			this.textBoxSelectedFolder = new System.Windows.Forms.TextBox();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.menuStripTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.labelWait);
			this.splitContainer.Panel1.Controls.Add(this.listBoxFiles);
			this.splitContainer.Panel1.Controls.Add(this.menuStripTop);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.checkBoxSubdirs);
			this.splitContainer.Panel2.Controls.Add(this.labelDateAfter);
			this.splitContainer.Panel2.Controls.Add(this.labelFolder);
			this.splitContainer.Panel2.Controls.Add(this.dateTimePickerAfter);
			this.splitContainer.Panel2.Controls.Add(this.buttonSelectFolder);
			this.splitContainer.Panel2.Controls.Add(this.textBoxSelectedFolder);
			this.splitContainer.Panel2.Controls.Add(this.buttonSearch);
			this.splitContainer.Size = new System.Drawing.Size(597, 342);
			this.splitContainer.SplitterDistance = 280;
			this.splitContainer.TabIndex = 0;
			// 
			// labelWait
			// 
			this.labelWait.BackColor = System.Drawing.SystemColors.Window;
			this.labelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.labelWait.Location = new System.Drawing.Point(217, 116);
			this.labelWait.Name = "labelWait";
			this.labelWait.Size = new System.Drawing.Size(171, 57);
			this.labelWait.TabIndex = 1;
			this.labelWait.Text = "Please wait...";
			this.labelWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelWait.Visible = false;
			// 
			// listBoxFiles
			// 
			this.listBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.listBoxFiles.FormattingEnabled = true;
			this.listBoxFiles.HorizontalScrollbar = true;
			this.listBoxFiles.ItemHeight = 18;
			this.listBoxFiles.Location = new System.Drawing.Point(0, 24);
			this.listBoxFiles.Name = "listBoxFiles";
			this.listBoxFiles.Size = new System.Drawing.Size(597, 256);
			this.listBoxFiles.TabIndex = 5;
			this.listBoxFiles.DoubleClick += new System.EventHandler(this.ListBoxFilesDoubleClick);
			// 
			// menuStripTop
			// 
			this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.aboutToolStripMenuItem});
			this.menuStripTop.Location = new System.Drawing.Point(0, 0);
			this.menuStripTop.Name = "menuStripTop";
			this.menuStripTop.Size = new System.Drawing.Size(597, 24);
			this.menuStripTop.TabIndex = 2;
			this.menuStripTop.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.searchToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.searchToolStripMenuItem.Text = "Start &Searching";
			this.searchToolStripMenuItem.ToolTipText = "Start the searching process";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.ToolTipText = "Quit the application";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.ToolTipText = "Show information about this program";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// checkBoxSubdirs
			// 
			this.checkBoxSubdirs.Checked = true;
			this.checkBoxSubdirs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSubdirs.Location = new System.Drawing.Point(451, 26);
			this.checkBoxSubdirs.Name = "checkBoxSubdirs";
			this.checkBoxSubdirs.Size = new System.Drawing.Size(113, 24);
			this.checkBoxSubdirs.TabIndex = 3;
			this.checkBoxSubdirs.Text = "Include subfolders";
			this.checkBoxSubdirs.UseVisualStyleBackColor = true;
			// 
			// labelDateAfter
			// 
			this.labelDateAfter.Location = new System.Drawing.Point(92, 28);
			this.labelDateAfter.Name = "labelDateAfter";
			this.labelDateAfter.Size = new System.Drawing.Size(90, 23);
			this.labelDateAfter.TabIndex = 5;
			this.labelDateAfter.Text = "Modified after";
			// 
			// labelFolder
			// 
			this.labelFolder.Location = new System.Drawing.Point(92, 5);
			this.labelFolder.Name = "labelFolder";
			this.labelFolder.Size = new System.Drawing.Size(90, 23);
			this.labelFolder.TabIndex = 4;
			this.labelFolder.Text = "Folder to search";
			// 
			// dateTimePickerAfter
			// 
			this.dateTimePickerAfter.Location = new System.Drawing.Point(188, 28);
			this.dateTimePickerAfter.Name = "dateTimePickerAfter";
			this.dateTimePickerAfter.Size = new System.Drawing.Size(224, 20);
			this.dateTimePickerAfter.TabIndex = 4;
			// 
			// buttonSelectFolder
			// 
			this.buttonSelectFolder.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectFolder.Image")));
			this.buttonSelectFolder.Location = new System.Drawing.Point(537, 5);
			this.buttonSelectFolder.Name = "buttonSelectFolder";
			this.buttonSelectFolder.Size = new System.Drawing.Size(27, 20);
			this.buttonSelectFolder.TabIndex = 1;
			this.buttonSelectFolder.UseVisualStyleBackColor = true;
			this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolderClick);
			// 
			// textBoxSelectedFolder
			// 
			this.textBoxSelectedFolder.Location = new System.Drawing.Point(188, 5);
			this.textBoxSelectedFolder.Name = "textBoxSelectedFolder";
			this.textBoxSelectedFolder.Size = new System.Drawing.Size(343, 20);
			this.textBoxSelectedFolder.TabIndex = 2;
			// 
			// buttonSearch
			// 
			this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
			this.buttonSearch.Location = new System.Drawing.Point(3, 2);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(81, 51);
			this.buttonSearch.TabIndex = 0;
			this.buttonSearch.Text = "&Search";
			this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 342);
			this.Controls.Add(this.splitContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripTop;
			this.MinimumSize = new System.Drawing.Size(613, 380);
			this.Name = "MainForm";
			this.Text = "TouchedFiles";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.menuStripTop.ResumeLayout(false);
			this.menuStripTop.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStripTop;
		private System.Windows.Forms.Label labelDateAfter;
		private System.Windows.Forms.Label labelFolder;
		private System.Windows.Forms.Label labelWait;
		private System.Windows.Forms.CheckBox checkBoxSubdirs;
		private System.Windows.Forms.DateTimePicker dateTimePickerAfter;
		private System.Windows.Forms.TextBox textBoxSelectedFolder;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button buttonSelectFolder;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.ListBox listBoxFiles;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	}
}
