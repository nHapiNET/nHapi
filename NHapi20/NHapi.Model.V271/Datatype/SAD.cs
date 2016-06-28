using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V271.Datatype
{

///<summary>
/// <p>The HL7 SAD (Street Address) data type.  Consists of the following components: </p><ol>
/// <li>Street or Mailing Address (ST)</li>
/// <li>Street Name (ST)</li>
/// <li>Dwelling Number (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class SAD : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a SAD.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public SAD(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a SAD.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public SAD(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new ST(message,"Street or Mailing Address");
		data[1] = new ST(message,"Street Name");
		data[2] = new ST(message,"Dwelling Number");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element SAD composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Street or Mailing Address (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST StreetOrMailingAddress {
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
	/// Returns Street Name (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST StreetName {
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
	/// Returns Dwelling Number (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST DwellingNumber {
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
}}