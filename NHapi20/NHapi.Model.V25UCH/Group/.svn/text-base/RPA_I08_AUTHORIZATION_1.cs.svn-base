using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V25UCH.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V25UCH.Group
{
///<summary>
///Represents the RPA_I08_AUTHORIZATION_1 Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: AUT (Authorization Information) </li>
///<li>1: CTD (Contact Data) optional </li>
///</ol>
///</summary>
[Serializable]
public class RPA_I08_AUTHORIZATION_1 : AbstractGroup {

	///<summary> 
	/// Creates a new RPA_I08_AUTHORIZATION_1 Group.
	///</summary>
	public RPA_I08_AUTHORIZATION_1(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(AUT), true, false);
	      this.add(typeof(CTD), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RPA_I08_AUTHORIZATION_1 - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns AUT (Authorization Information) - creates it if necessary
	///</summary>
	public AUT AUT { 
get{
	   AUT ret = null;
	   try {
	      ret = (AUT)this.GetStructure("AUT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns CTD (Contact Data) - creates it if necessary
	///</summary>
	public CTD CTD { 
get{
	   CTD ret = null;
	   try {
	      ret = (CTD)this.GetStructure("CTD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
