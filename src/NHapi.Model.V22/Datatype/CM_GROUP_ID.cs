using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V22.Datatype
{

///<summary>
/// <p>The HL7 CM_GROUP_ID (Auftragsgruppennummer) data type.  Consists of the following components: </p><ol>
/// <li>unique group id (ID)</li>
/// <li>placer application id (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class CM_GROUP_ID : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CM_GROUP_ID.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CM_GROUP_ID(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CM_GROUP_ID.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CM_GROUP_ID(IMessage message, string description) : base(message, description){
		data = new IType[2];
		data[0] = new ID(message, 0,"Unique group id");
		data[1] = new ID(message, 0,"Placer application id");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 2 element CM_GROUP_ID composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns unique group id (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID UniqueGroupId {
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
	/// Returns placer application id (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID PlacerApplicationId {
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
}}