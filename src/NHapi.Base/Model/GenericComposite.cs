using System;
using System.Collections;

namespace NHapi.Base.Model
{
    /// <summary> An unspecified Composite datatype that has an undefined number of components, each 
    /// of which is a Varies.  
    /// This is used to store Varies data, when the data type is unknown.  It is also 
    /// used to store unrecognized message constituents.  
    /// </summary>
    /// <author>  Bryan Tripp
    /// </author>
    public class GenericComposite : AbstractType, IComposite
    {
        /// <summary> Returns an array containing the components of this field.</summary>
        public virtual IType[] Components
        {
            get
            {
                IType[] ret = new IType[components.Count];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = (IType) components[i];
                }
                return ret;
            }
        }

        /// <summary>Returns the name of the type (used in XML encoding and profile checking)  </summary>
        public override String TypeName
        {
            get { return "UNKNOWN"; }
        }

        private ArrayList components;
        private IMessage message;

        /// <summary>Creates a new instance of GenericComposite</summary>
        /// <param name="theMessage">message to which this Type belongs</param>
        public GenericComposite(IMessage theMessage)
            : this(theMessage, null)
        {
        }

        /// <summary>Creates a new instance of GenericComposite</summary>
        /// <param name="theMessage">message to which this Type belongs</param>
        /// <param name="description">The description of this type</param>
        public GenericComposite(IMessage theMessage, string description)
            : base(theMessage, description)
        {
            components = new ArrayList(20);
        }

        /// <summary> Returns the single component of this composite at the specified position (starting at 0) - 
        /// Creates it (and any nonexistent components before it) if necessary.  
        /// </summary>
        public virtual IType this[int index]
        {
            get
            {
                for (int i = components.Count; i <= index; i++)
                {
                    components.Add(new Varies(message));
                }
                return (IType) components[index];
            }
        }
    }
}