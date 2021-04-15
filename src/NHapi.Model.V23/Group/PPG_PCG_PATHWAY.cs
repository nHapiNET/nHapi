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
///Represents the PPG_PCG_PATHWAY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PTH (Pathway) </li>
///<li>1: NTE (Notes and comments segment) optional repeating</li>
///<li>2: VAR (Variance) optional repeating</li>
///<li>3: PPG_PCG_PATHWAY_ROLE (a Group object) optional repeating</li>
///<li>4: PPG_PCG_GOAL (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class PPG_PCG_PATHWAY : AbstractGroup {

	///<summary> 
	/// Creates a new PPG_PCG_PATHWAY Group.
	///</summary>
	public PPG_PCG_PATHWAY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PTH), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(VAR), false, true);
	      this.add(typeof(PPG_PCG_PATHWAY_ROLE), false, true);
	      this.add(typeof(PPG_PCG_GOAL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PPG_PCG_PATHWAY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PTH (Pathway) - creates it if necessary
	///</summary>
	public PTH PTH { 
get{
	   PTH ret = null;
	   try {
	      ret = (PTH)this.GetStructure("PTH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE (Notes and comments segment) - creates it if necessary
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
	/// * (Notes and comments segment) - creates it if necessary
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
	/// Returns  first repetition of VAR (Variance) - creates it if necessary
	///</summary>
	public VAR GetVAR() {
	   VAR ret = null;
	   try {
	      ret = (VAR)this.GetStructure("VAR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of VAR
	/// * (Variance) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public VAR GetVAR(int rep) { 
	   return (VAR)this.GetStructure("VAR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of VAR 
	 */ 
	public int VARRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("VAR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the VAR results 
	 */ 
	public IEnumerable<VAR> VARs 
	{ 
		get
		{
			for (int rep = 0; rep < VARRepetitionsUsed; rep++)
			{
				yield return (VAR)this.GetStructure("VAR", rep);
			}
		}
	}

	///<summary>
	///Adds a new VAR
	///</summary>
	public VAR AddVAR()
	{
		return this.AddStructure("VAR") as VAR;
	}

	///<summary>
	///Removes the given VAR
	///</summary>
	public void RemoveVAR(VAR toRemove)
	{
		this.RemoveStructure("VAR", toRemove);
	}

	///<summary>
	///Removes the VAR at the given index
	///</summary>
	public void RemoveVARAt(int index)
	{
		this.RemoveRepetition("VAR", index);
	}

	///<summary>
	/// Returns  first repetition of PPG_PCG_PATHWAY_ROLE (a Group object) - creates it if necessary
	///</summary>
	public PPG_PCG_PATHWAY_ROLE GetPATHWAY_ROLE() {
	   PPG_PCG_PATHWAY_ROLE ret = null;
	   try {
	      ret = (PPG_PCG_PATHWAY_ROLE)this.GetStructure("PATHWAY_ROLE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PPG_PCG_PATHWAY_ROLE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PPG_PCG_PATHWAY_ROLE GetPATHWAY_ROLE(int rep) { 
	   return (PPG_PCG_PATHWAY_ROLE)this.GetStructure("PATHWAY_ROLE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PPG_PCG_PATHWAY_ROLE 
	 */ 
	public int PATHWAY_ROLERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATHWAY_ROLE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PPG_PCG_PATHWAY_ROLE results 
	 */ 
	public IEnumerable<PPG_PCG_PATHWAY_ROLE> PATHWAY_ROLEs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAY_ROLERepetitionsUsed; rep++)
			{
				yield return (PPG_PCG_PATHWAY_ROLE)this.GetStructure("PATHWAY_ROLE", rep);
			}
		}
	}

	///<summary>
	///Adds a new PPG_PCG_PATHWAY_ROLE
	///</summary>
	public PPG_PCG_PATHWAY_ROLE AddPATHWAY_ROLE()
	{
		return this.AddStructure("PATHWAY_ROLE") as PPG_PCG_PATHWAY_ROLE;
	}

	///<summary>
	///Removes the given PPG_PCG_PATHWAY_ROLE
	///</summary>
	public void RemovePATHWAY_ROLE(PPG_PCG_PATHWAY_ROLE toRemove)
	{
		this.RemoveStructure("PATHWAY_ROLE", toRemove);
	}

	///<summary>
	///Removes the PPG_PCG_PATHWAY_ROLE at the given index
	///</summary>
	public void RemovePATHWAY_ROLEAt(int index)
	{
		this.RemoveRepetition("PATHWAY_ROLE", index);
	}

	///<summary>
	/// Returns  first repetition of PPG_PCG_GOAL (a Group object) - creates it if necessary
	///</summary>
	public PPG_PCG_GOAL GetGOAL() {
	   PPG_PCG_GOAL ret = null;
	   try {
	      ret = (PPG_PCG_GOAL)this.GetStructure("GOAL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PPG_PCG_GOAL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PPG_PCG_GOAL GetGOAL(int rep) { 
	   return (PPG_PCG_GOAL)this.GetStructure("GOAL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PPG_PCG_GOAL 
	 */ 
	public int GOALRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GOAL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PPG_PCG_GOAL results 
	 */ 
	public IEnumerable<PPG_PCG_GOAL> GOALs 
	{ 
		get
		{
			for (int rep = 0; rep < GOALRepetitionsUsed; rep++)
			{
				yield return (PPG_PCG_GOAL)this.GetStructure("GOAL", rep);
			}
		}
	}

	///<summary>
	///Adds a new PPG_PCG_GOAL
	///</summary>
	public PPG_PCG_GOAL AddGOAL()
	{
		return this.AddStructure("GOAL") as PPG_PCG_GOAL;
	}

	///<summary>
	///Removes the given PPG_PCG_GOAL
	///</summary>
	public void RemoveGOAL(PPG_PCG_GOAL toRemove)
	{
		this.RemoveStructure("GOAL", toRemove);
	}

	///<summary>
	///Removes the PPG_PCG_GOAL at the given index
	///</summary>
	public void RemoveGOALAt(int index)
	{
		this.RemoveRepetition("GOAL", index);
	}

}
}
