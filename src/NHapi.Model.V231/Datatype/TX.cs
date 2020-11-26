using System;
using NHapi.Base.Model;
using NHapi.Base;
using NHapi.Base.Model.Primitive;
namespace NHapi.Model.V231.Datatype
{
///<summary>
///Represents the HL7 TX (text data) datatype.  A TX contains a single String value.
///</summary>
[Serializable]
public class TX : AbstractPrimitive  {

	///<summary>
	///Constructs an uninitialized TX.
	///<param name="message">The Message to which this Type belongs</param>
	///</summary>
	public TX(IMessage message) : base(message){
	}

	///<summary>
	///Constructs an uninitialized TX.
	///<param name="message">The Message to which this Type belongs</param>
	///<param name="description">The description of this type</param>
	///</summary>
	public TX(IMessage message, string description) : base(message,description){
	}

	///<summary>
	///  @return "2.3.1"
	///</summary>
	public string getVersion() {
	    return "2.3.1";
}
}
}