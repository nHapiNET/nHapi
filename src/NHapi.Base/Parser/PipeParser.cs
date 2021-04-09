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
    using System.Text;
    using System.Text.RegularExpressions;

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
        private const string SegDelim = "\r"; // see section 2.8 of spec

        private static readonly IHapiLog Log;

        static PipeParser()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(PipeParser));
        }

        /// <summary>Creates a new PipeParser. </summary>
        public PipeParser()
        {
        }

        /// <summary>Creates a new PipeParser. </summary>
        public PipeParser(IModelClassFactory factory)
            : base(factory)
        {
        }

        /// <summary>
        /// Gets the preferred encoding of this Parser.
        /// </summary>
        public override string DefaultEncoding => "VB";

        /// <summary>
        /// Splits the given composite string into an array of components using
        /// the given delimiter.
        /// </summary>
        public static string[] Split(string composite, string delim)
        {
            var components = new ArrayList();

            // defend against evil nulls
            if (composite == null)
            {
                composite = string.Empty;
            }

            if (delim == null)
            {
                delim = string.Empty;
            }

            var tok = new SupportClass.Tokenizer(composite, delim, true);
            var previousTokenWasDelim = true;
            while (tok.HasMoreTokens())
            {
                var thisTok = tok.NextToken();
                if (thisTok.Equals(delim))
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
        /// Encodes the given Type, using the given encoding characters.
        /// It is assumed that the Type represents a complete field rather than a component.
        /// </summary>
        public static string Encode(IType source, EncodingCharacters encodingChars)
        {
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
        /// Returns given group serialized as a pipe-encoded string - this method is called
        /// by encode(Message source, String encoding).
        /// </summary>
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
            var out_Renamed = new StringBuilder();
            var chars = in_Renamed.ToCharArray();
            var c = 0;
            while (c < chars.Length)
            {
                if (!char.IsWhiteSpace(chars[c]))
                {
                    break;
                }

                c++;
            }

            for (var i = c; i < chars.Length; i++)
            {
                out_Renamed.Append(chars[i]);
            }

            return out_Renamed.ToString();
        }

        /// <summary> Returns a String representing the encoding of the given message, if
        /// the encoding is recognized.  For example if the given message appears
        /// to be encoded using HL7 2.x XML rules then "XML" would be returned.
        /// If the encoding is not recognized then null is returned.  That this
        /// method returns a specific encoding does not guarantee that the
        /// message is correctly encoded (e.g. well formed XML) - just that
        /// it is not encoded using any other encoding than the one returned.
        /// </summary>
        public override string GetEncoding(string message)
        {
            string encoding = null;

            // quit if the string is too short
            if (message.Length < 4)
            {
                return null;
            }

            // see if it looks like this message is | encoded ...
            var ok = true;

            // string should start with "MSH"
            if (!message.StartsWith("MSH"))
            {
                return null;
            }

            // 4th character of each segment should be field delimiter
            var fourthChar = message[3];
            var st = new SupportClass.Tokenizer(message, Convert.ToString(SegDelim), false);
            while (st.HasMoreTokens())
            {
                var x = st.NextToken();
                if (x.Length > 0)
                {
                    if (char.IsWhiteSpace(x[0]))
                    {
                        x = StripLeadingWhitespace(x);
                    }

                    if (x.Length >= 4 && x[3] != fourthChar)
                    {
                        return null;
                    }
                }
            }

            // should be at least 11 field delimiters (because MSH-12 is required)
            var nextFieldDelimLoc = 0;
            for (var i = 0; i < 11; i++)
            {
                nextFieldDelimLoc = message.IndexOf((char)fourthChar, nextFieldDelimLoc + 1);
                if (nextFieldDelimLoc < 0)
                {
                    return null;
                }
            }

            if (ok)
            {
                encoding = "VB";
            }

            return encoding;
        }

        /// <summary>
        /// Returns true if and only if the given encoding is supported
        /// by this Parser.
        /// </summary>
        public override bool SupportsEncoding(string encoding)
        {
            return (encoding ?? string.Empty).Equals("VB");
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

        /// <summary> Parses a segment string and populates the given Segment object.  Unexpected fields are
        /// added as Varies' at the end of the segment.
        ///
        /// </summary>
        /// <throws>  HL7Exception if the given string does not contain the. </throws>
        /// <summary>      given segment or if the string is not encoded properly.
        /// </summary>
        public virtual void Parse(ISegment destination, string segment, EncodingCharacters encodingChars)
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
                        e.FieldPosition = i + fieldOffset;
                        e.SegmentRepetition = MessageIterator.GetIndex(destination.ParentStructure, destination).Rep;
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

        /// <summary> <p>Returns a minimal amount of data from a message string, including only the
        /// data needed to send a response to the remote system.  This includes the
        /// following fields:
        /// <ul><li>field separator</li>
        /// <li>encoding characters</li>
        /// <li>processing ID</li>
        /// <li>message control ID</li></ul>
        /// This method is intended for use when there is an error parsing a message,
        /// (so the Message object is unavailable) but an error message must be sent
        /// back to the remote system including some of the information in the inbound
        /// message.  This method parses only that required information, hopefully
        /// avoiding the condition that caused the original error.  The other
        /// fields in the returned MSH segment are empty.</p>
        /// </summary>
        public override ISegment GetCriticalResponseData(string message)
        {
            // try to get MSH segment
            var locStartMSH = message.IndexOf("MSH");
            if (locStartMSH < 0)
            {
                throw new HL7Exception("Couldn't find MSH segment in message: " + message, ErrorCode.SEGMENT_SEQUENCE_ERROR);
            }

            var locEndMSH = message.IndexOf('\r', locStartMSH + 1);
            if (locEndMSH < 0)
            {
                locEndMSH = message.Length;
            }

            var mshString = message.Substring(locStartMSH, locEndMSH - locStartMSH);

            // find out what the field separator is
            var fieldSep = mshString[3];

            // get field array
            var fields = Split(mshString, Convert.ToString(fieldSep));

            ISegment msh;
            try
            {
                // parse required fields
                var encChars = fields[1];
                var compSep = encChars[0];
                var messControlID = fields[9];
                var procIDComps = Split(fields[10], Convert.ToString(compSep));

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
                Terser.Set(msh, 10, 0, 1, 1, messControlID);
                Terser.Set(msh, 11, 0, 1, 1, procIDComps[0]);
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

        /// <summary> For response messages, returns the value of MSA-2 (the message ID of the message
        /// sent by the sending system).  This value may be needed prior to main message parsing,
        /// so that (particularly in a multi-threaded scenario) the message can be routed to
        /// the thread that sent the request.  We need this information first so that any
        /// parse exceptions are thrown to the correct thread.
        /// Returns null if MSA-2 can not be found (e.g. if the message is not a
        /// response message).
        /// </summary>
        public override string GetAckID(string message)
        {
            string ackID = null;
            var startMSA = message.IndexOf("\rMSA");
            if (startMSA >= 0)
            {
                var startFieldOne = startMSA + 5;
                var fieldDelim = message[startFieldOne - 1];
                var start = message.IndexOf((char)fieldDelim, startFieldOne) + 1;
                var end = message.IndexOf((char)fieldDelim, start);
                var segEnd = message.IndexOf(Convert.ToString(SegDelim), start);
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

        /// <summary> Returns the version ID (MSH-12) from the given message, without fully parsing the message.
        /// The version is needed prior to parsing in order to determine the message class
        /// into which the text of the message should be parsed.
        /// </summary>
        /// <throws>  HL7Exception if the version field can not be found. </throws>
        public override string GetVersion(string message)
        {
            var startMSH = message.IndexOf("MSH");
            if (startMSH < 0)
            {
                throw new HL7Exception("No MSH header segment found.", ErrorCode.REQUIRED_FIELD_MISSING);
            }

            var endMSH = message.IndexOf(SegDelim, startMSH);
            if (endMSH < 0)
            {
                endMSH = message.Length;
            }

            var msh = message.Substring(startMSH, endMSH - startMSH);
            string fieldSep;
            if (msh.Length > 3)
            {
                fieldSep = Convert.ToString(msh[3]);
            }
            else
            {
                throw new HL7Exception("Can't find field separator in MSH: " + msh, ErrorCode.UNSUPPORTED_VERSION_ID);
            }

            var fields = Split(msh, fieldSep);

            string compSep;
            if (fields.Length >= 2 && fields[0] == "MSH" && fields[1] != null && fields[1].Length > 0)
            {
                compSep = Convert.ToString(fields[1][0]); // get component separator as 1st encoding char
            }
            else
            {
                throw new HL7Exception(
                    "Can't find encoding characters - MSH has only " + fields.Length + " fields",
                    ErrorCode.REQUIRED_FIELD_MISSING);
            }

            string version;
            if (fields.Length >= 12)
            {
                if (fields[11] == null)
                {
                    throw new HL7Exception("MSH Version field is null.", ErrorCode.REQUIRED_FIELD_MISSING);
                }

                version = Split(fields[11], compSep)[0];
            }
            else
            {
                throw new HL7Exception(
                    "Can't find version ID - MSH has only " + fields.Length + " fields.",
                    ErrorCode.REQUIRED_FIELD_MISSING);
            }

            return version.Trim();
        }

        /// <summary> Formats a Message object into an HL7 message string using the given
        /// encoding.
        /// </summary>
        /// <throws>  HL7Exception if the data fields in the message do not permit encoding. </throws>
        /// <summary>      (e.g. required fields are null).
        /// </summary>
        /// <throws>  EncodingNotSupportedException if the requested encoding is not. </throws>
        /// <summary>      supported by this parser.
        /// </summary>
        protected internal override string DoEncode(IMessage source, string encoding)
        {
            if (!SupportsEncoding(encoding))
            {
                throw new EncodingNotSupportedException("This parser does not support the " + encoding + " encoding");
            }

            return Encode(source);
        }

        /// <summary> Formats a Message object into an HL7 message string using this parser's
        /// default encoding ("VB").
        /// </summary>
        /// <throws>  HL7Exception if the data fields in the message do not permit encoding. </throws>
        /// <summary>      (e.g. required fields are null).
        /// </summary>
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

            var fieldSep = '|';
            if (fieldSepString != null && fieldSepString.Length > 0)
            {
                fieldSep = fieldSepString[0];
            }

            var encCharString = Terser.Get(msh, 2, 0, 1, 1);

            if (encCharString == null)
            {
                // cdc: This was breaking when trying to construct a blank message, and there is no way to set the EncChars, so fill in a default
                // throw new HL7Exception("Can't encode message: MSH-2 (encoding characters) is missing");
                encCharString = @"^~\&";
                Terser.Set(msh, 2, 0, 1, 1, encCharString);
            }

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

            if (encCharString.Length != 4)
            {
                throw new HL7Exception(
                    "Encoding characters '" + encCharString + "' invalid -- must be 4 characters",
                    ErrorCode.DATA_TYPE_ERROR);
            }

            var en = new EncodingCharacters(fieldSep, encCharString);

            // pass down to group encoding method which will operate recursively on children ...
            return Encode((IGroup)source, en);
        }

        /// <summary> Parses a message string and returns the corresponding Message
        /// object.  Unexpected segments added at the end of their group.
        ///
        /// </summary>
        /// <throws>  HL7Exception if the message is not correctly formatted. </throws>
        /// <throws>  EncodingNotSupportedException if the message encoded. </throws>
        /// <summary>      is not supported by this parser.
        /// </summary>
        protected internal override IMessage DoParse(string message, string version)
        {
            // try to instantiate a message object of the right class
            var structure = GetStructure(message);
            var m = InstantiateMessage(structure.Structure, version, structure.ExplicitlyDefined);

            var messageIter = new MessageIterator(m, "MSH", true);
            FilterIterator.IPredicate segmentsOnly = new AnonymousClassPredicate(this);
            var segmentIter = new FilterIterator(messageIter, segmentsOnly);

            var segments = Split(message, SegDelim);
            var encodingChars = GetEncodingChars(message);
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
                    var name = segments[i].Substring(0, 3 - 0);
                    Log.Debug("Parsing segment " + name);

                    messageIter.Direction = name;
                    FilterIterator.IPredicate byDirection = new AnonymousClassPredicate1(name, this);
                    var dirIter = new FilterIterator(segmentIter, byDirection);
                    if (dirIter.MoveNext())
                    {
                        Parse((ISegment)dirIter.Current, segments[i], encodingChars);
                    }
                }
            }

            return m;
        }

        /// <summary> Returns object that contains the field separator and encoding characters
        /// for this message.
        /// </summary>
        private static EncodingCharacters GetEncodingChars(string message)
        {
            return new EncodingCharacters(message[3], message.Substring(4, 8 - 4));
        }

        private static string EncodePrimitive(IPrimitive p, EncodingCharacters encodingChars)
        {
            var val = ((IPrimitive)p).Value;
            if (val == null)
            {
                val = string.Empty;
            }
            else
            {
                val = Escape.EscapeText(val, encodingChars);
            }

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

        /// <returns> true if the segment is MSH, FHS, or BHS.  These need special treatment
        /// because they define delimiters.
        /// </returns>
        /// <param name="theSegmentName">
        /// </param>
        private static bool IsDelimDefSegment(string theSegmentName)
        {
            var is_Renamed = false;
            if (theSegmentName.Equals("MSH") || theSegmentName.Equals("FHS") || theSegmentName.Equals("BHS"))
            {
                is_Renamed = true;
            }

            return is_Renamed;
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

        /// <returns>s the message structure from MSH-9-3.
        /// </returns>
        private MessageStructure GetStructure(string message)
        {
            var ec = GetEncodingChars(message);
            var explicityDefined = true;
            string wholeFieldNine;
            string messageStructure;
            try
            {
                var fields = Split(
                    message.Substring(0, Math.Max(message.IndexOf(SegDelim), message.Length) - 0),
                    Convert.ToString(ec.FieldSeparator));
                wholeFieldNine = fields[8];

                // message structure is component 3 but we'll accept a composite of 1 and 2 if there is no component 3 ...
                //      if component 1 is ACK, then the structure is ACK regardless of component 2
                var comps = Split(wholeFieldNine, Convert.ToString(ec.ComponentSeparator));
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
                    explicityDefined = false;
                    messageStructure = comps[0] + "_" + comps[1];
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

            return new MessageStructure(messageStructure, explicityDefined);
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

        private class AnonymousClassPredicate : FilterIterator.IPredicate
        {
            public AnonymousClassPredicate(PipeParser enclosingInstance)
            {
                Enclosing_Instance = enclosingInstance;
            }

            public PipeParser Enclosing_Instance { get; }

            public virtual bool evaluate(object obj)
            {
                return Evaluate(obj);
            }

            public virtual bool Evaluate(object obj)
            {
                return typeof(ISegment).IsAssignableFrom(obj.GetType());
            }
        }

        private class AnonymousClassPredicate1 : FilterIterator.IPredicate
        {
            public AnonymousClassPredicate1(string name, PipeParser enclosingInstance)
            {
                Name = name;
                Enclosing_Instance = enclosingInstance;
            }

            public PipeParser Enclosing_Instance { get; }

            private string Name { get; }

            /// <inheritdoc />
            public virtual bool evaluate(object obj)
            {
                return Evaluate(obj);
            }

            /// <inheritdoc />
            public virtual bool Evaluate(object obj)
            {
                var structureName = ((IStructure)obj).GetStructureName();
                Log.Debug($"PipeParser iterating message in direction {Name} at {structureName}");

                return Regex.IsMatch(structureName, Regex.Escape(Name) + $"\\d*");
            }
        }
    }
}