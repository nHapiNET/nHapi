using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V271.Datatype
{

///<summary>
/// <p>The HL7 CSU (Channel Sensitivity and Units) data type.  Consists of the following components: </p><ol>
/// <li>Channel Sensitivity (NM)</li>
/// <li>Unit of Measure Identifier (ST)</li>
/// <li>Unit of Measure Description (ST)</li>
/// <li>Unit of Measure Coding System (ID)</li>
/// <li>Alternate Unit of Measure Identifier (ST)</li>
/// <li>Alternate Unit of Measure Description (ST)</li>
/// <li>Alternate Unit of Measure Coding System (ID)</li>
/// <li>Unit of Measure Coding System Version ID (ST)</li>
/// <li>Alternate Unit of Measure Coding System Version ID (ST)</li>
/// <li>Original Text (ST)</li>
/// <li>Second Alternate Unit of Measure Identifier (ST)</li>
/// <li>Second Alternate Unit of Measure Text (ST)</li>
/// <li>Name of Second Alternate Unit of Measure Coding Sy (ID)</li>
/// <li>Second Alternate Unit of Measure Coding System Ver (ST)</li>
/// <li>Unit of Measure Coding System OID (ST)</li>
/// <li>Unit of Measure Value Set OID (ST)</li>
/// <li>Unit of Measure Value Set Version ID (DTM)</li>
/// <li>Alternate Unit of Measure Coding System OID (ST)</li>
/// <li>Alternate Unit of Measure Value Set OID (ST)</li>
/// <li>Alternate Unit of Measure Value Set Version ID (DTM)</li>
/// <li>Alternate Unit of Measure Coding System OID (ST)</li>
/// <li>Alternate Unit of Measure Value Set OID (ST)</li>
/// <li>Alternate Unit of Measure Value Set Version ID (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class CSU : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CSU.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CSU(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CSU.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CSU(IMessage message, string description) : base(message, description){
		data = new IType[23];
		data[0] = new NM(message,"Channel Sensitivity");
		data[1] = new ST(message,"Unit of Measure Identifier");
		data[2] = new ST(message,"Unit of Measure Description");
		data[3] = new ID(message, 396,"Unit of Measure Coding System");
		data[4] = new ST(message,"Alternate Unit of Measure Identifier");
		data[5] = new ST(message,"Alternate Unit of Measure Description");
		data[6] = new ID(message, 396,"Alternate Unit of Measure Coding System");
		data[7] = new ST(message,"Unit of Measure Coding System Version ID");
		data[8] = new ST(message,"Alternate Unit of Measure Coding System Version ID");
		data[9] = new ST(message,"Original Text");
		data[10] = new ST(message,"Second Alternate Unit of Measure Identifier");
		data[11] = new ST(message,"Second Alternate Unit of Measure Text");
		data[12] = new ID(message, 396,"Name of Second Alternate Unit of Measure Coding Sy");
		data[13] = new ST(message,"Second Alternate Unit of Measure Coding System Ver");
		data[14] = new ST(message,"Unit of Measure Coding System OID");
		data[15] = new ST(message,"Unit of Measure Value Set OID");
		data[16] = new DTM(message,"Unit of Measure Value Set Version ID");
		data[17] = new ST(message,"Alternate Unit of Measure Coding System OID");
		data[18] = new ST(message,"Alternate Unit of Measure Value Set OID");
		data[19] = new DTM(message,"Alternate Unit of Measure Value Set Version ID");
		data[20] = new ST(message,"Alternate Unit of Measure Coding System OID");
		data[21] = new ST(message,"Alternate Unit of Measure Value Set OID");
		data[22] = new ST(message,"Alternate Unit of Measure Value Set Version ID");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 23 element CSU composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Channel Sensitivity (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM ChannelSensitivity {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Unit of Measure Identifier (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UnitOfMeasureIdentifier {
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
	/// Returns Unit of Measure Description (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UnitOfMeasureDescription {
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
	/// Returns Unit of Measure Coding System (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID UnitOfMeasureCodingSystem {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Unit of Measure Identifier (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureIdentifier {
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
	/// Returns Alternate Unit of Measure Description (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureDescription {
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
	/// Returns Alternate Unit of Measure Coding System (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID AlternateUnitOfMeasureCodingSystem {
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
	/// Returns Unit of Measure Coding System Version ID (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UnitOfMeasureCodingSystemVersionID {
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
	/// Returns Alternate Unit of Measure Coding System Version ID (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureCodingSystemVersionID {
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
	/// Returns Original Text (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OriginalText {
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
	/// Returns Second Alternate Unit of Measure Identifier (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAlternateUnitOfMeasureIdentifier {
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
	/// Returns Second Alternate Unit of Measure Text (component #11).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAlternateUnitOfMeasureText {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[11];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name of Second Alternate Unit of Measure Coding Sy (component #12).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameOfSecondAlternateUnitOfMeasureCodingSy {
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
	/// Returns Second Alternate Unit of Measure Coding System Ver (component #13).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAlternateUnitOfMeasureCodingSystemVer {
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
	/// Returns Unit of Measure Coding System OID (component #14).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UnitOfMeasureCodingSystemOID {
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
	/// Returns Unit of Measure Value Set OID (component #15).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UnitOfMeasureValueSetOID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[15];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Unit of Measure Value Set Version ID (component #16).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM UnitOfMeasureValueSetVersionID {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[16];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Unit of Measure Coding System OID (component #17).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureCodingSystemOID {
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
	/// Returns Alternate Unit of Measure Value Set OID (component #18).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureValueSetOID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[18];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Unit of Measure Value Set Version ID (component #19).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM AlternateUnitOfMeasureValueSetVersionID {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[19];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Alternate Unit of Measure Coding System OID (component #20).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureCodingSystemOID {
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
	/// Returns Alternate Unit of Measure Value Set OID (component #21).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureValueSetOID {
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
	/// Returns Alternate Unit of Measure Value Set Version ID (component #22).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateUnitOfMeasureValueSetVersionID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[22];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}