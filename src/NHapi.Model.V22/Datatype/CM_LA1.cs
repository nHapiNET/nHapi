using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V22.Datatype
{

///<summary>
/// <p>The HL7 CM_LA1 (Location with address information) data type.  Consists of the following components: </p><ol>
/// <li>Dispense / Deliver to Location (CM_INTERNAL_LOCATION)</li>
/// <li>location (AD)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_LA1 : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_LA1.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_LA1(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_LA1.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_LA1(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new CM_INTERNAL_LOCATION(message,"Dispense / Deliver to Location");
		data[1] = new AD(message,"Location");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element CM_LA1 composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Dispense / Deliver to Location (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_INTERNAL_LOCATION DispenseDeliverToLocation {
get{
	   CM_INTERNAL_LOCATION ret = null;
	   try {
	      ret = (CM_INTERNAL_LOCATION)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns location (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public AD Location {
get{
	   AD ret = null;
	   try {
	      ret = (AD)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}