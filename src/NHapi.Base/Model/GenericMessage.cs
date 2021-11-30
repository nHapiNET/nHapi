namespace NHapi.Base.Model
{
    using System;
#if !NET35
    using System.Collections.Concurrent;
#endif

    using NHapi.Base;
    using NHapi.Base.Log;
    using NHapi.Base.Parser;
#if NET35
    using NHapi.Base.Util;
#endif

    /// <summary>
    /// A generic HL7 message, meant for parsing message with unrecognized structures
    /// into a flat list of segments.
    /// </summary>
    /// <author>Bryan Tripp.</author>
    public abstract class GenericMessage : AbstractMessage
    {
        // TODO: when we only target netstandard2.0 and above consider converting to ConcurrentDictionary
#if NET35
        private static readonly SynchronizedCache<string, Type> GenericMessages = new SynchronizedCache<string, Type>();
#else
        private static readonly ConcurrentDictionary<string, Type> GenericMessages = new ConcurrentDictionary<string, Type>();
#endif

        /// <summary>
        /// Creates a new instance of GenericMessage.
        /// </summary>
        /// <param name="factory">class factory for contained structures.</param>
        public GenericMessage(IModelClassFactory factory)
            : base(factory)
        {
            try
            {
                AddNonstandardSegment("MSH");
            }
            catch (HL7Exception e)
            {
                var message = "Unexpected error adding GenericSegment to GenericMessage.";
                HapiLogFactory.GetHapiLog(GetType()).Error(message, e);
                throw new ApplicationException(message);
            }
        }

        [Obsolete("This method has been replaced by 'GetGenericMessageClass'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Style",
            "IDE1006:Naming Styles",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static Type getGenericMessageClass(string version)
        {
            return GetGenericMessageClass(version);
        }

        /// <summary>
        /// Returns a subclass of GenericMessage corresponding to a certain version.
        /// This is needed so that version-specific segments can be added as the message
        /// is parsed.
        /// </summary>
        public static Type GetGenericMessageClass(string version)
        {
            if (!ParserBase.ValidVersion(version))
            {
                throw new ArgumentException($"The version {version} is not recognized");
            }

            Type c;
            if (GenericMessages.ContainsKey(version))
            {
                c = GenericMessages[version];
            }
            else
            {
                var versionClassName = $"V{version.Replace(".", string.Empty)}";
                var fullName = $"{typeof(GenericMessage).FullName}+{versionClassName}";

                c = Type.GetType(fullName, false);

                if (c != null)
                {
                    GenericMessages.TryAdd(version, c);
                }
            }

            return c;
        }

        /// <summary>
        /// Version 2.1 generic message.
        /// </summary>
        public class V21 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V21(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.1";
        }

        /// <summary>
        /// Version 2.2 generic message.
        /// </summary>
        public class V22 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V22(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.2";
        }

        /// <summary>
        /// Version 2.3 generic message.
        /// </summary>
        public class V23 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V23(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.3";
        }

        /// <summary>
        /// Version 2.3.1 generic message.
        /// </summary>
        public class V231 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V231(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.3.1";
        }

        /// <summary>
        /// Version 2.4 generic message.
        /// </summary>
        public class V24 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V24(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.4";
        }

        /// <summary>
        /// Version 2.5 generic message.
        /// </summary>
        public class V25 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V25(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.5";
        }

        /// <summary>
        /// Version 2.5.1 generic message.
        /// </summary>
        public class V251 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V251(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.5.1";
        }

        /// <summary>
        /// Version 2.6 generic message.
        /// </summary>
        public class V26 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V26(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.6";
        }

        /// <summary>
        /// Version 2.7 generic message.
        /// </summary>
        public class V27 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V27(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.7";
        }

        /// <summary>
        /// Version 2.7.1 generic message.
        /// </summary>
        public class V271 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V271(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.7.1";
        }

        /// <summary>
        /// Version 2.8 generic message.
        /// </summary>
        public class V28 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V28(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.8";
        }

        /// <summary>
        /// Version 2.8.1 generic message.
        /// </summary>
        public class V281 : GenericMessage
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factory"></param>
            public V281(IModelClassFactory factory)
                : base(factory)
            {
            }

            /// <summary>
            /// Version of message.
            /// </summary>
            public override string Version => "2.8.1";
        }
    }
}