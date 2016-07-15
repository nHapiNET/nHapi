using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the PTR_PCF_PATIENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (Patient Identification) </li>
///<li>1: PTR_PCF_PATIENT_VISIT (a Group object) optional </li>
///<li>2: PTR_PCF_PATHWAY (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class PTR_PCF_PATIENT : AbstractGroup {

	///<summary> 
	/// Creates a new PTR_PCF_PATIENT Group.
	///</summary>
	public PTR_PCF_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PTR_PCF_PATIENT_VISIT), false, false);
	      this.add(typeof(PTR_PCF_PATHWAY), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PTR_PCF_PATIENT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PTR_PCF_PATIENT_VISIT (a Group object) - creates it if necessary
	///</summary>
	public PTR_PCF_PATIENT_VISIT PATIENT_VISIT { 
get{
	   PTR_PCF_PATIENT_VISIT ret = null;
	   try {
	      ret = (PTR_PCF_PATIENT_VISIT)this.GetStructure("PATIENT_VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PTR_PCF_PATHWAY (a Group object) - creates it if necessary
	///</summary>
	public PTR_PCF_PATHWAY GetPATHWAY() {
	   PTR_PCF_PATHWAY ret = null;
	   try {
	      ret = (PTR_PCF_PATHWAY)this.GetStructure("PATHWAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PTR_PCF_PATHWAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PTR_PCF_PATHWAY GetPATHWAY(int rep) { 
	   return (PTR_PCF_PATHWAY)this.GetStructure("PATHWAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PTR_PCF_PATHWAY 
	 */ 
	public int PATHWAYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATHWAY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PTR_PCF_PATHWAY results 
	 */ 
	public IEnumerable<PTR_PCF_PATHWAY> PATHWAYs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAYRepetitionsUsed; rep++)
			{
				yield return (PTR_PCF_PATHWAY)this.GetStructure("PATHWAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new PTR_PCF_PATHWAY
	///</summary>
	public PTR_PCF_PATHWAY AddPATHWAY()
	{
		return this.AddStructure("PATHWAY") as PTR_PCF_PATHWAY;
	}

	///<summary>
	///Removes the given PTR_PCF_PATHWAY
	///</summary>
	public void RemovePATHWAY(PTR_PCF_PATHWAY toRemove)
	{
		this.RemoveStructure("PATHWAY", toRemove);
	}

	///<summary>
	///Removes the PTR_PCF_PATHWAY at the given index
	///</summary>
	public void RemovePATHWAYAt(int index)
	{
		this.RemoveRepetition("PATHWAY", index);
	}

}
}
