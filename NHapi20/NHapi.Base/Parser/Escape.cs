/// <summary>The contents of this file are subject to the Mozilla Public License Version 1.1 
/// (the "License"); you may not use this file except in compliance with the License. 
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/ 
/// Software distributed under the License is distributed on an "AS IS" basis, 
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the 
/// specific language governing rights and limitations under the License. 
/// The Original Code is "Escape.java".  Description: 
/// "Handles "escaping" and "unescaping" of text according to the HL7 escape sequence rules
/// defined in section 2.10 of the standard (version 2.4)" 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C) 
/// 2001.  All Rights Reserved. 
/// Contributor(s): Mark Lee (Skeva Technologies); Elmar Hinz 
/// Alternatively, the contents of this file may be used under the terms of the 
/// GNU General Public License (the  “GPL”), in which case the provisions of the GPL are 
/// applicable instead of those above.  If you wish to allow use of your version of this 
/// file only under the terms of the GPL and not to allow others to use your version 
/// of this file under the MPL, indicate your decision by deleting  the provisions above 
/// and replace  them with the notice and other provisions required by the GPL License.  
/// If you do not delete the provisions above, a recipient may use your version of 
/// this file under either the MPL or the GPL. 
/// </summary>
using System;
using System.Collections.Specialized;
using System.Collections;
namespace NHapi.Base.Parser
{

    /// <summary> Handles "escaping" and "unescaping" of text according to the HL7 escape sequence rules
    /// defined in section 2.10 of the standard (version 2.4).  Currently, escape sequences for 
    /// multiple character sets are unsupported.  The highlighting, hexademical, and locally 
    /// defined escape sequences are also unsupported.  
    /// </summary>
    /// <author>  Bryan Tripp
    /// </author>
    public class Escape
    {
		//This items are are to not be escaped when building the message
		private static string[] NON_ESCAPE_CHARACTERS = new string[] { @"\.", @"\X", @"\Z", @"\C", @"\M", @"\H", @"\N", @"\S" };
		private static Hashtable _nonEscapeCharacterMapping = new Hashtable();
        private static System.Collections.Hashtable variousEncChars = new System.Collections.Hashtable(5);

		static Escape()
		{
			foreach (string element in NON_ESCAPE_CHARACTERS)
			{
				_nonEscapeCharacterMapping.Add(element, element);
			}
		}
        /// <summary>Creates a new instance of Escape </summary>
        public Escape()
        {
			
        }

		private static Hashtable InvertHash(Hashtable htIn)
		{
			Hashtable ht = new Hashtable(htIn.Count);
			foreach (string key in htIn.Keys)
			{
				char[] newKey = htIn[key].ToString().ToCharArray();
				ht[newKey[0]] = key;
			}
			return ht;
		}

		
		
        /// <summary>
        /// Escape string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encChars"></param>
        /// <returns></returns>
        public static System.String escape(System.String text, EncodingCharacters encChars)
        {
			//Note: Special character sequences are like \.br\.  Items like this should not
			//be escaped using the \E\ method for the \'s.  Instead, just tell the encoding to
			//skip these items.
			char[] textAsChar = text.ToCharArray();
			
            System.Text.StringBuilder result = new System.Text.StringBuilder(text.Length);
			Hashtable specialCharacters = InvertHash(getEscapeSequences(encChars));
			bool isEncodingSpecialCharacterSequence = false;
			bool encodeCharacter = false;
			for (int i = 0; i < textAsChar.Length; i++)
			{
				encodeCharacter = false;
				if (isEncodingSpecialCharacterSequence)
				{
					encodeCharacter = false;
					if(textAsChar[i].Equals(encChars.EscapeCharacter))
						isEncodingSpecialCharacterSequence = false;
				}
				else
				{
					if (specialCharacters[textAsChar[i]] != null)
					{
						//Special character
						encodeCharacter = true;
						if (textAsChar[i].Equals(encChars.EscapeCharacter))
						{
							//Check for special escaping
							if (i < textAsChar.Length - 1)
							{
								//The data is specially escaped, treat it that way by not encoding the escape character
								if (_nonEscapeCharacterMapping[textAsChar[i].ToString() + textAsChar[i + 1].ToString()] != null)
								{
									//Start buffering this
									isEncodingSpecialCharacterSequence = true;
									encodeCharacter = false;
								}
							}
						}	
					}
				}

				if (encodeCharacter)
					result.Append(specialCharacters[textAsChar[i]]);
				else
					result.Append(textAsChar[i]);
			}		
			if (result.Length > 0)
				return result.ToString().Trim();
			else
				return "";
        }

        /// <summary>
        /// Unescape the string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encChars"></param>
        /// <returns></returns>
        public static System.String unescape(System.String text, EncodingCharacters encChars)
        {
            // is there an escape character in the text at all?
            if (text.IndexOf(encChars.EscapeCharacter) == -1)
            {
                return text;
            }

            System.Text.StringBuilder result = new System.Text.StringBuilder();
            int textLength = text.Length;
            System.Collections.Hashtable esc = getEscapeSequences(encChars);
            SupportClass.ISetSupport keys = new SupportClass.HashSetSupport(esc.Keys);
            System.String escChar = System.Convert.ToString(encChars.EscapeCharacter);
            int position = 0;
            while (position < textLength)
            {
                System.Collections.IEnumerator it = keys.GetEnumerator();
                bool isReplaced = false;
                while (it.MoveNext() && !isReplaced)
                {
                    System.String seq = (System.String)it.Current;
                    System.String val = (System.String)esc[seq];
                    int seqLength = seq.Length;
                    if (position + seqLength <= textLength)
                    {
                        if (text.Substring(position, (position + seqLength) - (position)).Equals(seq))
                        {
                            result.Append(val);
                            isReplaced = true;
                            position = position + seq.Length;
                        }
                    }
                }
                if (!isReplaced)
                {
                    result.Append(text.Substring(position, ((position + 1)) - (position)));
                    position++;
                }
            }
            return result.ToString();
        }

           /// <summary> Returns a HashTable with escape sequences as keys, and corresponding 
        /// Strings as values.  
        /// </summary>
        private static System.Collections.Hashtable getEscapeSequences(EncodingCharacters encChars)
        {
            //escape sequence strings must be assembled using the given escape character 
            //see if this has already been done for this set of encoding characters
            System.Collections.Hashtable escapeSequences = null;
            System.Object o = variousEncChars[encChars];
            if (o == null)
            {
                //this means we haven't got the sequences for these encoding characters yet - let's make them
                escapeSequences = makeEscapeSequences(encChars);
                variousEncChars[encChars] = escapeSequences;
            }
            else
            {
                //we already have escape sequences for these encoding characters
                escapeSequences = (System.Collections.Hashtable)o;
            }
            return escapeSequences;
        }

        /// <summary> Constructs escape sequences using the given escape character - this should only 
        /// be called by getEscapeCharacter(), which will cache the results for subsequent use.
        /// </summary>
        private static System.Collections.Hashtable makeEscapeSequences(EncodingCharacters ec)
        {
            System.Collections.Hashtable seqs = new System.Collections.Hashtable();
            char[] codes = new char[] { 'F', 'S', 'T', 'R', 'E' };
            char[] values = new char[] { ec.FieldSeparator, ec.ComponentSeparator, ec.SubcomponentSeparator, ec.RepetitionSeparator, ec.EscapeCharacter };
            for (int i = 0; i < codes.Length; i++)
            {
                System.Text.StringBuilder seq = new System.Text.StringBuilder();
                seq.Append(ec.EscapeCharacter);
                seq.Append(codes[i]);
                seq.Append(ec.EscapeCharacter);
                seqs[seq.ToString()] = System.Convert.ToString(values[i]);
            }
            seqs["\\X000d\\"] = System.Convert.ToString('\r');
            return seqs;
        }

        /// <summary> Test harness</summary>
        [STAThread]
        public static void Main(System.String[] args)
        {
            System.String testString = "foo$r$this is $ $p$test$r$r$ string";
            //System.out.println(testString);
            //System.out.println(replace(testString, "$r$", "***"));
            //System.out.println(replace(testString, "$", "+"));

            //test speed gain with cache
            int n = 100000;
            System.Collections.Hashtable seqs;
            EncodingCharacters ec = new EncodingCharacters('|', "^~\\&");
            //warm up the JIT 
            for (int i = 0; i < n; i++)
            {
                seqs = makeEscapeSequences(ec);
            }
            for (int i = 0; i < n; i++)
            {
                seqs = getEscapeSequences(ec);
            }
            //time
            long start = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;
            for (int i = 0; i < n; i++)
            {
                seqs = makeEscapeSequences(ec);
            }
            System.Console.Out.WriteLine("Time to make " + n + " times: " + ((System.DateTime.Now.Ticks - 621355968000000000) / 10000 - start));
            start = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;
            for (int i = 0; i < n; i++)
            {
                seqs = getEscapeSequences(ec);
            }
            System.Console.Out.WriteLine("Time to get " + n + " times: " + ((System.DateTime.Now.Ticks - 621355968000000000) / 10000 - start));
            start = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;
            for (int i = 0; i < n; i++)
            {
                seqs = makeEscapeSequences(ec);
            }
            System.Console.Out.WriteLine("Time to make " + n + " times: " + ((System.DateTime.Now.Ticks - 621355968000000000) / 10000 - start));

            //test escape: 
            testString = "this | is ^ a field \\T\\ with & some ~ bad stuff \\T\\";
            System.Console.Out.WriteLine("Original:  " + testString);
            System.String escaped = escape(testString, ec);
            System.Console.Out.WriteLine("Escaped:   " + escaped);
            System.Console.Out.WriteLine("Unescaped: " + unescape(escaped, ec));
        }
    }
}