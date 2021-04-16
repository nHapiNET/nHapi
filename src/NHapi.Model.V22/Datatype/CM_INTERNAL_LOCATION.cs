using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V22.Datatype
{

///<summary>
/// <p>The HL7 CM_INTERNAL_LOCATION (CM für Ortsangaben im Krankenhaus) data type.  Consists of the following components: </p><ol>
/// <li>nurse unit (Station) (ID)</li>
/// <li>Room (ID)</li>
/// <li>Bed (ID)</li>
/// <li>Facility ID (ID)</li>
/// <li>Bed Status (ID)</li>
/// <li>Etage (ID)</li>
/// <li>Klinik (ID)</li>
/// <li>Zentrum (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_INTERNAL_LOCATION : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_INTERNAL_LOCATION.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_INTERNAL_LOCATION(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_INTERNAL_LOCATION.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_INTERNAL_LOCATION(IMessage message, string description) : base(message, description){
		data = new IType[8];
		data[0] = new ID(message, 0,"Nurse unit (Station)");
		data[1] = new ID(message, 0,"Room");
		data[2] = new ID(message, 0,"Bed");
		data[3] = new ID(message, 0,"Facility ID");
		data[4] = new ID(message, 0,"Bed Status");
		data[5] = new ID(message, 0,"Etage");
		data[6] = new ID(message, 0,"Klinik");
		data[7] = new ID(message, 0,"Zentrum");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 8 element CM_INTERNAL_LOCATION composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns nurse unit (Station) (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NurseUnitStation {
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
	/// Returns Room (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Room {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[1];
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
	public ID Bed {
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
	///<summary>
	/// Returns Bed Status (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID BedStatus {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Etage (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Etage {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Klinik (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Klinik {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Zentrum (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Zentrum {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}