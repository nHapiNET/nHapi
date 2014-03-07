//
// In order to convert some functionality to Visual C#, the Java Language Conversion Assistant
// creates "support classes" that duplicate the original functionality.  
//
// Support classes replicate the functionality of the original code, but in some cases they are 
// substantially different architecturally. Although every effort is made to preserve the 
// original architecture of the application in the converted project, the user should be aware that 
// the primary goal of these support classes is to replicate functionality, and that at times 
// the architecture of the resulting solution may differ somewhat.
//

using System;
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
        /// This method manage an error exception ocurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void error(System.Xml.XmlException exception);

        /// <summary>
        /// This method manage a fatal error exception ocurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void fatalError(System.Xml.XmlException exception);

        /// <summary>
        /// This method manage a warning exception ocurred during the parsing process.
        /// </summary>
        /// <param name="exception">The exception thrown by the parser.</param>
        void warning(System.Xml.XmlException exception);
    }

    /*******************************/
    /// <summary>
    /// This class is used to encapsulate a source of Xml code in an single class.
    /// </summary>
    public class XmlSourceSupport
    {
        private System.IO.Stream bytes;
        private System.IO.StreamReader characters;
        private System.String uri;

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
        public XmlSourceSupport(System.IO.Stream stream)
        {
            bytes = stream;
            characters = null;
            uri = null;
        }

        /// <summary>
        /// Constructs a XmlSource instance with the specified source System.IO.StreamReader.
        /// </summary>
        /// <param name="reader">The reader containing the document.</param>
        public XmlSourceSupport(System.IO.StreamReader reader)
        {
            bytes = null;
            characters = reader;
            uri = null;
        }

        /// <summary>
        /// Construct a XmlSource instance with the specified source Uri string.
        /// </summary>
        /// <param name="source">The source containing the document.</param>
        public XmlSourceSupport(System.String source)
        {
            bytes = null;
            characters = null;
            uri = source;
        }

        /// <summary>
        /// Represents the source Stream of the XmlSource.
        /// </summary>
        public System.IO.Stream Bytes
        {
            get
            {
                return bytes;
            }
            set
            {
                bytes = value;
            }
        }

        /// <summary>
        /// Represents the source StreamReader of the XmlSource.
        /// </summary>
        public System.IO.StreamReader Characters
        {
            get
            {
                return characters;
            }
            set
            {
                characters = value;
            }
        }

        /// <summary>
        /// Represents the source URI of the XmlSource.
        /// </summary>
        public System.String Uri
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
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
        XmlSourceSupport resolveEntity(System.String publicId, System.String systemId);
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
        void endElement(System.String namespaceURI, System.String localName, System.String qName);

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends.</param>
        void endPrefixMapping(System.String prefix);

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
        void processingInstruction(System.String target, System.String data);

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// </summary>
        void setDocumentLocator(IXmlSaxLocator locator);

        /// <summary>
        /// This method manage the event when a skipped entity was found.
        /// </summary>
        /// <param name="name">The name of the skipped entity.</param>
        void skippedEntity(System.String name);

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
        void startElement(System.String namespaceURI, System.String localName, System.String qName, SaxAttributesSupport atts);

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area.</param>
        /// <param name="uri">The namespace URI of the prefix area.</param>
        void startPrefixMapping(System.String prefix, System.String uri);
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
        System.String getPublicId();

        /// <summary>
        /// This method is not supported, it is included for compatibility.		
        /// </summary>
        /// <returns>The saved system identifier.</returns>
        System.String getSystemId();
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
        public virtual System.String getPublicId()
        {
            return publicId;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Return the saved system identifier.
        /// </summary>
        /// <returns>The saved system identifier.</returns>
        public virtual System.String getSystemId()
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
        public virtual void setPublicId(System.String publicId)
        {
            this.publicId = publicId;
        }

        /// <summary>
        /// This method is not supported, it is included for compatibility.
        /// Set the system identifier for this locator.
        /// </summary>
        /// <param name="systemId">The new system identifier.</param>
        public virtual void setSystemId(System.String systemId)
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
        private System.String publicId;
        private System.String systemId;
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
        void endEntity(System.String name);

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
        void startDTD(System.String name, System.String publicId, System.String systemId);

        /// <summary>
        /// This method report the start of an entity.
        /// </summary>
        /// <param name="name">The name of the entity that is ending.</param>
        void startEntity(System.String name);
    }

    /*******************************/
    /// <summary>
    /// This class will manage all the parsing operations emulating the SAX parser behavior
    /// </summary>
    public class SaxAttributesSupport
    {
        private System.Collections.ArrayList MainList;

        /// <summary>
        /// Builds a new instance of SaxAttributesSupport.
        /// </summary>
        public SaxAttributesSupport()
        {
            MainList = new System.Collections.ArrayList();
        }

        /// <summary>
        /// Creates a new instance of SaxAttributesSupport from an ArrayList of Att_Instance class.
        /// </summary>
        /// <param name="arrayList">An ArraList of Att_Instance class instances.</param>
        /// <returns>A new instance of SaxAttributesSupport</returns>
        public SaxAttributesSupport(SaxAttributesSupport List)
        {
            SaxAttributesSupport temp = new SaxAttributesSupport();
            temp.MainList = (System.Collections.ArrayList)List.MainList.Clone();
        }

        /// <summary>
        /// Adds a new attribute elment to the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="Uri">The Uri of the attribute to be added.</param>
        /// <param name="Lname">The Local name of the attribute to be added.</param>
        /// <param name="Qname">The Long(qualify) name of the attribute to be added.</param>
        /// <param name="Type">The type of the attribute to be added.</param>
        /// <param name="Value">The value of the attribute to be added.</param>
        public virtual void Add(System.String Uri, System.String Lname, System.String Qname, System.String Type, System.String Value)
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
        public virtual int GetIndex(System.String Qname)
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
        /// Obtains the index of an attribute of the AttributeSupport from its namespace URI and its localname.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>An zero-based index of the attribute if it is found, otherwise it returns -1.</returns>
        public virtual int GetIndex(System.String Uri, System.String Lname)
        {
            int index = GetLength() - 1;
            while ((index >= 0) && !(((Att_Instance)(MainList[index])).att_localName.Equals(Lname) && ((Att_Instance)(MainList[index])).att_URI.Equals(Uri)))
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
        public virtual System.String GetLocalName(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_localName;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the qualified name of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The qualified name of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual System.String GetFullName(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_fullName;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the type of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The type of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual System.String GetType(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_type;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the namespace URI of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The namespace URI of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual System.String GetURI(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_URI;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the value of the attribute in the given SaxAttributesSupport instance that indicates the given index.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <returns>The value of the attribute indicated by the index or null if the index is out of bounds.</returns>
        public virtual System.String GetValue(int index)
        {
            try
            {
                return ((Att_Instance)MainList[index]).att_value;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        /// <summary>
        /// Modifies the local name of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="LocalName">The new Local name for the attribute.</param>
        public virtual void SetLocalName(int index, System.String LocalName)
        {
            ((Att_Instance)MainList[index]).att_localName = LocalName;
        }

        /// <summary>
        /// Modifies the qualified name of the attribute in the given SaxAttributesSupport instance.
        /// </summary>	
        /// <param name="index">The attribute index.</param>
        /// <param name="FullName">The new qualified name for the attribute.</param>
        public virtual void SetFullName(int index, System.String FullName)
        {
            ((Att_Instance)MainList[index]).att_fullName = FullName;
        }

        /// <summary>
        /// Modifies the type of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="Type">The new type for the attribute.</param>
        public virtual void SetType(int index, System.String Type)
        {
            ((Att_Instance)MainList[index]).att_type = Type;
        }

        /// <summary>
        /// Modifies the namespace URI of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="URI">The new namespace URI for the attribute.</param>
        public virtual void SetURI(int index, System.String URI)
        {
            ((Att_Instance)MainList[index]).att_URI = URI;
        }

        /// <summary>
        /// Modifies the value of the attribute in the given SaxAttributesSupport instance.
        /// </summary>
        /// <param name="index">The attribute index.</param>
        /// <param name="Value">The new value for the attribute.</param>
        public virtual void SetValue(int index, System.String Value)
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
            catch (System.ArgumentOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("The index is out of range");
            }
        }

        /// <summary>
        /// This method eliminates the Att_Instance instance in the specified index.
        /// </summary>
        /// <param name="indexName">The index name of the attribute.</param>
        public virtual void RemoveAttribute(System.String indexName)
        {
            try
            {
                int pos = GetLength() - 1;
                while ((pos >= 0) && !(((Att_Instance)(MainList[pos])).att_localName.Equals(indexName)))
                    pos--;
                if (pos >= 0)
                    MainList.RemoveAt(pos);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw new System.IndexOutOfRangeException("The index is out of range");
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
        public virtual void SetAttribute(int index, System.String Uri, System.String Lname, System.String Qname, System.String Type, System.String Value)
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
        public virtual System.String GetType(System.String Qname)
        {
            int temp_Index = GetIndex(Qname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_type;
            else
                return "";
        }

        /// <summary>
        /// Returns the type of the Attribute that match with the given namespace URI and local name.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>The type of the attribute if it exist otherwise returns null.</returns>
        public virtual System.String GetType(System.String Uri, System.String Lname)
        {
            int temp_Index = GetIndex(Uri, Lname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_type;
            else
                return "";
        }

        /// <summary>
        /// Returns the value of the Attribute that match with the given qualified name.
        /// </summary>
        /// <param name="Qname">The qualified name of the attribute to search.</param>
        /// <returns>The value of the attribute if it exist otherwise returns null.</returns>
        public virtual System.String GetValue(System.String Qname)
        {
            int temp_Index = GetIndex(Qname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_value;
            else
                return "";
        }

        /// <summary>
        /// Returns the value of the Attribute that match with the given namespace URI and local name.
        /// </summary>
        /// <param name="Uri">The namespace URI of the attribute to search.</param>
        /// <param name="Lname">The local name of the attribute to search.</param>
        /// <returns>The value of the attribute if it exist otherwise returns null.</returns>
        public virtual System.String GetValue(System.String Uri, System.String Lname)
        {
            int temp_Index = GetIndex(Uri, Lname);
            if (temp_Index != -1)
                return ((Att_Instance)MainList[temp_Index]).att_value;
            else
                return "";
        }

        /*******************************/
        /// <summary>
        /// This class is created to save the information of each attributes in the SaxAttributesSupport.
        /// </summary>
        public class Att_Instance
        {
            public System.String att_URI;
            public System.String att_localName;
            public System.String att_fullName;
            public System.String att_type;
            public System.String att_value;

            /// <summary>
            /// This is the constructor of the Att_Instance
            /// </summary>
            /// <param name="Uri">The namespace URI of the attribute</param>
            /// <param name="Lname">The local name of the attribute</param>
            /// <param name="Qname">The long(Qualify) name of attribute</param>
            /// <param name="Type">The type of the attribute</param>
            /// <param name="Value">The value of the attribute</param>
            public Att_Instance(System.String Uri, System.String Lname, System.String Qname, System.String Type, System.String Value)
            {
                this.att_URI = Uri;
                this.att_localName = Lname;
                this.att_fullName = Qname;
                this.att_type = Type;
                this.att_value = Value;
            }
        }
    }

    /*******************************/
    /// <summary>
    /// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature 
    /// methods if a property or method couldn't be found.
    /// </summary>
    public class ManagerNotRecognizedException : System.Exception
    {
        /// <summary>
        /// Creates a new ManagerNotRecognizedException with the message specified.
        /// </summary>
        /// <param name="Message">Error message of the exception.</param>
        public ManagerNotRecognizedException(System.String Message)
            : base(Message)
        {
        }
    }

    /*******************************/
    /// <summary>
    /// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature methods 
    /// if a property or method couldn't be supported.
    /// </summary>
    public class ManagerNotSupportedException : System.Exception
    {
        /// <summary>
        /// Creates a new ManagerNotSupportedException with the message specified.
        /// </summary>
        /// <param name="Message">Error message of the exception.</param>
        public ManagerNotSupportedException(System.String Message)
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
        /// <param name="namespaceURI">The namespace URI of the element</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The long name (qualify name) of the element</param>
        public virtual void endElement(System.String uri, System.String localName, System.String qName)
        {
        }

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends</param>
        public virtual void endPrefixMapping(System.String prefix)
        {
        }

        /// <summary>
        /// This method manage when an error exception ocurrs in the parsing process
        /// </summary>
        /// <param name="exception">The exception throws by the parser</param>
        public virtual void error(System.Xml.XmlException e)
        {
        }

        /// <summary>
        /// This method manage when a fatal error exception ocurrs in the parsing process
        /// </summary>
        /// <param name="exception">The exception Throws by the parser</param>
        public virtual void fatalError(System.Xml.XmlException e)
        {
        }

        /// <summary>
        /// This method manage the event when a ignorable whitespace node were found
        /// </summary>
        /// <param name="Ch">The array with the ignorable whitespaces</param>
        /// <param name="Start">The index in the array with the ignorable whitespace</param>
        /// <param name="Length">The length of the whitespaces</param>
        public virtual void ignorableWhitespace(char[] ch, int start, int length)
        {
        }

        /// <summary>
        /// This method is not supported only is created for compatibility
        /// </summary>
        public virtual void notationDecl(System.String name, System.String publicId, System.String systemId)
        {
        }

        /// <summary>
        /// This method manage the event when a processing instruction were found
        /// </summary>
        /// <param name="target">The processing instruction target</param>
        /// <param name="data">The processing instruction data</param>
        public virtual void processingInstruction(System.String target, System.String data)
        {
        }

        /// <summary>
        /// Allow the application to resolve external entities.
        /// </summary>
        /// <param name="publicId">The public identifier of the external entity being referenced, or null if none was supplied.</param>
        /// <param name="systemId">The system identifier of the external entity being referenced.</param>
        /// <returns>A XmlSourceSupport object describing the new input source, or null to request that the parser open a regular URI connection to the system identifier.</returns>
        public virtual XmlSourceSupport resolveEntity(System.String publicId, System.String systemId)
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
        public virtual void skippedEntity(System.String name)
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
        /// <param name="atts">The list of attributes of the element</param>
        public virtual void startElement(System.String uri, System.String localName, System.String qName, SaxAttributesSupport attributes)
        {
        }

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area</param>
        /// <param name="uri">The namespace uri of the prefix area</param>
        public virtual void startPrefixMapping(System.String prefix, System.String uri)
        {
        }

        /// <summary>
        /// This method is not supported only is created for compatibility
        /// </summary>        
        public virtual void unparsedEntityDecl(System.String name, System.String publicId, System.String systemId, System.String notationName)
        {
        }

        /// <summary>
        /// This method manage when a warning exception ocurrs in the parsing process
        /// </summary>
        /// <param name="exception">The exception Throws by the parser</param>
        public virtual void warning(System.Xml.XmlException e)
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
        public virtual void characters(char[] ch, int start, int length) { }

        /// <summary>
        /// This method manage the notification when the end document node were found
        /// </summary>
        public virtual void endDocument() { }

        /// <summary>
        /// This method manage the notification when the end element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace URI of the element</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The long name (qualify name) of the element</param>
        public virtual void endElement(System.String namespaceURI, System.String localName, System.String qName) { }

        /// <summary>
        /// This method manage the event when an area of expecific URI prefix was ended.
        /// </summary>
        /// <param name="prefix">The prefix that ends.</param>
        public virtual void endPrefixMapping(System.String prefix) { }

        /// <summary>
        /// This method manage the event when a ignorable whitespace node were found
        /// </summary>
        /// <param name="ch">The array with the ignorable whitespaces</param>
        /// <param name="start">The index in the array with the ignorable whitespace</param>
        /// <param name="length">The length of the whitespaces</param>
        public virtual void ignorableWhitespace(char[] ch, int start, int length) { }

        /// <summary>
        /// This method manage the event when a processing instruction were found
        /// </summary>
        /// <param name="target">The processing instruction target</param>
        /// <param name="data">The processing instruction data</param>
        public virtual void processingInstruction(System.String target, System.String data) { }

        /// <summary>
        /// Receive an object for locating the origin of events into the XML document
        /// </summary>
        /// <param name="locator">A 'XmlSaxLocator' object that can return the location of any events into the XML document</param>
        public virtual void setDocumentLocator(IXmlSaxLocator locator) { }

        /// <summary>
        /// This method manage the event when a skipped entity was found.
        /// </summary>
        /// <param name="name">The name of the skipped entity.</param>
        public virtual void skippedEntity(System.String name) { }

        /// <summary>
        /// This method manage the event when a start document node were found 
        /// </summary>
        public virtual void startDocument() { }

        /// <summary>
        /// This method manage the event when a start element node were found
        /// </summary>
        /// <param name="namespaceURI">The namespace uri of the element tag</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="qName">The Qualify (long) name of the element</param>
        /// <param name="qAtts">The list of attributes of the element</param>
        public virtual void startElement(System.String namespaceURI, System.String localName, System.String qName, SaxAttributesSupport qAtts) { }

        /// <summary>
        /// This methods indicates the start of a prefix area in the XML document.
        /// </summary>
        /// <param name="prefix">The prefix of the area.</param>
        /// <param name="uri">The namespace URI of the prefix area.</param>
        public virtual void startPrefixMapping(System.String prefix, System.String uri) { }

    }


    /*******************************/
    /// <summary>
    /// Emulates the SAX parsers behaviours.
    /// </summary>
    public class XmlSAXDocumentManager
    {
        protected bool isValidating;
        protected bool namespaceAllowed;
        protected System.Xml.XmlReader reader;
        //protected XmlValidatingReader reader;
        protected IXmlSaxContentHandler callBackHandler;
        protected IXmlSaxErrorHandler errorHandler;
        protected XmlSaxLocatorImpl locator;
        protected IXmlSaxLexicalHandler lexical;
        protected IXmlSaxEntityResolver entityResolver;
        protected System.String parserFileName;

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
            parserFileName = "";
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
            temp.setFeature("http://xml.org/sax/features/namespaces", instance.getFeature("http://xml.org/sax/features/namespaces"));
            temp.setFeature("http://xml.org/sax/features/namespace-prefixes", instance.getFeature("http://xml.org/sax/features/namespace-prefixes"));
            temp.setFeature("http://xml.org/sax/features/validation", instance.getFeature("http://xml.org/sax/features/validation"));
            temp.setProperty("http://xml.org/sax/properties/lexical-handler", instance.getProperty("http://xml.org/sax/properties/lexical-handler"));
            temp.parserFileName = instance.parserFileName;
            return temp;
        }

        /// <summary>
        /// Indicates whether the 'XmlSAXDocumentManager' are validating the XML over a DTD.
        /// </summary>
        public bool IsValidating
        {
            get
            {
                return isValidating;
            }
            set
            {
                isValidating = value;
            }
        }

        /// <summary>
        /// Indicates whether the 'XmlSAXDocumentManager' manager allows namespaces.
        /// </summary>
        public bool NamespaceAllowed
        {
            get
            {
                return namespaceAllowed;
            }
            set
            {
                namespaceAllowed = value;
            }
        }

        /// <summary>
        /// Emulates the behaviour of a SAX LocatorImpl object.
        /// </summary>
        /// <param name="locator">The 'XmlSaxLocatorImpl' instance to assing the document location.</param>
        /// <param name="textReader">The XML document instance to be used.</param>
        private void UpdateLocatorData(XmlSaxLocatorImpl locator, System.Xml.XmlTextReader textReader)
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
        public virtual void setFeature(System.String name, bool value)
        {
            switch (name)
            {
                case "http://xml.org/sax/features/namespaces":
                    {
                        try
                        {
                            this.NamespaceAllowed = value;
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
                            this.NamespaceAllowed = value;
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
                            this.isValidating = value;
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
        public virtual bool getFeature(System.String name)
        {
            switch (name)
            {
                case "http://xml.org/sax/features/namespaces":
                    {
                        try
                        {
                            return this.NamespaceAllowed;
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
                            return this.NamespaceAllowed;
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
                            return this.isValidating;
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
        public virtual void setProperty(System.String name, System.Object value)
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
                        catch (System.Exception e)
                        {
                            throw new ManagerNotSupportedException("The property is not supported as an internal exception was thrown when trying to set it: " + e.Message);
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
        public virtual System.Object getProperty(System.String name)
        {
            switch (name)
            {
                case "http://xml.org/sax/properties/lexical-handler":
                    {
                        try
                        {
                            return this.lexical;
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
            System.Collections.Hashtable prefixes = new System.Collections.Hashtable();
            System.Collections.Stack stackNameSpace = new System.Collections.Stack();
            locator = new XmlSaxLocatorImpl();
            try
            {
                UpdateLocatorData(this.locator, (System.Xml.XmlTextReader)(this.reader));
                if (this.callBackHandler != null)
                    this.callBackHandler.setDocumentLocator(locator);
                if (this.callBackHandler != null)
                    this.callBackHandler.startDocument();
                while (this.reader.Read())
                {
                    UpdateLocatorData(this.locator, (System.Xml.XmlTextReader)(this.reader));
                    switch (this.reader.NodeType)
                    {
                        case System.Xml.XmlNodeType.Element:
                            bool Empty = reader.IsEmptyElement;
                            System.String namespaceURI = "";
                            System.String localName = "";
                            if (this.namespaceAllowed)
                            {
                                namespaceURI = reader.NamespaceURI;
                                localName = reader.LocalName;
                            }
                            System.String name = reader.Name;
                            SaxAttributesSupport attributes = new SaxAttributesSupport();
                            if (reader.HasAttributes)
                            {
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    System.String prefixName = (reader.Name.IndexOf(":") > 0) ? reader.Name.Substring(reader.Name.IndexOf(":") + 1, reader.Name.Length - reader.Name.IndexOf(":") - 1) : "";
                                    System.String prefix = (reader.Name.IndexOf(":") > 0) ? reader.Name.Substring(0, reader.Name.IndexOf(":")) : reader.Name;
                                    bool IsXmlns = prefix.ToLower().Equals("xmlns");
                                    if (this.namespaceAllowed)
                                    {
                                        if (!IsXmlns)
                                            attributes.Add(reader.NamespaceURI, reader.LocalName, reader.Name, "" + reader.NodeType, reader.Value);
                                    }
                                    else
                                        attributes.Add("", "", reader.Name, "" + reader.NodeType, reader.Value);
                                    if (IsXmlns)
                                    {
                                        System.String namespaceTemp = "";
                                        namespaceTemp = (namespaceURI.Length == 0) ? reader.Value : namespaceURI;
                                        if (this.namespaceAllowed && !prefixes.ContainsKey(namespaceTemp) && namespaceTemp.Length > 0)
                                        {
                                            stackNameSpace.Push(name);
                                            System.Collections.Stack namespaceStack = new System.Collections.Stack();
                                            namespaceStack.Push(prefixName);
                                            prefixes.Add(namespaceURI, namespaceStack);
                                            if (this.callBackHandler != null)
                                                ((IXmlSaxContentHandler)this.callBackHandler).startPrefixMapping(prefixName, namespaceTemp);
                                        }
                                        else
                                        {
                                            if (this.namespaceAllowed && namespaceTemp.Length > 0 && !((System.Collections.Stack)prefixes[namespaceTemp]).Contains(reader.Name))
                                            {
                                                ((System.Collections.Stack)prefixes[namespaceURI]).Push(prefixName);
                                                if (this.callBackHandler != null)
                                                    ((IXmlSaxContentHandler)this.callBackHandler).startPrefixMapping(prefixName, reader.Value);
                                            }
                                        }
                                    }
                                }
                            }
                            if (this.callBackHandler != null)
                                this.callBackHandler.startElement(namespaceURI, localName, name, attributes);
                            if (Empty)
                            {
                                if (this.NamespaceAllowed)
                                {
                                    if (this.callBackHandler != null)
                                        this.callBackHandler.endElement(namespaceURI, localName, name);
                                }
                                else
                                    if (this.callBackHandler != null)
                                        this.callBackHandler.endElement("", "", name);
                            }
                            break;

                        case System.Xml.XmlNodeType.EndElement:
                            if (this.namespaceAllowed)
                            {
                                if (this.callBackHandler != null)
                                    this.callBackHandler.endElement(reader.NamespaceURI, reader.LocalName, reader.Name);
                            }
                            else
                                if (this.callBackHandler != null)
                                    this.callBackHandler.endElement("", "", reader.Name);
                            if (this.namespaceAllowed && prefixes.ContainsKey(reader.NamespaceURI) && ((System.Collections.Stack)stackNameSpace).Contains(reader.Name))
                            {
                                stackNameSpace.Pop();
                                System.Collections.Stack namespaceStack = (System.Collections.Stack)prefixes[reader.NamespaceURI];
                                while (namespaceStack.Count > 0)
                                {
                                    System.String tempString = (System.String)namespaceStack.Pop();
                                    if (this.callBackHandler != null)
                                        ((IXmlSaxContentHandler)this.callBackHandler).endPrefixMapping(tempString);
                                }
                                prefixes.Remove(reader.NamespaceURI);
                            }
                            break;

                        case System.Xml.XmlNodeType.Text:
                            if (this.callBackHandler != null)
                                this.callBackHandler.characters(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case System.Xml.XmlNodeType.Whitespace:
                            if (this.callBackHandler != null)
                                this.callBackHandler.ignorableWhitespace(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case System.Xml.XmlNodeType.ProcessingInstruction:
                            if (this.callBackHandler != null)
                                this.callBackHandler.processingInstruction(reader.Name, reader.Value);
                            break;

                        case System.Xml.XmlNodeType.Comment:
                            if (this.lexical != null)
                                this.lexical.comment(reader.Value.ToCharArray(), 0, reader.Value.Length);
                            break;

                        case System.Xml.XmlNodeType.CDATA:
                            if (this.lexical != null)
                            {
                                lexical.startCDATA();
                                if (this.callBackHandler != null)
                                    this.callBackHandler.characters(this.reader.Value.ToCharArray(), 0, this.reader.Value.ToCharArray().Length);
                                lexical.endCDATA();
                            }
                            break;

                        case System.Xml.XmlNodeType.DocumentType:
                            if (this.lexical != null)
                            {
                                System.String lname = this.reader.Name;
                                System.String systemId = null;
                                if (this.reader.AttributeCount > 0)
                                    systemId = this.reader.GetAttribute(0);
                                this.lexical.startDTD(lname, null, systemId);
                                this.lexical.startEntity("[dtd]");
                                this.lexical.endEntity("[dtd]");
                                this.lexical.endDTD();
                            }
                            break;
                    }
                }
                if (this.callBackHandler != null)
                    this.callBackHandler.endDocument();
            }
            catch (System.Xml.XmlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified file and process the events over the specified handler.
        /// </summary>
        /// <param name="filepath">The file to be used.</param>
        /// <param name="handler">The handler that manages the parser events.</param>
        public virtual void parse(System.IO.FileInfo filepath, IXmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler)handler;
                    this.entityResolver = (XmlSaxDefaultHandler)handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if (this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                this.reader = CreateXmlReader(filepath);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        private XmlReader CreateXmlReader(System.IO.FileInfo filePath)
        {
            parserFileName = filePath.FullName;
            return CreateXmlReader(new System.Xml.XmlTextReader(filePath.OpenRead()));
        }

        private XmlReader CreateXmlReader(string fileName)
        {
            parserFileName = fileName;
            return CreateXmlReader(new System.Xml.XmlTextReader(fileName));
        }

        private XmlReader CreateXmlReader(System.IO.Stream stream)
        {
            parserFileName = null;
            return CreateXmlReader(new System.Xml.XmlTextReader(stream));
        }

        private XmlReader CreateXmlReader(System.IO.Stream stream, string URI)
        {
            parserFileName = null;
            return CreateXmlReader(new System.Xml.XmlTextReader(URI, stream));
        }


        private XmlReader CreateXmlReader(System.Xml.XmlTextReader textReader)
        {
            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = (this.isValidating) ? System.Xml.ValidationType.DTD : System.Xml.ValidationType.None;
            //settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
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
        public virtual void parse(System.String filepath, IXmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler)handler;
                    this.entityResolver = (XmlSaxDefaultHandler)handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if (this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                this.reader = CreateXmlReader(filepath);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over the specified handler.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        public virtual void parse(System.IO.Stream stream, IXmlSaxContentHandler handler)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler)handler;
                    this.entityResolver = (XmlSaxDefaultHandler)handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if (this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                this.reader = CreateXmlReader(stream);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over the specified handler, and resolves the 
        /// entities with the specified URI.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="handler">The handler that manage the parser events.</param>
        /// <param name="URI">The namespace URI for resolve external etities.</param>
        public virtual void parse(System.IO.Stream stream, IXmlSaxContentHandler handler, System.String URI)
        {
            try
            {
                if (handler is XmlSaxDefaultHandler)
                {
                    this.errorHandler = (XmlSaxDefaultHandler)handler;
                    this.entityResolver = (XmlSaxDefaultHandler)handler;
                }
                if (!(this is XmlSaxParserAdapter))
                    this.callBackHandler = handler;
                else
                {
                    if (this.callBackHandler == null)
                        this.callBackHandler = handler;
                }
                this.reader = CreateXmlReader(stream, URI);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
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
                        throw new System.Xml.XmlException("The XmlSource class can't be null");
                }
            }
        }

        /// <summary>
        /// Parses the specified file and process the events over previously specified handler.
        /// </summary>
        /// <param name="filepath">The file with the XML.</param>
        public virtual void parse(System.IO.FileInfo filepath)
        {
            try
            {
                this.reader = CreateXmlReader(filepath);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified file path and processes the events over previously specified handler.
        /// </summary>
        /// <param name="filepath">The path of the file with the XML.</param>
        public virtual void parse(System.String filepath)
        {
            try
            {
                this.reader = CreateXmlReader(filepath);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and process the events over previusly specified handler.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        public virtual void parse(System.IO.Stream stream)
        {
            try
            {
                this.reader = CreateXmlReader(stream);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
                throw e;
            }
        }

        /// <summary>
        /// Parses the specified stream and processes the events over previously specified handler, and resolves the 
        /// external entities with the specified URI.
        /// </summary>
        /// <param name="stream">The stream with the XML.</param>
        /// <param name="URI">The namespace URI for resolve external etities.</param>
        public virtual void parse(System.IO.Stream stream, System.String URI)
        {
            try
            {
                this.reader = CreateXmlReader(stream, URI);
                this.DoParsing();
            }
            catch (System.Xml.XmlException e)
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(e);
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
                        throw new System.Xml.XmlException("The XmlSource class can't be null");
                }
            }
        }

        /// <summary>
        /// Manages all the exceptions that were thrown when the validation over XML fails.
        /// </summary>
        public void ValidationEventHandle(System.Object sender, System.Xml.Schema.ValidationEventArgs args)
        {
            System.Xml.Schema.XmlSchemaException tempException = args.Exception;
            if (args.Severity == System.Xml.Schema.XmlSeverityType.Warning)
            {
                if (this.errorHandler != null)
                    this.errorHandler.warning(new System.Xml.XmlException(tempException.Message, tempException, tempException.LineNumber, tempException.LinePosition));
            }
            else
            {
                if (this.errorHandler != null)
                    this.errorHandler.fatalError(new System.Xml.XmlException(tempException.Message, tempException, tempException.LineNumber, tempException.LinePosition));
            }
        }

        /// <summary>
        /// Assigns the object that will handle all the content events.
        /// </summary>
        /// <param name="handler">The object that handles the content events.</param>
        public virtual void setContentHandler(IXmlSaxContentHandler handler)
        {
            if (handler != null)
                this.callBackHandler = handler;
            else
                throw new System.Xml.XmlException("Error assigning the Content handler: a null Content Handler was received");
        }

        /// <summary>
        /// Assigns the object that will handle all the error events. 
        /// </summary>
        /// <param name="handler">The object that handles the errors events.</param>
        public virtual void setErrorHandler(IXmlSaxErrorHandler handler)
        {
            if (handler != null)
                this.errorHandler = handler;
            else
                throw new System.Xml.XmlException("Error assigning the Error handler: a null Error Handler was received");
        }

        /// <summary>
        /// Obtains the object that will handle all the content events.
        /// </summary>
        /// <returns>The object that handles the content events.</returns>
        public virtual IXmlSaxContentHandler getContentHandler()
        {
            return this.callBackHandler;
        }

        /// <summary>
        /// Assigns the object that will handle all the error events. 
        /// </summary>
        /// <returns>The object that handles the error events.</returns>
        public virtual IXmlSaxErrorHandler getErrorHandler()
        {
            return this.errorHandler;
        }

        /// <summary>
        /// Returns the current entity resolver.
        /// </summary>
        /// <returns>The current entity resolver, or null if none has been registered.</returns>
        public virtual IXmlSaxEntityResolver getEntityResolver()
        {
            return this.entityResolver;
        }

        /// <summary>
        /// Allows an application to register an entity resolver.
        /// </summary>
        /// <param name="resolver">The entity resolver.</param>
        public virtual void setEntityResolver(IXmlSaxEntityResolver resolver)
        {
            this.entityResolver = resolver;
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
        /// <param name="stream">Output sream used to write to</param>
        public static void WriteStackTrace(System.Exception throwable, System.IO.TextWriter stream)
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
            public static System.Object Pop(System.Collections.ArrayList stack)
            {
                System.Object obj = stack[stack.Count - 1];
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
        public static void GetCharsFromString(System.String sourceString, int sourceStart, int sourceEnd, char[] destinationArray, int destinationStart)
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
        public class TransactionManager
        {
            public static ConnectionHashTable manager = new ConnectionHashTable();

            public class ConnectionHashTable : System.Collections.Hashtable
            {
                public System.Data.OleDb.OleDbCommand CreateStatement(System.Data.OleDb.OleDbConnection connection)
                {
                    System.Data.OleDb.OleDbCommand command = connection.CreateCommand();
                    System.Data.OleDb.OleDbTransaction transaction;
                    if (this[connection] != null)
                    {
                        ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                        transaction = Properties.Transaction;
                        command.Transaction = transaction;
                        command.CommandTimeout = 0;
                    }
                    else
                    {
                        ConnectionProperties TempProp = new ConnectionProperties();
                        TempProp.AutoCommit = true;
                        TempProp.TransactionLevel = 0;
                        command.Transaction = TempProp.Transaction;
                        command.CommandTimeout = 0;
                        Add(connection, TempProp);
                    }
                    return command;
                }

                public void Commit(System.Data.OleDb.OleDbConnection connection)
                {
                    if (this[connection] != null && !((ConnectionProperties)this[connection]).AutoCommit)
                    {
                        ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                        System.Data.OleDb.OleDbTransaction transaction = Properties.Transaction;
                        transaction.Commit();
                        if (Properties.TransactionLevel == 0)
                            Properties.Transaction = connection.BeginTransaction();
                        else
                            Properties.Transaction = connection.BeginTransaction(Properties.TransactionLevel);
                    }
                }

                public void RollBack(System.Data.OleDb.OleDbConnection connection)
                {
                    if (this[connection] != null && !((ConnectionProperties)this[connection]).AutoCommit)
                    {
                        ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                        System.Data.OleDb.OleDbTransaction transaction = Properties.Transaction;
                        transaction.Rollback();
                        if (Properties.TransactionLevel == 0)
                            Properties.Transaction = connection.BeginTransaction();
                        else
                            Properties.Transaction = connection.BeginTransaction(Properties.TransactionLevel);
                    }
                }

                public void SetAutoCommit(System.Data.OleDb.OleDbConnection connection, bool boolean)
                {
                    if (this[connection] != null)
                    {
                        ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                        if (Properties.AutoCommit != boolean)
                        {
                            Properties.AutoCommit = boolean;
                            if (!boolean)
                            {
                                if (Properties.TransactionLevel == 0)
                                    Properties.Transaction = connection.BeginTransaction();
                                else
                                    Properties.Transaction = connection.BeginTransaction(Properties.TransactionLevel);
                            }
                            else
                            {
                                System.Data.OleDb.OleDbTransaction transaction = Properties.Transaction;
                                if (transaction != null)
                                {
                                    transaction.Commit();
                                }
                            }
                        }
                    }
                    else
                    {
                        ConnectionProperties TempProp = new ConnectionProperties();
                        TempProp.AutoCommit = boolean;
                        TempProp.TransactionLevel = 0;
                        if (!boolean)
                            TempProp.Transaction = connection.BeginTransaction();
                        Add(connection, TempProp);
                    }
                }

                public System.Data.OleDb.OleDbCommand PrepareStatement(System.Data.OleDb.OleDbConnection connection, System.String sql)
                {
                    System.Data.OleDb.OleDbCommand command = this.CreateStatement(connection);
                    command.CommandText = sql;
                    command.CommandTimeout = 0;
                    return command;
                }

                public System.Data.OleDb.OleDbCommand PrepareCall(System.Data.OleDb.OleDbConnection connection, System.String sql)
                {
                    System.Data.OleDb.OleDbCommand command = this.CreateStatement(connection);
                    command.CommandText = sql;
                    command.CommandTimeout = 0;
                    return command;
                }

                public void SetTransactionIsolation(System.Data.OleDb.OleDbConnection connection, int level)
                {
                    ConnectionProperties Properties;
                    if (level == (int)System.Data.IsolationLevel.ReadCommitted)
                        SetAutoCommit(connection, false);
                    else
                        if (level == (int)System.Data.IsolationLevel.ReadUncommitted)
                            SetAutoCommit(connection, false);
                        else
                            if (level == (int)System.Data.IsolationLevel.RepeatableRead)
                                SetAutoCommit(connection, false);
                            else
                                if (level == (int)System.Data.IsolationLevel.Serializable)
                                    SetAutoCommit(connection, false);

                    if (this[connection] != null)
                    {
                        Properties = ((ConnectionProperties)this[connection]);
                        Properties.TransactionLevel = (System.Data.IsolationLevel)level;
                    }
                    else
                    {
                        Properties = new ConnectionProperties();
                        Properties.AutoCommit = true;
                        Properties.TransactionLevel = (System.Data.IsolationLevel)level;
                        Add(connection, Properties);
                    }
                }

                public int GetTransactionIsolation(System.Data.OleDb.OleDbConnection connection)
                {
                    if (this[connection] != null)
                    {
                        ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                        if (Properties.TransactionLevel != 0)
                            return (int)Properties.TransactionLevel;
                        else
                            return 2;
                    }
                    else
                        return 2;
                }

                public bool GetAutoCommit(System.Data.OleDb.OleDbConnection connection)
                {
                    if (this[connection] != null)
                        return ((ConnectionProperties)this[connection]).AutoCommit;
                    else
                        return true;
                }

                /// <summary>
                /// Sets the value of a parameter using any permitted object.  The given argument object will be converted to the
                /// corresponding SQL type before being sent to the database.
                /// </summary>
                /// <param name="command">Command object to be changed.</param>
                /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
                /// <param name="parameter">The object containing the input parameter value.</param>
                public void SetValue(System.Data.OleDb.OleDbCommand command, int parameterIndex, System.Object parameter)
                {
                    if (command.Parameters.Count < parameterIndex)
                        command.Parameters.Add(command.CreateParameter());
                    command.Parameters[parameterIndex - 1].Value = parameter;
                }

                /// <summary>
                /// Sets a parameter to SQL NULL.
                /// </summary>
                /// <param name="command">Command object to be changed.</param>
                /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
                /// <param name="targetSqlType">The SQL type to be sent to the database.</param>
                public void SetNull(System.Data.OleDb.OleDbCommand command, int parameterIndex, int sqlType)
                {
                    if (command.Parameters.Count < parameterIndex)
                        command.Parameters.Add(command.CreateParameter());
                    command.Parameters[parameterIndex - 1].Value = System.Convert.DBNull;
                    command.Parameters[parameterIndex - 1].OleDbType = (System.Data.OleDb.OleDbType)sqlType;
                }

                /// <summary>
                /// Sets the value of a parameter using an object.  The given argument object will be converted to the
                /// corresponding SQL type before being sent to the database.
                /// </summary>
                /// <param name="command">Command object to be changed.</param>
                /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
                /// <param name="parameter">The object containing the input parameter value.</param>
                /// <param name="targetSqlType">The SQL type to be sent to the database.</param>
                public void SetObject(System.Data.OleDb.OleDbCommand command, int parameterIndex, System.Object parameter, int targetSqlType)
                {
                    if (command.Parameters.Count < parameterIndex)
                        command.Parameters.Add(command.CreateParameter());
                    command.Parameters[parameterIndex - 1].Value = parameter;
                    command.Parameters[parameterIndex - 1].OleDbType = (System.Data.OleDb.OleDbType)targetSqlType;
                }

                /// <summary>
                /// Sets the value of a parameter using an object.  The given argument object will be converted to the
                /// corresponding SQL type before being sent to the database.
                /// </summary>
                /// <param name="command">Command object to be changed.</param>
                /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
                /// <param name="parameter">The object containing the input parameter value.</param>
                public void SetObject(System.Data.OleDb.OleDbCommand command, int parameterIndex, System.Object parameter)
                {
                    if (command.Parameters.Count < parameterIndex)
                        command.Parameters.Add(command.CreateParameter());
                    command.Parameters[parameterIndex - 1].Value = parameter;
                }

                /// <summary>
                /// This method is for such prepared statements verify if the Conection is autoCommit for assing the transaction to the command.
                /// </summary>
                /// <param name="command">The command to be tested.</param>
                /// <returns>The number of rows afected.</returns>
                public int ExecuteUpdate(System.Data.OleDb.OleDbCommand command)
                {
                    if (!(((ConnectionProperties)this[command.Connection]).AutoCommit))
                    {
                        command.Transaction = ((ConnectionProperties)this[command.Connection]).Transaction;
                        return command.ExecuteNonQuery();
                    }
                    else
                        return command.ExecuteNonQuery();
                }

                /// <summary>
                /// This method Closes the connection, and if the property of autocommit is true make the comit operation
                /// </summary>
                /// <param name="command"> The command to be closed</param>		
                public void Close(System.Data.OleDb.OleDbConnection Connection)
                {

                    if ((this[Connection] != null) && !(((ConnectionProperties)this[Connection]).AutoCommit))
                    {
                        Commit(Connection);
                    }
                    Connection.Close();
                }

                class ConnectionProperties
                {
                    public bool AutoCommit;
                    public System.Data.OleDb.OleDbTransaction Transaction;
                    public System.Data.IsolationLevel TransactionLevel;
                }
            }
        }
        /*******************************/
        /// <summary>
        /// Manager for the connection with the database
        /// </summary>
        public class OleDBSchema
        {
            private System.Data.DataTable schemaData = null;
            private System.Data.OleDb.OleDbConnection Connection;
            private System.Data.ConnectionState ConnectionState;

            /// <summary>
            /// Constructs a new member with the provided connection
            /// </summary>
            /// <param name="Connection">The connection to assign to the new member</param>
            public OleDBSchema(System.Data.OleDb.OleDbConnection Connection)
            {
                this.Connection = Connection;
            }

            /// <summary>
            /// Gets the Driver name of the connection
            /// </summary>
            public System.String DriverName
            {
                get
                {
                    System.String result = "";
                    OpenConnection();
                    result = this.Connection.Provider;
                    CloseConnection();
                    return result;
                }
            }

            /// <summary>
            /// Opens the connection
            /// </summary>
            private void OpenConnection()
            {
                this.ConnectionState = Connection.State;
                this.Connection.Close();
                this.Connection.Open();
                schemaData = null;
            }

            /// <summary>
            /// Closes the connection
            /// </summary>
            private void CloseConnection()
            {
                if (this.ConnectionState == System.Data.ConnectionState.Open)
                    this.Connection.Close();
            }

            /// <summary>
            /// Gets the info of the row
            /// </summary>
            /// <param name="filter">Filter to apply to the row</param>
            /// <param name="RowName">The row from which to obtain the filter</param>
            /// <returns>A new String with the info from the row</returns>
            private System.String GetMaxInfo(System.String filter, System.String RowName)
            {
                System.String result = "";
                schemaData = null;
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.DbInfoLiterals, null);
                foreach (System.Data.DataRow DataRow in schemaData.Rows)
                {
                    if (DataRow["LiteralName"].ToString() == filter)
                    {
                        result = DataRow[RowName].ToString();
                        break;
                    }
                }
                CloseConnection();
                return result;
            }

            /// <summary>
            /// Gets the catalogs from the database to which it is connected
            /// </summary>
            public System.Data.DataTable Catalogs
            {
                get
                {
                    OpenConnection();
                    schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Catalogs, null);
                    CloseConnection();
                    return schemaData;
                }
            }

            /// <summary>
            /// Gets the OleDBConnection for the current member
            /// </summary>
            /// <returns></returns>
            public System.Data.OleDb.OleDbConnection GetConnection()
            {
                return this.Connection;
            }

            /// <summary>
            /// Gets a description of the stored procedures available
            /// </summary>
            /// <param name="catalog">The catalog from which to obtain the procedures</param>
            /// <param name="schemaPattern">Schema pattern, retrieves those without the schema</param>
            /// <param name="procedureNamePattern">a procedure name pattern</param>
            /// <returns>each row but withing a procedure description</returns>
            public System.Data.DataTable GetProcedures(System.String catalog, System.String schemaPattern, System.String procedureNamePattern)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Procedures, new System.Object[] { catalog, schemaPattern, procedureNamePattern, null });
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets a collection of the descriptions of the stored procedures parameters and result columns
            /// </summary>
            /// <param name="catalog">Retrieves those without a catalog</param>
            /// <param name="schemaPattern">Schema pattern, retrieves those without the schema</param>
            /// <param name="procedureNamePattern">a procedure name pattern</param>
            /// <param name="columnNamePattern">a columng name patterm</param>
            /// <returns>Each row but withing a procedure description or column</returns>
            public System.Data.DataTable GetProcedureColumns(System.String catalog, System.String schemaPattern, System.String procedureNamePattern, System.String columnNamePattern)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Procedure_Parameters, new System.Object[] { catalog, schemaPattern, procedureNamePattern, columnNamePattern });
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets a description of the tables available for the catalog
            /// </summary>
            /// <param name="catalog">A catalog, retrieves those without a catalog</param>
            /// <param name="schemaPattern">Schema pattern, retrieves those without the schema</param>
            /// <param name="tableNamePattern">A table name pattern</param>
            /// <param name="types">a list of table types to include</param>
            /// <returns>Each row</returns>
            public System.Data.DataTable GetTables(System.String catalog, System.String schemaPattern, System.String tableNamePattern, System.String[] types)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new System.Object[] { catalog, schemaPattern, tableNamePattern, types[0] });
                if (types != null)
                {
                    for (int i = 1; i < types.Length; i++)
                    {
                        System.Data.DataTable temp_Table = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new System.Object[] { catalog, schemaPattern, tableNamePattern, types[i] });
                        for (int j = 0; j < temp_Table.Rows.Count; j++)
                        {
                            schemaData.ImportRow(temp_Table.Rows[j]);
                        }
                    }
                }
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets a description of the table rights
            /// </summary>
            /// <param name="catalog">A catalog, retrieves those without a catalog</param>
            /// <param name="schemaPattern">Schema pattern, retrieves those without the schema</param>
            /// <param name="tableNamePattern">A table name pattern</param>
            /// <returns>A description of the table rights</returns>
            public System.Data.DataTable GetTablePrivileges(System.String catalog, System.String schemaPattern, System.String tableNamePattern)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Table_Privileges, new System.Object[] { catalog, schemaPattern, tableNamePattern });
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets the table types available
            /// </summary>
            public System.Data.DataTable TableTypes
            {
                get
                {
                    OpenConnection();
                    schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                    System.Collections.ArrayList tableTypes = new System.Collections.ArrayList(schemaData.Rows.Count);

                    System.String tableType = "";
                    foreach (System.Data.DataRow DataRow in schemaData.Rows)
                    {
                        tableType = DataRow[schemaData.Columns["TABLE_TYPE"]].ToString();
                        if (!(tableTypes.Contains(tableType)))
                        {
                            tableTypes.Add(tableType);
                        }
                    }
                    schemaData = new System.Data.DataTable();
                    schemaData.Columns.Add("TABLE_TYPE");
                    for (int index = 0; index < tableTypes.Count; index++)
                    {
                        schemaData.Rows.Add(new System.Object[] { tableTypes[index] });
                    }
                    CloseConnection();
                    return schemaData;
                }
            }

            /// <summary>
            /// Gets a description of the table columns available
            /// </summary>
            /// <param name="catalog">A catalog, retrieves those without a catalog</param>
            /// <param name="schemaPattern">Schema pattern, retrieves those without the schema</param>
            /// <param name="tableNamePattern">A table name pattern</param>
            /// <param name="columnNamePattern">a columng name patterm</param>
            /// <returns>A description of the table columns available</returns>
            public System.Data.DataTable GetColumns(System.String catalog, System.String schemaPattern, System.String tableNamePattern, System.String columnNamePattern)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, new System.Object[] { catalog, schemaPattern, tableNamePattern, columnNamePattern });
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets a description of the primary keys available
            /// </summary>
            /// <param name="catalog">A catalog, retrieves those without a catalog</param>
            /// <param name="schema">Schema name, retrieves those without the schema</param>
            /// <param name="table">A table name</param>
            /// <returns>A description of the primary keys available</returns>
            public System.Data.DataTable GetPrimaryKeys(System.String catalog, System.String schema, System.String table)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Primary_Keys, new System.Object[] { catalog, schema, table });
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets a description of the foreign keys available
            /// </summary>
            /// <param name="catalog">A catalog, retrieves those without a catalog</param>
            /// <param name="schema">Schema name, retrieves those without the schema</param>
            /// <param name="table">A table name</param>
            /// <returns>A description of the foreign keys available</returns>
            public System.Data.DataTable GetForeignKeys(System.String catalog, System.String schema, System.String table)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Foreign_Keys, new System.Object[] { catalog, schema, table });
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets a description of the access rights for	a table columns
            /// </summary>
            /// <param name="catalog">A catalog, retrieves those without a catalog</param>
            /// <param name="schema">Schema name, retrieves those without the schema</param>
            /// <param name="table">A table name</param>
            /// <param name="columnNamePattern">A column name patter</param>
            /// <returns>A description of the access rights for	a table columns</returns>
            public System.Data.DataTable GetColumnPrivileges(System.String catalog, System.String schema, System.String table, System.String columnNamePattern)
            {
                OpenConnection();
                schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Column_Privileges, new System.Object[] { catalog, schema, table, columnNamePattern });
                CloseConnection();
                return schemaData;
            }

            /// <summary>
            /// Gets the provider version
            /// </summary>
            public System.String ProviderVersion
            {
                get
                {
                    System.String result = "";
                    OpenConnection();
                    result = this.Connection.ServerVersion;
                    CloseConnection();
                    return result;
                }
            }

            /// <summary>
            /// Gets the default transaction isolation integer value
            /// </summary>
            public int DefaultTransactionIsolation
            {
                get
                {
                    int result = -1;
                    OpenConnection();
                    System.Data.OleDb.OleDbTransaction Transaction = this.Connection.BeginTransaction();
                    result = (int)Transaction.IsolationLevel;
                    CloseConnection();
                    return result;
                }
            }

            /// <summary>
            /// Gets the schemata for the member
            /// </summary>
            public System.Data.DataTable Schemata
            {
                get
                {
                    OpenConnection();
                    schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Schemata, null);
                    CloseConnection();
                    return schemaData;
                }
            }

            /// <summary>
            /// Gets the provider types for the member
            /// </summary>
            public System.Data.DataTable ProviderTypes
            {
                get
                {
                    OpenConnection();
                    schemaData = this.Connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Provider_Types, null);
                    CloseConnection();
                    return schemaData;
                }
            }

            /// <summary>
            /// Gets the catalog separator
            /// </summary>
            public System.String CatalogSeparator
            {
                get { return GetMaxInfo("Catalog_Separator", "LiteralValue"); }
            }

            /// <summary>
            /// Gets the maximum binary length permited
            /// </summary>
            public int MaxBinaryLiteralLength
            {
                get
                {
                    System.String len = GetMaxInfo("Binary_Literal", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len) * 4);
                }
            }

            /// <summary>
            /// Gets the maximum catalog name length permited
            /// </summary>
            public int MaxCatalogNameLength
            {
                get
                {
                    System.String len = GetMaxInfo("Catalog_Name", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len));
                }
            }

            /// <summary>
            /// Gets the maximum character literal length permited
            /// </summary>
            public int MaxCharLiteralLength
            {
                get
                {
                    System.String len = GetMaxInfo("Char_Literal", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len) * 4);
                }
            }

            /// <summary>
            /// Gets the maximum column name length
            /// </summary>
            public int MaxColumnNameLength
            {
                get
                {
                    System.String len = GetMaxInfo("Column_Name", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len));
                }
            }

            /// <summary>
            /// Gets the maximum cursor name length
            /// </summary>
            public int MaxCursorNameLength
            {
                get
                {
                    System.String len = GetMaxInfo("Cursor_Name", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len));
                }
            }

            /// <summary>
            /// Gets the maximum procedure name length
            /// </summary>
            public int MaxProcedureNameLength
            {
                get
                {
                    System.String len = GetMaxInfo("Procedure_Name", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len));
                }
            }

            /// <summary>
            /// Gets the maximum schema name length
            /// </summary>
            public int MaxSchemaNameLength
            {
                get
                {
                    System.String len = GetMaxInfo("Schema_Name", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len));
                }
            }

            /// <summary>
            /// Gets the maximum table name length
            /// </summary>
            public int MaxTableNameLength
            {
                get
                {
                    System.String len = GetMaxInfo("Table_Name", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return (System.Convert.ToInt32(len));
                }
            }

            /// <summary>
            /// Gets the maximum user name length
            /// </summary>
            public int MaxUserNameLength
            {
                get
                {
                    System.String len = GetMaxInfo("User_Name", "Maxlen");
                    if (len.Equals(""))
                        return 0;
                    else
                        return System.Convert.ToInt32(len);
                }
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
            public static bool Add(System.Collections.ICollection c, System.Object obj)
            {
                bool added = false;
                //Reflection. Invoke either the "add" or "Add" method.
                System.Reflection.MethodInfo method;
                try
                {
                    //Get the "add" method for proprietary classes
                    method = c.GetType().GetMethod("Add");
                    if (method == null)
                        method = c.GetType().GetMethod("add");
                    int index = (int)method.Invoke(c, new System.Object[] { obj });
                    if (index >= 0)
                        added = true;
                }
                catch (System.Exception e)
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
            public static bool AddAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {
                System.Collections.IEnumerator e = new System.Collections.ArrayList(c).GetEnumerator();
                bool added = false;

                //Reflection. Invoke "addAll" method for proprietary classes
                System.Reflection.MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("addAll");

                    if (method != null)
                        added = (bool)method.Invoke(target, new System.Object[] { c });
                    else
                    {
                        method = target.GetType().GetMethod("Add");
                        while (e.MoveNext() == true)
                        {
                            bool tempBAdded = (int)method.Invoke(target, new System.Object[] { e.Current }) >= 0;
                            added = added ? added : tempBAdded;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                return added;
            }

            /// <summary>
            /// Removes all the elements from the collection.
            /// </summary>
            /// <param name="c">The collection to remove elements.</param>
            public static void Clear(System.Collections.ICollection c)
            {
                //Reflection. Invoke "Clear" method or "clear" method for proprietary classes
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("Clear");

                    if (method == null)
                        method = c.GetType().GetMethod("clear");

                    method.Invoke(c, new System.Object[] { });
                }
                catch (System.Exception e)
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
            public static bool Contains(System.Collections.ICollection c, System.Object obj)
            {
                bool contains = false;

                //Reflection. Invoke "contains" method for proprietary classes
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("Contains");

                    if (method == null)
                        method = c.GetType().GetMethod("contains");

                    contains = (bool)method.Invoke(c, new System.Object[] { obj });
                }
                catch (System.Exception e)
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
            public static bool ContainsAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {
                System.Collections.IEnumerator e = c.GetEnumerator();

                bool contains = false;

                //Reflection. Invoke "containsAll" method for proprietary classes or "Contains" method for each element in the collection
                System.Reflection.MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("containsAll");

                    if (method != null)
                        contains = (bool)method.Invoke(target, new Object[] { c });
                    else
                    {
                        method = target.GetType().GetMethod("Contains");
                        while (e.MoveNext() == true)
                        {
                            if ((contains = (bool)method.Invoke(target, new Object[] { e.Current })) == false)
                                break;
                        }
                    }
                }
                catch (System.Exception ex)
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
            public static bool Remove(System.Collections.ICollection c, System.Object obj)
            {
                bool changed = false;

                //Reflection. Invoke "remove" method for proprietary classes or "Remove" method
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("remove");

                    if (method != null)
                        method.Invoke(c, new System.Object[] { obj });
                    else
                    {
                        method = c.GetType().GetMethod("Contains");
                        changed = (bool)method.Invoke(c, new System.Object[] { obj });
                        method = c.GetType().GetMethod("Remove");
                        method.Invoke(c, new System.Object[] { obj });
                    }
                }
                catch (System.Exception e)
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
            public static bool RemoveAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {
                System.Collections.ArrayList al = ToArrayList(c);
                System.Collections.IEnumerator e = al.GetEnumerator();

                //Reflection. Invoke "removeAll" method for proprietary classes or "Remove" for each element in the collection
                System.Reflection.MethodInfo method;
                try
                {
                    method = target.GetType().GetMethod("removeAll");

                    if (method != null)
                        method.Invoke(target, new System.Object[] { al });
                    else
                    {
                        method = target.GetType().GetMethod("Remove");
                        System.Reflection.MethodInfo methodContains = target.GetType().GetMethod("Contains");

                        while (e.MoveNext() == true)
                        {
                            while ((bool)methodContains.Invoke(target, new System.Object[] { e.Current }) == true)
                                method.Invoke(target, new System.Object[] { e.Current });
                        }
                    }
                }
                catch (System.Exception ex)
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
            public static bool RetainAll(System.Collections.ICollection target, System.Collections.ICollection c)
            {
                System.Collections.IEnumerator e = new System.Collections.ArrayList(target).GetEnumerator();
                System.Collections.ArrayList al = new System.Collections.ArrayList(c);

                //Reflection. Invoke "retainAll" method for proprietary classes or "Remove" for each element in the collection
                System.Reflection.MethodInfo method;
                try
                {
                    method = c.GetType().GetMethod("retainAll");

                    if (method != null)
                        method.Invoke(target, new System.Object[] { c });
                    else
                    {
                        method = c.GetType().GetMethod("Remove");

                        while (e.MoveNext() == true)
                        {
                            if (al.Contains(e.Current) == false)
                                method.Invoke(target, new System.Object[] { e.Current });
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            /// <summary>
            /// Returns an array containing all the elements of the collection.
            /// </summary>
            /// <returns>The array containing all the elements of the collection.</returns>
            public static System.Object[] ToArray(System.Collections.ICollection c)
            {
                int index = 0;
                System.Object[] objects = new System.Object[c.Count];
                System.Collections.IEnumerator e = c.GetEnumerator();

                while (e.MoveNext())
                    objects[index++] = e.Current;

                return objects;
            }

            /// <summary>
            /// Obtains an array containing all the elements of the collection.
            /// </summary>
            /// <param name="objects">The array into which the elements of the collection will be stored.</param>
            /// <returns>The array containing all the elements of the collection.</returns>
            public static System.Object[] ToArray(System.Collections.ICollection c, System.Object[] objects)
            {
                int index = 0;

                System.Type type = objects.GetType().GetElementType();
                System.Object[] objs = (System.Object[])Array.CreateInstance(type, c.Count);

                System.Collections.IEnumerator e = c.GetEnumerator();

                while (e.MoveNext())
                    objs[index++] = e.Current;

                //If objects is smaller than c then do not return the new array in the parameter
                if (objects.Length >= c.Count)
                    objs.CopyTo(objects, 0);

                return objs;
            }

            /// <summary>
            /// Converts an ICollection instance to an ArrayList instance.
            /// </summary>
            /// <param name="c">The ICollection instance to be converted.</param>
            /// <returns>An ArrayList instance in which its elements are the elements of the ICollection instance.</returns>
            public static System.Collections.ArrayList ToArrayList(System.Collections.ICollection c)
            {
                System.Collections.ArrayList tempArrayList = new System.Collections.ArrayList();
                System.Collections.IEnumerator tempEnumerator = c.GetEnumerator();
                while (tempEnumerator.MoveNext())
                    tempArrayList.Add(tempEnumerator.Current);
                return tempArrayList;
            }
        }

        /*******************************/
        /// <summary>
        /// Represents a collection ob objects that contains no duplicate elements.
        /// </summary>	
        public interface ISetSupport : System.Collections.ICollection, System.Collections.IList
        {
            /// <summary>
            /// Adds a new element to the Collection if it is not already present.
            /// </summary>
            /// <param name="obj">The object to add to the collection.</param>
            /// <returns>Returns true if the object was added to the collection, otherwise false.</returns>
            new bool Add(System.Object obj);

            /// <summary>
            /// Adds all the elements of the specified collection to the Set.
            /// </summary>
            /// <param name="c">Collection of objects to add.</param>
            /// <returns>true</returns>
            bool AddAll(System.Collections.ICollection c);
        }


        /*******************************/
        /// <summary>
        /// SupportClass for the HashSet class.
        /// </summary>
        [Serializable]
        public class HashSetSupport : System.Collections.ArrayList, ISetSupport
        {
            public HashSetSupport()
                : base()
            {
            }

            public HashSetSupport(System.Collections.ICollection c)
            {
                this.AddAll(c);
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
            new public virtual bool Add(System.Object obj)
            {
                bool inserted;

                if ((inserted = this.Contains(obj)) == false)
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
            public bool AddAll(System.Collections.ICollection c)
            {
                System.Collections.IEnumerator e = new System.Collections.ArrayList(c).GetEnumerator();
                bool added = false;

                while (e.MoveNext() == true)
                {
                    if (this.Add(e.Current) == true)
                        added = true;
                }

                return added;
            }

            /// <summary>
            /// Returns a copy of the HashSet instance.
            /// </summary>		
            /// <returns>Returns a shallow copy of the current HashSet.</returns>
            public override System.Object Clone()
            {
                return base.MemberwiseClone();
            }
        }


        /*******************************/
        /// <summary>
        /// This class manages different features for calendars.
        /// The different calendars are internally managed using a hashtable structure.
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
            /// The hashtable that contains the calendars and its properties.
            /// </summary>
            static public CalendarHashTable manager = new CalendarHashTable();

            /// <summary>
            /// Internal class that inherits from HashTable to manage the different calendars.
            /// This structure will contain an instance of System.Globalization.Calendar that represents 
            /// a type of calendar and its properties (represented by an instance of CalendarProperties 
            /// class).
            /// </summary>
            public class CalendarHashTable : System.Collections.Hashtable
            {
                /// <summary>
                /// Gets the calendar current date and time.
                /// </summary>
                /// <param name="calendar">The calendar to get its current date and time.</param>
                /// <returns>A System.DateTime value that indicates the current date and time for the 
                /// calendar given.</returns>
                public System.DateTime GetDateTime(System.Globalization.Calendar calendar)
                {
                    if (this[calendar] != null)
                        return ((CalendarProperties)this[calendar]).dateTime;
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        return this.GetDateTime(calendar);
                    }
                }

                /// <summary>
                /// Sets the specified System.DateTime value to the specified calendar.
                /// </summary>
                /// <param name="calendar">The calendar to set its date.</param>
                /// <param name="date">The System.DateTime value to set to the calendar.</param>
                public void SetDateTime(System.Globalization.Calendar calendar, System.DateTime date)
                {
                    if (this[calendar] != null)
                    {
                        ((CalendarProperties)this[calendar]).dateTime = date;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = date;
                        this.Add(calendar, tempProps);
                    }
                }

                /// <summary>
                /// Sets the corresponding field in an specified calendar with the value given.
                /// If the specified calendar does not have exist in the hash table, it creates a 
                /// new instance of the calendar with the current date and time and then assings it 
                /// the new specified value.
                /// </summary>
                /// <param name="calendar">The calendar to set its date or time.</param>
                /// <param name="field">One of the fields that composes a date/time.</param>
                /// <param name="fieldValue">The value to be set.</param>
                public void Set(System.Globalization.Calendar calendar, int field, int fieldValue)
                {
                    if (this[calendar] != null)
                    {
                        System.DateTime tempDate = ((CalendarProperties)this[calendar]).dateTime;
                        switch (field)
                        {
                            case CalendarManager.DATE:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                                break;
                            case CalendarManager.HOUR:
                                tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
                                break;
                            case CalendarManager.MILLISECOND:
                                tempDate = tempDate.AddMilliseconds(fieldValue - tempDate.Millisecond);
                                break;
                            case CalendarManager.MINUTE:
                                tempDate = tempDate.AddMinutes(fieldValue - tempDate.Minute);
                                break;
                            case CalendarManager.MONTH:
                                //Month value is 0-based. e.g., 0 for January
                                tempDate = tempDate.AddMonths((fieldValue + 1) - tempDate.Month);
                                break;
                            case CalendarManager.SECOND:
                                tempDate = tempDate.AddSeconds(fieldValue - tempDate.Second);
                                break;
                            case CalendarManager.YEAR:
                                tempDate = tempDate.AddYears(fieldValue - tempDate.Year);
                                break;
                            case CalendarManager.DAY_OF_MONTH:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                                break;
                            case CalendarManager.DAY_OF_WEEK:
                                tempDate = tempDate.AddDays((fieldValue - 1) - (int)tempDate.DayOfWeek);
                                break;
                            case CalendarManager.DAY_OF_YEAR:
                                tempDate = tempDate.AddDays(fieldValue - tempDate.DayOfYear);
                                break;
                            case CalendarManager.HOUR_OF_DAY:
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
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, field, fieldValue);
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
                public void Set(System.Globalization.Calendar calendar, int year, int month, int day)
                {
                    if (this[calendar] != null)
                    {
                        this.Set(calendar, CalendarManager.YEAR, year);
                        this.Set(calendar, CalendarManager.MONTH, month);
                        this.Set(calendar, CalendarManager.DATE, day);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, year, month, day);
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
                public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute)
                {
                    if (this[calendar] != null)
                    {
                        this.Set(calendar, CalendarManager.YEAR, year);
                        this.Set(calendar, CalendarManager.MONTH, month);
                        this.Set(calendar, CalendarManager.DATE, day);
                        this.Set(calendar, CalendarManager.HOUR, hour);
                        this.Set(calendar, CalendarManager.MINUTE, minute);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, year, month, day, hour, minute);
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
                public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute, int second)
                {
                    if (this[calendar] != null)
                    {
                        this.Set(calendar, CalendarManager.YEAR, year);
                        this.Set(calendar, CalendarManager.MONTH, month);
                        this.Set(calendar, CalendarManager.DATE, day);
                        this.Set(calendar, CalendarManager.HOUR, hour);
                        this.Set(calendar, CalendarManager.MINUTE, minute);
                        this.Set(calendar, CalendarManager.SECOND, second);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        this.Set(calendar, year, month, day, hour, minute, second);
                    }
                }

                /// <summary>
                /// Gets the value represented by the field specified.
                /// </summary>
                /// <param name="calendar">The calendar to get its date or time.</param>
                /// <param name="field">One of the field that composes a date/time.</param>
                /// <returns>The integer value for the field given.</returns>
                public int Get(System.Globalization.Calendar calendar, int field)
                {
                    if (this[calendar] != null)
                    {
                        int tempHour;
                        switch (field)
                        {
                            case CalendarManager.DATE:
                                return ((CalendarProperties)this[calendar]).dateTime.Day;
                            case CalendarManager.HOUR:
                                tempHour = ((CalendarProperties)this[calendar]).dateTime.Hour;
                                return tempHour > 12 ? tempHour - 12 : tempHour;
                            case CalendarManager.MILLISECOND:
                                return ((CalendarProperties)this[calendar]).dateTime.Millisecond;
                            case CalendarManager.MINUTE:
                                return ((CalendarProperties)this[calendar]).dateTime.Minute;
                            case CalendarManager.MONTH:
                                //Month value is 0-based. e.g., 0 for January
                                return ((CalendarProperties)this[calendar]).dateTime.Month - 1;
                            case CalendarManager.SECOND:
                                return ((CalendarProperties)this[calendar]).dateTime.Second;
                            case CalendarManager.YEAR:
                                return ((CalendarProperties)this[calendar]).dateTime.Year;
                            case CalendarManager.DAY_OF_MONTH:
                                return ((CalendarProperties)this[calendar]).dateTime.Day;
                            case CalendarManager.DAY_OF_YEAR:
                                return (int)(((CalendarProperties)this[calendar]).dateTime.DayOfYear);
                            case CalendarManager.DAY_OF_WEEK:
                                return (int)(((CalendarProperties)this[calendar]).dateTime.DayOfWeek) + 1;
                            case CalendarManager.HOUR_OF_DAY:
                                return ((CalendarProperties)this[calendar]).dateTime.Hour;
                            case CalendarManager.AM_PM:
                                tempHour = ((CalendarProperties)this[calendar]).dateTime.Hour;
                                return tempHour > 12 ? CalendarManager.PM : CalendarManager.AM;

                            default:
                                return 0;
                        }
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        this.Add(calendar, tempProps);
                        return this.Get(calendar, field);
                    }
                }

                /// <summary>
                /// Sets the time in the specified calendar with the long value.
                /// </summary>
                /// <param name="calendar">The calendar to set its date and time.</param>
                /// <param name="milliseconds">A long value that indicates the milliseconds to be set to 
                /// the hour for the calendar.</param>
                public void SetTimeInMilliseconds(System.Globalization.Calendar calendar, long milliseconds)
                {
                    if (this[calendar] != null)
                    {
                        ((CalendarProperties)this[calendar]).dateTime = new System.DateTime(milliseconds);
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = new System.DateTime(System.TimeSpan.TicksPerMillisecond * milliseconds);
                        this.Add(calendar, tempProps);
                    }
                }

                /// <summary>
                /// Gets what the first day of the week is; e.g., Sunday in US, Monday in France.
                /// </summary>
                /// <param name="calendar">The calendar to get its first day of the week.</param>
                /// <returns>A System.DayOfWeek value indicating the first day of the week.</returns>
                public System.DayOfWeek GetFirstDayOfWeek(System.Globalization.Calendar calendar)
                {
                    if (this[calendar] != null)
                    {
                        if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
                        {
                            ((CalendarProperties)this[calendar]).dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
                            ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek = System.DayOfWeek.Sunday;
                        }
                        return ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
                        tempProps.dateTimeFormat.FirstDayOfWeek = System.DayOfWeek.Sunday;
                        this.Add(calendar, tempProps);
                        return this.GetFirstDayOfWeek(calendar);
                    }
                }

                /// <summary>
                /// Sets what the first day of the week is; e.g., Sunday in US, Monday in France.
                /// </summary>
                /// <param name="calendar">The calendar to set its first day of the week.</param>
                /// <param name="firstDayOfWeek">A System.DayOfWeek value indicating the first day of the week
                /// to be set.</param>
                public void SetFirstDayOfWeek(System.Globalization.Calendar calendar, System.DayOfWeek firstDayOfWeek)
                {
                    if (this[calendar] != null)
                    {
                        if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
                            ((CalendarProperties)this[calendar]).dateTimeFormat = new System.Globalization.DateTimeFormatInfo();

                        ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek = firstDayOfWeek;
                    }
                    else
                    {
                        CalendarProperties tempProps = new CalendarProperties();
                        tempProps.dateTime = System.DateTime.Now;
                        tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
                        this.Add(calendar, tempProps);
                        this.SetFirstDayOfWeek(calendar, firstDayOfWeek);
                    }
                }

                /// <summary>
                /// Removes the specified calendar from the hash table.
                /// </summary>
                /// <param name="calendar">The calendar to be removed.</param>
                public void Clear(System.Globalization.Calendar calendar)
                {
                    if (this[calendar] != null)
                        this.Remove(calendar);
                }

                /// <summary>
                /// Removes the specified field from the calendar given.
                /// If the field does not exists in the calendar, the calendar is removed from the table.
                /// </summary>
                /// <param name="calendar">The calendar to remove the value from.</param>
                /// <param name="field">The field to be removed from the calendar.</param>
                public void Clear(System.Globalization.Calendar calendar, int field)
                {
                    if (this[calendar] != null)
                        this.Set(calendar, field, 0);
                }

                /// <summary>
                /// Internal class that represents the properties of a calendar instance.
                /// </summary>
                class CalendarProperties
                {
                    /// <summary>
                    /// The date and time of a calendar.
                    /// </summary>
                    public System.DateTime dateTime;

                    /// <summary>
                    /// The format for the date and time in a calendar.
                    /// </summary>
                    public System.Globalization.DateTimeFormatInfo dateTimeFormat;
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
            private System.Threading.Thread threadField;

            /// <summary>
            /// Initializes a new instance of the ThreadClass class
            /// </summary>
            public ThreadClass()
            {
                threadField = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
            }

            /// <summary>
            /// Initializes a new instance of the Thread class.
            /// </summary>
            /// <param name="Name">The name of the thread</param>
            public ThreadClass(System.String Name)
            {
                threadField = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
                this.Name = Name;
            }

            /// <summary>
            /// Initializes a new instance of the Thread class.
            /// </summary>
            /// <param name="Start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
            public ThreadClass(System.Threading.ThreadStart Start)
            {
                threadField = new System.Threading.Thread(Start);
            }

            /// <summary>
            /// Initializes a new instance of the Thread class.
            /// </summary>
            /// <param name="Start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
            /// <param name="Name">The name of the thread</param>
            public ThreadClass(System.Threading.ThreadStart Start, System.String Name)
            {
                threadField = new System.Threading.Thread(Start);
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
            public System.Threading.Thread Instance
            {
                get
                {
                    return threadField;
                }
                set
                {
                    threadField = value;
                }
            }

            /// <summary>
            /// Gets or sets the name of the thread
            /// </summary>
            public System.String Name
            {
                get
                {
                    return threadField.Name;
                }
                set
                {
                    if (threadField.Name == null)
                        threadField.Name = value;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating the scheduling priority of a thread
            /// </summary>
            public System.Threading.ThreadPriority Priority
            {
                get
                {
                    return threadField.Priority;
                }
                set
                {
                    threadField.Priority = value;
                }
            }

            /// <summary>
            /// Gets a value indicating the execution status of the current thread
            /// </summary>
            public bool IsAlive
            {
                get
                {
                    return threadField.IsAlive;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether or not a thread is a background thread.
            /// </summary>
            public bool IsBackground
            {
                get
                {
                    return threadField.IsBackground;
                }
                set
                {
                    threadField.IsBackground = value;
                }
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
                    threadField.Join(new System.TimeSpan(MiliSeconds * 10000));
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
                    threadField.Join(new System.TimeSpan(MiliSeconds * 10000 + NanoSeconds * 100));
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
            public void Abort(System.Object stateInfo)
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
            public override System.String ToString()
            {
                return "Thread[" + Name + "," + Priority.ToString() + "," + "" + "]";
            }

            /// <summary>
            /// Gets the currently running thread
            /// </summary>
            /// <returns>The currently running thread</returns>
            public static ThreadClass Current()
            {
                ThreadClass CurrentThread = new ThreadClass();
                CurrentThread.Instance = System.Threading.Thread.CurrentThread;
                return CurrentThread;
            }
        }


        /*******************************/
        /// <summary>
        /// The class performs token processing in strings
        /// </summary>
        public class Tokenizer : System.Collections.IEnumerator
        {
            /// Position over the string
            private long currentPos = 0;

            /// Include demiliters in the results.
            private bool includeDelims = false;

            /// Char representation of the String to tokenize.
            private char[] chars = null;

            //The tokenizer uses the default delimiter set: the space character, the tab character, the newline character, and the carriage-return character and the form-feed character
            private string delimiters = " \t\n\r\f";

            /// <summary>
            /// Initializes a new class instance with a specified string to process
            /// </summary>
            /// <param name="source">String to tokenize</param>
            public Tokenizer(System.String source)
            {
                this.chars = source.ToCharArray();
            }

            /// <summary>
            /// Initializes a new class instance with a specified string to process
            /// and the specified token delimiters to use
            /// </summary>
            /// <param name="source">String to tokenize</param>
            /// <param name="delimiters">String containing the delimiters</param>
            public Tokenizer(System.String source, System.String delimiters)
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
            public Tokenizer(System.String source, System.String delimiters, bool includeDelims)
                : this(source, delimiters)
            {
                this.includeDelims = includeDelims;
            }


            /// <summary>
            /// Returns the next token from the token list
            /// </summary>
            /// <returns>The string value of the token</returns>
            public System.String NextToken()
            {
                return NextToken(this.delimiters);
            }

            /// <summary>
            /// Returns the next token from the source string, using the provided
            /// token delimiters
            /// </summary>
            /// <param name="delimiters">String containing the delimiters to use</param>
            /// <returns>The string value of the token</returns>
            public System.String NextToken(System.String delimiters)
            {
                //According to documentation, the usage of the received delimiters should be temporary (only for this call).
                //However, it seems it is not true, so the following line is necessary.
                this.delimiters = delimiters;

                //at the end 
                if (this.currentPos == this.chars.Length)
                    throw new System.ArgumentOutOfRangeException();
                //if over a delimiter and delimiters must be returned
                else if ((System.Array.IndexOf(delimiters.ToCharArray(), chars[this.currentPos]) != -1)
                         && this.includeDelims)
                    return "" + this.chars[this.currentPos++];
                //need to get the token wo delimiters.
                else
                    return nextToken(delimiters.ToCharArray());
            }

            //Returns the nextToken wo delimiters
            private System.String nextToken(char[] delimiters)
            {
                string token = "";
                long pos = this.currentPos;

                //skip possible delimiters
                while (System.Array.IndexOf(delimiters, this.chars[currentPos]) != -1)
                    //The last one is a delimiter (i.e there is no more tokens)
                    if (++this.currentPos == this.chars.Length)
                    {
                        this.currentPos = pos;
                        throw new System.ArgumentOutOfRangeException();
                    }

                //getting the token
                while (System.Array.IndexOf(delimiters, this.chars[this.currentPos]) == -1)
                {
                    token += this.chars[this.currentPos];
                    //the last one is not a delimiter
                    if (++this.currentPos == this.chars.Length)
                        break;
                }
                return token;
            }


            /// <summary>
            /// Determines if there are more tokens to return from the source string
            /// </summary>
            /// <returns>True or false, depending if there are more tokens</returns>
            public bool HasMoreTokens()
            {
                // rlb: Attempt to improve performance by checking just based on length,
                //      this should generally improve performance.
                if (this.chars.Length == 0 || this.chars.Length == currentPos)
                {
                    return false;
                }
                else
                {
                    //keeping the current pos
                    long pos = this.currentPos;

                    try
                    {
                        this.NextToken();
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        return false;
                    }
                    finally
                    {
                        this.currentPos = pos;
                    }
                    return true;
                }
            }

            /// <summary>
            /// Remaining tokens count
            /// </summary>
            public int Count
            {
                get
                {
                    //keeping the current pos
                    long pos = this.currentPos;
                    int i = 0;

                    try
                    {
                        while (true)
                        {
                            this.NextToken();
                            i++;
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        this.currentPos = pos;
                        return i;
                    }
                }
            }

            /// <summary>
            ///  Performs the same action as NextToken.
            /// </summary>
            public System.Object Current
            {
                get
                {
                    return (Object)this.NextToken();
                }
            }

            /// <summary>
            //  Performs the same action as HasMoreTokens.
            /// </summary>
            /// <returns>True or false, depending if there are more tokens</returns>
            public bool MoveNext()
            {
                return this.HasMoreTokens();
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
        public static long FileLength(System.IO.FileInfo file)
        {
            if (file.Exists)
                return file.Length;
            else
                return 0;
        }
    }
}