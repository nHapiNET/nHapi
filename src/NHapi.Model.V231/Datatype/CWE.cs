using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V231.Datatype
{

///<summary>
/// <p>The HL7 CWE (coded with exceptions) data type.  Consists of the following components: </p><ol>
/// <li>identifier (ST)</li>
/// <li>text (ST)</li>
/// <li>name of coding system (ST)</li>
/// <li>alternate identifier (ST)</li>
/// <li>alternate text (ST)</li>
/// <li>name of alternate coding system (ST)</li>
/// <li>coding system version ID (ST)</li>
/// <li>alternate coding system version ID (ST)</li>
/// <li>original text (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class CWE : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CWE.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CWE(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CWE.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CWE(IMessage message, string description) : base(message, description){
		data = new IType[9];
		data[0] = new ST(message,"Identifier");
		data[1] = new ST(message,"Text");
		data[2] = new ST(message,"Name of coding system");
		data[3] = new ST(message,"Alternate identifier");
		data[4] = new ST(message,"Alternate text");
		data[5] = new ST(message,"Name of alternate coding system");
		data[6] = new ST(message,"Coding system version ID");
		data[7] = new ST(message,"Alternate coding system version ID");
		data[8] = new ST(message,"Original text");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 9 element CWE composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns identifier (component #0).  This is a convenience method that saves you from 
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
	/// Returns text (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Text {
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
	/// Returns name of coding system (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST NameOfCodingSystem {
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
	/// Returns alternate identifier (component #3).  This is a convenience method that saves you from 
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
	/// Returns alternate text (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST AlternateText {
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
	/// Returns name of alternate coding system (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST NameOfAlternateCodingSystem {
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
	/// Returns coding system version ID (component #6).  This is a convenience method that saves you from 
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
	/// Returns alternate coding system version ID (component #7).  This is a convenience method that saves you from 
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
	/// Returns original text (component #8).  This is a convenience method that saves you from 
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
}}