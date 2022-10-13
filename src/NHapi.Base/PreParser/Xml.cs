/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  Contributor(s): Jake Aitchison

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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public static class Xml
    {
        /// <summary>
        /// Parse message and return data found with provided <see cref="DatumPath">DatumPaths</see>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// <paramref name="message"/> should be an XML document with one top level element, that being the
        /// message i.e. <![CDATA[<ACK>]]> or whatever.
        /// </para>
        /// <para>
        /// We are only expecting one message / xml document to be in the<paramref name="message"/>.
        /// </para>
        /// <para>
        /// The <paramref name="message"/> data (located via passed in <paramref name="messageMasks"/>) will be added to
        /// <paramref name="results"/> as key / value pairs with the key being
        /// <see cref="DatumPath.ToString()">DatumPath.ToString()</see> of the appropriate <see cref="DatumPath" />
        /// for the location where the data is found (i.e. in the <c>ZYX[a]-b[c]-d-e</c> style), and the value
        /// being that of the corresponding text.
        /// </para>
        /// <para>So, after calling <see cref="TryParseMessage"/> successfully, if you wanted to retrieve the
        /// message data from <paramref name="results"/> you might call something like:
        /// <code>
        /// var key = new DatumPath().Add("MSH").Add(1).ToString();
        /// results.TryGetValue(key, out var @value)</code>
        /// and that would return a String with "|", probably.
        /// </para>
        /// <para>
        /// Note that this package facilitates the extraction of message data in a way
        /// independent of message version (i.e. components and whatever getting added):
        /// </para>
        /// <para>
        /// With a <paramref name="message" /> of <![CDATA[<FOO><ZYX><ZYX.42>fieldy-field-field</ZYX.42></ZYX></FOO>]]>,
        /// <c>ZYX[0]-1[0]-1-1</c> will be the key that ends up in <paramref name="results"/> (see notes at
        /// <see cref="DatumPath.ToString()">DatumPath.ToString()</see>).
        /// </para>
        /// <para>
        /// So if you, coding for a future version of the FOO message but receiving an old-version message data,
        /// tried:
        /// <code>
        /// var key = new DatumPath().Add("ZYX").Add(0).Add(42).Add(0).Add(1).ToString();
        /// results.TryGetValue(key, out var @value)</code> with the message above (that is, trying to extract a
        /// repetition and component that aren't there), you would get <c>ZYX[0]-42[0]-1-1</c> mapping to
        /// "fieldy-field-field" in the resulting <paramref name="results"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="message" /> was <![CDATA[<FOO><ZYX><ZYX.42><ARG.1>component data</ARG.1></ZYX.42></ZYX></FOO>]]>
        /// and you, coding for an old version of this FOO message but receiving new-version FOO message data,
        /// tried:
        /// <code>
        /// var key = new DatumPath().Add("ZYX").Add(0).Add(42).ToString();
        /// results.TryGetValue(key, out var @value)</code> you would get <c>ZYX[0]-42[0]-1-1</c> mapping to
        /// "component data" in the resulting <paramref name="results"/>.
        /// </para>
        /// <para>
        /// <paramref name="messageMasks" /> lets you specify which parts of the message you want dumped to
        /// <paramref name="results"/>. Passing in null gets you everything. Otherwise, <paramref name="messageMasks" />
        /// elements should all be <see cref="DatumPath">DatumPaths</see>, and a particular part of the message
        /// will be added to <paramref name="results"/> only if it's location, as represented by a
        /// <see cref="DatumPath" />, starts with (as in <see cref="DatumPathExtensions.StartsWith">DatumPathExtensions.StartsWith</see>)
        /// at least one element of <paramref name="messageMasks" />.
        /// </para>
        /// <para>So if one element of <paramref name="messageMasks" /> was a
        /// <c>new DatumPath().Add("ZYX")</c>, then everything in all <c>ZYX</c> segment would get dumped to
        /// <paramref name="results"/>. A <c>new DatumPath().Add("ZYX").Add(1)</c> would get only the first
        /// repetitions of same (if there is one) dumped to <paramref name="results"/>. etc. etc.
        /// </para>
        /// <para>
        /// Note that a <see cref="DatumPath" /> of <see cref="DatumPath.Size" /> == 0 in <paramref name="messageMasks" />
        /// will get you everything, no matter what the other elements of <paramref name="messageMasks" /> are, because
        /// all <see cref="DatumPath">DatumPaths</see> starts with the zero-length <see cref="DatumPath" />.
        /// </para>
        /// <para>
        /// Segment group elements (eg. ADT_A01.PROCEDURE) are handled fine, but they aren't addressed in
        /// <paramref name="messageMasks" /> or in the output in <paramref name="results"/> -- basically any element tags
        /// at the level immediately inside the message element, and having a name that starts with the
        /// message element name + '.', is ignored (meaning it's contents are dealt with the same as if the
        /// start and end tags' just  wasn't there.).
        /// </para>
        /// </remarks>
        /// <param name="message">Xml encoded HL7 v2 message.</param>
        /// <param name="messageMasks">The location/path to retrieve values from.</param>
        /// <param name="results">The values found in message.</param>
        /// <returns>
        /// <see langword="true"/> if parsed okay i.e. xml was well formed.
        /// <para>
        /// We just barely check against HL7 structure, and ignore any elements / text that is unexpected
        /// (that is, impossible in any HL7 message: independent of any message / segment definitions).
        /// </para>
        /// </returns>
        public static bool TryParseMessage(string message, IEnumerable<DatumPath> messageMasks, out IDictionary<string, string> results)
        {
            results = new Dictionary<string, string>();
            messageMasks ??= new List<DatumPath> { new () };

            try
            {
                var document = XDocument.Parse(message);

                foreach (var datumPath in messageMasks)
                {
                    var result = SearchForDatum(document, datumPath);
                    if (result is not null)
                    {
                        results.Add(datumPath.ToString(), result);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static string SearchForDatum(XDocument message, DatumPath datumPath)
        {
            if (datumPath.Size == 0)
            {
                return message.Root?.Value;
            }

            var segment = datumPath.Get(0) as string;

            var nameSpace = message.Root?.Name.Namespace;
            var search =
                message.Root?.Elements(nameSpace + segment)
                    .ElementAt((int)datumPath.Get(1));

            if (search?.HasElements == true)
            {
                search = search.Elements()
                    .Where(x => x.Name.LocalName.EndsWith($"{(int)datumPath.Get(2)}"))
                    .ElementAt((int)datumPath.Get(3));
            }

            if (search?.HasElements == true)
            {
                search = search.Elements()
                    .SingleOrDefault(x => x.Name.LocalName.EndsWith($"{(int)datumPath.Get(4)}"));
            }

            if (search?.HasElements == true)
            {
                search = search.Elements()
                    .SingleOrDefault(x => x.Name.LocalName.EndsWith($"{(int)datumPath.Get(5)}"));
            }

            return search?.Value;
        }
    }
}