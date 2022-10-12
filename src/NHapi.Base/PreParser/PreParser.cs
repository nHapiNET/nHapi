/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "PreParser.java".  Description:
  "Extracts specified fields from unparsed messages. This class is a facade for the ER7 and XML classes."

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): James, Agnew, Christian Ohr, Jake Aitchison

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

namespace NHapi.Base.PreParser
{
    using System.Collections.Generic;
    using System.Linq;

    using NHapi.Base.Parser;

    /// <summary>
    /// Extracts specified fields from unparsed messages.
    /// <example>
    /// <code>
    /// var message = null; //... your ER7 or XML message string goes here
    /// var fieldSpecs = new string[] { "MSH-9-1", "MSH-9-2", "MSH-12" };
    /// var fields = PreParser.GetFields(message, fieldSpecs);
    /// </code>
    /// </example>
    /// <remarks>This class is a facade for the <see cref="Er7"/> and <see cref="Xml"/> classes.</remarks>
    /// </summary>
    public static class PreParser
    {
        /// <summary>
        /// Extracts selected fields from a message.
        /// </summary>
        /// <param name="message">An unparsed message from which to get fields.</param>
        /// <param name="pathSpecs">
        /// Terser-like paths to fields in the message.
        /// See documentation for <see cref="NHapi.Base.Util.Terser"/>.
        /// These paths are identical except that they start with the segment name (search flags and group
        /// names are to be omitted as they are not relevant with unparsed ER7 messages).
        /// </param>
        /// <returns>Field values corresponding to the given paths.</returns>
        /// <exception cref="HL7Exception">When detecting message encoding fails or when parsing the message fails.</exception>
        public static string[] GetFields(string message, params string[] pathSpecs)
        {
            var datumPaths = pathSpecs.Select(x => x.FromPathSpec()).ToList();

            bool result;
            IDictionary<string, string> results;
            if (EncodingDetector.IsEr7Encoded(message))
            {
                result = Er7.ParseMessage(message, datumPaths, out results);
            }
            else if (EncodingDetector.IsXmlEncoded(message))
            {
                result = Xml.ParseMessage(message, datumPaths, out results);
            }
            else
            {
                throw new HL7Exception("Message encoding is not recognized");
            }

            if (!result)
            {
                throw new HL7Exception("Parse failed");
            }

            return results.Select(x => x.Value).ToArray();
        }
    }
}