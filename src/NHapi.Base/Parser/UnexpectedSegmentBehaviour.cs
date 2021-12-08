namespace NHapi.Base.Parser
{
    using NHapi.Base.Model;

    /// <summary>
    /// Defines the behaviour to use when an unexpected segment is discovered while parsing a message.
    /// </summary>
    /// <remarks>See <see cref="ParserOptions.UnexpectedSegmentBehaviour"/>.</remarks>
    public enum UnexpectedSegmentBehaviour
    {
        /// <summary>
        /// Add the segment as a <see cref="IGroup.AddNonstandardSegment(string, int)"/>
        /// at the current location, even if the current location is in a child group within the message.
        /// </summary>
        /// <remarks>This is the default.</remarks>
        AddInline,

        /// <summary>
        /// Return the parser back to the root of the message (even if the last segment was in a group) and add
        /// the unexpected segment as a <see cref="IGroup.AddNonstandardSegment(string, int)"/>.
        /// </summary>
        DropToRoot,

        /// <summary>
        /// Throw an <see cref="HL7Exception"/>
        /// </summary>
        ThrowHl7Exception,
    }
}