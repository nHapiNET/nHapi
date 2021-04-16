using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23.Datatype
{

///<summary>
/// <p>The HL7 MA (multiplexed array) data type.  Consists of the following components: </p><ol>
/// <li>sample 1 from channel 1 (NM)</li>
/// <li>sample 1 from channel 2 (NM)</li>
/// <li>sample 1 from channel 3 (NM)</li>
/// <li>sample 2 from channel 1 (NM)</li>
/// <li>sample 2 from channel 2 (NM)</li>
/// <li>sample 2 from channel 3 (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class MA : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a MA.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public MA(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a MA.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public MA(IMessage message, string description) : base(message, description){
		data = new IType[6];
		data[0] = new NM(message,"Sample 1 from channel 1");
		data[1] = new NM(message,"Sample 1 from channel 2");
		data[2] = new NM(message,"Sample 1 from channel 3");
		data[3] = new NM(message,"Sample 2 from channel 1");
		data[4] = new NM(message,"Sample 2 from channel 2");
		data[5] = new NM(message,"Sample 2 from channel 3");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 6 element MA composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns sample 1 from channel 1 (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Sample1FromChannel1 {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sample 1 from channel 2 (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Sample1FromChannel2 {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sample 1 from channel 3 (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Sample1FromChannel3 {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sample 2 from channel 1 (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Sample2FromChannel1 {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sample 2 from channel 2 (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Sample2FromChannel2 {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sample 2 from channel 3 (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Sample2FromChannel3 {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}