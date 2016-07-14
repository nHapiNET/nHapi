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
///Represents the BAR_P10_PROCEDURE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PR1 (Procedures) </li>
///<li>1: GP2 (Grouping/Reimbursement - Procedure Line Item) optional </li>
///</ol>
///</summary>
[Serializable]
public class BAR_P10_PROCEDURE : AbstractGroup {

	///<summary> 
	/// Creates a new BAR_P10_PROCEDURE Group.
	///</summary>
	public BAR_P10_PROCEDURE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PR1), true, false);
	      this.add(typeof(GP2), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating BAR_P10_PROCEDURE - this is probably a bug in the source code generator.", e);
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
	/// Returns GP2 (Grouping/Reimbursement - Procedure Line Item) - creates it if necessary
	///</summary>
	public GP2 GP2 { 
get{
	   GP2 ret = null;
	   try {
	      ret = (GP2)this.GetStructure("GP2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
