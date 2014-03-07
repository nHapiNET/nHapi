using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23UCH.Datatype
{

///<summary>
/// <p>The HL7 CM_MDV (minimum/maximum data values) data type.  Consists of the following components: </p><ol>
/// <li>Minimum Value (NM)</li>
/// <li>Maximum Value (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_MDV : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_MDV.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_MDV(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_MDV.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_MDV(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new NM(message,"Minimum Value");
		data[1] = new NM(message,"Maximum Value");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element CM_MDV composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Minimum Value (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM MinimumValue {
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
	/// Returns Maximum Value (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM MaximumValue {
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
}}