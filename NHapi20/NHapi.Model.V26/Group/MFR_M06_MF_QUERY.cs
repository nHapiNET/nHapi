using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V26.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the MFR_M06_MF_QUERY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master File Entry) </li>
///<li>1: CM0 (Clinical Study Master) </li>
///<li>2: MFR_M06_MF_PHASE_SCHED_DETAIL (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFR_M06_MF_QUERY : AbstractGroup {

	///<summary> 
	/// Creates a new MFR_M06_MF_QUERY Group.
	///</summary>
	public MFR_M06_MF_QUERY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(CM0), true, false);
	      this.add(typeof(MFR_M06_MF_PHASE_SCHED_DETAIL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFR_M06_MF_QUERY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MFE (Master File Entry) - creates it if necessary
	///</summary>
	public MFE MFE { 
get{
	   MFE ret = null;
	   try {
	      ret = (MFE)this.GetStructure("MFE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns CM0 (Clinical Study Master) - creates it if necessary
	///</summary>
	public CM0 CM0 { 
get{
	   CM0 ret = null;
	   try {
	      ret = (CM0)this.GetStructure("CM0");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of MFR_M06_MF_PHASE_SCHED_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public MFR_M06_MF_PHASE_SCHED_DETAIL GetMF_PHASE_SCHED_DETAIL() {
	   MFR_M06_MF_PHASE_SCHED_DETAIL ret = null;
	   try {
	      ret = (MFR_M06_MF_PHASE_SCHED_DETAIL)this.GetStructure("MF_PHASE_SCHED_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFR_M06_MF_PHASE_SCHED_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFR_M06_MF_PHASE_SCHED_DETAIL GetMF_PHASE_SCHED_DETAIL(int rep) { 
	   return (MFR_M06_MF_PHASE_SCHED_DETAIL)this.GetStructure("MF_PHASE_SCHED_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFR_M06_MF_PHASE_SCHED_DETAIL 
	 */ 
	public int MF_PHASE_SCHED_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_PHASE_SCHED_DETAIL").Length; 
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
