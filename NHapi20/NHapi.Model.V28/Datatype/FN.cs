using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V28.Datatype
{

///<summary>
/// <p>The HL7 FN (Family Name) data type.  Consists of the following components: </p><ol>
/// <li>Surname (ST)</li>
/// <li>Own Surname Prefix (ST)</li>
/// <li>Own Surname (ST)</li>
/// <li>Surname Prefix from Partner/Spouse (ST)</li>
/// <li>Surname from Partner/Spouse (ST)</li>
/// </ol>
///</summary>
[Serializable]
public class FN : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a FN.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public FN(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a FN.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public FN(IMessage message, string description) : base(message, description){
		data = new IType[5];
		data[0] = new ST(message,"Surname");
		data[1] = new ST(message,"Own Surname Prefix");
		data[2] = new ST(message,"Own Surname");
		data[3] = new ST(message,"Surname Prefix from Partner/Spouse");
		data[4] = new ST(message,"Surname from Partner/Spouse");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 5 element FN composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Surname (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST Surname {
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
	/// Returns Own Surname Prefix (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OwnSurnamePrefix {
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
	/// Returns Own Surname (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST OwnSurname {
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
	/// Returns Surname Prefix from Partner/Spouse (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SurnamePrefixFromPartnerSpouse {
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
	/// Returns Surname from Partner/Spouse (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SurnameFromPartnerSpouse {
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
}}