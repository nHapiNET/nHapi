using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V22.Datatype
{

///<summary>
/// <p>The HL7 CM_NDL (observing practitioner) data type.  Consists of the following components: </p><ol>
/// <li>interpreter / technician (CN_PERSON)</li>
/// <li>start date/time (TS)</li>
/// <li>end date/time (TS)</li>
/// <li>location (CM_INTERNAL_LOCATION)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_NDL : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_NDL.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_NDL(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_NDL.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_NDL(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new CN_PERSON(message,"Interpreter / technician");
		data[1] = new TS(message,"Start date/time");
		data[2] = new TS(message,"End date/time");
		data[3] = new CM_INTERNAL_LOCATION(message,"Location");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element CM_NDL composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns interpreter / technician (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CN_PERSON InterpreterTechnician {
get{
	   CN_PERSON ret = null;
	   try {
	      ret = (CN_PERSON)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns start date/time (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TS StartDateTime {
get{
	   TS ret = null;
	   try {
	      ret = (TS)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns end date/time (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TS EndDateTime {
get{
	   TS ret = null;
	   try {
	      ret = (TS)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns location (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_INTERNAL_LOCATION Location {
get{
	   CM_INTERNAL_LOCATION ret = null;
	   try {
	      ret = (CM_INTERNAL_LOCATION)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}