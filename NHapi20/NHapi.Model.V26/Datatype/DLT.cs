using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V26.Datatype
{

///<summary>
/// <p>The HL7 DLT (Delta) data type.  Consists of the following components: </p><ol>
/// <li>Normal Range (NR)</li>
/// <li>Numeric Threshold (NM)</li>
/// <li>Change Computation (ID)</li>
/// <li>Days Retained (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class DLT : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a DLT.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public DLT(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a DLT.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public DLT(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new NR(message,"Normal Range");
		data[1] = new NM(message,"Numeric Threshold");
		data[2] = new ID(message, 523,"Change Computation");
		data[3] = new NM(message,"Days Retained");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element DLT composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Normal Range (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NR NormalRange {
get{
	   NR ret = null;
	   try {
	      ret = (NR)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Numeric Threshold (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM NumericThreshold {
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
	/// Returns Change Computation (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID ChangeComputation {
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
	/// Returns Days Retained (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM DaysRetained {
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
}}