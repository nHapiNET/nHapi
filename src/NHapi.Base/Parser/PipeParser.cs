/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "PipeParser.java".  Description:
  "An implementation of Parser that supports traditionally encoded (i.e"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): Kenneth Beaton.

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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NHapi.Base.Log;
    using NHapi.Base.Model;
    using NHapi.Base.Util;

    /// <summary>
    /// An implementation of Parser that supports traditionally encoded (ie delimited with characters
    /// like |, ^, and ~) HL7 messages.  Unexpected segments and fields are parsed into generic elements
    /// that are added to the message.
    /// </summary>
    /// <author>Bryan Tripp (bryan_tripp@sourceforge.net).</author>
    public class PipeParser : ParserBase
    {
        public const string SegmentDelimiter = "\r"; // see section 2.8 of spec

        private static readonly IHapiLog Log;

        private readonly Dictionary<Type, Dictionary<string, StructureDefinition>> structureDefinitions =
            new Dictionary<Type, Dictionary<string, StructureDefinition>>();

        static PipeParser()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(PipeParser));
        }

        /// <summary>
        /// Creates a new PipeParser.
        /// </summary>
        public PipeParser()
        {
        }

        /// <summary>
        /// Creates a new PipeParser.
        /// </summary>
        public PipeParser(IModelClassFactory factory)
            : base(factory)
        {
        }

        /// <inheritdoc />
        public override string DefaultEncoding => "VB";

        /// <summary>
        /// Splits the given composite string into an array of components using
        /// the given delimiter.
        /// </summary>
        /// <param name="composite">Encoded composite string.</param>
        /// <param name="delimiter">Delimiter to split upon.</param>
        public static string[] Split(string composite, string delimiter)
        {
            var components = new ArrayList();

            // defend against evil nulls
            if (composite == null)
            {
                composite = string.Empty;
            }

            if (delimiter == null)
            {
                delimiter = string.Empty;
            }

            var tok = new SupportClass.Tokenizer(composite, delimiter, true);
            var previousTokenWasDelim = true;
            while (tok.HasMoreTokens())
            {
                var thisTok = tok.NextToken();
                if (thisTok.Equals(delimiter))
                {
                    if (previousTokenWasDelim)
                    {
                        components.Add(null);
                    }

                    previousTokenWasDelim = true;
                }
                else
                {
                    components.Add(thisTok);
                    previousTokenWasDelim = false;
                }
            }

            var ret = new string[components.Count];
            for (var i = 0; i < components.Count; i++)
            {
                ret[i] = (string)components[i];
            }

            return ret;
        }

        /// <summary>
        /// Returns given <see cref="IType"/> as a pipe-encoded string, using the given encoding characters.
        /// <para>
        /// It is assumed that the Type represents a complete field rather than a component.
        /// </para>
        /// </summary>
        /// <param name="source">An <see cref="IType"/> object from which to construct an encoded string.</param>
        /// <param name="encodingChars">Encoding characters to be used.</param>
        /// <returns>The encoded type.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the group do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        public static string Encode(IType source, EncodingCharacters encodingChars)
        {
            if (source is Varies)
            {
                var varies = (Varies)source;
                if (varies.Data != null)
                {
                    source = varies.Data;
                }
            }

            var field = new StringBuilder();
            for (var i = 1; i <= Terser.NumComponents(source); i++)
            {
                var comp = new StringBuilder();
                for (var j = 1; j <= Terser.NumSubComponents(source, i); j++)
                {
                    var p = Terser.GetPrimitive(source, i, j);
                    comp.Append(EncodePrimitive(p, encodingChars));
                    comp.Append(encodingChars.SubcomponentSeparator);
                }

                field.Append(StripExtraDelimiters(comp.ToString(), encodingChars.SubcomponentSeparator));
                field.Append(encodingChars.ComponentSeparator);
            }

            return StripExtraDelimiters(field.ToString(), encodingChars.ComponentSeparator);
        }

        /// <summary>
        /// Returns given <see cref="IGroup"/> as a pipe-encoded string, using the given encoding characters.
        /// </summary>
        /// <param name="source">An <see cref="IGroup"/> object from which to construct an encoded string.</param>
        /// <param name="encodingChars">Encoding characters to be used.</param>
        /// <returns>The encoded group.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the group do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        public static string Encode(IGroup source, EncodingCharacters encodingChars)
        {
            var result = new StringBuilder();

            var names = source.Names;
            for (var i = 0; i < names.Length; i++)
            {
                var reps = source.GetAll(names[i]);
                for (var rep = 0; rep < reps.Length; rep++)
                {
                    if (reps[rep] is IGroup)
                    {
                        result.Append(Encode((IGroup)reps[rep], encodingChars));
                    }
                    else
                    {
                        var segString = Encode((ISegment)reps[rep], encodingChars);
                        if (segString.Length >= 4)
                        {
                            result.Append(segString);
                            result.Append('\r');
                        }
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Formats a <see cref="IMessage"/> object into an HL7 message string using the given encoding.
        /// </summary>
        /// <param name="source">An <see cref="IMessage"/> object from which to construct an encoded message string.</param>
        /// <param name="encodingChars">Encoding characters to be used.</param>
        /// <returns>The encoded message.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        public static string Encode(ISegment source, EncodingCharacters encodingChars)
        {
            var result = new StringBuilder();
            result.Append(source.GetStructureName());
            result.Append(encodingChars.FieldSeparator);

            // start at field 2 for MSH segment because field 1 is the field delimiter
            var startAt = 1;
            if (IsDelimDefSegment(source.GetStructureName()))
            {
                startAt = 2;
            }

            // loop through fields; for every field delimit any repetitions and add field delimiter after ...
            var numFields = source.NumFields();
            for (var i = startAt; i <= numFields; i++)
            {
                try
                {
                    var reps = source.GetField(i);
                    for (var j = 0; j < reps.Length; j++)
                    {
                        var fieldText = Encode(reps[j], encodingChars);

                        // if this is MSH-2, then it shouldn't be escaped, so un-escape it again
                        if (IsDelimDefSegment(source.GetStructureName()) && i == 2)
                        {
                            fieldText = Escape.UnescapeText(fieldText, encodingChars);
                        }

                        result.Append(fieldText);
                        if (j < reps.Length - 1)
                        {
                            result.Append(encodingChars.RepetitionSeparator);
                        }
                    }
                }
                catch (HL7Exception e)
                {
                    Log.Error("Error while encoding segment: ", e);
                }

                result.Append(encodingChars.FieldSeparator);
            }

            // strip trailing delimiters ...
            return StripExtraDelimiters(result.ToString(), encodingChars.FieldSeparator);
        }

        /// <summary>
        /// Removes leading whitespace from the given string. This method was created to deal with frequent
        /// problems parsing messages that have been hand-written in windows. The intuitive way to delimit
        /// segments is to hit ENTER at the end of each segment, but this creates both a carriage return
        /// and a line feed, so to the parser, the first character of the next segment is the line feed.
        /// </summary>
        public static string StripLeadingWhitespace(string in_Renamed)
        {
            return in_Renamed.TrimStart();
        }

        /// <summary>
        /// Returns a string representing the encoding of the given message, if the
        /// encoding is recognised.
        /// <para>
        /// For example if the given message appears to be
        /// encoded using HL7 2.x XML rules then "XML" would be returned.
        /// </para>
        /// <para>
        /// If the encoding is not recognised then null is returned.
        /// </para>
        /// That this method returns a specific encoding does not guarantee that the
        /// message is correctly encoded (e.g. well formed XML) - just that
        /// it is not encoded using any other encoding than the one returned.
        /// </summary>
        /// <param name="message">Message to be examined.</param>
        public override string GetEncoding(string message)
        {
            return EncodingDetector.IsEr7Encoded(message) ? DefaultEncoding : null;
        }

        /// <deprecated> this method should not be public.
        /// </deprecated>
        /// <param name="message">
        /// </param>
        /// <returns>
        /// </returns>
        /// <throws>  HL7Exception. </throws>
        /// <throws>  EncodingNotSupportedException. </throws>
        public virtual string GetMessageStructure(string message)
        {
            return GetStructure(message).Structure;
        }

        /// <summary>
        /// Parses a segment string and populates the given Segment object.
        /// <para>
        /// Unexpected fields are added as Varies' at the end of the segment.
        /// </para>
        /// </summary>
        /// <param name="destination">Segment to parse the segment string into.</param>
        /// <param name="segment">Encoded segment.</param>
        /// <param name="encodingChars">Encoding characters to be used.</param>
        /// <exception cref="HL7Exception">
        /// If the given string does not contain the given segment or if the string is not encoded properly.
        /// </exception>
        public virtual void Parse(ISegment destination, string segment, EncodingCharacters encodingChars)
        {
            Parse(destination, segment, encodingChars, 0);
        }

        /// <summary>
        /// Parses a segment string and populates the given Segment object.
        /// <para>
        /// Unexpected fields are added as Varies' at the end of the segment.
        /// </para>
        /// </summary>
        /// <param name="destination">Segment to parse the segment string into.</param>
        /// <param name="segment">Encoded segment.</param>
        /// <param name="encodingChars">Encoding characters to be used.</param>
        /// <param name="repetition">The repetition number of this segment within its group.</param>
        /// <exception cref="HL7Exception">
        /// If the given string does not contain the given segment or if the string is not encoded properly.
        /// </exception>
        public virtual void Parse(ISegment destination, string segment, EncodingCharacters encodingChars, int repetition)
        {
            var fieldOffset = 0;
            if (IsDelimDefSegment(destination.GetStructureName()))
            {
                fieldOffset = 1;

                // set field 1 to fourth character of string
                Terser.Set(destination, 1, 0, 1, 1, Convert.ToString(encodingChars.FieldSeparator));
            }

            var fields = Split(segment, Convert.ToString(encodingChars.FieldSeparator));

            for (var i = 1; i < fields.Length; i++)
            {
                var reps = Split(fields[i], Convert.ToString(encodingChars.RepetitionSeparator));
                if (Log.DebugEnabled)
                {
                    Log.Debug(reps.Length + "reps delimited by: " + encodingChars.RepetitionSeparator);
                }

                // MSH-2 will get split incorrectly so we have to fudge it ...
                var isMSH2 = IsDelimDefSegment(destination.GetStructureName()) && i + fieldOffset == 2;
                if (isMSH2)
                {
                    reps = new string[1];
                    reps[0] = fields[i];
                }

                for (var j = 0; j < reps.Length; j++)
                {
                    try
                    {
                        var statusMessage = $"Parsing field {i + fieldOffset} repetition {j}";
                        Log.Debug(statusMessage);

                        var field = destination.GetField(i + fieldOffset, j);
                        if (isMSH2)
                        {
                            Terser.GetPrimitive(field, 1, 1).Value = reps[j];
                        }
                        else
                        {
                            Parse(field, reps[j], encodingChars);
                        }
                    }
                    catch (HL7Exception e)
                    {
                        // set the field location and throw again ...
                        e.FieldPosition = i;
                        if (repetition > 1)
                        {
                            e.SegmentRepetition = repetition;
                        }

                        e.SegmentName = destination.GetStructureName();
                        throw;
                    }
                }
            }

            // set data type of OBX-5
            if (destination.GetType().FullName.IndexOf("OBX") >= 0)
            {
                Varies.FixOBX5(destination, Factory);
            }
        }

        /// <inheritdoc />
        public override void Parse(IMessage message, string @string)
        {
            var structureDefinition = GetStructureDefinition(message);
            var messageIterator = new MessageIterator(message, structureDefinition, "MSH", true);

            var segments = Split(@string, SegmentDelimiter);

            if (segments.Length == 0)
            {
                throw new HL7Exception($"Invalid message content: \"{@string}\"");
            }

            if (segments[0] == null || segments[0].Length < 4)
            {
                throw new HL7Exception($"Invalid message content: \"{@string}\"");
            }

            var delimiter = '|';
            string previousName = null;
            var repetition = 1;
            for (var i = 0; i < segments.Length; i++)
            {
                // get rid of any leading whitespace characters ...
                if (segments[i] != null && segments[i].Length > 0 && char.IsWhiteSpace(segments[i][0]))
                {
                    segments[i] = StripLeadingWhitespace(segments[i]);
                }

                // sometimes people put extra segment delimiters at end of msg ...
                if (segments[i] != null && segments[i].Length >= 3)
                {
                    string name;
                    if (i == 0)
                    {
                        if (segments[i].Length < 4)
                        {
                            throw new HL7Exception($"Invalid message content: \"{@string}\"");
                        }

                        name = segments[i].Substring(0, 3);
                        delimiter = segments[i][3];
                    }
                    else
                    {
                        name = segments[i].IndexOf(delimiter) >= 0
                            ? segments[i].Substring(0, segments[i].IndexOf(delimiter))
                            : segments[i];
                    }

                    Log.Trace($"Parsing segment {name}");

                    if (name.Equals(previousName))
                    {
                        repetition++;
                    }
                    else
                    {
                        repetition = 1;
                        previousName = name;
                    }

                    messageIterator.Direction = name;

                    if (messageIterator.MoveNext())
                    {
                        var next = messageIterator.Current as ISegment;

                        if (next == null)
                        {
                            throw new HL7Exception($"Current segment does not implement ISegment and therefore cannot be parsed.");
                        }

                        Parse(next, segments[i], GetEncodingChars(@string), repetition);
                    }
                }
            }
        }

        /// <inheritdoc />
        public override ISegment GetCriticalResponseData(string message)
        {
            // try to get MSH segment
            var mshStart = message.IndexOf("MSH");
            if (mshStart < 0)
            {
                throw new HL7Exception("Couldn't find MSH segment in message: " + message, ErrorCode.SEGMENT_SEQUENCE_ERROR);
            }

            var mshEnd = message.IndexOf('\r', mshStart + 1);
            if (mshEnd < 0)
            {
                mshEnd = message.Length;
            }

            var mshString = message.Substring(mshStart, mshEnd - mshStart);

            // find out what the field separator is
            var fieldSep = mshString[3];

            // get field array
            var fields = Split(mshString, Convert.ToString(fieldSep));

            ISegment msh;
            try
            {
                // parse required fields
                var encChars = fields[1];
                var compSeparator = encChars[0];
                var messageControlId = fields[9];
                var processingIdComps = Split(fields[10], Convert.ToString(compSeparator));

                // fill MSH segment
                var version = "2.4"; // default
                try
                {
                    version = GetVersion(message);
                }
                catch (Exception)
                {
                    /* use the default */
                }

                msh = MakeControlMSH(version, Factory);
                Terser.Set(msh, 1, 0, 1, 1, Convert.ToString(fieldSep));
                Terser.Set(msh, 2, 0, 1, 1, encChars);
                Terser.Set(msh, 10, 0, 1, 1, messageControlId);
                Terser.Set(msh, 11, 0, 1, 1, processingIdComps[0]);
            }
            catch (Exception e)
            {
                SupportClass.WriteStackTrace(e, Console.Error);
                throw new HL7Exception(
                    "Can't parse critical fields from MSH segment (" + e.GetType().FullName + ": " + e.Message + "): " + mshString,
                    ErrorCode.REQUIRED_FIELD_MISSING);
            }

            return msh;
        }

        /// <inheritdoc />
        public override string GetAckID(string message)
        {
            string ackID = null;
            var msaStart = message.IndexOf("\rMSA");

            if (msaStart >= 0)
            {
                var startFieldOne = msaStart + 5;
                var fieldDelimiter = message[startFieldOne - 1];
                var start = message.IndexOf(fieldDelimiter, startFieldOne) + 1;
                var end = message.IndexOf(fieldDelimiter, start);
                var segEnd = message.IndexOf(SegmentDelimiter, start);

                if (segEnd > start && segEnd < end)
                {
                    end = segEnd;
                }

                // if there is no field delimiter after MSH-2, need to go to end of message, but not including end segment delimiter if it exists
                if (end < 0)
                {
                    if (message[message.Length - 1] == '\r')
                    {
                        end = message.Length - 1;
                    }
                    else
                    {
                        end = message.Length;
                    }
                }

                if (start > 0 && end > start)
                {
                    ackID = message.Substring(start, end - start);
                }
            }

            Log.Debug("ACK ID: " + ackID);
            return ackID;
        }

        /// <inheritdoc />
        public override string GetVersion(string message)
        {
            var startMsh = message.IndexOf("MSH");
            var endMsh = message.IndexOf(SegmentDelimiter, startMsh);

            if (endMsh < 0)
            {
                endMsh = message.Length;
            }

            var msh = message.Substring(startMsh, endMsh - startMsh);
            string fieldSep;
            if (msh.Length > 3)
            {
                fieldSep = Convert.ToString(msh[3]);
            }
            else
            {
                throw new HL7Exception($"Can't find field separator in MSH: {msh}", ErrorCode.UNSUPPORTED_VERSION_ID);
            }

            var fields = Split(msh, fieldSep);

            string compSep;
            if (fields.Length >= 2 && (fields[1]?.Length == 4 || fields[1]?.Length == 5))
            {
                compSep = Convert.ToString(fields[1][0]); // get component separator as 1st encoding char
            }
            else
            {
                throw new HL7Exception(
                    $"Can't find encoding characters - MSH has only {fields.Length} fields",
                    ErrorCode.REQUIRED_FIELD_MISSING);
            }

            if (fields.Length < 12)
            {
                throw new HL7Exception(
                    $"Can't find version ID - MSH has only {fields.Length} fields.",
                    ErrorCode.REQUIRED_FIELD_MISSING);
            }

            var comp = Split(fields[11], compSep);
            if (comp.Length < 1)
            {
                throw new HL7Exception(
                    $"Can't find version ID - MSH.12 is {fields[11]}",
                    ErrorCode.REQUIRED_FIELD_MISSING);
            }

            return comp[0];
        }

        /// <inheritdoc />
        protected internal override string DoEncode(IMessage source, string encoding)
        {
            if (!SupportsEncoding(encoding))
            {
                throw new EncodingNotSupportedException("This parser does not support the " + encoding + " encoding");
            }

            return Encode(source);
        }

        /// <inheritdoc />
        protected internal override string DoEncode(IMessage source)
        {
            // get encoding characters ...
            var msh = (ISegment)source.GetStructure("MSH");
            var fieldSepString = Terser.Get(msh, 1, 0, 1, 1);

            if (fieldSepString == null)
            {
                // cdc: This was breaking when trying to construct a blank message, and there is no way to set the fieldSeperator, so fill in a default
                // throw new HL7Exception("Can't encode message: MSH-1 (field separator) is missing");
                fieldSepString = "|";
                Terser.Set(msh, 1, 0, 1, 1, fieldSepString);
            }

            var fieldSep = fieldSepString.Length > 0
                ? fieldSepString[0]
                : '|';

            var encodingCharacters = GetValidEncodingCharacters(fieldSep, msh);

            var version = Terser.Get(msh, 12, 0, 1, 1);
            if (version == null)
            {
                // Put in the message version
                Terser.Set(msh, 12, 0, 1, 1, source.Version);
            }

            var msgStructure = Terser.Get(msh, 9, 0, 1, 1);
            if (msgStructure == null)
            {
                // Create the MsgType and Trigger Event if not there
                var messageTypeFullname = source.GetStructureName();
                var i = messageTypeFullname.IndexOf("_");
                if (i > 0)
                {
                    var type = messageTypeFullname.Substring(0, i);
                    var triggerEvent = messageTypeFullname.Substring(i + 1);
                    Terser.Set(msh, 9, 0, 1, 1, type);
                    Terser.Set(msh, 9, 0, 2, 1, triggerEvent);
                }
                else
                {
                    Terser.Set(msh, 9, 0, 1, 1, messageTypeFullname);
                }
            }

            // pass down to group encoding method which will operate recursively on
            // children ...
            return Encode(source, encodingCharacters);
        }

        /// <inheritdoc />
        protected internal override IMessage DoParse(string message, string version)
        {
            // try to instantiate a message object of the right class
            var structure = GetStructure(message);
            var m = InstantiateMessage(structure.Structure, version, structure.ExplicitlyDefined);
            Parse(m, message);

            return m;
        }

        /// <summary>
        /// Returns object that contains the field separator and encoding characters
        /// for this message.
        /// <para>
        /// There's an additional character starting with v2.7 (truncation), but we will
        /// accept it in messages of any version.
        /// </para>
        /// </summary>
        private static EncodingCharacters GetEncodingChars(string message)
        {
            if (message.Length < 9)
            {
                throw new HL7Exception($"Invalid message content: '{message}'");
            }

            return new EncodingCharacters(message[3], message.Substring(4, 4));
        }

        private static string EncodePrimitive(IPrimitive p, EncodingCharacters encodingChars)
        {
            var val = p.Value == null
                ? string.Empty
                : Escape.EscapeText(p.Value, encodingChars);

            return val;
        }

        /// <summary>
        /// Removes unnecessary delimiters from the end of a field or segment.
        /// This seems to be more convenient than checking to see if they are needed
        /// while we are building the encoded string.
        /// </summary>
        private static string StripExtraDelimiters(string in_Renamed, char delim)
        {
            var chars = in_Renamed.ToCharArray();

            // search from back end for first occurrence of non-delimiter ...
            var c = chars.Length - 1;
            var found = false;
            while (c >= 0 && !found)
            {
                if (chars[c--] != delim)
                {
                    found = true;
                }
            }

            var ret = string.Empty;
            if (found)
            {
                ret = new string(chars, 0, c + 2);
            }

            return ret;
        }

        /// <returns>
        /// true if the segment is MSH, FHS, or BHS.
        /// These need special treatment because they define delimiters.
        /// </returns>
        /// <param name="theSegmentName"></param>
        private static bool IsDelimDefSegment(string theSegmentName)
        {
            var isRenamed = theSegmentName.Equals("MSH")
                         || theSegmentName.Equals("FHS")
                         || theSegmentName.Equals("BHS");

            return isRenamed;
        }

        /// <summary> Fills a field with values from an unparsed string representing the field.  </summary>
        /// <param name="destinationField">the field Type.
        /// </param>
        /// <param name="data">the field string (including all components and subcomponents; not including field delimiters).
        /// </param>
        /// <param name="encodingCharacters">the encoding characters used in the message.
        /// </param>
        private static void Parse(IType destinationField, string data, EncodingCharacters encodingCharacters)
        {
            var components = Split(data, Convert.ToString(encodingCharacters.ComponentSeparator));
            for (var i = 0; i < components.Length; i++)
            {
                var subcomponents = Split(components[i], Convert.ToString(encodingCharacters.SubcomponentSeparator));
                for (var j = 0; j < subcomponents.Length; j++)
                {
                    var val = subcomponents[j];
                    if (val != null)
                    {
                        val = Escape.UnescapeText(val, encodingCharacters);
                    }

                    Terser.GetPrimitive(destinationField, i + 1, j + 1).Value = val;
                }
            }
        }

        private EncodingCharacters GetValidEncodingCharacters(char fieldSep, ISegment msh)
        {
            var encCharString = Terser.Get(msh, 2, 0, 1, 1);

            if (encCharString == null)
            {
                // cdc: This was breaking when trying to construct a blank message, and there is no way to set the EncChars, so fill in a default
                // throw new HL7Exception("Can't encode message: MSH-2 (encoding characters) is missing");
                encCharString = @"^~\&";
                Terser.Set(msh, 2, 0, 1, 1, encCharString);
            }

            var version27 = "2.7";

            if (string.CompareOrdinal(version27, msh.Message.Version) > 0 && encCharString.Length != 4)
            {
                throw new HL7Exception(
                    $"Encoding characters (MSH-2) value '{encCharString}' invalid -- must be 4 characters", ErrorCode.DATA_TYPE_ERROR);
            }

            if (encCharString.Length != 4 && encCharString.Length != 5)
            {
                throw new HL7Exception(
                    $"Encoding characters (MSH-2) value '{encCharString}' invalid -- must be 4 or 5 characters", ErrorCode.DATA_TYPE_ERROR);
            }

            return new EncodingCharacters(fieldSep, encCharString);
        }

        /// <returns>
        /// The message structure from MSH-9-3.
        /// </returns>
        private MessageStructure GetStructure(string message)
        {
            var encodingCharacters = GetEncodingChars(message);
            var explicitlyDefined = true;
            string wholeFieldNine;
            string messageStructure;

            try
            {
                var fields = Split(
                    message.Substring(0, Math.Max(message.IndexOf(SegmentDelimiter), message.Length) - 0),
                    Convert.ToString(encodingCharacters.FieldSeparator));
                wholeFieldNine = fields[8];

                // message structure is component 3 but we'll accept a composite of 1 and 2 if there is no component 3 ...
                // if component 1 is ACK, then the structure is ACK regardless of component 2
                var comps = Split(wholeFieldNine, Convert.ToString(encodingCharacters.ComponentSeparator));
                if (comps.Length >= 3)
                {
                    messageStructure = comps[2];
                }
                else if (comps.Length > 0 && comps[0] != null && comps[0].Equals("ACK"))
                {
                    messageStructure = "ACK";
                }
                else if (comps.Length == 2)
                {
                    explicitlyDefined = false;
                    messageStructure = $"{comps[0]}_{comps[1]}";
                }
                else
                {
                    var buf = new StringBuilder("Can't determine message structure from MSH-9: ");
                    buf.Append(wholeFieldNine);
                    if (comps.Length < 3)
                    {
                        buf.Append(" HINT: there are only ");
                        buf.Append(comps.Length);
                        buf.Append(" of 3 components present");
                    }

                    throw new HL7Exception(buf.ToString(), ErrorCode.UNSUPPORTED_MESSAGE_TYPE);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw new HL7Exception("Can't find message structure (MSH-9-3): " + e.Message, ErrorCode.UNSUPPORTED_MESSAGE_TYPE);
            }

            return new MessageStructure(messageStructure, explicitlyDefined);
        }

        private IStructureDefinition GetStructureDefinition(IMessage theMessage)
        {
            var messageType = theMessage.GetType();
            StructureDefinition retVal;

            if (structureDefinitions.TryGetValue(messageType, out var definitions))
            {
                if (definitions.TryGetValue(theMessage.GetStructureName(), out retVal))
                {
                    return retVal;
                }
            }

            Log.Info($"Instantiating msg of class {messageType.FullName}");
            var constructor = messageType.GetConstructor(new[] { typeof(IModelClassFactory) });
            var message = (IMessage)constructor.Invoke(new object[] { Factory });

            StructureDefinition previousLeaf = null;
            retVal = CreateStructureDefinition(message, ref previousLeaf);

            if (structureDefinitions.ContainsKey(messageType))
            {
                return retVal;
            }

            var dictionary = new Dictionary<string, StructureDefinition>
            {
                { theMessage.GetStructureName(), retVal },
            };

            structureDefinitions[messageType] = dictionary;

            return retVal;
        }

        private StructureDefinition CreateStructureDefinition(IStructure theStructure, ref StructureDefinition thePreviousLeaf)
        {
            var result = new StructureDefinition
            {
                Name = theStructure.GetStructureName(),
            };

            if (theStructure is IGroup)
            {
                result.IsSegment = false;
                var group = (IGroup)theStructure;
                var index = 0;
                var childNames = group.Names.ToList();

                foreach (var nextName in childNames)
                {
                    var nextChild = group.GetStructure(nextName);
                    var structureDefinition = CreateStructureDefinition(nextChild, ref thePreviousLeaf);

                    structureDefinition.NameAsItAppearsInParent = nextName;
                    structureDefinition.IsRepeating = group.IsRepeating(nextName);
                    structureDefinition.IsRequired = group.IsRequired(nextName);
                    structureDefinition.IsChoiceElement = group.IsChoiceElement(nextName);
                    structureDefinition.Position = index++;
                    structureDefinition.Parent = result;

                    result.Children.Add(structureDefinition);
                }
            }
            else
            {
                if (thePreviousLeaf != null)
                {
                    thePreviousLeaf.NextLeaf = result;
                }

                thePreviousLeaf = result;
                result.IsSegment = true;
            }

            return result;
        }

        /// <summary>
        /// A struct for holding a message class string and a boolean indicating whether it
        /// was defined explicitly.
        /// </summary>
        private class MessageStructure
        {
            public MessageStructure(string theMessageStructure, bool isExplicitlyDefined)
            {
                Structure = theMessageStructure;
                ExplicitlyDefined = isExplicitlyDefined;
            }

            public string Structure { get; }

            public bool ExplicitlyDefined { get; }
        }
    }
}