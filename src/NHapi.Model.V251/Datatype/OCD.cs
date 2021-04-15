using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V251.Datatype
{

///<summary>
/// <p>The HL7 OCD (Occurrence Code and Date) data type.  Consists of the following components: </p><ol>
/// <li>Occurrence Code (CNE)</li>
/// <li>Occurrence Date (DT)</li>
/// </ol>
///</summary>
[Serializable]
public class OCD : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a OCD.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public OCD(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a OCD.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public OCD(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new CNE(message,"Occurrence Code");
		data[1] = new DT(message,"Occurrence Date");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element OCD composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Occurrence Code (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CNE OccurrenceCode {
get{
	   CNE ret = null;
	   try {
	      ret = (CNE)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Occurrence Date (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DT OccurrenceDate {
get{
	   DT ret = null;
	   try {
	      ret = (DT)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}