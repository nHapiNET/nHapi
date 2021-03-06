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
///Represents the RRI_I12_OBSERVATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (OBR - observation request segment) </li>
///<li>1: NTE (NTE - notes and comments segment) optional repeating</li>
///<li>2: RRI_I12_RESULTS_NOTES (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RRI_I12_OBSERVATION : AbstractGroup {

	///<summary> 
	/// Creates a new RRI_I12_OBSERVATION Group.
	///</summary>
	public RRI_I12_OBSERVATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(RRI_I12_RESULTS_NOTES), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRI_I12_OBSERVATION - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RRI_I12_RESULTS_NOTES (a Group object) - creates it if necessary
	///</summary>
	public RRI_I12_RESULTS_NOTES GetRESULTS_NOTES() {
	   RRI_I12_RESULTS_NOTES ret = null;
	   try {
	      ret = (RRI_I12_RESULTS_NOTES)this.GetStructure("RESULTS_NOTES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RRI_I12_RESULTS_NOTES
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RRI_I12_RESULTS_NOTES GetRESULTS_NOTES(int rep) { 
	   return (RRI_I12_RESULTS_NOTES)this.GetStructure("RESULTS_NOTES", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RRI_I12_RESULTS_NOTES 
	 */ 
	public int RESULTS_NOTESRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESULTS_NOTES").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RRI_I12_RESULTS_NOTES results 
	 */ 
	public IEnumerable<RRI_I12_RESULTS_NOTES> RESULTS_NOTESs 
	{ 
		get
		{
			for (int rep = 0; rep < RESULTS_NOTESRepetitionsUsed; rep++)
			{
				yield return (RRI_I12_RESULTS_NOTES)this.GetStructure("RESULTS_NOTES", rep);
			}
		}
	}

	///<summary>
	///Adds a new RRI_I12_RESULTS_NOTES
	///</summary>
	public RRI_I12_RESULTS_NOTES AddRESULTS_NOTES()
	{
		return this.AddStructure("RESULTS_NOTES") as RRI_I12_RESULTS_NOTES;
	}

	///<summary>
	///Removes the given RRI_I12_RESULTS_NOTES
	///</summary>
	public void RemoveRESULTS_NOTES(RRI_I12_RESULTS_NOTES toRemove)
	{
		this.RemoveStructure("RESULTS_NOTES", toRemove);
	}

	///<summary>
	///Removes the RRI_I12_RESULTS_NOTES at the given index
	///</summary>
	public void RemoveRESULTS_NOTESAt(int index)
	{
		this.RemoveRepetition("RESULTS_NOTES", index);
	}

}
}
