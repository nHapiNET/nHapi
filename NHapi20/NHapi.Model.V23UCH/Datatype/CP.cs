using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23UCH.Datatype
{

///<summary>
/// <p>The HL7 CP (Composite Price (2.8.8)) data type.  Consists of the following components: </p><ol>
/// <li>price (MO)</li>
/// <li>price type (ID)</li>
/// <li>from value (NM)</li>
/// <li>to value (NM)</li>
/// <li>range units (CE)</li>
/// <li>range type (ID)</li>
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
		data[1] = new ID(message, 0,"Price type");
		data[2] = new NM(message,"From value");
		data[3] = new NM(message,"To value");
		data[4] = new CE(message,"Range units");
		data[5] = new ID(message, 0,"Range type");
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
	/// Returns price (component #0).  This is a convenience method that saves you from 
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
	/// Returns price type (component #1).  This is a convenience method that saves you from 
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
	/// Returns from value (component #2).  This is a convenience method that saves you from 
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
	/// Returns to value (component #3).  This is a convenience method that saves you from 
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
	/// Returns range units (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE RangeUnits {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns range type (component #5).  This is a convenience method that saves you from 
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