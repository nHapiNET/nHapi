using System;
using System.Collections;
using System.Text;
using NHapi.Base.Model;
using NHapi.Base.Log;

namespace NHapi.Base.Util
{
    /// <summary> Iterates over all defined nodes (ie segments, groups) in a message,
    /// regardless of whether they have been instantiated previously.  This is a
    /// tricky process, because the number of nodes is infinite, due to infinitely
    /// repeating segments and groups.  See <code>next()</code> for details on
    /// how this is handled.
    ///
    /// This implementation assumes that the first segment in each group is present (as per
    /// HL7 rules).  Specifically, when looking for a segment location, an empty group that has
    /// a spot for the segment will be overlooked if there is anything else before that spot.
    /// This may result in surprising (but sensible) behaviour if a message is missing the
    /// first segment in a group.
    ///
    /// </summary>
    /// <author>  Bryan Tripp
    /// </author>
    public class MessageIterator : IEnumerator
    {
        /// <summary> <p>Returns the next node in the message.  Sometimes the next node is
        /// ambiguous.  For example at the end of a repeating group, the next node
        /// may be the first segment in the next repetition of the group, or the
        /// next sibling, or an undeclared segment locally added to the group's end.
        /// Cases like this are disambiguated using getDirection(), which returns
        /// the name of the structure that we are "iterating towards".
        /// Usually we are "iterating towards" a segment of a certain name because we
        /// have a segment string that we would like to parse into that node.
        /// Here are the rules: </p>
        /// <ol><li>If at a group, next means first child.</li>
        /// <li>If at a non-repeating segment, next means next "position"</li>
        /// <li>If at a repeating segment: if segment name matches
        /// direction then next means next rep, otherwise next means next "position".</li>
        /// <li>If at a segment within a group (not at the end of the group), next "position"
        /// means next sibling</li>
        /// <li>If at the end of a group: If name of group or any of its "first
        /// decendents" matches direction, then next position means next rep of group.  Otherwise
        /// if direction matches name of next sibling of the group, or any of its first
        /// descendents, next position means next sibling of the group.  Otherwise, next means a
        /// new segment added to the group (with a name that matches "direction").  </li>
        /// <li>"First descendents" means first child, or first child of the first child,
        /// or first child of the first child of the first child, etc. </li> </ol>
        /// </summary>
        public virtual Object Current
        {
            get
            {
                if (!MoveNext())
                {
                    throw new ArgumentOutOfRangeException("No more nodes in message");
                }

                try
                {
                    currentStructure = next_Renamed_Field.parent.GetStructure(next_Renamed_Field.index.name,
                        next_Renamed_Field.index.rep);
                }
                catch (HL7Exception e)
                {
                    throw new ArgumentOutOfRangeException("HL7Exception: " + e.Message);
                }

                clearNext();
                return currentStructure;
            }
        }

        /// <summary>
        /// The direction
        /// </summary>
        public virtual String Direction
        {
            get { return direction; }

            set
            {
                clearNext();
                direction = value;
            }
        }

        private IStructure currentStructure;
        private String direction;
        private Position next_Renamed_Field;
        private bool handleUnexpectedSegments;

        private static readonly IHapiLog log;

        /* may add configurability later ...
        private boolean findUpToFirstRequired;
        private boolean findFirstDescendentsOnly;

        public static final String WHOLE_GROUP;
        public static final String FIRST_DESCENDENTS_ONLY;
        public static final String UP_TO_FIRST_REQUIRED;
        */

        /// <summary>Creates a new instance of MessageIterator </summary>
        public MessageIterator(IStructure start, String direction, bool handleUnexpectedSegments)
        {
            currentStructure = start;
            this.direction = direction;
            this.handleUnexpectedSegments = handleUnexpectedSegments;
        }

        /* for configurability (maybe to add later, replacing hard-coded options
        in nextFromEndOfGroup) ...
        public void setSearchLevel(String level) {
        if (WHOLE_GROUP.equals(level)) {
        this.findUpToFirstRequired = false;
        this.findFirstDescendentsOnly = false;
        } else if (FIRST_DESCENDENTS_ONLY.equals(level)) {
        this.findUpToFirstRequired = false;
        this.findFirstDescendentsOnly = true;
        } else if (UP_TO_FIRST_REQUIRED.equals(level)) {
        this.findUpToFirstRequired = true;
        this.findFirstDescendentsOnly = false;
        } else {
        throw IllegalArgumentException(level + " is not a valid search level.  Should be WHOLE_GROUP, etc.");
        }
        }

        public String getSearchLevel() {
        String level = WHOLE_GROUP;
        if (this.findFirstDescendentsOnly) {
        level = FIRST_DESCENDENTS_ONLY;
        } else if (this.findUpTpFirstRequired) {
        level = UP_TO_FIRST_REQUIRED;
        }
        return level;
        }*/


        /// <summary> Returns true if another object exists in the iteration sequence.  </summary>
        public virtual bool MoveNext()
        {
            bool has = true;
            if (next_Renamed_Field == null)
            {
                if (typeof(IGroup).IsAssignableFrom(currentStructure.GetType()))
                {
                    groupNext((IGroup)currentStructure);
                }
                else
                {
                    IGroup parent = currentStructure.ParentStructure;
                    Index i = getIndex(parent, currentStructure);
                    Position currentPosition = new Position(parent, i);

                    try
                    {
                        if (parent.IsRepeating(i.name) && currentStructure.GetStructureName().Equals(direction))
                        {
                            nextRep(currentPosition);
                        }
                        else
                        {
                            has = nextPosition(currentPosition, direction, handleUnexpectedSegments);
                        }
                    }
                    catch (HL7Exception e)
                    {
                        throw new ApplicationException("HL7Exception arising from bad index: " + e.Message);
                    }
                }
            }

            log.Debug("MessageIterator.hasNext() in direction " + direction + "? " + has);
            return has;
        }

        /// <summary> Sets next to the first child of the given group (iteration
        /// always proceeds from group to first child).
        /// </summary>
        private void groupNext(IGroup current)
        {
            next_Renamed_Field = new Position(current, ((IGroup)current).Names[0], 0);
        }

        /// <summary> Sets next to the next repetition of the current structure.  </summary>
        private void nextRep(Position current)
        {
            next_Renamed_Field = new Position(current.parent, current.index.name, current.index.rep + 1);
        }

        /// <summary> Sets this.next to the next position in the message (from the given position),
        /// which could be the next sibling, a new segment, or the next rep
        /// of the parent.  See next() for details.
        /// </summary>
        private bool nextPosition(Position currPos, String direction, bool makeNewSegmentIfNeeded)
        {
            bool nextExists = true;
            if (isLast(currPos))
            {
                nextExists = nextFromGroupEnd(currPos, direction, makeNewSegmentIfNeeded);
            }
            else
            {
                nextSibling(currPos);
            }

            return nextExists;
        }

        /// <summary>Navigates from end of group </summary>
        private bool nextFromGroupEnd(Position currPos, String direction, bool makeNewSegmentIfNeeded)
        {
            // assert isLast(currPos);
            bool nextExists = true;

            // the following conditional logic is a little convoluted -- its meant as an optimization
            // i.e. trying to avoid calling matchExistsAfterCurrentPosition

            if (!makeNewSegmentIfNeeded && typeof(IMessage).IsAssignableFrom(currPos.parent.GetType()))
            {
                nextExists = false;
            }
            else if (!makeNewSegmentIfNeeded || matchExistsAfterPosition(currPos, direction, false, true))
            {
                IGroup grandparent = currPos.parent.ParentStructure;
                Index parentIndex = getIndex(grandparent, currPos.parent);
                Position parentPos = new Position(grandparent, parentIndex);

                try
                {
                    bool parentRepeats = parentPos.parent.IsRepeating(parentPos.index.name);
                    if (parentRepeats && contains(parentPos.parent.GetStructure(parentPos.index.name, 0), direction, false, true))
                    {
                        nextRep(parentPos);
                    }
                    else
                    {
                        nextExists = nextPosition(parentPos, direction, makeNewSegmentIfNeeded);
                    }
                }
                catch (HL7Exception e)
                {
                    throw new ApplicationException("HL7Exception arising from bad index: " + e.Message);
                }
            }
            else
            {
                newSegment(currPos.parent, direction);
            }

            return nextExists;
        }

        /// <summary> A match exists for the given name somewhere after the given position (in the
        /// normal serialization order).
        /// </summary>
        /// <param name="pos">the message position after which to look (note that this specifies
        /// the message instance)
        /// </param>
        /// <param name="name">the name of the structure to look for
        /// </param>
        /// <param name="firstDescendentsOnly">only searches the first children of a group
        /// </param>
        /// <param name="upToFirstRequired">only searches the children of a group up to the first
        /// required child (normally the first one).  This is used when we are parsing
        /// a message in order and looking for a place to parse a particular segment --
        /// if the message is correct then it can't go after a required position of a
        /// different name.
        /// </param>
        public static bool matchExistsAfterPosition(Position pos, String name, bool firstDescendentsOnly,
            bool upToFirstRequired)
        {
            bool matchExists = false;

            // check next rep of self (if any)
            if (pos.parent.IsRepeating(pos.index.name))
            {
                IStructure s = pos.parent.GetStructure(pos.index.name, pos.index.rep);
                matchExists = contains(s, name, firstDescendentsOnly, upToFirstRequired);
            }

            // check later siblings (if any)
            if (!matchExists)
            {
                String[] siblings = pos.parent.Names;
                bool after = false;
                for (int i = 0; i < siblings.Length && !matchExists; i++)
                {
                    if (after)
                    {
                        matchExists = contains(pos.parent.GetStructure(siblings[i]), name, firstDescendentsOnly, upToFirstRequired);
                        if (upToFirstRequired && pos.parent.IsRequired(siblings[i]))
                            break;
                    }

                    if (pos.index.name.Equals(siblings[i]))
                        after = true;
                }
            }

            // recurse to parent (if parent is not message root)
            if (!matchExists && !typeof(IMessage).IsAssignableFrom(pos.parent.GetType()))
            {
                IGroup grandparent = pos.parent.ParentStructure;
                Position parentPos = new Position(grandparent, getIndex(grandparent, pos.parent));
                matchExists = matchExistsAfterPosition(parentPos, name, firstDescendentsOnly, upToFirstRequired);
            }

            log.Debug("Match exists after position " + pos + " for " + name + "? " + matchExists);
            return matchExists;
        }

        /// <summary> Sets the next position to a new segment of the given name, within the
        /// given group.
        /// </summary>
        private void newSegment(IGroup parent, String name)
        {
            log.Info("MessageIterator creating new segment: " + name);
            parent.addNonstandardSegment(name);
            next_Renamed_Field = new Position(parent, parent.Names[parent.Names.Length - 1], 0);
        }

        /// <summary> Determines whether the given structure matches the given name, or contains
        /// a child that does.
        /// </summary>
        /// <param name="s">the structure to check
        /// </param>
        /// <param name="name">the name to look for
        /// </param>
        /// <param name="firstDescendentsOnly">only checks first descendents (i.e. first
        /// child, first child of first child, etc.)  In theory the first child
        /// of a group should always be present, and we don't use this method with
        /// subsequent children because finding the next position within a group is
        /// straightforward.
        /// </param>
        /// <param name="upToFirstRequired">only checks first descendents and of their siblings
        /// up to the first required one.  This may be needed because in practice
        /// some first children of groups are not required.
        /// </param>
        public static bool contains(IStructure s, String name, bool firstDescendentsOnly, bool upToFirstRequired)
        {
            bool contains = false;
            if (typeof(ISegment).IsAssignableFrom(s.GetType()))
            {
                if (s.GetStructureName().Equals(name))
                    contains = true;
            }
            else
            {
                IGroup g = (IGroup)s;
                String[] names = g.Names;
                for (int i = 0; i < names.Length && !contains; i++)
                {
                    try
                    {
                        contains = MessageIterator.contains(g.GetStructure(names[i], 0), name, firstDescendentsOnly, upToFirstRequired);
                        if (firstDescendentsOnly)
                            break;
                        if (upToFirstRequired && g.IsRequired(names[i]))
                            break;
                    }
                    catch (HL7Exception e)
                    {
                        throw new ApplicationException("HL7Exception due to bad index: " + e.Message);
                    }
                }
            }

            return contains;
        }

        /// <summary> Tests whether the name of the given Index matches
        /// the name of the last child of the given group.
        /// </summary>
        public static bool isLast(Position p)
        {
            String[] names = p.parent.Names;
            return names[names.Length - 1].Equals(p.index.name);
        }

        /// <summary> Sets the next location to the next sibling of the given
        /// index.
        /// </summary>
        private void nextSibling(Position pos)
        {
            String[] names = pos.parent.Names;
            int i = 0;
            for (; i < names.Length && !names[i].Equals(pos.index.name); i++)
            {
            }

            String nextName = names[i + 1];

            next_Renamed_Field = new Position(pos.parent, nextName, 0);
        }

        /// <summary>Not supported </summary>
        public virtual void remove()
        {
            throw new NotSupportedException("Can't remove a node from a message");
        }

        private void clearNext()
        {
            next_Renamed_Field = null;
        }

        /// <summary> Returns the index of the given structure as a child of the
        /// given parent.  Returns null if the child isn't found.
        /// </summary>
        public static Index getIndex(IGroup parent, IStructure child)
        {
            Index index = null;
            String[] names = parent.Names;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].StartsWith(child.GetStructureName()))
                {
                    try
                    {
                        IStructure[] reps = parent.GetAll(names[i]);
                        for (int j = 0; j < reps.Length; j++)
                        {
                            if (child == reps[j])
                            {
                                index = new Index(names[i], j);
                                break;
                            }
                        }
                    }
                    catch (HL7Exception e)
                    {
                        log.Error("", e);
                        throw new ApplicationException("Internal HL7Exception finding structure index: " + e.Message);
                    }
                }
            }

            return index;
        }

        /// <summary> An index of a child structure within a group, consisting of the name and rep of
        /// of the child.
        /// </summary>
        public class Index
        {
            /// <summary>
            /// The name
            /// </summary>
            public String name;

            /// <summary>
            /// The repetition
            /// </summary>
            public int rep;

            /// <summary>
            /// The index
            /// </summary>
            /// <param name="name">name</param>
            /// <param name="rep">repetition</param>
            public Index(String name, int rep)
            {
                this.name = name;
                this.rep = rep;
            }

            /// <summary>
            /// Override equals
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public override bool Equals(Object o)
            {
                bool equals = false;
                if (o != null && o is Index)
                {
                    Index i = (Index)o;
                    if (i.rep == rep && i.name.Equals(name))
                        equals = true;
                }

                return equals;
            }

            /// <summary>
            /// Override has code
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return name.GetHashCode() + 700 * rep;
            }

            /// <summary>
            /// Override to string
            /// </summary>
            /// <returns></returns>
            public override String ToString()
            {
                return name + ":" + rep;
            }
        }

        /// <summary> A structure position within a message. </summary>
        public class Position
        {
            /// <summary>
            /// The parent
            /// </summary>
            public IGroup parent;

            /// <summary>
            /// The index
            /// </summary>
            public Index index;

            /// <summary>
            /// The position of the element
            /// </summary>
            /// <param name="parent">Parent</param>
            /// <param name="name">Name</param>
            /// <param name="rep">Repetition</param>
            public Position(IGroup parent, String name, int rep)
            {
                this.parent = parent;
                index = new Index(name, rep);
            }

            /// <summary>
            /// The position of the element
            /// </summary>
            /// <param name="parent">Parent</param>
            /// <param name="i">index</param>
            public Position(IGroup parent, Index i)
            {
                this.parent = parent;
                index = i;
            }

            /// <summary>
            /// Override equals operator
            /// </summary>
            /// <param name="o">Object o</param>
            /// <returns>true if objects are equal</returns>
            public override bool Equals(Object o)
            {
                bool equals = false;
                if (o != null && o is Position)
                {
                    Position p = (Position)o;
                    if (p.parent.Equals(parent) && p.index.Equals(index))
                        equals = true;
                }

                return equals;
            }

            /// <summary>
            /// Override hash code
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return parent.GetHashCode() + index.GetHashCode();
            }

            /// <summary>
            /// Override to string
            /// </summary>
            /// <returns></returns>
            public override String ToString()
            {
                StringBuilder ret = new StringBuilder(parent.GetStructureName());
                ret.Append(":");
                ret.Append(index.name);
                ret.Append("(");
                ret.Append(index.rep);
                ret.Append(")");
                return ret.ToString();
            }
        }

        /// <summary>
        /// Reset the iterator
        /// </summary>
        public virtual void Reset()
        {
        }

        static MessageIterator()
        {
            log = HapiLogFactory.GetHapiLog(typeof(MessageIterator));
        }
    }
}