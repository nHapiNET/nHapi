using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V231.Datatype
{

///<summary>
/// <p>The HL7 MOP (money or percentage) data type.  Consists of the following components: </p><ol>
/// <li>money or percentage indicator (IS)</li>
/// <li>money or percentage quantity (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class MOP : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a MOP.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public MOP(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a MOP.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public MOP(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new IS(message, 0,"Money or percentage indicator");
		data[1] = new NM(message,"Money or percentage quantity");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element MOP composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns money or percentage indicator (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS MoneyOrPercentageIndicator {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns money or percentage quantity (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM MoneyOrPercentageQuantity {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}