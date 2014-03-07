using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V251.Datatype
{

///<summary>
/// <p>The HL7 RP (Reference Pointer) data type.  Consists of the following components: </p><ol>
/// <li>Pointer (ST)</li>
/// <li>Application ID (HD)</li>
/// <li>Type of Data (ID)</li>
/// <li>Subtype (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class RP : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a RP.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public RP(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a RP.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public RP(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"Pointer");
		data[1] = new HD(message,"Application ID");
		data[2] = new ID(message, 191,"Type of Data");
		data[3] = new ID(message, 291,"Subtype");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element RP composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Pointer (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Pointer {
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
	/// Returns Application ID (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD ApplicationID {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Type of Data (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID TypeOfData {
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
	/// Returns Subtype (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Subtype {
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