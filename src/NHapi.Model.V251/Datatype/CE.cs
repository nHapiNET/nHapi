using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V251.Datatype
{

///<summary>
/// <p>The HL7 CE (Coded Element) data type.  Consists of the following components: </p><ol>
/// <li>Identifier (ST)</li>
/// <li>Text (ST)</li>
/// <li>Name of Coding System (ID)</li>
/// <li>Alternate Identifier (ST)</li>
/// <li>Alternate Text (ST)</li>
/// <li>Name of Alternate Coding System (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class CE : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CE.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CE(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CE.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CE(IMessage message, string description) : base(message, description){
		data = new IType[6];
		data[0] = new ST(message,"Identifier");
		data[1] = new ST(message,"Text");
		data[2] = new ID(message, 396,"Name of Coding System");
		data[3] = new ST(message,"Alternate Identifier");
		data[4] = new ST(message,"Alternate Text");
		data[5] = new ID(message, 396,"Name of Alternate Coding System");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 6 element CE composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Identifier (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Identifier {
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
	/// Returns Text (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Text {
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
	/// Returns Name of Coding System (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameOfCodingSystem {
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
	/// Returns Alternate Identifier (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateIdentifier {
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
	///<summary>
	/// Returns Alternate Text (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateText {
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
	/// Returns Name of Alternate Coding System (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameOfAlternateCodingSystem {
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
}}