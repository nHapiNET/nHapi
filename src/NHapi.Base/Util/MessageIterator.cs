namespace NHapi.Base.Util
{
    using System;
    using System.Collections;
    using System.Text;

    using NHapi.Base.Log;
    using NHapi.Base.Model;

    /// <summary>
    /// Iterates over all defined nodes (ie segments, groups) in a message,
    /// regardless of whether they have been instantiated previously.  This is a
    /// tricky process, because the number of nodes is infinite, due to infinitely
    /// repeating segments and groups.  See. <code>next()</code> for details on
    /// how this is handled.
    /// <para>
    /// This implementation assumes that the first segment in each group is present (as per
    /// HL7 rules).  Specifically, when looking for a segment location, an empty group that has
    /// a spot for the segment will be overlooked if there is anything else before that spot.
    /// This may result in surprising (but sensible) behaviour if a message is missing the
    /// first segment in a group.
    /// </para>
    /// </summary>
    /// <author>Bryan Tripp.</author>
    public class MessageIterator : IEnumerator
    {
        private static readonly IHapiLog Log;

        private readonly bool handleUnexpectedSegments;
        private IStructure currentStructure;
        private string direction;
        private Position nextRenamedField;

        static MessageIterator()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(MessageIterator));
        }

        /// <summary>Creates a new instance of MessageIterator. </summary>
        public MessageIterator(IStructure start, string direction, bool handleUnexpectedSegments)
        {
            currentStructure = start;
            this.direction = direction;
            this.handleUnexpectedSegments = handleUnexpectedSegments;
        }

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
        /// descendants" matches direction, then next position means next rep of group.  Otherwise
        /// if direction matches name of next sibling of the group, or any of its first
        /// descendents, next position means next sibling of the group.  Otherwise, next means a
        /// new segment added to the group (with a name that matches "direction").  </li>
        /// <li>"First descendents" means first child, or first child of the first child,
        /// or first child of the first child of the first child, etc. </li> </ol>
        /// </summary>
        public virtual object Current
        {
            get
            {
                if (!MoveNext())
                {
                    throw new ArgumentOutOfRangeException("No more nodes in message");
                }

                try
                {
                    currentStructure = nextRenamedField.Parent.GetStructure(
                        nextRenamedField.Index.Name,
                        nextRenamedField.Index.Rep);
                }
                catch (HL7Exception e)
                {
                    throw new ArgumentOutOfRangeException("HL7Exception: " + e.Message);
                }

                ClearNext();
                return currentStructure;
            }
        }

        /// <summary>
        /// The direction.
        /// </summary>
        public virtual string Direction
        {
            get
            {
                return direction;
            }

            set
            {
                ClearNext();
                direction = value;
            }
        }

        [Obsolete("This method has been replaced by 'MatchExistsAfterPosition'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static bool matchExistsAfterPosition(
            Position pos,
            string name,
            bool firstDescendentsOnly,
            bool upToFirstRequired)
        {
            return MatchExistsAfterPosition(pos, name, firstDescendentsOnly, upToFirstRequired);
        }

        /// <summary> A match exists for the given name somewhere after the given position (in the
        /// normal serialization order).
        /// </summary>
        /// <param name="pos">the message position after which to look (note that this specifies
        /// the message instance).
        /// </param>
        /// <param name="name">the name of the structure to look for.
        /// </param>
        /// <param name="firstDescendentsOnly">only searches the first children of a group.
        /// </param>
        /// <param name="upToFirstRequired">only searches the children of a group up to the first
        /// required child (normally the first one).  This is used when we are parsing
        /// a message in order and looking for a place to parse a particular segment --
        /// if the message is correct then it can't go after a required position of a
        /// different name.
        /// </param>
        public static bool MatchExistsAfterPosition(
            Position pos,
            string name,
            bool firstDescendentsOnly,
            bool upToFirstRequired)
        {
            var matchExists = false;

            // check next rep of self (if any)
            if (pos.Parent.IsRepeating(pos.Index.Name))
            {
                var s = pos.Parent.GetStructure(pos.Index.Name, pos.Index.Rep);
                matchExists = Contains(s, name, firstDescendentsOnly, upToFirstRequired);
            }

            // check later siblings (if any)
            if (!matchExists)
            {
                var siblings = pos.Parent.Names;
                var after = false;
                for (var i = 0; i < siblings.Length && !matchExists; i++)
                {
                    if (after)
                    {
                        matchExists = Contains(pos.Parent.GetStructure(siblings[i]), name, firstDescendentsOnly, upToFirstRequired);
                        if (upToFirstRequired && pos.Parent.IsRequired(siblings[i]))
                        {
                            break;
                        }
                    }

                    if (pos.Index.Name.Equals(siblings[i]))
                    {
                        after = true;
                    }
                }
            }

            // recurse to parent (if parent is not message root)
            if (!matchExists && !typeof(IMessage).IsAssignableFrom(pos.Parent.GetType()))
            {
                var grandparent = pos.Parent.ParentStructure;
                var parentPos = new Position(grandparent, GetIndex(grandparent, pos.Parent));
                matchExists = MatchExistsAfterPosition(parentPos, name, firstDescendentsOnly, upToFirstRequired);
            }

            Log.Debug("Match exists after position " + pos + " for " + name + "? " + matchExists);
            return matchExists;
        }

        [Obsolete("This method has been replaced by 'GetIndex'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static Index getIndex(IGroup parent, IStructure child)
        {
            return GetIndex(parent, child);
        }

        /// <summary> Returns the index of the given structure as a child of the
        /// given parent.  Returns null if the child isn't found.
        /// </summary>
        public static Index GetIndex(IGroup parent, IStructure child)
        {
            Index index = null;
            var names = parent.Names;
            for (var i = 0; i < names.Length; i++)
            {
                if (names[i].StartsWith(child.GetStructureName(), StringComparison.Ordinal))
                {
                    try
                    {
                        var reps = parent.GetAll(names[i]);
                        for (var j = 0; j < reps.Length; j++)
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
                        Log.Error(string.Empty, e);
                        throw new ApplicationException("Internal HL7Exception finding structure index: " + e.Message);
                    }
                }
            }

            return index;
        }

        [Obsolete("This method has been replaced by 'Contains'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static bool contains(IStructure s, string name, bool firstDescendentsOnly, bool upToFirstRequired)
        {
            return Contains(s, name, firstDescendentsOnly, upToFirstRequired);
        }

        /// <summary> Determines whether the given structure matches the given name, or contains
        /// a child that does.
        /// </summary>
        /// <param name="s">the structure to check.
        /// </param>
        /// <param name="name">the name to look for.
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
        public static bool Contains(IStructure s, string name, bool firstDescendentsOnly, bool upToFirstRequired)
        {
            var contains = false;
            if (typeof(ISegment).IsAssignableFrom(s.GetType()))
            {
                if (s.GetStructureName().Equals(name))
                {
                    contains = true;
                }
            }
            else
            {
                var g = (IGroup)s;
                var names = g.Names;
                for (var i = 0; i < names.Length && !contains; i++)
                {
                    try
                    {
                        contains = Contains(g.GetStructure(names[i], 0), name, firstDescendentsOnly, upToFirstRequired);
                        if (firstDescendentsOnly)
                        {
                            break;
                        }

                        if (upToFirstRequired && g.IsRequired(names[i]))
                        {
                            break;
                        }
                    }
                    catch (HL7Exception e)
                    {
                        throw new ApplicationException("HL7Exception due to bad index: " + e.Message);
                    }
                }
            }

            return contains;
        }

        [Obsolete("This method has been replaced by 'IsLast'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static bool isLast(Position p)
        {
            return IsLast(p);
        }

        /// <summary> Tests whether the name of the given Index matches
        /// the name of the last child of the given group.
        /// </summary>
        public static bool IsLast(Position p)
        {
            var names = p.Parent.Names;
            return names[names.Length - 1].Equals(p.Index.Name);
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

        /// <summary>Not supported. </summary>
        public virtual void Remove()
        {
            throw new NotSupportedException("Can't remove a node from a message");
        }

        /// <summary> Returns true if another object exists in the iteration sequence.  </summary>
        public virtual bool MoveNext()
        {
            var has = true;
            if (nextRenamedField == null)
            {
                if (typeof(IGroup).IsAssignableFrom(currentStructure.GetType()))
                {
                    GroupNext((IGroup)currentStructure);
                }
                else
                {
                    var parent = currentStructure.ParentStructure;
                    var i = GetIndex(parent, currentStructure);
                    var currentPosition = new Position(parent, i);

                    try
                    {
                        if (parent.IsRepeating(i.Name) && currentStructure.GetStructureName().Equals(direction))
                        {
                            NextRep(currentPosition);
                        }
                        else
                        {
                            has = NextPosition(currentPosition, direction, handleUnexpectedSegments);
                        }
                    }
                    catch (HL7Exception e)
                    {
                        throw new ApplicationException("HL7Exception arising from bad index: " + e.Message);
                    }
                }
            }

            Log.Debug("MessageIterator.hasNext() in direction " + direction + "? " + has);
            return has;
        }

        /// <summary>
        /// Reset the iterator.
        /// </summary>
        public virtual void Reset()
        {
        }

        /// <summary> Sets the next location to the next sibling of the given
        /// index.
        /// </summary>
        private void NextSibling(Position pos)
        {
            var names = pos.Parent.Names;
            var i = 0;
            for (; i < names.Length && !names[i].Equals(pos.Index.Name); i++)
            {
            }

            var nextName = names[i + 1];

            nextRenamedField = new Position(pos.Parent, nextName, 0);
        }

        private void ClearNext()
        {
            nextRenamedField = null;
        }

        /// <summary> Sets the next position to a new segment of the given name, within the
        /// given group.
        /// </summary>
        private void NewSegment(IGroup parent, string name)
        {
            Log.Info("MessageIterator creating new segment: " + name);
            parent.AddNonstandardSegment(name);
            nextRenamedField = new Position(parent, parent.Names[parent.Names.Length - 1], 0);
        }

        /// <summary> Sets next to the first child of the given group (iteration
        /// always proceeds from group to first child).
        /// </summary>
        private void GroupNext(IGroup current)
        {
            nextRenamedField = new Position(current, ((IGroup)current).Names[0], 0);
        }

        /// <summary> Sets next to the next repetition of the current structure.  </summary>
        private void NextRep(Position current)
        {
            nextRenamedField = new Position(current.Parent, current.Index.Name, current.Index.Rep + 1);
        }

        /// <summary> Sets this.next to the next position in the message (from the given position),
        /// which could be the next sibling, a new segment, or the next rep
        /// of the parent.  See next() for details.
        /// </summary>
        private bool NextPosition(Position currPos, string direction, bool makeNewSegmentIfNeeded)
        {
            var nextExists = true;
            if (IsLast(currPos))
            {
                nextExists = NextFromGroupEnd(currPos, direction, makeNewSegmentIfNeeded);
            }
            else
            {
                NextSibling(currPos);
            }

            return nextExists;
        }

        /// <summary>Navigates from end of group. </summary>
        private bool NextFromGroupEnd(Position currPos, string direction, bool makeNewSegmentIfNeeded)
        {
            // assert isLast(currPos);
            var nextExists = true;

            // the following conditional logic is a little convoluted -- its meant as an optimization
            // i.e. trying to avoid calling matchExistsAfterCurrentPosition
            if (!makeNewSegmentIfNeeded && typeof(IMessage).IsAssignableFrom(currPos.Parent.GetType()))
            {
                nextExists = false;
            }
            else if (!makeNewSegmentIfNeeded || MatchExistsAfterPosition(currPos, direction, false, true))
            {
                var grandparent = currPos.Parent.ParentStructure;
                var parentIndex = GetIndex(grandparent, currPos.Parent);
                var parentPos = new Position(grandparent, parentIndex);

                try
                {
                    var parentRepeats = parentPos.Parent.IsRepeating(parentPos.Index.Name);
                    if (parentRepeats && Contains(parentPos.Parent.GetStructure(parentPos.Index.Name, 0), direction, false, true))
                    {
                        NextRep(parentPos);
                    }
                    else
                    {
                        nextExists = NextPosition(parentPos, direction, makeNewSegmentIfNeeded);
                    }
                }
                catch (HL7Exception e)
                {
                    throw new ApplicationException("HL7Exception arising from bad index: " + e.Message);
                }
            }
            else
            {
                NewSegment(currPos.Parent, direction);
            }

            return nextExists;
        }

        /// <summary> An index of a child structure within a group, consisting of the name and rep of
        /// of the child.
        /// </summary>
        public class Index
        {
            /// <summary>
            /// The name.
            /// </summary>
            [Obsolete("This method has been replaced by 'Name'.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.NamingRules",
                "SA1307:Accessible fields should begin with upper-case letter",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.MaintainabilityRules",
                "SA1401:Fields should be private",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            public string name;

            /// <summary>
            /// The repetition.
            /// </summary>
            [Obsolete("This method has been replaced by 'Rep'.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.NamingRules",
                "SA1307:Accessible fields should begin with upper-case letter",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.MaintainabilityRules",
                "SA1401:Fields should be private",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            public int rep;

            /// <summary>
            /// The index.
            /// </summary>
            /// <param name="name">name.</param>
            /// <param name="rep">repetition.</param>
            public Index(string name, int rep)
            {
                Name = name;
                Rep = rep;
            }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            /// <summary>
            /// Gets or sets the repetition.
            /// </summary>
            public int Rep
            {
                get { return rep; }
                set { rep = value; }
            }

            /// <summary>
            /// Override equals.
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public override bool Equals(object o)
            {
                var equals = false;
                if (o != null && o is Index)
                {
                    var i = (Index)o;
                    if (i.Rep == Rep && i.Name.Equals(Name))
                    {
                        equals = true;
                    }
                }

                return equals;
            }

            /// <summary>
            /// Override has code.
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return Name.GetHashCode() + (700 * Rep);
            }

            /// <summary>
            /// Override to string.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return Name + ":" + Rep;
            }
        }

        /// <summary> A structure position within a message. </summary>
        public class Position
        {
            /// <summary>
            /// The parent.
            /// </summary>
            [Obsolete("This method has been replaced by 'Parent'.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.NamingRules",
                "SA1307:Accessible fields should begin with upper-case letter",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.MaintainabilityRules",
                "SA1401:Fields should be private",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            public IGroup parent;

            /// <summary>
            /// The index.
            /// </summary>
            [Obsolete("This method has been replaced by 'Index'.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.NamingRules",
                "SA1307:Accessible fields should begin with upper-case letter",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "StyleCop.CSharp.MaintainabilityRules",
                "SA1401:Fields should be private",
                Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
            public Index index;

            /// <summary>
            /// The position of the element.
            /// </summary>
            /// <param name="parent">Parent.</param>
            /// <param name="name">Name.</param>
            /// <param name="rep">Repetition.</param>
            public Position(IGroup parent, string name, int rep)
            {
                Parent = parent;
                Index = new Index(name, rep);
            }

            /// <summary>
            /// The position of the element.
            /// </summary>
            /// <param name="parent">Parent.</param>
            /// <param name="i">index.</param>
            public Position(IGroup parent, Index i)
            {
                Parent = parent;
                Index = i;
            }

            /// <summary>
            /// Gets or sets the parent.
            /// </summary>
            public IGroup Parent
            {
                get { return parent; }
                set { parent = value; }
            }

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            public Index Index
            {
                get { return index; }
                set { index = value; }
            }

            /// <summary>
            /// Override equals operator.
            /// </summary>
            /// <param name="obj">Object obj.</param>
            /// <returns>true if objects are equal.</returns>
            public override bool Equals(object obj)
            {
                var equals = false;
                if (obj != null && obj is Position)
                {
                    var p = (Position)obj;
                    if (p.Parent.Equals(Parent) && p.Index.Equals(Index))
                    {
                        equals = true;
                    }
                }

                return equals;
            }

            /// <summary>
            /// Override hash code.
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return Parent.GetHashCode() + Index.GetHashCode();
            }

            /// <summary>
            /// Override to string.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                var ret = new StringBuilder(Parent.GetStructureName());
                ret.Append(":");
                ret.Append(Index.Name);
                ret.Append("(");
                ret.Append(Index.Rep);
                ret.Append(")");
                return ret.ToString();
            }
        }
    }
}