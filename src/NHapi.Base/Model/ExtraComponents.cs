namespace NHapi.Base.Model
{
    using System;
    using System.Collections;

    /// <summary>
    /// <para>
    /// A set of "extra" components (sub-components) that are not a standard part
    /// of a field (component) but have been added at runtime.  The purpose is to allow
    /// processing of locally-defined extensions to datatypes without the need for a
    /// custom message definition.
    /// </para>
    ///
    /// <para>
    /// Extra components are not treated uniformly with standard components (e.g.
    /// they are not accessible through methods like Primitive.getValue() and
    /// Composite.getComponent()).  To do so would blur the distinction between
    /// primitive and composite types (i.e. leaf and non-leaf nodes), which seems
    /// nice and polymorphic for a moment but actually isn't helpful.
    /// Furthermore, the auto-generated classes do not define accessors to extra
    /// components, because they are meant to encourage and enforce use of the standard
    /// message structure -- stepping outside the standard structure must be
    /// deliberate.
    /// </para>
    ///
    /// <para>
    /// Note that a uniformity of access to standard and extra components is provided
    /// by Terser.
    /// </para>
    /// </summary>
    /// <author>Bryan Tripp.</author>
    public class ExtraComponents
    {
        private ArrayList comps;
        private IMessage message;

        /// <summary>
        /// Creates a new instance of ExtraComponents.
        /// </summary>
        public ExtraComponents(IMessage message)
        {
            comps = new ArrayList();
            this.message = message;
        }

        [Obsolete("This method has been replaced by 'NumComponents'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual int numComponents()
        {
            return NumComponents();
        }

        /// <summary>
        /// Returns the number of existing extra components.
        /// </summary>
        public virtual int NumComponents()
        {
            return comps.Count;
        }

        [Obsolete("This method has been replaced by 'GetComponent'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual Varies getComponent(int comp)
        {
            return GetComponent(comp);
        }

        /// <summary>
        /// Returns the component at the given location, creating it
        /// and all preceding components if necessary.
        /// </summary>
        /// <param name="comp">
        /// The extra component number starting at 0 (i.e. 0 is the first extra component).
        /// </param>
        public virtual Varies GetComponent(int comp)
        {
            EnsureComponentAndPredecessorsExist(comp);
            return (Varies)comps[comp];
        }

        /// <summary> Checks that the component at the given location exists, and that
        /// all preceding components exist, creating any missing ones.
        /// </summary>
        private void EnsureComponentAndPredecessorsExist(int comp)
        {
            for (var i = comps.Count; i <= comp; i++)
            {
                comps.Add(new Varies(message));
            }
        }
    }
}