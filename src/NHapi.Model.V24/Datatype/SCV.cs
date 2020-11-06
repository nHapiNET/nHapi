using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 SCV (scheduling class value pair) data type.  Consists of the following components: </p><ol>
/// <li>parameter class (IS)</li>
/// <li>parameter value (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class SCV : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a SCV.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public SCV(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a SCV.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public SCV(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new IS(message, 0,"Parameter class");
		data[1] = new ST(message,"Parameter value");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element SCV composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns parameter class (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS ParameterClass {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns parameter value (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST ParameterValue {
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
}}