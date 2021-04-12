namespace NHapi.Base.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc />
    public class StructureDefinition : IStructureDefinition
    {
        private HashSet<string> allChildrenNames;

        private HashSet<string> allFirstLeafNames;

        private IStructureDefinition firstSibling;

        private bool firstSiblingIsSet;

        private bool? isFinalChildOfParent;

        private HashSet<string> namesOfAllPossibleFollowingLeaves;

        private IStructureDefinition nextSibling;

        public string Name { get; set; }

        public bool IsChoiceElement { get; set; }

        public bool IsRequired { get; set; }

        public bool IsSegment { get; set; }

        public bool IsRepeating { get; set; }

        public bool HasChildren => Children.Any();

        public bool IsFinalChildOfParent
        {
            get
            {
                if (isFinalChildOfParent.HasValue)
                {
                    return isFinalChildOfParent.Value;
                }

                isFinalChildOfParent = Parent == null || Position == (Parent.Children.Count - 1);

                return isFinalChildOfParent.Value;
            }
        }

        public List<IStructureDefinition> Children { get; } = new List<IStructureDefinition>();

        public IStructureDefinition FirstChild => Children[0];

        public IStructureDefinition Parent { get; set; }

        public IStructureDefinition FirstSibling
        {
            get
            {
                if (firstSiblingIsSet)
                {
                    return firstSibling;
                }

                if (Parent == null || this.Equals(Parent.FirstChild))
                {
                    firstSibling = null;
                }
                else
                {
                    firstSibling = Parent.FirstChild;
                }

                firstSiblingIsSet = true;

                return firstSibling;
            }
        }

        public IStructureDefinition NextLeaf { get; set; }

        public string NameAsItAppearsInParent { get; set; }

        public int Position { get; set; }

        public IStructureDefinition NextSibling
        {
            get
            {
                if (nextSibling != null)
                {
                    return nextSibling;
                }

                if (IsFinalChildOfParent)
                {
                    throw new InvalidOperationException("Final child");
                }

                nextSibling = Parent.Children[Position + 1];
                return nextSibling;
            }
        }

        public HashSet<string> GetNamesOfAllPossibleFollowingLeaves()
        {
            if (namesOfAllPossibleFollowingLeaves != null)
            {
                return namesOfAllPossibleFollowingLeaves;
            }

            namesOfAllPossibleFollowingLeaves = new HashSet<string>();

            var nextLeaf = NextLeaf;
            if (nextLeaf != null)
            {
                namesOfAllPossibleFollowingLeaves.Add(nextLeaf.Name);
                namesOfAllPossibleFollowingLeaves.UnionWith(nextLeaf.GetNamesOfAllPossibleFollowingLeaves());
            }

            var parent = Parent;
            while (parent != null)
            {
                if (parent.IsRepeating)
                {
                    namesOfAllPossibleFollowingLeaves.UnionWith(parent.GetAllPossibleFirstChildren());
                }

                parent = parent.Parent;
            }

            return namesOfAllPossibleFollowingLeaves;
        }

        public HashSet<string> GetAllPossibleFirstChildren()
        {
            if (allFirstLeafNames != null)
            {
                return allFirstLeafNames;
            }

            allFirstLeafNames = new HashSet<string>();

            var hasChoice = false;
            foreach (var next in Children)
            {
                allFirstLeafNames.UnionWith(next.GetAllPossibleFirstChildren());

                if (next.IsChoiceElement)
                {
                    hasChoice = true;
                    continue;
                }

                if (hasChoice || next.IsRequired)
                {
                    break;
                }
            }

            allFirstLeafNames.Add(Name);

            return allFirstLeafNames;
        }

        public HashSet<string> GetAllChildNames()
        {
            if (allChildrenNames != null)
            {
                return allChildrenNames;
            }

            allChildrenNames = new HashSet<string>();
            foreach (var next in Children)
            {
                allChildrenNames.Add(next.Name);
                allChildrenNames.UnionWith(next.GetAllChildNames());
            }

            return allChildrenNames;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((StructureDefinition)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ Position;
            }
        }

        protected bool Equals(StructureDefinition other)
        {
            return Name == other?.Name && Position == other?.Position;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "Operator override")]
        public static bool operator ==(StructureDefinition lhs, StructureDefinition rhs)
        {
            return ReferenceEquals(lhs, null)
                ? ReferenceEquals(rhs, null)
                : lhs.Equals(rhs);
        }

        public static bool operator !=(StructureDefinition lhs, StructureDefinition rhs) => !(lhs == rhs);
    }
}
