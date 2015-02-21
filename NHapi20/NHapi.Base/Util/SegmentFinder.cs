/// <summary> The contents of this file are subject to the Mozilla Public License Version 1.1
/// (the "License"); you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/
/// Software distributed under the License is distributed on an "AS IS" basis,
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
/// specific language governing rights and limitations under the License.
/// 
/// The Original Code is "SegmentFinder.java".  Description:
/// "A tool for getting segments by name within a message or part of a message."
/// 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C)
/// 2002.  All Rights Reserved.
/// 
/// Contributor(s): ______________________________________.
/// 
/// Alternatively, the contents of this file may be used under the terms of the
/// GNU General Public License (the  “GPL”), in which case the provisions of the GPL are
/// applicable instead of those above.  If you wish to allow use of your version of this
/// file only under the terms of the GPL and not to allow others to use your version
/// of this file under the MPL, indicate your decision by deleting  the provisions above
/// and replace  them with the notice and other provisions required by the GPL License.
/// If you do not delete the provisions above, a recipient may use your version of
/// this file under either the MPL or the GPL.
/// 
/// </summary>
using System;
using NHapi.Base.Model;
using NHapi.Base;
using System.Text.RegularExpressions;

namespace NHapi.Base.Util
{

    /// <summary> A tool for getting segments by name within a message or part of a message.</summary>
    /// <author>  Bryan Tripp
    /// </author>
    public class SegmentFinder : MessageNavigator
    {

        /// <summary> Creates a new instance of SegmentFinder.</summary>
        /// <param name="root">the scope of searches -- may be a whole message or only a branch
        /// </param>
        public SegmentFinder(IGroup root)
            : base(root)
        {
        }

        /// <summary> Returns the first segment with a name that matches the given pattern, in a depth-first search.  
        /// Repeated searches are initiated from the location just AFTER where the last segment was found.
        /// Call reset() is this is not desired.  Note: this means that the current location will not be found.
        /// </summary>
        /// <param name="segmentName">the name of the segment to find.  The wildcad * means any number 
        /// of arbitrary characters; the wildard ? one arbitrary character
        /// (eg "P*" or "*ID" or "???" or "P??" would match on PID).
        /// </param>
        /// <param name="rep">the repetition of the segment to return
        /// </param>
        public virtual ISegment findSegment(String namePattern, int rep)
        {
            IStructure s = null;
            do
            {
                s = findStructure(namePattern, rep);
            }
            while (!typeof(ISegment).IsAssignableFrom(s.GetType()));
            return (ISegment)s;
        }

        /// <summary> As findSegment(), but will only return a group.</summary>
        public virtual IGroup findGroup(String namePattern, int rep)
        {
            IStructure s = null;
            do
            {
                s = findStructure(namePattern, rep);
            }
            while (!typeof(IGroup).IsAssignableFrom(s.GetType()));
            return (IGroup)s;
        }

        /// <summary> Returns the first matching structure AFTER the current position</summary>
        private IStructure findStructure(String namePattern, int rep)
        {
            IStructure s = null;

            while (s == null)
            {
                iterate(false, false);
                String currentName = getCurrentStructure(0).GetStructureName();
                if (matches(namePattern, currentName))
                {
                    s = getCurrentStructure(rep);
                }
            }
            return s;
        }

        /// <summary> Returns the first segment with a name matching the given pattern that is a sibling of
        /// the structure at the current location.  Other parts of the message are
        /// not searched (in contrast to findSegment).
        /// As a special case, if the pointer is at the root, the children of the root
        /// are searched.
        /// </summary>
        /// <param name="segmentName">the name of the segment to get.  The wildcad * means any number 
        /// of arbitrary characters; the wildard ? one arbitrary character
        /// (eg "P*" or "*ID" or "???" or "P??" would match on PID).
        /// </param>
        /// <param name="rep">the repetition of the segment to return
        /// </param>
        public virtual ISegment getSegment(String namePattern, int rep)
        {
            IStructure s = GetStructure(namePattern, rep);
            if (!typeof(ISegment).IsAssignableFrom(s.GetType()))
            {
                throw new HL7Exception(s.GetStructureName() + " is not a segment", HL7Exception.APPLICATION_INTERNAL_ERROR);
            }
            return (ISegment)s;
        }

        /// <summary> As getSegment() but will only return a group.</summary>
        public virtual IGroup getGroup(String namePattern, int rep)
        {
            IStructure s = GetStructure(namePattern, rep);
            if (!typeof(IGroup).IsAssignableFrom(s.GetType()))
            {
                throw new HL7Exception(s.GetStructureName() + " is not a group", HL7Exception.APPLICATION_INTERNAL_ERROR);
            }
            return (IGroup)s;
        }

        private IStructure GetStructure(String namePattern, int rep)
        {
            IStructure s = null;

            if (getCurrentStructure(0).Equals(Root))
                drillDown(0);

            String[] names = getCurrentStructure(0).ParentStructure.Names;
            for (int i = 0; i < names.Length && s == null; i++)
            {
                if (matches(namePattern, names[i]))
                {
                    toChild(i);
                    s = getCurrentStructure(rep);
                }
            }

            if (s == null)
                throw new HL7Exception("Can't find " + namePattern + " as a direct child", HL7Exception.APPLICATION_INTERNAL_ERROR);

            return s;
        }

        /// <summary> Tests whether the given name matches the given pattern.</summary>
        /*private boolean matches(String pattern, String candidate) {
        boolean matches = false;
        boolean substring = false;
        if (pattern.substring(0, 1).equals("*")) {
        substring = true;
        pattern = pattern.substring(1);
        }
		
        if (substring && (candidate.indexOf(pattern) >= 0)) {
        matches = true;
        } else if (!substring && candidate.equals(pattern)) {
        matches = true;
        }
        return matches;
        }*/

        /// <summary> Tests whether the given name matches the given pattern.</summary>
        private bool matches(String pattern, String candidate)
        {
            //shortcut ...
            if (pattern.Equals(candidate))
            {
                return true;
            }

            if (!Regex.IsMatch(pattern, "[\\w\\*\\?]*"))
                throw new ArgumentException("The pattern " + pattern + " is not valid.  Only [\\w\\*\\?]* allowed.");

            pattern = Regex.Replace(pattern, "\\*", ".*");
            pattern = Regex.Replace(pattern, "\\?", ".");

            return Regex.IsMatch(candidate, pattern);
        }
    }
}