/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.
  The Original Code is "XMLParser.java".  Description:
  "Parses and encodes HL7 messages in XML form, according to HL7's normative XML encoding
  specification."
  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2002.  All Rights Reserved.
  Contributor(s): ______________________________________.
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
    using System.IO;
    using System.Text;
    using System.Xml;

    using NHapi.Base.Log;
    using NHapi.Base.Model;
    using NHapi.Base.Util;

    /// <summary>
    /// Parses and encodes HL7 messages in XML form, according to HL7's normative XML encoding
    /// specification.  This is an abstract class that handles datatype and segment parsing/encoding,
    /// but not the parsing/encoding of entire messages.  To use the XML parser, you should create a
    /// subclass for a certain message structure.  This subclass must be able to identify the Segment
    /// objects that correspond to various Segment nodes in an XML document, and call the methods. <code>
    /// parse(Segment segment, ElementNode segmentNode)</code> and. <code>encode(Segment segment, ElementNode segmentNode)
    /// </code> as appropriate.  XMLParser uses the Xerces parser, which must be installed in your class path.
    /// </summary>
    /// <author>Bryan Tripp, Shawn Bellina.</author>
    [Obsolete("Use XMLParser instead.")]
    public abstract class LegacyXMLParser : ParserBase
    {
        private static readonly IHapiLog Log = HapiLogFactory.GetHapiLog(typeof(LegacyXMLParser));

        /// <summary>
        /// The nodes whose names match these strings will be kept as original,
        /// meaning that no white space trimming will occur on them.
        /// </summary>
        private string[] keepAsOriginalNodes;

        /// <summary> All keepAsOriginalNodes names, concatenated by a pipe (|).</summary>
        private string concatKeepAsOriginalNodes = string.Empty;

        protected LegacyXMLParser()
        {
        }

        protected LegacyXMLParser(IModelClassFactory factory)
            : base(factory)
        {
        }

        /// <summary>
        /// Gets the preferred encoding of this Parser.
        /// </summary>
        public override string DefaultEncoding => "XML";

        /// <summary>
        /// Sets the <i>keepAsOriginalNodes</i>.
        /// <para>
        /// The nodes whose names match the <i>keepAsOriginalNodes</i> will be kept as original,
        /// meaning that no white space trimming will occur on them.
        /// </para>
        /// </summary>
        public virtual string[] KeepAsOriginalNodes
        {
            get
            {
                return keepAsOriginalNodes;
            }

            set
            {
                keepAsOriginalNodes = value;

                if (value.Length != 0)
                {
                    // initializes the
                    var strBuf = new StringBuilder(value[0]);
                    for (var i = 1; i < value.Length; i++)
                    {
                        strBuf.Append("|");
                        strBuf.Append(value[i]);
                    }

                    concatKeepAsOriginalNodes = strBuf.ToString();
                }
                else
                {
                    concatKeepAsOriginalNodes = string.Empty;
                }
            }
        }

        /// <summary>
        /// Returns a String representing the encoding of the given message, if
        /// the encoding is recognized.  For example if the given message appears
        /// to be encoded using HL7 2.x XML rules then "XML" would be returned.
        /// If the encoding is not recognized then null is returned.  That this
        /// method returns a specific encoding does not guarantee that the
        /// message is correctly encoded (e.g. well formed XML) - just that
        /// it is not encoded using any other encoding than the one returned.
        /// Returns null if the encoding is not recognized.
        /// </summary>
        public override string GetEncoding(string message)
        {
            string encoding = null;

            // check for a number of expected strings
            var expected = new[] { "<MSH.1", "<MSH.2", "</MSH>" };
            var isXML = true;
            for (var i = 0; i < expected.Length; i++)
            {
                if (message.IndexOf(expected[i], StringComparison.Ordinal) < 0)
                {
                    isXML = false;
                }
            }

            if (isXML)
            {
                encoding = "XML";
            }

            return encoding;
        }

        /// <summary> <p>Creates and populates a Message object from an XML Document that contains an XML-encoded HL7 message.</p>
        /// <p>The easiest way to implement this method for a particular message structure is as follows:
        /// <ol><li>Create an instance of the Message type you are going to handle with your subclass
        /// of XMLParser</li>
        /// <li>Go through the given Document and find the Elements that represent the top level of
        /// each message segment. </li>
        /// <li>For each of these segments, call <code>parse(Segment segmentObject, Element segmentElement)</code>,
        /// providing the appropriate Segment from your Message object, and the corresponding Element.</li></ol>
        /// At the end of this process, your Message object should be populated with data from the XML
        /// Document.</p>
        /// </summary>
        /// <throws>  HL7Exception if the message is not correctly formatted. </throws>
        /// <throws>  EncodingNotSupportedException if the message encoded. </throws>
        /// <summary>      is not supported by this parser.
        /// </summary>
        public IMessage ParseDocument(XmlDocument xmlMessage, string version)
        {
            return ParseDocument(xmlMessage, version, DefaultParserOptions);
        }

        /// <summary> <p>Creates and populates a Message object from an XML Document that contains an XML-encoded HL7 message.</p>
        /// <p>The easiest way to implement this method for a particular message structure is as follows:
        /// <ol><li>Create an instance of the Message type you are going to handle with your subclass
        /// of XMLParser</li>
        /// <li>Go through the given Document and find the Elements that represent the top level of
        /// each message segment. </li>
        /// <li>For each of these segments, call <code>parse(Segment segmentObject, Element segmentElement)</code>,
        /// providing the appropriate Segment from your Message object, and the corresponding Element.</li></ol>
        /// At the end of this process, your Message object should be populated with data from the XML
        /// Document.</p>
        /// </summary>
        /// <throws>  HL7Exception if the message is not correctly formatted. </throws>
        /// <throws>  EncodingNotSupportedException if the message encoded. </throws>
        /// <summary>      is not supported by this parser.
        /// </summary>
        public abstract IMessage ParseDocument(XmlDocument xmlMessage, string version, ParserOptions parserOptions);

        /// <summary> <p>Creates an XML Document that corresponds to the given Message object. </p>
        /// <p>If you are implementing this method, you should create an XML Document, and insert XML Elements
        /// into it that correspond to the groups and segments that belong to the message type that your subclass
        /// of XMLParser supports.  Then, for each segment in the message, call the method
        /// <code>encode(Segment segmentObject, Element segmentElement)</code> using the Element for
        /// that segment and the corresponding Segment object from the given Message.</p>
        /// </summary>
        public abstract XmlDocument EncodeDocument(IMessage source, ParserOptions parserOptions);

        public XmlDocument EncodeDocument(IMessage source)
        {
            return EncodeDocument(source, DefaultParserOptions);
        }

        /// <summary> Populates the given Segment object with data from the given XML Element.</summary>
        /// <throws>  HL7Exception if the XML Element does not have the correct name and structure. </throws>
        /// <summary>      for the given Segment, or if there is an error while setting individual field values.
        /// </summary>
        public virtual void Parse(ISegment segmentObject, XmlElement segmentElement)
        {
            Parse(segmentObject, segmentElement, DefaultParserOptions);
        }

        /// <summary> Populates the given Segment object with data from the given XML Element.</summary>
        /// <throws>  HL7Exception if the XML Element does not have the correct name and structure. </throws>
        /// <summary>      for the given Segment, or if there is an error while setting individual field values.
        /// </summary>
        public virtual void Parse(ISegment segmentObject, XmlElement segmentElement, ParserOptions parserOptions)
        {
            parserOptions ??= DefaultParserOptions;

            var done = new SupportClass.HashSetSupport();
            var all = segmentElement.ChildNodes;
            for (var i = 0; i < all.Count; i++)
            {
                var elementName = all.Item(i).Name;
                if (Convert.ToInt16(all.Item(i).NodeType) == (short)XmlNodeType.Element && !done.Contains(elementName))
                {
                    done.Add(elementName);

                    var index = elementName.IndexOf('.');
                    if (index >= 0 && elementName.Length > index)
                    {
                        // properly formatted element
                        var fieldNumString = elementName.Substring(index + 1);
                        var fieldNum = int.Parse(fieldNumString);
                        ParseReps(segmentObject, segmentElement, elementName, fieldNum);
                    }
                    else
                    {
                        Log.Debug("Child of segment " + segmentObject.GetStructureName() + " doesn't look like a field: " + elementName);
                    }
                }
            }

            // set data type of OBX-5
            if (segmentObject.GetType().FullName.IndexOf("OBX", StringComparison.Ordinal) >= 0)
            {
                Varies.FixOBX5(segmentObject, Factory, parserOptions);
            }
        }

        /// <summary> Populates the given Element with data from the given Segment, by inserting
        /// Elements corresponding to the Segment's fields, their components, etc.  Returns
        /// true if there is at least one data value in the segment.
        /// </summary>
        public virtual bool Encode(ISegment segmentObject, XmlElement segmentElement)
        {
            return Encode(segmentObject, segmentElement, DefaultParserOptions);
        }

        /// <summary> Populates the given Element with data from the given Segment, by inserting
        /// Elements corresponding to the Segment's fields, their components, etc.  Returns
        /// true if there is at least one data value in the segment.
        /// </summary>
        public virtual bool Encode(ISegment segmentObject, XmlElement segmentElement, ParserOptions parserOptions)
        {
            var hasValue = false;
            var n = segmentObject.NumFields();
            for (var i = 1; i <= n; i++)
            {
                var name = MakeElementName(segmentObject, i);
                var reps = segmentObject.GetField(i);
                for (var j = 0; j < reps.Length; j++)
                {
                    var newNode = segmentElement.OwnerDocument.CreateElement(name);

                    var componentHasValue = Encode(reps[j], newNode, parserOptions);
                    if (componentHasValue)
                    {
                        try
                        {
                            segmentElement.AppendChild(newNode);
                        }
                        catch (Exception e)
                        {
                            throw new HL7Exception("DOMException encoding Segment: ", ErrorCode.APPLICATION_INTERNAL_ERROR, e);
                        }

                        hasValue = true;
                    }
                }
            }

            return hasValue;
        }

        /// <summary> Populates the given Type object with data from the given XML Element.</summary>
        public virtual void Parse(IType datatypeObject, XmlElement datatypeElement)
        {
            // TODO: consider replacing with a switch statement
            if (datatypeObject is Varies)
            {
                ParseVaries((Varies)datatypeObject, datatypeElement);
            }
            else if (datatypeObject is IPrimitive)
            {
                ParsePrimitive((IPrimitive)datatypeObject, datatypeElement);
            }
            else if (datatypeObject is IComposite)
            {
                ParseComposite((IComposite)datatypeObject, datatypeElement);
            }
        }

        /// <summary> <p>Returns a minimal amount of data from a message string, including only the
        /// data needed to send a response to the remote system.  This includes the
        /// following fields:
        /// <list type="bullet">
        /// <item><description>field separator</description></item>
        /// <item><description>encoding characters</description></item>
        /// <item><description>processing ID</description></item>
        /// <item><description>message control ID</description></item>
        /// </list>
        /// This method is intended for use when there is an error parsing a message,
        /// (so the Message object is unavailable) but an error message must be sent
        /// back to the remote system including some of the information in the inbound
        /// message.  This method parses only that required information, hopefully
        /// avoiding the condition that caused the original error.</p>
        /// </summary>
        public override ISegment GetCriticalResponseData(string message)
        {
            var version = GetVersion(message);
            var criticalData = MakeControlMSH(version, Factory);

            Terser.Set(criticalData, 1, 0, 1, 1, ParseLeaf(message, "MSH.1", 0));
            Terser.Set(criticalData, 2, 0, 1, 1, ParseLeaf(message, "MSH.2", 0));
            Terser.Set(criticalData, 10, 0, 1, 1, ParseLeaf(message, "MSH.10", 0));
            var procID = ParseLeaf(message, "MSH.11", 0);
            if (procID == null || procID.Length == 0)
            {
                procID = ParseLeaf(message, "PT.1", message.IndexOf("MSH.11", StringComparison.Ordinal));

                // this field is a composite in later versions
            }

            Terser.Set(criticalData, 11, 0, 1, 1, procID);

            return criticalData;
        }

        /// <summary>
        /// For response messages, returns the value of MSA-2 (the message ID of the message
        /// sent by the sending system). This value may be needed prior to main message parsing,
        /// so that (particularly in a multi-threaded scenario) the message can be routed to
        /// the thread that sent the request. We need this information first so that any
        /// parse exceptions are thrown to the correct thread. Implementers of Parsers should
        /// take care to make the implementation of this method very fast and robust.
        /// Returns null if MSA-2 can not be found (e.g. if the message is not a
        /// response message). Trims whitespace from around the MSA-2 field.
        /// </summary>
        public override string GetAckID(string message)
        {
            try
            {
                return ParseLeaf(message, "msa.2", 0).Trim();
            }
            catch (HL7Exception)
            {
                // OK ... assume it isn't a response message
                return null;
            }
        }

        /// <inheritdoc />
        public override string GetVersion(string message, ParserOptions parserOptions)
        {
            var version = ParseLeaf(message, "MSH.12", 0);
            if (version == null || version.Trim().Length == 0)
            {
                version = ParseLeaf(message, "VID.1", message.IndexOf("MSH.12", StringComparison.Ordinal));
            }

            return version;
        }

        /// <summary>
        /// Checks if a node content should be kept as original (ie.: whitespaces won't be removed).
        /// </summary>
        /// <param name="node">The target node.</param>
        /// <returns>
        /// <c>true</c> if whitespaces should not be removed from node content; otherwise, <c>false</c>.
        /// </returns>
        protected internal virtual bool KeepAsOriginal(XmlNode node)
        {
            return
                node.Name != null
                && concatKeepAsOriginalNodes.IndexOf(node.Name, StringComparison.Ordinal) != -1;
        }

        /// <summary>
        /// Removes all unnecessary whitespace from the given String (intended to be used with Primitive values).
        /// This includes leading and trailing whitespace, and repeated space characters. Carriage returns,
        /// line feeds, and tabs are replaced with spaces.
        /// </summary>
        protected internal virtual string RemoveWhitespace(string s)
        {
            s = s.Replace('\r', ' ');
            s = s.Replace('\n', ' ');
            s = s.Replace('\t', ' ');

            var repeatedSpacesExist = true;
            while (repeatedSpacesExist)
            {
                var loc = s.IndexOf("  ", StringComparison.Ordinal);
                if (loc < 0)
                {
                    repeatedSpacesExist = false;
                }
                else
                {
                    var buf = new StringBuilder();
                    buf.Append(s.Substring(0, loc - 0));
                    buf.Append(" ");
                    buf.Append(s.Substring(loc + 2));
                    s = buf.ToString();
                }
            }

            return s.Trim();
        }

        /// <summary>
        /// Parses a message string and returns the corresponding Message
        /// object. This method checks that the given message string is XML encoded, creates an
        /// XML Document object (using Xerces) from the given String, and calls the abstract
        /// method <see cref="ParseDocument(XmlDocument, string)"/>.
        /// </summary>
        protected internal override IMessage DoParse(string message, string version, ParserOptions parserOptions)
        {
            IMessage m;

            // parse message string into a DOM document
            try
            {
                var doc = new XmlDocument();
                doc.Load(new StringReader(message));

                m = ParseDocument(doc, version, parserOptions);
            }
            catch (XmlException e)
            {
                throw new HL7Exception("XmlException parsing XML", ErrorCode.APPLICATION_INTERNAL_ERROR, e);
            }
            catch (IOException e)
            {
                throw new HL7Exception("IOException parsing XML", ErrorCode.APPLICATION_INTERNAL_ERROR, e);
            }

            return m;
        }

        /// <summary>
        /// Formats a Message object into an HL7 message string using the given encoding.
        /// </summary>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        protected internal override string DoEncode(IMessage source, string encoding, ParserOptions parserOptions)
        {
            if (!SupportsEncoding("XML"))
            {
                throw new EncodingNotSupportedException("XMLParser supports only XML encoding");
            }

            return Encode(source, parserOptions);
        }

        /// <summary>
        /// Formats a Message object into an HL7 message string using this parser's
        /// default encoding (XML encoding). This method calls the abstract method.
        /// <code>encodeDocument(...)</code> in order to obtain XML Document object
        /// representation of the Message, then serializes it to a String.
        /// </summary>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        protected internal override string DoEncode(IMessage source, ParserOptions parserOptions)
        {
            if (source is GenericMessage)
            {
                throw new HL7Exception(
                    "Can't XML-encode a GenericMessage. Message must have a recognized structure.");
            }

            var doc = EncodeDocument(source, parserOptions);
            doc.DocumentElement.SetAttribute("xmlns", "urn:hl7-org:v2xml");

            return doc.OuterXml;
        }

        /// <summary>
        /// Attempts to retrieve the value of a leaf tag without using DOM or SAX.
        /// This method searches the given message string for the given tag name, and returns
        /// everything after the given tag and before the start of the next tag.  Whitespace
        /// is stripped.  This is intended only for lead nodes, as the value is considered to
        /// end at the start of the next tag, regardless of whether it is the matching end
        /// tag or some other nested tag.
        /// </summary>
        /// <param name="message">a string message in XML form.</param>
        /// <param name="tagName">the name of the XML tag, e.g. "MSA.2".</param>
        /// <param name="startAt">the character location at which to start searching.</param>
        /// <exception cref="HL7Exception">Thrown if the tag can not be found.</exception>
        protected internal virtual string ParseLeaf(string message, string tagName, int startAt)
        {
            var tagStart = message.IndexOf("<" + tagName, startAt, StringComparison.Ordinal);
            if (tagStart < 0)
            {
                tagStart = message.IndexOf("<" + tagName.ToUpperInvariant(), startAt, StringComparison.Ordinal);
            }

            var valStart = message.IndexOf(">", tagStart, StringComparison.Ordinal) + 1;
            var valEnd = message.IndexOf("<", valStart, StringComparison.Ordinal);

            string value;
            if (tagStart >= 0 && valEnd >= valStart)
            {
                value = message.Substring(valStart, valEnd - valStart);
            }
            else
            {
                throw new HL7Exception(
                    $"Couldn't find {tagName} in message beginning: {message.Substring(0, Math.Min(150, message.Length) - 0)}",
                    ErrorCode.REQUIRED_FIELD_MISSING);
            }

            return value;
        }

        /// <summary> Populates a Composite type by looping through it's children, finding corresponding
        /// Elements among the children of the given Element, and calling parse(Type, Element) for
        /// each.
        /// </summary>
        private void ParseComposite(IComposite datatypeObject, XmlElement datatypeElement)
        {
            if (datatypeObject is GenericComposite)
            {
                // elements won't be named GenericComposite.x
                var children = datatypeElement.ChildNodes;
                var compNum = 0;
                for (var i = 0; i < children.Count; i++)
                {
                    if (Convert.ToInt16(children.Item(i).NodeType) == (short)XmlNodeType.Element)
                    {
                        Parse(datatypeObject[compNum], (XmlElement)children.Item(i));
                        compNum++;
                    }
                }
            }
            else
            {
                var children = datatypeObject.Components;
                for (var i = 0; i < children.Length; i++)
                {
                    var matchingElements = datatypeElement.GetElementsByTagName(MakeElementName(datatypeObject, i + 1));
                    if (matchingElements.Count > 0)
                    {
                        Parse(children[i], (XmlElement)matchingElements.Item(0)); // components don't repeat - use 1st
                    }
                }
            }
        }

        /// <summary>
        /// Returns the expected XML element name for the given child of the given Segment.
        /// </summary>
        private string MakeElementName(ISegment s, int child)
        {
            return $"{s.GetStructureName()}.{child}";
        }

        /// <summary>
        /// Returns the expected XML element name for the given child of the given Composite.
        /// </summary>
        private string MakeElementName(IComposite composite, int child)
        {
            return $"{composite.TypeName}.{child}";
        }

        /// <summary>
        /// Populates the given <see cref="XmlElement"/> with data from the given <see cref="IType"/>, by inserting
        /// XmlElements corresponding to the Type's components and values.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the given type contains a value (i.e. for Primitives, if
        /// <see cref="IPrimitive.Value"/> doesn't return null, and for Composites, if at least one underlying
        /// Primitive doesn't return null).
        /// </returns>
        private bool Encode(IType datatypeObject, XmlElement datatypeElement, ParserOptions parserOptions)
        {
            var hasData = false;

            // TODO: consider using a switch statement
            if (datatypeObject is Varies)
            {
                hasData = EncodeVaries((Varies)datatypeObject, datatypeElement, parserOptions);
            }
            else if (datatypeObject is IPrimitive)
            {
                hasData = EncodePrimitive((IPrimitive)datatypeObject, datatypeElement);
            }
            else if (datatypeObject is IComposite)
            {
                hasData = EncodeComposite((IComposite)datatypeObject, datatypeElement, parserOptions);
            }

            return hasData;
        }

        /// <summary>
        /// Encodes a Varies type by extracting it's data field and encoding that.
        /// </summary>
        /// <returns><see langword="true" /> if the data field (or one of its components) contains a value.</returns>
        private bool EncodeVaries(Varies datatypeObject, XmlElement datatypeElement, ParserOptions parserOptions)
        {
            var hasData = false;
            if (datatypeObject.Data != null)
            {
                hasData = Encode(datatypeObject.Data, datatypeElement, parserOptions);
            }

            return hasData;
        }

        /// <summary>
        /// Encodes a Primitive in XML by adding it's value as a child of the given Element.
        /// </summary>
        /// <returns><see langword="true" /> if the given Primitive contains a value.</returns>
        private bool EncodePrimitive(IPrimitive datatypeObject, XmlElement datatypeElement)
        {
            var hasValue = datatypeObject.Value != null && !datatypeObject.Value.Equals(string.Empty);

            var t = datatypeElement.OwnerDocument.CreateTextNode(datatypeObject.Value);
            if (hasValue)
            {
                try
                {
                    datatypeElement.AppendChild(t);
                }
                catch (Exception e)
                {
                    throw new DataTypeException("DOMException encoding Primitive: ", e);
                }
            }

            return hasValue;
        }

        /// <summary>
        /// Encodes a Composite in XML by looping through it's components, creating new
        /// children for each of them (with the appropriate names) and populating them by
        /// calling <see cref="Encode(IType, XmlElement, ParserOptions)"/> using these children.
        /// </summary>
        /// <returns><see langword="true" /> if at least one component contains a value.</returns>
        private bool EncodeComposite(IComposite datatypeObject, XmlElement datatypeElement, ParserOptions parserOptions)
        {
            var components = datatypeObject.Components;
            var hasValue = false;
            for (var i = 0; i < components.Length; i++)
            {
                var name = MakeElementName(datatypeObject, i + 1);
                var newNode = datatypeElement.OwnerDocument.CreateElement(name);
                var componentHasValue = Encode(components[i], newNode, parserOptions);
                if (componentHasValue)
                {
                    try
                    {
                        datatypeElement.AppendChild(newNode);
                    }
                    catch (Exception e)
                    {
                        throw new DataTypeException("DOMException encoding Composite: ", e);
                    }

                    hasValue = true;
                }
            }

            return hasValue;
        }

        private void ParseReps(ISegment segmentObject, XmlElement segmentElement, string fieldName, int fieldNum)
        {
            var reps = segmentElement.GetElementsByTagName(fieldName);
            for (var i = 0; i < reps.Count; i++)
            {
                Parse(segmentObject.GetField(fieldNum, i), (XmlElement)reps.Item(i));
            }
        }

        /// <summary>
        /// Parses an XML element into a Varies by determining whether the element is primitive or
        /// composite, calling setData() on the Varies with a new generic primitive or composite as appropriate,
        /// and then calling parse again with the new Type object.
        /// </summary>
        private void ParseVaries(Varies datatypeObject, XmlElement datatypeElement)
        {
            // figure out what data type it holds
            if (!HasChildElement(datatypeElement))
            {
                // it's a primitive
                datatypeObject.Data = new GenericPrimitive(datatypeObject.Message);
            }
            else
            {
                // it's a composite ... almost know what type, except that we don't have the version here
                datatypeObject.Data = new GenericComposite(datatypeObject.Message);
            }

            Parse(datatypeObject.Data, datatypeElement);
        }

        /// <summary>Returns true if any of the given element's children are elements. </summary>
        private bool HasChildElement(XmlElement e)
        {
            var children = e.ChildNodes;
            var hasElement = false;
            var c = 0;
            while (c < children.Count && !hasElement)
            {
                if (Convert.ToInt16(children.Item(c).NodeType) == (short)XmlNodeType.Element)
                {
                    hasElement = true;
                }

                c++;
            }

            return hasElement;
        }

        /// <summary>Parses a primitive type by filling it with text child, if any. </summary>
        private void ParsePrimitive(IPrimitive datatypeObject, XmlElement datatypeElement)
        {
            var children = datatypeElement.ChildNodes;
            var c = 0;
            var full = false;
            while (c < children.Count && !full)
            {
                var child = children.Item(c++);
                if (Convert.ToInt16(child.NodeType) == (short)XmlNodeType.Text)
                {
                    try
                    {
                        if (child.Value != null && !child.Value.Equals(string.Empty))
                        {
                            if (KeepAsOriginal(child.ParentNode))
                            {
                                datatypeObject.Value = child.Value;
                            }
                            else
                            {
                                datatypeObject.Value = RemoveWhitespace(child.Value);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error("Error parsing primitive value from TEXT_NODE", e);
                    }

                    full = true;
                }
            }
        }
    }
}