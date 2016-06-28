using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V271.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the RDR_RDR_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RDR_RDR_TIMING (a Group object) optional repeating</li>
///<li>2: RDR_RDR_ENCODING (a Group object) optional </li>
///<li>3: RDR_RDR_DISPENSE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RDR_RDR_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RDR_RDR_ORDER Group.
	///</summary>
	public RDR_RDR_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RDR_RDR_TIMING), false, true);
	      this.add(typeof(RDR_RDR_ENCODING), false, false);
	      this.add(typeof(RDR_RDR_DISPENSE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RDR_RDR_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RDR_RDR_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RDR_RDR_TIMING GetTIMING() {
	   RDR_RDR_TIMING ret = null;
	   try {
	      ret = (RDR_RDR_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDR_RDR_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDR_RDR_TIMING GetTIMING(int rep) { 
	   return (RDR_RDR_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDR_RDR_TIMING 
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
	/// Returns RDR_RDR_ENCODING (a Group object) - creates it if necessary
	///</summary>
	public RDR_RDR_ENCODING ENCODING { 
get{
	   RDR_RDR_ENCODING ret = null;
	   try {
	      ret = (RDR_RDR_ENCODING)this.GetStructure("ENCODING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RDR_RDR_DISPENSE (a Group object) - creates it if necessary
	///</summary>
	public RDR_RDR_DISPENSE GetDISPENSE() {
	   RDR_RDR_DISPENSE ret = null;
	   try {
	      ret = (RDR_RDR_DISPENSE)this.GetStructure("DISPENSE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDR_RDR_DISPENSE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDR_RDR_DISPENSE GetDISPENSE(int rep) { 
	   return (RDR_RDR_DISPENSE)this.GetStructure("DISPENSE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDR_RDR_DISPENSE 
	 */ 
	public int DISPENSERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DISPENSE").Length; 
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
