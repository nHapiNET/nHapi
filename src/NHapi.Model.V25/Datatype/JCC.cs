using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V25.Datatype
{

///<summary>
/// <p>The HL7 JCC (Job Code/Class) data type.  Consists of the following components: </p><ol>
/// <li>Job Code (IS)</li>
/// <li>Job Class (IS)</li>
/// <li>Job Description Text (TX)</li>
/// </ol>
///</summary>
[Serializable]
public class JCC : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a JCC.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public JCC(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a JCC.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public JCC(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new IS(message, 327,"Job Code");
		data[1] = new IS(message, 328,"Job Class");
		data[2] = new TX(message,"Job Description Text");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element JCC composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Job Code (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS JobCode {
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
	/// Returns Job Class (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS JobClass {
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
	/// Returns Job Description Text (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TX JobDescriptionText {
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