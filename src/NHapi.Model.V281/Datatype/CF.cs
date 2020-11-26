using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V281.Datatype
{

///<summary>
/// <p>The HL7 CF (Coded Element with Formatted Values) data type.  Consists of the following components: </p><ol>
/// <li>Identifier (ST)</li>
/// <li>Formatted Text (FT)</li>
/// <li>Name of Coding System (ID)</li>
/// <li>Alternate Identifier (ST)</li>
/// <li>Alternate Formatted Text (FT)</li>
/// <li>Name of Alternate Coding System (ID)</li>
/// <li>Coding System Version ID (ST)</li>
/// <li>Alternate Coding System Version ID (ST)</li>
/// <li>Original Text (ST)</li>
/// <li>Second Alternate Identifier (ST)</li>
/// <li>Second Alternate Formatted Text (FT)</li>
/// <li>Name of Second Alternate Coding System (ID)</li>
/// <li>Second Alternate Coding System Version ID (ST)</li>
/// <li>Coding System OID (ST)</li>
/// <li>Value Set OID (ST)</li>
/// <li>Value Set Version ID (DTM)</li>
/// <li>Alternate Coding System OID (ST)</li>
/// <li>Alternate Value Set OID (ST)</li>
/// <li>Alternate Value Set Version ID (DTM)</li>
/// <li>Second Alternate Coding System OID (ST)</li>
/// <li>Second Alternate Value Set OID (ST)</li>
/// <li>Second Alternate Value Set Version ID (DTM)</li>
/// </ol>
///</summary>
[Serializable]
public class CF : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CF.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CF(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CF.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CF(IMessage message, string description) : base(message, description){
		data = new IType[22];
		data[0] = new ST(message,"Identifier");
		data[1] = new FT(message,"Formatted Text");
		data[2] = new ID(message, 396,"Name of Coding System");
		data[3] = new ST(message,"Alternate Identifier");
		data[4] = new FT(message,"Alternate Formatted Text");
		data[5] = new ID(message, 396,"Name of Alternate Coding System");
		data[6] = new ST(message,"Coding System Version ID");
		data[7] = new ST(message,"Alternate Coding System Version ID");
		data[8] = new ST(message,"Original Text");
		data[9] = new ST(message,"Second Alternate Identifier");
		data[10] = new FT(message,"Second Alternate Formatted Text");
		data[11] = new ID(message, 396,"Name of Second Alternate Coding System");
		data[12] = new ST(message,"Second Alternate Coding System Version ID");
		data[13] = new ST(message,"Coding System OID");
		data[14] = new ST(message,"Value Set OID");
		data[15] = new DTM(message,"Value Set Version ID");
		data[16] = new ST(message,"Alternate Coding System OID");
		data[17] = new ST(message,"Alternate Value Set OID");
		data[18] = new DTM(message,"Alternate Value Set Version ID");
		data[19] = new ST(message,"Second Alternate Coding System OID");
		data[20] = new ST(message,"Second Alternate Value Set OID");
		data[21] = new DTM(message,"Second Alternate Value Set Version ID");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 22 element CF composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Identifier (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Identifier {
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
	/// Returns Formatted Text (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FT FormattedText {
get{
	   FT ret = null;
	   try {
	      ret = (FT)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name of Coding System (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameOfCodingSystem {
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
	/// Returns Alternate Identifier (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateIdentifier {
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
	/// Returns Alternate Formatted Text (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FT AlternateFormattedText {
get{
	   FT ret = null;
	   try {
	      ret = (FT)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name of Alternate Coding System (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameOfAlternateCodingSystem {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Coding System Version ID (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST CodingSystemVersionID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Coding System Version ID (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateCodingSystemVersionID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Original Text (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OriginalText {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[8];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Second Alternate Identifier (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAlternateIdentifier {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[9];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Second Alternate Formatted Text (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FT SecondAlternateFormattedText {
get{
	   FT ret = null;
	   try {
	      ret = (FT)this[10];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name of Second Alternate Coding System (component #11).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameOfSecondAlternateCodingSystem {
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
	/// Returns Second Alternate Coding System Version ID (component #12).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAlternateCodingSystemVersionID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[12];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Coding System OID (component #13).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST CodingSystemOID {
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
	/// Returns Value Set OID (component #14).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST ValueSetOID {
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
	///<summary>
	/// Returns Value Set Version ID (component #15).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM ValueSetVersionID {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[15];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Coding System OID (component #16).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateCodingSystemOID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[16];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Value Set OID (component #17).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateValueSetOID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[17];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Value Set Version ID (component #18).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM AlternateValueSetVersionID {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[18];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Second Alternate Coding System OID (component #19).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAlternateCodingSystemOID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[19];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Second Alternate Value Set OID (component #20).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAlternateValueSetOID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[20];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Second Alternate Value Set Version ID (component #21).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM SecondAlternateValueSetVersionID {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[21];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}