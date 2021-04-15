namespace NHapi.Base.Parser
{
    using System;
    using System.Collections;
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
        private static readonly IHapiLog Log;

        static DefaultXMLParser()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(DefaultXMLParser));
        }

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
                var cbuf = new char[(int)fileLength];
                Console.Out.WriteLine("Reading message file ... " + r.Read((char[])cbuf, 0, cbuf.Length) + " of " + fileLength +
                                             " chars");
                r.Close();
                var messString = Convert.ToString(cbuf);

                ParserBase inParser = null;
                ParserBase outParser = null;
                var pp = new PipeParser();
                XMLParser xp = new DefaultXMLParser();
                Console.Out.WriteLine("Encoding: " + pp.GetEncoding(messString));
                if (pp.GetEncoding(messString) != null)
                {
                    inParser = pp;
                    outParser = xp;
                }
                else if (xp.GetEncoding(messString) != null)
                {
                    inParser = xp;
                    outParser = pp;
                }

                var mess = inParser.Parse(messString);
                Console.Out.WriteLine("Got message of type " + mess.GetType().FullName);

                var otherEncoding = outParser.Encode(mess);
                Console.Out.WriteLine(otherEncoding);
            }
            catch (Exception e)
            {
                SupportClass.WriteStackTrace(e, Console.Error);
            }
        }

        /// <summary> <p>Creates an XML Document that corresponds to the given Message object. </p>
        /// <p>If you are implementing this method, you should create an XML Document, and insert XML Elements
        /// into it that correspond to the groups and segments that belong to the message type that your subclass
        /// of XMLParser supports.  Then, for each segment in the message, call the method
        /// <code>encode(Segment segmentObject, Element segmentElement)</code> using the Element for
        /// that segment and the corresponding Segment object from the given Message.</p>
        /// </summary>
        public override XmlDocument EncodeDocument(IMessage source)
        {
            var messageClassName = source.GetType().FullName;
            var messageName = messageClassName.Substring(messageClassName.LastIndexOf('.') + 1);
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                var root = doc.CreateElement(messageName);
                doc.AppendChild(root);
            }
            catch (Exception e)
            {
                throw new HL7Exception(
                    "Can't create XML document - " + e.GetType().FullName,
                    ErrorCode.APPLICATION_INTERNAL_ERROR,
                    e);
            }

            Encode(source, (XmlElement)doc.DocumentElement);
            return doc;
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
        /// <summary>     is not supported by this parser.
        /// </summary>
        public override IMessage ParseDocument(XmlDocument xmlMessage, string version)
        {
            var messageName = xmlMessage.DocumentElement.Name;
            var message = InstantiateMessage(messageName, version, true);
            Parse(message, xmlMessage.DocumentElement);
            return message;
        }

        /// <inheritdoc />
        public override void Parse(IMessage message, string @string)
        {
            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(new StringReader(@string));

                Parse(message, xmlDocument.DocumentElement);
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
            string ret = null;

            if (className.Length > 4)
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
        private void Parse(IGroup groupObject, XmlElement groupElement)
        {
            var childNames = groupObject.Names;
            var messageName = groupObject.Message.GetStructureName();

            var allChildNodes = groupElement.ChildNodes;
            var unparsedElementList = new ArrayList();
            for (var i = 0; i < allChildNodes.Count; i++)
            {
                var node = allChildNodes.Item(i);
                var name = node.Name;
                if (Convert.ToInt16(node.NodeType) == (short)XmlNodeType.Element && !unparsedElementList.Contains(name))
                {
                    unparsedElementList.Add(name);
                }
            }

            // we're not too fussy about order here (all occurrences get parsed as repetitions) ...
            for (var i = 0; i < childNames.Length; i++)
            {
                SupportClass.ICollectionSupport.Remove(unparsedElementList, childNames[i]);
                ParseReps(groupElement, groupObject, messageName, childNames[i], childNames[i]);
            }

            for (var i = 0; i < unparsedElementList.Count; i++)
            {
                var segName = (string)unparsedElementList[i];
                var segIndexName = groupObject.AddNonstandardSegment(segName);
                ParseReps(groupElement, groupObject, messageName, segName, segIndexName);
            }
        }

        /// <summary> Copies data from a group object into the corresponding group element, creating any
        /// necessary child nodes.
        /// </summary>
        private void Encode(IGroup groupObject, XmlElement groupElement)
        {
            var childNames = groupObject.Names;
            var messageName = groupObject.Message.GetStructureName();

            try
            {
                for (var i = 0; i < childNames.Length; i++)
                {
                    var reps = groupObject.GetAll(childNames[i]);
                    for (var j = 0; j < reps.Length; j++)
                    {
                        var childElement =
                            groupElement.OwnerDocument.CreateElement(MakeGroupElementName(messageName, childNames[i]));
                        var hasValue = false;

                        if (reps[j] is IGroup)
                        {
                            hasValue = true;
                            Encode((IGroup)reps[j], childElement);
                        }
                        else if (reps[j] is ISegment)
                        {
                            hasValue = Encode((ISegment)reps[j], childElement);
                        }

                        if (hasValue)
                        {
                            groupElement.AppendChild(childElement);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new HL7Exception(
                    "Can't encode group " + groupObject.GetType().FullName,
                    ErrorCode.APPLICATION_INTERNAL_ERROR,
                    e);
            }
        }

        // param childIndexName may have an integer on the end if >1 sibling with same name (e.g. NTE2)
        private void ParseReps(
            XmlElement groupElement,
            IGroup groupObject,
            string messageName,
            string childName,
            string childIndexName)
        {
            var reps = GetChildElementsByTagName(groupElement, MakeGroupElementName(messageName, childName));
            Log.Debug("# of elements matching " + MakeGroupElementName(messageName, childName) + ": " + reps.Count);

            if (groupObject.IsRepeating(childIndexName))
            {
                for (var i = 0; i < reps.Count; i++)
                {
                    ParseRep((XmlElement)reps[i], groupObject.GetStructure(childIndexName, i));
                }
            }
            else
            {
                if (reps.Count > 0)
                {
                    ParseRep((XmlElement)reps[0], groupObject.GetStructure(childIndexName, 0));
                }

                if (reps.Count > 1)
                {
                    var newIndexName = groupObject.AddNonstandardSegment(childName);
                    for (var i = 1; i < reps.Count; i++)
                    {
                        ParseRep((XmlElement)reps[i], groupObject.GetStructure(newIndexName, i - 1));
                    }
                }
            }
        }

        private void ParseRep(XmlElement theElem, IStructure theObj)
        {
            if (theObj is IGroup)
            {
                Parse((IGroup)theObj, theElem);
            }
            else if (theObj is ISegment)
            {
                Parse((ISegment)theObj, theElem);
            }

            Log.Debug("Parsed element: " + theElem.Name);
        }

        // includes direct children only
        private IList GetChildElementsByTagName(XmlElement theElement, string theName)
        {
            IList result = new ArrayList(10);
            var children = theElement.ChildNodes;

            for (var i = 0; i < children.Count; i++)
            {
                var child = children.Item(i);
                if (Convert.ToInt16(child.NodeType) == (short)XmlNodeType.Element && child.Name.Equals(theName))
                {
                    result.Add(child);
                }
            }

            return result;
        }
    }
}