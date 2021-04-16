using System;
using NHapi.Base.Model;
using NHapi.Base;
using NHapi.Base.Model.Primitive;
namespace NHapi.Model.V231.Datatype
{
///<summary>
///Represents the HL7 FT (formatted text data) datatype.  A FT contains a single String value.
///</summary>
[Serializable]
public class FT : AbstractPrimitive  {

	///<summary>
	///Constructs an uninitialized FT.
	///<param name="message">The Message to which this Type belongs</param>
	///</summary>
	public FT(IMessage message) : base(message){
	}

	///<summary>
	///Constructs an uninitialized FT.
	///<param name="message">The Message to which this Type belongs</param>
	///<param name="description">The description of this type</param>
	///</summary>
	public FT(IMessage message, string description) : base(message,description){
	}

	///<summary>
	///  @return "2.3.1"
	///</summary>
	public string getVersion() {
	    return "2.3.1";
}
}
}