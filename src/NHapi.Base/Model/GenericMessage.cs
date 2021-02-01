using System;
using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;

namespace NHapi.Base.Model
{
    /// <summary> A generic HL7 message, meant for parsing message with unrecognized structures
    /// into a flat list of segments.
    /// </summary>
    /// <author>  Bryan Tripp
    /// </author>
    public abstract class GenericMessage : AbstractMessage
    {
        /// <summary> Creates a new instance of GenericMessage. 
        /// 
        /// </summary>
        /// <param name="factory">class factory for contained structures 
        /// </param>
        public GenericMessage(IModelClassFactory factory)
            : base(factory)
        {
            try
            {
                addNonstandardSegment("MSH");
            }
            catch (HL7Exception e)
            {
                String message = "Unexpected error adding GenericSegment to GenericMessage.";
                HapiLogFactory.GetHapiLog(GetType()).Error(message, e);
                throw new ApplicationException(message);
            }
        }

        /// <summary> Returns a subclass of GenericMessage corresponding to a certain version.  
        /// This is needed so that version-specific segments can be added as the message
        /// is parsed.  
        /// </summary>
        public static Type getGenericMessageClass(String version)
        {
            if (!ParserBase.ValidVersion(version))
                throw new ArgumentException("The version " + version + " is not recognized");

            Type c = null;
            if (version.Equals("2.1"))
            {
                c = typeof (V21);
            }
            else if (version.Equals("2.2"))
            {
                c = typeof (V22);
            }
            else if (version.Equals("2.3"))
            {
                c = typeof (V23);
            }
            else if (version.Equals("2.3.1"))
            {
                c = typeof (V231);
            }
            else if (version.Equals("2.4"))
            {
                c = typeof (V24);
            }
            else if (version.Equals("2.5"))
            {
                c = typeof (V25);
            }
            return c;
        }

        /// <summary>
        /// Version 2.1 generic message
        /// </summary>
        public class V21 : GenericMessage
        {
            /// <summary>
            /// Version of message
            /// </summary>
            public override String Version
            {
                get { return "2.1"; }
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="factory"></param>
            public V21(IModelClassFactory factory)
                : base(factory)
            {
            }
        }

        /// <summary>
        /// Version 2.2 generic message
        /// </summary>
        public class V22 : GenericMessage
        {
            /// <summary>
            /// Version of message
            /// </summary>
            public override String Version
            {
                get { return "2.2"; }
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="factory"></param>
            public V22(IModelClassFactory factory)
                : base(factory)
            {
            }
        }

        /// <summary>
        /// Version 2.3 generic message
        /// </summary>
        public class V23 : GenericMessage
        {
            /// <summary>
            /// Version of message
            /// </summary>
            public override String Version
            {
                get { return "2.3"; }
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="factory"></param>
            public V23(IModelClassFactory factory)
                : base(factory)
            {
            }
        }

        /// <summary>
        /// Version 2.3.1 generic message
        /// </summary>
        public class V231 : GenericMessage
        {
            /// <summary>
            /// Version of message
            /// </summary>
            public override String Version
            {
                get { return "2.3.1"; }
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="factory"></param>
            public V231(IModelClassFactory factory)
                : base(factory)
            {
            }
        }

        /// <summary>
        /// Version 2.4 generic message
        /// </summary>
        public class V24 : GenericMessage
        {
            /// <summary>
            /// Version of message
            /// </summary>
            public override String Version
            {
                get { return "2.4"; }
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="factory"></param>
            public V24(IModelClassFactory factory)
                : base(factory)
            {
            }
        }

        /// <summary>
        /// Version 2.5 generic message
        /// </summary>
        public class V25 : GenericMessage
        {
            /// <summary>
            /// Version of message
            /// </summary>
            public override String Version
            {
                get { return "2.5"; }
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="factory"></param>
            public V25(IModelClassFactory factory)
                : base(factory)
            {
            }
        }
    }
}