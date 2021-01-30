using System;

using NHapi.Base;
using NHapi.Base.Log;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;

namespace NHapi.Model.V22_ZSegments.Datatype
{
   ///<summary>
   /// The HL7 ACCIDENTDATA data type.  Consists of the following components:
   /// <ol>
   /// <li>file number (ID)</li>
   /// <li>text (ST)</li>
   /// </ol>
   ///</summary>
   [Serializable]
	public class ACCIDENTDATA : AbstractType, IComposite
	{
		#region Fields

		private IType[] data;

		#endregion

		#region Constructor

		///<summary>
		/// Creates a ACCIDENTDATA.
		/// <param name="message">The Message to which this Type belongs</param>
		///</summary>
		public ACCIDENTDATA(IMessage message) : this(message, null) { }

		///<summary>
		/// Creates a ACCIDENTDATA.
		///</summary>		
		/// <param name="message">The Message to which this Type belongs</param>
		/// <param name="description"></param>
		public ACCIDENTDATA(IMessage message, string description) : base(message, description)
		{
			data = new IType[2];
			data[0] = new ID(message, 0, "File number");
			data[1] = new ST(message, "Text");
		}

		#endregion

		#region Properties

		///<summary>
		/// Returns an array containing the data elements.
		///</summary>
		public IType[] Components
		{
			get
			{
				return this.data;
			}
		}

		///<summary>
		/// Returns an individual data component.
		///</summary>
		///<returns>The data component (as a type) at the requested number (ordinal)</returns>
		///<exception cref="DataTypeException">Thrown if the given element number is out of range.</exception>
		public IType this[int index]
		{
			get
			{
				try
				{
					return this.data[index];
				}
				catch (System.ArgumentOutOfRangeException)
				{
					throw new DataTypeException("Element " + index + " doesn't exist in 8 element AD composite");
				}
			}
		}

		///<summary>
		/// Returns file number (component #1).  
		/// This is a convenience method that saves you from 
		/// casting and handling an exception.
		///</summary>
		public ID Id
		{
			get
			{
				ID ret = null;
				try
				{
					ret = (ID)this[0];
				}
				catch (DataTypeException e)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
					throw new System.Exception("An unexpected error occurred", e);
				}
				return ret;
			}
		}

		///<summary>
		/// Returns text (component #2).  
		/// This is a convenience method that saves you from 
		/// casting and handling an exception.
		///</summary>		
		public ST Text
		{
			get
			{
				ST ret = null;
				try
				{
					ret = (ST)this[1];
				}
				catch (DataTypeException e)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
					throw new System.Exception("An unexpected error occurred", e);
				}
				return ret;
			}
		}

		#endregion
	}
}
