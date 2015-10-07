#region license
/* 
 * Props library - Version 1.2
 * Copyright (C) 2011-2012 Petros Kyladitis
 * 
 * A minimalistic properties file manipulation library,
 * developed in SharpDevelop, at C# language, targeted .NET framework
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met: 
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer. 
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution. 
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
 #endregion
 
using System;
using System.IO;
using System.Collections.Generic;

namespace Multipetros{
	/// <summary>
	/// A minimalistic properties file manipulation library for .net framework
	/// </summary>
	public class Props{
		public const bool NO_AUTOSAVE = false ;
		public const bool AUTOSAVE = true ;

		private readonly string SEPARATOR ;
		private string[] keys ;
		private string[] values ;
		private string file ;
		private bool autosave;
		
		/// <summary>
		/// Constructor of the class, with default separator '=' of key-value
		/// </summary>
		/// <param name="file">The path of the properties file</param>
		/// <param name="autosave">Select if want to save the properties automated after every change (adding or deleting a property)</param>
		public Props(string file, bool autosave){
			this.file = file ;
			this.autosave = autosave ;
			this.SEPARATOR = "=" ; //the default separator is '=' 
			this.Load() ;
		}

		/// <summary>
		/// Constructor of the class, with optional key-value separator
		/// </summary>
		/// <param name="file">The path of the properties file</param>
		/// <param name="autosave">Select if want to save the properties automated after every change (adding or deleting a property)</param>
		/// <param name="separator">The separator of key-value</param>
		public Props(string file, bool autosave, string separator){
			this.file = file ;
			this.autosave = autosave ;
			this.SEPARATOR = separator ;
			this.Load() ;
		}
		
		/// <summary>
		/// Load values and keys from properties file
		/// </summary>
		private void Load(){			
			//check if file exist, if not create it, utilize blank tables and return
			if(!File.Exists(this.file)){
				this.keys = new string[0] ;
				this.values = new string[0] ;
				return ;
			}
						
			string[] allProperties = File.ReadAllLines(this.file) ;
			string[] eachProperty ;
			
			//check how many properties exist (lines with '=' but no starts with) and create the table in the same size
			int existedKeys = allProperties.Length ;
			for(int i=0; i<allProperties.Length; i++){
				if(!allProperties[i].Contains(this.SEPARATOR)||allProperties[i].StartsWith(this.SEPARATOR))
					existedKeys-- ;
			}			
			this.keys = new string[existedKeys] ;
			this.values = new string[existedKeys] ;
			
			int j=0 ; //j is keys and values last position counter
			for(int i=0; i<allProperties.Length; i++){
				//if not '=' existed or starts with (have no key name) go next
				if(allProperties[i].Contains(this.SEPARATOR)||!allProperties[i].StartsWith(this.SEPARATOR)){
					eachProperty = allProperties[i].Split(this.SEPARATOR.ToCharArray(), 2) ; //return only 2 substrings, with this way more than 1 '=' allowed in a line. The first one determinate the end of the key, and any other used as value
					this.keys[j] = eachProperty[0] ;
					this.values[j] = eachProperty[1] ;
					j++ ;
				}
			}
		}
		
		/// <summary>
		/// Save pairs of values and keys at properites file
		/// </summary>		
		public void Save(){
			string[] allProperties = new string[this.keys.Length] ;
			for(int i=0; i<allProperties.Length; i++)
				allProperties[i] = string.Concat(this.keys[i], this.SEPARATOR, this.values[i]) ;
			File.WriteAllLines(this.file, allProperties) ;
		}
		
		/// <summary>
		/// Returns the value of the specified key
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <returns>The value of the specified key, null if key not exist</returns>
		public string GetProperty(string key){
			int keyIndex = GetKeyIndex(key) ;
			if(keyIndex < 0)
				return null ;
			else 
				return values[keyIndex] ;
		}
		
		/// <summary>
		/// Sets the specified value to the key. If key not exist, creating it and store the value.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="val">The value wants to set to the key</param>
 		/// <exception cref="Exception">If key's name contains separator character '=' an exception throwed preventing errors</exception>
 		public void SetProperty(string key, string val){
 			// Separator in key name does not allowed, so if key contains '=' throw new exception preventing errors
 			if(key.Contains(this.SEPARATOR))
 				throw new Exception("Bad key name") ;
 			
			int keyIndex = GetKeyIndex(key) ;
			if(keyIndex > -1)
				values[keyIndex] = val ;				
			else
				AddProperty(key, val) ;
			
			if(this.autosave)
				Save() ;
		}
		
		/// <summary>
		/// Removes the specified key. If not exist do nothing.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <returns>true if done, false if key not found</returns>
		public bool DelProperty(string key){
			//get the index of the specified key, if is -1 (key not exist) do nothing
			int keyIndex = GetKeyIndex(key) ;
			if(keyIndex == -1)
				return false ;
			
			/* if key exist, set the last values of the tables (keys, values) at the index position
			 * then, make 2 temporary tables with the size of others minus 1,
			 * copy the contents of the tables except the last to the temp tables,
			 * finally clone the temp tables and set these obgects to the original tables. */
			
			this.keys[keyIndex] = this.keys[this.keys.Length - 1] ;
			this.values[keyIndex] = this.values[this.values.Length-1] ;
			
			int newLenght = this.keys.Length - 1 ;
			string[] keysTemp = new string[newLenght] ;
			string[] valuesTemp = new string[newLenght] ;
			
			for(int i=0; i<newLenght; i++){
				keysTemp[i] = this.keys[i] ;
				valuesTemp[i] = this.values[i] ;
			}
			
			keys = (string[])keysTemp.Clone() ;
			values = (string[])valuesTemp.Clone() ;
			
			if(this.autosave)
				Save() ;
			
			return true ;
		}
		
		/// <summary>
		/// Add the specified property (key,value) to the list.
		/// Private for inner use only. -Property added by SetProperty(key,val) method, if key not exist.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="val">The value wants to set to the key</param>
		private void AddProperty(string key, string val){			
			/* create 2 temporary tabled with the size of others plus 1,
			 * copy the contents of the tables to the temporary
			 * and add at the last position the specified new key/value
			 * finally clone the temp tables and set these obgects to the original tables. */
			
			int newLenght = this.keys.Length + 1 ;
			string[] keysTemp = new string[newLenght] ;
			string[] valuesTemp = new string[newLenght] ;
			
			for(int i=0; i<newLenght - 1; i++){
				keysTemp[i] = this.keys[i] ;
				valuesTemp[i] = this.values[i] ;
			}
			
			keysTemp[newLenght - 1] = key ;
			valuesTemp[newLenght - 1] = val ;
			
			keys = (string[])keysTemp.Clone() ;
			values = (string[])valuesTemp.Clone() ;
			
			if(this.autosave)
				Save() ;
		}
		
		/// <summary>
		/// Search and returns the index of the specified key, ignore case
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <returns>The index of the specified key, if not found returns -1</returns>
		private int GetKeyIndex(string key){
			for(int i=0; i<keys.Length; i++)
				if(String.Compare(keys[i], key, true) == 0)
					return i ;
			return -1 ;
		}
		
		/// <summary>
		/// Sets the specified value, encoded with Base64 formula, to the key. If key not exist, creating it and store the value.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="val">The value wants to set after encoding it to the key</param>
		public void SetPropertyEncoded(string key, string val){
			string encodedValue = Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(val)) ;
			this.SetProperty(key, encodedValue) ;
		}
		
		/// <summary>
		/// Returns the value of the specified key, decoded from Base64 format
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <returns>The value of the specified key, decoded from Base64 format, null if key not found</returns>
		public string GetPropertyDecoded(string key){
			string encodedValue = this.GetProperty(key) ;
			if(encodedValue == null) //if key not found return null, no decode
				return null ;
			
			string decodedValue = System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(encodedValue)) ;
			return decodedValue ;
		}
		
		/// <summary>
		/// Returns the value of the specified key, decoded from Base64 format.
		/// And specify if return empty string or null if key not found.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="emptyStrInsteadNull">True to return empty string if key not found, false to return null</param>
		/// <returns>The value of the specified key, decoded from Base64 format</returns>
		public string GetPropertyDecoded(string key, bool emptyStrInsteadNull){
			string decodedValue = this.GetPropertyDecoded(key) ;
			if(decodedValue == null){
				if(emptyStrInsteadNull)
					return "" ;
				return null ;
			}
			
			return decodedValue ;
		}
		
		/// <summary>
		/// Returns the value of the specified key.
		/// And specify if return empty string or null if key not found.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="emptyStrInsteadNull">True to return empty string if key not found, false to return null</param>
		/// <returns>The value of the specified key, null if key not exist</returns>
		public string GetProperty(string key, bool emptyStrInsteadNull){
			string val = this.GetProperty(key) ;			
			if(val == null){
				if(emptyStrInsteadNull)
					return "" ;
				return null ;
			}
			
			return val ;
		}
		
	}
}
