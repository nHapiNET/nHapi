/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "IStructureDefinition.java"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

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

namespace NHapi.Base.Parser
{
    using System.Collections.Generic;

    using NHapi.Base.Model;

    /// <summary>
    /// Contains information about the composition of a given type of <see cref="IStructure"/>.
    /// At runtime, parsers will use accessors provided by various structure types(messages, groups,
    /// segments) to determine the structure of a messages.Structure definitions are used
    /// to cache that information between parse calls.
    /// </summary>
    public interface IStructureDefinition
    {
        /// <summary>
        /// Returns this structure's first sibling (in other words, its parent's first child).
        /// Returns <c>null</c> if this is the first sibling, or if this has no parent.
        /// </summary>
        /// <returns></returns>
        IStructureDefinition FirstSibling { get; }

        /// <summary>
        /// Returns the next leaf (segment) after this one, within the same
        /// group, only if one exists and this structure is also a leaf. Otherwise returns <c>null</c>.
        /// </summary>
        /// <returns></returns>
        IStructureDefinition NextLeaf { get; }

        /// <summary>
        /// The name of the segment, as it is known to it's parent. This
        /// will differ from <see cref="Name"/> in the case of multiple segments
        /// with the same name in a group, e.g.the two PID segments in ADT_A17,
        /// where the second one it known as PID2 to it's parent.
        /// </summary>
        /// <returns></returns>
        string NameAsItAppearsInParent { get; }

        /// <summary>
        /// Returns the name of this structure.
        /// </summary>
        /// <returns></returns>
        string Name { get; }

        /// <summary>
        /// Returns true if this structure is a segment.
        /// </summary>
        /// <returns></returns>
        bool IsSegment { get; }

        /// <summary>
        /// Returns true if this is a repeatable structure.
        /// </summary>
        /// <returns></returns>
        bool IsRepeating { get; }

        /// <summary>
        /// Does this structure have children (i.e. is it not a segment).
        /// </summary>
        /// <returns></returns>
        bool HasChildren { get; }

        /// <summary>
        /// Returns true if this structure is the final child of it's parent.
        /// </summary>
        /// <returns></returns>
        bool IsFinalChildOfParent { get; }

        /// <summary>
        /// Returns true if this element a choice element <see ref="IGroup.IsChoiceElement"/>.
        /// </summary>
        /// <returns></returns>
        bool IsChoiceElement { get; }

        /// <summary>
        /// Returns true if this a required structure within it's parent.
        /// </summary>
        /// <returns></returns>
        bool IsRequired { get; }

        /// <summary>
        /// Returns all children of this structure definition.
        /// </summary>
        /// <returns></returns>
        List<IStructureDefinition> Children { get; }

        /// <summary>
        /// Returns the index of the position of this structure
        /// within it's parent's children.
        /// </summary>
        /// <returns></returns>
        int Position { get; }

        /// <summary>
        /// Returns the parent structure of this structure, if one exists.
        /// Otherwise, returns null.
        /// </summary>
        /// <returns></returns>
        IStructureDefinition Parent { get; }

        /// <summary>
        /// Returns this structure's next sibling within it's parent, if any.
        /// </summary>
        /// <returns></returns>
        IStructureDefinition NextSibling { get; }

        /// <summary>
        /// structure definition of first child or <c>null</c> if there is no child.
        /// </summary>
        /// <returns></returns>
        IStructureDefinition FirstChild { get; }

        /// <summary>
        /// Should only be called on a leaf node (segment).
        /// <para>Returns the names of all valid children which may follow
        /// this one at any level in the hierarchy (including as later
        /// siblings of parent structures to this one).
        /// </para>
        /// </summary>
        /// <returns>the names of all valid children which may follow this one.</returns>
        HashSet<string> GetNamesOfAllPossibleFollowingLeaves();

        /// <summary>
        /// Returns the names of any possible children that could be the first
        /// required child of this group.
        /// <para>
        /// For instance, for the group below "ORC" and "OBR" would both be
        /// returned, as they are both potential first children of this group.
        /// </para>
        /// <para>
        /// Note that the name returned by <see cref="Name"/>
        /// is also returned.
        /// </para>
        /// </summary>
        /// <returns>the names of any possible children that could be the first required child of this group.</returns>
        /// <example>For example:
        /// <code>
        /// ORDER_OBSERVATION
        /// {
        /// [ ORC ]
        /// OBR
        /// [ { NTE } ]
        /// [ CTD ]
        /// OBSERVATION
        ///     {
        ///     [ OBX ]
        ///     [ { NTE } ]
        ///     }
        /// OBSERVATION
        /// [ { FT1 } ]
        /// [ { CTI } ]
        /// }
        /// ORDER_OBSERVATION
        /// </code>
        /// </example>
        HashSet<string> GetAllPossibleFirstChildren();

        /// <summary>
        /// Returns the names of all children of this structure, including first elements within child groups.
        /// </summary>
        /// <returns></returns>
        HashSet<string> GetAllChildNames();
    }
}