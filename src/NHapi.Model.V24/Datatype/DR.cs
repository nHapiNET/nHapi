using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 DR (date/time range) data type.  Consists of the following components: </p><ol>
/// <li>range start date/time (TS)</li>
/// <li>range end date/time (TS)</li>
/// </ol>
///</summary>
[Serializable]
public class DR : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a DR.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public DR(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a DR.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public DR(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new TS(message,"Range start date/time");
		data[1] = new TS(message,"Range end date/time");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element DR composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns range start date/time (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TS RangeStartDateTime {
get{
	   TS ret = null;
	   try {
	      ret = (TS)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns range end date/time (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TS RangeEndDateTime {
get{
	   TS ret = null;
	   try {
	      ret = (TS)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}