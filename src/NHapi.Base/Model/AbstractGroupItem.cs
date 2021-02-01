using System;
using System.Collections.Generic;
using System.Text;
using NHapi.Base.Model;

namespace NHapi.Base.Model
{
    /// <summary>
    /// Abstract group item
    /// </summary>
    public class AbstractGroupItem
    {
        private string _name;
        private List<IStructure> _structures = new List<IStructure>();
        private bool _isRequired = false;
        private bool _isRepeating = false;
        private Type _class;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="required"></param>
        /// <param name="repeating"></param>
        /// <param name="classType"></param>
        public AbstractGroupItem(string name, bool required, bool repeating, Type classType)
        {
            _name = name;
            _isRequired = required;
            _isRepeating = repeating;
            _class = classType;
        }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// The type of class
        /// </summary>
        public Type ClassType
        {
            get { return _class; }
        }

        /// <summary>
        /// Is item repeating
        /// </summary>
        public bool IsRepeating
        {
            get { return _isRepeating; }
        }

        /// <summary>
        /// Is item required
        /// </summary>
        public bool IsRequired
        {
            get { return _isRequired; }
        }

        /// <summary>
        /// The structures of the group item
        /// </summary>
        public List<IStructure> Structures
        {
            get { return _structures; }
        }

        /// <summary>
        /// Structure indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IStructure this[int index]
        {
            get { return _structures[index]; }
            set
            {
                if (index > 0 && !_isRepeating)
                    throw new HL7Exception("Cannot add multiple strucutres to " + _name + ".  Item is non-repeating");

                _structures[index] = value;
            }
        }
    }
}