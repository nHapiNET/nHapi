/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "CharSetUtil.java".

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): Jens Kristian Villadsen from Cetrea A/S; Christian Ohr, Jake Aitchison

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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NHapi.Base.Log;
    using NHapi.Base.Parser;
    using NHapi.Base.PreParser;

    public class CharSetUtility
    {
        private static readonly IHapiLog Log = HapiLogFactory.GetHapiLog(typeof(CharSetUtility));

        public static byte[] WithoutBom(byte[] messageBytes)
        {
            var bom = Bom.GetBom(messageBytes);
            return messageBytes.Skip(bom.BomBytes.Length).ToArray();
        }

        /// <summary>
        /// Attempt to determine the HL7 character set (<see cref="Encoding"/>) of the HL7 message.
        /// </summary>
        /// <param name="message">HL7 message as bytes.</param>
        /// <returns>The detected Hl7 character set, if none detected defaults to ASCII (us-ascii).</returns>
        public static Encoding CheckCharset(byte[] message)
        {
            return CheckCharset(message, Encoding.ASCII);
        }

        /// <summary>
        /// Attempt to determine the HL7 character set (<see cref="Encoding"/>) of the HL7 message.
        /// </summary>
        /// <param name="message">HL7 message as <see cref="T:byte[]"/>.</param>
        /// <param name="encoding">HL7 Character to be used should one not be detected.</param>
        /// <returns>The detected Hl7 character set, if none detected defaults to the one provided by the
        /// <paramref name="encoding"/> parameter.
        /// </returns>
        public static Encoding CheckCharset(byte[] message, Encoding encoding)
        {
            encoding ??= Encoding.ASCII;
            var messageFromBytes = Bom.SkipBom(message);

            return CheckCharset(messageFromBytes, encoding);
        }

        /// <summary>
        /// Attempt to determine the HL7 character set (<see cref="Encoding"/>) of the HL7 message.
        /// </summary>
        /// <param name="message">HL7 message as a <see cref="string"/>.</param>
        /// <returns>The detected Hl7 character set, if none detected defaults to ASCII (us-ascii).</returns>
        public static Encoding CheckCharset(string message)
        {
            return CheckCharset(message, Encoding.ASCII);
        }

        /// <summary>
        /// Attempt to determine the HL7 character set (<see cref="Encoding"/>) of the HL7 message.
        /// </summary>
        /// <param name="message">HL7 message as a <see cref="string"/>.</param>
        /// <param name="encoding">HL7 Character to be used should one not be detected.</param>
        /// <returns>The detected Hl7 character set, if none detected defaults to the one provided by the
        /// <paramref name="encoding"/> parameter.
        /// </returns>
        public static Encoding CheckCharset(string message, Encoding encoding)
        {
            encoding ??= Encoding.ASCII;

            try
            {
                var fields = PreParser.GetFields(message, "MSH-18(0)");
                var hl7CharsetName = StripNonLowAscii(fields[0]);
                if (hl7CharsetName.Length > 0)
                {
                    encoding = Hl7CharSets.FromHl7Encoding(hl7CharsetName);
                }

                Log.Trace($"Detected MSH-18 value {hl7CharsetName} so using encoding {encoding.EncodingName}");
            }
            catch (EncodingNotSupportedException ex)
            {
                Log.Warn($"Invalid or unsupported encoding in MSH-18. Defaulting to {encoding.EncodingName}", ex);
            }
            catch (HL7Exception ex)
            {
                Log.Warn($"Failed to parse MSH segment. Defaulting to {encoding.EncodingName}", ex);
            }

            return encoding;
        }

        private static string StripNonLowAscii(string theString)
        {
            if (theString == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var next in theString)
            {
                if (next > 0 && next < 127)
                {
                    builder.Append(next);
                }
            }

            return builder.ToString();
        }

        private class Bom
        {
            private static readonly IList<Bom> KnownBoms = new List<Bom>
            {
                new Bom(new byte[] { 0xFF, 0xFE, 0x00, 0x00 }, Encoding.UTF32),                 // UTF-32LE
                new Bom(new byte[] { 0x00, 0x00, 0xFE, 0xFF }, new UTF32Encoding(true, true)),  // UTF-32BE
                new Bom(new byte[] { 0xEF, 0xBB, 0xBF }, Encoding.UTF8),                        // Unicode (UTF-8)
                new Bom(new byte[] { 0xFE, 0xFF, 0xBF }, Encoding.BigEndianUnicode),            // UTF-16BE
                new Bom(new byte[] { 0xFF, 0xFE }, Encoding.Unicode),                           // UTF-16LE
            };

            private static readonly Bom DefaultBom = new Bom(new byte[] { }, Encoding.ASCII);   // ASCII (us-ascii)

            public Bom(byte[] bomBytes, Encoding encoding)
            {
                BomBytes = bomBytes;
                Encoding = encoding;
            }

            public byte[] BomBytes { get; }

            public Encoding Encoding { get; }

            public static string SkipBom(byte[] messageBytes)
            {
                var bom = GetBom(messageBytes);
                var messageBytesWithoutBom = messageBytes.Skip(bom.BomBytes.Length).ToArray();
                return bom.Encoding.GetString(messageBytesWithoutBom);
            }

            public static Bom GetBom(byte[] messageBytes)
            {
                if (messageBytes == null)
                {
                    return KnownBoms[0];
                }

                foreach (var bom in KnownBoms)
                {
                    var messageBomBytes = messageBytes.Take(bom.BomBytes.Length);
                    if (bom.BomBytes.SequenceEqual(messageBomBytes))
                    {
                        return bom;
                    }
                }

                return DefaultBom;
            }
        }
    }
}