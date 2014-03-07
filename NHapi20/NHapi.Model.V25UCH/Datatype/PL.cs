using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V25UCH.Datatype
{

///<summary>
/// <p>The HL7 PL (Person Location) data type.  Consists of the following components: </p><ol>
/// <li>Point of Care (IS)</li>
/// <li>Room (IS)</li>
/// <li>Bed (IS)</li>
/// <li>Facility (HD)</li>
/// <li>Location Status (IS)</li>
/// <li>Person Location Type (IS)</li>
/// <li>Building (IS)</li>
/// <li>Floor (IS)</li>
/// <li>Location Description (ST)</li>
/// <li>Comprehensive Location Identifier (EI)</li>
/// <li>Assigning Authority for Location (HD)</li>
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
		data = new IType[11];
		data[0] = new IS(message, 302,"Point of Care");
		data[1] = new IS(message, 303,"Room");
		data[2] = new IS(message, 304,"Bed");
		data[3] = new HD(message,"Facility");
		data[4] = new IS(message, 306,"Location Status");
		data[5] = new IS(message, 305,"Person Location Type");
		data[6] = new IS(message, 307,"Building");
		data[7] = new IS(message, 308,"Floor");
		data[8] = new ST(message,"Location Description");
		data[9] = new EI(message,"Comprehensive Location Identifier");
		data[10] = new HD(message,"Assigning Authority for Location");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 11 element PL composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Point of Care (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS PointOfCare {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Room (component #1).  This is a convenience method that saves you from 
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
	/// Returns Bed (component #2).  This is a convenience method that saves you from 
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
	/// Returns Facility (component #3).  This is a convenience method that saves you from 
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
	/// Returns Location Status (component #4).  This is a convenience method that saves you from 
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
	/// Returns Person Location Type (component #5).  This is a convenience method that saves you from 
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
	/// Returns Building (component #6).  This is a convenience method that saves you from 
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
	/// Returns Floor (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS Floor {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Location Description (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST LocationDescription {
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
	///<summary>
	/// Returns Comprehensive Location Identifier (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public EI ComprehensiveLocationIdentifier {
get{
	   EI ret = null;
	   try {
	      ret = (EI)this[9];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Assigning Authority for Location (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD AssigningAuthorityForLocation {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[10];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}