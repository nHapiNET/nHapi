using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the VXR_V03_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: VXR_V03_TIMING (a Group object) </li>
///<li>2: RXA (Pharmacy/Treatment Administration) </li>
///<li>3: RXR (Pharmacy/Treatment Route) optional </li>
///<li>4: VXR_V03_OBSERVATION (a Group object) </li>
///</ol>
///</summary>
[Serializable]
public class VXR_V03_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new VXR_V03_ORDER Group.
	///</summary>
	public VXR_V03_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(VXR_V03_TIMING), true, false);
	      this.add(typeof(RXA), true, false);
	      this.add(typeof(RXR), false, false);
	      this.add(typeof(VXR_V03_OBSERVATION), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating VXR_V03_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns VXR_V03_TIMING (a Group object) - creates it if necessary
	///</summary>
	public VXR_V03_TIMING TIMING { 
get{
	   VXR_V03_TIMING ret = null;
	   try {
	      ret = (VXR_V03_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RXA (Pharmacy/Treatment Administration) - creates it if necessary
	///</summary>
	public RXA RXA { 
get{
	   RXA ret = null;
	   try {
	      ret = (RXA)this.GetStructure("RXA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RXR (Pharmacy/Treatment Route) - creates it if necessary
	///</summary>
	public RXR RXR { 
get{
	   RXR ret = null;
	   try {
	      ret = (RXR)this.GetStructure("RXR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns VXR_V03_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public VXR_V03_OBSERVATION OBSERVATION { 
get{
	   VXR_V03_OBSERVATION ret = null;
	   try {
	      ret = (VXR_V03_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
