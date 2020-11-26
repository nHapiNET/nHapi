using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V271.Segment;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the OPU_R25_PATIENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (Patient Identification) </li>
///<li>1: PD1 (Patient Additional Demographic) optional </li>
///<li>2: PRT (Participation Information) optional repeating</li>
///<li>3: OPU_R25_PATIENT_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPU_R25_PATIENT : AbstractGroup {

	///<summary> 
	/// Creates a new OPU_R25_PATIENT Group.
	///</summary>
	public OPU_R25_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PD1), false, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OPU_R25_PATIENT_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPU_R25_PATIENT - this is probably a bug in the source code generator.", e);
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
	/// Returns PD1 (Patient Additional Demographic) - creates it if necessary
	///</summary>
	public PD1 PD1 { 
get{
	   PD1 ret = null;
	   try {
	      ret = (PD1)this.GetStructure("PD1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PRT (Participation Information) - creates it if necessary
	///</summary>
	public PRT GetPRT() {
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRT
	/// * (Participation Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRT GetPRT(int rep) { 
	   return (PRT)this.GetStructure("PRT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRT 
	 */ 
	public int PRTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRT results 
	 */ 
	public IEnumerable<PRT> PRTs 
	{ 
		get
		{
			for (int rep = 0; rep < PRTRepetitionsUsed; rep++)
			{
				yield return (PRT)this.GetStructure("PRT", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRT
	///</summary>
	public PRT AddPRT()
	{
		return this.AddStructure("PRT") as PRT;
	}

	///<summary>
	///Removes the given PRT
	///</summary>
	public void RemovePRT(PRT toRemove)
	{
		this.RemoveStructure("PRT", toRemove);
	}

	///<summary>
	///Removes the PRT at the given index
	///</summary>
	public void RemovePRTAt(int index)
	{
		this.RemoveRepetition("PRT", index);
	}

	///<summary>
	/// Returns  first repetition of OPU_R25_PATIENT_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_PATIENT_OBSERVATION GetPATIENT_OBSERVATION() {
	   OPU_R25_PATIENT_OBSERVATION ret = null;
	   try {
	      ret = (OPU_R25_PATIENT_OBSERVATION)this.GetStructure("PATIENT_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_PATIENT_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_PATIENT_OBSERVATION GetPATIENT_OBSERVATION(int rep) { 
	   return (OPU_R25_PATIENT_OBSERVATION)this.GetStructure("PATIENT_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_PATIENT_OBSERVATION 
	 */ 
	public int PATIENT_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPU_R25_PATIENT_OBSERVATION results 
	 */ 
	public IEnumerable<OPU_R25_PATIENT_OBSERVATION> PATIENT_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENT_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_PATIENT_OBSERVATION)this.GetStructure("PATIENT_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_PATIENT_OBSERVATION
	///</summary>
	public OPU_R25_PATIENT_OBSERVATION AddPATIENT_OBSERVATION()
	{
		return this.AddStructure("PATIENT_OBSERVATION") as OPU_R25_PATIENT_OBSERVATION;
	}

	///<summary>
	///Removes the given OPU_R25_PATIENT_OBSERVATION
	///</summary>
	public void RemovePATIENT_OBSERVATION(OPU_R25_PATIENT_OBSERVATION toRemove)
	{
		this.RemoveStructure("PATIENT_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_PATIENT_OBSERVATION at the given index
	///</summary>
	public void RemovePATIENT_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("PATIENT_OBSERVATION", index);
	}

}
}
