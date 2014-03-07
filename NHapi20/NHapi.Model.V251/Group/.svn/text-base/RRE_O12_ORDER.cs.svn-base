using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the RRE_O12_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RRE_O12_TIMING (a Group object) </li>
///<li>2: RRE_O12_ENCODING (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RRE_O12_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RRE_O12_ORDER Group.
	///</summary>
	public RRE_O12_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RRE_O12_TIMING), true, false);
	      this.add(typeof(RRE_O12_ENCODING), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRE_O12_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns RRE_O12_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RRE_O12_TIMING TIMING { 
get{
	   RRE_O12_TIMING ret = null;
	   try {
	      ret = (RRE_O12_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RRE_O12_ENCODING (a Group object) - creates it if necessary
	///</summary>
	public RRE_O12_ENCODING ENCODING { 
get{
	   RRE_O12_ENCODING ret = null;
	   try {
	      ret = (RRE_O12_ENCODING)this.GetStructure("ENCODING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
