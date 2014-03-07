using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23UCH.Datatype
{

///<summary>
/// <p>The HL7 CM_ELD (error) data type.  Consists of the following components: </p><ol>
/// <li>segment ID (ST)</li>
/// <li>sequence (NM)</li>
/// <li>field position (NM)</li>
/// <li>code identifying error (CE)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_ELD : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_ELD.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_ELD(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_ELD.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_ELD(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"Segment ID");
		data[1] = new NM(message,"Sequence");
		data[2] = new NM(message,"Field position");
		data[3] = new CE(message,"Code identifying error");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element CM_ELD composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns segment ID (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SegmentID {
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
	/// Returns sequence (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Sequence {
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
	/// Returns field position (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM FieldPosition {
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
	/// Returns code identifying error (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE CodeIdentifyingError {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}