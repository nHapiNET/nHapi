namespace NHapi.SourceGeneration
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SQLException : Exception
    {
        public SQLException()
        {
        }

        public SQLException(string message)
            : base(message)
        {
        }

        public SQLException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected SQLException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}