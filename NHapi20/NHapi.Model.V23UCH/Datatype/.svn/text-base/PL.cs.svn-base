using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23UCH.Datatype
{

///<summary>
/// <p>The HL7 PL (person location) data type.  Consists of the following components: </p><ol>
/// <li>point of care (ID) (ID)</li>
/// <li>room (IS)</li>
/// <li>bed (IS)</li>
/// <li>facility (HD) (HD)</li>
/// <li>location status (IS)</li>
/// <li>person location type (IS)</li>
/// <li>building (IS)</li>
/// <li>floor (ST)</li>
/// <li>Location type (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class PL : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a PL.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public PL(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a PL.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public PL(IMessage message, string description) : base(message, description){
		data = new IType[9];
		data[0] = new ID(message, 0,"Point of care (ID)");
		data[1] = new IS(message, 0,"Room");
		data[2] = new IS(message, 0,"Bed");
		data[3] = new HD(message,"Facility (HD)");
		data[4] = new IS(message, 0,"Location status");
		data[5] = new IS(message, 0,"Person location type");
		data[6] = new IS(message, 0,"Building");
		data[7] = new ST(message,"Floor");
		data[8] = new ST(message,"Location type");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 9 element PL composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns point of care (ID) (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID PointOfCare {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns room (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS Room {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns bed (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS Bed {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns facility (HD) (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD Facility {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns location status (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS LocationStatus {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns person location type (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS PersonLocationType {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns building (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS Building {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns floor (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Floor {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Location type (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST LocationType {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[8];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}