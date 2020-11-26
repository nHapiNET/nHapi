using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 CF (coded element with formatted values) data type.  Consists of the following components: </p><ol>
/// <li>identifier (ID) (ID)</li>
/// <li>formatted text (FT)</li>
/// <li>name of coding system (IS)</li>
/// <li>alternate identifier (ID) (ID)</li>
/// <li>alternate formatted text (FT)</li>
/// <li>name of alternate coding system (IS)</li>
/// </ol>
///</summary>
[Serializable]
public class CF : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CF.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CF(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CF.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CF(IMessage message, string description) : base(message, description){
		data = new IType[6];
		data[0] = new ID(message, 0,"Identifier (ID)");
		data[1] = new FT(message,"Formatted text");
		data[2] = new IS(message, 0,"Name of coding system");
		data[3] = new ID(message, 0,"Alternate identifier (ID)");
		data[4] = new FT(message,"Alternate formatted text");
		data[5] = new IS(message, 0,"Name of alternate coding system");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 6 element CF composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns identifier (ID) (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID Identifier {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns formatted text (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FT FormattedText {
get{
	   FT ret = null;
	   try {
	      ret = (FT)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns name of coding system (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS NameOfCodingSystem {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns alternate identifier (ID) (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID AlternateIdentifier {
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
	/// Returns alternate formatted text (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FT AlternateFormattedText {
get{
	   FT ret = null;
	   try {
	      ret = (FT)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns name of alternate coding system (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS NameOfAlternateCodingSystem {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}