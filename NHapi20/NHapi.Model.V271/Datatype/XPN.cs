using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V271.Datatype
{

///<summary>
/// <p>The HL7 XPN (Extended Person Name) data type.  Consists of the following components: </p><ol>
/// <li>Family Name (FN)</li>
/// <li>Given Name (ST)</li>
/// <li>Second and Further Given Names or Initials Thereof (ST)</li>
/// <li>Suffix (e.g., JR or III) (ST)</li>
/// <li>Prefix (e.g., DR) (ST)</li>
/// <li>Degree (e.g., MD) (IS)</li>
/// <li>Name Type Code (ID)</li>
/// <li>Name Representation Code (ID)</li>
/// <li>Name Context (CWE)</li>
/// <li>Name Validity Range (DR)</li>
/// <li>Name Assembly Order (ID)</li>
/// <li>Effective Date (DTM)</li>
/// <li>Expiration Date (DTM)</li>
/// <li>Professional Suffix (ST)</li>
/// <li>Called By (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class XPN : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a XPN.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public XPN(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a XPN.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public XPN(IMessage message, string description) : base(message, description){
		data = new IType[15];
		data[0] = new FN(message,"Family Name");
		data[1] = new ST(message,"Given Name");
		data[2] = new ST(message,"Second and Further Given Names or Initials Thereof");
		data[3] = new ST(message,"Suffix (e.g., JR or III)");
		data[4] = new ST(message,"Prefix (e.g., DR)");
		data[5] = new IS(message, 0,"Degree (e.g., MD)");
		data[6] = new ID(message, 200,"Name Type Code");
		data[7] = new ID(message, 465,"Name Representation Code");
		data[8] = new CWE(message,"Name Context");
		data[9] = new DR(message,"Name Validity Range");
		data[10] = new ID(message, 444,"Name Assembly Order");
		data[11] = new DTM(message,"Effective Date");
		data[12] = new DTM(message,"Expiration Date");
		data[13] = new ST(message,"Professional Suffix");
		data[14] = new ST(message,"Called By");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 15 element XPN composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Family Name (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FN FamilyName {
get{
	   FN ret = null;
	   try {
	      ret = (FN)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Given Name (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST GivenName {
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
	/// Returns Second and Further Given Names or Initials Thereof (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAndFurtherGivenNamesOrInitialsThereof {
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
	/// Returns Suffix (e.g., JR or III) (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SuffixEgJRorIII {
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
	/// Returns Prefix (e.g., DR) (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST PrefixEgDR {
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
	/// Returns Degree (e.g., MD) (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS DegreeEgMD {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Type Code (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameTypeCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Representation Code (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameRepresentationCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Context (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE NameContext {
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
	/// Returns Name Validity Range (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DR NameValidityRange {
get{
	   DR ret = null;
	   try {
	      ret = (DR)this[9];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Assembly Order (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameAssemblyOrder {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[10];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Effective Date (component #11).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM EffectiveDate {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[11];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Expiration Date (component #12).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM ExpirationDate {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[12];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Professional Suffix (component #13).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST ProfessionalSuffix {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[13];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Called By (component #14).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST CalledBy {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[14];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}