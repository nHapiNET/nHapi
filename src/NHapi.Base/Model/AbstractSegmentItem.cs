namespace NHapi.Base.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class AbstractSegmentItem
    {
        private List<IType> _fields = new List<IType>();
        private Type _type;
        private bool _required = false;
        private int _length = 0;
        private List<object> _args = new List<object>();
        private int _maxReps = -1;
        private string _description;

        /// <summary>
        /// Constructor
        /// <param name="t">the class of the data for this field - this should inherit from IType</param>
        /// <param name="required">whether a value for this field is required in order for the segment
        /// to be valid</param>
        /// <param name="maxReps">the maximum number of repetitions - 0 implies that there is no limit</param>
        /// <param name="length">the maximum length of each repetition of the field (in characters) </param>
        /// <param name="constructorArgs">an array of objects that will be used as constructor arguments
        /// if new instances of this class are created (use null for zero-arg constructor)</param>
        /// <throws>  HL7Exception if the given class does not inherit from IType or if it cannot be instantiated. </throws>
        /// </summary>
        public AbstractSegmentItem(Type t, bool required, int maxReps, int length, object[] constructorArgs)
            : this(t, required, maxReps, length, constructorArgs, string.Empty)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="t">the class of the data for this field - this should inherit from IType</param>
        /// <param name="required">whether a value for this field is required in order for the segment
        /// to be valid</param>
        /// <param name="maxReps">the maximum number of repetitions - 0 implies that there is no limit</param>
        /// <param name="length">the maximum length of each repetition of the field (in characters) </param>
        /// <param name="constructorArgs">an array of objects that will be used as constructor arguments
        /// if new instances of this class are created (use null for zero-arg constructor)</param>
        /// <param name="description">Description of the segment</param>
        /// <throws>  HL7Exception if the given class does not inherit from IType or if it cannot be instantiated. </throws>
        public AbstractSegmentItem(Type t, bool required, int maxReps, int length, object[] constructorArgs,
            string description)
        {
            if (!typeof(IType).IsAssignableFrom(t))
            {
                throw new HL7Exception(
                    "Class " + t.FullName + " does not inherit from " + "NHapi.Base.Model.IType",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            _type = t;
            _length = length;
            _required = required;
            _maxReps = maxReps;
            if (constructorArgs != null)
                _args.AddRange(constructorArgs);
            _description = description;
        }

        /// <summary>
        ///     The IType of this field in the segment
        /// </summary>
        public Type FieldType
        {
            get { return _type; }
        }

        /// <summary>
        /// Is this a required field
        /// </summary>
        public bool IsRequired
        {
            get { return _required; }
        }

        /// <summary>
        /// What is the length in characters of the field
        /// </summary>
        public int Length
        {
            get { return _length; }
        }

        /// <summary>
        /// Arguments to pass to a constructor for this field
        /// </summary>
        public object[] Args
        {
            get { return _args.ToArray(); }
        }

        /// <summary>
        /// Maximum number of repetitions of this field
        /// </summary>
        public int MaxRepetitions
        {
            get
            {
                if (_maxReps <= 0)
                    return int.MaxValue;
                else
                    return _maxReps;
            }

            set { _maxReps = value; }
        }

        /// <summary>
        /// What is this field
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Return a specific repetition of this field
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IType this[int index]
        {
            get { return _fields[index]; }
        }

        /// <summary>
        ///
        /// </summary>
        public IList<IType> Fields
        {
            get { return _fields; }
        }

        public IType[] GetAllFieldsAsITypeArray()
        {
            IType[] fields = new IType[_fields.Count];
            int i = 0;
            foreach (IType type in _fields)
            {
                fields[i++] = type;
            }

            return fields;
        }
    }
}