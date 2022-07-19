namespace NHapi.Base.Parser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    using NHapi.Base.Log;
    using NHapi.Base.Model;

    /// <summary>
    /// A default XMLParser. This class assigns segment elements (in an XML-encoded message)
    /// to Segment objects (in a Message object) using the name of a segment and the names
    /// of any groups in which the segment is nested. The names of group classes must correspond
    /// to the names of group elements (they must be identical except that a dot in the element
    /// name, following the message name, is replaced with an underscore, in order to constitute a
    /// valid class name).
    /// </summary>
    /// <remarks>
    /// At the time of writing, the group names in the XML spec are changing. Many of the group
    /// names have been automatically generated based on the group contents. However, these automatic
    /// names are gradually being replaced with manually assigned names. This process is expected to
    /// be complete by November 2002. As a result, mismatches are likely. Messages could be
    /// transformed prior to parsing (using XSLT) as a work-around. Alternatively the group class names
    /// could be changed to reflect updates in the XML spec.  Ultimately, HAPI group classes will be
    /// changed to correspond with the official group names, once these are all assigned.
    /// </remarks>
    /// <author>Bryan Tripp.</author>
    public class DefaultXMLParser : XMLParser
    {
        private static readonly IHapiLog Log = HapiLogFactory.GetHapiLog(typeof(DefaultXMLParser));

        private static readonly HashSet<string> ForceGroupNames = new HashSet<string> { "DIET" };

        /// <summary>Creates a new instance of DefaultXMLParser. </summary>
        public DefaultXMLParser()
        {
        }

        /// <summary>Creates a new instance of DefaultXMLParser. </summary>
        public DefaultXMLParser(IModelClassFactory modelClassFactory)
            : base(modelClassFactory)
        {
        }

        /// <summary>Test harness. </summary>
        [STAThread]
        public static new void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Out.WriteLine("Usage: DefaultXMLParser pipe_encoded_file");
                Environment.Exit(1);
            }

            // read and parse message from file
            try
            {
                var messageFile = new FileInfo(args[0]);
                var fileLength = SupportClass.FileLength(messageFile);
                var r = new StreamReader(messageFile.FullName, Encoding.Default);
                var buffer = new char[fileLength];
                Console.Out.WriteLine(
                    $"Reading message file ... {r.Read(buffer, 0, buffer.Length)} of {fileLength} chars");
                r.Close();
                var messString = Convert.ToString(buffer);

                ParserBase inParser;
                ParserBase outParser;
                var pipeParser = new PipeParser();
                XMLParser xmlParser = new DefaultXMLParser();
                Console.Out.WriteLine($"Encoding: {pipeParser.GetEncoding(messString)}");

                if (EncodingDetector.IsEr7Encoded(messString))
                {
                    inParser = pipeParser;
                    outParser = xmlParser;
                }
                else if (EncodingDetector.IsXmlEncoded(messString))
                {
                    inParser = xmlParser;
                    outParser = pipeParser;
                }
                else
                {
                    throw new HL7Exception("Message encoding is not recognized");
                }

                var mess = inParser.Parse(messString);
                Console.Out.WriteLine($"Got message of type {mess.GetType().FullName}");

                var otherEncoding = outParser.Encode(mess);
                Console.Out.WriteLine(otherEncoding);
            }
            catch (Exception e)
            {
                SupportClass.WriteStackTrace(e, Console.Error);
            }
        }

        /// <inheritdoc/>
        public override XmlDocument EncodeDocument(IMessage source, ParserOptions parserOptions)
        {
            var messageClassName = source.GetType().FullName;
            var messageName = messageClassName!.Substring(messageClassName.LastIndexOf('.') + 1);

            if (source is GenericMessage)
            {
                messageName = messageName.Replace("+", string.Empty);
            }

            XmlDocument doc;
            try
            {
                doc = new XmlDocument();
                var root = doc.CreateElement(messageName, NameSpace);
                doc.AppendChild(root);
            }
            catch (Exception e)
            {
                throw new HL7Exception(
                    $"Can't create XML document - {e.GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR,
                    e);
            }

            Encode(source, doc.DocumentElement, parserOptions);
            return doc;
        }

        /// <inheritdoc/>
        public override IMessage ParseDocument(XmlDocument xmlMessage, string version, ParserOptions parserOptions)
        {
            if (xmlMessage is null)
            {
                throw new ArgumentNullException(nameof(xmlMessage));
            }

            parserOptions ??= DefaultParserOptions;

            AssertNamespaceUri(xmlMessage.DocumentElement!.NamespaceURI);

            var messageName = xmlMessage.DocumentElement!.LocalName;
            var message = InstantiateMessage(messageName, version, true);
            Parse(message, xmlMessage.DocumentElement, parserOptions);
            return message;
        }

        // TODO: should this be public?
        // https://github.com/nHapiNET/nHapi/issues/399
        /// <inheritdoc />
        public override void Parse(IMessage message, string @string, ParserOptions parserOptions)
        {
            parserOptions ??= DefaultParserOptions;

            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(new StringReader(@string));

                Parse(message, xmlDocument.DocumentElement, parserOptions);
            }
            catch (XmlException e)
            {
                throw new HL7Exception("XmlException parsing XML", ErrorCode.APPLICATION_INTERNAL_ERROR, e);
            }
        }

        /// <summary>
        /// Given the name of a message and a Group class, returns the corresponding group element name in an
        /// XML-encoded message. This is the message name and group name separated by a dot. For example,
        /// ADT_A01.INSURANCE.
        /// <para>
        /// If it looks like a segment name (ie: has 3 characters), no change is made.
        /// </para>
        /// </summary>
        protected internal static string MakeGroupElementName(string messageName, string className)
        {
            string ret;

            if (className.Length > 4 || ForceGroupNames.Contains(className))
            {
                var elementName = new StringBuilder();
                elementName.Append(messageName);
                elementName.Append('.');
                elementName.Append(className);
                ret = elementName.ToString();
            }
            else if (className.Length == 4)
            {
                ret = className.Substring(0, 3 - 0);
            }
            else
            {
                ret = className;
            }

            return ret;
        }

        /// <summary> Populates the given group object with data from the given group element, ignoring
        /// any unrecognized nodes.
        /// </summary>
        private void Parse(IGroup groupObject, XmlElement groupElement, ParserOptions parserOptions)
        {
            var childNames = groupObject.Names;
            var messageName = groupObject.Message.GetStructureName();

            var allChildNodes = groupElement.ChildNodes;
            var unparsedElementList = new List<string>();
            for (var i = 0; i < allChildNodes.Count; i++)
            {
                var node = allChildNodes[i];
                var name = node.LocalName;
                if (node.NodeType == XmlNodeType.Element && !unparsedElementList.Contains(name))
                {
                    AssertNamespaceUri(node.NamespaceURI);
                    unparsedElementList.Add(name);
                }
            }

            // we're not too fussy about order here (all occurrences get parsed as repetitions) ...
            foreach (var nextChildName in childNames)
            {
                var childName = nextChildName;
                if (groupObject.IsGroup(nextChildName))
                {
                    childName = MakeGroupElementName(groupObject.Message.GetStructureName(), nextChildName);
                }

                unparsedElementList.Remove(childName);

                // 4 char segment names are second occurrences of a segment within a single message
                // structure. e.g. the second PID segment in an A17 patient swap message is known
                // to nhapi's code representation as PID2
                if (nextChildName.Length == 4 && char.IsDigit(nextChildName[3]))
                {
                    Log.Trace($"Skipping rep segment: {nextChildName}");
                }
                else
                {
                    ParseReps(groupElement, groupObject, messageName, nextChildName, nextChildName, parserOptions);
                }
            }

            foreach (var segmentName in unparsedElementList)
            {
                var segmentIndexName = groupObject.AddNonstandardSegment(segmentName);
                ParseReps(groupElement, groupObject, messageName, segmentName, segmentIndexName, parserOptions);
            }
        }

        /// <summary>
        /// Copies data from a <see cref="IGroup"/> object into the corresponding <paramref name="groupElement"/>,
        /// creating any necessary child nodes.
        /// </summary>
        /// <param name="groupObject">The <see cref="IGroup"/> to encode.</param>
        /// <param name="groupElement">The <see cref="XmlElement"/> to encode into.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when encoding.</param>
        /// <exception cref="HL7Exception">If unable to encode <paramref name="groupObject"/>.</exception>
        private void Encode(IGroup groupObject, XmlElement groupElement, ParserOptions parserOptions)
        {
            var childNames = groupObject.Names;
            var messageName = groupObject.Message.GetStructureName();

            try
            {
                foreach (var name in childNames)
                {
                    var reps = groupObject.GetAll(name);
                    foreach (var rep in reps)
                    {
                        var elementName = MakeGroupElementName(messageName, name);
                        var childElement =
                            groupElement.OwnerDocument!.CreateElement(elementName, NameSpace);

                        groupElement.AppendChild(childElement);

                        if (rep is IGroup group)
                        {
                            Encode(group, childElement, parserOptions);
                        }
                        else if (rep is ISegment segment)
                        {
                            Encode(segment, childElement, parserOptions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HL7Exception(
                    "Can't encode group " + groupObject.GetType().FullName,
                    ErrorCode.APPLICATION_INTERNAL_ERROR,
                    ex);
            }
        }

        // param childIndexName may have an integer on the end if >1 sibling with same name (e.g. NTE2)
        private void ParseReps(
            XmlElement groupElement,
            IGroup groupObject,
            string messageName,
            string childName,
            string childIndexName,
            ParserOptions parserOptions)
        {
            var groupElementName = MakeGroupElementName(messageName, childName);
            var reps = GetChildElementsByTagName(groupElement, groupElementName);
            Log.Debug($"# of elements matching {MakeGroupElementName(messageName, childName)}: {reps.Count}");

            if (groupObject.IsRepeating(childIndexName))
            {
                for (var i = 0; i < reps.Count; i++)
                {
                    ParseRep(reps[i], groupObject.GetStructure(childIndexName, i), parserOptions);
                }
            }
            else
            {
                if (reps.Count > 0)
                {
                    ParseRep(reps[0], groupObject.GetStructure(childIndexName, 0), parserOptions);
                }

                if (reps.Count > 1)
                {
                    string newIndexName;
                    var i = 1;
                    try
                    {
                        for (i = 1; i < reps.Count; i++)
                        {
                            newIndexName = childName + (i + 1);
                            var structure = groupObject.GetStructure(newIndexName);
                            ParseRep(reps[i], structure, parserOptions);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Info("Issue Parsing", ex);
                        newIndexName = groupObject.AddNonstandardSegment(childName);
                        for (var j = i; j < reps.Count; j++)
                        {
                            ParseRep(reps[i], groupObject.GetStructure(newIndexName, j - i), parserOptions);
                        }
                    }
                }
            }
        }

        private void ParseRep(XmlElement theElem, IStructure theObj, ParserOptions parserOptions)
        {
            if (theObj is IGroup group)
            {
                Parse(group, theElem, parserOptions);
            }
            else if (theObj is ISegment segment)
            {
                Parse(segment, theElem, parserOptions);
            }

            Log.Debug("Parsed element: " + theElem.Name);
        }

        // includes direct children only
        private IList<XmlElement> GetChildElementsByTagName(XmlElement theElement, string theName)
        {
            var result = new List<XmlElement>(10);
            var children = theElement.ChildNodes;

            for (var i = 0; i < children.Count; i++)
            {
                var child = children[i];
                if (child.NodeType != XmlNodeType.Element || !child.LocalName.Equals(theName, StringComparison.Ordinal))
                {
                    continue;
                }

                AssertNamespaceUri(child.NamespaceURI);
                result.Add((XmlElement)child);
            }

            return result;
        }
    }
}