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
///Represents the CSU_C12_STUDY_SCHEDULE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: CSS (Clinical Study Data Schedule) optional </li>
///<li>1: CSU_C12_STUDY_OBSERVATION (a Group object) optional repeating</li>
///<li>2: CSU_C12_STUDY_PHARM (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class CSU_C12_STUDY_SCHEDULE : AbstractGroup {

	///<summary> 
	/// Creates a new CSU_C12_STUDY_SCHEDULE Group.
	///</summary>
	public CSU_C12_STUDY_SCHEDULE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(CSS), false, false);
	      this.add(typeof(CSU_C12_STUDY_OBSERVATION), false, true);
	      this.add(typeof(CSU_C12_STUDY_PHARM), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CSU_C12_STUDY_SCHEDULE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns CSS (Clinical Study Data Schedule) - creates it if necessary
	///</summary>
	public CSS CSS { 
get{
	   CSS ret = null;
	   try {
	      ret = (CSS)this.GetStructure("CSS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CSU_C12_STUDY_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CSU_C12_STUDY_OBSERVATION GetSTUDY_OBSERVATION() {
	   CSU_C12_STUDY_OBSERVATION ret = null;
	   try {
	      ret = (CSU_C12_STUDY_OBSERVATION)this.GetStructure("STUDY_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CSU_C12_STUDY_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CSU_C12_STUDY_OBSERVATION GetSTUDY_OBSERVATION(int rep) { 
	   return (CSU_C12_STUDY_OBSERVATION)this.GetStructure("STUDY_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CSU_C12_STUDY_OBSERVATION 
	 */ 
	public int STUDY_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("STUDY_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CSU_C12_STUDY_OBSERVATION results 
	 */ 
	public IEnumerable<CSU_C12_STUDY_OBSERVATION> STUDY_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < STUDY_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (CSU_C12_STUDY_OBSERVATION)this.GetStructure("STUDY_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new CSU_C12_STUDY_OBSERVATION
	///</summary>
	public CSU_C12_STUDY_OBSERVATION AddSTUDY_OBSERVATION()
	{
		return this.AddStructure("STUDY_OBSERVATION") as CSU_C12_STUDY_OBSERVATION;
	}

	///<summary>
	///Removes the given CSU_C12_STUDY_OBSERVATION
	///</summary>
	public void RemoveSTUDY_OBSERVATION(CSU_C12_STUDY_OBSERVATION toRemove)
	{
		this.RemoveStructure("STUDY_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the CSU_C12_STUDY_OBSERVATION at the given index
	///</summary>
	public void RemoveSTUDY_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("STUDY_OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of CSU_C12_STUDY_PHARM (a Group object) - creates it if necessary
	///</summary>
	public CSU_C12_STUDY_PHARM GetSTUDY_PHARM() {
	   CSU_C12_STUDY_PHARM ret = null;
	   try {
	      ret = (CSU_C12_STUDY_PHARM)this.GetStructure("STUDY_PHARM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CSU_C12_STUDY_PHARM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CSU_C12_STUDY_PHARM GetSTUDY_PHARM(int rep) { 
	   return (CSU_C12_STUDY_PHARM)this.GetStructure("STUDY_PHARM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CSU_C12_STUDY_PHARM 
	 */ 
	public int STUDY_PHARMRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("STUDY_PHARM").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CSU_C12_STUDY_PHARM results 
	 */ 
	public IEnumerable<CSU_C12_STUDY_PHARM> STUDY_PHARMs 
	{ 
		get
		{
			for (int rep = 0; rep < STUDY_PHARMRepetitionsUsed; rep++)
			{
				yield return (CSU_C12_STUDY_PHARM)this.GetStructure("STUDY_PHARM", rep);
			}
		}
	}

	///<summary>
	///Adds a new CSU_C12_STUDY_PHARM
	///</summary>
	public CSU_C12_STUDY_PHARM AddSTUDY_PHARM()
	{
		return this.AddStructure("STUDY_PHARM") as CSU_C12_STUDY_PHARM;
	}

	///<summary>
	///Removes the given CSU_C12_STUDY_PHARM
	///</summary>
	public void RemoveSTUDY_PHARM(CSU_C12_STUDY_PHARM toRemove)
	{
		this.RemoveStructure("STUDY_PHARM", toRemove);
	}

	///<summary>
	///Removes the CSU_C12_STUDY_PHARM at the given index
	///</summary>
	public void RemoveSTUDY_PHARMAt(int index)
	{
		this.RemoveRepetition("STUDY_PHARM", index);
	}

}
}
