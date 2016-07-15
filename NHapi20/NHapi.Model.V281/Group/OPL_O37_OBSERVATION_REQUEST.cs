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
///Represents the OPL_O37_OBSERVATION_REQUEST Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: PRT (Participation Information) optional repeating</li>
///<li>2: OBR (Observation Request) </li>
///<li>3: PRT (Participation Information) optional repeating</li>
///<li>4: OPL_O37_TIMING (a Group object) optional repeating</li>
///<li>5: TCD (Test Code Detail) optional </li>
///<li>6: DG1 (Diagnosis) optional repeating</li>
///<li>7: OPL_O37_ORDER_RELATED_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPL_O37_OBSERVATION_REQUEST : AbstractGroup {

	///<summary> 
	/// Creates a new OPL_O37_OBSERVATION_REQUEST Group.
	///</summary>
	public OPL_O37_OBSERVATION_REQUEST(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OPL_O37_TIMING), false, true);
	      this.add(typeof(TCD), false, false);
	      this.add(typeof(DG1), false, true);
	      this.add(typeof(OPL_O37_ORDER_RELATED_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPL_O37_OBSERVATION_REQUEST - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of PRT2 (Participation Information) - creates it if necessary
	///</summary>
	public PRT GetPRT2() {
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRT2
	/// * (Participation Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRT GetPRT2(int rep) { 
	   return (PRT)this.GetStructure("PRT2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRT2 
	 */ 
	public int PRT2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRT2").Length; 
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
	public IEnumerable<PRT> PRT2s 
	{ 
		get
		{
			for (int rep = 0; rep < PRT2RepetitionsUsed; rep++)
			{
				yield return (PRT)this.GetStructure("PRT2", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRT
	///</summary>
	public PRT AddPRT2()
	{
		return this.AddStructure("PRT2") as PRT;
	}

	///<summary>
	///Removes the given PRT
	///</summary>
	public void RemovePRT2(PRT toRemove)
	{
		this.RemoveStructure("PRT2", toRemove);
	}

	///<summary>
	///Removes the PRT at the given index
	///</summary>
	public void RemovePRT2At(int index)
	{
		this.RemoveRepetition("PRT2", index);
	}

	///<summary>
	/// Returns  first repetition of OPL_O37_TIMING (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_TIMING GetTIMING() {
	   OPL_O37_TIMING ret = null;
	   try {
	      ret = (OPL_O37_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_TIMING GetTIMING(int rep) { 
	   return (OPL_O37_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_TIMING 
	 */ 
	public int TIMINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_TIMING results 
	 */ 
	public IEnumerable<OPL_O37_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_TIMING
	///</summary>
	public OPL_O37_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as OPL_O37_TIMING;
	}

	///<summary>
	///Removes the given OPL_O37_TIMING
	///</summary>
	public void RemoveTIMING(OPL_O37_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

	///<summary>
	/// Returns TCD (Test Code Detail) - creates it if necessary
	///</summary>
	public TCD TCD { 
get{
	   TCD ret = null;
	   try {
	      ret = (TCD)this.GetStructure("TCD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DG1 (Diagnosis) - creates it if necessary
	///</summary>
	public DG1 GetDG1() {
	   DG1 ret = null;
	   try {
	      ret = (DG1)this.GetStructure("DG1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DG1
	/// * (Diagnosis) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DG1 GetDG1(int rep) { 
	   return (DG1)this.GetStructure("DG1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DG1 
	 */ 
	public int DG1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DG1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DG1 results 
	 */ 
	public IEnumerable<DG1> DG1s 
	{ 
		get
		{
			for (int rep = 0; rep < DG1RepetitionsUsed; rep++)
			{
				yield return (DG1)this.GetStructure("DG1", rep);
			}
		}
	}

	///<summary>
	///Adds a new DG1
	///</summary>
	public DG1 AddDG1()
	{
		return this.AddStructure("DG1") as DG1;
	}

	///<summary>
	///Removes the given DG1
	///</summary>
	public void RemoveDG1(DG1 toRemove)
	{
		this.RemoveStructure("DG1", toRemove);
	}

	///<summary>
	///Removes the DG1 at the given index
	///</summary>
	public void RemoveDG1At(int index)
	{
		this.RemoveRepetition("DG1", index);
	}

	///<summary>
	/// Returns  first repetition of OPL_O37_ORDER_RELATED_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_ORDER_RELATED_OBSERVATION GetORDER_RELATED_OBSERVATION() {
	   OPL_O37_ORDER_RELATED_OBSERVATION ret = null;
	   try {
	      ret = (OPL_O37_ORDER_RELATED_OBSERVATION)this.GetStructure("ORDER_RELATED_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_ORDER_RELATED_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_ORDER_RELATED_OBSERVATION GetORDER_RELATED_OBSERVATION(int rep) { 
	   return (OPL_O37_ORDER_RELATED_OBSERVATION)this.GetStructure("ORDER_RELATED_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_ORDER_RELATED_OBSERVATION 
	 */ 
	public int ORDER_RELATED_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_RELATED_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_ORDER_RELATED_OBSERVATION results 
	 */ 
	public IEnumerable<OPL_O37_ORDER_RELATED_OBSERVATION> ORDER_RELATED_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDER_RELATED_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_ORDER_RELATED_OBSERVATION)this.GetStructure("ORDER_RELATED_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_ORDER_RELATED_OBSERVATION
	///</summary>
	public OPL_O37_ORDER_RELATED_OBSERVATION AddORDER_RELATED_OBSERVATION()
	{
		return this.AddStructure("ORDER_RELATED_OBSERVATION") as OPL_O37_ORDER_RELATED_OBSERVATION;
	}

	///<summary>
	///Removes the given OPL_O37_ORDER_RELATED_OBSERVATION
	///</summary>
	public void RemoveORDER_RELATED_OBSERVATION(OPL_O37_ORDER_RELATED_OBSERVATION toRemove)
	{
		this.RemoveStructure("ORDER_RELATED_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_ORDER_RELATED_OBSERVATION at the given index
	///</summary>
	public void RemoveORDER_RELATED_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("ORDER_RELATED_OBSERVATION", index);
	}

}
}
