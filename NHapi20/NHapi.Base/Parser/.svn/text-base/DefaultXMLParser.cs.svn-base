using System;
using NHapi.Base;
using NHapi.Base.Model;
using NHapi.Base.Log;

namespace NHapi.Base.Parser
{

    /// <summary> <p>A default XMLParser.  This class assigns segment elements (in an XML-encoded message) 
    /// to Segment objects (in a Message object) using the name of a segment and the names 
    /// of any groups in which the segment is nested.  The names of group classes must correspond
    /// to the names of group elements (they must be identical except that a dot in the element 
    /// name, following the message name, is replaced with an underscore, in order to consitute a 
    /// valid class name). </p>
    /// <p>At the time of writing, the group names in the XML spec are changing.  Many of the group 
    /// names have been automatically generated based on the group contents.  However, these automatic 
    /// names are gradually being replaced with manually assigned names.  This process is expected to 
    /// be complete by November 2002.  As a result, mismatches are likely.  Messages could be  
    /// transformed prior to parsing (using XSLT) as a work-around.  Alternatively the group class names 
    /// could be changed to reflect updates in the XML spec.  Ultimately, HAPI group classes will be 
    /// changed to correspond with the official group names, once these are all assigned.  </p>
    /// </summary>
    /// <author>  Bryan Tripp
    /// </author>
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
        public override System.Xml.XmlDocument EncodeDocument(IMessage source)
        {
            System.String messageClassName = source.GetType().FullName;
            System.String messageName = messageClassName.Substring(messageClassName.LastIndexOf('.') + 1);
            System.Xml.XmlDocument doc = null;
            try
            {
                doc = new System.Xml.XmlDocument();
                System.Xml.XmlElement root = doc.CreateElement(messageName);
                doc.AppendChild(root);
            }
            catch (System.Exception e)
            {
                throw new HL7Exception("Can't create XML document - " + e.GetType().FullName, HL7Exception.APPLICATION_INTERNAL_ERROR, e);
            }
            Encode(source, (System.Xml.XmlElement)doc.DocumentElement);
            return doc;
        }

        /// <summary> Copies data from a group object into the corresponding group element, creating any 
        /// necessary child nodes.  
        /// </summary>
        private void Encode(IGroup groupObject, System.Xml.XmlElement groupElement)
        {
            System.String[] childNames = groupObject.Names;
            System.String messageName = groupObject.Message.GetStructureName();

            try
            {
                for (int i = 0; i < childNames.Length; i++)
                {
                    IStructure[] reps = groupObject.GetAll(childNames[i]);
                    for (int j = 0; j < reps.Length; j++)
                    {
                        System.Xml.XmlElement childElement = groupElement.OwnerDocument.CreateElement(MakeGroupElementName(messageName, childNames[i]));
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
            catch (System.Exception e)
            {
                throw new HL7Exception("Can't encode group " + groupObject.GetType().FullName, HL7Exception.APPLICATION_INTERNAL_ERROR, e);
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
        public override IMessage ParseDocument(System.Xml.XmlDocument XMLMessage, System.String version)
        {
            System.String messageName = ((System.Xml.XmlElement)XMLMessage.DocumentElement).Name;
            IMessage message = InstantiateMessage(messageName, version, true);
            Parse(message, (System.Xml.XmlElement)XMLMessage.DocumentElement);
            return message;
        }

        /// <summary> Populates the given group object with data from the given group element, ignoring 
        /// any unrecognized nodes.  
        /// </summary>
        private void Parse(IGroup groupObject, System.Xml.XmlElement groupElement)
        {
            System.String[] childNames = groupObject.Names;
            System.String messageName = groupObject.Message.GetStructureName();

            System.Xml.XmlNodeList allChildNodes = groupElement.ChildNodes;
            System.Collections.ArrayList unparsedElementList = new System.Collections.ArrayList();
            for (int i = 0; i < allChildNodes.Count; i++)
            {
                System.Xml.XmlNode node = allChildNodes.Item(i);
                System.String name = node.Name;
                if (System.Convert.ToInt16(node.NodeType) == (short)System.Xml.XmlNodeType.Element && !unparsedElementList.Contains(name))
                {
                    unparsedElementList.Add(name);
                }
            }

            //we're not too fussy about order here (all occurances get parsed as repetitions) ... 
            for (int i = 0; i < childNames.Length; i++)
            {
                SupportClass.ICollectionSupport.Remove(unparsedElementList, childNames[i]);
                ParseReps(groupElement, groupObject, messageName, childNames[i], childNames[i]);
            }

            for (int i = 0; i < unparsedElementList.Count; i++)
            {
                System.String segName = (System.String)unparsedElementList[i];
                System.String segIndexName = groupObject.addNonstandardSegment(segName);
                ParseReps(groupElement, groupObject, messageName, segName, segIndexName);
            }
        }

        //param childIndexName may have an integer on the end if >1 sibling with same name (e.g. NTE2) 
        private void ParseReps(System.Xml.XmlElement groupElement, IGroup groupObject, System.String messageName, System.String childName, System.String childIndexName)
        {

            System.Collections.IList reps = GetChildElementsByTagName(groupElement, MakeGroupElementName(messageName, childName));
            log.Debug("# of elements matching " + MakeGroupElementName(messageName, childName) + ": " + reps.Count);
			
            if (groupObject.IsRepeating(childIndexName))
            {
                for (int i = 0; i < reps.Count; i++)
                {
                    ParseRep((System.Xml.XmlElement)reps[i], groupObject.GetStructure(childIndexName, i));
                }
            }
            else
            {
                if (reps.Count > 0)
                {
                    ParseRep((System.Xml.XmlElement)reps[0], groupObject.GetStructure(childIndexName, 0));
                }

                if (reps.Count > 1)
                {
                    System.String newIndexName = groupObject.addNonstandardSegment(childName);
                    for (int i = 1; i < reps.Count; i++)
                    {
                        ParseRep((System.Xml.XmlElement)reps[i], groupObject.GetStructure(newIndexName, i - 1));
                    }
                }
            }
        }

        private void ParseRep(System.Xml.XmlElement theElem, IStructure theObj)
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
        private System.Collections.IList GetChildElementsByTagName(System.Xml.XmlElement theElement, System.String theName)
        {
            System.Collections.IList result = new System.Collections.ArrayList(10);
            System.Xml.XmlNodeList children = theElement.ChildNodes;

            for (int i = 0; i < children.Count; i++)
            {
                System.Xml.XmlNode child = children.Item(i);
                if (System.Convert.ToInt16(child.NodeType) == (short)System.Xml.XmlNodeType.Element && child.Name.Equals(theName))
                {
                    result.Add(child);
                }
            }

            return result;
        }

        /// <summary> Given the name of a group element in an XML message, returns the corresponding 
        /// group class name.  This name is identical except in order to be a valid class 
        /// name, the dot character immediately following the message name is replaced with 
        /// an underscore.  For example, there is a group element called ADT_A01.INSURANCE and the 
        /// corresponding group Class is called ADT_A01_INSURANCE. 
        /// </summary>
        //    protected static String makeGroupClassName(String elementName) {
        //        return elementName.replace('.', '_');
        //    }

        /// <summary> Given the name of a message and a Group class, returns the corresponding group element name in an 
        /// XML-encoded message.  This is the message name and group name separated by a dot. For example, 
        /// ADT_A01.INSURANCE.
        /// 
        /// If it looks like a segment name (i.e. has 3 characters), no change is made. 
        /// </summary>
        protected internal static System.String MakeGroupElementName(System.String messageName, System.String className)
        {
            System.String ret = null;

            if (className.Length > 4)
            {
                System.Text.StringBuilder elementName = new System.Text.StringBuilder();
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
        public new static void Main(System.String[] args)
        {
            if (args.Length != 1)
            {
                System.Console.Out.WriteLine("Usage: DefaultXMLParser pipe_encoded_file");
                System.Environment.Exit(1);
            }

            //read and parse message from file 
            try
            {
                System.IO.FileInfo messageFile = new System.IO.FileInfo(args[0]);
                long fileLength = SupportClass.FileLength(messageFile);
                System.IO.StreamReader r = new System.IO.StreamReader(messageFile.FullName, System.Text.Encoding.Default);
                char[] cbuf = new char[(int)fileLength];
                System.Console.Out.WriteLine("Reading message file ... " + r.Read((System.Char[])cbuf, 0, cbuf.Length) + " of " + fileLength + " chars");
                r.Close();
                System.String messString = System.Convert.ToString(cbuf);

                ParserBase inParser = null;
                ParserBase outParser = null;
                PipeParser pp = new PipeParser();
                NHapi.Base.Parser.XMLParser xp = new DefaultXMLParser();
                System.Console.Out.WriteLine("Encoding: " + pp.GetEncoding(messString));
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
                System.Console.Out.WriteLine("Got message of type " + mess.GetType().FullName);

                System.String otherEncoding = outParser.Encode(mess);
                System.Console.Out.WriteLine(otherEncoding);
            }
            catch (System.Exception e)
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