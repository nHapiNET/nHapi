namespace NHapi.Base.Parser
{
    public class ParserOptions
    {
        public ParserOptions()
        {
            DefaultObx2Type = null;
            InvalidObx2Type = null;
            UnexpectedSegmentBehaviour = UnexpectedSegmentBehaviour.AddInline;
            NonGreedyMode = false;
        }

        /// <summary>
        /// If this property is set, the value provides a default datatype ("ST",
        /// "NM", etc) for an OBX segment with a missing OBX-2 value. This is useful
        /// when parsing messages from systems which do not correctly populate OBX-2.
        /// </summary>
        /// <example>
        /// <para>
        /// For example, if this property is set to "ST", and the following OBX
        /// segment is encountered:
        /// <code>
        /// OBX|||||This is a value
        /// </code>
        /// It will be parsed as though it had read:
        /// <code>
        /// OBX||ST|||This is a value
        /// </code>
        /// </para>
        /// </example>
        public string DefaultObx2Type { get; set; }

        /// <summary>
        /// If this property is set, the value provides a default datatype ("ST",
        /// "NM", etc) for an OBX segment with an invalid OBX-2 value. This is useful
        /// when parsing messages from systems which do not correctly populate OBX-2.
        /// </summary>
        /// <example>
        /// <para>
        /// For example, if this property is set to "ST", and the following OBX
        /// segment is encountered:
        /// <code>
        /// OBX||INVALID|||This is a value
        /// </code>
        /// It will be parsed as though it had read:
        /// <code>
        /// OBX||ST|||This is a value
        /// </code>
        /// </para>
        /// </example>
        public string InvalidObx2Type { get; set; }

        /// <summary>
        /// Gets or Sets the behaviour to use when parsing a message and a nonstandard segment is found.
        /// </summary>
        /// <remarks>The default value is <see cref="Parser.UnexpectedSegmentBehaviour.AddInline"/>.</remarks>
        public UnexpectedSegmentBehaviour UnexpectedSegmentBehaviour { get; set; }

        /// <summary>
        /// If set to <c>true</c> (default is <c>false</c>), pipe parser will be put in non-greedy mode. This setting
        /// applies only to <see cref="PipeParser"/> and will have no effect on <see cref="XMLParser"/>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        ///     In non-greedy mode, if the message structure being parsed has an ambiguous choice of where to put a segment
        ///     because there is a segment matching the current segment name in both a later position in the message, and
        ///     in an earlier position as a part of a repeating group, the earlier position will be chosen.
        /// </para>
        /// <para>
        ///     This mode is useful for example when parsing OML^O21 messages containing multiple orders.
        /// </para>
        /// </remarks>
        ///
        /// <example>
        /// <para>
        ///     This is perhaps best explained with an example. Consider the following structure:
        ///     <code>
        ///         MSH
        ///         GROUP_1 (start)
        ///         {
        ///            AAA
        ///            BBB
        ///            GROUP_2 (start)
        ///            {
        ///               AAA
        ///            }
        ///            GROUP_2 (end)
        ///         }
        ///         GROUP_1 (end)
        ///     </code>
        /// </para>
        /// <para>
        ///     For the above example, consider a message containing the following segments:
        ///     <code>
        ///         MSH
        ///         AAA
        ///         BBB
        ///         AAA
        ///     </code>
        /// </para>
        /// <para>
        ///     In this example, when the second AAA segment is encountered, there are two possible choices. It would be
        ///     placed in GROUP_2, or it could be placed in a second repetition of GROUP_1. By default it will be placed in
        ///     GROUP_2, but in non-greedy mode it will be put in a new repetition of GROUP_1.
        /// </para>
        /// </example>
        public bool NonGreedyMode { get; set; }
    }
}
