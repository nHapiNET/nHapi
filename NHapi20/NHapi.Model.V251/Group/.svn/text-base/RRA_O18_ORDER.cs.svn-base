using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the RRA_O18_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RRA_O18_TIMING (a Group object) </li>
///<li>2: RRA_O18_ADMINISTRATION (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RRA_O18_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RRA_O18_ORDER Group.
	///</summary>
	public RRA_O18_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RRA_O18_TIMING), true, false);
	      this.add(typeof(RRA_O18_ADMINISTRATION), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRA_O18_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns RRA_O18_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RRA_O18_TIMING TIMING { 
get{
	   RRA_O18_TIMING ret = null;
	   try {
	      ret = (RRA_O18_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RRA_O18_ADMINISTRATION (a Group object) - creates it if necessary
	///</summary>
	public RRA_O18_ADMINISTRATION ADMINISTRATION { 
get{
	   RRA_O18_ADMINISTRATION ret = null;
	   try {
	      ret = (RRA_O18_ADMINISTRATION)this.GetStructure("ADMINISTRATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
