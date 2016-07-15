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
///Represents the RQA_I08_PROCEDURE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PR1 (Procedures) </li>
///<li>1: RQA_I08_AUTHORIZATION2 (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RQA_I08_PROCEDURE : AbstractGroup {

	///<summary> 
	/// Creates a new RQA_I08_PROCEDURE Group.
	///</summary>
	public RQA_I08_PROCEDURE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PR1), true, false);
	      this.add(typeof(RQA_I08_AUTHORIZATION2), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RQA_I08_PROCEDURE - this is probably a bug in the source code generator.", e);
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
	/// Returns RQA_I08_AUTHORIZATION2 (a Group object) - creates it if necessary
	///</summary>
	public RQA_I08_AUTHORIZATION2 AUTHORIZATION2 { 
get{
	   RQA_I08_AUTHORIZATION2 ret = null;
	   try {
	      ret = (RQA_I08_AUTHORIZATION2)this.GetStructure("AUTHORIZATION2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
