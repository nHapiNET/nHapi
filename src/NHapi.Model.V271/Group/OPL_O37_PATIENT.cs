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
///Represents the OPL_O37_PATIENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (Patient Identification) </li>
///<li>1: PD1 (Patient Additional Demographic) optional </li>
///<li>2: PRT (Participation Information) optional repeating</li>
///<li>3: OPL_O37_OBSERVATIONS_ON_PATIENT (a Group object) optional repeating</li>
///<li>4: OPL_O37_INSURANCE (a Group object) optional repeating</li>
///<li>5: AL1 (Patient Allergy Information) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPL_O37_PATIENT : AbstractGroup {

	///<summary> 
	/// Creates a new OPL_O37_PATIENT Group.
	///</summary>
	public OPL_O37_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PD1), false, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OPL_O37_OBSERVATIONS_ON_PATIENT), false, true);
	      this.add(typeof(OPL_O37_INSURANCE), false, true);
	      this.add(typeof(AL1), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPL_O37_PATIENT - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OPL_O37_OBSERVATIONS_ON_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_OBSERVATIONS_ON_PATIENT GetOBSERVATIONS_ON_PATIENT() {
	   OPL_O37_OBSERVATIONS_ON_PATIENT ret = null;
	   try {
	      ret = (OPL_O37_OBSERVATIONS_ON_PATIENT)this.GetStructure("OBSERVATIONS_ON_PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_OBSERVATIONS_ON_PATIENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_OBSERVATIONS_ON_PATIENT GetOBSERVATIONS_ON_PATIENT(int rep) { 
	   return (OPL_O37_OBSERVATIONS_ON_PATIENT)this.GetStructure("OBSERVATIONS_ON_PATIENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_OBSERVATIONS_ON_PATIENT 
	 */ 
	public int OBSERVATIONS_ON_PATIENTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATIONS_ON_PATIENT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_OBSERVATIONS_ON_PATIENT results 
	 */ 
	public IEnumerable<OPL_O37_OBSERVATIONS_ON_PATIENT> OBSERVATIONS_ON_PATIENTs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONS_ON_PATIENTRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_OBSERVATIONS_ON_PATIENT)this.GetStructure("OBSERVATIONS_ON_PATIENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_OBSERVATIONS_ON_PATIENT
	///</summary>
	public OPL_O37_OBSERVATIONS_ON_PATIENT AddOBSERVATIONS_ON_PATIENT()
	{
		return this.AddStructure("OBSERVATIONS_ON_PATIENT") as OPL_O37_OBSERVATIONS_ON_PATIENT;
	}

	///<summary>
	///Removes the given OPL_O37_OBSERVATIONS_ON_PATIENT
	///</summary>
	public void RemoveOBSERVATIONS_ON_PATIENT(OPL_O37_OBSERVATIONS_ON_PATIENT toRemove)
	{
		this.RemoveStructure("OBSERVATIONS_ON_PATIENT", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_OBSERVATIONS_ON_PATIENT at the given index
	///</summary>
	public void RemoveOBSERVATIONS_ON_PATIENTAt(int index)
	{
		this.RemoveRepetition("OBSERVATIONS_ON_PATIENT", index);
	}

	///<summary>
	/// Returns  first repetition of OPL_O37_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_INSURANCE GetINSURANCE() {
	   OPL_O37_INSURANCE ret = null;
	   try {
	      ret = (OPL_O37_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_INSURANCE GetINSURANCE(int rep) { 
	   return (OPL_O37_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_INSURANCE 
	 */ 
	public int INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_INSURANCE results 
	 */ 
	public IEnumerable<OPL_O37_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (OPL_O37_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_INSURANCE
	///</summary>
	public OPL_O37_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as OPL_O37_INSURANCE;
	}

	///<summary>
	///Removes the given OPL_O37_INSURANCE
	///</summary>
	public void RemoveINSURANCE(OPL_O37_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

	///<summary>
	/// Returns  first repetition of AL1 (Patient Allergy Information) - creates it if necessary
	///</summary>
	public AL1 GetAL1() {
	   AL1 ret = null;
	   try {
	      ret = (AL1)this.GetStructure("AL1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of AL1
	/// * (Patient Allergy Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public AL1 GetAL1(int rep) { 
	   return (AL1)this.GetStructure("AL1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of AL1 
	 */ 
	public int AL1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("AL1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the AL1 results 
	 */ 
	public IEnumerable<AL1> AL1s 
	{ 
		get
		{
			for (int rep = 0; rep < AL1RepetitionsUsed; rep++)
			{
				yield return (AL1)this.GetStructure("AL1", rep);
			}
		}
	}

	///<summary>
	///Adds a new AL1
	///</summary>
	public AL1 AddAL1()
	{
		return this.AddStructure("AL1") as AL1;
	}

	///<summary>
	///Removes the given AL1
	///</summary>
	public void RemoveAL1(AL1 toRemove)
	{
		this.RemoveStructure("AL1", toRemove);
	}

	///<summary>
	///Removes the AL1 at the given index
	///</summary>
	public void RemoveAL1At(int index)
	{
		this.RemoveRepetition("AL1", index);
	}

}
}
