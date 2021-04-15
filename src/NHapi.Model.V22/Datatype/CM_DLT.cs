using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V22.Datatype
{

///<summary>
/// <p>The HL7 CM_DLT (delta check) data type.  Consists of the following components: </p><ol>
/// <li>Range (CM_RANGE)</li>
/// <li>numeric threshold (NM)</li>
/// <li>change (ST)</li>
/// <li>length of time-days (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_DLT : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_DLT.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_DLT(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_DLT.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_DLT(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new CM_RANGE(message,"Range");
		data[1] = new NM(message,"Numeric threshold");
		data[2] = new ST(message,"Change");
		data[3] = new NM(message,"Length of time-days");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element CM_DLT composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Range (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_RANGE Range {
get{
	   CM_RANGE ret = null;
	   try {
	      ret = (CM_RANGE)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns numeric threshold (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM NumericThreshold {
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
	/// Returns change (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Change {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns length of time-days (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM LengthOfTimeDays {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}