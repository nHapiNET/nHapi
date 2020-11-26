using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V271.Datatype
{

///<summary>
/// <p>The HL7 PLN (Practitioner License or Other ID Number) data type.  Consists of the following components: </p><ol>
/// <li>ID Number (ST)</li>
/// <li>Type of ID Number (CWE)</li>
/// <li>State/other Qualifying Information (ST)</li>
/// <li>Expiration Date (DT)</li>
/// </ol>
///</summary>
[Serializable]
public class PLN : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a PLN.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public PLN(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a PLN.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public PLN(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"ID Number");
		data[1] = new CWE(message,"Type of ID Number");
		data[2] = new ST(message,"State/other Qualifying Information");
		data[3] = new DT(message,"Expiration Date");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element PLN composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns ID Number (component #0).  This is a convenience method that saves you from 
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
	/// Returns Type of ID Number (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE TypeOfIDNumber {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns State/other Qualifying Information (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST StateOtherQualifyingInformation {
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
	///<summary>
	/// Returns Expiration Date (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DT ExpirationDate {
get{
	   DT ret = null;
	   try {
	      ret = (DT)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}