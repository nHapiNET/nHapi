using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

using NHapi.Base.Log;
using NHapi.Base.Model;

namespace NHapi.Base.Parser
{
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
   /// <author>Bryan Tripp</author>
   public class DefaultXMLParser : XMLParser
    {
        private static readonly IHapiLog log;

        /// <summary>Creates a new instance of DefaultXMLParser </summary>
        public DefaultXMLParser()
        {
        }

        /// <summary>Creates a new instance of DefaultXMLParser </summary>
        public DefaultXMLParser(IModelClassFactory modelClassFactory) : base(modelClassFactory)
        {
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
            String messageClassName = source.GetType().FullName;
            String messageName = messageClassName.Substring(messageClassName.LastIndexOf('.') + 1);
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                XmlElement root = doc.CreateElement(messageName);
                doc.AppendChild(root);
            }
            catch (Exception e)
            {
                throw new HL7Exception("Can't create XML document - " + e.GetType().FullName,
                    ErrorCode.APPLICATION_INTERNAL_ERROR, e);
            }
            Encode(source, (XmlElement)doc.DocumentElement);
            return doc;
        }

        /// <summary> Copies data from a group object into the corresponding group element, creating any
        /// necessary child nodes.
        /// </summary>
        private void Encode(IGroup groupObject, XmlElement groupElement)
        {
            String[] childNames = groupObject.Names;
            String messageName = groupObject.Message.GetStructureName();

            try
            {
                for (int i = 0; i < childNames.Length; i++)
                {
                    IStructure[] reps = groupObject.GetAll(childNames[i]);
                    for (int j = 0; j < reps.Length; j++)
                    {
                        XmlElement childElement =
                            groupElement.OwnerDocument.CreateElement(MakeGroupElementName(messageName, childNames[i]));
                        bool hasValue = false;

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
                throw new HL7Exception("Can't encode group " + groupObject.GetType().FullName,
                    ErrorCode.APPLICATION_INTERNAL_ERROR, e);
            }
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
        /// <throws>  EncodingNotSupportedException if the message encoded </throws>
        /// <summary>     is not supported by this parser.
        /// </summary>
        public override IMessage ParseDocument(XmlDocument XMLMessage, String version)
        {
            String messageName = ((XmlElement)XMLMessage.DocumentElement).Name;
            IMessage message = InstantiateMessage(messageName, version, true);
            Parse(message, (XmlElement)XMLMessage.DocumentElement);
            return message;
        }

        /// <summary> Populates the given group object with data from the given group element, ignoring
        /// any unrecognized nodes.
        /// </summary>
        private void Parse(IGroup groupObject, XmlElement groupElement)
        {
            String[] childNames = groupObject.Names;
            String messageName = groupObject.Message.GetStructureName();

            XmlNodeList allChildNodes = groupElement.ChildNodes;
            ArrayList unparsedElementList = new ArrayList();
            for (int i = 0; i < allChildNodes.Count; i++)
            {
                XmlNode node = allChildNodes.Item(i);
                String name = node.Name;
                if (Convert.ToInt16(node.NodeType) == (short)XmlNodeType.Element && !unparsedElementList.Contains(name))
                {
                    unparsedElementList.Add(name);
                }
            }

            //we're not too fussy about order here (all occurrences get parsed as repetitions) ...
            for (int i = 0; i < childNames.Length; i++)
            {
                SupportClass.ICollectionSupport.Remove(unparsedElementList, childNames[i]);
                ParseReps(groupElement, groupObject, messageName, childNames[i], childNames[i]);
            }

            for (int i = 0; i < unparsedElementList.Count; i++)
            {
                String segName = (String)unparsedElementList[i];
                String segIndexName = groupObject.addNonstandardSegment(segName);
                ParseReps(groupElement, groupObject, messageName, segName, segIndexName);
            }
        }

        //param childIndexName may have an integer on the end if >1 sibling with same name (e.g. NTE2)
        private void ParseReps(XmlElement groupElement, IGroup groupObject, String messageName, String childName,
            String childIndexName)
        {
            IList reps = GetChildElementsByTagName(groupElement, MakeGroupElementName(messageName, childName));
            log.Debug("# of elements matching " + MakeGroupElementName(messageName, childName) + ": " + reps.Count);

            if (groupObject.IsRepeating(childIndexName))
            {
                for (int i = 0; i < reps.Count; i++)
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
                    String newIndexName = groupObject.addNonstandardSegment(childName);
                    for (int i = 1; i < reps.Count; i++)
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
            log.Debug("Parsed element: " + theElem.Name);
        }

        //includes direct children only
        private IList GetChildElementsByTagName(XmlElement theElement, String theName)
        {
            IList result = new ArrayList(10);
            XmlNodeList children = theElement.ChildNodes;

            for (int i = 0; i < children.Count; i++)
            {
                XmlNode child = children.Item(i);
                if (Convert.ToInt16(child.NodeType) == (short)XmlNodeType.Element && child.Name.Equals(theName))
                {
                    result.Add(child);
                }
            }

            return result;
        }

        /// <summary>
        /// Given the name of a message and a Group class, returns the corresponding group element name in an
        /// XML-encoded message. This is the message name and group name separated by a dot. For example,
        /// ADT_A01.INSURANCE.
        /// <para>
        /// If it looks like a segment name (ie: has 3 characters), no change is made.
        /// </para>
        /// </summary>
        protected internal static String MakeGroupElementName(String messageName, String className)
        {
            String ret = null;

            if (className.Length > 4)
            {
                StringBuilder elementName = new StringBuilder();
                elementName.Append(messageName);
                elementName.Append('.');
                elementName.Append(className);
                ret = elementName.ToString();
            }
            else if (className.Length == 4)
            {
                ret = className.Substring(0, (3) - (0));
            }
            else
            {
                ret = className;
            }

            return ret;
        }

        /// <summary>Test harness </summary>
        [STAThread]
        public new static void Main(String[] args)
        {
            if (args.Length != 1)
            {
                Console.Out.WriteLine("Usage: DefaultXMLParser pipe_encoded_file");
                Environment.Exit(1);
            }

            //read and parse message from file
            try
            {
                FileInfo messageFile = new FileInfo(args[0]);
                long fileLength = SupportClass.FileLength(messageFile);
                StreamReader r = new StreamReader(messageFile.FullName, Encoding.Default);
                char[] cbuf = new char[(int)fileLength];
                Console.Out.WriteLine("Reading message file ... " + r.Read((Char[])cbuf, 0, cbuf.Length) + " of " + fileLength +
                                             " chars");
                r.Close();
                String messString = Convert.ToString(cbuf);

                ParserBase inParser = null;
                ParserBase outParser = null;
                PipeParser pp = new PipeParser();
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

                IMessage mess = inParser.Parse(messString);
                Console.Out.WriteLine("Got message of type " + mess.GetType().FullName);

                String otherEncoding = outParser.Encode(mess);
                Console.Out.WriteLine(otherEncoding);
            }
            catch (Exception e)
            {
                SupportClass.WriteStackTrace(e, Console.Error);
            }
        }

        static DefaultXMLParser()
        {
            log = HapiLogFactory.GetHapiLog(typeof(DefaultXMLParser));
        }
    }
}