/*
 * TouchedFiles project, program entry point class
 * Copyright (C) 2014, Petros Kyladitis
 *
 * This program is free software distributed under the  GNU GPL 3, 
 * for license details see at 'license.txt' file, distributed with 
 * this program, or see at <http://www.gnu.org/licenses/gpl-3.0.txt>
 */
 
using System;
using System.Windows.Forms;

namespace TouchedFiles{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args){
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
