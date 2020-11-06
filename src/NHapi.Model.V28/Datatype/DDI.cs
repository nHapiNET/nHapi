using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V28.Datatype
{

///<summary>
/// <p>The HL7 DDI (Daily Deductible Information) data type.  Consists of the following components: </p><ol>
/// <li>Delay Days (NM)</li>
/// <li>Monetary Amount (MO)</li>
/// <li>Number of Days (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class DDI : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a DDI.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public DDI(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a DDI.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public DDI(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new NM(message,"Delay Days");
		data[1] = new MO(message,"Monetary Amount");
		data[2] = new NM(message,"Number of Days");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element DDI composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Delay Days (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM DelayDays {
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
	/// Returns Monetary Amount (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public MO MonetaryAmount {
get{
	   MO ret = null;
	   try {
	      ret = (MO)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Number of Days (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM NumberOfDays {
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
}}