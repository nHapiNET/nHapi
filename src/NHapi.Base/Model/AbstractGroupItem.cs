namespace NHapi.Base.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract group item.
    /// </summary>
    public class AbstractGroupItem
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="required"></param>
        /// <param name="repeating"></param>
        /// <param name="choiceElement"></param>
        /// <param name="classType"></param>
        public AbstractGroupItem(string name, bool required, bool repeating, bool choiceElement, Type classType)
        {
            Name = name;
            IsRequired = required;
            IsRepeating = repeating;
            IsChoiceElement = choiceElement;
            ClassType = classType;
        }

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The type of class.
        /// </summary>
        public Type ClassType { get; }

        /// <summary>
        /// Is item repeating.
        /// </summary>
        public bool IsRepeating { get; }

        /// <summary>
        /// Is item required.
        /// </summary>
        public bool IsRequired { get; }

        /// <summary>
        /// Is item a "choice element".
        /// </summary>
        public bool IsChoiceElement { get; }

        /// <summary>
        /// The structures of the group item.
        /// </summary>
        public List<IStructure> Structures { get; } = new List<IStructure>();

        /// <summary>
        /// Structure indexer.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IStructure this[int index]
        {
            get
            {
                return Structures[index];
            }

            set
            {
                if (index > 0 && !IsRepeating)
                {
                    throw new HL7Exception(
                        $"Cannot add multiple structures to {Name}. Item is non-repeating");
                }

                Structures[index] = value;
            }
        }
    }
}