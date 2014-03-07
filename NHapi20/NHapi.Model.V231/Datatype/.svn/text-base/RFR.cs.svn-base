using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V231.Datatype
{

///<summary>
/// <p>The HL7 RFR (reference range) data type.  Consists of the following components: </p><ol>
/// <li>numeric range (NR)</li>
/// <li>administrative sex (IS)</li>
/// <li>age range (NR)</li>
/// <li>gestational age range (NR)</li>
/// <li>species (TX)</li>
/// <li>race/subspecies (ST)</li>
/// <li>conditions (TX)</li>
/// </ol>
///</summary>
[Serializable]
public class RFR : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a RFR.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public RFR(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a RFR.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public RFR(IMessage message, string description) : base(message, description){
		data = new IType[7];
		data[0] = new NR(message,"Numeric range");
		data[1] = new IS(message, 0,"Administrative sex");
		data[2] = new NR(message,"Age range");
		data[3] = new NR(message,"Gestational age range");
		data[4] = new TX(message,"Species");
		data[5] = new ST(message,"Race/subspecies");
		data[6] = new TX(message,"Conditions");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 7 element RFR composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns numeric range (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NR NumericRange {
get{
	   NR ret = null;
	   try {
	      ret = (NR)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns administrative sex (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS AdministrativeSex {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns age range (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NR AgeRange {
get{
	   NR ret = null;
	   try {
	      ret = (NR)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns gestational age range (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NR GestationalAgeRange {
get{
	   NR ret = null;
	   try {
	      ret = (NR)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns species (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TX Species {
get{
	   TX ret = null;
	   try {
	      ret = (TX)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns race/subspecies (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST RaceSubspecies {
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
	/// Returns conditions (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TX Conditions {
get{
	   TX ret = null;
	   try {
	      ret = (TX)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}