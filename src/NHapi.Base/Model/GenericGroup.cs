namespace NHapi.Base.Model
{
    using NHapi.Base.Parser;

    /// <summary>
    /// An undefined segment group. This is for storing undefined groups
    /// that appear in XML-encoded messages. Note that if an undefined group appears
    /// in an ER7-encoded message, the group structure won't be clear and we'll just assume
    /// it's a flat list of segments.
    /// </summary>
    /// <author>Bryan Tripp.</author>
    public class GenericGroup : AbstractGroup
    {
        private string name;

        /// <summary>Creates a new instance of GenericGroup. </summary>
        public GenericGroup(IGroup parent, string name, IModelClassFactory factory)
            : base(parent, factory)
        {
            this.name = name;
        }

        /// <summary>
        /// Returns the name specified at construction time.
        /// </summary>
        /// <seealso cref="IStructure.GetStructureName"></seealso>
        public override string GetStructureName()
        {
            // TODO: Does not need to be a function.
            return name;
        }
    }
}