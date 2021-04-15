using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V231.Datatype
{

///<summary>
/// <p>The HL7 SPS (specimen source) data type.  Consists of the following components: </p><ol>
/// <li>specimen source name or code (CE)</li>
/// <li>additives (TX)</li>
/// <li>freetext (TX)</li>
/// <li>body site (CE)</li>
/// <li>site modifier (CE)</li>
/// <li>collection modifier method code (CE)</li>
/// <li>specimen role (CE)</li>
/// </ol>
///</summary>
[Serializable]
public class SPS : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a SPS.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public SPS(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a SPS.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public SPS(IMessage message, string description) : base(message, description){
		data = new IType[7];
		data[0] = new CE(message,"Specimen source name or code");
		data[1] = new TX(message,"Additives");
		data[2] = new TX(message,"Freetext");
		data[3] = new CE(message,"Body site");
		data[4] = new CE(message,"Site modifier");
		data[5] = new CE(message,"Collection modifier method code");
		data[6] = new CE(message,"Specimen role");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 7 element SPS composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns specimen source name or code (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE SpecimenSourceNameOrCode {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns additives (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TX Additives {
get{
	   TX ret = null;
	   try {
	      ret = (TX)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns freetext (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TX Freetext {
get{
	   TX ret = null;
	   try {
	      ret = (TX)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns body site (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE BodySite {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns site modifier (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE SiteModifier {
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
	/// Returns collection modifier method code (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE CollectionModifierMethodCode {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns specimen role (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE SpecimenRole {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}