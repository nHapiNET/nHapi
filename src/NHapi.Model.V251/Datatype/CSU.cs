using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V251.Datatype
{

///<summary>
/// <p>The HL7 CSU (Channel Sensitivity) data type.  Consists of the following components: </p><ol>
/// <li>Channel Sensitivity (NM)</li>
/// <li>Unit of Measure Identifier (ST)</li>
/// <li>Unit of Measure Description (ST)</li>
/// <li>Unit of Measure Coding System (ID)</li>
/// <li>Alternate Unit of Measure Identifier (ST)</li>
/// <li>Alternate Unit of Measure Description (ST)</li>
/// <li>Alternate Unit of Measure Coding System (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class CSU : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CSU.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CSU(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CSU.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CSU(IMessage message, string description) : base(message, description){
		data = new IType[7];
		data[0] = new NM(message,"Channel Sensitivity");
		data[1] = new ST(message,"Unit of Measure Identifier");
		data[2] = new ST(message,"Unit of Measure Description");
		data[3] = new ID(message, 396,"Unit of Measure Coding System");
		data[4] = new ST(message,"Alternate Unit of Measure Identifier");
		data[5] = new ST(message,"Alternate Unit of Measure Description");
		data[6] = new ID(message, 396,"Alternate Unit of Measure Coding System");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 7 element CSU composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Channel Sensitivity (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM ChannelSensitivity {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Unit of Measure Identifier (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UnitOfMeasureIdentifier {
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
	/// Returns Unit of Measure Description (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UnitOfMeasureDescription {
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
	/// Returns Unit of Measure Coding System (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID UnitOfMeasureCodingSystem {
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
	/// Returns Alternate Unit of Measure Identifier (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureIdentifier {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Unit of Measure Description (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureDescription {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Unit of Measure Coding System (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID AlternateUnitOfMeasureCodingSystem {
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
}}