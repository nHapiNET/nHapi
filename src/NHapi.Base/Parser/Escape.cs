/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "Escape.java".  Description:
  "Handles "escaping" and "unescaping" of text according to the HL7 escape sequence rules
  defined in section 2.10 of the standard (version 2.4)"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): Mark Lee (Skeva Technologies); Elmar Hinz; Eric Steinbrenner

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

using System;
using System.Collections;
using System.Linq;
using System.Text;

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
        // This items are are to not be escaped when building the message
        private static string[] NON_ESCAPE_CHARACTERS = new string[] { @"\.", @"\X", @"\Z", @"\C", @"\M", @"\H", @"\N", @"\S" };
        private static string[] SINGLE_CHAR_NON_ESCAPE_CHARACTERS = new string[] { @"H", @"N", @"S", @"T", @"R", @"F", @"E" };
        private static string[] MULTI_CHAR_NON_ESCAPE_CHARACTERS = new string[] { @"X", @"Z", @"C", @"M" };
        private static Hashtable _nonEscapeCharacterMapping = new Hashtable();
        private static Hashtable _singleCharNonEscapeCharacterMapping = new Hashtable();
        private static Hashtable _multiCharNonEscapeCharacterMapping = new Hashtable();
        private static Hashtable variousEncChars = new Hashtable(5);
        private static char[] HexDigits = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        static Escape()
        {
            foreach (string element in NON_ESCAPE_CHARACTERS)
            {
                _nonEscapeCharacterMapping.Add(element, element);
            }

            foreach (string element in SINGLE_CHAR_NON_ESCAPE_CHARACTERS)
            {
                _singleCharNonEscapeCharacterMapping.Add(element, element);
            }

            foreach (string element in MULTI_CHAR_NON_ESCAPE_CHARACTERS)
            {
                _multiCharNonEscapeCharacterMapping.Add(element, element);
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
        public static string escape(string text, EncodingCharacters encChars)
        {
            // Note: Special character sequences are like \.br\.  Items like this should not
            // be escaped using the \E\ method for the \'s.  Instead, just tell the encoding to
            // skip these items.
            char[] textAsChar = text.ToCharArray();

            StringBuilder result = new StringBuilder(text.Length);
            Hashtable specialCharacters = InvertHash(getEscapeSequences(encChars));
            bool isEncodingSpecialCharacterSequence = false;
            bool encodeCharacter = false;
            for (int i = 0; i < textAsChar.Length; i++)
            {
                encodeCharacter = false;
                if (isEncodingSpecialCharacterSequence)
                {
                    encodeCharacter = false;
                    if (textAsChar[i].Equals(encChars.EscapeCharacter))
                        isEncodingSpecialCharacterSequence = false;
                }
                else
                {
                    if (specialCharacters[textAsChar[i]] != null)
                    {
                        // Special character
                        encodeCharacter = true;
                        if (textAsChar[i].Equals(encChars.EscapeCharacter))
                        {
                            int nextEscapeChar = text.IndexOf(encChars.EscapeCharacter, i + 1);
                            if (nextEscapeChar == i + 2)
                            {
                                // The data is specially escaped, treat it that way by not encoding the escape character
                                if (_singleCharNonEscapeCharacterMapping[textAsChar[i + 1].ToString()] != null)
                                {
                                    // Start buffering this
                                    encodeCharacter = false;
                                    isEncodingSpecialCharacterSequence = true;
                                }
                            }
                            else if (nextEscapeChar != -1)
                            {
                                if (_multiCharNonEscapeCharacterMapping[textAsChar[i + 1].ToString()] != null)
                                {
                                    // Contains /#xxyyzz..nn/ from the main string.
                                    string potentialEscapeSequence = text.Substring(i, nextEscapeChar - i + 1);
                                    bool encodeCharacter1 = true;

                                    // Get the hex component by striping initial slash, escape character, and last slash. Need to substring at index 2 for length - 3 characters.
                                    string hex = potentialEscapeSequence.Substring(2, potentialEscapeSequence.Length - 3);
                                    if (hex.Length % 2 == 0)
                                    {
                                        switch (potentialEscapeSequence.Substring(0, 2))
                                        {
                                            case "\\C":
                                                // Look for closing character of \Cxxyy\
                                                if (hex.All(c => HexDigits.Contains(char.ToUpper(c))))
                                                {
                                                    encodeCharacter1 = false;
                                                    isEncodingSpecialCharacterSequence = true;
                                                }

                                                break;
                                            case "\\M":
                                                // Look for closing character of \Mxxyy\ or Mxxyyzz
                                                if (hex.All(c => HexDigits.Contains(char.ToUpper(c))))
                                                {
                                                    encodeCharacter1 = false;
                                                    isEncodingSpecialCharacterSequence = true;
                                                }

                                                break;
                                            case "\\X":
                                                if (hex.All(c => HexDigits.Contains(char.ToUpper(c))))
                                                {
                                                    encodeCharacter1 = false;
                                                    isEncodingSpecialCharacterSequence = true;
                                                }

                                                break;
                                            case "\\Z":
                                                // We don't support this.
                                                // if (hex.All(c => HexDigits.Contains(char.ToUpper(c))))
                                                // {
                                                //    encodeCharacter = false;
                                                //    isEncodingSpecialCharacterSequence = true;
                                                // }
                                                break;
                                        }
                                    }

                                    encodeCharacter = encodeCharacter1;
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
                return string.Empty;
        }

        /// <summary>
        /// Unescape the string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encChars"></param>
        /// <returns></returns>
        public static string unescape(string text, EncodingCharacters encChars)
        {
            // is there an escape character in the text at all?
            if (text.IndexOf(encChars.EscapeCharacter) == -1)
            {
                return text;
            }

            StringBuilder result = new StringBuilder();
            int textLength = text.Length;
            Hashtable esc = getEscapeSequences(encChars);
            SupportClass.ISetSupport keys = new SupportClass.HashSetSupport(esc.Keys);
            string escChar = Convert.ToString(encChars.EscapeCharacter);
            int position = 0;
            while (position < textLength)
            {
                IEnumerator it = keys.GetEnumerator();
                bool isReplaced = false;
                while (it.MoveNext() && !isReplaced)
                {
                    string seq = (string)it.Current;
                    string val = (string)esc[seq];
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
        private static Hashtable getEscapeSequences(EncodingCharacters encChars)
        {
            // escape sequence strings must be assembled using the given escape character
            // see if this has already been done for this set of encoding characters
            Hashtable escapeSequences = null;
            object o = variousEncChars[encChars];
            if (o == null)
            {
                // this means we haven't got the sequences for these encoding characters yet - let's make them
                escapeSequences = makeEscapeSequences(encChars);
                variousEncChars[encChars] = escapeSequences;
            }
            else
            {
                // we already have escape sequences for these encoding characters
                escapeSequences = (Hashtable)o;
            }

            return escapeSequences;
        }

        /// <summary> Constructs escape sequences using the given escape character - this should only
        /// be called by getEscapeCharacter(), which will cache the results for subsequent use.
        /// </summary>
        private static Hashtable makeEscapeSequences(EncodingCharacters ec)
        {
            Hashtable seqs = new Hashtable();
            char[] codes = new char[] { 'F', 'S', 'T', 'R', 'E' };
            char[] values = new char[]
            {ec.FieldSeparator, ec.ComponentSeparator, ec.SubcomponentSeparator, ec.RepetitionSeparator, ec.EscapeCharacter};
            for (int i = 0; i < codes.Length; i++)
            {
                StringBuilder seq = new StringBuilder();
                seq.Append(ec.EscapeCharacter);
                seq.Append(codes[i]);
                seq.Append(ec.EscapeCharacter);
                seqs[seq.ToString()] = Convert.ToString(values[i]);
            }

            // \\x....\\ denotes hexadecimal escaping
            // Convert the .... hexadecimal values into decimal, which map to ascii characters
            seqs["\\X000d\\"] = Convert.ToString('\r'); // 00 > null, 0D > CR
            seqs["\\X0A\\"] = Convert.ToString('\n'); // 0A > LF
            return seqs;
        }

        /// <summary> Test harness</summary>
        [STAThread]
        public static void Main(string[] args)
        {
            string testString = "foo$r$this is $ $p$test$r$r$ string";

            // System.out.println(testString);
            // System.out.println(replace(testString, "$r$", "***"));
            // System.out.println(replace(testString, "$", "+"));

            // test speed gain with cache
            int n = 100000;
            Hashtable seqs;
            EncodingCharacters ec = new EncodingCharacters('|', "^~\\&");

            // warm up the JIT
            for (int i = 0; i < n; i++)
            {
                seqs = makeEscapeSequences(ec);
            }

            for (int i = 0; i < n; i++)
            {
                seqs = getEscapeSequences(ec);
            }

            // time
            long start = (DateTime.Now.Ticks - 621355968000000000) / 10000;
            for (int i = 0; i < n; i++)
            {
                seqs = makeEscapeSequences(ec);
            }

            Console.Out.WriteLine("Time to make " + n + " times: " + ((DateTime.Now.Ticks - 621355968000000000) / 10000 - start));
            start = (DateTime.Now.Ticks - 621355968000000000) / 10000;
            for (int i = 0; i < n; i++)
            {
                seqs = getEscapeSequences(ec);
            }

            Console.Out.WriteLine("Time to get " + n + " times: " + ((DateTime.Now.Ticks - 621355968000000000) / 10000 - start));
            start = (DateTime.Now.Ticks - 621355968000000000) / 10000;
            for (int i = 0; i < n; i++)
            {
                seqs = makeEscapeSequences(ec);
            }

            Console.Out.WriteLine("Time to make " + n + " times: " + ((DateTime.Now.Ticks - 621355968000000000) / 10000 - start));

            // test escape:
            testString = "this | is ^ a field \\T\\ with & some ~ bad stuff \\T\\";
            Console.Out.WriteLine("Original:  " + testString);
            string escaped = escape(testString, ec);
            Console.Out.WriteLine("Escaped:   " + escaped);
            Console.Out.WriteLine("Unescaped: " + unescape(escaped, ec));
        }
    }
}