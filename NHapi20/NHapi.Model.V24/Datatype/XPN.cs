using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V24.Datatype
{

///<summary>
/// <p>The HL7 XPN (extended person name) data type.  Consists of the following components: </p><ol>
/// <li>family name (FN)</li>
/// <li>given name (ST)</li>
/// <li>second and further given names or initials thereof (ST)</li>
/// <li>suffix (e.g., JR or III) (ST)</li>
/// <li>prefix (e.g., DR) (ST)</li>
/// <li>degree (e.g., MD) (IS)</li>
/// <li>name type code (ID)</li>
/// <li>Name Representation code (ID)</li>
/// <li>name context (CE)</li>
/// <li>name validity range (DR)</li>
/// <li>name assembly order (ID)</li>
/// </ol>
///</summary>
[Serializable]
public class XPN : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a XPN.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public XPN(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a XPN.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public XPN(IMessage message, string description) : base(message, description){
		data = new IType[11];
		data[0] = new FN(message,"Family name");
		data[1] = new ST(message,"Given name");
		data[2] = new ST(message,"Second and further given names or initials thereof");
		data[3] = new ST(message,"Suffix (e.g., JR or III)");
		data[4] = new ST(message,"Prefix (e.g., DR)");
		data[5] = new IS(message, 0,"Degree (e.g., MD)");
		data[6] = new ID(message, 0,"Name type code");
		data[7] = new ID(message, 0,"Name Representation code");
		data[8] = new CE(message,"Name context");
		data[9] = new DR(message,"Name validity range");
		data[10] = new ID(message, 0,"Name assembly order");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 11 element XPN composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns family name (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public FN FamilyName {
get{
	   FN ret = null;
	   try {
	      ret = (FN)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns given name (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST GivenName {
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
	/// Returns second and further given names or initials thereof (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SecondAndFurtherGivenNamesOrInitialsThereof {
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
	/// Returns suffix (e.g., JR or III) (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST SuffixEgJRorIII {
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
	/// Returns prefix (e.g., DR) (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ST PrefixEgDR {
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
	///<summary>
	/// Returns degree (e.g., MD) (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public IS DegreeEgMD {
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
	///<summary>
	/// Returns name type code (component #6).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameTypeCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[6];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns Name Representation code (component #7).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameRepresentationCode {
get{
	   ID ret = null;
	   try {
	      ret = (ID)this[7];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns name context (component #8).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CE NameContext {
get{
	   CE ret = null;
	   try {
	      ret = (CE)this[8];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns name validity range (component #9).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public DR NameValidityRange {
get{
	   DR ret = null;
	   try {
	      ret = (DR)this[9];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns name assembly order (component #10).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public ID NameAssemblyOrder {
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