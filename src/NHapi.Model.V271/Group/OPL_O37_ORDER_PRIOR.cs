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
///Represents the OPL_O37_ORDER_PRIOR Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: ORC (Common Order) optional </li>
///<li>2: PRT (Participation Information) optional repeating</li>
///<li>3: OPL_O37_TIMING (a Group object) optional </li>
///<li>4: OPL_O37_OBSERVATION_RESULT (a Group object) repeating</li>
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
	      this.add(typeof(OPL_O37_OBSERVATION_RESULT), true, true);
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
	/// Returns  first repetition of OPL_O37_OBSERVATION_RESULT (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_OBSERVATION_RESULT GetOBSERVATION_RESULT() {
	   OPL_O37_OBSERVATION_RESULT ret = null;
	   try {
	      ret = (OPL_O37_OBSERVATION_RESULT)this.GetStructure("OBSERVATION_RESULT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_OBSERVATION_RESULT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_OBSERVATION_RESULT GetOBSERVATION_RESULT(int rep) { 
	   return (OPL_O37_OBSERVATION_RESULT)this.GetStructure("OBSERVATION_RESULT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_OBSERVATION_RESULT 
	 */ 
	public int OBSERVATION_RESULTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION_RESULT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_OBSERVATION_RESULT results 
	 */ 
	public IEnumerable<OPL_O37_OBSERVATION_RESULT> OBSERVATION_RESULTs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATION_RESULTRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_OBSERVATION_RESULT)this.GetStructure("OBSERVATION_RESULT", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_OBSERVATION_RESULT
	///</summary>
	public OPL_O37_OBSERVATION_RESULT AddOBSERVATION_RESULT()
	{
		return this.AddStructure("OBSERVATION_RESULT") as OPL_O37_OBSERVATION_RESULT;
	}

	///<summary>
	///Removes the given OPL_O37_OBSERVATION_RESULT
	///</summary>
	public void RemoveOBSERVATION_RESULT(OPL_O37_OBSERVATION_RESULT toRemove)
	{
		this.RemoveStructure("OBSERVATION_RESULT", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_OBSERVATION_RESULT at the given index
	///</summary>
	public void RemoveOBSERVATION_RESULTAt(int index)
	{
		this.RemoveRepetition("OBSERVATION_RESULT", index);
	}

}
}
