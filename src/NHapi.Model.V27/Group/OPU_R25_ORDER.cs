using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V27.Segment;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the OPU_R25_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: ORC (Common Order) optional </li>
///<li>2: NTE (Notes and Comments) optional repeating</li>
///<li>3: PRT (Participation Information) optional repeating</li>
///<li>4: OPU_R25_TIMING_QTY (a Group object) optional repeating</li>
///<li>5: OPU_R25_RESULT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPU_R25_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new OPU_R25_ORDER Group.
	///</summary>
	public OPU_R25_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OPU_R25_TIMING_QTY), false, true);
	      this.add(typeof(OPU_R25_RESULT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPU_R25_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OPU_R25_TIMING_QTY (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_TIMING_QTY GetTIMING_QTY() {
	   OPU_R25_TIMING_QTY ret = null;
	   try {
	      ret = (OPU_R25_TIMING_QTY)this.GetStructure("TIMING_QTY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_TIMING_QTY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_TIMING_QTY GetTIMING_QTY(int rep) { 
	   return (OPU_R25_TIMING_QTY)this.GetStructure("TIMING_QTY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_TIMING_QTY 
	 */ 
	public int TIMING_QTYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_QTY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPU_R25_TIMING_QTY results 
	 */ 
	public IEnumerable<OPU_R25_TIMING_QTY> TIMING_QTYs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_QTYRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_TIMING_QTY)this.GetStructure("TIMING_QTY", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_TIMING_QTY
	///</summary>
	public OPU_R25_TIMING_QTY AddTIMING_QTY()
	{
		return this.AddStructure("TIMING_QTY") as OPU_R25_TIMING_QTY;
	}

	///<summary>
	///Removes the given OPU_R25_TIMING_QTY
	///</summary>
	public void RemoveTIMING_QTY(OPU_R25_TIMING_QTY toRemove)
	{
		this.RemoveStructure("TIMING_QTY", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_TIMING_QTY at the given index
	///</summary>
	public void RemoveTIMING_QTYAt(int index)
	{
		this.RemoveRepetition("TIMING_QTY", index);
	}

	///<summary>
	/// Returns  first repetition of OPU_R25_RESULT (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_RESULT GetRESULT() {
	   OPU_R25_RESULT ret = null;
	   try {
	      ret = (OPU_R25_RESULT)this.GetStructure("RESULT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_RESULT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_RESULT GetRESULT(int rep) { 
	   return (OPU_R25_RESULT)this.GetStructure("RESULT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_RESULT 
	 */ 
	public int RESULTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESULT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPU_R25_RESULT results 
	 */ 
	public IEnumerable<OPU_R25_RESULT> RESULTs 
	{ 
		get
		{
			for (int rep = 0; rep < RESULTRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_RESULT)this.GetStructure("RESULT", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_RESULT
	///</summary>
	public OPU_R25_RESULT AddRESULT()
	{
		return this.AddStructure("RESULT") as OPU_R25_RESULT;
	}

	///<summary>
	///Removes the given OPU_R25_RESULT
	///</summary>
	public void RemoveRESULT(OPU_R25_RESULT toRemove)
	{
		this.RemoveStructure("RESULT", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_RESULT at the given index
	///</summary>
	public void RemoveRESULTAt(int index)
	{
		this.RemoveRepetition("RESULT", index);
	}

}
}
