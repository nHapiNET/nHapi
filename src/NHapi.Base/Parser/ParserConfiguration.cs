namespace NHapi.Base.Parser
{
    public class ParserConfiguration
    {
        public ParserConfiguration()
        {
            NonGreedyMode = false;
        }

        /// <summary>
        /// If set to true (default is false), pipe parser will be put in non-greedy mode. This setting applies only to
        /// Pipe Parsers and will have no effect on XML Parsers.
        ///
        /// In non-greedy mode, if the message structure being parsed has an ambiguous choice of where to put a segment
        /// because there is a segment matching the current segment name in both a later position in the message, and
        /// in an earlier position as a part of a repeating group, the earlier position will be chosen.
        ///
        /// This is perhaps best explained with an example. Consider the following structure:
        /// MSH
        /// GROUP_1 (start)
        /// {
        ///    AAA
        ///    BBB
        ///    GROUP_2 (start)
        ///    {
        ///       AAA
        ///    }
        ///    GROUP_2 (end)
        /// }
        /// GROUP_1 (end)
        ///
        /// For the above example, consider a message containing the following segments:
        /// MSH
        /// AAA
        /// BBB
        /// AAA
        ///
        /// In this example, when the second AAA segment is encountered, there are two possible choices. It would be
        /// placed in GROUP_2, or it could be placed in a second repetition of GROUP_1. By default it will be placed in
        /// GROUP_2, but in non-greedy mode it will be put in a new repetition of GROUP_1.
        ///
        /// This mode is useful for example when parsing OML^O21 messages containing multiple orders.
        /// </summary>
        public bool NonGreedyMode { get; set; }
    }
}
