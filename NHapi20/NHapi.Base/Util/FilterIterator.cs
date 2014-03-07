/// <summary> This class is based on the Iterators.FilterIterator class from
/// araSpect (araspect.sourceforge.net).  The original copyright follows ...
/// 
/// =================================================================
/// Copyright (c) 2001,2002 aragost ag, Zürich, Switzerland.
/// All rights reserved.
/// 
/// This software is provided 'as-is', without any express or implied
/// warranty. In no event will the authors be held liable for any
/// damages arising from the use of this software.
/// 
/// Permission is granted to anyone to use this software for any
/// purpose, including commercial applications, and to alter it and
/// redistribute it freely, subject to the following restrictions:
/// 
/// 1. The origin of this software must not be misrepresented; you
/// must not claim that you wrote the original software. If you
/// use this software in a product, an acknowledgment in the
/// product documentation would be appreciated but is not required.
/// 
/// 2. Altered source versions must be plainly marked as such, and
/// must not be misrepresented as being the original software.
/// 
/// 3. This notice may not be removed or altered from any source
/// distribution.
/// 
/// ==================================================================
/// 
/// Changes (c) 2003 University Health Network include the following:
/// - move to non-nested class
/// - collapse inherited method remove()
/// - accept iterator instead of object in constructor
/// - moved to HAPI package
/// - Predicate added as an inner class; also changed to an interface
/// 
/// These changes are distributed under the same terms as the original (above). 
/// </summary>
using System;
namespace NHapi.Base.Util
{
    /// <summary>
    /// Filter iterator class
    /// </summary>
    public class FilterIterator : System.Collections.IEnumerator
    {
        private FilterIterator.IPredicate predicate;
        private System.Collections.IEnumerator iter;
        private System.Object nextObject;
        private bool nextObjectSet = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iter"></param>
        /// <param name="predicate"></param>
        public FilterIterator(System.Collections.IEnumerator iter, FilterIterator.IPredicate predicate)
        {
            this.iter = iter;
            this.predicate = predicate;
        }

        /// <summary>
        /// The current item
        /// </summary>
        public virtual System.Object Current
        {
            get
            {
                if (!nextObjectSet)
                {
                    if (!setNextObject())
                    {
                        throw new System.ArgumentOutOfRangeException();
                    }
                }
                nextObjectSet = false;
                return nextObject;
            }

        }



        /// <summary>
        /// Move next
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveNext()
        {
            if (nextObjectSet)
            {
                return true;
            }
            else
            {
                return setNextObject();
            }
        }

        /// <summary> Set nextObject to the next object. If there are no more
        /// objects then return false. Otherwise, return true.
        /// </summary>
        private bool setNextObject()
        {
            while (iter.MoveNext())
            {
                System.Object object_Renamed = iter.Current;
                if (predicate.evaluate(object_Renamed))
                {
                    nextObject = object_Renamed;
                    nextObjectSet = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>Throws UnsupportedOperationException </summary>
        public virtual void remove()
        {
            throw new System.NotSupportedException();
        }

        /// <summary>
        /// IPredicate interface
        /// </summary>
        public interface IPredicate
        {
            /// <summary>
            /// Evaluate the object
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            bool evaluate(System.Object obj);
        }
        /// <summary>
        /// Reset
        /// </summary>
        virtual public void Reset()
        {
        }
    }
}