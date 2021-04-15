using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 XON (extended composite name and identification number for organizations) data type.  Consists of the following components: </p><ol>
/// <li>organization name (ST)</li>
/// <li>organization name type code (IS)</li>
/// <li>ID number (NM) (NM)</li>
/// <li>check digit (NM) (NM)</li>
/// <li>code identifying the check digit scheme employed (ID)</li>
/// <li>assigning authority (HD)</li>
/// <li>identifier type code (IS) (IS)</li>
/// <li>assigning facility ID (HD)</li>
/// <li>Name Representation code (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class XON : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a XON.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public XON(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a XON.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public XON(IMessage message, string description) : base(message, description){
		data = new IType[9];
		data[0] = new ST(message,"Organization name");
		data[1] = new IS(message, 0,"Organization name type code");
		data[2] = new NM(message,"ID number (NM)");
		data[3] = new NM(message,"Check digit (NM)");
		data[4] = new ID(message, 0,"Code identifying the check digit scheme employed");
		data[5] = new HD(message,"Assigning authority");
		data[6] = new IS(message, 0,"Identifier type code (IS)");
		data[7] = new HD(message,"Assigning facility ID");
		data[8] = new ID(message, 0,"Name Representation code");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 9 element XON composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns organization name (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OrganizationName {
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
	/// Returns organization name type code (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS OrganizationNameTypeCode {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns ID number (NM) (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM IDNumber {
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
	/// Returns check digit (NM) (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM CheckDigit {
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
	/// Returns code identifying the check digit scheme employed (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID CodeIdentifyingTheCheckDigitSchemeEmployed {
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
	/// Returns assigning authority (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD AssigningAuthority {
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
	/// Returns identifier type code (IS) (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS IdentifierTypeCode {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns assigning facility ID (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD AssigningFacilityID {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Representation code (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameRepresentationCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[8];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}