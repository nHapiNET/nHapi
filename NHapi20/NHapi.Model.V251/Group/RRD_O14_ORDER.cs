using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the RRD_O14_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RRD_O14_TIMING (a Group object) </li>
///<li>2: RRD_O14_DISPENSE (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RRD_O14_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RRD_O14_ORDER Group.
	///</summary>
	public RRD_O14_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RRD_O14_TIMING), true, false);
	      this.add(typeof(RRD_O14_DISPENSE), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRD_O14_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns RRD_O14_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RRD_O14_TIMING TIMING { 
get{
	   RRD_O14_TIMING ret = null;
	   try {
	      ret = (RRD_O14_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RRD_O14_DISPENSE (a Group object) - creates it if necessary
	///</summary>
	public RRD_O14_DISPENSE DISPENSE { 
get{
	   RRD_O14_DISPENSE ret = null;
	   try {
	      ret = (RRD_O14_DISPENSE)this.GetStructure("DISPENSE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
