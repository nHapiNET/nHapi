using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the ORL_O36_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: ORL_O36_TIMING (a Group object) </li>
///<li>2: ORL_O36_OBSERVATION_REQUEST (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class ORL_O36_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O36_ORDER Group.
	///</summary>
	public ORL_O36_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(ORL_O36_TIMING), true, false);
	      this.add(typeof(ORL_O36_OBSERVATION_REQUEST), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O36_ORDER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (Common Order) - creates it if necessary
	///</summary>
	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ORL_O36_TIMING (a Group object) - creates it if necessary
	///</summary>
	public ORL_O36_TIMING TIMING { 
get{
	   ORL_O36_TIMING ret = null;
	   try {
	      ret = (ORL_O36_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ORL_O36_OBSERVATION_REQUEST (a Group object) - creates it if necessary
	///</summary>
	public ORL_O36_OBSERVATION_REQUEST OBSERVATION_REQUEST { 
get{
	   ORL_O36_OBSERVATION_REQUEST ret = null;
	   try {
	      ret = (ORL_O36_OBSERVATION_REQUEST)this.GetStructure("OBSERVATION_REQUEST");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
