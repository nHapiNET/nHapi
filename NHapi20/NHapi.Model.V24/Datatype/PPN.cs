using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 PPN (performing person time stamp) data type.  Consists of the following components: </p><ol>
/// <li>ID number (ST) (ST)</li>
/// <li>family name (FN)</li>
/// <li>given name (ST)</li>
/// <li>second and further given names or initials thereof (ST)</li>
/// <li>suffix (e.g., JR or III) (ST)</li>
/// <li>prefix (e.g., DR) (ST)</li>
/// <li>degree (e.g., MD) (IS)</li>
/// <li>source table (IS)</li>
/// <li>assigning authority (HD)</li>
/// <li>name type code (ID)</li>
/// <li>identifier check digit (ST)</li>
/// <li>code identifying the check digit scheme employed (ID)</li>
/// <li>identifier type code (IS) (IS)</li>
/// <li>assigning facility (HD)</li>
/// <li>Date/Time Action Performed (TS)</li>
/// <li>Name Representation code (ID)</li>
/// <li>name context (CE)</li>
/// <li>name validity range (DR)</li>
/// <li>name assembly order (ID)</li>
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
		data = new IType[19];
		data[0] = new ST(message,"ID number (ST)");
		data[1] = new FN(message,"Family name");
		data[2] = new ST(message,"Given name");
		data[3] = new ST(message,"Second and further given names or initials thereof");
		data[4] = new ST(message,"Suffix (e.g., JR or III)");
		data[5] = new ST(message,"Prefix (e.g., DR)");
		data[6] = new IS(message, 0,"Degree (e.g., MD)");
		data[7] = new IS(message, 0,"Source table");
		data[8] = new HD(message,"Assigning authority");
		data[9] = new ID(message, 0,"Name type code");
		data[10] = new ST(message,"Identifier check digit");
		data[11] = new ID(message, 0,"Code identifying the check digit scheme employed");
		data[12] = new IS(message, 0,"Identifier type code (IS)");
		data[13] = new HD(message,"Assigning facility");
		data[14] = new TS(message,"Date/Time Action Performed");
		data[15] = new ID(message, 0,"Name Representation code");
		data[16] = new CE(message,"Name context");
		data[17] = new DR(message,"Name validity range");
		data[18] = new ID(message, 0,"Name assembly order");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 19 element PPN composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns ID number (ST) (component #0).  This is a convenience method that saves you from 
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
	/// Returns family name (component #1).  This is a convenience method that saves you from 
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
	/// Returns given name (component #2).  This is a convenience method that saves you from 
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
	/// Returns second and further given names or initials thereof (component #3).  This is a convenience method that saves you from 
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
	/// Returns suffix (e.g., JR or III) (component #4).  This is a convenience method that saves you from 
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
	/// Returns prefix (e.g., DR) (component #5).  This is a convenience method that saves you from 
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
	/// Returns degree (e.g., MD) (component #6).  This is a convenience method that saves you from 
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
	/// Returns source table (component #7).  This is a convenience method that saves you from 
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
	/// Returns assigning authority (component #8).  This is a convenience method that saves you from 
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
	/// Returns name type code (component #9).  This is a convenience method that saves you from 
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
	/// Returns identifier check digit (component #10).  This is a convenience method that saves you from 
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
	/// Returns code identifying the check digit scheme employed (component #11).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID CodeIdentifyingTheCheckDigitSchemeEmployed {
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
	/// Returns identifier type code (IS) (component #12).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS IdentifierTypeCode {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[12];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns assigning facility (component #13).  This is a convenience method that saves you from 
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
	/// Returns Name Representation code (component #15).  This is a convenience method that saves you from 
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
	/// Returns name context (component #16).  This is a convenience method that saves you from 
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
	/// Returns name validity range (component #17).  This is a convenience method that saves you from 
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
	/// Returns name assembly order (component #18).  This is a convenience method that saves you from 
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
}}