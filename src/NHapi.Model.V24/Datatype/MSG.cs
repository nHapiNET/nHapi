using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 MSG (Message Type) data type.  Consists of the following components: </p><ol>
/// <li>message type (ID)</li>
/// <li>trigger event (ID)</li>
/// <li>message structure (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class MSG : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a MSG.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public MSG(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a MSG.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public MSG(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new ID(message, 0,"Message type");
		data[1] = new ID(message, 0,"Trigger event");
		data[2] = new ID(message, 0,"Message structure");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element MSG composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns message type (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID MessageType {
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
	/// Returns trigger event (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID TriggerEvent {
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
	/// Returns message structure (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID MessageStructure {
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
}}