namespace NHapi.Base.Model
{
    using System;
    using System.Collections.Generic;

    internal class AbstractSegmentItem
    {
        private List<object> args = new List<object>();
        private int maxReps = -1;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="t">the class of the data for this field - this should inherit from IType.</param>
        /// <param name="required">whether a value for this field is required in order for the segment to be valid.</param>
        /// <param name="maxReps">the maximum number of repetitions - 0 implies that there is no limit.</param>
        /// <param name="length">the maximum length of each repetition of the field (in characters).</param>
        /// <param name="constructorArgs">
        /// an array of objects that will be used as constructor arguments
        /// if new instances of this class are created (use null for zero-arg constructor).
        /// </param>
        /// <exception cref="HL7Exception">Thrown if the given class does not inherit from IType or if it cannot be instantiated.</exception>
        public AbstractSegmentItem(Type t, bool required, int maxReps, int length, object[] constructorArgs)
            : this(t, required, maxReps, length, constructorArgs, string.Empty)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="t">the class of the data for this field - this should inherit from IType.</param>
        /// <param name="required">whether a value for this field is required in order for the segment to be valid.</param>
        /// <param name="maxReps">the maximum number of repetitions - 0 implies that there is no limit.</param>
        /// <param name="length">the maximum length of each repetition of the field (in characters). </param>
        /// <param name="constructorArgs">an array of objects that will be used as constructor arguments if new instances of this class are created (use null for zero-arg constructor).</param>
        /// <param name="description">Description of the segment.</param>
        /// <exception cref="HL7Exception">Thrown if the given class does not inherit from IType or if it cannot be instantiated.</exception>
        public AbstractSegmentItem(
            Type t,
            bool required,
            int maxReps,
            int length,
            object[] constructorArgs,
            string description)
        {
            if (!typeof(IType).IsAssignableFrom(t))
            {
                throw new HL7Exception(
                    $"Class {t.FullName} does not inherit from NHapi.Base.Model.IType",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            FieldType = t;
            Length = length;
            IsRequired = required;
            this.maxReps = maxReps;
            if (constructorArgs != null)
            {
                args.AddRange(constructorArgs);
            }

            Description = description;
        }

        /// <summary>
        /// The IType of this field in the segment.
        /// </summary>
        public Type FieldType { get; }

        /// <summary>
        /// Is this a required field.
        /// </summary>
        public bool IsRequired { get; }

        /// <summary>
        /// What is the length in characters of the field.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Arguments to pass to a constructor for this field.
        /// </summary>
        public object[] Args => args.ToArray();

        /// <summary>
        /// Maximum number of repetitions of this field.
        /// </summary>
        public int MaxRepetitions
        {
            get { return (maxReps <= 0) ? int.MaxValue : maxReps; }
            set { maxReps = value; }
        }

        /// <summary>
        /// What is this field.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IList<IType> Fields { get; } = new List<IType>();

        /// <summary>
        /// Return a specific repetition of this field.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IType this[int index] => Fields[index];

        public IType[] GetAllFieldsAsITypeArray()
        {
            var fields = new IType[Fields.Count];
            var i = 0;
            foreach (var type in Fields)
            {
                fields[i++] = type;
            }

            return fields;
        }
    }
}