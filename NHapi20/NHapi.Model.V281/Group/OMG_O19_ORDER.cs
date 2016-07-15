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
///Represents the OMG_O19_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: PRT (Participation Information) optional repeating</li>
///<li>2: OMG_O19_TIMING (a Group object) optional repeating</li>
///<li>3: OBR (Observation Request) </li>
///<li>4: NTE (Notes and Comments) optional repeating</li>
///<li>5: PRT (Participation Information) optional repeating</li>
///<li>6: CTD (Contact Data) optional </li>
///<li>7: DG1 (Diagnosis) optional repeating</li>
///<li>8: OMG_O19_OBSERVATION (a Group object) optional repeating</li>
///<li>9: OMG_O19_SPECIMEN (a Group object) optional repeating</li>
///<li>10: OMG_O19_PRIOR_RESULT (a Group object) optional repeating</li>
///<li>11: FT1 (Financial Transaction) optional repeating</li>
///<li>12: CTI (Clinical Trial Identification) optional repeating</li>
///<li>13: BLG (Billing) optional </li>
///</ol>
///</summary>
[Serializable]
public class OMG_O19_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new OMG_O19_ORDER Group.
	///</summary>
	public OMG_O19_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OMG_O19_TIMING), false, true);
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(CTD), false, false);
	      this.add(typeof(DG1), false, true);
	      this.add(typeof(OMG_O19_OBSERVATION), false, true);
	      this.add(typeof(OMG_O19_SPECIMEN), false, true);
	      this.add(typeof(OMG_O19_PRIOR_RESULT), false, true);
	      this.add(typeof(FT1), false, true);
	      this.add(typeof(CTI), false, true);
	      this.add(typeof(BLG), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OMG_O19_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OMG_O19_TIMING (a Group object) - creates it if necessary
	///</summary>
	public OMG_O19_TIMING GetTIMING() {
	   OMG_O19_TIMING ret = null;
	   try {
	      ret = (OMG_O19_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMG_O19_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMG_O19_TIMING GetTIMING(int rep) { 
	   return (OMG_O19_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMG_O19_TIMING 
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
	 * Enumerate over the OMG_O19_TIMING results 
	 */ 
	public IEnumerable<OMG_O19_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (OMG_O19_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMG_O19_TIMING
	///</summary>
	public OMG_O19_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as OMG_O19_TIMING;
	}

	///<summary>
	///Removes the given OMG_O19_TIMING
	///</summary>
	public void RemoveTIMING(OMG_O19_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the OMG_O19_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
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
	/// Returns CTD (Contact Data) - creates it if necessary
	///</summary>
	public CTD CTD { 
get{
	   CTD ret = null;
	   try {
	      ret = (CTD)this.GetStructure("CTD");
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
	/// Returns  first repetition of OMG_O19_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OMG_O19_OBSERVATION GetOBSERVATION() {
	   OMG_O19_OBSERVATION ret = null;
	   try {
	      ret = (OMG_O19_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMG_O19_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMG_O19_OBSERVATION GetOBSERVATION(int rep) { 
	   return (OMG_O19_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMG_O19_OBSERVATION 
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
	 * Enumerate over the OMG_O19_OBSERVATION results 
	 */ 
	public IEnumerable<OMG_O19_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OMG_O19_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMG_O19_OBSERVATION
	///</summary>
	public OMG_O19_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as OMG_O19_OBSERVATION;
	}

	///<summary>
	///Removes the given OMG_O19_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(OMG_O19_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OMG_O19_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of OMG_O19_SPECIMEN (a Group object) - creates it if necessary
	///</summary>
	public OMG_O19_SPECIMEN GetSPECIMEN() {
	   OMG_O19_SPECIMEN ret = null;
	   try {
	      ret = (OMG_O19_SPECIMEN)this.GetStructure("SPECIMEN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMG_O19_SPECIMEN
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMG_O19_SPECIMEN GetSPECIMEN(int rep) { 
	   return (OMG_O19_SPECIMEN)this.GetStructure("SPECIMEN", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMG_O19_SPECIMEN 
	 */ 
	public int SPECIMENRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OMG_O19_SPECIMEN results 
	 */ 
	public IEnumerable<OMG_O19_SPECIMEN> SPECIMENs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMENRepetitionsUsed; rep++)
			{
				yield return (OMG_O19_SPECIMEN)this.GetStructure("SPECIMEN", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMG_O19_SPECIMEN
	///</summary>
	public OMG_O19_SPECIMEN AddSPECIMEN()
	{
		return this.AddStructure("SPECIMEN") as OMG_O19_SPECIMEN;
	}

	///<summary>
	///Removes the given OMG_O19_SPECIMEN
	///</summary>
	public void RemoveSPECIMEN(OMG_O19_SPECIMEN toRemove)
	{
		this.RemoveStructure("SPECIMEN", toRemove);
	}

	///<summary>
	///Removes the OMG_O19_SPECIMEN at the given index
	///</summary>
	public void RemoveSPECIMENAt(int index)
	{
		this.RemoveRepetition("SPECIMEN", index);
	}

	///<summary>
	/// Returns  first repetition of OMG_O19_PRIOR_RESULT (a Group object) - creates it if necessary
	///</summary>
	public OMG_O19_PRIOR_RESULT GetPRIOR_RESULT() {
	   OMG_O19_PRIOR_RESULT ret = null;
	   try {
	      ret = (OMG_O19_PRIOR_RESULT)this.GetStructure("PRIOR_RESULT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMG_O19_PRIOR_RESULT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMG_O19_PRIOR_RESULT GetPRIOR_RESULT(int rep) { 
	   return (OMG_O19_PRIOR_RESULT)this.GetStructure("PRIOR_RESULT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMG_O19_PRIOR_RESULT 
	 */ 
	public int PRIOR_RESULTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRIOR_RESULT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OMG_O19_PRIOR_RESULT results 
	 */ 
	public IEnumerable<OMG_O19_PRIOR_RESULT> PRIOR_RESULTs 
	{ 
		get
		{
			for (int rep = 0; rep < PRIOR_RESULTRepetitionsUsed; rep++)
			{
				yield return (OMG_O19_PRIOR_RESULT)this.GetStructure("PRIOR_RESULT", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMG_O19_PRIOR_RESULT
	///</summary>
	public OMG_O19_PRIOR_RESULT AddPRIOR_RESULT()
	{
		return this.AddStructure("PRIOR_RESULT") as OMG_O19_PRIOR_RESULT;
	}

	///<summary>
	///Removes the given OMG_O19_PRIOR_RESULT
	///</summary>
	public void RemovePRIOR_RESULT(OMG_O19_PRIOR_RESULT toRemove)
	{
		this.RemoveStructure("PRIOR_RESULT", toRemove);
	}

	///<summary>
	///Removes the OMG_O19_PRIOR_RESULT at the given index
	///</summary>
	public void RemovePRIOR_RESULTAt(int index)
	{
		this.RemoveRepetition("PRIOR_RESULT", index);
	}

	///<summary>
	/// Returns  first repetition of FT1 (Financial Transaction) - creates it if necessary
	///</summary>
	public FT1 GetFT1() {
	   FT1 ret = null;
	   try {
	      ret = (FT1)this.GetStructure("FT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of FT1
	/// * (Financial Transaction) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public FT1 GetFT1(int rep) { 
	   return (FT1)this.GetStructure("FT1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of FT1 
	 */ 
	public int FT1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FT1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the FT1 results 
	 */ 
	public IEnumerable<FT1> FT1s 
	{ 
		get
		{
			for (int rep = 0; rep < FT1RepetitionsUsed; rep++)
			{
				yield return (FT1)this.GetStructure("FT1", rep);
			}
		}
	}

	///<summary>
	///Adds a new FT1
	///</summary>
	public FT1 AddFT1()
	{
		return this.AddStructure("FT1") as FT1;
	}

	///<summary>
	///Removes the given FT1
	///</summary>
	public void RemoveFT1(FT1 toRemove)
	{
		this.RemoveStructure("FT1", toRemove);
	}

	///<summary>
	///Removes the FT1 at the given index
	///</summary>
	public void RemoveFT1At(int index)
	{
		this.RemoveRepetition("FT1", index);
	}

	///<summary>
	/// Returns  first repetition of CTI (Clinical Trial Identification) - creates it if necessary
	///</summary>
	public CTI GetCTI() {
	   CTI ret = null;
	   try {
	      ret = (CTI)this.GetStructure("CTI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTI
	/// * (Clinical Trial Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTI GetCTI(int rep) { 
	   return (CTI)this.GetStructure("CTI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTI 
	 */ 
	public int CTIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTI").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CTI results 
	 */ 
	public IEnumerable<CTI> CTIs 
	{ 
		get
		{
			for (int rep = 0; rep < CTIRepetitionsUsed; rep++)
			{
				yield return (CTI)this.GetStructure("CTI", rep);
			}
		}
	}

	///<summary>
	///Adds a new CTI
	///</summary>
	public CTI AddCTI()
	{
		return this.AddStructure("CTI") as CTI;
	}

	///<summary>
	///Removes the given CTI
	///</summary>
	public void RemoveCTI(CTI toRemove)
	{
		this.RemoveStructure("CTI", toRemove);
	}

	///<summary>
	///Removes the CTI at the given index
	///</summary>
	public void RemoveCTIAt(int index)
	{
		this.RemoveRepetition("CTI", index);
	}

	///<summary>
	/// Returns BLG (Billing) - creates it if necessary
	///</summary>
	public BLG BLG { 
get{
	   BLG ret = null;
	   try {
	      ret = (BLG)this.GetStructure("BLG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
