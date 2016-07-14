using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V21.Segment;
using NHapi.Model.V21.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V21.Group
{
///<summary>
///Represents the ADT_A17_PATIENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (PATIENT IDENTIFICATION) </li>
///<li>1: PV1 (PATIENT VISIT) </li>
///</ol>
///</summary>
[Serializable]
public class ADT_A17_PATIENT : AbstractGroup {

	///<summary> 
	/// Creates a new ADT_A17_PATIENT Group.
	///</summary>
	public ADT_A17_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PV1), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A17_PATIENT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PID (PATIENT IDENTIFICATION) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PV1 (PATIENT VISIT) - creates it if necessary
	///</summary>
	public PV1 PV1 { 
get{
	   PV1 ret = null;
	   try {
	      ret = (PV1)this.GetStructure("PV1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
