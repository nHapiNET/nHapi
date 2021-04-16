using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V25.Datatype
{

///<summary>
/// <p>The HL7 CX (Extended Composite ID with Check Digit) data type.  Consists of the following components: </p><ol>
/// <li>ID Number (ST)</li>
/// <li>Check Digit (ST)</li>
/// <li>Check Digit Scheme (ID)</li>
/// <li>Assigning Authority (HD)</li>
/// <li>Identifier Type Code (ID)</li>
/// <li>Assigning Facility (HD)</li>
/// <li>Effective Date (DT)</li>
/// <li>Expiration Date (DT)</li>
/// <li>Assigning Jurisdiction (CWE)</li>
/// <li>Assigning Agency or Department (CWE)</li>
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
		data = new IType[10];
		data[0] = new ST(message,"ID Number");
		data[1] = new ST(message,"Check Digit");
		data[2] = new ID(message, 61,"Check Digit Scheme");
		data[3] = new HD(message,"Assigning Authority");
		data[4] = new ID(message, 203,"Identifier Type Code");
		data[5] = new HD(message,"Assigning Facility");
		data[6] = new DT(message,"Effective Date");
		data[7] = new DT(message,"Expiration Date");
		data[8] = new CWE(message,"Assigning Jurisdiction");
		data[9] = new CWE(message,"Assigning Agency or Department");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 10 element CX composite"); 
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
	/// Returns Check Digit (component #1).  This is a convenience method that saves you from 
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
	/// Returns Check Digit Scheme (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID CheckDigitScheme {
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
	/// Returns Assigning Authority (component #3).  This is a convenience method that saves you from 
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
	/// Returns Identifier Type Code (component #4).  This is a convenience method that saves you from 
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
	/// Returns Assigning Facility (component #5).  This is a convenience method that saves you from 
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
	/// Returns Effective Date (component #6).  This is a convenience method that saves you from 
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
	/// Returns Expiration Date (component #7).  This is a convenience method that saves you from 
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
	///<summary>
	/// Returns Assigning Jurisdiction (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE AssigningJurisdiction {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[8];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Assigning Agency or Department (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE AssigningAgencyOrDepartment {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[9];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}