/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "HL7Charsets.java".  Description:
  "Content of HL7 table 0211 mapped to dotnet Encoding"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): Christian Ohr, Jake Aitchison

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

namespace NHapi.Base.Llp
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NHapi.Base.Parser;

    /// <summary>
    /// HL7 Charsets from Table 0211 mapped to dotnet <see cref="Encoding"/>.
    /// </summary>
    internal static class Hl7CharSets
    {
        private static readonly Dictionary<string, string> EncodingMap = new ()
        {
            { "ASCII", Encoding.ASCII.BodyName },               // ASCII (us-ascii)
            { "8859/1", "iso-8859-1" },                         // Western European (ISO)
            { "8859/2", "iso-8859-2" },                         // Central European (ISO)
            { "8859/3", "iso-8859-3" },                         // Latin 3 (ISO)
            { "8859/4", "iso-8859-4" },                         // Baltic (ISO)
            { "8859/5", "iso-8859-5" },                         // Cyrillic (ISO)
            { "8859/6", "iso-8859-6" },                         // Arabic (ISO)
            { "8859/7", "iso-8859-7" },                         // Greek (ISO)
            { "8859/8", "iso-8859-8" },                         // Hebrew (ISO-Visual)
            { "8859/9", "iso-8859-9" },                         // Turkish (ISO)
            { "8859/15", "iso-8859-15" },                       // Latin 9 (ISO)
            { "ISO IR6", "ISO IR6" },
            { "ISO IR14", "ISO IR14" },
            { "ISO IR87", "ISO IR87" },
            { "ISO IR159", "ISO IR159" },
            { "GB 18030-2000", "gb18030" },                     // Chinese Simplified (GB18030)
            { "KS X 1001", "euc-kr" },                          // Korean (EUC)
            { "CNS 11643-1992", "CNS 11643-1992" },
            { "BIG-5", "big5" },                                // Chinese Traditional (Big5)
            { "UNICODE", Encoding.UTF8.BodyName },              // Unicode (UTF-8)
            { "UNICODE UTF-8", Encoding.UTF8.BodyName },        // Unicode (UTF-8)
            { "UNICODE UTF-16", Encoding.Unicode.BodyName },    // Unicode (UTF-16LE)
            { "UNICODE UTF-32", Encoding.UTF32.BodyName },      // Unicode (UTF-32LE)
        };

        /// <summary>
        /// Returns the dotnet <see cref="Encoding"/> for the HL7 charset name.
        /// <a href="https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding#list-of-encodings">list of supported encodings</a>.
        /// </summary>
        /// <param name="hl7EncodingName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">When null empty or white-space <paramref name="hl7EncodingName"/>.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="hl7EncodingName" /> is not a valid code page name.
        /// -or-
        /// The code page indicated by <paramref name="hl7EncodingName" /> is not supported by the underlying platform.</exception>
        /// <exception cref="EncodingNotSupportedException"><paramref name="hl7EncodingName"/> is unknown.</exception>
        public static Encoding FromHl7Encoding(string hl7EncodingName)
        {
#if NET35
            if (string.IsNullOrEmpty(hl7EncodingName) || hl7EncodingName.Trim().Length == 0)
#else
            if (string.IsNullOrWhiteSpace(hl7EncodingName))
#endif
            {
                throw new ArgumentException("Should not be null empty or white-space.", nameof(hl7EncodingName));
            }

            if (!EncodingMap.TryGetValue(hl7EncodingName, out var mappedEncoding))
            {
                throw new EncodingNotSupportedException(hl7EncodingName);
            }

            return Encoding.GetEncoding(mappedEncoding);
        }
    }
}