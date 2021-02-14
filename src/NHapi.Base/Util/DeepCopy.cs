namespace NHapi.Base.Util
{
    using System;

    using NHapi.Base.Model;

    /// <summary> Tools for copying data recursively from one message element into another.  Currently only Types are
    /// supported.
    /// </summary>
    /// <author>  Bryan Tripp.
    /// </author>
    public class DeepCopy
    {
        [Obsolete("This method has been replaced by 'Copy'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static void copy(IType from, IType to)
        {
            Copy(from, to);
        }

        /// <summary> Copies data from the "from" Type into the "to" Type.  Either Type may be
        /// a Primitive, Composite, or Varies.  If a Varies is provided, the operation is
        /// performed on the result of calling its getData() method.  A Primitive may be
        /// copied into a Composite, in which case the value is copied into the first
        /// component of the Composite.  A Composite may be copied into a Primitive,
        /// in which case the first component is copied.  Given Composites with different
        /// numbers of components, the first components are copied, up to the length
        /// of the smaller one.
        /// </summary>
        public static void Copy(IType from, IType to)
        {
            for (var i = 1; i <= Terser.NumComponents(from); i++)
            {
                for (var j = 1; j <= Terser.NumSubComponents(from, i); j++)
                {
                    var val = Terser.GetPrimitive(from, i, j).Value;
                    Terser.GetPrimitive(to, i, j).Value = val;
                }
            }
        }

        [Obsolete("This method has been replaced by 'Copy'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static void copy(ISegment from, ISegment to)
        {
            Copy(from, to);
        }

        /// <summary> Copies contents from the source segment to the destination segment.  This
        /// method calls copy(Type, Type) on each repetition of each field (see additional
        /// behavioural description there).  An attempt is made to copy each repetition of
        /// each field in the source segment, regardless of whether the corresponding
        /// destination field is repeating or even exists.
        /// </summary>
        /// <param name="from">the segment from which data are copied.
        /// </param>
        /// <param name="to">the segment into which data are copied.
        /// </param>
        public static void Copy(ISegment from, ISegment to)
        {
            var n = from.NumFields();
            for (var i = 1; i <= n; i++)
            {
                var reps = from.GetField(i);
                for (var j = 0; j < reps.Length; j++)
                {
                    Copy(reps[j], to.GetField(i, j));
                }
            }
        }
    }
}