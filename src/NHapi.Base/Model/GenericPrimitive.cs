namespace NHapi.Base.Model
{
    /// <summary>
    /// An unspecified Primitive datatype that imposes no constraints on its string
    /// value. This is used to store Varies data, when the data type is unknown. It is also
    /// used to store unrecognized message constituents.
    /// </summary>
    /// <author>Bryan Tripp.</author>
    public class GenericPrimitive : AbstractPrimitive, IPrimitive
    {
        /// <summary>
        /// Creates a new instance of GenericPrimitive.
        /// </summary>
        public GenericPrimitive(IMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// Gets or sets the string representation of the value of this field.
        /// </summary>
        public override string Value { get; set; }

        /// <summary>
        /// Returns the name of the type (used in XML encoding and profile checking).
        /// </summary>
        public override string TypeName => "UNKNOWN";

        /// <summary>
        /// Gets the version.
        /// </summary>
        public virtual string Version => null;
    }
}