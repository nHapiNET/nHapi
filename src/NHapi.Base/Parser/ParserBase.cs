/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "Parser.java".  Description:
  "Parses HL7 message Strings into HL7 Message objects and
  encodes HL7 Message objects into HL7 message Strings"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

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
    using System.Collections;
    using System.Collections.Specialized;
    using System.IO;

    using NHapi.Base.Log;
    using NHapi.Base.Model;
    using NHapi.Base.Validation;
    using NHapi.Base.Validation.Implementation;

    /// <summary>
    /// Parses HL7 message Strings into HL7 Message objects and
    /// encodes HL7 Message objects into HL7 message Strings.
    /// </summary>
    /// <author>Bryan Tripp (bryan_tripp@sourceforge.net).</author>
    public abstract class ParserBase
    {
        protected static readonly ParserOptions DefaultParserOptions = new ParserOptions();
        private static readonly IHapiLog Log = HapiLogFactory.GetHapiLog(typeof(ParserBase));
        private IValidationContext validationContext;
        private MessageValidator messageValidator;

        /// <summary>
        /// Uses DefaultModelClassFactory for model class lookup.
        /// </summary>
        protected ParserBase()
            : this(new DefaultModelClassFactory())
        {
        }

        /// <param name="theFactory">
        /// custom factory to use for model class lookup.
        /// </param>
        protected ParserBase(IModelClassFactory theFactory)
        {
            Factory = theFactory;
            ValidationContext = new DefaultValidation();
        }

        /// <summary>
        /// Gets the factory used by this Parser for model class lookup.
        /// </summary>
        public virtual IModelClassFactory Factory { get; }

        /// <summary>
        /// Gets or sets the set of validation rules that is applied to messages parsed or encoded by this parser.
        /// </summary>
        public IValidationContext ValidationContext
        {
            get => validationContext;

            set
            {
                validationContext = value;
                messageValidator = new MessageValidator(value, true);
            }
        }

        /// <summary>
        /// Gets the preferred encoding of this Parser.
        /// </summary>
        public abstract string DefaultEncoding { get; }

        /// <summary>
        /// Returns event->structure maps.
        /// </summary>
        private static IDictionary MessageStructures => EventMapper.Instance.Maps;

        /// <summary>
        /// Creates a version-specific MSH object and returns it as a version-independent
        /// MSH interface.
        /// </summary>
        /// <param name="version">HL7 Version.</param>
        /// <param name="factory">Model class factory to be used.</param>
        /// <returns>MSH segment for this version returned by the model class factory.</returns>
        /// <exception cref="HL7Exception">If no matching segment could be found.</exception>
        public static ISegment MakeControlMSH(string version, IModelClassFactory factory)
        {
            ISegment msh;
            try
            {
                var dummy =
                    (IMessage)GenericMessage
                        .GetGenericMessageClass(version)
                        .GetConstructor(new[] { typeof(IModelClassFactory) })
                        !.Invoke(new object[] { factory });

                var @class = factory.GetSegmentClass("MSH", version);
                var constructorParamTypes = new[] { typeof(IGroup), typeof(IModelClassFactory) };
                var constructorParamArgs = new object[] { dummy, factory };
                var constructor = @class.GetConstructor(constructorParamTypes);
                msh = (ISegment)constructor!.Invoke(constructorParamArgs);
            }
            catch (Exception e)
            {
                throw new HL7Exception(
                    $"Couldn't create MSH for version {version} (does your class path include this version?) ... ",
                    ErrorCode.APPLICATION_INTERNAL_ERROR,
                    e);
            }

            return msh;
        }

        /// <summary>
        /// Returns true if the given string represents a valid 2.x version.
        /// Valid versions include "2.0", "2.0D", "2.1", "2.2", "2.3", "2.3.1", "2.4", "2.5".
        /// </summary>
        public static bool ValidVersion(string version)
        {
            return PackageManager.Instance.IsValidVersion(version);
        }

        /// <summary>
        /// Given a concatenation of message type and event (e.g. ADT_A04), and the
        /// version, finds the corresponding message structure (e.g. ADT_A01).  This
        /// is needed because some events share message structures, although it is not needed
        /// when the message structure is explicitly valued in MSH-9-3.
        /// If no mapping is found, returns the original name.
        /// </summary>
        /// <param name="name">A concatenation of message type and event (e.g. ADT_A04).</param>
        /// <param name="version">The name of the HL7 version to which the message belongs (eg "2.5").</param>
        /// <exception cref="HL7Exception">Thrown if there is an error retrieving the map, or if the given version is invalid.</exception>
        public static string GetMessageStructureForEvent(string name, string version)
        {
            if (!ValidVersion(version))
            {
                throw new HL7Exception($"The version {version} is unknown");
            }

            NameValueCollection p;
            try
            {
                p = (NameValueCollection)MessageStructures[version];
            }
            catch (IOException ioe)
            {
                throw new HL7Exception("Unable to access message structures", ioe);
            }

            if (p == null)
            {
                throw new HL7Exception($"No map found for version {version}");
            }

            var structure = p.Get(name) ?? name;

            return structure;
        }

        /// <summary>
        /// Parses a message string and returns the corresponding Message object. Uses the default
        /// <see cref="ParserOptions"/>.
        /// </summary>
        /// <param name="message">A string that contains an HL7 message.</param>
        /// <returns>A <see cref="IMessage"/> object parsed from the given string.</returns>
        /// <exception cref="HL7Exception">If the message is not correctly formatted.</exception>
        /// <exception cref="EncodingNotSupportedException">If the message encoded is not supported by this parser.</exception>
        public virtual IMessage Parse(string message)
        {
            return Parse(message, DefaultParserOptions);
        }

        /// <summary>
        /// Parses a message string and returns the corresponding Message object.
        /// </summary>
        /// <param name="message">A string that contains an HL7 message.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <returns>A <see cref="IMessage"/> object parsed from the given string.</returns>
        /// <exception cref="HL7Exception">If the message is not correctly formatted.</exception>
        /// <exception cref="EncodingNotSupportedException">If the message encoded is not supported by this parser.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="parserOptions"/> is null.</exception>
        public virtual IMessage Parse(string message, ParserOptions parserOptions)
        {
            parserOptions ??= DefaultParserOptions;

            var encoding = GetEncoding(message);

            if (!SupportsEncoding(encoding))
            {
                string startOfMessage = null;
                if (message.StartsWith("MSH", StringComparison.Ordinal))
                {
                    var indexOfCarriageReturn = message.IndexOf('\r');
                    if (indexOfCarriageReturn > 0)
                    {
                        startOfMessage = message.Substring(0, indexOfCarriageReturn);
                    }
                }

                startOfMessage ??= message.Substring(0, Math.Min(message.Length, 50));

                throw new EncodingNotSupportedException(
                    $"Determine encoding for message. The following is the first 50 chars of the message for reference, although this may not be where the issue is: {startOfMessage}");
            }

            var version = GetVersion(message);
            if (!parserOptions.AllowUnknownVersions && !ValidVersion(version))
            {
                throw new HL7Exception(
                    $"Can't process message of version '{version}' - version not recognized",
                    ErrorCode.UNSUPPORTED_VERSION_ID);
            }

            return Parse(message, version, parserOptions);
        }

        /// <summary>
        /// Parse a message to a specific assembly. Uses the default <see cref="ParserOptions"/>.
        /// </summary>
        /// <param name="message">A string that contains an HL7 message.</param>
        /// <param name="version">the name of the HL7 version to which the message belongs (eg "2.5").</param>
        /// <returns></returns>
        public virtual IMessage Parse(string message, string version)
        {
            return Parse(message, version, DefaultParserOptions);
        }

        /// <summary>
        /// Parse a message to a specific assembly.
        /// </summary>
        /// <param name="message">A string that contains an HL7 message.</param>
        /// <param name="version">the name of the HL7 version to which the message belongs (eg "2.5").</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If <paramref name="parserOptions"/> is null.</exception>
        public virtual IMessage Parse(string message, string version, ParserOptions parserOptions)
        {
            if (parserOptions is null)
            {
                throw new ArgumentNullException(nameof(parserOptions));
            }

            var encoding = GetEncoding(message);
            if (!SupportsEncoding(encoding))
            {
                throw new EncodingNotSupportedException(
                    $"Can't parse message beginning {message.Substring(0, Math.Min(message.Length, 50) - 0)}");
            }

            messageValidator.Validate(message, encoding.Equals("XML"), version);
            var result = DoParse(message, version, parserOptions);
            messageValidator.Validate(result);

            return result;
        }

        // TODO: should this be public?
        // https://github.com/nHapiNET/nHapi/issues/399
        /// <summary>
        /// Parses a particular message and returns the encoded structure. Uses the default
        /// <see cref="ParserOptions"/>.
        /// </summary>
        /// <param name="message">The message to encode.</param>
        /// <param name="string">The string to parse.</param>
        /// <exception cref="HL7Exception">If there is a problem encoding.</exception>
        public void Parse(IMessage message, string @string)
        {
            Parse(message, @string, DefaultParserOptions);
        }

        // TODO: should this be public?
        // https://github.com/nHapiNET/nHapi/issues/399
        /// <summary>
        /// Parses a particular message and returns the encoded structure.
        /// </summary>
        /// <param name="message">The message to encode.</param>
        /// <param name="string">The string to parse.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <exception cref="HL7Exception">If there is a problem encoding.</exception>
        public abstract void Parse(IMessage message, string @string, ParserOptions parserOptions);

        /// <summary>
        /// Formats a <see cref="IMessage"/> object into an HL7 message string using the given encoding.
        /// </summary>
        /// <param name="source">An <see cref="IMessage"/> object from which to construct an encoded message string.</param>
        /// <param name="encoding">the name of the HL7 encoding to use (eg "XML"; most implementations support only
        /// one encoding).
        /// </param>
        /// <returns>The encoded message.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        public virtual string Encode(IMessage source, string encoding)
        {
            return Encode(source, encoding, DefaultParserOptions);
        }

        /// <summary>
        /// Formats a <see cref="IMessage"/> object into an HL7 message string using the given encoding.
        /// </summary>
        /// <param name="source">An <see cref="IMessage"/> object from which to construct an encoded message string.</param>
        /// <param name="encoding">the name of the HL7 encoding to use (eg "XML"; most implementations support only
        /// one encoding).
        /// </param>
        /// <param name="parserOptions">Contains configuration that will be applied when encoding.</param>
        /// <returns>The encoded message.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        public virtual string Encode(IMessage source, string encoding, ParserOptions parserOptions)
        {
            messageValidator.Validate(source);
            var result = DoEncode(source, encoding, parserOptions);
            messageValidator.Validate(result, encoding.Equals("XML"), source.Version);

            return result;
        }

        /// <summary>
        /// Formats a Message object into an HL7 message string using this parsers
        /// default encoding.
        /// </summary>
        /// <param name="source">
        /// A Message object from which to construct an encoded message string.
        /// </param>
        /// <returns>The encoded message.</returns>
        public virtual string Encode(IMessage source)
        {
            return Encode(source, DefaultParserOptions);
        }

        /// <summary>
        /// Formats a Message object into an HL7 message string using this parsers
        /// default encoding.
        /// </summary>
        /// <param name="source">
        /// A Message object from which to construct an encoded message string.
        /// </param>
        /// <param name="parserOptions">Contains configuration that will be applied when encoding.</param>
        /// <returns>The encoded message.</returns>
        public virtual string Encode(IMessage source, ParserOptions parserOptions)
        {
            var encoding = DefaultEncoding;

            messageValidator.Validate(source);
            var result = DoEncode(source, parserOptions);
            messageValidator.Validate(result, encoding.Equals("XML"), source.Version);

            return result;
        }

        /// <summary>
        /// Returns a String representing the encoding of the given message, if
        /// the encoding is recognized.
        /// <para>
        /// For example if the given message appears
        /// to be encoded using HL7 2.x XML rules then "XML" would be returned.
        /// </para>
        /// <para>
        /// If the encoding is not recognized then null is returned.
        /// </para>
        /// That this method returns a specific encoding does not guarantee that the
        /// message is correctly encoded (e.g. well formed XML) - just that
        /// it is not encoded using any other encoding than the one returned.
        /// </summary>
        /// <param name="message">The message to inspect.</param>
        /// <returns>
        /// "XML" or "ER7" or null if the encoding is not recognized.
        /// </returns>
        public abstract string GetEncoding(string message);

        /// <summary>
        /// Returns true if and only if the given encoding is supported
        /// by this Parser.
        /// </summary>
        /// <param name="encoding">The encoding, "XML" or "ER7".</param>
        /// <returns>true if this parser supports parsing message encoded this way.</returns>
        public bool SupportsEncoding(string encoding)
        {
            return DefaultEncoding.Equals(encoding);
        }

        /// <summary>
        /// Returns a minimal amount of data from a message string, including only the
        /// data needed to send a response to the remote system.
        /// <para>This includes the following fields:</para>
        /// <list type="bullet">
        /// <item><description>field separator</description></item>
        /// <item><description>encoding characters</description></item>
        /// <item><description>processing ID</description></item>
        /// <item><description>message control ID</description></item>
        /// </list>
        /// This method is intended for use when there is an error parsing a message,
        /// (so the Message object is unavailable) but an error message must be sent
        /// back to the remote system including some of the information in the inbound
        /// message.
        /// <para>This method parses only that required information, hopefully
        /// avoiding the condition that caused the original error.
        /// </para>
        /// The other fields in the returned MSH segment are empty.
        /// </summary>
        public abstract ISegment GetCriticalResponseData(string message);

        /// <summary>
        /// For response messages, returns the value of MSA-2 (the message ID of the message
        /// sent by the sending system).
        /// <para>
        /// This value may be needed prior to main message parsing,
        /// so that (particularly in a multi-threaded scenario) the message can be routed to
        /// the thread that sent the request.
        /// </para>
        /// We need this information first so that any
        /// parse exceptions are thrown to the correct thread.
        /// <para>
        /// Implementers of Parsers should
        /// take care to make the implementation of this method very fast and robust.
        /// </para>
        /// </summary>
        /// <returns>
        /// null if MSA-2 can not be found (e.g. if the message is not a
        /// response message).
        /// </returns>
        public abstract string GetAckID(string message);

        /// <summary>
        /// Returns the version ID (MSH-12) from the given message, without fully parsing the message.
        /// The version is needed prior to parsing in order to determine the message class
        /// into which the text of the message should be parsed.
        /// </summary>
        /// <param name="message">The message to inspect.</param>
        /// <exception cref="HL7Exception">Thrown if the version field can not be found.</exception>
        public virtual string GetVersion(string message)
        {
            return GetVersion(message, DefaultParserOptions);
        }

        /// <summary>
        /// Returns the version ID (MSH-12) from the given message, without fully parsing the message.
        /// The version is needed prior to parsing in order to determine the message class
        /// into which the text of the message should be parsed.
        /// </summary>
        /// <param name="message">The message to inspect.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <exception cref="HL7Exception">Thrown if the version field can not be found.</exception>
        public abstract string GetVersion(string message, ParserOptions parserOptions);

        /// <summary>
        /// Called by <see cref="Encode(IMessage, string, ParserOptions)"/> to perform implementation-specific encoding work.
        /// </summary>
        /// <param name="source">a Message object from which to construct an encoded message string.</param>
        /// <param name="encoding">the name of the HL7 encoding to use (eg "XML"; most implementations support only one encoding).</param>
        /// <param name="parserOptions">Contains configuration that will be applied when encoding.</param>
        /// <returns>The encoded message.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        protected internal abstract string DoEncode(IMessage source, string encoding, ParserOptions parserOptions);

        /// <summary>
        /// Called by <see cref="Encode(IMessage, ParserOptions)"/> to perform implementation-specific encoding work.
        /// </summary>
        /// <param name="source">a Message object from which to construct an encoded message string.</param>
        /// <param name="parserOptions">Contains configuration that will be applied when encoding.</param>
        /// <returns>The encoded message.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        protected internal abstract string DoEncode(IMessage source, ParserOptions parserOptions);

        /// <summary>
        /// Called by <see cref="Parse(string, string)"/> to perform implementation-specific parsing work.
        /// </summary>
        /// <param name="message">a String that contains an HL7 message.</param>
        /// <param name="version">the name of the HL7 version to which the message belongs (eg "2.5").</param>
        /// <param name="parserOptions">Contains configuration that will be applied when parsing.</param>
        /// <returns>A HAPI Message object parsed from the given String.</returns>
        /// <exception cref="HL7Exception">Thrown if the data fields in the message do not permit encoding (e.g. required fields are null).</exception>
        /// <exception cref="EncodingNotSupportedException">Thrown if the requested encoding is not supported by this parser.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="parserOptions"/> is null.</exception>
        protected internal abstract IMessage DoParse(string message, string version, ParserOptions parserOptions);

        /// <summary>
        /// Note that the validation context of the resulting message is set to this parsers validation
        /// context. The validation context is used within <see cref="IPrimitive.Value"/>.
        /// </summary>
        /// <param name="theName">name of the desired structure in the form XXX_YYY.</param>
        /// <param name="theVersion">HL7 version (e.g. "2.3").</param>
        /// <param name="isExplicit">
        /// true if the structure was specified explicitly in MSH-9-3, false if it
        /// was inferred from MSH-9-1 and MSH-9-2.  If false, a lookup may be performed to find
        /// an alternate structure corresponding to that message type and event.
        /// </param>
        /// <returns>a Message instance.</returns>
        /// <exception cref="HL7Exception">Thrown when the version is not recognized or no appropriate class can be found or the Message.</exception>
        protected internal virtual IMessage InstantiateMessage(string theName, string theVersion, bool isExplicit)
        {
            Type messageClass;
            try
            {
                messageClass = Factory.GetMessageClass(theName, theVersion, isExplicit);
            }
            catch (Exception ex)
            {
                throw new HL7Exception(
                    $"Can't find message class in current package list: {theName}",
                    ErrorCode.UNSUPPORTED_MESSAGE_TYPE,
                    ex);
            }

            if (messageClass == null)
            {
                throw new HL7Exception(
                    $"Can't find message class in current package list: {theName}",
                    ErrorCode.UNSUPPORTED_MESSAGE_TYPE);
            }

            Log.Info($"Instantiating msg of class {messageClass.FullName}");
            var constructor = messageClass.GetConstructor(new[] { typeof(IModelClassFactory) });
            var result = (IMessage)constructor!.Invoke(new object[] { Factory });
            result.ValidationContext = validationContext;

            return result;
        }
    }
}