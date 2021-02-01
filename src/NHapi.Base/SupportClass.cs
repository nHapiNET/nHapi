/*
  In order to convert some functionality to Visual C#, the Java Language Conversion Assistant
  creates "support classes" that duplicate the original functionality.

  Support classes replicate the functionality of the original code, but in some cases they are
  substantially different architecturally. Although every effort is made to preserve the
  original architecture of the application in the converted project, the user should be aware that
  the primary goal of these support classes is to replicate functionality, and that at times
  the architecture of the resulting solution may differ somewhat.
*/

using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;

namespace NHapi.Base
{
   /// <summary>
   /// This interface should be implemented by any class whose instances are intended
   /// to be executed by a thread.
   /// </summary>
   public interface IThreadRunnable
    {
        /// <summary>
        /// This method has to be implemented in order that starting of the thread causes the object's
        /// run method to be called in that separately executing thread.
        /// </summary>
        void Run();
    }

    /*******************************/

    /// <summary>
    /// This interface will manage errors during the parsing of a XML document.
    /// </summary>
   public interface IXmlSaxErrorHandler
    {
        /// <summary>
        /// This method manage an error exception occurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void error(XmlException exception);

        /// <summary>
        /// This method manage a fatal error exception occurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void fatalError(XmlException exception);

        /// <summary>
        /// This method manage a warning exception occurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void warning(XmlException exception);
    }

    /*******************************/

    /// <summary>
    /// This class is used to encapsulate a source of Xml code in an single class.
    /// </summary>
   public class XmlSourceSupport
    {
        private Stream bytes;
        private StreamReader characters;
        private string uri;

        /// <summary>
        /// Constructs an empty XmlSourceSupport instance.
        /// </summary>
        public XmlSourceSupport()
        {
            bytes = null;
            characters = null;
            uri = null;
        }

        /// <summary>
        /// Constructs a XmlSource instance with the specified source System.IO.Stream.
        /// </summary>
        /// <param name="stream">The stream containing the document.</param>
        public XmlSourceSupport(Stream stream)
        {
            bytes = stream;
            characters = null;
            uri = null;
        }

        /// <summary>
        /// Constructs a XmlSource instance with the specified source System.IO.StreamReader.
        /// </summary>
        /// <param name="reader">The reader containing the document.</param>
        public XmlSourceSupport(StreamReader reader)
        {
            bytes = null;
            characters = reader;
            uri = null;
        }

        /// <summary>
        /// Construct a XmlSource instance with the specified source Uri string.
        /// </summary>
        /// <param name="source">The source containing the document.</param>
        public XmlSourceSupport(string source)
        {
            bytes = null;
            characters = null;
            uri = source;
        }

        /// <summary>
        /// Represents the source Stream of the XmlSource.
        /// </summary>
        public Stream Bytes
        {
            get { return bytes; }
            set { bytes = value; }
        }

        /// <summary>
        /// Represents the source StreamReader of the XmlSource.
        /// </summary>
        public StreamReader Characters
        {
            get { return characters; }
            set { characters = value; }
        }

        /// <summary>
        /// Represents the source URI of the XmlSource.
        /// </summary>
        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }
    }

    /*******************************/

    /// <summary>
    /// Basic interface for resolving entities.
    /// </summary>
   public interface IXmlSaxEntityResolver
    {
        /// <summary>
        /// Allow the application to resolve external entities.
        /// </summary>
        /// <param name="publicId">The public identifier of the external entity being referenced, or null if none was supplied.</param>
        /// <param name="systemId">The system identifier of the external entity being referenced.</param>
        /// <returns>A XmlSourceSupport object describing the new input source, or null to request that the parser open a regular URI connection to the system identifier.</returns>
        XmlSourceSupport resolveEntity(string publicId, string systemId);
    }

    /*******************************/

    /// <summary>
    /// This interface will manage the Content events of a XML document.
    /// </summary>
   public interface IXmlSaxContentHandler
    {
        /// <summary>
        /// This method manage the notification when Characters elements were found.
        /// </summary>
        /// <param name="ch">The array with the characters found.</param>
        /// <param name="start">The index of the first position of the characters found.</param>
        /// <param name="length">Specify how many characters must be read from the array.</param>
        void characters(char[] ch, int start, int length);

        /// <summary>
        /// This method manage the notification when the end document node were found.
        /// </summary>
        void endDocument();

        /// <summary>
        /// This method manage the notification when the end element node was found.
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the element.</param>
        /// <param name="localName">The local name of the element.</param>
        /// <param name="qName">The long (qualified) name of the element.</param>
        void endElement(string namespaceURI, string localName, string qName);

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends.</param>
        void endPrefixMapping(string prefix);

        /// <summary>
        /// This method manage the event when a ignorable whitespace node was found.
        /// </summary>
        /// <param name="Ch">The array with the ignorable whitespaces.</param>
        /// <param name="Start">The index in the array with the ignorable whitespace.</param>
        /// <param name="Length">The length of the whitespaces.</param>
        void ignorableWhitespace(char[] Ch, int Start, int Length);

        /// <summary>
        /// This method manage the event when a processing instruction was found.
        /// </summary>
        /// <param name="target">The processing instruction target.</param>
        /// <param name="data">The processing instruction data.</param>
        void processingInstruction(string target, string data);

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// </summary>
        void setDocumentLocator(IXmlSaxLocator locator);

        /// <summary>
        /// This method manage the event when a skipped entity was found.
        /// </summary>
        /// <param name="name">The name of the skipped entity.</param>
        void skippedEntity(string name);

        /// <summary>
        /// This method manage the event when a start document node was found.
        /// </summary>
        void startDocument();

        /// <summary>
        /// This method manage the event when a start element node was found.
        /// </summary>
        /// <param name="namespaceURI">The namespace uri of the element tag.</param>
        /// <param name="localName">The local name of the element.</param>
        /// <param name="qName">The long (qualified) name of the element.</param>
        /// <param name="atts">The list of attributes of the element.</param>
        void startElement(string namespaceURI, string localName, string qName, SaxAttributesSupport atts);

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area.</param>
        /// <param name="uri">The namespace URI of the prefix area.</param>
        void startPrefixMapping(string prefix, string uri);
    }

    /*******************************/

    /// <summary>
    /// This interface is created to emulate the SAX Locator interface behavior.
    /// </summary>
   public interface IXmlSaxLocator
    {
        /// <summary>
        /// This method return the column number where the current document event ends.
        /// </summary>
        /// <returns>The column number where the current document event ends.</returns>
        int getColumnNumber();

        /// <summary>
        /// This method return the line number where the current document event ends.
        /// </summary>
        /// <returns>The line number where the current document event ends.</returns>
        int getLineNumber();

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// </summary>
        /// <returns>The saved public identifier.</returns>
        string getPublicId();

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// </summary>
        /// <returns>The saved system identifier.</returns>
        string getSystemId();
    }

    /*******************************/

    /// <summary>
    /// This class is created for emulates the SAX LocatorImpl behaviors.
    /// </summary>
   public class XmlSaxLocatorImpl : IXmlSaxLocator
    {
        /// <summary>
        /// This method returns a new instance of 'XmlSaxLocatorImpl'.
        /// </summary>
        /// <returns>A new 'XmlSaxLocatorImpl' instance.</returns>
        public XmlSaxLocatorImpl()
        {
        }

        /// <summary>
        /// This method returns a new instance of 'XmlSaxLocatorImpl'.
        /// Create a persistent copy of the current state of a locator.
        /// </summary>
        /// <param name="locator">The current state of a locator.</param>
        /// <returns>A new 'XmlSaxLocatorImpl' instance.</returns>
        public XmlSaxLocatorImpl(IXmlSaxLocator locator)
        {
            setPublicId(locator.getPublicId());
            setSystemId(locator.getSystemId());
            setLineNumber(locator.getLineNumber());
            setColumnNumber(locator.getColumnNumber());
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Return the saved public identifier.
        /// </summary>
        /// <returns>The saved public identifier.</returns>
        public virtual string getPublicId()
        {
            return publicId;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Return the saved system identifier.
        /// </summary>
        /// <returns>The saved system identifier.</returns>
        public virtual string getSystemId()
        {
            return systemId;
        }

        /// <summary>
        /// Return the saved line number.
        /// </summary>
        /// <returns>The saved line number.</returns>
        public virtual int getLineNumber()
        {
            return lineNumber;
        }

        /// <summary>
        /// Return the saved column number.
        /// </summary>
        /// <returns>The saved column number.</returns>
        public virtual int getColumnNumber()
        {
            return columnNumber;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Set the public identifier for this locator.
        /// </summary>
        /// <param name="publicId">The new public identifier.</param>
        public virtual void setPublicId(string publicId)
        {
            this.publicId = publicId;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Set the system identifier for this locator.
        /// </summary>
        /// <param name="systemId">The new system identifier.</param>
        public virtual void setSystemId(string systemId)
        {
            this.systemId = systemId;
        }

        /// <summary>
        /// Set the line number for this locator.
        /// </summary>
        /// <param name="lineNumber">The line number.</param>
        public virtual void setLineNumber(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Set the column number for this locator.
        /// </summary>
        /// <param name="columnNumber">The column number.</param>
        public virtual void setColumnNumber(int columnNumber)
        {
            this.columnNumber = columnNumber;
        }

        // Internal state.
        private string publicId;
        private string systemId;
        private int lineNumber;
        private int columnNumber;
    }

    /*******************************/

    /// <summary>
    /// This interface will manage the Content events of a XML document.
    /// </summary>
   public interface IXmlSaxLexicalHandler
    {
        /// <summary>
        /// This method manage the notification when Characters elements were found.
        /// </summary>
        /// <param name="ch">The array with the characters found.</param>
        /// <param name="start">The index of the first position of the characters found.</param>
        /// <param name="length">Specify how many characters must be read from the array.</param>
        void comment(char[] ch, int start, int length);

        /// <summary>
        /// This method manage the notification when the end of a CDATA section were found.
        /// </summary>
        void endCDATA();

        /// <summary>
        /// This method manage the notification when the end of DTD declarations were found.
        /// </summary>
        void endDTD();

        /// <summary>
        /// This method report the end of an entity.
        /// </summary>
        /// <param name="name">The name of the entity that is ending.</param>
        void endEntity(string name);

        /// <summary>
        /// This method manage the notification when the start of a CDATA section were found.
        /// </summary>
        void startCDATA();

        /// <summary>
        /// This method manage the notification when the start of DTD declarations were found.
        /// </summary>
        /// <param name="name">The name of the DTD entity.</param>
        /// <param name="publicId">The public identifier.</param>
        /// <param name="systemId">The system identifier.</param>
        void startDTD(string name, string publicId, string systemId);

        /// <summary>
        /// This method report the start of an entity.
        /// </summary>
        /// <param name="name">The name of the entity that is ending.</param>
        void startEntity(string name);
    }

    /*******************************/

    /// <summary>
    /// This class will manage all the parsing operations emulating the SAX parser behavior
    /// </summary>
   public class SaxAttributesSupport
    {
        private ArrayList MainList;

        /// <summary>
        /// Builds a new instance of SaxAttributesSupport.
        /// </summary>
        public SaxAttributesSupport()
        {
            MainList = new ArrayList();
        }

        /// <summary>
        /// Creates a new instance of SaxAttributesSupport from an ArrayList of Att_Instance class.
        /// </summary>
        /// <param name="List">An ArraList of Att_Instance class instances.</param>
        /// <returns>A new instance of SaxAttributesSupport</returns>
        public SaxAttributesSupport(SaxAttributesSupport List)
        {
            SaxAttributesSupport temp = new SaxAttributesSupport();
            temp.MainList = (ArrayList)List.MainList.Clone();
        }

        /// <summary>
        /// Adds a new attribute element to the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="Uri">The Uri of the attribute to be added.</param>
        /// <param name="Lname">The Local name of the attribute to be added.</param>
        /// <param name="Qname">The Long(qualify) name of the attribute to be added.</param>
        /// <param name="Type">The type of the attribute to be added.</param>
        /// <param name="Value">The value of the attribute to be added.</param>
        public virtual void Add(string Uri, string Lname, string Qname, string Type, string Value)
        {
            Att_Instance temp_Attributes = new Att_Instance(Uri, Lname, Qname, Type, Value);
            MainList.Add(temp_Attributes);
        }

        /// <summary>
        /// Clears the list of attributes in the given AttributesSupport instance.
        /// </summary>
        public virtual void Clear()
        {
            MainList.Clear();
        }

        /// <summary>
        /// Obtains the index of an attribute of the AttributeSupport from its qualified (long) name.
        /// </summary>
        /// <param name="Qname">The qualified name of the attribute to search.</param>
        /// <returns>An zero-based index of the attribute if it is found, otherwise it returns -1.</returns>
        public virtual int GetIndex(string Qname)
        {
            int index = GetLength() - 1;
            while ((index >= 0) && !(((Att_Instance)(MainList[index])).att_fullName.Equals(Qname)))
                index--;
            if (index >= 0)
                return index;
            else
                return -1;
        }

        /// <summary>
        /// Obtains the index of an attribute of the AttributeSupport from its namespace URI and its local name.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>An zero-based index of the attribute if it is found, otherwise it returns -1.</returns>
        public virtual int GetIndex(string Uri, string Lname)
        {
            int index = GetLength() - 1;
            while ((index >= 0) &&
                     !(((Att_Instance)(MainList[index])).att_localName.Equals(Lname) &&
                        ((Att_Instance)(MainList[index])).att_URI.Equals(Uri)))
                index--;
            if (index >= 0)
                return index;
            else
                return -1;
        }

        /// <summary>
        /// Returns the number of attributes saved in the SaxAttributesSupport instance.
        /// </summary>
        /// <returns>The number of elements in the given SaxAttributesSupport instance.</returns>
        public virtual int GetLength()
        {
            return MainList.Count;
        }

        /// <summary>
        /// Returns the local name of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The local name of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetLocalName(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_localName;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the qualified name of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The qualified name of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetFullName(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_fullName;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the type of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The type of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetType(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_type;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the namespace URI of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The namespace URI of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetURI(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_URI;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the value of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The value of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual string GetValue(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_value;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Modifies the local name of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="LocalName">The new Local name for the attribute.</param>
        public virtual void SetLocalName(int index, string LocalName)
        {
            ((Att_Instance)MainList[index]).att_localName = LocalName;
        }

        /// <summary>
        /// Modifies the qualified name of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="FullName">The new qualified name for the attribute.</param>
        public virtual void SetFullName(int index, string FullName)
        {
            ((Att_Instance)MainList[index]).att_fullName = FullName;
        }

        /// <summary>
        /// Modifies the type of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="Type">The new type for the attribute.</param>
        public virtual void SetType(int index, string Type)
        {
            ((Att_Instance)MainList[index]).att_type = Type;
        }

        /// <summary>
        /// Modifies the namespace URI of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="URI">The new namespace URI for the attribute.</param>
        public virtual void SetURI(int index, string URI)
        {
            ((Att_Instance)MainList[index]).att_URI = URI;
        }

        /// <summary>
        /// Modifies the value of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="Value">The new value for the attribute.</param>
        public virtual void SetValue(int index, string Value)
        {
            ((Att_Instance)MainList[index]).att_value = Value;
        }

        /// <summary>
        /// This method eliminates the Att_Instance instance at the specified index.
        /// </summary>
        /// <param name="index">The index of the attribute.</param>
        public virtual void RemoveAttribute(int index)
        {
            try
            {
                MainList.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new IndexOutOfRangeException("The index is out of range");
            }
        }

        /// <summary>
        /// This method eliminates the Att_Instance instance in the specified index.
        /// </summary>
        /// <param name="indexName">The index name of the attribute.</param>
        public virtual void RemoveAttribute(string indexName)
        {
            try
            {
                int pos = GetLength() - 1;
                while ((pos >= 0) && !(((Att_Instance)(MainList[pos])).att_localName.Equals(indexName)))
                    pos--;
                if (pos >= 0)
                    MainList.RemoveAt(pos);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new IndexOutOfRangeException("The index is out of range");
            }
        }

        /// <summary>
        /// Replaces an Att_Instance in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The index of the attribute.</param>
        /// <param name="Uri">The namespace URI of the new Att_Instance.</param>
        /// <param name="Lname">The local name of the new Att_Instance.</param>
        /// <param name="Qname">The namespace URI of the new Att_Instance.</param>
        /// <param name="Type">The type of the new Att_Instance.</param>
        /// <param name="Value">The value of the new Att_Instance.</param>
        public virtual void SetAttribute(int index, string Uri, string Lname, string Qname, string Type, string Value)
        {
            MainList[index] = new Att_Instance(Uri, Lname, Qname, Type, Value);
        }

        /// <summary>
        /// Replaces all the list of Att_Instance of the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="Source">The source SaxAttributesSupport instance.</param>
        public virtual void SetAttributes(SaxAttributesSupport Source)
        {
            MainList = Source.MainList;
        }

        /// <summary>
        /// Returns the type of the Attribute that match with the given qualified name.
        /// </summary>
        /// <param name="Qname">The qualified name of the attribute to search.</param>
        /// <returns>The type of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetType(string Qname)
        {
            int temp_Index = GetIndex(Qname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_type;
            else
                return string.Empty;
        }

        /// <summary>
        /// Returns the type of the Attribute that match with the given namespace URI and local name.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>The type of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetType(string Uri, string Lname)
        {
            int temp_Index = GetIndex(Uri, Lname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_type;
            else
                return string.Empty;
        }

        /// <summary>
        /// Returns the value of the Attribute that match with the given qualified name.
        /// </summary>
        /// <param name="Qname">The qualified name of the attribute to search.</param>
        /// <returns>The value of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetValue(string Qname)
        {
            int temp_Index = GetIndex(Qname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_value;
            else
                return string.Empty;
        }

        /// <summary>
        /// Returns the value of the Attribute that match with the given namespace URI and local name.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>The value of the attribute if it exist otherwise returns null.</returns>
        public virtual string GetValue(string Uri, string Lname)
        {
            int temp_Index = GetIndex(Uri, Lname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_value;
            else
                return string.Empty;
        }

        /*******************************/

        /// <summary>
        /// This class is created to save the information of each attributes in the SaxAttributesSupport.
        /// </summary>
        public class Att_Instance
        {
            public string att_URI;
            public string att_localName;
            public string att_fullName;
            public string att_type;
            public string att_value;

            /// <summary>
            /// This is the constructor of the Att_Instance
            /// </summary>
            /// <param name="Uri">The namespace URI of the attribute</param>
            /// <param name="Lname">The local name of the attribute</param>
            /// <param name="Qname">The long(Qualify) name of attribute</param>
            /// <param name="Type">The type of the attribute</param>
            /// <param name="Value">The value of the attribute</param>
            public Att_Instance(string Uri, string Lname, string Qname, string Type, string Value)
            {
                att_URI = Uri;
                att_localName = Lname;
                att_fullName = Qname;
                att_type = Type;
                att_value = Value;
            }
        }
    }

    /*******************************/

    /// <summary>
    /// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature
    /// methods if a property or method couldn't be found.
    /// </summary>
   public class ManagerNotRecognizedException : Exception
    {
        /// <summary>
        /// Creates a new ManagerNotRecognizedException with the message specified.
        /// </summary>
        /// <param name="Message">Error message of the exception.</param>
        public ManagerNotRecognizedException(string Message)
            : base(Message)
        {
        }
    }

    /*******************************/

    /// <summary>
    /// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature methods
    /// if a property or method couldn't be supported.
    /// </summary>
   public class ManagerNotSupportedException : Exception
    {
        /// <summary>
        /// Creates a new ManagerNotSupportedException with the message specified.
        /// </summary>
        /// <param name="Message">Error message of the exception.</param>
        public ManagerNotSupportedException(string Message)
            : base(Message)
        {
        }
    }

    /*******************************/

    /// <summary>
    /// This class provides the base implementation for the management of XML documents parsing.
    /// </summary>
   public class XmlSaxDefaultHandler : IXmlSaxContentHandler, IXmlSaxErrorHandler, IXmlSaxEntityResolver
    {
        /// <summary>
        /// This method manage the notification when Characters element were found.
        /// </summary>
        /// <param name="ch">The array with the characters founds</param>
        /// <param name="start">The index of the first position of the characters found</param>
        /// <param name="length">Specify how many characters must be read from the array</param>
        public virtual void characters(char[] ch, int start, int length)
        {
        }

        /// <summary>
        /// This method manage the notification when the end document node were found
        /// </summary>
        public virtual void endDocument()
        {
        }

        /// <summary>
        /// This method manage the notification when the end element node were found
        /// </summary>
        /// <param name="uri">The namespace URI of the element</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The long name (qualify name) of the element</param>
        public virtual void endElement(string uri, string localName, string qName)
        {
        }

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends</param>
        public virtual void endPrefixMapping(string prefix)
        {
        }

        /// <summary>
        /// This method manage when an error exception occurs in the parsing process
        /// </summary>
        /// <param name="e">The exception throws by the parser</param>
        public virtual void error(XmlException e)
        {
        }

        /// <summary>
        /// This method manage when a fatal error exception occurs in the parsing process
        /// </summary>
        /// <param name="e">The exception Throws by the parser</param>
        public virtual void fatalError(XmlException e)
        {
        }

        /// <summary>
        /// This method manage the event when a ignorable whitespace node were found
        /// </summary>
        /// <param name="ch">The array with the ignorable whitespaces</param>
        /// <param name="start">The index in the array with the ignorable whitespace</param>
        /// <param name="length">The length of the whitespaces</param>
        public virtual void ignorableWhitespace(char[] ch, int start, int length)
        {
        }

        /// <summary>
        /// This method is not supported only is created for compatibility
        /// </summary>
        public virtual void notationDecl(string name, string publicId, string systemId)
        {
        }

        /// <summary>
        /// This method manage the event when a processing instruction were found
        /// </summary>
        /// <param name="target">The processing instruction target</param>
        /// <param name="data">The processing instruction data</param>
        public virtual void processingInstruction(string target, string data)
        {
        }

        /// <summary>
        /// Allow the application to resolve external entities.
        /// </summary>
        /// <param name="publicId">The public identifier of the external entity being referenced, or null if none was supplied.</param>
        /// <param name="systemId">The system identifier of the external entity being referenced.</param>
        /// <returns>A XmlSourceSupport object describing the new input source, or null to request that the parser open a regular URI connection to the system identifier.</returns>
        public virtual XmlSourceSupport resolveEntity(string publicId, string systemId)
        {
            return null;
        }

        /// <summary>
        /// This method is not supported, is include for compatibility
        /// </summary>
        public virtual void setDocumentLocator(IXmlSaxLocator locator)
        {
        }

        /// <summary>
        /// This method manage the event when a skipped entity were found
        /// </summary>
        /// <param name="name">The name of the skipped entity</param>
        public virtual void skippedEntity(string name)
        {
        }

        /// <summary>
        /// This method manage the event when a start document node were found
        /// </summary>
        public virtual void startDocument()
        {
        }

        /// <summary>
        /// This method manage the event when a start element node were found
        /// </summary>
        /// <param name="uri">The namespace uri of the element tag</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The Qualify (long) name of the element</param>
        /// <param name="attributes">The list of attributes of the element</param>
        public virtual void startElement(string uri, string localName, string qName, SaxAttributesSupport attributes)
        {
        }

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area</param>
        /// <param name="uri">The namespace uri of the prefix area</param>
        public virtual void startPrefixMapping(string prefix, string uri)
        {
        }

        /// <summary>
        /// This method is not supported only is created for compatibility
        /// </summary>
        public virtual void unparsedEntityDecl(string name, string publicId, string systemId, string notationName)
        {
        }

        /// <summary>
        /// This method manage when a warning exception occurs in the parsing process
        /// </summary>
        /// <param name="e">The exception Throws by the parser</param>
        public virtual void warning(XmlException e)
        {
        }
    }

    /*******************************/

    /// <summary>
    /// This class provides the base implementation for the management of XML documents parsing.
    /// </summary>
   public class XmlSaxParserAdapter : XmlSAXDocumentManager, IXmlSaxContentHandler
    {
        /// <summary>
        /// This method manage the notification when Characters element were found.
        /// </summary>
        /// <param name="ch">The array with the characters founds</param>
        /// <param name="start">The index of the first position of the characters found</param>
        /// <param name="length">Specify how many characters must be read from the array</param>
        public virtual void characters(char[] ch, int start, int length)
        {
        }

        /// <summary>
        /// This method manage the notification when the end document node were found
        /// </summary>
        public virtual void endDocument()
        {
        }

        /// <summary>
        /// This method manage the notification when the end element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the element</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The long name (qualify name) of the element</param>
        public virtual void endElement(string namespaceURI, string localName, string qName)
        {
        }

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends.</param>
        public virtual void endPrefixMapping(string prefix)
        {
        }

        /// <summary>
        /// This method manage the event when a ignorable whitespace node were found
        /// </summary>
        /// <param name="ch">The array with the ignorable whitespaces</param>
        /// <param name="start">The index in the array with the ignorable whitespace</param>
        /// <param name="length">The length of the whitespaces</param>
        public virtual void ignorableWhitespace(char[] ch, int start, int length)
        {
        }

        /// <summary>
        /// This method manage the event when a processing instruction were found
        /// </summary>
        /// <param name="target">The processing instruction target</param>
        /// <param name="data">The processing instruction data</param>
        public virtual void processingInstruction(string target, string data)
        {
        }

        /// <summary>
        /// Receive an object for locating the origin of events into the XML document
        /// </summary>
        /// <param name="locator">A 'XmlSaxLocator' object that can return the location of any events into the XML document</param>
        public virtual void setDocumentLocator(IXmlSaxLocator locator)
        {
        }

        /// <summary>
        /// This method manage the event when a skipped entity was found.
        /// </summary>
        /// <param name="name">The name of the skipped entity.</param>
        public virtual void skippedEntity(string name)
        {
        }

        /// <summary>
        /// This method manage the event when a start document node were found
        /// </summary>
        public virtual void startDocument()
        {
        }

        /// <summary>
        /// This method manage the event when a start element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace uri of the element tag</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The Qualify (long) name of the element</param>
        /// <param name="qAtts">The list of attributes of the element</param>
        public virtual void startElement(string namespaceURI, string localName, string qName, SaxAttributesSupport qAtts)
        {
        }

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area.</param>
        /// <param name="uri">The namespace URI of the prefix area.</param>
        public virtual void startPrefixMapping(string prefix, string uri)
        {
        }
    }


    /*******************************/

    /// <summary>
    /// Emulates the SAX parsers behaviours.
    /// </summary>
   public class XmlSAXDocumentManager
    {
        protected bool isValidating;
        protected bool namespaceAllowed;
        protected XmlReader reader;

        // protected XmlValidatingReader reader;
        protected IXmlSaxContentHandler callBackHandler;
        protected IXmlSaxErrorHandler errorHandler;
        protected XmlSaxLocatorImpl locator;
        protected IXmlSaxLexicalHandler lexical;
        protected IXmlSaxEntityResolver entityResolver;
        protected string parserFileName;

        /// <summary>
        /// Public constructor for the class.
        /// </summary>
        public XmlSAXDocumentManager()
        {
            isValidating = false;
            namespaceAllowed = false;
            reader = null;
            callBackHandler = null;
            errorHandler = null;
            locator = null;
            lexical = null;
            entityResolver = null;
            parserFileName = string.Empty;
        }

        /// <summary>
        /// Returns a new instance of 'XmlSAXDocumentManager'.
        /// </summary>
        /// <returns>A new 'XmlSAXDocumentManager' instance.</returns>
        public static XmlSAXDocumentManager NewInstance()
        {
            return new XmlSAXDocumentManager();
        }

        /// <summary>
        /// Returns a clone instance of 'XmlSAXDocumentManager'.
        /// </summary>
        /// <returns>A clone 'XmlSAXDocumentManager' instance.</returns>
        public static XmlSAXDocumentManager CloneInstance(XmlSAXDocumentManager instance)
        {
            XmlSAXDocumentManager temp = new XmlSAXDocumentManager();
            temp.NamespaceAllowed = instance.NamespaceAllowed;
            temp.isValidating = instance.isValidating;
            IXmlSaxContentHandler contentHandler = instance.getContentHandler();
            if (contentHandler != null)
                temp.setContentHandler(contentHandler);
            IXmlSaxErrorHandler errorHandler = instance.getErrorHandler();
            if (errorHandler != null)
                temp.setErrorHandler(errorHandler);
            temp.setFeature("http://xml.org/sax/features/namespaces",
                instance.getFeature("http://xml.org/sax/features/namespaces"));
            temp.setFeature("http://xml.org/sax/features/namespace-prefixes",
                instance.getFeature("http://xml.org/sax/features/namespace-prefixes"));
            temp.setFeature("http://xml.org/sax/features/validation",
                instance.getFeature("http://xml.org/sax/features/validation"));
            temp.setProperty("http://xml.org/sax/properties/lexical-handler",
                instance.getProperty("http://xml.org/sax/properties/lexical-handler"));
            temp.parserFileName = instance.parserFileName;
            return temp;
        }

        /// <summary>
        /// Indicates whether the 'XmlSAXDocumentManager' are validating the XML over a DTD.
        /// </summary>
        public bool IsValidating
        {
            get { return isValidating; }
            set { isValidating = value; }
        }

        /// <summary>
        /// Indicates whether the 'XmlSAXDocumentManager' manager allows namespaces.
        /// </summary>
        public bool NamespaceAllowed
        {
            get { return namespaceAllowed; }
            set { namespaceAllowed = value; }
        }

        /// <summary>
        /// Emulates the behaviour of a SAX LocatorImpl object.
        /// </summary>
        /// <param name="locator">The 'XmlSaxLocatorImpl' instance to assign the document location.</param>
        /// <param name="textReader">The XML document instance to be used.</param>
        private void UpdateLocatorData(XmlSaxLocatorImpl locator, XmlTextReader textReader)
        {
            if ((locator != null) && (textReader != null))
            {
                locator.setColumnNumber(textReader.LinePosition);
                locator.setLineNumber(textReader.LineNumber);
                locator.setSystemId(parserFileName);
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Set the value of a feature.
        /// </summary>
        /// <param name="name">The feature name, which is a fully-qualified URI.</param>
        /// <param name="value">The requested value for the feature.</param>
        public virtual void setFeature(string name, bool value)
        {
            switch (name)
            {
                case "http://xml.org/sax/features/namespaces":
                    {
                        try
                        {
                            NamespaceAllowed = value;
                            break;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }

                case "http://xml.org/sax/features/namespace-prefixes":
                    {
                        try
                        {
                            NamespaceAllowed = value;
                            break;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }

                case "http://xml.org/sax/features/validation":
                    {
                        try
                        {
                            isValidating = value;
                            break;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }

                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name + " are not supported");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Gets the value of a feature.
        /// </summary>
        /// <param name="name">The feature name, which is a fully-qualified URI.</param>
        /// <returns>The requested value for the feature.</returns>
        public virtual bool getFeature(string name)
        {
            switch (name)
            {
                case "http://xml.org/sax/features/namespaces":
                    {
                        try
                        {
                            return NamespaceAllowed;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }

                case "http://xml.org/sax/features/namespace-prefixes":
                    {
                        try
                        {
                            return NamespaceAllowed;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }

                case "http://xml.org/sax/features/validation":
                    {
                        try
                        {
                            return isValidating;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }

                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name + " are not supported");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Sets the value of a property.
        /// </summary>
        /// <param name="name">The property name, which is a fully-qualified URI.</param>
        /// <param name="value">The requested value for the property.</param>
        public virtual void setProperty(string name, object value)
        {
            switch (name)
            {
                case "http://xml.org/sax/properties/lexical-handler":
                    {
                        try
                        {
                            lexical = (IXmlSaxLexicalHandler)value;
                            break;
                        }
                        catch (Exception e)
                        {
                            throw new ManagerNotSupportedException(
                                "The property is not supported as an internal exception was thrown when trying to set it: " + e.Message);
                        }
                    }

                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name + " is not recognized");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parsers. Gets the value of a property.
        /// </summary>
        /// <param name="name">The property name, which is a fully-qualified URI.</param>
        /// <returns>The requested value for the property.</returns>
        public virtual object getProperty(string name)
        {
            switch (name)
            {
                case "http://xml.org/sax/properties/lexical-handler":
                    {
                        try
                        {
                            return lexical;
                        }
                        catch
                        {
                            throw new ManagerNotSupportedException("The specified operation was not performed");
                        }
                    }

                default:
                    throw new ManagerNotRecognizedException("The specified feature: " + name + " are not supported");
            }
        }

        /// <summary>
        /// Emulates the behavior of a SAX parser, it realizes the callback events of the parser.
        /// </summary>
        private void DoParsing()
        {
            Hashtable prefixes = new Hashtable();
            Stack stackNameSpace = new Stack();
            locator = new XmlSaxLocatorImpl();
            try
            {
                UpdateLocatorData(locator, (XmlTextReader)(reader));
                if (callBackHandler != null)
                    callBackHandler.setDocumentLocator(locator);
                if (callBackHandler != null)
                    callBackHandler.startDocument();
                while (reader.Read())
                {
                    UpdateLocatorData(locator, (XmlTextReader)(reader));
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            bool Empty = reader.IsEmptyElement;
                            string namespaceURI = string.Empty;
                            string localName = string.Empty;
                            if (namespaceAllowed)
                            {
                                namespaceURI = reader.NamespaceURI;
                                localName = reader.LocalName;
                            }

                            string name = reader.Name;
                            SaxAttributesSupport attributes = new SaxAttributesSupport();
                            if (reader.HasAttributes)
                            {
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    string prefixName = (reader.Name.IndexOf(":") > 0)
                                        ? reader.Name.Substring(reader.Name.IndexOf(":") + 1, reader.Name.Length - reader.Name.IndexOf(":") - 1)
                                        : string.Empty;
                                    string prefix = (reader.Name.IndexOf(":") > 0)
                                        ? reader.Name.Substring(0, reader.Name.IndexOf(":"))
                                        : reader.Name;
                                    bool IsXmlns = prefix.ToLower().Equals("xmlns");
                                    if (namespaceAllowed)
                                    {
                                        if (!IsXmlns)
                                            attributes.Add(reader.NamespaceURI, reader.LocalName, reader.Name, string.Empty + reader.NodeType, reader.Value);
                                    }
                                    else
                                        attributes.Add(string.Empty, string.Empty, reader.Name, string.Empty + reader.NodeType, reader.Value);
                                    if (IsXmlns)
                                    {
                                        string namespaceTemp = string.Empty;
                                        namespaceTemp = (namespaceURI.Length == 0) ? reader.Value : namespaceURI;
                                        if (namespaceAllowed && !prefixes.ContainsKey(namespaceTemp) && namespaceTemp.Length > 0)
                                        {
                                            stackNameSpace.Push(name);
                                            Stack namespaceStack = new Stack();
                                            namespaceStack.Push(prefixName);
                                            prefixes.Add(namespaceURI, namespaceStack);
                                            if (callBackHandler != null)
                                                ((IXmlSaxContentHandler)callBackHandler).startPrefixMapping(prefixName, namespaceTemp);
                                        }
                                        else
                                        {
                                            if (namespaceAllowed && namespaceTemp.Length > 0 && !((Stack)prefixes[namespaceTemp]).Contains(reader.Name))
                                            {
                                                ((Stack)prefixes[namespaceURI]).Push(prefixName);
                                                if (callBackHandler != null)
                                                    ((IXmlSaxContentHandler)callBackHandler).startPrefixMapping(prefixName, reader.Value);
                                            }
                                        }
                                    }
                                }
                            }

                            if (callBackHandler != null)
                                callBackHandler.startElement(namespaceURI, localName, name, attributes);
                            if (Empty)
                            {
                                if (NamespaceAllowed)
                                {
                                    if (callBackHandler != null)
                                        callBackHandler.endElement(namespaceURI, localName, name);
                                }
                                else if (callBackHandler != null)
                                    callBackHandler.endElement(string.Empty, string.Empty, name);
                            }

                            break;

                        case XmlNodeType.EndElement:
                            if (namespaceAllowed)
                            {
                                if (callBackHandler != null)
                                    callBackHandler.endElement(reader.NamespaceURI, reader.LocalName, reader.Name);
                            }
                            else if (callBackHandler != null)
                                callBackHandler.endElement(string.Empty, string.Empty, reader.Name);
                            if (namespaceAllowed && prefixes.ContainsKey(reader.NamespaceURI) &&
                                 ((Stack)stackNameSpace).Contains(reader.Name))
                            {
                                stackNameSpace.Pop();
                                Stack namespaceStack = (Stack)prefixes[reader.NamespaceURI];
                                while (namespaceStack.Count > 0)
                                {
                                    string tempString = (string)namespaceStack.Pop();
                                    if (callBackHandler != null)
                                        ((IXmlSaxContentHandler)callBackHandler).endPrefixMapping(tempString);
                                }

                                prefixes.Remove(reader.NamespaceURI);
                            }

                            break;

                        case XmlNodeType.Text:
                            if (callBackHandler != null)
                                callBackHandler.characters(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case XmlNodeType.Whitespace:
                            if (callBackHandler != null)
                                callBackHandler.ignorableWhitespace(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case XmlNodeType.ProcessingInstruction:
                            if (callBackHandler != null)
                                callBackHandler.processingInstruction(reader.Name, reader.Value);
                            break;

                        case XmlNodeType.Comment:
                            if (lexical != null)
                                lexical.comment(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case XmlNodeType.CDATA:
                            if (lexical != null)
                            {
                                lexical.startCDATA();
                                if (callBackHandler != null)
                                    callBackHandler.characters(reader.Value.ToCharArray(), 0, reader.Value.ToCharArray().Length);
                                lexical.endCDATA();
                            }

                            break;

                        case XmlNodeType.DocumentType:
                            if (lexical != null)
                            {
                                string lname = reader.Name;
                                string systemId = null;
                                if (reader.AttributeCount > 0)
                                    systemId = reader.GetAttribute(0);
                                lexical.startDTD(lname, null, systemId);
                                lexical.startEntity("[dtd]");
                                lexical.endEntity("[dtd]");
                                lexical.endDTD();
                            }

                            break;
                    }
                }

                if (callBackHandler != null)
                    callBackHandler.endDocument();
            }
            catch (XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified file and process the events over the specified handler.
        /// </summary>
        /// <param name="filepath">The file to be used.</param>
        /// <param name="handler">The handler that manages the parser events.</param>
        public virtual void parse(FileInfo filepath, IXmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    errorHandler = (XmlSaxDefaultHandler)handler;
                    entityResolver = (XmlSaxDefaultHandler)handler;
                }

                if (!(this is XmlSaxParserAdapter))
                    callBackHandler = handler;
                else
                {
                    if (callBackHandler == null)
                        callBackHandler = handler;
                }

                reader = CreateXmlReader(filepath);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        private XmlReader CreateXmlReader(FileInfo filePath)
        {
            parserFileName = filePath.FullName;
            return CreateXmlReader(new XmlTextReader(filePath.OpenRead()));
        }

        private XmlReader CreateXmlReader(string fileName)
        {
            parserFileName = fileName;
            return CreateXmlReader(new XmlTextReader(fileName));
        }

        private XmlReader CreateXmlReader(Stream stream)
        {
            parserFileName = null;
            return CreateXmlReader(new XmlTextReader(stream));
        }

        private XmlReader CreateXmlReader(Stream stream, string URI)
        {
            parserFileName = null;
            return CreateXmlReader(new XmlTextReader(URI, stream));
        }


        private XmlReader CreateXmlReader(XmlTextReader textReader)
        {
            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = (isValidating) ? ValidationType.DTD : ValidationType.None;

            // settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandle);


            XmlReader tempValidatingReader = XmlReader.Create(textReader, settings);
            return tempValidatingReader;
        }

        /// <summary>
        /// Parses the specified file path and process the events over the specified handler.
        /// </summary>
        /// <param name="filepath">The path of the file to be used.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        public virtual void parse(string filepath, IXmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    errorHandler = (XmlSaxDefaultHandler)handler;
                    entityResolver = (XmlSaxDefaultHandler)handler;
                }

                if (!(this is XmlSaxParserAdapter))
                    callBackHandler = handler;
                else
                {
                    if (callBackHandler == null)
                        callBackHandler = handler;
                }

                reader = CreateXmlReader(filepath);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over the specified handler.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        public virtual void parse(Stream stream, IXmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    errorHandler = (XmlSaxDefaultHandler)handler;
                    entityResolver = (XmlSaxDefaultHandler)handler;
                }

                if (!(this is XmlSaxParserAdapter))
                    callBackHandler = handler;
                else
                {
                    if (callBackHandler == null)
                        callBackHandler = handler;
                }

                reader = CreateXmlReader(stream);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over the specified handler, and resolves the
        /// entities with the specified URI.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        /// <param name="URI">The namespace URI for resolve external entities.</param>
        public virtual void parse(Stream stream, IXmlSaxContentHandler handler, string URI)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    errorHandler = (XmlSaxDefaultHandler)handler;
                    entityResolver = (XmlSaxDefaultHandler)handler;
                }

                if (!(this is XmlSaxParserAdapter))
                    callBackHandler = handler;
                else
                {
                    if (callBackHandler == null)
                        callBackHandler = handler;
                }

                reader = CreateXmlReader(stream, URI);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified 'XmlSourceSupport' instance and process the events over the specified handler,
        /// and resolves the entities with the specified URI.
        /// </summary>
        /// <param name="source">The 'XmlSourceSupport' that contains the XML.</param>
        /// <param name="handler">The handler that manages the parser events.</param>
        public virtual void parse(XmlSourceSupport source, IXmlSaxContentHandler handler)
        {
            if (source.Characters != null)
                parse(source.Characters.BaseStream, handler);
            else
            {
                if (source.Bytes != null)
                    parse(source.Bytes, handler);
                else
                {
                    if (source.Uri != null)
                        parse(source.Uri, handler);
                    else
                        throw new XmlException("The XmlSource class can't be null");
                }
            }
        }

        /// <summary>
        /// Parses the specified file and process the events over previously specified handler.
        /// </summary>
        /// <param name="filepath">The file with the XML.</param>
        public virtual void parse(FileInfo filepath)
        {
            try
            {
                reader = CreateXmlReader(filepath);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified file path and processes the events over previously specified handler.
        /// </summary>
        /// <param name="filepath">The path of the file with the XML.</param>
        public virtual void parse(string filepath)
        {
            try
            {
                reader = CreateXmlReader(filepath);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over previously specified handler.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        public virtual void parse(Stream stream)
        {
            try
            {
                reader = CreateXmlReader(stream);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and processes the events over previously specified handler, and resolves the
        /// external entities with the specified URI.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="URI">The namespace URI for resolve external entities.</param>
        public virtual void parse(Stream stream, string URI)
        {
            try
            {
                reader = CreateXmlReader(stream, URI);
                DoParsing();
            }
            catch (XmlException e)
            {
                if (errorHandler != null)
                    errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified 'XmlSourceSupport' and processes the events over the specified handler, and
        /// resolves the entities with the specified URI.
        /// </summary>
        /// <param name="source">The 'XmlSourceSupport' instance with the XML.</param>
        public virtual void parse(XmlSourceSupport source)
        {
            if (source.Characters != null)
                parse(source.Characters.BaseStream);
            else
            {
                if (source.Bytes != null)
                    parse(source.Bytes);
                else
                {
                    if (source.Uri != null)
                        parse(source.Uri);
                    else
                        throw new XmlException("The XmlSource class can't be null");
                }
            }
        }

        /// <summary>
        /// Manages all the exceptions that were thrown when the validation over XML fails.
        /// </summary>
        public void ValidationEventHandle(object sender, ValidationEventArgs args)
        {
            XmlSchemaException tempException = args.Exception;
            if (args.Severity == XmlSeverityType.Warning)
            {
                if (errorHandler != null)
                    errorHandler.warning(new XmlException(tempException.Message, tempException, tempException.LineNumber,
                        tempException.LinePosition));
            }
            else
            {
                if (errorHandler != null)
                    errorHandler.fatalError(new XmlException(tempException.Message, tempException, tempException.LineNumber,
                        tempException.LinePosition));
            }
        }

        /// <summary>
        /// Assigns the object that will handle all the content events.
        /// </summary>
        /// <param name="handler">The object that handles the content events.</param>
        public virtual void setContentHandler(IXmlSaxContentHandler handler)
        {
            if (handler != null)
                callBackHandler = handler;
            else
                throw new XmlException("Error assigning the Content handler: a null Content Handler was received");
        }

        /// <summary>
        /// Assigns the object that will handle all the error events.
        /// </summary>
        /// <param name="handler">The object that handles the errors events.</param>
        public virtual void setErrorHandler(IXmlSaxErrorHandler handler)
        {
            if (handler != null)
                errorHandler = handler;
            else
                throw new XmlException("Error assigning the Error handler: a null Error Handler was received");
        }

        /// <summary>
        /// Obtains the object that will handle all the content events.
        /// </summary>
        /// <returns>The object that handles the content events.</returns>
        public virtual IXmlSaxContentHandler getContentHandler()
        {
            return callBackHandler;
        }

        /// <summary>
        /// Assigns the object that will handle all the error events.
        /// </summary>
        /// <returns>The object that handles the error events.</returns>
        public virtual IXmlSaxErrorHandler getErrorHandler()
        {
            return errorHandler;
        }

        /// <summary>
        /// Returns the current entity resolver.
        /// </summary>
        /// <returns>The current entity resolver, or null if none has been registered.</returns>
        public virtual IXmlSaxEntityResolver getEntityResolver()
        {
            return entityResolver;
        }

        /// <summary>
        /// Allows an application to register an entity resolver.
        /// </summary>
        /// <param name="resolver">The entity resolver.</param>
        public virtual void setEntityResolver(IXmlSaxEntityResolver resolver)
        {
            entityResolver = resolver;
        }
    }

    /// <summary>
    /// Contains conversion support elements such as classes, interfaces and static methods.
    /// </summary>
   public class SupportClass
    {
        /*******************************/

        /// <summary>
        /// Writes the exception stack trace to the received stream
        /// </summary>
        /// <param name="throwable">Exception to obtain information from</param>
        /// <param name="stream">Output stream used to write to</param>
        public static void WriteStackTrace(Exception throwable, TextWriter stream)
        {
            stream.Write(throwable.StackTrace);
            stream.Flush();
        }

        /*******************************/

        /// <summary>
        /// SupportClass for the Stack class.
        /// </summary>
        public class StackSupport
        {
            /// <summary>
            /// Removes the element at the top of the stack and returns it.
            /// </summary>
            /// <param name="stack">The stack where the element at the top will be returned and removed.</param>
            /// <returns>The element at the top of the stack.</returns>
            public static object Pop(ArrayList stack)
            {
                object obj = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);

                return obj;
            }
        }

        /*******************************/

        /// <summary>
        /// Copies an array of chars obtained from a String into a specified array of chars
        /// </summary>
        /// <param name="sourceString">The String to get the chars from</param>
        /// <param name="sourceStart">Position of the String to start getting the chars</param>
        /// <param name="sourceEnd">Position of the String to end getting the chars</param>
        /// <param name="destinationArray">Array to return the chars</param>
        /// <param name="destinationStart">Position of the destination array of chars to start storing the chars</param>
        /// <returns>An array of chars</returns>
        public static void GetCharsFromString(string sourceString, int sourceStart, int sourceEnd, char[] destinationArray,
            int destinationStart)
        {
            int sourceCounter;
            int destinationCounter;
            sourceCounter = sourceStart;
            destinationCounter = destinationStart;
            while (sourceCounter < sourceEnd)
            {
                destinationArray[destinationCounter] = (char)sourceString[sourceCounter];
                sourceCounter++;
                destinationCounter++;
            }
        }

        /*******************************/


        /// <summary>
        /// This class provides functionality not found in .NET collection-related interfaces.
        /// </summary>
        public class ICollectionSupport
        {
            /// <summary>
            /// Adds a new element to the specified collection.
            /// </summary>
            /// <param name="c">Collection where the new element will be added.</param>
            /// <param name="obj">Object to add.</param>
            /// <returns>true</returns>
            public static bool Add(ICollection c, object obj)
            {
                bool added = false;

                // Reflection. Invoke either the "add" or "Add" method.
                MethodInfo method;
                try
                {
                    // Get the "add" method for proprietary classes
                    method = c.GetType().GetMethod("Add");
                    if (method == null)
                        method = c.GetType().GetMethod("add");
                    int index = (int)method.Invoke(c, new object[] { obj });
                    if (index >= 0)
                        added = true;
                }
                catch (Exception e)
                {
                    throw e;
                }

                return added;
            }

            /// <summary>
            /// Adds all of the elements of the "c" collection to the "target" collection.
            /// </summary>
            /// <param name="target">Collection where the new elements will be added.</param>
            /// <param name="c">Collection whose elements will be added.</param>
            /// <returns>Returns true if at least one element was added, false otherwise.</returns>
            public static bool AddAll(ICollection target, ICollection c)
            {
                IEnumerator e = new ArrayList(c).GetEnumerator();
                bool added = false;

                // Reflection. Invoke "addAll" method for proprietary classes
                MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("addAll");

                    if (method != null)
                        added = (bool)method.Invoke(target, new object[] { c });
                    else
                    {
                        method = target.GetType().GetMethod("Add");
                        while (e.MoveNext() == true)
                        {
                            bool tempBAdded = (int)method.Invoke(target, new object[] { e.Current }) >= 0;
                            added = added ? added : tempBAdded;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return added;
            }

            /// <summary>
            /// Removes all the elements from the collection.
            /// </summary>
            /// <param name="c">The collection to remove elements.</param>
            public static void Clear(ICollection c)
            {
                // Reflection. Invoke "Clear" method or "clear" method for proprietary classes
                MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("Clear");

                    if (method == null)
                        method = c.GetType().GetMethod("clear");

                    method.Invoke(c, new object[] { });
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            /// <summary>
            /// Determines whether the collection contains the specified element.
            /// </summary>
            /// <param name="c">The collection to check.</param>
            /// <param name="obj">The object to locate in the collection.</param>
            /// <returns>true if the element is in the collection.</returns>
            public static bool Contains(ICollection c, object obj)
            {
                bool contains = false;

                // Reflection. Invoke "contains" method for proprietary classes
                MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("Contains");

                    if (method == null)
                        method = c.GetType().GetMethod("contains");

                    contains = (bool)method.Invoke(c, new object[] { obj });
                }
                catch (Exception e)
                {
                    throw e;
                }

                return contains;
            }

            /// <summary>
            /// Determines whether the collection contains all the elements in the specified collection.
            /// </summary>
            /// <param name="target">The collection to check.</param>
            /// <param name="c">Collection whose elements would be checked for containment.</param>
            /// <returns>true id the target collection contains all the elements of the specified collection.</returns>
            public static bool ContainsAll(ICollection target, ICollection c)
            {
                IEnumerator e = c.GetEnumerator();

                bool contains = false;

                // Reflection. Invoke "containsAll" method for proprietary classes or "Contains" method for each element in the collection
                MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("containsAll");

                    if (method != null)
                        contains = (bool)method.Invoke(target, new object[] { c });
                    else
                    {
                        method = target.GetType().GetMethod("Contains");
                        while (e.MoveNext() == true)
                        {
                            if ((contains = (bool)method.Invoke(target, new object[] { e.Current })) == false)
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return contains;
            }

            /// <summary>
            /// Removes the specified element from the collection.
            /// </summary>
            /// <param name="c">The collection where the element will be removed.</param>
            /// <param name="obj">The element to remove from the collection.</param>
            public static bool Remove(ICollection c, object obj)
            {
                bool changed = false;

                // Reflection. Invoke "remove" method for proprietary classes or "Remove" method
                MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("remove");

                    if (method != null)
                        method.Invoke(c, new object[] { obj });
                    else
                    {
                        method = c.GetType().GetMethod("Contains");
                        changed = (bool)method.Invoke(c, new object[] { obj });
                        method = c.GetType().GetMethod("Remove");
                        method.Invoke(c, new object[] { obj });
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return changed;
            }

            /// <summary>
            /// Removes all the elements from the specified collection that are contained in the target collection.
            /// </summary>
            /// <param name="target">Collection where the elements will be removed.</param>
            /// <param name="c">Elements to remove from the target collection.</param>
            /// <returns>true</returns>
            public static bool RemoveAll(ICollection target, ICollection c)
            {
                ArrayList al = ToArrayList(c);
                IEnumerator e = al.GetEnumerator();

                // Reflection. Invoke "removeAll" method for proprietary classes or "Remove" for each element in the collection
                MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("removeAll");

                    if (method != null)
                        method.Invoke(target, new object[] { al });
                    else
                    {
                        method = target.GetType().GetMethod("Remove");
                        MethodInfo methodContains = target.GetType().GetMethod("Contains");

                        while (e.MoveNext() == true)
                        {
                            while ((bool)methodContains.Invoke(target, new object[] { e.Current }) == true)
                                method.Invoke(target, new object[] { e.Current });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            /// <summary>
            /// Retains the elements in the target collection that are contained in the specified collection
            /// </summary>
            /// <param name="target">Collection where the elements will be removed.</param>
            /// <param name="c">Elements to be retained in the target collection.</param>
            /// <returns>true</returns>
            public static bool RetainAll(ICollection target, ICollection c)
            {
                IEnumerator e = new ArrayList(target).GetEnumerator();
                ArrayList al = new ArrayList(c);

                // Reflection. Invoke "retainAll" method for proprietary classes or "Remove" for each element in the collection
                MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("retainAll");

                    if (method != null)
                        method.Invoke(target, new object[] { c });
                    else
                    {
                        method = c.GetType().GetMethod("Remove");

                        while (e.MoveNext() == true)
                        {
                            if (al.Contains(e.Current) == false)
                                method.Invoke(target, new object[] { e.Current });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            /// <summary>
            /// Returns an array containing all the elements of the collection.
            /// </summary>
            /// <returns>The array containing all the elements of the collection.</returns>
            public static object[] ToArray(ICollection c)
            {
                int index = 0;
                object[] objects = new object[c.Count];
                IEnumerator e = c.GetEnumerator();

                while (e.MoveNext())
                    objects[index++] = e.Current;

                return objects;
            }

            /// <summary>
            /// Obtains an array containing all the elements of the collection.
            /// </summary>
            /// <param name="objects">The array into which the elements of the collection will be stored.</param>
            /// <param name="c"></param>
            /// <returns>The array containing all the elements of the collection.</returns>
            public static object[] ToArray(ICollection c, object[] objects)
            {
                int index = 0;

                Type type = objects.GetType().GetElementType();
                object[] objs = (object[])Array.CreateInstance(type, c.Count);

                IEnumerator e = c.GetEnumerator();

                while (e.MoveNext())
                    objs[index++] = e.Current;

                // If objects is smaller than c then do not return the new array in the parameter
                if (objects.Length >= c.Count)
                    objs.CopyTo(objects, 0);

                return objs;
            }

            /// <summary>
            /// Converts an ICollection instance to an ArrayList instance.
            /// </summary>
            /// <param name="c">The ICollection instance to be converted.</param>
            /// <returns>An ArrayList instance in which its elements are the elements of the ICollection instance.</returns>
            public static ArrayList ToArrayList(ICollection c)
            {
                ArrayList tempArrayList = new ArrayList();
                IEnumerator tempEnumerator = c.GetEnumerator();
                while (tempEnumerator.MoveNext())
                    tempArrayList.Add(tempEnumerator.Current);
                return tempArrayList;
            }
        }

        /*******************************/

        /// <summary>
        /// Represents a collection ob objects that contains no duplicate elements.
        /// </summary>
        public interface ISetSupport : ICollection, IList
        {
            /// <summary>
            /// Adds a new element to the Collection if it is not already present.
            /// </summary>
            /// <param name="obj">The object to add to the collection.</param>
            /// <returns>Returns true if the object was added to the collection, otherwise false.</returns>
            new bool Add(object obj);

            /// <summary>
            /// Adds all the elements of the specified collection to the Set.
            /// </summary>
            /// <param name="c">Collection of objects to add.</param>
            /// <returns>true</returns>
            bool AddAll(ICollection c);
        }


        /*******************************/

        /// <summary>
        /// SupportClass for the HashSet class.
        /// </summary>
        [Serializable]
        public class HashSetSupport : ArrayList, ISetSupport
        {
            public HashSetSupport()
                : base()
            {
            }

            public HashSetSupport(ICollection c)
            {
                AddAll(c);
            }

            public HashSetSupport(int capacity)
                : base(capacity)
            {
            }

            /// <summary>
            /// Adds a new element to the ArrayList if it is not already present.
            /// </summary>
            /// <param name="obj">Element to insert to the ArrayList.</param>
            /// <returns>Returns true if the new element was inserted, false otherwise.</returns>
            public new virtual bool Add(object obj)
            {
                bool inserted;

                if ((inserted = Contains(obj)) == false)
                {
                    base.Add(obj);
                }

                return !inserted;
            }

            /// <summary>
            /// Adds all the elements of the specified collection that are not present to the list.
            /// </summary>
            /// <param name="c">Collection where the new elements will be added</param>
            /// <returns>Returns true if at least one element was added, false otherwise.</returns>
            public bool AddAll(ICollection c)
            {
                IEnumerator e = new ArrayList(c).GetEnumerator();
                bool added = false;

                while (e.MoveNext() == true)
                {
                    if (Add(e.Current) == true)
                        added = true;
                }

                return added;
            }

            /// <summary>
            /// Returns a copy of the HashSet instance.
            /// </summary>
            /// <returns>Returns a shallow copy of the current HashSet.</returns>
            public override object Clone()
            {
                return base.MemberwiseClone();
            }
        }


        /*******************************/

        /// <summary>
        /// This class manages different features for calendars.
        /// The different calendars are internally managed using a hash table structure.
        /// </summary>
        public class CalendarManager
        {
            public const int ZONE_OFFSET = 0;
            public const int DST_OFFSET = 0;

            /// <summary>
            /// Field used to get or set the year.
            /// </summary>
            public const int YEAR = 1;

            /// <summary>
            /// Field used to get or set the month.
            /// </summary>
            public const int MONTH = 2;

            /// <summary>
            /// Field used to get or set the day of the month.
            /// </summary>
            public const int DATE = 5;

            /// <summary>
            /// Field used to get or set the hour of the morning or afternoon.
            /// </summary>
            public const int HOUR = 10;

            /// <summary>
            /// Field used to get or set the minute within the hour.
            /// </summary>
            public const int MINUTE = 12;

            /// <summary>
            /// Field used to get or set the second within the minute.
            /// </summary>
            public const int SECOND = 13;

            /// <summary>
            /// Field used to get or set the millisecond within the second.
            /// </summary>
            public const int MILLISECOND = 14;

            /// <summary>
            /// Field used to get or set the day of the year.
            /// </summary>
            public const int DAY_OF_YEAR = 4;

            /// <summary>
            /// Field used to get or set the day of the month.
            /// </summary>
            public const int DAY_OF_MONTH = 6;

            /// <summary>
            /// Field used to get or set the day of the week.
            /// </summary>
            public const int DAY_OF_WEEK = 7;

            /// <summary>
            /// Field used to get or set the hour of the day.
            /// </summary>
            public const int HOUR_OF_DAY = 11;

            /// <summary>
            /// Field used to get or set whether the HOUR is before or after noon.
            /// </summary>
            public const int AM_PM = 9;

            /// <summary>
            /// Field used to get or set the value of the AM_PM field which indicates the period of the day from midnight to just before noon.
            /// </summary>
            public const int AM = 0;

            /// <summary>
            /// Field used to get or set the value of the AM_PM field which indicates the period of the day from noon to just before midnight.
            /// </summary>
            public const int PM = 1;

            /// <summary>
            /// The hash table that contains the calendars and its properties.
            /// </summary>
            public static CalendarHashTable manager = new CalendarHashTable();

            /// <summary>
            /// Internal class that inherits from HashTable to manage the different calendars.
            /// This structure will contain an instance of System.Globalization.Calendar that represents
            /// a type of calendar and its properties (represented by an instance of CalendarProperties
            /// class).
            /// </summary>
            public class CalendarHashTable : Hashtable
            {
                /// <summary>
                /// Gets the calendar current date and time.
                /// </summary>
                /// <param name="calendar">The calendar to get its current date and time.</param>
                /// <returns>A System.DateTime value that indicates the current date and time for the
                /// calendar given.</returns>
                public DateTime GetDateTime(Calendar calendar)
                {
                    if (this[calendar] != null)
                        return ((CalendarProperties)this[calendar]).dateTime;
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        Add(calendar, tempProps);
                        return GetDateTime(calendar);
                    }
                }

                /// <summary>
                /// Sets the specified System.DateTime value to the specified calendar.
                /// </summary>
                /// <param name="calendar">The calendar to set its date.</param>
                /// <param name="date">The System.DateTime value to set to the calendar.</param>
                public void SetDateTime(Calendar calendar, DateTime date)
                {
                    if (this[calendar] != null)
                    {
                        ((CalendarProperties)this[calendar]).dateTime = date;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = date;
                        Add(calendar, tempProps);
                    }
                }

                /// <summary>
                /// Sets the corresponding field in an specified calendar with the value given.
                /// If the specified calendar does not have exist in the hash table, it creates a
                /// new instance of the calendar with the current date and time and then assigns it
                /// the new specified value.
                /// </summary>
                /// <param name="calendar">The calendar to set its date or time.</param>
                /// <param name="field">One of the fields that composes a date/time.</param>
                /// <param name="fieldValue">The value to be set.</param>
                public void Set(Calendar calendar, int field, int fieldValue)
                {
                    if (this[calendar] != null)
                    {
                        DateTime tempDate = ((CalendarProperties)this[calendar]).dateTime;
                        switch (field)
                        {
                            case DATE:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                                break;
                            case HOUR:
                                tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
                                break;
                            case MILLISECOND:
                                tempDate = tempDate.AddMilliseconds(fieldValue - tempDate.Millisecond);
                                break;
                            case MINUTE:
                                tempDate = tempDate.AddMinutes(fieldValue - tempDate.Minute);
                                break;
                            case MONTH:
                                // Month value is 0-based. e.g., 0 for January
                                tempDate = tempDate.AddMonths((fieldValue + 1) - tempDate.Month);
                                break;
                            case SECOND:
                                tempDate = tempDate.AddSeconds(fieldValue - tempDate.Second);
                                break;
                            case YEAR:
                                tempDate = tempDate.AddYears(fieldValue - tempDate.Year);
                                break;
                            case DAY_OF_MONTH:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                                break;
                            case DAY_OF_WEEK:
                                tempDate = tempDate.AddDays((fieldValue - 1) - (int)tempDate.DayOfWeek);
                                break;
                            case DAY_OF_YEAR:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.DayOfYear);
                                break;
                            case HOUR_OF_DAY:
                                tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
                                break;

                            default:
                                break;
                        }

                        ((CalendarProperties)this[calendar]).dateTime = tempDate;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        Add(calendar, tempProps);
                        Set(calendar, field, fieldValue);
                    }
                }

                /// <summary>
                /// Sets the corresponding date (day, month and year) to the calendar specified.
                /// If the calendar does not exist in the hash table, it creates a new instance and sets
                /// its values.
                /// </summary>
                /// <param name="calendar">The calendar to set its date.</param>
                /// <param name="year">Integer value that represent the year.</param>
                /// <param name="month">Integer value that represent the month.</param>
                /// <param name="day">Integer value that represent the day.</param>
                public void Set(Calendar calendar, int year, int month, int day)
                {
                    if (this[calendar] != null)
                    {
                        Set(calendar, YEAR, year);
                        Set(calendar, MONTH, month);
                        Set(calendar, DATE, day);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        Add(calendar, tempProps);
                        Set(calendar, year, month, day);
                    }
                }

                /// <summary>
                /// Sets the corresponding date (day, month and year) and hour (hour and minute)
                /// to the calendar specified.
                /// If the calendar does not exist in the hash table, it creates a new instance and sets
                /// its values.
                /// </summary>
                /// <param name="calendar">The calendar to set its date and time.</param>
                /// <param name="year">Integer value that represent the year.</param>
                /// <param name="month">Integer value that represent the month.</param>
                /// <param name="day">Integer value that represent the day.</param>
                /// <param name="hour">Integer value that represent the hour.</param>
                /// <param name="minute">Integer value that represent the minutes.</param>
                public void Set(Calendar calendar, int year, int month, int day, int hour, int minute)
                {
                    if (this[calendar] != null)
                    {
                        Set(calendar, YEAR, year);
                        Set(calendar, MONTH, month);
                        Set(calendar, DATE, day);
                        Set(calendar, HOUR, hour);
                        Set(calendar, MINUTE, minute);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        Add(calendar, tempProps);
                        Set(calendar, year, month, day, hour, minute);
                    }
                }

                /// <summary>
                /// Sets the corresponding date (day, month and year) and hour (hour, minute and second)
                /// to the calendar specified.
                /// If the calendar does not exist in the hash table, it creates a new instance and sets
                /// its values.
                /// </summary>
                /// <param name="calendar">The calendar to set its date and time.</param>
                /// <param name="year">Integer value that represent the year.</param>
                /// <param name="month">Integer value that represent the month.</param>
                /// <param name="day">Integer value that represent the day.</param>
                /// <param name="hour">Integer value that represent the hour.</param>
                /// <param name="minute">Integer value that represent the minutes.</param>
                /// <param name="second">Integer value that represent the seconds.</param>
                public void Set(Calendar calendar, int year, int month, int day, int hour, int minute, int second)
                {
                    if (this[calendar] != null)
                    {
                        Set(calendar, YEAR, year);
                        Set(calendar, MONTH, month);
                        Set(calendar, DATE, day);
                        Set(calendar, HOUR, hour);
                        Set(calendar, MINUTE, minute);
                        Set(calendar, SECOND, second);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        Add(calendar, tempProps);
                        Set(calendar, year, month, day, hour, minute, second);
                    }
                }

                /// <summary>
                /// Gets the value represented by the field specified.
                /// </summary>
                /// <param name="calendar">The calendar to get its date or time.</param>
                /// <param name="field">One of the field that composes a date/time.</param>
                /// <returns>The integer value for the field given.</returns>
                public int Get(Calendar calendar, int field)
                {
                    if (this[calendar] != null)
                    {
                        int tempHour;
                        switch (field)
                        {
                            case DATE:
                                return ((CalendarProperties)this[calendar]).dateTime.Day;
                            case HOUR:
                                tempHour = ((CalendarProperties)this[calendar]).dateTime.Hour;
                                return tempHour > 12 ? tempHour - 12 : tempHour;
                            case MILLISECOND:
                                return ((CalendarProperties)this[calendar]).dateTime.Millisecond;
                            case MINUTE:
                                return ((CalendarProperties)this[calendar]).dateTime.Minute;
                            case MONTH:
                                // Month value is 0-based. e.g., 0 for January
                                return ((CalendarProperties)this[calendar]).dateTime.Month - 1;
                            case SECOND:
                                return ((CalendarProperties)this[calendar]).dateTime.Second;
                            case YEAR:
                                return ((CalendarProperties)this[calendar]).dateTime.Year;
                            case DAY_OF_MONTH:
                                return ((CalendarProperties)this[calendar]).dateTime.Day;
                            case DAY_OF_YEAR:
                                return (int)(((CalendarProperties)this[calendar]).dateTime.DayOfYear);
                            case DAY_OF_WEEK:
                                return (int)(((CalendarProperties)this[calendar]).dateTime.DayOfWeek) + 1;
                            case HOUR_OF_DAY:
                                return ((CalendarProperties)this[calendar]).dateTime.Hour;
                            case AM_PM:
                                tempHour = ((CalendarProperties)this[calendar]).dateTime.Hour;
                                return tempHour > 12 ? PM : AM;

                            default:
                                return 0;
                        }
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        Add(calendar, tempProps);
                        return Get(calendar, field);
                    }
                }

                /// <summary>
                /// Sets the time in the specified calendar with the long value.
                /// </summary>
                /// <param name="calendar">The calendar to set its date and time.</param>
                /// <param name="milliseconds">A long value that indicates the milliseconds to be set to
                /// the hour for the calendar.</param>
                public void SetTimeInMilliseconds(Calendar calendar, long milliseconds)
                {
                    if (this[calendar] != null)
                    {
                        ((CalendarProperties)this[calendar]).dateTime = new DateTime(milliseconds);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = new DateTime(TimeSpan.TicksPerMillisecond * milliseconds);
                        Add(calendar, tempProps);
                    }
                }

                /// <summary>
                /// Gets what the first day of the week is; e.g., Sunday in US, Monday in France.
                /// </summary>
                /// <param name="calendar">The calendar to get its first day of the week.</param>
                /// <returns>A System.DayOfWeek value indicating the first day of the week.</returns>
                public DayOfWeek GetFirstDayOfWeek(Calendar calendar)
                {
                    if (this[calendar] != null)
                    {
                        if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
                        {
                            ((CalendarProperties)this[calendar]).dateTimeFormat = new DateTimeFormatInfo();
                            ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek = DayOfWeek.Sunday;
                        }

                        return ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        tempProps.dateTimeFormat = new DateTimeFormatInfo();
                        tempProps.dateTimeFormat.FirstDayOfWeek = DayOfWeek.Sunday;
                        Add(calendar, tempProps);
                        return GetFirstDayOfWeek(calendar);
                    }
                }

                /// <summary>
                /// Sets what the first day of the week is; e.g., Sunday in US, Monday in France.
                /// </summary>
                /// <param name="calendar">The calendar to set its first day of the week.</param>
                /// <param name="firstDayOfWeek">A System.DayOfWeek value indicating the first day of the week
                /// to be set.</param>
                public void SetFirstDayOfWeek(Calendar calendar, DayOfWeek firstDayOfWeek)
                {
                    if (this[calendar] != null)
                    {
                        if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
                            ((CalendarProperties)this[calendar]).dateTimeFormat = new DateTimeFormatInfo();

                        ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek = firstDayOfWeek;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = DateTime.Now;
                        tempProps.dateTimeFormat = new DateTimeFormatInfo();
                        Add(calendar, tempProps);
                        SetFirstDayOfWeek(calendar, firstDayOfWeek);
                    }
                }

                /// <summary>
                /// Removes the specified calendar from the hash table.
                /// </summary>
                /// <param name="calendar">The calendar to be removed.</param>
                public void Clear(Calendar calendar)
                {
                    if (this[calendar] != null)
                        Remove(calendar);
                }

                /// <summary>
                /// Removes the specified field from the calendar given.
                /// If the field does not exists in the calendar, the calendar is removed from the table.
                /// </summary>
                /// <param name="calendar">The calendar to remove the value from.</param>
                /// <param name="field">The field to be removed from the calendar.</param>
                public void Clear(Calendar calendar, int field)
                {
                    if (this[calendar] != null)
                        Set(calendar, field, 0);
                }

                /// <summary>
                /// Internal class that represents the properties of a calendar instance.
                /// </summary>
                private class CalendarProperties
                {
                    /// <summary>
                    /// The date and time of a calendar.
                    /// </summary>
                    public DateTime dateTime;

                    /// <summary>
                    /// The format for the date and time in a calendar.
                    /// </summary>
                    public DateTimeFormatInfo dateTimeFormat;
                }
            }
        }

        /*******************************/

        /// <summary>
        /// Support class used to handle threads
        /// </summary>
        public class ThreadClass : IThreadRunnable
        {
            /// <summary>
            /// The instance of System.Threading.Thread
            /// </summary>
            private Thread threadField;

            /// <summary>
            /// Initializes a new instance of the ThreadClass class
            /// </summary>
            public ThreadClass()
            {
                threadField = new Thread(new ThreadStart(Run));
            }

            /// <summary>
            /// Initializes a new instance of the Thread class.
            /// </summary>
            /// <param name="Name">The name of the thread</param>
            public ThreadClass(string Name)
            {
                threadField = new Thread(new ThreadStart(Run));
                this.Name = Name;
            }

            /// <summary>
            /// Initializes a new instance of the Thread class.
            /// </summary>
            /// <param name="Start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
            public ThreadClass(ThreadStart Start)
            {
                threadField = new Thread(Start);
            }

            /// <summary>
            /// Initializes a new instance of the Thread class.
            /// </summary>
            /// <param name="Start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
            /// <param name="Name">The name of the thread</param>
            public ThreadClass(ThreadStart Start, string Name)
            {
                threadField = new Thread(Start);
                this.Name = Name;
            }

            /// <summary>
            /// This method has no functionality unless the method is overridden
            /// </summary>
            public virtual void Run()
            {
            }

            /// <summary>
            /// Causes the operating system to change the state of the current thread instance to ThreadState.Running
            /// </summary>
            public virtual void Start()
            {
                threadField.Start();
            }

            /// <summary>
            /// Interrupts a thread that is in the WaitSleepJoin thread state
            /// </summary>
            public virtual void Interrupt()
            {
                threadField.Interrupt();
            }

            /// <summary>
            /// Gets the current thread instance
            /// </summary>
            public Thread Instance
            {
                get { return threadField; }
                set { threadField = value; }
            }

            /// <summary>
            /// Gets or sets the name of the thread
            /// </summary>
            public string Name
            {
                get { return threadField.Name; }

                set
                {
                    if (threadField.Name == null)
                        threadField.Name = value;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating the scheduling priority of a thread
            /// </summary>
            public ThreadPriority Priority
            {
                get { return threadField.Priority; }
                set { threadField.Priority = value; }
            }

            /// <summary>
            /// Gets a value indicating the execution status of the current thread
            /// </summary>
            public bool IsAlive
            {
                get { return threadField.IsAlive; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether or not a thread is a background thread.
            /// </summary>
            public bool IsBackground
            {
                get { return threadField.IsBackground; }
                set { threadField.IsBackground = value; }
            }

            /// <summary>
            /// Blocks the calling thread until a thread terminates
            /// </summary>
            public void Join()
            {
                threadField.Join();
            }

            /// <summary>
            /// Blocks the calling thread until a thread terminates or the specified time elapses
            /// </summary>
            /// <param name="MiliSeconds">Time of wait in milliseconds</param>
            public void Join(long MiliSeconds)
            {
                lock (this)
                {
                    threadField.Join(new TimeSpan(MiliSeconds * 10000));
                }
            }

            /// <summary>
            /// Blocks the calling thread until a thread terminates or the specified time elapses
            /// </summary>
            /// <param name="MiliSeconds">Time of wait in milliseconds</param>
            /// <param name="NanoSeconds">Time of wait in nanoseconds</param>
            public void Join(long MiliSeconds, int NanoSeconds)
            {
                lock (this)
                {
                    threadField.Join(new TimeSpan(MiliSeconds * 10000 + NanoSeconds * 100));
                }
            }

            /// <summary>
            /// Raises a ThreadAbortException in the thread on which it is invoked,
            /// to begin the process of terminating the thread. Calling this method
            /// usually terminates the thread
            /// </summary>
            public void Abort()
            {
                threadField.Abort();
            }

            /// <summary>
            /// Raises a ThreadAbortException in the thread on which it is invoked,
            /// to begin the process of terminating the thread while also providing
            /// exception information about the thread termination.
            /// Calling this method usually terminates the thread.
            /// </summary>
            /// <param name="stateInfo">An object that contains application-specific information, such as state, which can be used by the thread being aborted</param>
            public void Abort(object stateInfo)
            {
                lock (this)
                {
                    threadField.Abort(stateInfo);
                }
            }

            /// <summary>
            /// Obtain a String that represents the current Object
            /// </summary>
            /// <returns>A String that represents the current Object</returns>
            public override string ToString()
            {
                return "Thread[" + Name + "," + Priority.ToString() + "," + string.Empty + "]";
            }

            /// <summary>
            /// Gets the currently running thread
            /// </summary>
            /// <returns>The currently running thread</returns>
            public static ThreadClass Current()
            {
                ThreadClass CurrentThread = new ThreadClass();
                CurrentThread.Instance = Thread.CurrentThread;
                return CurrentThread;
            }
        }


        /*******************************/

        /// <summary>
        /// The class performs token processing in strings
        /// </summary>
        public class Tokenizer : IEnumerator
        {
            /// Position over the string
            private long currentPos = 0;

            /// Include delimiters in the results.
            private bool includeDelims = false;

            /// Char representation of the String to tokenize.
            private char[] chars = null;

            // The tokenizer uses the default delimiter set: the space character, the tab character, the newline character, and the carriage-return character and the form-feed character
            private string delimiters = " \t\n\r\f";

            /// <summary>
            /// Initializes a new class instance with a specified string to process
            /// </summary>
            /// <param name="source">String to tokenize</param>
            public Tokenizer(string source)
            {
                chars = source.ToCharArray();
            }

            /// <summary>
            /// Initializes a new class instance with a specified string to process
            /// and the specified token delimiters to use
            /// </summary>
            /// <param name="source">String to tokenize</param>
            /// <param name="delimiters">String containing the delimiters</param>
            public Tokenizer(string source, string delimiters)
                : this(source)
            {
                this.delimiters = delimiters;
            }


            /// <summary>
            /// Initializes a new class instance with a specified string to process, the specified token
            /// delimiters to use, and whether the delimiters must be included in the results.
            /// </summary>
            /// <param name="source">String to tokenize</param>
            /// <param name="delimiters">String containing the delimiters</param>
            /// <param name="includeDelims">Determines if delimiters are included in the results.</param>
            public Tokenizer(string source, string delimiters, bool includeDelims)
                : this(source, delimiters)
            {
                this.includeDelims = includeDelims;
            }


            /// <summary>
            /// Returns the next token from the token list
            /// </summary>
            /// <returns>The string value of the token</returns>
            public string NextToken()
            {
                if (cache_HasNextToken)
                {
                    currentPos = cache_NextTokenPosition;
                    cache_HasNextToken = false;
                    return cache_NextToken;
                }

                return NextToken(delimiters);
            }

            /// <summary>
            /// Returns the next token from the source string, using the provided
            /// token delimiters
            /// </summary>
            /// <param name="delimiters">String containing the delimiters to use</param>
            /// <returns>The string value of the token</returns>
            public string NextToken(string delimiters)
            {
                // According to documentation, the usage of the received delimiters should be temporary (only for this call).
                // However, it seems it is not true, so the following line is necessary.
                this.delimiters = delimiters;

                // at the end
                if (currentPos == chars.Length)
                    throw new ArgumentOutOfRangeException();

                // if over a delimiter and delimiters must be returned
                else if ((Array.IndexOf(delimiters.ToCharArray(), chars[currentPos]) != -1)
                            && includeDelims)
                    return string.Empty + chars[currentPos++];

                // need to get the token wo delimiters.
                else
                    return nextToken(delimiters.ToCharArray());
            }

            // Returns the nextToken wo delimiters
            private string nextToken(char[] delimiters)
            {
                StringBuilder token = new StringBuilder();
                long pos = currentPos;

                // skip possible delimiters
                while (Array.IndexOf(delimiters, chars[currentPos]) != -1)

                    // The last one is a delimiter (i.e there is no more tokens)
                    if (++currentPos == chars.Length)
                    {
                        currentPos = pos;
                        throw new ArgumentOutOfRangeException();
                    }

                // getting the token
                while (Array.IndexOf(delimiters, chars[currentPos]) == -1)
                {
                    token.Append(chars[currentPos]);

                    // the last one is not a delimiter
                    if (++currentPos == chars.Length)
                        break;
                }

                return token.ToString();
            }

            private bool cache_HasNextToken = false;
            private string cache_NextToken = null;
            private long cache_NextTokenPosition = 0;

            /// <summary>
            /// Determines if there are more tokens to return from the source string
            /// </summary>
            /// <returns>True or false, depending if there are more tokens</returns>
            public bool HasMoreTokens()
            {
                // rlb: Attempt to improve performance by checking just based on length,
                //      this should generally improve performance.
                if (chars.Length == 0 || chars.Length == currentPos)
                {
                    return false;
                }

                // keeping the current pos
                long pos = currentPos;

                try
                {
                    cache_NextToken = NextToken();
                    cache_NextTokenPosition = currentPos;
                    cache_HasNextToken = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return false;
                }
                finally
                {
                    currentPos = pos;
                }

                return true;
            }

            /// <summary>
            /// Remaining tokens count
            /// </summary>
            public int Count
            {
                get
                {
                    // keeping the current pos
                    long pos = currentPos;
                    int i = 0;

                    try
                    {
                        while (true)
                        {
                            NextToken();
                            i++;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        currentPos = pos;
                        return i;
                    }
                }
            }

            /// <summary>
            ///  Performs the same action as NextToken.
            /// </summary>
            public object Current
            {
                get { return (object)NextToken(); }
            }

            /// <summary>
            /// Performs the same action as HasMoreTokens.
            /// </summary>
            /// <returns>True or false, depending if there are more tokens</returns>
            public bool MoveNext()
            {
                return HasMoreTokens();
            }

            /// <summary>
            /// Does nothing.
            /// </summary>
            public void Reset()
            {
                ;
            }
        }

        /*******************************/

        /// <summary>
        /// Checks if the giving File instance is a directory or file, and returns his Length
        /// </summary>
        /// <param name="file">The File instance to check</param>
        /// <returns>The length of the file</returns>
        public static long FileLength(FileInfo file)
        {
            if (file.Exists)
                return file.Length;
            else
                return 0;
        }
    }
}