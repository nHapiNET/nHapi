/// <summary> The contents of this file are subject to the Mozilla Public License Version 1.1
/// (the "License"); you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/
/// Software distributed under the License is distributed on an "AS IS" basis,
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
/// specific language governing rights and limitations under the License.
/// 
/// The Original Code is "SourceGenerator.java".  Description:
/// "Manages automatic generation of HL7 API source code for all data types,
/// segments, groups, and message structures"
/// 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C)
/// 2001.  All Rights Reserved.
/// 
/// Contributor(s): ______________________________________.
/// 
/// Alternatively, the contents of this file may be used under the terms of the
/// GNU General Public License (the  “GPL”), in which case the provisions of the GPL are
/// applicable instead of those above.  If you wish to allow use of your version of this
/// file only under the terms of the GPL and not to allow others to use your version
/// of this file under the MPL, indicate your decision by deleting  the provisions above
/// and replace  them with the notice and other provisions required by the GPL License.
/// If you do not delete the provisions above, a recipient may use your version of
/// this file under either the MPL or the GPL.
/// 
/// </summary>

using System;
using System.Reflection;
using System.Text;
using HL7Exception = NHapi.Base.HL7Exception;
using NHapi.Base.Parser;
using System.IO;

namespace NHapi.Base.SourceGeneration
{
	/// <summary> <p>Manages automatic generation of HL7 API source code for all data types,
	/// segments, groups, and message structures. </p>
	/// <p>Note: should put a nice UI on this</p>
	/// </summary>
	/// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
	/// </author>
	public class SourceGenerator : Object
	{
		/// <summary>Creates new SourceGenerator </summary>
		public SourceGenerator()
		{
		}

		public static void MakeEventMapping(String baseDirectory, String version)
		{
			EventMappingGenerator.makeAll(baseDirectory, version);
		}

		/// <summary> Generates source code for all data types, segments, groups, and messages.</summary>
		/// <param name="baseDirectory">the directory where source should be written
		/// </param>
		public static void makeAll(String baseDirectory, String version)
		{
			try
			{
				DataTypeGenerator.makeAll(baseDirectory, version);
				SegmentGenerator.makeAll(baseDirectory, version);
				MessageGenerator.makeAll(baseDirectory, version);
				BaseDataTypeGenerator.BuildBaseDataTypes(baseDirectory, version);
			}
			catch (Exception e)
			{
				SupportClass.WriteStackTrace(e, Console.Error);
			}
		}

		public static string MakeName(string fieldDesc)
		{
			//char[] nameChar = fieldDesc.ToCharArray();
			//System.Text.StringBuilder nameFixed = new System.Text.StringBuilder();
			//for (int i = 0; i < nameChar.Length; i++)
			//{
			//    if (char.IsLetterOrDigit(nameChar[i]))
			//    {
			//        nameFixed.Append(nameChar[i]);
			//    }
			//    if (nameChar[i] == ' ')
			//    {
			//        nameFixed.Append(" ");
			//    }
			//}
			//string[] splits = nameFixed.ToString().Split(' ');
			//System.Text.StringBuilder sb = new System.Text.StringBuilder();
			//foreach (string split in splits)
			//{
			//    if (split.Trim().Length > 0)
			//    {
			//        sb.Append(GetWord(split));
			//    }
			//}
			//return sb.ToString();
			StringBuilder aName = new StringBuilder();
			char[] chars = fieldDesc.ToCharArray();
			bool lastCharWasNotLetter = true;
			int inBrackets = 0;
			StringBuilder bracketContents = new StringBuilder();
			for (int i = 0; i < chars.Length; i++)
			{
				if (chars[i] == '(')
					inBrackets++;
				if (chars[i] == ')')
					inBrackets--;

				if (Char.IsLetterOrDigit(chars[i]))
				{
					if (inBrackets > 0)
					{
						//buffer everthing in brackets
						bracketContents.Append(chars[i]);
					}
					else
					{
						//add capitalized bracketed text if appropriate 
						if (bracketContents.Length > 0)
						{
							aName.Append(capitalize(filterBracketedText(bracketContents.ToString())));
							bracketContents = new StringBuilder();
						}
						if (lastCharWasNotLetter)
						{
							//first letter of each word is upper-case
							aName.Append(Char.ToUpper(chars[i]));
						}
						else
						{
							aName.Append(chars[i]);
						}
						lastCharWasNotLetter = false;
					}
				}
				else
				{
					lastCharWasNotLetter = true;
				}
			}
			aName.Append(capitalize(filterBracketedText(bracketContents.ToString())));
			if (Char.IsDigit(aName[0]))
			{
				return "Get" + aName.ToString();
			}
			else
				return aName.ToString();
		}


		public static string MakePropertyName(string fieldDesc)
		{
			string name = MakeName(fieldDesc);
			return name;
		}

		/// <summary> Make a Java-ish accessor method name out of a field or component description
		/// by removing non-letters and adding "get".  One complication is that some description
		/// entries in the DB have their data types in brackets, and these should not be
		/// part of the method name.  On the other hand, sometimes critical distinguishing
		/// information is in brackets, so we can't omit everything in brackets.  The approach
		/// taken here is to eliminate bracketed text if a it looks like a data type.
		/// </summary>
		public static String MakeAccessorName(String fieldDesc)
		{
			return MakeName(fieldDesc);
		}

		/// <summary> Make a C#-ish accessor method name out of a field or component description
		/// by removing non-letters and adding "get".  One complication is that some description
		/// entries in the DB have their data types in brackets, and these should not be
		/// part of the method name.  On the other hand, sometimes critical distinguishing
		/// information is in brackets, so we can't omit everything in brackets.  The approach
		/// taken here is to eliminate bracketed text if a it looks like a data type.
		/// </summary>
		public static String MakeAccessorName(String fieldDesc, int repitions)
		{
			string name = MakeName(fieldDesc);
			if (repitions != 1 && !name.StartsWith("Get"))
				name = "Get" + name;


			return name;
		}

		/// <summary> Bracketed text in a field description should be included in the accessor 
		/// name unless it corresponds to a data type name. Given the text that appears in 
		/// brackets in a field description, this method returns an empty string if it 
		/// corresponds to a data type name, or returns original text if not.  It isn't 
		/// convenient to actually check (e.g. with DataTypeGenerator) whether the given 
		/// text actually corresponds to a data type name, so we are going to conclude that 
		/// it is a data type if and only if it is all caps and has 2 or 3 characters.  
		/// </summary>
		private static String filterBracketedText(String text)
		{
			String filtered = "";
			bool isDataType = true;
			if (!text.Equals(text.ToUpper()))
				isDataType = false;
			if (text.Length < 2 || text.Length > 3)
				isDataType = false;

			if (!isDataType)
				filtered = text;
			return filtered;
		}

		/// <summary>Capitalizes first character of the given text. </summary>
		private static String capitalize(String text)
		{
			StringBuilder cap = new StringBuilder();
			if (text.Length > 0)
			{
				cap.Append(Char.ToUpper(text[0]));
				cap.Append(text.Substring(1, (text.Length) - (1)));
			}
			return cap.ToString();
		}

		/// <summary> Creates the given directory if it does not exist.</summary>
		public static FileInfo makeDirectory(String directory)
		{
			SupportClass.Tokenizer tok = new SupportClass.Tokenizer(directory, "\\/", false);
			if (!Directory.Exists(directory))
				return new FileInfo(Directory.CreateDirectory(directory).FullName);
			else
				return new FileInfo(directory);
		}

		/// <summary> <p>Returns either the given data type name or an alternate data type that Composites
		/// and Segments should use in place of the given Type.  </p>
		/// <p>As currently implemented, substitutions
		/// may be desired if there is a validating subclass of the given Type.
		/// By convention such classes would be named ValidX (where X is the Type name).  This
		/// method checks the classpath for classes of this name in the datatype package and
		/// returns this name if one is found.</p>
		/// <p>Also converts "varies" to Varies which is an implementation of Type that contains
		/// a Type that can be set at run-time.</p>
		/// </summary>
		public static String getAlternateType(String dataTypeName, String version)
		{
			String ret = dataTypeName;

			//convert to varies to Varies
			if (ret.Equals("varies"))
				ret = "Varies";

			//Valid.. classes are removed as of HAPI 0.3 (validating code implemented directly in Primitive classes
			/*try {
            Class.forName(getVersionPackageName(version) + "datatype.Valid" + dataTypeName);
            ret = "Valid" + dataTypeName;
            } catch (Exception e) {
            // fine ... there isn't a ValidX implementation
            // I don't like using Class.forName here but I don't know a better way to
            // search for the class 
            }*/

			return ret;
		}


		[STAThread]
		public static void Main(String[] args)
		{
			if (args.Length != 2)
			{
				Console.Out.WriteLine("Usage: SourceGenerator base_directory version");
				Environment.Exit(1);
			}
			makeAll(args[0], args[1]);
		}
	}
}