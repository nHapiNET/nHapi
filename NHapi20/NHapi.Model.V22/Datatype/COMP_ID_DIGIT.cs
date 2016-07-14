using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V22.Datatype
{

///<summary>
/// <p>The HL7 COMP_ID_DIGIT (composite ID with cheCOMP_ID_DIGIT digit) data type.  Consists of the following components: </p><ol>
/// <li>ID Number (ST)</li>
/// <li>CheCOMP_ID_DIGIT Digit (NM)</li>
/// <li>CheCOMP_ID_DIGIT Digit Scheme (ID)</li>
/// <li>Facility ID (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class COMP_ID_DIGIT : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a COMP_ID_DIGIT.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public COMP_ID_DIGIT(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a COMP_ID_DIGIT.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public COMP_ID_DIGIT(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"ID Number");
		data[1] = new NM(message,"CheCOMP_ID_DIGIT Digit");
		data[2] = new ID(message, 0,"CheCOMP_ID_DIGIT Digit Scheme");
		data[3] = new ID(message, 0,"Facility ID");
	}

	///<summary>
	/// Returns an array containing the data elements.
	///</summary>
	public IType[] Components
	{ 
		get{
			return this.data; 
		}
	}

	///<summary>
	/// Returns an individual data component.
	/// @throws DataTypeException if the given element number is out of range.
	///<param name="index">The index item to get (zero based)</param>
	///<returns>The data component (as a type) at the requested number (ordinal)</returns>
	///</summary>
	public IType this[int index] { 

get{
		try { 
			return this.data[index]; 
		} catch (System.ArgumentOutOfRangeException) { 
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element COMP_ID_DIGIT composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns ID Number (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST IDNumber {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns CheCOMP_ID_DIGIT Digit (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM CheCOMP_ID_DIGITDigit {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns CheCOMP_ID_DIGIT Digit Scheme (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID CheCOMP_ID_DIGITDigitScheme {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Facility ID (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID FacilityID {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}