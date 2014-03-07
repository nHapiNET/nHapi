using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 SPD (Specialty) data type.  Consists of the following components: </p><ol>
/// <li>specialty name (ST)</li>
/// <li>governing board (ST)</li>
/// <li>eligible or certified (ID)</li>
/// <li>date of certification (DT)</li>
/// </ol>
///</summary>
[Serializable]
public class SPD : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a SPD.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public SPD(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a SPD.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public SPD(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"Specialty name");
		data[1] = new ST(message,"Governing board");
		data[2] = new ID(message, 0,"Eligible or certified");
		data[3] = new DT(message,"Date of certification");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element SPD composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns specialty name (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SpecialtyName {
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
	/// Returns governing board (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST GoverningBoard {
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
	/// Returns eligible or certified (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID EligibleOrCertified {
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
	/// Returns date of certification (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DT DateOfCertification {
get{
	   DT ret = null;
	   try {
	      ret = (DT)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}