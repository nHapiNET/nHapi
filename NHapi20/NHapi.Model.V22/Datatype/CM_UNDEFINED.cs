using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V22.Datatype
{

///<summary>
/// <p>The HL7 CM_UNDEFINED (Undefined CM data type) data type.  Consists of the following components: </p><ol>
/// <li>observation identifier (OBX-3) of parent result (CE)</li>
/// <li>sub-ID (OBX-4) of parent result (ST)</li>
/// <li>result (OBX-5) from parent (CE)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_UNDEFINED : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_UNDEFINED.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_UNDEFINED(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_UNDEFINED.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_UNDEFINED(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new CE(message,"Observation identifier (OBX-3) of parent result");
		data[1] = new ST(message,"Sub-ID (OBX-4) of parent result");
		data[2] = new CE(message,"Result (OBX-5) from parent");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element CM_UNDEFINED composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns observation identifier (OBX-3) of parent result (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE ObservationIdentifierOBX3OfParentResult {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sub-ID (OBX-4) of parent result (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SubIDOBX4OfParentResult {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns result (OBX-5) from parent (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE ResultOBX5FromParent {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}