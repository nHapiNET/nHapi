using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V26.Datatype
{

///<summary>
/// <p>The HL7 ED (Encapsulated Data) data type.  Consists of the following components: </p><ol>
/// <li>Source Application (HD)</li>
/// <li>Type of Data (ID)</li>
/// <li>Data Subtype (ID)</li>
/// <li>Encoding (ID)</li>
/// <li>Data (TX)</li>
/// </ol>
///</summary>
[Serializable]
public class ED : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a ED.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public ED(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a ED.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public ED(IMessage message, string description) : base(message, description){
		data = new IType[5];
		data[0] = new HD(message,"Source Application");
		data[1] = new ID(message, 834,"Type of Data");
		data[2] = new ID(message, 291,"Data Subtype");
		data[3] = new ID(message, 299,"Encoding");
		data[4] = new TX(message,"Data");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 5 element ED composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns Source Application (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public HD SourceApplication {
get{
	   HD ret = null;
	   try {
	      ret = (HD)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Type of Data (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID TypeOfData {
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
	/// Returns Data Subtype (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID DataSubtype {
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
	/// Returns Encoding (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Encoding {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Data (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public TX Data {
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
}}