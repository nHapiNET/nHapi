using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23.Datatype
{

///<summary>
/// <p>The HL7 SN (structured numeric) data type.  Consists of the following components: </p><ol>
/// <li>comparator (ST)</li>
/// <li>num1 (NM)</li>
/// <li>separator or suffix (ST)</li>
/// <li>num2 (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class SN : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a SN.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public SN(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a SN.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public SN(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"Comparator");
		data[1] = new NM(message,"Num1");
		data[2] = new ST(message,"Separator or suffix");
		data[3] = new NM(message,"Num2");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element SN composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns comparator (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Comparator {
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
	/// Returns num1 (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Num1 {
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
	///<summary>
	/// Returns separator or suffix (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SeparatorOrSuffix {
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
	/// Returns num2 (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM Num2 {
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
}}