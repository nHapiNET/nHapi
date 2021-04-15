using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
///<summary>
///Represents the CSU_C09_STUDY_PHASE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: CSP (Clinical Study Phase) optional </li>
///<li>1: CSU_C09_STUDY_SCHEDULE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class CSU_C09_STUDY_PHASE : AbstractGroup {

	///<summary> 
	/// Creates a new CSU_C09_STUDY_PHASE Group.
	///</summary>
	public CSU_C09_STUDY_PHASE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(CSP), false, false);
	      this.add(typeof(CSU_C09_STUDY_SCHEDULE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CSU_C09_STUDY_PHASE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns CSP (Clinical Study Phase) - creates it if necessary
	///</summary>
	public CSP CSP { 
get{
	   CSP ret = null;
	   try {
	      ret = (CSP)this.GetStructure("CSP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CSU_C09_STUDY_SCHEDULE (a Group object) - creates it if necessary
	///</summary>
	public CSU_C09_STUDY_SCHEDULE GetSTUDY_SCHEDULE() {
	   CSU_C09_STUDY_SCHEDULE ret = null;
	   try {
	      ret = (CSU_C09_STUDY_SCHEDULE)this.GetStructure("STUDY_SCHEDULE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CSU_C09_STUDY_SCHEDULE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CSU_C09_STUDY_SCHEDULE GetSTUDY_SCHEDULE(int rep) { 
	   return (CSU_C09_STUDY_SCHEDULE)this.GetStructure("STUDY_SCHEDULE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CSU_C09_STUDY_SCHEDULE 
	 */ 
	public int STUDY_SCHEDULERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("STUDY_SCHEDULE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CSU_C09_STUDY_SCHEDULE results 
	 */ 
	public IEnumerable<CSU_C09_STUDY_SCHEDULE> STUDY_SCHEDULEs 
	{ 
		get
		{
			for (int rep = 0; rep < STUDY_SCHEDULERepetitionsUsed; rep++)
			{
				yield return (CSU_C09_STUDY_SCHEDULE)this.GetStructure("STUDY_SCHEDULE", rep);
			}
		}
	}

	///<summary>
	///Adds a new CSU_C09_STUDY_SCHEDULE
	///</summary>
	public CSU_C09_STUDY_SCHEDULE AddSTUDY_SCHEDULE()
	{
		return this.AddStructure("STUDY_SCHEDULE") as CSU_C09_STUDY_SCHEDULE;
	}

	///<summary>
	///Removes the given CSU_C09_STUDY_SCHEDULE
	///</summary>
	public void RemoveSTUDY_SCHEDULE(CSU_C09_STUDY_SCHEDULE toRemove)
	{
		this.RemoveStructure("STUDY_SCHEDULE", toRemove);
	}

	///<summary>
	///Removes the CSU_C09_STUDY_SCHEDULE at the given index
	///</summary>
	public void RemoveSTUDY_SCHEDULEAt(int index)
	{
		this.RemoveRepetition("STUDY_SCHEDULE", index);
	}

}
}
