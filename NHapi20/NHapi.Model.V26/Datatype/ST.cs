using System;
using NHapi.Base.Model;
using NHapi.Base;
using NHapi.Base.Model.Primitive;
namespace NHapi.Model.V26.Datatype
{
///<summary>
///Represents the HL7 ST (String Data) datatype.  A ST contains a single String value.
///</summary>
[Serializable]
public class ST : AbstractPrimitive  {

	///<summary>
	///Constructs an uninitialized ST.
	///<param name="message">The Message to which this Type belongs</param>
	///</summary>
	public ST(IMessage message) : base(message){
	}

	///<summary>
	///Constructs an uninitialized ST.
	///<param name="message">The Message to which this Type belongs</param>
	///<param name="description">The description of this type</param>
	///</summary>
	public ST(IMessage message, string description) : base(message,description){
	}

	///<summary>
	///  @return "2.6"
	///</summary>
	public string getVersion() {
	    return "2.6";
}
}
}