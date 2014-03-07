using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the DFT_P03_COMMON_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) optional </li>
///<li>1: DFT_P03_TIMING_QUANTITY (a Group object) </li>
///<li>2: DFT_P03_ORDER (a Group object) optional </li>
///<li>3: DFT_P03_OBSERVATION (a Group object) </li>
///</ol>
///</summary>
[Serializable]
public class DFT_P03_COMMON_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new DFT_P03_COMMON_ORDER Group.
	///</summary>
	public DFT_P03_COMMON_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(DFT_P03_TIMING_QUANTITY), true, false);
	      this.add(typeof(DFT_P03_ORDER), false, false);
	      this.add(typeof(DFT_P03_OBSERVATION), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DFT_P03_COMMON_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns DFT_P03_TIMING_QUANTITY (a Group object) - creates it if necessary
	///</summary>
	public DFT_P03_TIMING_QUANTITY TIMING_QUANTITY { 
get{
	   DFT_P03_TIMING_QUANTITY ret = null;
	   try {
	      ret = (DFT_P03_TIMING_QUANTITY)this.GetStructure("TIMING_QUANTITY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns DFT_P03_ORDER (a Group object) - creates it if necessary
	///</summary>
	public DFT_P03_ORDER ORDER { 
get{
	   DFT_P03_ORDER ret = null;
	   try {
	      ret = (DFT_P03_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns DFT_P03_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public DFT_P03_OBSERVATION OBSERVATION { 
get{
	   DFT_P03_OBSERVATION ret = null;
	   try {
	      ret = (DFT_P03_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
