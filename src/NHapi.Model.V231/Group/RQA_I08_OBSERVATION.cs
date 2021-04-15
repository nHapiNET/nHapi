using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the RQA_I08_OBSERVATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (OBR - observation request segment) </li>
///<li>1: NTE (NTE - notes and comments segment) optional repeating</li>
///<li>2: RQA_I08_RESULTS (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RQA_I08_OBSERVATION : AbstractGroup {

	///<summary> 
	/// Creates a new RQA_I08_OBSERVATION Group.
	///</summary>
	public RQA_I08_OBSERVATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(RQA_I08_RESULTS), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RQA_I08_OBSERVATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OBR (OBR - observation request segment) - creates it if necessary
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
	/// Returns  first repetition of NTE (NTE - notes and comments segment) - creates it if necessary
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
	/// * (NTE - notes and comments segment) - creates it if necessary
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
	/// Returns  first repetition of RQA_I08_RESULTS (a Group object) - creates it if necessary
	///</summary>
	public RQA_I08_RESULTS GetRESULTS() {
	   RQA_I08_RESULTS ret = null;
	   try {
	      ret = (RQA_I08_RESULTS)this.GetStructure("RESULTS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RQA_I08_RESULTS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RQA_I08_RESULTS GetRESULTS(int rep) { 
	   return (RQA_I08_RESULTS)this.GetStructure("RESULTS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RQA_I08_RESULTS 
	 */ 
	public int RESULTSRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESULTS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RQA_I08_RESULTS results 
	 */ 
	public IEnumerable<RQA_I08_RESULTS> RESULTSs 
	{ 
		get
		{
			for (int rep = 0; rep < RESULTSRepetitionsUsed; rep++)
			{
				yield return (RQA_I08_RESULTS)this.GetStructure("RESULTS", rep);
			}
		}
	}

	///<summary>
	///Adds a new RQA_I08_RESULTS
	///</summary>
	public RQA_I08_RESULTS AddRESULTS()
	{
		return this.AddStructure("RESULTS") as RQA_I08_RESULTS;
	}

	///<summary>
	///Removes the given RQA_I08_RESULTS
	///</summary>
	public void RemoveRESULTS(RQA_I08_RESULTS toRemove)
	{
		this.RemoveStructure("RESULTS", toRemove);
	}

	///<summary>
	///Removes the RQA_I08_RESULTS at the given index
	///</summary>
	public void RemoveRESULTSAt(int index)
	{
		this.RemoveRepetition("RESULTS", index);
	}

}
}
