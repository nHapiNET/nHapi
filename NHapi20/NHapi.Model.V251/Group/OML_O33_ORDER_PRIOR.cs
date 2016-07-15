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
///Represents the OML_O33_ORDER_PRIOR Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) optional </li>
///<li>1: OBR (Observation Request) </li>
///<li>2: NTE (Notes and Comments) optional repeating</li>
///<li>3: OML_O33_TIMING_PRIOR (a Group object) optional repeating</li>
///<li>4: OML_O33_OBSERVATION_PRIOR (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OML_O33_ORDER_PRIOR : AbstractGroup {

	///<summary> 
	/// Creates a new OML_O33_ORDER_PRIOR Group.
	///</summary>
	public OML_O33_ORDER_PRIOR(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(OML_O33_TIMING_PRIOR), false, true);
	      this.add(typeof(OML_O33_OBSERVATION_PRIOR), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OML_O33_ORDER_PRIOR - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE GetNTE() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE
	/// * (Notes and Comments) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE(int rep) { 
	   return (NTE)this.GetStructure("NTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE 
	 */ 
	public int NTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NTE results 
	 */ 
	public IEnumerable<NTE> NTEs 
	{ 
		get
		{
			for (int rep = 0; rep < NTERepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE()
	{
		return this.AddStructure("NTE") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE(NTE toRemove)
	{
		this.RemoveStructure("NTE", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTEAt(int index)
	{
		this.RemoveRepetition("NTE", index);
	}

	///<summary>
	/// Returns  first repetition of OML_O33_TIMING_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OML_O33_TIMING_PRIOR GetTIMING_PRIOR() {
	   OML_O33_TIMING_PRIOR ret = null;
	   try {
	      ret = (OML_O33_TIMING_PRIOR)this.GetStructure("TIMING_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O33_TIMING_PRIOR
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O33_TIMING_PRIOR GetTIMING_PRIOR(int rep) { 
	   return (OML_O33_TIMING_PRIOR)this.GetStructure("TIMING_PRIOR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O33_TIMING_PRIOR 
	 */ 
	public int TIMING_PRIORRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_PRIOR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OML_O33_TIMING_PRIOR results 
	 */ 
	public IEnumerable<OML_O33_TIMING_PRIOR> TIMING_PRIORs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_PRIORRepetitionsUsed; rep++)
			{
				yield return (OML_O33_TIMING_PRIOR)this.GetStructure("TIMING_PRIOR", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O33_TIMING_PRIOR
	///</summary>
	public OML_O33_TIMING_PRIOR AddTIMING_PRIOR()
	{
		return this.AddStructure("TIMING_PRIOR") as OML_O33_TIMING_PRIOR;
	}

	///<summary>
	///Removes the given OML_O33_TIMING_PRIOR
	///</summary>
	public void RemoveTIMING_PRIOR(OML_O33_TIMING_PRIOR toRemove)
	{
		this.RemoveStructure("TIMING_PRIOR", toRemove);
	}

	///<summary>
	///Removes the OML_O33_TIMING_PRIOR at the given index
	///</summary>
	public void RemoveTIMING_PRIORAt(int index)
	{
		this.RemoveRepetition("TIMING_PRIOR", index);
	}

	///<summary>
	/// Returns  first repetition of OML_O33_OBSERVATION_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OML_O33_OBSERVATION_PRIOR GetOBSERVATION_PRIOR() {
	   OML_O33_OBSERVATION_PRIOR ret = null;
	   try {
	      ret = (OML_O33_OBSERVATION_PRIOR)this.GetStructure("OBSERVATION_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O33_OBSERVATION_PRIOR
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O33_OBSERVATION_PRIOR GetOBSERVATION_PRIOR(int rep) { 
	   return (OML_O33_OBSERVATION_PRIOR)this.GetStructure("OBSERVATION_PRIOR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O33_OBSERVATION_PRIOR 
	 */ 
	public int OBSERVATION_PRIORRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION_PRIOR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OML_O33_OBSERVATION_PRIOR results 
	 */ 
	public IEnumerable<OML_O33_OBSERVATION_PRIOR> OBSERVATION_PRIORs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATION_PRIORRepetitionsUsed; rep++)
			{
				yield return (OML_O33_OBSERVATION_PRIOR)this.GetStructure("OBSERVATION_PRIOR", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O33_OBSERVATION_PRIOR
	///</summary>
	public OML_O33_OBSERVATION_PRIOR AddOBSERVATION_PRIOR()
	{
		return this.AddStructure("OBSERVATION_PRIOR") as OML_O33_OBSERVATION_PRIOR;
	}

	///<summary>
	///Removes the given OML_O33_OBSERVATION_PRIOR
	///</summary>
	public void RemoveOBSERVATION_PRIOR(OML_O33_OBSERVATION_PRIOR toRemove)
	{
		this.RemoveStructure("OBSERVATION_PRIOR", toRemove);
	}

	///<summary>
	///Removes the OML_O33_OBSERVATION_PRIOR at the given index
	///</summary>
	public void RemoveOBSERVATION_PRIORAt(int index)
	{
		this.RemoveRepetition("OBSERVATION_PRIOR", index);
	}

}
}
