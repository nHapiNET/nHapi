using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V26.Datatype
{

///<summary>
/// <p>The HL7 CE (Coded Element) data type.  Consists of the following components: </p><ol>
/// <li>Identifier (-)</li>
/// <li>Text (-)</li>
/// <li>Name of Coding System (-)</li>
/// <li>Alternate Identifier (-)</li>
/// <li>Alternate Text (-)</li>
/// <li>Name of Alternate Coding System (-)</li>
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
		data[0] = new -(message,"Identifier");
		data[1] = new -(message,"Text");
		data[2] = new -(message,"Name of Coding System");
		data[3] = new -(message,"Alternate Identifier");
		data[4] = new -(message,"Alternate Text");
		data[5] = new -(message,"Name of Alternate Coding System");
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
	public - Identifier {
get{
	   - ret = null;
	   try {
	      ret = (-)this[0];
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
	public - Text {
get{
	   - ret = null;
	   try {
	      ret = (-)this[1];
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
	public - NameOfCodingSystem {
get{
	   - ret = null;
	   try {
	      ret = (-)this[2];
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
	public - AlternateIdentifier {
get{
	   - ret = null;
	   try {
	      ret = (-)this[3];
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
	public - AlternateText {
get{
	   - ret = null;
	   try {
	      ret = (-)this[4];
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
	public - NameOfAlternateCodingSystem {
get{
	   - ret = null;
	   try {
	      ret = (-)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}