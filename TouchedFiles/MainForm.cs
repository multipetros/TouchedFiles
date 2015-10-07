/*
 * TouchedFiles project, main form class
 * Copyright (C) 2014, Petros Kyladitis
 *
 * This program is free software distributed under the  GNU GPL 3, 
 * for license details see at 'license.txt' file, distributed with 
 * this program, or see at <http://www.gnu.org/licenses/gpl-3.0.txt>
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO ;
using System.Diagnostics ;
using System.Linq ;
using Multipetros ;

namespace TouchedFiles{
	public partial class MainForm : Form{
		
		private string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\multiPetros\\" ;
		private string settingsFile = "touchedfiles.ini" ;

		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//load date picker with previous day (864000000 equals equals 1 day)
			dateTimePickerAfter.Value = new DateTime(DateTime.Today.Ticks - 864000000) ;
			ToolTip tip = new ToolTip() ;
			tip.SetToolTip(buttonSelectFolder, "Select Folder") ;
			tip.SetToolTip(buttonSearch, "Search for changed files") ;
			tip.SetToolTip(textBoxSelectedFolder, "Path to look at...") ;
			tip.SetToolTip(dateTimePickerAfter, "Pick date, to search for changed files after that") ;
			tip.SetToolTip(checkBoxSubdirs, "Recursive searching in subfolders of the selected path") ;
			LoadSettings() ;
		}
		
		private void LoadSettings(){
			if(File.Exists(appDataPath + settingsFile)){
				Props ini = new Props(appDataPath + settingsFile, false) ;
				string path = ini.GetProperty("PATH", true) ;
				textBoxSelectedFolder.Text = path ;
				string recrusive = ini.GetProperty("RECRUSIVE", true) ;
				if(recrusive == "False"){
					checkBoxSubdirs.Checked = false ;
				}
			}
		}
		
		private void StoreSettings(){
			if(!Directory.Exists(appDataPath)){
				try{
					Directory.CreateDirectory(appDataPath) ;
				}catch(Exception exc){
					MessageBox.Show("Can't store settings at AppData folder. Maybe you haven't sufficient permissions\n" + exc.Message, "Storing settings error", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
					return ;
				}
			}
			Props ini = new Props(appDataPath + settingsFile, false) ;
			ini.SetProperty("PATH", textBoxSelectedFolder.Text) ;
			ini.SetProperty("RECRUSIVE", checkBoxSubdirs.Checked.ToString()) ;
			ini.Save() ;
		}
		
		private void AddFiles(string path, List<string> files){
			if(files == null){
				files = new List<string>() ;
			}
		    try{
		        Directory.GetFiles(path)
		            .ToList()
		        	.ForEach(s => {
		        	         	if(File.GetLastWriteTime(s) > dateTimePickerAfter.Value){
									listBoxFiles.Items.Add(s) ;
									listBoxFiles.SelectedIndex = listBoxFiles.Items.Count - 1 ;
									}
		        	         	}
		        	         );

		        Directory.GetDirectories(path)
		            .ToList()
		            .ForEach(s => AddFiles(s, files));
		    }
		    catch (Exception){
		        // if can't access this dir, just skip it
		    }
		}
		
		private void AddFilesNoRecursive(string path, List<string> files){
			if(files == null){
				files = new List<string>() ;
			}
		    try{
		        Directory.GetFiles(path)
		            .ToList()
		        	.ForEach(s => {
		        	         	if(File.GetLastWriteTime(s) > dateTimePickerAfter.Value){
									listBoxFiles.Items.Add(s) ;
									listBoxFiles.SelectedIndex = listBoxFiles.Items.Count - 1 ;
									}
		        	         	}
		        	         );
		    }
		    catch (UnauthorizedAccessException){
		        // if can't access this dir, just skip it
		    }
		}

		
		void ButtonSearchClick(object sender, EventArgs e){
			StartSearch() ;
		}
		
		private void StartSearch(){
			labelWait.Visible = true ;
			labelWait.Location =  new Point((listBoxFiles.Width - labelWait.Width) / 2 , (listBoxFiles.Height - labelWait.Height) / 2 );
			Refresh() ;
			
			string path = textBoxSelectedFolder.Text ;
			if(!Directory.Exists(path)){
				MessageBox.Show("Selected directory not exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
				labelWait.Visible = false ;
				return ;
			}
			
			listBoxFiles.Items.Clear() ;
			
			if(checkBoxSubdirs.Checked){
				AddFiles(path, null) ;
			}else{
				AddFilesNoRecursive(path, null) ;
			}
			
			System.Media.SystemSounds.Beep.Play() ;			
			labelWait.Visible = false ;			
		}
		
		void ListBoxFilesDoubleClick(object sender, EventArgs e){
			if(listBoxFiles.SelectedIndex > -1){
				Process.Start(listBoxFiles.SelectedItem.ToString()) ;
			}
		}
		
		void ButtonSelectFolderClick(object sender, EventArgs e){
			folderBrowserDialog.ShowDialog() ;
			textBoxSelectedFolder.Text = folderBrowserDialog.SelectedPath ;
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e){
			MessageBox.Show("TouchedFiles v1.0\nA program to find and open last edited files\n\nCopyright (c) 2015, Petros Kyladitis\n<http://www.multipetros.gr/>\n\nThis program is free software distributed under the GNU GPL 3, for license details see at 'license.txt' file, distributed with this program, or see at <http://www.gnu.org/licenses/gpl-3.0.txt>.", "About TouchedFiles", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e){
			Application.Exit() ;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e){
			StoreSettings() ;
		}
		
		void SearchToolStripMenuItemClick(object sender, EventArgs e){
			StartSearch() ;
		}
	}
}
