/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "Escape.java".  Description:
  "Handles "escaping" and "un-escaping" of text according to the HL7 escape sequence rules
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

namespace NHapi.Base.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;

    using NHapi.Base.Model.Configuration;

    /// <summary>
    /// Handles "escaping" and "un-escaping" of text according to the HL7 escape sequence rules
    /// defined in section 2.10 of the standard (version 2.4).  Currently, escape sequences for
    /// multiple character sets are unsupported.  The highlighting, hexadecimal, and locally
    /// defined escape sequences are also unsupported.
    /// </summary>
    /// <author>Bryan Tripp.</author>
    public class Escape
    {
        /// <summary>
        /// Is used to cache multiple <see cref="EncodingLookups"/> keyed on <see cref="EncodingCharacters"/>
        /// for quick re-use.
        /// </summary>
        private static readonly IDictionary<EncodingCharacters, EncodingLookups> VariousEncChars = new Dictionary<EncodingCharacters, EncodingLookups>();

        [Obsolete("This method has been replaced by 'EscapeText'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static string escape(string text, EncodingCharacters encChars)
        {
            return EscapeText(text, encChars);
        }

        /// <summary>
        /// Escape string.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encodingCharacters"></param>
        /// <returns></returns>
        public static string EscapeText(string text, EncodingCharacters encodingCharacters)
        {
            var lookup = BuildEncodingLookups(encodingCharacters);
            var result = new StringBuilder();

            for (var i = 0; i < text.Length; i++)
            {
                var charReplaced = false;
                var currentCharacter = text[i];

                if (!lookup.SpecialCharacters.Contains(currentCharacter))
                {
                    result.Append(currentCharacter);
                    continue;
                }

                // Formatting escape sequences such as \.br\ should be left alone
                if (currentCharacter == encodingCharacters.EscapeCharacter)
                {
                    var nextCharacterIndex = i + 1;

                    if (nextCharacterIndex < text.Length)
                    {
                        var nextCharacter = text[nextCharacterIndex];

                        // Check for \.br\
                        switch (nextCharacter)
                        {
                            case '.':
                            case 'C':
                            case 'M':
                            case 'X':
                            case 'Z':
                                var nextEscapeCharacterIndex = text.IndexOf(currentCharacter, nextCharacterIndex);
                                if (nextEscapeCharacterIndex > 0)
                                {
                                    result.Append(text, i, (nextEscapeCharacterIndex + 1) - i);
                                    charReplaced = true;
                                    i = nextEscapeCharacterIndex;
                                }

                                break;

                            case 'H':
                            case 'N':
                                var twoCharactersAheadIndex = i + 2;
                                if (twoCharactersAheadIndex < text.Length && text[twoCharactersAheadIndex] == encodingCharacters.EscapeCharacter)
                                {
                                    if (twoCharactersAheadIndex > 0)
                                    {
                                        result.Append(text, i, (twoCharactersAheadIndex + 1) - i);
                                        charReplaced = true;
                                        i = twoCharactersAheadIndex;
                                    }
                                }

                                break;
                        }
                    }
                }

                if (charReplaced)
                {
                    continue;
                }

                result.Append(lookup.EscapeSequences[currentCharacter]);
            }

            return result.ToString();
        }

        [Obsolete("This method has been replaced by 'UnescapeText'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static string unescape(string text, EncodingCharacters encodingCharacters)
        {
            return UnescapeText(text, encodingCharacters);
        }

        /// <summary>
        /// Un-escape the string.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encodingCharacters"></param>
        /// <returns></returns>
        public static string UnescapeText(string text, EncodingCharacters encodingCharacters)
        {
            // If the escape char isn't found, we don't need to look for escape sequences
            // is there an escape character in the text at all?
            if (text.IndexOf(encodingCharacters.EscapeCharacter) == -1)
            {
                return text;
            }

            var result = new StringBuilder();
            var lookup = BuildEncodingLookups(encodingCharacters);

            for (var i = 0; i < text.Length; i++)
            {
                var currentCharacter = text[i];

                if (currentCharacter != encodingCharacters.EscapeCharacter)
                {
                    result.Append(currentCharacter);
                    continue;
                }

                var foundEncoding = false;

                foreach (var keyValuePair in lookup.EscapeSequences)
                {
                    var escapeSequence = keyValuePair.Value;
                    var character = keyValuePair.Key;
                    var escapeSequenceLength = escapeSequence.Length;

                    var canExtractSubstring = i + escapeSequenceLength <= text.Length;
                    if (canExtractSubstring && text.Substring(i, escapeSequenceLength).Equals(escapeSequence))
                    {
                        result.Append(character);
                        i += escapeSequenceLength - 1;
                        foundEncoding = true;
                        break;
                    }
                }

                if (foundEncoding)
                {
                    continue;
                }

                // If we haven't found this, there is one more option. Escape sequences of /.XXXXX/ are
                // formatting codes. They should be left intact
                var nextCharacterIndex = i + 1;
                if (nextCharacterIndex < text.Length)
                {
                    var nextCharacter = text[nextCharacterIndex];
                    var closingEscapeIndex = text.IndexOf(encodingCharacters.EscapeCharacter, nextCharacterIndex);
                    var escapeSequenceLength = (closingEscapeIndex + 1) - i;

                    switch (nextCharacter)
                    {
                        case '.':
                        case 'C':
                        case 'M':
                        case 'X':
                        case 'Z':
                            if (closingEscapeIndex > 0)
                            {
                                var substring = text.Substring(i, escapeSequenceLength);
                                result.Append(substring);
                                i += substring.Length - 1;
                            }

                            break;
                        case 'H':
                        case 'N':
                            var twoCharactersAheadIndex = i + 2;
                            if (closingEscapeIndex == twoCharactersAheadIndex)
                            {
                                var substring = text.Substring(i, escapeSequenceLength);
                                result.Append(substring);
                                i += substring.Length - 1;
                            }

                            break;
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns a <see cref="EncodingLookups"/> and caches for subsequent use
        /// using <see cref="EncodingCharacters"/> as keys.
        /// </summary>
        private static EncodingLookups BuildEncodingLookups(EncodingCharacters encChars)
        {
            // escape sequence strings must be assembled using the given escape character
            // see if this has already been done for this set of encoding characters
            if (!VariousEncChars.ContainsKey(encChars))
            {
                // this means we haven't got the sequences for these encoding characters yet - let's make them
                VariousEncChars.Add(encChars, new EncodingLookups(encChars));
            }

            return VariousEncChars[encChars];
        }

        internal class EncodingLookups
        {
            private const char TruncateChar = '#';

            private const char LineFeed = '\n';

            private const char CarriageReturn = '\r';

            public EncodingLookups(EncodingCharacters encoding)
            {
                LoadHexadecimalConfiguration();
                BuildLookups(encoding);
            }

            public char[] Codes { get; } = { 'F', 'S', 'T', 'R', 'E' };

            public char[] SpecialCharacters { get; } = new char[8];

            public Dictionary<char, string> EscapeSequences { get; } = new Dictionary<char, string>();

            private LineFeedHexadecimal LineFeedHexadecimal { get; set; } = LineFeedHexadecimal.X0A;

            private CarriageReturnHexadecimal CarriageReturnHexadecimal { get; set; } = CarriageReturnHexadecimal.X0D;

            private void BuildLookups(EncodingCharacters encoding)
            {
                SpecialCharacters[0] = encoding.FieldSeparator;
                SpecialCharacters[1] = encoding.ComponentSeparator;
                SpecialCharacters[2] = encoding.SubcomponentSeparator;
                SpecialCharacters[3] = encoding.RepetitionSeparator;
                SpecialCharacters[4] = encoding.EscapeCharacter;
                SpecialCharacters[5] = TruncateChar;
                SpecialCharacters[6] = LineFeed;
                SpecialCharacters[7] = CarriageReturn;

                for (var i = 0; i < Codes.Length; i++)
                {
                    var seq = $"{encoding.EscapeCharacter}{Codes[i]}{encoding.EscapeCharacter}";

                    EscapeSequences.Add(SpecialCharacters[i], seq);
                }

                // Escaping of truncation # is not implemented yet. It may only be escaped if it is the first character that
                // exceeds the conformance length of the component (ch 2.5.5.2). As of now, this information is not
                // available at this place.
                EscapeSequences.Add(TruncateChar, $"{TruncateChar}");
                EscapeSequences.Add(LineFeed, $"\\{LineFeedHexadecimal}\\");
                EscapeSequences.Add(CarriageReturn, $"\\{CarriageReturnHexadecimal}\\");
            }

            private void LoadHexadecimalConfiguration()
            {
                if (ConfigurationManager.GetSection("EscapingConfiguration")
                    is EscapingConfigurationSection configSection)
                {
                    LineFeedHexadecimal = configSection.HexadecimalEscaping.LineFeedHexadecimal;
                    CarriageReturnHexadecimal = configSection.HexadecimalEscaping.CarriageReturnHexadecimal;
                }
            }
        }
    }
}