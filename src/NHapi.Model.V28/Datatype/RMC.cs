using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V28.Datatype
{

///<summary>
/// <p>The HL7 RMC (Room Coverage) data type.  Consists of the following components: </p><ol>
/// <li>Room Type (CWE)</li>
/// <li>Amount Type (CWE)</li>
/// <li>Coverage Amount (RMC)</li>
/// <li>Money or Percentage (MOP)</li>
/// </ol>
///</summary>
[Serializable]
public class RMC : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a RMC.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public RMC(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a RMC.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public RMC(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new CWE(message,"Room Type");
		data[1] = new CWE(message,"Amount Type");
        	// Withdrawn as of v2.7
        	data[2] = new ST(message,"Coverage Amount");
		data[3] = new MOP(message,"Money or Percentage");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element RMC composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Room Type (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE RoomType {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Amount Type (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CWE AmountType {
get{
	   CWE ret = null;
	   try {
	      ret = (CWE)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Coverage Amount (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public RMC CoverageAmount {
get{
	   RMC ret = null;
	   try {
	      ret = (RMC)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Money or Percentage (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public MOP MoneyOrPercentage {
get{
	   MOP ret = null;
	   try {
	      ret = (MOP)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}