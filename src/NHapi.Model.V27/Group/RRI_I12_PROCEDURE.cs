using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V27.Segment;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the RRI_I12_PROCEDURE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PR1 (Procedures) </li>
///<li>1: RRI_I12_AUTHORIZATION_CONTACT2 (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RRI_I12_PROCEDURE : AbstractGroup {

	///<summary> 
	/// Creates a new RRI_I12_PROCEDURE Group.
	///</summary>
	public RRI_I12_PROCEDURE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PR1), true, false);
	      this.add(typeof(RRI_I12_AUTHORIZATION_CONTACT2), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRI_I12_PROCEDURE - this is probably a bug in the source code generator.", e);
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
	/// Returns RRI_I12_AUTHORIZATION_CONTACT2 (a Group object) - creates it if necessary
	///</summary>
	public RRI_I12_AUTHORIZATION_CONTACT2 AUTHORIZATION_CONTACT2 { 
get{
	   RRI_I12_AUTHORIZATION_CONTACT2 ret = null;
	   try {
	      ret = (RRI_I12_AUTHORIZATION_CONTACT2)this.GetStructure("AUTHORIZATION_CONTACT2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
