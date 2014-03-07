using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 OSD (order sequence) data type.  Consists of the following components: </p><ol>
/// <li>sequence/results flag (ID)</li>
/// <li>placer order number: entity identifier (ST)</li>
/// <li>placer order number: namespace ID (IS)</li>
/// <li>filler order number: entity identifier (ST)</li>
/// <li>filler order number: namespace ID (IS)</li>
/// <li>sequence condition value (ST)</li>
/// <li>maximum number of repeats (NM)</li>
/// <li>placer order number: universal ID (ST)</li>
/// <li>placer order number; universal ID type (ID)</li>
/// <li>filler order number: universal ID (ST)</li>
/// <li>filler order number: universal ID type (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class OSD : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a OSD.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public OSD(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a OSD.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public OSD(IMessage message, string description) : base(message, description){
		data = new IType[11];
		data[0] = new ID(message, 0,"Sequence/results flag");
		data[1] = new ST(message,"Placer order number: entity identifier");
		data[2] = new IS(message, 0,"Placer order number: namespace ID");
		data[3] = new ST(message,"Filler order number: entity identifier");
		data[4] = new IS(message, 0,"Filler order number: namespace ID");
		data[5] = new ST(message,"Sequence condition value");
		data[6] = new NM(message,"Maximum number of repeats");
		data[7] = new ST(message,"Placer order number: universal ID");
		data[8] = new ID(message, 0,"Placer order number; universal ID type");
		data[9] = new ST(message,"Filler order number: universal ID");
		data[10] = new ID(message, 0,"Filler order number: universal ID type");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 11 element OSD composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns sequence/results flag (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID SequenceResultsFlag {
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
	/// Returns placer order number: entity identifier (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST PlacerOrderNumberEntityIdentifier {
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
	/// Returns placer order number: namespace ID (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS PlacerOrderNumberNamespaceID {
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
	/// Returns filler order number: entity identifier (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST FillerOrderNumberEntityIdentifier {
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
	/// Returns filler order number: namespace ID (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS FillerOrderNumberNamespaceID {
get{
	   IS ret = null;
	   try {
	      ret = (IS)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sequence condition value (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SequenceConditionValue {
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
	/// Returns maximum number of repeats (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM MaximumNumberOfRepeats {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns placer order number: universal ID (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST PlacerOrderNumberUniversalID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns placer order number; universal ID type (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID PlacerOrderNumberUniversalIDType {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[8];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns filler order number: universal ID (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST FillerOrderNumberUniversalID {
get{
	   ST ret = null;
	   try {
	      ret = (ST)this[9];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns filler order number: universal ID type (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID FillerOrderNumberUniversalIDType {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[10];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}