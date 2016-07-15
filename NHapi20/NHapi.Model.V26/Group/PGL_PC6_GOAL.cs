using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the PGL_PC6_GOAL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: GOL (Goal Detail) </li>
///<li>1: NTE (Notes and Comments) optional repeating</li>
///<li>2: VAR (Variance) optional repeating</li>
///<li>3: PGL_PC6_GOAL_ROLE (a Group object) optional repeating</li>
///<li>4: PGL_PC6_PATHWAY (a Group object) optional repeating</li>
///<li>5: PGL_PC6_OBSERVATION (a Group object) optional repeating</li>
///<li>6: PGL_PC6_PROBLEM (a Group object) optional repeating</li>
///<li>7: PGL_PC6_ORDER (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class PGL_PC6_GOAL : AbstractGroup {

	///<summary> 
	/// Creates a new PGL_PC6_GOAL Group.
	///</summary>
	public PGL_PC6_GOAL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(GOL), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(VAR), false, true);
	      this.add(typeof(PGL_PC6_GOAL_ROLE), false, true);
	      this.add(typeof(PGL_PC6_PATHWAY), false, true);
	      this.add(typeof(PGL_PC6_OBSERVATION), false, true);
	      this.add(typeof(PGL_PC6_PROBLEM), false, true);
	      this.add(typeof(PGL_PC6_ORDER), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PGL_PC6_GOAL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns GOL (Goal Detail) - creates it if necessary
	///</summary>
	public GOL GOL { 
get{
	   GOL ret = null;
	   try {
	      ret = (GOL)this.GetStructure("GOL");
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
	/// Returns  first repetition of PGL_PC6_GOAL_ROLE (a Group object) - creates it if necessary
	///</summary>
	public PGL_PC6_GOAL_ROLE GetGOAL_ROLE() {
	   PGL_PC6_GOAL_ROLE ret = null;
	   try {
	      ret = (PGL_PC6_GOAL_ROLE)this.GetStructure("GOAL_ROLE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PGL_PC6_GOAL_ROLE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PGL_PC6_GOAL_ROLE GetGOAL_ROLE(int rep) { 
	   return (PGL_PC6_GOAL_ROLE)this.GetStructure("GOAL_ROLE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PGL_PC6_GOAL_ROLE 
	 */ 
	public int GOAL_ROLERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GOAL_ROLE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PGL_PC6_GOAL_ROLE results 
	 */ 
	public IEnumerable<PGL_PC6_GOAL_ROLE> GOAL_ROLEs 
	{ 
		get
		{
			for (int rep = 0; rep < GOAL_ROLERepetitionsUsed; rep++)
			{
				yield return (PGL_PC6_GOAL_ROLE)this.GetStructure("GOAL_ROLE", rep);
			}
		}
	}

	///<summary>
	///Adds a new PGL_PC6_GOAL_ROLE
	///</summary>
	public PGL_PC6_GOAL_ROLE AddGOAL_ROLE()
	{
		return this.AddStructure("GOAL_ROLE") as PGL_PC6_GOAL_ROLE;
	}

	///<summary>
	///Removes the given PGL_PC6_GOAL_ROLE
	///</summary>
	public void RemoveGOAL_ROLE(PGL_PC6_GOAL_ROLE toRemove)
	{
		this.RemoveStructure("GOAL_ROLE", toRemove);
	}

	///<summary>
	///Removes the PGL_PC6_GOAL_ROLE at the given index
	///</summary>
	public void RemoveGOAL_ROLEAt(int index)
	{
		this.RemoveRepetition("GOAL_ROLE", index);
	}

	///<summary>
	/// Returns  first repetition of PGL_PC6_PATHWAY (a Group object) - creates it if necessary
	///</summary>
	public PGL_PC6_PATHWAY GetPATHWAY() {
	   PGL_PC6_PATHWAY ret = null;
	   try {
	      ret = (PGL_PC6_PATHWAY)this.GetStructure("PATHWAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PGL_PC6_PATHWAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PGL_PC6_PATHWAY GetPATHWAY(int rep) { 
	   return (PGL_PC6_PATHWAY)this.GetStructure("PATHWAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PGL_PC6_PATHWAY 
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
	 * Enumerate over the PGL_PC6_PATHWAY results 
	 */ 
	public IEnumerable<PGL_PC6_PATHWAY> PATHWAYs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAYRepetitionsUsed; rep++)
			{
				yield return (PGL_PC6_PATHWAY)this.GetStructure("PATHWAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new PGL_PC6_PATHWAY
	///</summary>
	public PGL_PC6_PATHWAY AddPATHWAY()
	{
		return this.AddStructure("PATHWAY") as PGL_PC6_PATHWAY;
	}

	///<summary>
	///Removes the given PGL_PC6_PATHWAY
	///</summary>
	public void RemovePATHWAY(PGL_PC6_PATHWAY toRemove)
	{
		this.RemoveStructure("PATHWAY", toRemove);
	}

	///<summary>
	///Removes the PGL_PC6_PATHWAY at the given index
	///</summary>
	public void RemovePATHWAYAt(int index)
	{
		this.RemoveRepetition("PATHWAY", index);
	}

	///<summary>
	/// Returns  first repetition of PGL_PC6_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public PGL_PC6_OBSERVATION GetOBSERVATION() {
	   PGL_PC6_OBSERVATION ret = null;
	   try {
	      ret = (PGL_PC6_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PGL_PC6_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PGL_PC6_OBSERVATION GetOBSERVATION(int rep) { 
	   return (PGL_PC6_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PGL_PC6_OBSERVATION 
	 */ 
	public int OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PGL_PC6_OBSERVATION results 
	 */ 
	public IEnumerable<PGL_PC6_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (PGL_PC6_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new PGL_PC6_OBSERVATION
	///</summary>
	public PGL_PC6_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as PGL_PC6_OBSERVATION;
	}

	///<summary>
	///Removes the given PGL_PC6_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(PGL_PC6_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the PGL_PC6_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of PGL_PC6_PROBLEM (a Group object) - creates it if necessary
	///</summary>
	public PGL_PC6_PROBLEM GetPROBLEM() {
	   PGL_PC6_PROBLEM ret = null;
	   try {
	      ret = (PGL_PC6_PROBLEM)this.GetStructure("PROBLEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PGL_PC6_PROBLEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PGL_PC6_PROBLEM GetPROBLEM(int rep) { 
	   return (PGL_PC6_PROBLEM)this.GetStructure("PROBLEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PGL_PC6_PROBLEM 
	 */ 
	public int PROBLEMRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROBLEM").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PGL_PC6_PROBLEM results 
	 */ 
	public IEnumerable<PGL_PC6_PROBLEM> PROBLEMs 
	{ 
		get
		{
			for (int rep = 0; rep < PROBLEMRepetitionsUsed; rep++)
			{
				yield return (PGL_PC6_PROBLEM)this.GetStructure("PROBLEM", rep);
			}
		}
	}

	///<summary>
	///Adds a new PGL_PC6_PROBLEM
	///</summary>
	public PGL_PC6_PROBLEM AddPROBLEM()
	{
		return this.AddStructure("PROBLEM") as PGL_PC6_PROBLEM;
	}

	///<summary>
	///Removes the given PGL_PC6_PROBLEM
	///</summary>
	public void RemovePROBLEM(PGL_PC6_PROBLEM toRemove)
	{
		this.RemoveStructure("PROBLEM", toRemove);
	}

	///<summary>
	///Removes the PGL_PC6_PROBLEM at the given index
	///</summary>
	public void RemovePROBLEMAt(int index)
	{
		this.RemoveRepetition("PROBLEM", index);
	}

	///<summary>
	/// Returns  first repetition of PGL_PC6_ORDER (a Group object) - creates it if necessary
	///</summary>
	public PGL_PC6_ORDER GetORDER() {
	   PGL_PC6_ORDER ret = null;
	   try {
	      ret = (PGL_PC6_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PGL_PC6_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PGL_PC6_ORDER GetORDER(int rep) { 
	   return (PGL_PC6_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PGL_PC6_ORDER 
	 */ 
	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PGL_PC6_ORDER results 
	 */ 
	public IEnumerable<PGL_PC6_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (PGL_PC6_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new PGL_PC6_ORDER
	///</summary>
	public PGL_PC6_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as PGL_PC6_ORDER;
	}

	///<summary>
	///Removes the given PGL_PC6_ORDER
	///</summary>
	public void RemoveORDER(PGL_PC6_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the PGL_PC6_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
