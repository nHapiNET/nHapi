using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V281.Datatype
{

///<summary>
/// <p>The HL7 CP (Composite Price) data type.  Consists of the following components: </p><ol>
/// <li>Price (MO)</li>
/// <li>Price Type (ID)</li>
/// <li>From Value (NM)</li>
/// <li>To Value (NM)</li>
/// <li>Range Units (CWE)</li>
/// <li>Range Type (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class CP : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CP.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CP(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CP.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CP(IMessage message, string description) : base(message, description){
		data = new IType[6];
		data[0] = new MO(message,"Price");
		data[1] = new ID(message, 205,"Price Type");
		data[2] = new NM(message,"From Value");
		data[3] = new NM(message,"To Value");
		data[4] = new CWE(message,"Range Units");
		data[5] = new ID(message, 298,"Range Type");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 6 element CP composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Price (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public MO Price {
get{
	   MO ret = null;
	   try {
	      ret = (MO)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Price Type (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID PriceType {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns From Value (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM FromValue {
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
	/// Returns To Value (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM ToValue {
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
	/// Returns Range Units (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE RangeUnits {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Range Type (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID RangeType {
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
}}