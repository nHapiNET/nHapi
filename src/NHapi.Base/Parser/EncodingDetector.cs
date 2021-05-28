/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "EncodingDetector.java".  Description:
  "Detects message encoding (ER7 / XML)"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): ______________________________________.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the  "GPL"), in which case the provisions of the GPL are
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

    /// <summary>
    /// Detects message encoding (ER7 / XML) without relying on any
    /// external dependencies.
    /// </summary>
    public static class EncodingDetector
    {
        /// <summary>
        /// Asserts the message is Er7 Encoded.
        /// </summary>
        /// <param name="message">Message to be examined.</param>
        /// <exception cref="ArgumentException">
        /// If the message is less than 4 characters long or the message does not start with MSH.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the 4th character of each segment was not a field delimiter.
        /// </exception>
        public static void AssertEr7Encoded(string message)
        {
            // quit if the string is too short
            if (message.Length < 4)
            {
                throw new ArgumentException("The message is less than 4 characters long");
            }

            // string should start with "MSH"
            if (!message.StartsWith("MSH", StringComparison.Ordinal))
            {
                throw new ArgumentException("The message does not start with MSH");
            }

            // 4th character of each segment should be field delimiter
            var fourthChar = message[3];
            var tokens = message.Split(Convert.ToChar(PipeParser.SegmentDelimiter));

            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if (token.Length > 0)
                {
                    if (char.IsWhiteSpace(token[0]))
                    {
                        token = PipeParser.StripLeadingWhitespace(token);
                    }

                    if (token.Length >= 4 && token[3] != fourthChar)
                    {
                        throw new InvalidOperationException(
                            $"The 4th character should have been a {token[3]}, but it was a {fourthChar}");
                    }
                }
            }
        }

        /// <summary>
        /// Asserts the message is XML encoded.
        /// </summary>
        /// <param name="message">Message to be examined.</param>
        /// <exception cref="ArgumentException">
        /// If <paramref name="message"/> does not contain "MSH.1>" or "MSH.2>".
        /// </exception>
        public static void AssertXmlEncoded(string message)
        {
            if (!message.Contains("MSH.1>"))
            {
                throw new ArgumentException("Expected to find MSH.1");
            }

            if (!message.Contains("MSH.2>"))
            {
                throw new ArgumentException("Expected to find MSH.2");
            }
        }

        /// <summary>
        /// Returns true if the message is ER7 (pipe-and-hat) encoded.
        /// </summary>
        /// <param name="message">Message to be examined.</param>
        /// <returns>true if message is ER7-encoded.</returns>
        public static bool IsEr7Encoded(string message)
        {
            try
            {
                AssertEr7Encoded(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the message is XML encoded.
        /// <para>
        /// Note that this message does not perform a very robust check and does not
        /// validate for well-formedness.
        /// </para>
        /// <para>
        /// It is only intended to perform a simple check for XML vs.ER7 messages.
        /// </para>
        /// </summary>
        /// <param name="message">Message to be examined.</param>
        /// <returns>true if message is XML-encoded.</returns>
        public static bool IsXmlEncoded(string message)
        {
            try
            {
                AssertXmlEncoded(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}