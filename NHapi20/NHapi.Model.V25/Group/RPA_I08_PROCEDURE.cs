using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the RPA_I08_PROCEDURE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PR1 (Procedures) </li>
///<li>1: RPA_I08_AUTHORIZATION_2 (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RPA_I08_PROCEDURE : AbstractGroup {

	///<summary> 
	/// Creates a new RPA_I08_PROCEDURE Group.
	///</summary>
	public RPA_I08_PROCEDURE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PR1), true, false);
	      this.add(typeof(RPA_I08_AUTHORIZATION_2), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RPA_I08_PROCEDURE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PR1 (Procedures) - creates it if necessary
	///</summary>
	public PR1 PR1 { 
get{
	   PR1 ret = null;
	   try {
	      ret = (PR1)this.GetStructure("PR1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RPA_I08_AUTHORIZATION_2 (a Group object) - creates it if necessary
	///</summary>
	public RPA_I08_AUTHORIZATION_2 AUTHORIZATION_2 { 
get{
	   RPA_I08_AUTHORIZATION_2 ret = null;
	   try {
	      ret = (RPA_I08_AUTHORIZATION_2)this.GetStructure("AUTHORIZATION_2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
