/*
  This class is based on the Iterators.FilterIterator class from
  araSpect (araspect.sourceforge.net).  The original copyright follows ...

  =================================================================
  Copyright (c) 2001,2002 aragost ag, Zürich, Switzerland.
  All rights reserved.

  This software is provided 'as-is', without any express or implied
  warranty. In no event will the authors be held liable for any
  damages arising from the use of this software.

  Permission is granted to anyone to use this software for any
  purpose, including commercial applications, and to alter it and
  redistribute it freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you
  must not claim that you wrote the original software. If you
  use this software in a product, an acknowledgment in the
  product documentation would be appreciated but is not required.

  2. Altered source versions must be plainly marked as such, and
  must not be misrepresented as being the original software.

  3. This notice may not be removed or altered from any source
  distribution.

  ==================================================================

  Changes (c) 2003 University Health Network include the following:
  - move to non-nested class
  - collapse inherited method remove()
  - accept iterator instead of object in constructor
  - moved to HAPI package
  - Predicate added as an inner class; also changed to an interface

  These changes are distributed under the same terms as the original (above).
*/

namespace NHapi.Base.Util
{
    using System;
    using System.Collections;

    /// <summary>
    /// Filter iterator class.
    /// </summary>
    public class FilterIterator : IEnumerator
    {
        private IPredicate predicate;
        private IEnumerator iter;
        private object nextObject;
        private bool nextObjectSet = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="iter"></param>
        /// <param name="predicate"></param>
        public FilterIterator(IEnumerator iter, IPredicate predicate)
        {
            this.iter = iter;
            this.predicate = predicate;
        }

        /// <summary>
        /// IPredicate interface.
        /// </summary>
        public interface IPredicate
        {
            [Obsolete("This method has been replaced by 'Evaluate'.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.NamingRules",
                "SA1300:Element should begin with upper-case letter",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            bool evaluate(object obj);

            /// <summary>
            /// Evaluate the object.
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            bool Evaluate(object obj);
        }

        /// <summary>
        /// The current item.
        /// </summary>
        public virtual object Current
        {
            get
            {
                if (!nextObjectSet)
                {
                    if (!SetNextObject())
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }

                nextObjectSet = false;
                return nextObject;
            }
        }

        /// <summary>
        /// Move next.
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
                return SetNextObject();
            }
        }

        [Obsolete("This method has been replaced by 'Remove'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void remove()
        {
            Remove();
        }

        /// <summary>Throws UnsupportedOperationException. </summary>
        public virtual void Remove()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Reset.
        /// </summary>
        public virtual void Reset()
        {
        }

        /// <summary> Set nextObject to the next object. If there are no more
        /// objects then return false. Otherwise, return true.
        /// </summary>
        private bool SetNextObject()
        {
            while (iter.MoveNext())
            {
                var object_Renamed = iter.Current;
                if (predicate.Evaluate(object_Renamed))
                {
                    nextObject = object_Renamed;
                    nextObjectSet = true;
                    return true;
                }
            }

            return false;
        }
    }
}