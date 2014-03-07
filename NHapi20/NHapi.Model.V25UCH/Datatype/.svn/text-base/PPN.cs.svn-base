using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V25UCH.Datatype
{

///<summary>
/// <p>The HL7 PPN (Performing Person Time Stamp) data type.  Consists of the following components: </p><ol>
/// <li>ID Number (ST)</li>
/// <li>Family Name (FN)</li>
/// <li>Given Name (ST)</li>
/// <li>Second and Further Given Names or Initials Thereof (ST)</li>
/// <li>Suffix (e.g., JR or III) (ST)</li>
/// <li>Prefix (e.g., DR) (ST)</li>
/// <li>Degree (e.g., MD) (IS)</li>
/// <li>Source Table (IS)</li>
/// <li>Assigning Authority (HD)</li>
/// <li>Name Type Code (ID)</li>
/// <li>Identifier Check Digit (ST)</li>
/// <li>Check Digit Scheme (ID)</li>
/// <li>Identifier Type Code (ID)</li>
/// <li>Assigning Facility (HD)</li>
/// <li>Date/Time Action Performed (TS)</li>
/// <li>Name Representation Code (ID)</li>
/// <li>Name Context (CE)</li>
/// <li>Name Validity Range (DR)</li>
/// <li>Name Assembly Order (ID)</li>
/// <li>Effective Date (TS)</li>
/// <li>Expiration Date (TS)</li>
/// <li>Professional Suffix (ST)</li>
/// <li>Assigning Jurisdiction (CWE)</li>
/// <li>Assigning Agency or Department (CWE)</li>
/// </ol>
///</summary>
[Serializable]
public class PPN : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a PPN.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public PPN(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a PPN.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public PPN(IMessage message, string description) : base(message, description){
		data = new IType[24];
		data[0] = new ST(message,"ID Number");
		data[1] = new FN(message,"Family Name");
		data[2] = new ST(message,"Given Name");
		data[3] = new ST(message,"Second and Further Given Names or Initials Thereof");
		data[4] = new ST(message,"Suffix (e.g., JR or III)");
		data[5] = new ST(message,"Prefix (e.g., DR)");
		data[6] = new IS(message, 360,"Degree (e.g., MD)");
		data[7] = new IS(message, 297,"Source Table");
		data[8] = new HD(message,"Assigning Authority");
		data[9] = new ID(message, 200,"Name Type Code");
		data[10] = new ST(message,"Identifier Check Digit");
		data[11] = new ID(message, 61,"Check Digit Scheme");
		data[12] = new ID(message, 203,"Identifier Type Code");
		data[13] = new HD(message,"Assigning Facility");
		data[14] = new TS(message,"Date/Time Action Performed");
		data[15] = new ID(message, 465,"Name Representation Code");
		data[16] = new CE(message,"Name Context");
		data[17] = new DR(message,"Name Validity Range");
		data[18] = new ID(message, 444,"Name Assembly Order");
		data[19] = new TS(message,"Effective Date");
		data[20] = new TS(message,"Expiration Date");
		data[21] = new ST(message,"Professional Suffix");
		data[22] = new CWE(message,"Assigning Jurisdiction");
		data[23] = new CWE(message,"Assigning Agency or Department");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 24 element PPN composite"); 
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
	/// Returns Family Name (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FN FamilyName {
get{
	   FN ret = null;
	   try {
	      ret = (FN)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Given Name (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST GivenName {
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
	/// Returns Second and Further Given Names or Initials Thereof (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAndFurtherGivenNamesOrInitialsThereof {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Suffix (e.g., JR or III) (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SuffixEgJRorIII {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Prefix (e.g., DR) (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST PrefixEgDR {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Degree (e.g., MD) (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS DegreeEgMD {
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
	/// Returns Source Table (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS SourceTable {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Assigning Authority (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD AssigningAuthority {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[8];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Type Code (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameTypeCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[9];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Identifier Check Digit (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST IdentifierCheckDigit {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[10];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Check Digit Scheme (component #11).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID CheckDigitScheme {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[11];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Identifier Type Code (component #12).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID IdentifierTypeCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[12];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Assigning Facility (component #13).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD AssigningFacility {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[13];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Date/Time Action Performed (component #14).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TS DateTimeActionPerformed {
get{
	   TS ret = null;
	   try {
	      ret = (TS)this[14];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Representation Code (component #15).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameRepresentationCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[15];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Context (component #16).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE NameContext {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[16];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Validity Range (component #17).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DR NameValidityRange {
get{
	   DR ret = null;
	   try {
	      ret = (DR)this[17];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Assembly Order (component #18).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameAssemblyOrder {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[18];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Effective Date (component #19).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TS EffectiveDate {
get{
	   TS ret = null;
	   try {
	      ret = (TS)this[19];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Expiration Date (component #20).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TS ExpirationDate {
get{
	   TS ret = null;
	   try {
	      ret = (TS)this[20];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Professional Suffix (component #21).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST ProfessionalSuffix {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[21];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Assigning Jurisdiction (component #22).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE AssigningJurisdiction {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[22];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Assigning Agency or Department (component #23).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE AssigningAgencyOrDepartment {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[23];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}