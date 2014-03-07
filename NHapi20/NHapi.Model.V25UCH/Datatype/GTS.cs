using System;
using NHapi.Base.Model;
using NHapi.Base;
using NHapi.Base.Model.Primitive;
namespace NHapi.Model.V25UCH.Datatype
{
///<summary>
///Represents the HL7 GTS (General Timing Specification) datatype.  A GTS contains a single String value.
///</summary>
[Serializable]
public class GTS : AbstractPrimitive  {

	///<summary>
	///Constructs an uninitialized GTS.
	///<param name="message">The Message to which this Type belongs</param>
	///</summary>
	public GTS(IMessage message) : base(message){
	}

	///<summary>
	///Constructs an uninitialized GTS.
	///<param name="message">The Message to which this Type belongs</param>
	///<param name="description">The description of this type</param>
	///</summary>
	public GTS(IMessage message, string description) : base(message,description){
	}

	///<summary>
	///  @return "2.5.UCH"
	///</summary>
	public string getVersion() {
	    return "2.3";
}
}
}