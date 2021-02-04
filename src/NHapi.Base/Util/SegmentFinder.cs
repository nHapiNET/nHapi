/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "SegmentFinder.java".  Description:
  "A tool for getting segments by name within a message or part of a message."

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2002.  All Rights Reserved.

  Contributor(s): ______________________________________.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

namespace NHapi.Base.Util
{
    using System;
    using System.Text.RegularExpressions;

    using NHapi.Base.Model;

    /// <summary> A tool for getting segments by name within a message or part of a message.</summary>
    /// <author>  Bryan Tripp.
    /// </author>
    public class SegmentFinder : MessageNavigator
    {
        /// <summary> Creates a new instance of SegmentFinder.</summary>
        /// <param name="root">the scope of searches -- may be a whole message or only a branch.
        /// </param>
        public SegmentFinder(IGroup root)
            : base(root)
        {
        }

        [Obsolete("This method has been replaced by 'FindSegment'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual ISegment findSegment(string namePattern, int rep)
        {
            return FindSegment(namePattern, rep);
        }

        /// <summary>
        /// Returns the first segment with a name that matches the given pattern, in a depth-first search.
        /// Repeated searches are initiated from the location just AFTER where the last segment was found.
        /// Call reset() is this is not desired.  Note: this means that the current location will not be found.
        /// </summary>
        /// <param name="namePattern">
        /// The name of the segment to find. The wildcard * means any number
        /// of arbitrary characters; the wildcard ? one arbitrary character
        /// (eg "P*" or "*ID" or "???" or "P??" would match on PID).
        /// </param>
        /// <param name="rep">the repetition of the segment to return.</param>
        public virtual ISegment FindSegment(string namePattern, int rep)
        {
            IStructure s = null;
            do
            {
                s = FindStructure(namePattern, rep);
            }
            while (!typeof(ISegment).IsAssignableFrom(s.GetType()));

            return (ISegment)s;
        }

        [Obsolete("This method has been replaced by 'FindGroup'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual IGroup findGroup(string namePattern, int rep)
        {
            return FindGroup(namePattern, rep);
        }

        /// <summary> As findSegment(), but will only return a group.</summary>
        public virtual IGroup FindGroup(string namePattern, int rep)
        {
            IStructure s = null;
            do
            {
                s = FindStructure(namePattern, rep);
            }
            while (!typeof(IGroup).IsAssignableFrom(s.GetType()));

            return (IGroup)s;
        }

        [Obsolete("This method has been replaced by 'GetSegment'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual ISegment getSegment(string namePattern, int rep)
        {
            return GetSegment(namePattern, rep);
        }

        /// <summary>
        /// Returns the first segment with a name matching the given pattern that is a sibling of
        /// the structure at the current location. Other parts of the message are
        /// not searched (in contrast to findSegment).
        /// As a special case, if the pointer is at the root, the children of the root
        /// are searched.
        /// </summary>
        /// <param name="namePattern">
        /// The name of the segment to get. The wildcard * means any number
        /// of arbitrary characters; the wildcard ? one arbitrary character
        /// (eg "P*" or "*ID" or "???" or "P??" would match on PID).
        /// </param>
        /// <param name="rep">the repetition of the segment to return.</param>
        public virtual ISegment GetSegment(string namePattern, int rep)
        {
            IStructure s = GetStructure(namePattern, rep);
            if (!typeof(ISegment).IsAssignableFrom(s.GetType()))
            {
                throw new HL7Exception(s.GetStructureName() + " is not a segment", ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return (ISegment)s;
        }

        [Obsolete("This method has been replaced by 'GetGroup'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual IGroup getGroup(string namePattern, int rep)
        {
            return GetGroup(namePattern, rep);
        }

        /// <summary> As getSegment() but will only return a group.</summary>
        public virtual IGroup GetGroup(string namePattern, int rep)
        {
            IStructure s = GetStructure(namePattern, rep);
            if (!typeof(IGroup).IsAssignableFrom(s.GetType()))
            {
                throw new HL7Exception(s.GetStructureName() + " is not a group", ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return (IGroup)s;
        }

        /// <summary> Returns the first matching structure AFTER the current position.</summary>
        private IStructure FindStructure(string namePattern, int rep)
        {
            IStructure s = null;

            while (s == null)
            {
                Iterate(false, false);
                string currentName = GetCurrentStructure(0).GetStructureName();
                if (Matches(namePattern, currentName))
                {
                    s = GetCurrentStructure(rep);
                }
            }

            return s;
        }

        private IStructure GetStructure(string namePattern, int rep)
        {
            IStructure s = null;

            if (GetCurrentStructure(0).Equals(Root))
            {
                DrillDown(0);
            }

            string[] names = GetCurrentStructure(0).ParentStructure.Names;
            for (int i = 0; i < names.Length && s == null; i++)
            {
                if (Matches(namePattern, names[i]))
                {
                    ToChild(i);
                    s = GetCurrentStructure(rep);
                }
            }

            if (s == null)
            {
                throw new HL7Exception("Can't find " + namePattern + " as a direct child", ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return s;
        }

        /// <summary> Tests whether the given name matches the given pattern.</summary>
        private bool Matches(string pattern, string candidate)
        {
            // shortcut ...
            if (pattern.Equals(candidate))
            {
                return true;
            }

            if (!Regex.IsMatch(pattern, "[\\w\\*\\?]*"))
            {
                throw new ArgumentException("The pattern " + pattern + " is not valid.  Only [\\w\\*\\?]* allowed.");
            }

            pattern = Regex.Replace(pattern, "\\*", ".*");
            pattern = Regex.Replace(pattern, "\\?", ".");

            return Regex.IsMatch(candidate, pattern);
        }
    }
}