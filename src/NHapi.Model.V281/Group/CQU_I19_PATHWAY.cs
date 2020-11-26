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
///Represents the CQU_I19_PATHWAY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PTH (Pathway) </li>
///<li>1: VAR (Variance) optional repeating</li>
///<li>2: CQU_I19_ROLE_PATHWAY (a Group object) optional repeating</li>
///<li>3: CQU_I19_PATHWAY_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CQU_I19_PATHWAY : AbstractGroup {

	///<summary> 
	/// Creates a new CQU_I19_PATHWAY Group.
	///</summary>
	public CQU_I19_PATHWAY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PTH), true, false);
	      this.add(typeof(VAR), false, true);
	      this.add(typeof(CQU_I19_ROLE_PATHWAY), false, true);
	      this.add(typeof(CQU_I19_PATHWAY_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CQU_I19_PATHWAY - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of CQU_I19_ROLE_PATHWAY (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_ROLE_PATHWAY GetROLE_PATHWAY() {
	   CQU_I19_ROLE_PATHWAY ret = null;
	   try {
	      ret = (CQU_I19_ROLE_PATHWAY)this.GetStructure("ROLE_PATHWAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_ROLE_PATHWAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_ROLE_PATHWAY GetROLE_PATHWAY(int rep) { 
	   return (CQU_I19_ROLE_PATHWAY)this.GetStructure("ROLE_PATHWAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_ROLE_PATHWAY 
	 */ 
	public int ROLE_PATHWAYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROLE_PATHWAY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_ROLE_PATHWAY results 
	 */ 
	public IEnumerable<CQU_I19_ROLE_PATHWAY> ROLE_PATHWAYs 
	{ 
		get
		{
			for (int rep = 0; rep < ROLE_PATHWAYRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_ROLE_PATHWAY)this.GetStructure("ROLE_PATHWAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_ROLE_PATHWAY
	///</summary>
	public CQU_I19_ROLE_PATHWAY AddROLE_PATHWAY()
	{
		return this.AddStructure("ROLE_PATHWAY") as CQU_I19_ROLE_PATHWAY;
	}

	///<summary>
	///Removes the given CQU_I19_ROLE_PATHWAY
	///</summary>
	public void RemoveROLE_PATHWAY(CQU_I19_ROLE_PATHWAY toRemove)
	{
		this.RemoveStructure("ROLE_PATHWAY", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_ROLE_PATHWAY at the given index
	///</summary>
	public void RemoveROLE_PATHWAYAt(int index)
	{
		this.RemoveRepetition("ROLE_PATHWAY", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_PATHWAY_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_PATHWAY_OBSERVATION GetPATHWAY_OBSERVATION() {
	   CQU_I19_PATHWAY_OBSERVATION ret = null;
	   try {
	      ret = (CQU_I19_PATHWAY_OBSERVATION)this.GetStructure("PATHWAY_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_PATHWAY_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_PATHWAY_OBSERVATION GetPATHWAY_OBSERVATION(int rep) { 
	   return (CQU_I19_PATHWAY_OBSERVATION)this.GetStructure("PATHWAY_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_PATHWAY_OBSERVATION 
	 */ 
	public int PATHWAY_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATHWAY_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_PATHWAY_OBSERVATION results 
	 */ 
	public IEnumerable<CQU_I19_PATHWAY_OBSERVATION> PATHWAY_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAY_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_PATHWAY_OBSERVATION)this.GetStructure("PATHWAY_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_PATHWAY_OBSERVATION
	///</summary>
	public CQU_I19_PATHWAY_OBSERVATION AddPATHWAY_OBSERVATION()
	{
		return this.AddStructure("PATHWAY_OBSERVATION") as CQU_I19_PATHWAY_OBSERVATION;
	}

	///<summary>
	///Removes the given CQU_I19_PATHWAY_OBSERVATION
	///</summary>
	public void RemovePATHWAY_OBSERVATION(CQU_I19_PATHWAY_OBSERVATION toRemove)
	{
		this.RemoveStructure("PATHWAY_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_PATHWAY_OBSERVATION at the given index
	///</summary>
	public void RemovePATHWAY_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("PATHWAY_OBSERVATION", index);
	}

}
}
