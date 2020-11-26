using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the OPL_O37_ORDER_PRIOR Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: ORC (Common Order) optional </li>
///<li>2: PRT (Participation Information) optional repeating</li>
///<li>3: OPL_O37_TIMING (a Group object) optional </li>
///<li>4: OPL_O37_OBSERVATION_RESULT_GROUP (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPL_O37_ORDER_PRIOR : AbstractGroup {

	///<summary> 
	/// Creates a new OPL_O37_ORDER_PRIOR Group.
	///</summary>
	public OPL_O37_ORDER_PRIOR(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OPL_O37_TIMING), false, false);
	      this.add(typeof(OPL_O37_OBSERVATION_RESULT_GROUP), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPL_O37_ORDER_PRIOR - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OBR (Observation Request) - creates it if necessary
	///</summary>
	public OBR OBR { 
get{
	   OBR ret = null;
	   try {
	      ret = (OBR)this.GetStructure("OBR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
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
	/// Returns OPL_O37_TIMING (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_TIMING TIMING { 
get{
	   OPL_O37_TIMING ret = null;
	   try {
	      ret = (OPL_O37_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of OPL_O37_OBSERVATION_RESULT_GROUP (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_OBSERVATION_RESULT_GROUP GetOBSERVATION_RESULT_GROUP() {
	   OPL_O37_OBSERVATION_RESULT_GROUP ret = null;
	   try {
	      ret = (OPL_O37_OBSERVATION_RESULT_GROUP)this.GetStructure("OBSERVATION_RESULT_GROUP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_OBSERVATION_RESULT_GROUP
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_OBSERVATION_RESULT_GROUP GetOBSERVATION_RESULT_GROUP(int rep) { 
	   return (OPL_O37_OBSERVATION_RESULT_GROUP)this.GetStructure("OBSERVATION_RESULT_GROUP", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_OBSERVATION_RESULT_GROUP 
	 */ 
	public int OBSERVATION_RESULT_GROUPRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION_RESULT_GROUP").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_OBSERVATION_RESULT_GROUP results 
	 */ 
	public IEnumerable<OPL_O37_OBSERVATION_RESULT_GROUP> OBSERVATION_RESULT_GROUPs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATION_RESULT_GROUPRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_OBSERVATION_RESULT_GROUP)this.GetStructure("OBSERVATION_RESULT_GROUP", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_OBSERVATION_RESULT_GROUP
	///</summary>
	public OPL_O37_OBSERVATION_RESULT_GROUP AddOBSERVATION_RESULT_GROUP()
	{
		return this.AddStructure("OBSERVATION_RESULT_GROUP") as OPL_O37_OBSERVATION_RESULT_GROUP;
	}

	///<summary>
	///Removes the given OPL_O37_OBSERVATION_RESULT_GROUP
	///</summary>
	public void RemoveOBSERVATION_RESULT_GROUP(OPL_O37_OBSERVATION_RESULT_GROUP toRemove)
	{
		this.RemoveStructure("OBSERVATION_RESULT_GROUP", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_OBSERVATION_RESULT_GROUP at the given index
	///</summary>
	public void RemoveOBSERVATION_RESULT_GROUPAt(int index)
	{
		this.RemoveRepetition("OBSERVATION_RESULT_GROUP", index);
	}

}
}
