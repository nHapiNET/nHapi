using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 CX (extended composite ID with check digit) data type.  Consists of the following components: </p><ol>
/// <li>ID (ST)</li>
/// <li>check digit (ST) (ST)</li>
/// <li>code identifying the check digit scheme employed (ID)</li>
/// <li>assigning authority (HD)</li>
/// <li>identifier type code (ID) (ID)</li>
/// <li>assigning facility (HD)</li>
/// <li>effective date (DT) (DT)</li>
/// <li>expiration date (DT)</li>
/// </ol>
///</summary>
[Serializable]
public class CX : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CX.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CX(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CX.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CX(IMessage message, string description) : base(message, description){
		data = new IType[8];
		data[0] = new ST(message,"ID");
		data[1] = new ST(message,"Check digit (ST)");
		data[2] = new ID(message, 0,"Code identifying the check digit scheme employed");
		data[3] = new HD(message,"Assigning authority");
		data[4] = new ID(message, 203,"Identifier type code (ID)");
		data[5] = new HD(message,"Assigning facility");
		data[6] = new DT(message,"Effective date (DT)");
		data[7] = new DT(message,"Expiration date");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 8 element CX composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns ID (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST ID {
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
	/// Returns check digit (ST) (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST CheckDigit {
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
	///<summary>
	/// Returns code identifying the check digit scheme employed (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID CodeIdentifyingTheCheckDigitSchemeEmployed {
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
	/// Returns assigning authority (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD AssigningAuthority {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns identifier type code (ID) (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID IdentifierTypeCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns assigning facility (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD AssigningFacility {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns effective date (DT) (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DT EffectiveDate {
get{
	   DT ret = null;
	   try {
	      ret = (DT)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns expiration date (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DT ExpirationDate {
get{
	   DT ret = null;
	   try {
	      ret = (DT)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}