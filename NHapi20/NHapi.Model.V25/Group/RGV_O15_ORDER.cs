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
///Represents the RGV_O15_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RGV_O15_TIMING (a Group object) optional repeating</li>
///<li>2: RGV_O15_ORDER_DETAIL (a Group object) optional </li>
///<li>3: RGV_O15_ENCODING (a Group object) optional </li>
///<li>4: RGV_O15_GIVE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RGV_O15_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RGV_O15_ORDER Group.
	///</summary>
	public RGV_O15_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RGV_O15_TIMING), false, true);
	      this.add(typeof(RGV_O15_ORDER_DETAIL), false, false);
	      this.add(typeof(RGV_O15_ENCODING), false, false);
	      this.add(typeof(RGV_O15_GIVE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RGV_O15_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RGV_O15_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RGV_O15_TIMING GetTIMING() {
	   RGV_O15_TIMING ret = null;
	   try {
	      ret = (RGV_O15_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RGV_O15_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RGV_O15_TIMING GetTIMING(int rep) { 
	   return (RGV_O15_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RGV_O15_TIMING 
	 */ 
	public int TIMINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns RGV_O15_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public RGV_O15_ORDER_DETAIL ORDER_DETAIL { 
get{
	   RGV_O15_ORDER_DETAIL ret = null;
	   try {
	      ret = (RGV_O15_ORDER_DETAIL)this.GetStructure("ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RGV_O15_ENCODING (a Group object) - creates it if necessary
	///</summary>
	public RGV_O15_ENCODING ENCODING { 
get{
	   RGV_O15_ENCODING ret = null;
	   try {
	      ret = (RGV_O15_ENCODING)this.GetStructure("ENCODING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RGV_O15_GIVE (a Group object) - creates it if necessary
	///</summary>
	public RGV_O15_GIVE GetGIVE() {
	   RGV_O15_GIVE ret = null;
	   try {
	      ret = (RGV_O15_GIVE)this.GetStructure("GIVE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RGV_O15_GIVE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RGV_O15_GIVE GetGIVE(int rep) { 
	   return (RGV_O15_GIVE)this.GetStructure("GIVE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RGV_O15_GIVE 
	 */ 
	public int GIVERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GIVE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

}
}
