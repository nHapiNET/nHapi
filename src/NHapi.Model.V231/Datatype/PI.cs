using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V231.Datatype
{

///<summary>
/// <p>The HL7 PI (person identifier) data type.  Consists of the following components: </p><ol>
/// <li>ID number (ST) (ST)</li>
/// <li>type of ID number (IS) (IS)</li>
/// <li>other qualifying info (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class PI : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a PI.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public PI(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a PI.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public PI(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new ST(message,"ID number (ST)");
		data[1] = new IS(message, 0,"Type of ID number (IS)");
		data[2] = new ST(message,"Other qualifying info");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element PI composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns ID number (ST) (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST IDNumber {
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
	/// Returns type of ID number (IS) (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS TypeOfIDNumber {
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
	/// Returns other qualifying info (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OtherQualifyingInfo {
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