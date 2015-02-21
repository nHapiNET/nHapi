using System;
using NHapi.Base.Model;
using NHapi.Base;

namespace NHapi.Base.Util
{

    /// <summary> Tools for copying data recurvisely from one message element into another.  Currently only Types are 
    /// supported.  
    /// </summary>
    /// <author>  Bryan Tripp
    /// </author>
    public class DeepCopy
    {

        /// <summary> Copies data from the "from" Type into the "to" Type.  Either Type may be 
        /// a Primitive, Composite, or Varies.  If a Varies is provided, the operation is 
        /// performed on the result of calling its getData() method.  A Primitive may be 
        /// copied into a Composite, in which case the value is copied into the first 
        /// component of the Composite.  A Composite may be copied into a Primitive, 
        /// in which case the first component is copied.  Given Composites with different 
        /// numbers of components, the first components are copied, up to the length 
        /// of the smaller one.  
        /// </summary>
        public static void copy(IType from, IType to)
        {
            for (int i = 1; i <= Terser.numComponents(from); i++)
            {
                for (int j = 1; j <= Terser.numSubComponents(from, i); j++)
                {
                    String val = Terser.getPrimitive(from, i, j).Value;
                    Terser.getPrimitive(to, i, j).Value = val;
                }
            }
        }



        /// <summary> Copies contents from the source segment to the destination segment.  This 
        /// method calls copy(Type, Type) on each repetition of each field (see additional 
        /// behavioural description there).  An attempt is made to copy each repetition of 
        /// each field in the source segment, regardless of whether the corresponding 
        /// destination field is repeating or even exists.  
        /// </summary>
        /// <param name="from">the segment from which data are copied 
        /// </param>
        /// <param name="to">the segment into which data are copied
        /// </param>
        public static void copy(ISegment from, ISegment to)
        {
            int n = from.NumFields();
            for (int i = 1; i <= n; i++)
            {
                IType[] reps = from.GetField(i);
                for (int j = 0; j < reps.Length; j++)
                {
                    copy(reps[j], to.GetField(i, j));
                }
            }
        }
    }
}