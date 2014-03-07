using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V25UCH.Datatype
{

///<summary>
/// <p>The HL7 PRL (Parent Result Link) data type.  Consists of the following components: </p><ol>
/// <li>Parent Observation Identifier (CE)</li>
/// <li>Parent Observation Sub-identifier (ST)</li>
/// <li>Parent Observation Value Descriptor (TX)</li>
/// </ol>
///</summary>
[Serializable]
public class PRL : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a PRL.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public PRL(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a PRL.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public PRL(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new CE(message,"Parent Observation Identifier");
		data[1] = new ST(message,"Parent Observation Sub-identifier");
		data[2] = new TX(message,"Parent Observation Value Descriptor");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element PRL composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Parent Observation Identifier (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE ParentObservationIdentifier {
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
	/// Returns Parent Observation Sub-identifier (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST ParentObservationSubIdentifier {
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
	/// Returns Parent Observation Value Descriptor (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TX ParentObservationValueDescriptor {
get{
	   TX ret = null;
	   try {
	      ret = (TX)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}