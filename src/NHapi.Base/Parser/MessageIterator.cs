namespace NHapi.Base.Parser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

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

        private readonly IMessage message;
        private readonly bool handleUnexpectedSegments;

        private string direction;
        private bool nextIsSet;
        private List<Position> currentDefinitionPath = new List<Position>();

        static MessageIterator()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(MessageIterator));
        }

        /// <summary>Creates a new instance of MessageIterator. </summary>
        public MessageIterator(IMessage start, IStructureDefinition startDefinition, string direction, bool handleUnexpectedSegments)
        {
            this.message = start;
            this.direction = direction;
            this.handleUnexpectedSegments = handleUnexpectedSegments;
            this.currentDefinitionPath.Add(new Position(startDefinition, -1));
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
                    throw new IndexOutOfRangeException("No more nodes in message");
                }

                var currentStructure = NavigateToStructure(currentDefinitionPath);

                ClearNext();
                return currentStructure;
            }
        }

        /// <summary>
        /// The direction.
        /// </summary>
        public virtual string Direction
        {
            get => direction;

            set
            {
                ClearNext();
                direction = value;
            }
        }

        /// <summary>
        /// Returns true if another object exists in the iteration sequence.
        /// </summary>
        public virtual bool MoveNext()
        {
            if (this.direction == null)
            {
                throw new InvalidOperationException("Direction not set");
            }

            while (!this.nextIsSet)
            {
                var currentPosition = GetCurrentPosition();

                var structureDefinition = currentPosition.StructureDefinition;

                if (structureDefinition.IsSegment && structureDefinition.Name.StartsWith(direction, StringComparison.Ordinal) && (structureDefinition.IsRepeating || currentPosition.Repetition == -1))
                {
                    nextIsSet = true;
                    currentPosition.IncrementRepetition();
                }
                else if (structureDefinition.IsSegment
                         && structureDefinition.NextLeaf == null
                         && !structureDefinition.GetNamesOfAllPossibleFollowingLeaves().Contains(direction))
                {
                    if (!handleUnexpectedSegments)
                    {
                        return false;
                    }

                    AddNonStandardSegmentAtCurrentPosition();
                }
                else if (structureDefinition.HasChildren && structureDefinition.GetAllPossibleFirstChildren().Contains(direction) && (structureDefinition.IsRepeating || currentPosition.Repetition == -1))
                {
                    currentPosition.IncrementRepetition();
                    currentDefinitionPath.Add(new Position(structureDefinition.FirstChild, -1));
                }
                else if (!structureDefinition.HasChildren && !structureDefinition.GetNamesOfAllPossibleFollowingLeaves().Contains(direction))
                {
                    if (!handleUnexpectedSegments)
                    {
                        return false;
                    }

                    AddNonStandardSegmentAtCurrentPosition();
                }
                else if (structureDefinition.IsFinalChildOfParent)
                {
                    var newDefinitionPath = PopUntilMatchFound(currentDefinitionPath);
                    if (newDefinitionPath != null)
                    {
                        // found match
                        currentDefinitionPath = newDefinitionPath;
                    }
                    else
                    {
                        if (!handleUnexpectedSegments)
                        {
                            return false;
                        }

                        AddNonStandardSegmentAtCurrentPosition();
                    }
                }
                else
                {
                    currentPosition.StructureDefinition = structureDefinition.NextSibling;
                    currentPosition.ResetRepetition();
                }
            }

            return true;
        }

        /// <summary>
        /// Reset the iterator.
        /// </summary>
        public virtual void Reset()
        {
        }

        private Position GetCurrentPosition()
        {
            return currentDefinitionPath.Last();
        }

        private void AddNonStandardSegmentAtCurrentPosition()
        {
            Log.Debug(
                $"Creating non standard segment {direction} on group: {GetCurrentPosition().StructureDefinition.Parent.Name}");

            // TODO: make configurable like hapi?
            // switch (message.getParser().getParserConfiguration().getUnexpectedSegmentBehaviour())
            // {
            //     case ADD_INLINE:
            //     default:
            //         parentDefinitionPath = new ArrayList<>(myCurrentDefinitionPath.subList(0, myCurrentDefinitionPath.size() - 1));
            //         parentStructure = (IGroup)navigateToStructure(parentDefinitionPath);
            //         break;
            //     case DROP_TO_ROOT:
            //         parentDefinitionPath = new ArrayList<>(myCurrentDefinitionPath.subList(0, 1));
            //         parentStructure = myMessage;
            //         myCurrentDefinitionPath = myCurrentDefinitionPath.subList(0, 2);
            //         break;
            //     case THROW_HL7_EXCEPTION:
            //         throw new Error(new HL7Exception("Found unknown segment: " + myDirection));
            // }

            // default hapi behaviour
            var parentDefinitionPath = new List<Position>(currentDefinitionPath.GetRange(0, currentDefinitionPath.Count - 1));
            var parentStructure = (IGroup)NavigateToStructure(parentDefinitionPath);

            // Current position within parent
            var currentPosition = GetCurrentPosition();
            var nameAsItAppearsInParent = currentPosition.StructureDefinition.NameAsItAppearsInParent;

            var index = Array.IndexOf(parentStructure.Names, nameAsItAppearsInParent) + 1;

            string newSegmentName;

            // Check if the structure already has a non-standard segment in the appropriate
            // position
            var currentNames = parentStructure.Names;
            if (index < currentNames.Length && currentNames[index].StartsWith(direction, StringComparison.Ordinal))
            {
                newSegmentName = currentNames[index];
            }
            else
            {
                newSegmentName = parentStructure.AddNonstandardSegment(direction, index);
            }

            try
            {
                var previousSibling = GetCurrentPosition().StructureDefinition;
                var parentStructureDefinition = parentDefinitionPath.Last().StructureDefinition;
                var nextDefinition = new NonStandardStructureDefinition(parentStructureDefinition, previousSibling, newSegmentName, index);
                currentDefinitionPath = parentDefinitionPath;
                currentDefinitionPath.Add(new Position(nextDefinition, 0));

                nextIsSet = true;
            }
            catch (Exception ex)
            {
                throw new HL7Exception(
                    $"Could not add non-standard segment at current position.",
                    ex);
            }
        }

        private IStructure NavigateToStructure(IEnumerable<Position> theDefinitionPath)
        {
            IStructure currentStructure = null;
            foreach (var next in theDefinitionPath)
            {
                if (currentStructure == null)
                {
                    currentStructure = message;
                }
                else
                {
                    var structureDefinition = next.StructureDefinition;
                    var currentStructureGroup = (IGroup)currentStructure;
                    var nextStructureName = structureDefinition.NameAsItAppearsInParent;
                    currentStructure = currentStructureGroup.GetStructure(nextStructureName, next.Repetition);
                }
            }

            return currentStructure;
        }

        private List<Position> PopUntilMatchFound(List<Position> theDefinitionPath)
        {
            while (true)
            {
                theDefinitionPath = new List<Position>(theDefinitionPath.GetRange(0, theDefinitionPath.Count - 1));

                if (theDefinitionPath.Count == 0)
                {
                    Log.Debug($"The created list of positions contains no elements.");
                    return null;
                }

                var newCurrentPosition = theDefinitionPath.Last();
                var newCurrentStructureDefinition = newCurrentPosition.StructureDefinition;

                if (newCurrentStructureDefinition.GetAllPossibleFirstChildren().Contains(direction))
                {
                    return theDefinitionPath;
                }

                if (!newCurrentStructureDefinition.IsFinalChildOfParent)
                {
                    return theDefinitionPath;
                }

                if (theDefinitionPath.Count > 1)
                {
                    continue;
                }

                Log.Debug($"Popped to root of message and did not find a match for {direction}");
                return null;
            }
        }

        private void ClearNext()
        {
            nextIsSet = false;
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
            public Position(IStructureDefinition structureDefinition, int repetition)
            {
                StructureDefinition = structureDefinition;
                Repetition = repetition;
            }

            public IStructureDefinition StructureDefinition { get; set; }

            public int Repetition { get; private set; }

            public void ResetRepetition()
            {
                Repetition = -1;
            }

            public void IncrementRepetition()
            {
                Repetition++;
            }

            public override bool Equals(object obj)
            {
                if ((obj == null) || GetType() != obj.GetType())
                {
                    return false;
                }

                return Equals((Position)obj);
            }

            public override int GetHashCode()
            {
                return StructureDefinition.GetHashCode() + Repetition;
            }

            protected bool Equals(Position other)
            {
                return StructureDefinition.Equals((StructureDefinition)other.StructureDefinition);
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "Operator override")]
            public static bool operator ==(Position lhs, Position rhs)
            {
                return ReferenceEquals(lhs, null)
                    ? ReferenceEquals(rhs, null)
                    : lhs.Equals(rhs);
            }

            public static bool operator !=(Position lhs, Position rhs) => !(lhs == rhs);

            /// <summary>
            /// Override to string.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                var parent = StructureDefinition.Parent?.Name ?? "Root";

                return $"{parent}:{StructureDefinition.Name}({Repetition})";
            }
        }
    }
}