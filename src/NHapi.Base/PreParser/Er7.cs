/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "ER7.java".

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): James Agnew, Christian Ohr, Jake Aitchison

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

    using NHapi.Base.Parser;

    public static class Er7
    {
        /// <summary>
        /// <see cref="char"/> that delimit segments.
        /// for use with <see cref="NHapi.Base.SupportClass.Tokenizer"/>.
        /// </summary>
        /// <remarks>
        /// We are forgiving: HL7 2.3.1 section 2.7 says that carriage return <c>'\r'</c> is
        /// the only segment delimiter.  TODO: check other versions.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1310:Field names should not contain underscore",
            Justification = "Because these are constants and not just fields there is a rule clash.")]
        private const string SEGMENT_SEPARATORS = "\r\n\f";

        /// <summary>
        /// Parse message and return data found with provided <see cref="DatumPath">DatumPaths</see>.
        /// </summary>
        /// <param name="message">Er7 encoded hl7 v2 message.</param>
        /// <param name="messageMask">The location/path to retrieve values from.</param>
        /// <param name="results">The values found in message.</param>
        /// <returns>
        /// <see langword="true"/> if parsed okay i.e. looks like Er7 encoded HL7.
        /// <para>
        /// We just barely check against HL7 structure, and ignore any elements / text that is unexpected
        /// (that is, impossible in any HL7 message: independent of any message / segment definitions).
        /// </para>
        /// </returns>
        public static bool TryParseMessage(string message, IList<DatumPath> messageMask, out IDictionary<string, string> results)
        {
            messageMask ??= new List<DatumPath> { new () };
            results = new Dictionary<string, string>();

#if NET35
            if (string.IsNullOrEmpty(message) || message.Trim().Length == 0)
#else
            if (string.IsNullOrWhiteSpace(message))
#endif
            {
                return false;
            }

            var messageTokenizer = new SupportClass.Tokenizer(message, SEGMENT_SEPARATORS);

            if (!messageTokenizer.HasMoreTokens())
            {
                return false;
            }

            var firstSegment = messageTokenizer.NextToken();

            if (!ParseMshSegmentWhole(firstSegment, messageMask, results, out var encodingCharacters))
            {
                return false;
            }

            var segmentId2NextRepetitionIndex = new SortedDictionary<string, int> { { "MSH", 1 }, };

            while (messageTokenizer.HasMoreTokens())
            {
                ParseSegmentWhole(
                    segmentId2NextRepetitionIndex,
                    messageMask,
                    encodingCharacters,
                    messageTokenizer.NextToken(),
                    results);
            }

            return true;
        }

        private static bool ParseMshSegmentWhole(
            string segment,
            IList<DatumPath> messageMask,
            IDictionary<string, string> results,
            out EncodingCharacters encodingCharacters)
        {
            var result = false;
            encodingCharacters = null;
            try
            {
                encodingCharacters = new EncodingCharacters(
                    segment[3],
                    segment[4],
                    segment[5],
                    segment[6],
                    segment[7]);

                var handler = new Er7SegmentHandler(encodingCharacters, results)
                {
                    SegmentId = "MSH", SegmentRepetitionIndex = 0,
                    MessageMasks = messageMask ?? new List<DatumPath> { new () },
                };

                var nodeKey = new List<int> { 0 };
                handler.PutDatum(nodeKey, encodingCharacters.FieldSeparator.ToString());
                nodeKey.Insert(0, 1);
                handler.PutDatum(nodeKey, encodingCharacters.ToString());

                if (segment[8] == encodingCharacters.FieldSeparator)
                {
                    result = true;

                    nodeKey.Clear();
                    nodeKey.Add(2);
                    ParseSegmentGuts(handler, segment.Substring(9), nodeKey);
                }
            }
            catch (IndexOutOfRangeException)
            {
                // do nothing
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            return result;
        }

        private static void ParseSegmentGuts(Er7SegmentHandler handler, string guts, IList<int> nodeKey)
        {
            var lastIndex = nodeKey.Count - 1;
            var thisDepthsDelim = handler.Delimiter(lastIndex);

            var gutsTokenizer = new SupportClass.Tokenizer(guts, thisDepthsDelim.ToString(), true);
            while (gutsTokenizer.HasMoreTokens())
            {
                var gutsToken = gutsTokenizer.NextToken();

                if (gutsToken[0] == thisDepthsDelim)
                {
                    var oldValue = nodeKey[lastIndex];
                    nodeKey[lastIndex] = oldValue + gutsToken.Length;
                }
                else
                {
                    if (nodeKey.Count < handler.SpecDepth)
                    {
                        nodeKey.Add(0);
                        ParseSegmentGuts(handler, gutsToken, nodeKey);
                        nodeKey.RemoveAt(nodeKey.Count - 1);
                    }
                    else
                    {
                        handler.PutDatum(nodeKey, gutsToken);
                    }
                }
            }
        }

        private static void ParseSegmentWhole(
            IDictionary<string, int> segmentId2NextRepetitionIndex,
            IList<DatumPath> messageMask,
            EncodingCharacters encodingCharacters,
            string segment,
            IDictionary<string, string> props)
        {
            try
            {
                if (encodingCharacters is null)
                {
                    throw new ArgumentNullException(nameof(encodingCharacters));
                }

                var segmentId = segment.Substring(0, 3);

                var currentSegmentRepetitionIndex = segmentId2NextRepetitionIndex.ContainsKey(segmentId)
                    ? segmentId2NextRepetitionIndex[segmentId]
                    : 0;

                segmentId2NextRepetitionIndex[segmentId] = currentSegmentRepetitionIndex + 1;

                var segmentIdAsDatumPath = new DatumPath().Add(segmentId);
                var parseThisSegment = messageMask.Any(m => segmentIdAsDatumPath.StartsWith(m));

                parseThisSegment = messageMask.Any(m => m.StartsWith(segmentIdAsDatumPath) && !parseThisSegment);

                if (parseThisSegment && (segment[3] == encodingCharacters.FieldSeparator))
                {
                    var handler = new Er7SegmentHandler(encodingCharacters, props)
                    {
                        SegmentId = segmentId,
                        MessageMasks = messageMask,
                        SegmentRepetitionIndex = currentSegmentRepetitionIndex,
                    };

                    var nodeKey = new List<int> { 0 };
                    ParseSegmentGuts(handler, segment.Substring(4), nodeKey);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // do nothing
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }
        }

        private class Er7SegmentHandler
        {
            private readonly EncodingCharacters encodingCharacters;
            private readonly IDictionary<string, string> props;

            public Er7SegmentHandler(EncodingCharacters encodingCharacters, IDictionary<string, string> props)
            {
                this.encodingCharacters = encodingCharacters;
                this.props = props;
            }

            public int SpecDepth => 4;

            internal int SegmentRepetitionIndex { get; set; }

            internal string SegmentId { get; set; }

            internal IList<DatumPath> MessageMasks { get; set; }

            public char Delimiter(int level) => level switch
            {
                0 => this.encodingCharacters.FieldSeparator,
                1 => this.encodingCharacters.RepetitionSeparator,
                2 => this.encodingCharacters.ComponentSeparator,
                3 => this.encodingCharacters.SubcomponentSeparator,
                _ => throw new ArgumentOutOfRangeException()
            };

            public void PutDatum(IList<int> valNodeKey, string value)
            {
                var valDatumPath = new DatumPath();
                valDatumPath.Add(this.SegmentId).Add(this.SegmentRepetitionIndex);
                for (var i = 0; i < valNodeKey.Count && valDatumPath.Size < 6; i++)
                {
                    valDatumPath.Add(i == 1 ? valNodeKey[i] : valNodeKey[i] + 1);
                }

                if (this.MessageMasks.Any(m => valDatumPath.StartsWith(m)))
                {
                    props.Add(valDatumPath.ToString(), value);
                }
            }
        }
    }
}