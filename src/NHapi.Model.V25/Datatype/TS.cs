using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V25.Datatype
{

///<summary>
/// <p>The HL7 TS (Time Stamp) data type.  Consists of the following components: </p><ol>
/// <li>Time (TSComponentOne)</li>
/// <li>Degree of Precision (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class TS : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a TS.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public TS(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a TS.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public TS(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new TSComponentOne(message,"Time");
		data[1] = new ID(message, 529,"Degree of Precision");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element TS composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Time (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TSComponentOne Time {
get{
	   TSComponentOne ret = null;
	   try {
	      ret = (TSComponentOne)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Degree of Precision (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID DegreeOfPrecision {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}