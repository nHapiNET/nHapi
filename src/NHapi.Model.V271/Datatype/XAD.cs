using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V271.Datatype
{

///<summary>
/// <p>The HL7 XAD (Extended Address) data type.  Consists of the following components: </p><ol>
/// <li>Street Address (SAD)</li>
/// <li>Other Designation (ST)</li>
/// <li>City (ST)</li>
/// <li>State or Province (ST)</li>
/// <li>Zip or Postal Code (ST)</li>
/// <li>Country (ID)</li>
/// <li>Address Type (ID)</li>
/// <li>Other Geographic Designation (ST)</li>
/// <li>County/Parish Code (CWE)</li>
/// <li>Census Tract (CWE)</li>
/// <li>Address Representation Code (ID)</li>
/// <li>Address Validity Range (ST)</li>
/// <li>Effective Date (DTM)</li>
/// <li>Expiration Date (DTM)</li>
/// <li>Expiration Reason (CWE)</li>
/// <li>Temporary Indicator (ID)</li>
/// <li>Bad Address Indicator (ID)</li>
/// <li>Address Usage (ID)</li>
/// <li>Addressee (ST)</li>
/// <li>Comment (ST)</li>
/// <li>Preference Order (NM)</li>
/// <li>Protection Code (CWE)</li>
/// <li>Address Identifier (EI)</li>
/// </ol>
///</summary>
[Serializable]
public class XAD : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a XAD.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public XAD(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a XAD.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public XAD(IMessage message, string description) : base(message, description){
		data = new IType[23];
		data[0] = new SAD(message,"Street Address");
		data[1] = new ST(message,"Other Designation");
		data[2] = new ST(message,"City");
		data[3] = new ST(message,"State or Province");
		data[4] = new ST(message,"Zip or Postal Code");
		data[5] = new ID(message, 399,"Country");
		data[6] = new ID(message, 190,"Address Type");
		data[7] = new ST(message,"Other Geographic Designation");
		data[8] = new CWE(message,"County/Parish Code");
		data[9] = new CWE(message,"Census Tract");
		data[10] = new ID(message, 465,"Address Representation Code");
		data[11] = new ST(message,"Address Validity Range");
		data[12] = new DTM(message,"Effective Date");
		data[13] = new DTM(message,"Expiration Date");
		data[14] = new CWE(message,"Expiration Reason");
		data[15] = new ID(message, 136,"Temporary Indicator");
		data[16] = new ID(message, 136,"Bad Address Indicator");
		data[17] = new ID(message, 617,"Address Usage");
		data[18] = new ST(message,"Addressee");
		data[19] = new ST(message,"Comment");
		data[20] = new NM(message,"Preference Order");
		data[21] = new CWE(message,"Protection Code");
		data[22] = new EI(message,"Address Identifier");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 23 element XAD composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Street Address (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public SAD StreetAddress {
get{
	   SAD ret = null;
	   try {
	      ret = (SAD)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Other Designation (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OtherDesignation {
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
	/// Returns City (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST City {
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
	/// Returns State or Province (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST StateOrProvince {
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
	/// Returns Zip or Postal Code (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST ZipOrPostalCode {
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
	/// Returns Country (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Country {
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
	/// Returns Address Type (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID AddressType {
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
	/// Returns Other Geographic Designation (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OtherGeographicDesignation {
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
	/// Returns County/Parish Code (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE CountyParishCode {
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
	/// Returns Census Tract (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE CensusTract {
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
	///<summary>
	/// Returns Address Representation Code (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID AddressRepresentationCode {
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
	/// Returns Address Validity Range (component #11).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AddressValidityRange {
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
	/// Returns Effective Date (component #12).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM EffectiveDate {
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
	/// Returns Expiration Date (component #13).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DTM ExpirationDate {
get{
	   DTM ret = null;
	   try {
	      ret = (DTM)this[13];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Expiration Reason (component #14).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE ExpirationReason {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[14];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Temporary Indicator (component #15).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID TemporaryIndicator {
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
	/// Returns Bad Address Indicator (component #16).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID BadAddressIndicator {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[16];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Address Usage (component #17).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID AddressUsage {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[17];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Addressee (component #18).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Addressee {
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
	/// Returns Comment (component #19).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Comment {
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
	/// Returns Preference Order (component #20).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM PreferenceOrder {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[20];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Protection Code (component #21).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE ProtectionCode {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[21];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Address Identifier (component #22).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public EI AddressIdentifier {
get{
	   EI ret = null;
	   try {
	      ret = (EI)this[22];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}