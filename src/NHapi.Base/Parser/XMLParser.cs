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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
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
    public abstract class XMLParser : ParserBase
    {
        protected static readonly string NameSpace = "urn:hl7-org:v2xml";

        private static readonly IHapiLog Log = HapiLogFactory.GetHapiLog(typeof(XMLParser));

        private static readonly string EscapeAttrName = "V";

        private static readonly string EscapeNodeName = "escape";

        private static readonly Regex NameSpaceRegex = new Regex(@$"xmlns(.*)=""{NameSpace}""", RegexOptions.Compiled);

        /// <summary> _includeLongNameInEncodedXML.</summary>
        private bool _includeLongNameInEncodedXML;

        protected XMLParser()
        {
        }

        protected XMLParser(IModelClassFactory factory)
            : base(factory)
        {
        }

        public bool IncludeLongNameInEncodedXML
        {
            get { return _includeLongNameInEncodedXML; }
            set { _includeLongNameInEncodedXML = value; }
        }

        /// <summary>
        /// Gets the preferred encoding of this Parser.
        /// </summary>
        public override string DefaultEncoding => "XML";

        /// <summary>
        /// <para>
        /// The nodes whose names match these strings will be kept as original,
        /// meaning that no white space trimming will occur on them.
        /// </para>
        /// </summary>
        [Obsolete("This method has been replaced by 'ParserOptions.XmlNodeNamesToDisableWhitespaceTrimming'.")]
        public virtual IEnumerable<string> KeepAsOriginalNodes { get; set; } = new List<string>();

        /// <summary>Test harness. </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Out.WriteLine("Usage: XMLParser pipe_encoded_file");
                Environment.Exit(1);
            }

            // read and parse message from file
            try
            {
                var parser = new PipeParser();
                var messageFile = new FileInfo(args[0]);
                var fileLength = SupportClass.FileLength(messageFile);
                var r = new StreamReader(messageFile.FullName, Encoding.Default);
                var buffer = new char[(int)fileLength];
                Console.Out.WriteLine(
                    $"Reading message file ... {r.Read(buffer, 0, buffer.Length)} of {fileLength} chars");
                r.Close();
                var messString = Convert.ToString(buffer);
                var mess = parser.Parse(messString);
                Console.Out.WriteLine("Got message of type " + mess.GetType().FullName);

                XMLParser xp = new AnonymousClassXMLParser();

                // loop through segment children of message, encode, print to console
                var structNames = mess.Names;
                for (var i = 0; i < structNames.Length; i++)
                {
                    var reps = mess.GetAll(structNames[i]);
                    for (var j = 0; j < reps.Length; j++)
                    {
                        if (reps[j] is ISegment)
                        {
                            // ignore groups
                            var doc = new XmlDocument(); // new doc for each segment
                            var root = doc.CreateElement(reps[j].GetType().FullName, NameSpace);
                            doc.AppendChild(root);
                            xp.Encode((ISegment)reps[j], root);
                            var outRenamed = new StringWriter();
                            Console.Out.WriteLine("Segment " + reps[j].GetType().FullName + ": \r\n" + doc.OuterXml);

                            var segmentConstructTypes = new[] { typeof(IMessage) };
                            var segmentConstructArgs = new object[] { null };
                            var s = (ISegment)reps[j].GetType().GetConstructor(segmentConstructTypes).Invoke(segmentConstructArgs);
                            xp.Parse(s, root);
                            var doc2 = new XmlDocument();
                            var root2 = doc2.CreateElement(s.GetType().FullName, NameSpace);
                            doc2.AppendChild(root2);
                            xp.Encode(s, root2);
                            var out2 = new StringWriter();
                            var ser = XmlWriter.Create(out2);
                            doc.WriteTo(ser);
                            if (out2.ToString().Equals(outRenamed.ToString()))
                            {
                                Console.Out.WriteLine("Re-encode OK");
                            }
                            else
                            {
                                Console.Out.WriteLine(
                                    $"Warning: XML different after parse and re-encode: {Environment.NewLine}{out2}");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SupportClass.WriteStackTrace(e, Console.Error);
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
            return EncodingDetector.IsXmlEncoded(message) ? DefaultEncoding : null;
        }

        /// <summary>
        /// <para>Creates and populates a Message object from an XML Document that contains an XML-encoded HL7 message.</para>
        /// <para>
        /// The easiest way to implement this method for a particular message structure is as follows:
        /// <list type="number">
        /// <item>Create an instance of the Message type you are going to handle with your subclass of
        /// <see cref="XMLParser" /></item>
        /// <item>Go through the given <see cref="XmlDocument"/> and find the <see cref="XmlElement">XmlElements</see>
        /// that represent the top level of each message segment.</item>
        /// <item>For each of these segments, call <see cref="XMLParser.Encode(ISegment, XmlElement, ParserOptions)"/>,
        /// providing the appropriate <see cref="ISegment" /> from your <see cref="IMessage"/> object, and the
        /// corresponding <see cref="XmlElement"/>.</item>
        /// </list>
        /// At the end of this process, your <see cref="IMessage"/> object should be populated with data from the
        /// <see cref="XmlDocument"/>.
        /// </para>
        /// </summary>
        /// <param name="xmlMessage">Xml encoded HL7 parsed into <see cref="XmlDocument"/>.</param>
        /// <param name="version">The name of the HL7 version to which the message belongs (eg "2.5").</param>
        /// <returns>A parsed HL7 message.</returns>
        /// <exception cref="HL7Exception">If the message is not correctly formatted.</exception>
        /// <exception cref="EncodingNotSupportedException">
        /// If the message encoded is not supported by this parser.
        /// </exception>
        public IMessage ParseDocument(XmlDocument xmlMessage, string version)
        {
            return ParseDocument(xmlMessage, version, DefaultParserOptions);
        }

        /// <summary>
        /// <para>Creates and populates a Message object from an XML Document that contains an XML-encoded HL7 message.</para>
        /// <para>
        /// The easiest way to implement this method for a particular message structure is as follows:
        /// <list type="number">
        /// <item>Create an instance of the Message type you are going to handle with your subclass of
        /// <see cref="XMLParser" /></item>
        /// <item>Go through the given <see cref="XmlDocument"/> and find the <see cref="XmlElement">XmlElements</see>
        /// that represent the top level of each message segment.</item>
        /// <item>For each of these segments, call <see cref="XMLParser.Encode(ISegment, XmlElement, ParserOptions)"/>,
        /// providing the appropriate <see cref="ISegment" /> from your <see cref="IMessage"/> object, and the
        /// corresponding <see cref="XmlElement"/>.</item>
        /// </list>
        /// At the end of this process, your <see cref="IMessage"/> object should be populated with data from the
        /// <see cref="XmlDocument"/>.
        /// </para>
        /// </summary>
        /// <param name="xmlMessage">Xml encoded HL7 parsed into <see cref="XmlDocument"/>.</param>
        /// <param name="version">The name of the HL7 version to which the message belongs (eg "2.5").</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <returns>A parsed HL7 message.</returns>
        /// <exception cref="HL7Exception">If the message is not correctly formatted.</exception>
        /// <exception cref="EncodingNotSupportedException">
        /// If the message encoded is not supported by this parser.
        /// </exception>
        public abstract IMessage ParseDocument(XmlDocument xmlMessage, string version, ParserOptions parserOptions);

        /// <summary>
        /// <para>Creates an <see cref="XmlDocument"/> that corresponds to the given <see cref="IMessage"/> object.</para>
        /// <para>If you are implementing this method, you should create an <see cref="XmlDocument"/>, and insert
        /// <see cref="XmlElement">XmlElements</see> into it that correspond to the <see cref="IGroup">IGroups</see> and
        /// <see cref="ISegment">ISegments</see> that belong to the <see cref="IMessage"/> type that your subclass
        /// of <see cref="XMLParser"/> supports. Then, for each segment in the message, call the method
        /// <see cref="XMLParser.Encode(ISegment, XmlElement, ParserOptions)"/> using the <see cref="XmlElement"/> for
        /// that segment and the corresponding <see cref="ISegment" /> object from the given <see cref="IMessage"/>.</para>
        /// </summary>
        /// <param name="source">An <see cref="IMessage"/> object from which to construct an encoded message string.</param>
        /// <returns>An <see cref="XmlDocument"/> representation of the HL7 message.</returns>
        /// <exception cref="HL7Exception">When unable to create/populate the <see cref="XmlDocument"/>.</exception>
        public XmlDocument EncodeDocument(IMessage source)
        {
            return EncodeDocument(source, DefaultParserOptions);
        }

        /// <summary>
        /// <para>Creates an <see cref="XmlDocument"/> that corresponds to the given <see cref="IMessage"/> object.</para>
        /// <para>If you are implementing this method, you should create an <see cref="XmlDocument"/>, and insert
        /// <see cref="XmlElement">XmlElements</see> into it that correspond to the <see cref="IGroup">IGroups</see> and
        /// <see cref="ISegment">ISegments</see> that belong to the <see cref="IMessage"/> type that your subclass
        /// of <see cref="XMLParser"/> supports. Then, for each segment in the message, call the method
        /// <see cref="XMLParser.Encode(ISegment, XmlElement, ParserOptions)"/> using the <see cref="XmlElement"/> for
        /// that segment and the corresponding <see cref="ISegment" /> object from the given <see cref="IMessage"/>.</para>
        /// </summary>
        /// <param name="source">An <see cref="IMessage"/> object from which to construct an encoded message string.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when encoding.</param>
        /// <returns>An <see cref="XmlDocument"/> representation of the HL7 message.</returns>
        /// <exception cref="HL7Exception">When unable to create/populate the <see cref="XmlDocument"/>.</exception>
        public abstract XmlDocument EncodeDocument(IMessage source, ParserOptions parserOptions);

        /// <summary>
        /// Populates the given <see cref="ISegment"/> object with data from the given <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="segmentObject">The <see cref="ISegment"/> to parse into.</param>
        /// <param name="segmentElement">The <see cref="XmlElement"/> to be parse.</param>
        /// <exception cref="HL7Exception">
        /// If the <see cref="XmlElement"/> does not have the correct name and structure for the given
        /// <see cref="ISegment"/>, or if there is an error while setting individual field values.
        /// </exception>
        public virtual void Parse(ISegment segmentObject, XmlElement segmentElement)
        {
            Parse(segmentObject, segmentElement, DefaultParserOptions);
        }

        /// <summary>
        /// Populates the given <see cref="ISegment"/> object with data from the given <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="segmentObject">The <see cref="ISegment"/> to parse into.</param>
        /// <param name="segmentElement">The <see cref="XmlElement"/> to be parse.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <exception cref="HL7Exception">
        /// If the <see cref="XmlElement"/> does not have the correct name and structure for the given
        /// <see cref="ISegment"/>, or if there is an error while setting individual field values.
        /// </exception>
        /// <exception cref="HL7Exception">
        /// If any of the <see cref="XmlNode.ChildNodes"/> of <paramref name="segmentElement"/> have an invalid namespace.
        /// </exception>
        public virtual void Parse(ISegment segmentObject, XmlElement segmentElement, ParserOptions parserOptions)
        {
            parserOptions ??= DefaultParserOptions;

            var done = new HashSet<string>(StringComparer.Ordinal);
            var children = segmentElement.ChildNodes;

            for (var i = 0; i < children.Count; i++)
            {
                var elementName = children[i].LocalName;
                if (children[i].NodeType == XmlNodeType.Element && !done.Contains(elementName))
                {
                    AssertNamespaceUri(children[i].NamespaceURI);

                    done.Add(elementName);

                    var index = elementName.IndexOf('.');
                    if (index >= 0 && elementName.Length > index)
                    {
                        // properly formatted element
                        var fieldNumString = elementName.Substring(index + 1);
                        var fieldNum = int.Parse(fieldNumString);
                        ParseReps(segmentObject, segmentElement, elementName, fieldNum, parserOptions);
                    }
                    else
                    {
                        Log.Debug(
                            $"Child of segment {segmentObject.GetStructureName()} doesn't look like a field: {elementName}");
                    }
                }
            }

            // set data type of OBX-5
            if (segmentObject.GetType().FullName.IndexOf("OBX", StringComparison.Ordinal) >= 0)
            {
                Varies.FixOBX5(segmentObject, Factory, parserOptions);
            }

            // TODO set data type of MFE-4
        }

        /// <summary>
        /// Populates the given <see cref="XmlElement"/> with data from the given <see cref="ISegment"/>, by inserting
        /// <see cref="XmlElement">XmlElements</see> corresponding to the <see cref="ISegment">Segment's</see> fields,
        /// their components, etc.
        /// </summary>
        /// <param name="segmentObject">The <see cref="ISegment"/> to be encoded.</param>
        /// <param name="segmentElement">The <see cref="XmlElement"/> to encode into.</param>
        /// <returns><see langword="true"/> if there is at least one data value in the <see cref="ISegment"/>.</returns>
        /// <exception cref="HL7Exception">If an error occurred while encoding.</exception>
        public virtual bool Encode(ISegment segmentObject, XmlElement segmentElement)
        {
            return Encode(segmentObject, segmentElement, DefaultParserOptions);
        }

        /// <summary>
        /// Populates the given <see cref="XmlElement"/> with data from the given <see cref="ISegment"/>, by inserting
        /// <see cref="XmlElement">XmlElements</see> corresponding to the <see cref="ISegment">Segment's</see> fields,
        /// their components, etc.
        /// </summary>
        /// <param name="segmentObject">The <see cref="ISegment"/> to be encoded.</param>
        /// <param name="segmentElement">The <see cref="XmlElement"/> to encode into.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when encoding.</param>
        /// <returns><see langword="true"/> if there is at least one data value in the <see cref="ISegment"/>.</returns>
        /// <exception cref="HL7Exception">If an error occurred while encoding.</exception>
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
                    var newNode = segmentElement.OwnerDocument.CreateElement(name, NameSpace);

                    var componentHasValue = Encode(reps[j], newNode, parserOptions);
                    if (!componentHasValue)
                    {
                        continue;
                    }

                    if (_includeLongNameInEncodedXML && reps[j] is AbstractType rep)
                    {
                        newNode.SetAttribute("LongName", rep.Description);
                    }

                    try
                    {
                        segmentElement.AppendChild(newNode);
                    }
                    catch (Exception e)
                    {
                        throw new HL7Exception($"DOMException encoding Segment: ", ErrorCode.APPLICATION_INTERNAL_ERROR, e);
                    }

                    hasValue = true;
                }
            }

            return hasValue;
        }

        /// <summary>
        /// Populates the given <see cref="IType"/> object with data from the given <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="datatypeObject">The <see cref="IType"/> to parse into.</param>
        /// <param name="datatypeElement">The <see cref="XmlElement"/> to be parsed.</param>
        /// <exception cref="DataTypeException">if the data did not match the expected type rules.</exception>
        public virtual void Parse(IType datatypeObject, XmlElement datatypeElement)
        {
            Parse(datatypeObject, datatypeElement, DefaultParserOptions);
        }

        /// <summary>
        /// Populates the given <see cref="IType"/> object with data from the given <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="datatypeObject">The <see cref="IType"/> to parse into.</param>
        /// <param name="datatypeElement">The <see cref="XmlElement"/> to be parsed.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <exception cref="DataTypeException">if the data did not match the expected type rules.</exception>
        public virtual void Parse(IType datatypeObject, XmlElement datatypeElement, ParserOptions parserOptions)
        {
            // TODO: consider replacing with a switch statement
            if (datatypeObject is Varies varies)
            {
                ParseVaries(varies, datatypeElement, parserOptions);
            }
            else if (datatypeObject is IPrimitive primitive)
            {
                ParsePrimitive(primitive, datatypeElement, parserOptions);
            }
            else if (datatypeObject is IComposite composite)
            {
                ParseComposite(composite, datatypeElement, parserOptions);
            }
        }

        /// <summary> <para>Returns a minimal amount of data from a message string, including only the
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
        /// avoiding the condition that caused the original error.</para>
        /// </summary>
        public override ISegment GetCriticalResponseData(string message)
        {
            var version = GetVersion(message);
            var criticalData = MakeControlMSH(version, Factory);

            Terser.Set(criticalData, 1, 0, 1, 1, ParseLeaf(message, "MSH.1", 0));
            Terser.Set(criticalData, 2, 0, 1, 1, ParseLeaf(message, "MSH.2", 0));
            Terser.Set(criticalData, 10, 0, 1, 1, ParseLeaf(message, "MSH.10", 0));
            var procID = ParseLeaf(message, "MSH.11", 0);
            if (string.IsNullOrEmpty(procID))
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
        /// <see langword="true"/> if whitespaces should not be removed from node content; otherwise, <see langword="false"/>.
        /// </returns>
        protected internal virtual bool KeepAsOriginal(XmlNode node)
        {
            return KeepAsOriginal(node, DefaultParserOptions);
        }

        /// <summary>
        /// Checks if a node content should be kept as original (ie.: whitespaces won't be removed).
        /// </summary>
        /// <param name="node">The target node.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <returns>
        /// <see langword="true"/> if whitespaces should not be removed from node content; otherwise, <see langword="false"/>.
        /// </returns>
        protected internal virtual bool KeepAsOriginal(XmlNode node, ParserOptions parserOptions)
        {
            return parserOptions.DisableWhitespaceTrimmingOnAllXmlNodes
                   || parserOptions.XmlNodeNamesToDisableWhitespaceTrimming.Contains(node.LocalName)
                   || KeepAsOriginalNodes.Contains(node.LocalName, StringComparer.Ordinal);
        }

        /// <summary>
        /// Validates the namespace.
        /// </summary>
        /// <param name="namespace">Namespace to assert.</param>
        /// <exception cref="HL7Exception">If provided namespace is not valid.</exception>
        protected internal virtual void AssertNamespaceUri(string @namespace)
        {
            if (!NameSpace.Equals(@namespace, StringComparison.Ordinal))
            {
                throw new HL7Exception($"Namespace URI must be {NameSpace}");
            }
        }

        /// <summary>
        /// Removes all unnecessary whitespace from the given String (intended to be used with Primitive values).
        /// This includes leading and trailing whitespace, and repeated space characters. Carriage returns,
        /// line feeds, and tabs are replaced with spaces.
        /// </summary>
        protected internal virtual string RemoveWhitespace(string input)
        {
            input = input.Replace('\r', ' ')
                .Replace('\n', ' ')
                .Replace('\t', ' ');

            var repeatedSpacesExist = true;
            while (repeatedSpacesExist)
            {
                var loc = input.IndexOf("  ", StringComparison.Ordinal);
                if (loc < 0)
                {
                    repeatedSpacesExist = false;
                }
                else
                {
                    var buf = new StringBuilder();
                    buf.Append(input.Substring(0, loc - 0));
                    buf.Append(" ");
                    buf.Append(input.Substring(loc + 2));
                    input = buf.ToString();
                }
            }

            return input.Trim();
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
                doc.LoadXml(message);

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
        /// <see cref="EncodeDocument(IMessage, ParserOptions)"/> in order to obtain <see cref="XmlDocument"/> object
        /// representation of the Message, then serializes it to a String.
        /// </summary>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        protected internal override string DoEncode(IMessage source, ParserOptions parserOptions)
        {
            Log.Info("XML-Encoding a GenericMessage is not covered by the specification.");

            var doc = EncodeDocument(source, parserOptions);

            var stringBuilder = new StringBuilder();
            var utf8StringWriter = new StringWriterWithEncoding(stringBuilder, Encoding.UTF8);
            var xmlWriterSettings = new XmlWriterSettings { Indent = parserOptions.PrettyPrintEncodedXml, CloseOutput = true };

            using (var writer = XmlWriter.Create(utf8StringWriter, xmlWriterSettings))
            {
                doc.WriteTo(writer);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// <para>Attempts to retrieve the value of a leaf tag without using DOM or SAX.</para>
        /// <para>This method searches the given message string for the given tag name, and returns
        /// everything after the given tag and before the start of the next tag.</para>
        /// <para>Whitespace is stripped.</para>
        /// </summary>
        /// <remarks>
        /// This is intended only for lead nodes, as the value is considered to
        /// end at the start of the next tag, regardless of whether it is the matching end
        /// tag or some other nested tag.
        /// </remarks>
        /// <param name="message">a string message in XML form.</param>
        /// <param name="tagName">the name of the XML tag, e.g. "MSA.2".</param>
        /// <param name="startAt">the character location at which to start searching.</param>
        /// <exception cref="HL7Exception">Thrown if the tag can not be found.</exception>
        protected internal virtual string ParseLeaf(string message, string tagName, int startAt)
        {
            var prefix = string.Empty;
            var matches = NameSpaceRegex.Match(message);
            if (matches.Success)
            {
                var nameSpace = matches.Groups[1].Value;
                if (!string.IsNullOrEmpty(nameSpace))
                {
                    prefix = nameSpace.Substring(1) + ":";
                }
            }

            var tagStart = message.IndexOf($"<{prefix}{tagName}", startAt, StringComparison.Ordinal);
            if (tagStart < 0)
            {
                tagStart = message.IndexOf($"<{prefix}{tagName.ToUpperInvariant()}", startAt, StringComparison.Ordinal);
            }

            if (tagStart < 0)
            {
                throw new HL7Exception(
                    $"Couldn't find {tagName} in message beginning: {message.Substring(0, Math.Min(150, message.Length) - 0)}",
                    ErrorCode.REQUIRED_FIELD_MISSING);
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

            // Escape codes, as defined at http://hdf.ncsa.uiuc.edu/HDF5/XML/xml_escape_chars.htm
            value = Regex.Replace(value, "&quot;", "\"");
            value = Regex.Replace(value, "&apos;", "'");
            value = Regex.Replace(value, "&amp;", "&");
            value = Regex.Replace(value, "&lt;", "<");
            value = Regex.Replace(value, "&gt;", ">");

            return value;
        }

        /// <summary>
        /// Returns the expected XML element name for the given child of the given Segment.
        /// </summary>
        private static string MakeElementName(ISegment s, int child)
        {
            return $"{s.GetStructureName()}.{child}";
        }

        /// <summary>
        /// Returns the expected XML element name for the given child of the given Composite.
        /// </summary>
        private static string MakeElementName(IComposite composite, int child)
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
            if (datatypeObject is Varies varies)
            {
                hasData = EncodeVaries(varies, datatypeElement, parserOptions);
            }
            else if (datatypeObject is IPrimitive primitive)
            {
                hasData = EncodePrimitive(primitive, datatypeElement);
            }
            else if (datatypeObject is IComposite composite)
            {
                hasData = EncodeComposite(composite, datatypeElement, parserOptions);
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
            if (datatypeObject.Data is not null)
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
            var value = datatypeObject.Value;
            var hasValue = !string.IsNullOrEmpty(value);

            if (hasValue)
            {
                try
                {
                    var encoding = EncodingCharacters.FromMessage(datatypeObject.Message);
                    int pos;
                    var oldPos = 0;
                    var escaping = false;

                    // Find next escape character
                    while ((pos = value.IndexOf(encoding.EscapeCharacter, oldPos)) >= 0)
                    {
                        // string until next escape character
                        var v = value.Substring(oldPos, pos - oldPos);
                        if (!escaping)
                        {
                            // currently in "text mode", so create textnode from it
                            if (v.Length > 0)
                            {
                                datatypeElement.AppendChild(datatypeElement.OwnerDocument.CreateTextNode(v));
                            }

                            escaping = true;
                        }
                        else
                        {
                            if (v.StartsWith(".", StringComparison.Ordinal)
                                || "H".Equals(v, StringComparison.Ordinal)
                                || "N".Equals(v, StringComparison.Ordinal))
                            {
                                // currently in "escape mode", so create escape element from it
                                var escape = datatypeElement.OwnerDocument.CreateElement(EscapeNodeName, NameSpace);
                                escape.SetAttribute(EscapeAttrName, v);
                                datatypeElement.AppendChild(escape);
                                escaping = false;
                            }
                            else
                            {
                                // no proper escape sequence, assume text
                                datatypeElement.AppendChild(
                                    datatypeElement.OwnerDocument
                                        .CreateTextNode(encoding.EscapeCharacter + v));
                            }
                        }

                        oldPos = pos + 1;
                    }

                    // create text from the remainder
                    if (oldPos <= value.Length)
                    {
                        var stringBuilder = new StringBuilder();

                        // If we are in escaping mode, there appears no closing escape character,
                        // so we treat the string as text
                        if (escaping)
                        {
                            stringBuilder.Append(encoding.EscapeCharacter);
                        }

                        stringBuilder.Append(value.Substring(oldPos));
                        datatypeElement.AppendChild(
                            datatypeElement.OwnerDocument.CreateTextNode(stringBuilder.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    throw new DataTypeException("Exception encoding Primitive: ", ex);
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
                var newNode = datatypeElement.OwnerDocument.CreateElement(name, NameSpace);

                var componentHasValue = Encode(components[i], newNode, parserOptions);
                if (!componentHasValue)
                {
                    continue;
                }

                if (_includeLongNameInEncodedXML && components[i] is AbstractType component)
                {
                    newNode.SetAttribute("LongName", component.Description);
                }

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

            return hasValue;
        }

        private void ParseReps(ISegment segmentObject, XmlElement segmentElement, string fieldName, int fieldNum, ParserOptions parserOptions)
        {
            var reps = segmentElement.GetElementsByTagName(fieldName, NameSpace);
            for (var i = 0; i < reps.Count; i++)
            {
                Parse(segmentObject.GetField(fieldNum, i), (XmlElement)reps[i], parserOptions);
            }
        }

        /// <summary>
        /// Returns <see langword="true"/> if the <paramref name="element"/> provided has any children which are
        /// are also of type <see cref="XmlNodeType.Element"/>.
        /// </summary>
        /// <param name="element">Element to test.</param>
        /// <returns></returns>
        private bool HasChildElement(XmlElement element)
        {
            var children = element.ChildNodes;
            var hasElement = false;
            var i = 0;
            while (i < children.Count && !hasElement)
            {
                if (children[i].NodeType == XmlNodeType.Element
                    && !EscapeNodeName.Equals(children[i].Name, StringComparison.Ordinal))
                {
                    hasElement = true;
                }

                i++;
            }

            return hasElement;
        }

        /// <summary>
        /// Parses an <see cref="XmlElement"/> into a <see cref="Varies"/> by determining whether the element is
        /// <see cref="IPrimitive"/> or <see cref="IComposite"/>, assigning the <see cref="Varies.Data">Varies.Data</see>
        /// with a new <see cref="GenericPrimitive"/> or <see cref="GenericComposite"/> as appropriate, and then
        /// calling parse again with this newly assigned <see cref="Varies.Data">Varies.Data</see>.
        /// </summary>
        /// <param name="datatypeObject">The <see cref="Varies"/> to parse into.</param>
        /// <param name="datatypeElement">The <see cref="XmlElement"/> to be parsed.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <exception cref="DataTypeException">if the data did not match the expected type rules.</exception>
        private void ParseVaries(Varies datatypeObject, XmlElement datatypeElement, ParserOptions parserOptions)
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

            Parse(datatypeObject.Data, datatypeElement, parserOptions);
        }

        /// <summary>
        /// Populates the given <see cref="IPrimitive"/> object with data from the given <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="datatypeObject">The <see cref="IPrimitive"/> to parse into.</param>
        /// <param name="datatypeElement">The <see cref="XmlElement"/> to be parsed.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <exception cref="HL7Exception">
        /// If any of the <see cref="XmlNode.ChildNodes">XmlElement.ChildNodes</see> of type
        /// <see cref="XmlNodeType.Element"/> which should be escaped from <paramref name="datatypeElement"/>
        /// have an invalid namespace.
        /// </exception>
        private void ParsePrimitive(IPrimitive datatypeObject, XmlElement datatypeElement, ParserOptions parserOptions)
        {
            var children = datatypeElement.ChildNodes;
            var builder = new StringBuilder();

            for (var childIndex = 0; childIndex < children.Count; childIndex++)
            {
                var child = children[childIndex];
                try
                {
                    if (child.NodeType == XmlNodeType.Text)
                    {
                        var value = child.Value;
                        if (!string.IsNullOrEmpty(value))
                        {
                            var valueToAppend = KeepAsOriginal(child.ParentNode, parserOptions)
                                ? value
                                : RemoveWhitespace(value);

                            builder.Append(valueToAppend);
                        }
                    }
                    else if (child.NodeType == XmlNodeType.Element && EscapeNodeName.Equals(child.LocalName))
                    {
                        AssertNamespaceUri(child.NamespaceURI);

                        var encoding = EncodingCharacters.FromMessage(datatypeObject.Message);
                        var element = (XmlElement)child;
                        var attribute = element.GetAttribute(EscapeAttrName).Trim();

                        if (!string.IsNullOrEmpty(attribute))
                        {
                            builder.Append(encoding.EscapeCharacter)
                                .Append(attribute)
                                .Append(encoding.EscapeCharacter);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Error parsing primitive value from TEXT_NODE", ex);
                }
            }

            datatypeObject.Value = builder.ToString();
        }

        /// <summary>
        /// Populates the provided <see cref="IComposite"/> by looping through it's <see cref="IComposite.Components"/>, finding corresponding
        /// <see cref="XmlElement">XmlElements</see> among the children of the given <see cref="XmlElement"/>, and
        /// calling <see cref="Parse(IType, XmlElement, ParserOptions)"/> for each.
        /// </summary>
        /// <param name="datatypeObject">The <see cref="IComposite"/> to parse into.</param>
        /// <param name="datatypeElement">The <see cref="XmlElement"/> to be parsed.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <exception cref="HL7Exception">
        /// If any of the <see cref="XmlNode.ChildNodes">XmlElement.ChildNodes</see> of type
        /// <see cref="XmlNodeType.Element"/> which should be escaped from <paramref name="datatypeElement"/>
        /// have an invalid namespace.
        /// </exception>
        private void ParseComposite(IComposite datatypeObject, XmlElement datatypeElement, ParserOptions parserOptions)
        {
            if (datatypeObject is GenericComposite)
            {
                // elements won't be named GenericComposite.x
                var children = datatypeElement.ChildNodes;
                var componentIndex = 0;
                for (var i = 0; i < children.Count; i++)
                {
                    if (children[i].NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    var nextElement = (XmlElement)children[i];
                    AssertNamespaceUri(nextElement.NamespaceURI);

                    var localName = nextElement.LocalName;
                    var dotPosition = localName.IndexOf(".", StringComparison.Ordinal);
                    if (dotPosition > -1)
                    {
                        componentIndex = int.Parse(localName.Substring(dotPosition + 1)) - 1;
                    }
                    else
                    {
                        Log.Debug(
                            $"Datatype element {datatypeElement.LocalName} doesn't have a valid numbered name, using default index of {componentIndex}");
                    }

                    var nextComponent = datatypeObject[componentIndex];

                    Parse(nextComponent, nextElement, parserOptions);
                    componentIndex++;
                }
            }
            else
            {
                var children = datatypeObject.Components;
                for (var i = 0; i < children.Length; i++)
                {
                    var matchingElements = datatypeElement.GetElementsByTagName(MakeElementName(datatypeObject, i + 1), NameSpace);
                    if (matchingElements.Count > 0)
                    {
                        // components don't repeat - use 1st
                        Parse(children[i], (XmlElement)matchingElements[0], parserOptions);
                    }
                }

                var nextExtraComponent = 0;
                bool foundExtraComponent;
                do
                {
                    foundExtraComponent = false;
                    var matchingElements =
                        datatypeElement.GetElementsByTagName(
                            MakeElementName(datatypeObject, children.Length + nextExtraComponent + 1), NameSpace);

                    if (matchingElements.Count > 0)
                    {
                        var extraComponent = datatypeObject.ExtraComponents.GetComponent(nextExtraComponent);
                        Parse(extraComponent, (XmlElement)matchingElements[0], parserOptions);
                        foundExtraComponent = true;
                    }

                    nextExtraComponent++;
                }
                while (foundExtraComponent);
            }
        }

        private class AnonymousClassXMLParser : XMLParser
        {
            public AnonymousClassXMLParser()
            {
            }

            public AnonymousClassXMLParser(IModelClassFactory factory)
                : base(factory)
            {
            }

            public override IMessage ParseDocument(XmlDocument xmlMessage, string version, ParserOptions parserOptions)
            {
                return null;
            }

            public override XmlDocument EncodeDocument(IMessage source, ParserOptions parserOptions)
            {
                return null;
            }

            public override void Parse(IMessage message, string @string, ParserOptions parserOptions)
            {
            }

            public override string GetVersion(string message)
            {
                return null;
            }

            protected internal override string DoEncode(IMessage source, ParserOptions parserOptions)
            {
                return null;
            }
        }

        private sealed class StringWriterWithEncoding : StringWriter
        {
            public StringWriterWithEncoding(StringBuilder builder, Encoding encoding)
                : base(builder)
            {
                this.Encoding = encoding;
            }

            public override Encoding Encoding { get; }
        }
    }
}