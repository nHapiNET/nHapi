using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V271.Datatype
{

///<summary>
/// <p>The HL7 SPD (Specialty Description) data type.  Consists of the following components: </p><ol>
/// <li>Specialty Name (ST)</li>
/// <li>Governing Board (ST)</li>
/// <li>Eligible or Certified (ID)</li>
/// <li>Date of Certification (DT)</li>
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
		data[0] = new ST(message,"Specialty Name");
		data[1] = new ST(message,"Governing Board");
		data[2] = new ID(message, 337,"Eligible or Certified");
		data[3] = new DT(message,"Date of Certification");
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
	/// Returns Specialty Name (component #0).  This is a convenience method that saves you from 
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
	/// Returns Governing Board (component #1).  This is a convenience method that saves you from 
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
	/// Returns Eligible or Certified (component #2).  This is a convenience method that saves you from 
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
	/// Returns Date of Certification (component #3).  This is a convenience method that saves you from 
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