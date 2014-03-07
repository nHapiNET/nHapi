using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23UCH.Datatype
{

///<summary>
/// <p>The HL7 CM_AS (Allowable Service) data type.  Consists of the following components: </p><ol>
/// <li>Allowable Service 2 (ST)</li>
/// <li>Allowable Service 3 (ST)</li>
/// <li>Allowable Service 4 (ST)</li>
/// <li>Allowable Service 5 (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_AS : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_AS.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_AS(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_AS.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_AS(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"Allowable Service 2");
		data[1] = new ST(message,"Allowable Service 3");
		data[2] = new ST(message,"Allowable Service 4");
		data[3] = new ST(message,"Allowable Service 5");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element CM_AS composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Allowable Service 2 (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AllowableService2 {
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
	/// Returns Allowable Service 3 (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AllowableService3 {
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
	/// Returns Allowable Service 4 (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AllowableService4 {
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
	/// Returns Allowable Service 5 (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AllowableService5 {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}