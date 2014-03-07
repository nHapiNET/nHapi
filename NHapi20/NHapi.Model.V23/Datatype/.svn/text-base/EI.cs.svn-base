using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23.Datatype
{

///<summary>
/// <p>The HL7 EI (entity identifier) data type.  Consists of the following components: </p><ol>
/// <li>entity identifier (ST)</li>
/// <li>namespace ID (IS)</li>
/// <li>universal ID (ST)</li>
/// <li>universal ID type (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class EI : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a EI.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public EI(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a EI.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public EI(IMessage message, string description) : base(message, description){
		data = new IType[4];
		data[0] = new ST(message,"Entity identifier");
		data[1] = new IS(message, 0,"Namespace ID");
		data[2] = new ST(message,"Universal ID");
		data[3] = new ID(message, 0,"Universal ID type");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 4 element EI composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns entity identifier (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST EntityIdentifier {
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
	/// Returns namespace ID (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS NamespaceID {
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
	/// Returns universal ID (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST UniversalID {
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
	/// Returns universal ID type (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID UniversalIDType {
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
}}