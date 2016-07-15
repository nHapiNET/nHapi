using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V24.Segment;
using NHapi.Model.V24.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Group
{
///<summary>
///Represents the OML_O21_OBSERVATION_REQUEST Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: OML_O21_CONTAINER_2 (a Group object) optional repeating</li>
///<li>2: TCD (Test Code Detail) optional </li>
///<li>3: NTE (Notes and Comments) optional repeating</li>
///<li>4: DG1 (Diagnosis) optional repeating</li>
///<li>5: OML_O21_OBSERVATION (a Group object) optional repeating</li>
///<li>6: OML_O21_PRIOR_RESULT (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OML_O21_OBSERVATION_REQUEST : AbstractGroup {

	///<summary> 
	/// Creates a new OML_O21_OBSERVATION_REQUEST Group.
	///</summary>
	public OML_O21_OBSERVATION_REQUEST(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(OML_O21_CONTAINER_2), false, true);
	      this.add(typeof(TCD), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(DG1), false, true);
	      this.add(typeof(OML_O21_OBSERVATION), false, true);
	      this.add(typeof(OML_O21_PRIOR_RESULT), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OML_O21_OBSERVATION_REQUEST - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OML_O21_CONTAINER_2 (a Group object) - creates it if necessary
	///</summary>
	public OML_O21_CONTAINER_2 GetCONTAINER_2() {
	   OML_O21_CONTAINER_2 ret = null;
	   try {
	      ret = (OML_O21_CONTAINER_2)this.GetStructure("CONTAINER_2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O21_CONTAINER_2
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O21_CONTAINER_2 GetCONTAINER_2(int rep) { 
	   return (OML_O21_CONTAINER_2)this.GetStructure("CONTAINER_2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O21_CONTAINER_2 
	 */ 
	public int CONTAINER_2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CONTAINER_2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OML_O21_CONTAINER_2 results 
	 */ 
	public IEnumerable<OML_O21_CONTAINER_2> CONTAINER_2s 
	{ 
		get
		{
			for (int rep = 0; rep < CONTAINER_2RepetitionsUsed; rep++)
			{
				yield return (OML_O21_CONTAINER_2)this.GetStructure("CONTAINER_2", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O21_CONTAINER_2
	///</summary>
	public OML_O21_CONTAINER_2 AddCONTAINER_2()
	{
		return this.AddStructure("CONTAINER_2") as OML_O21_CONTAINER_2;
	}

	///<summary>
	///Removes the given OML_O21_CONTAINER_2
	///</summary>
	public void RemoveCONTAINER_2(OML_O21_CONTAINER_2 toRemove)
	{
		this.RemoveStructure("CONTAINER_2", toRemove);
	}

	///<summary>
	///Removes the OML_O21_CONTAINER_2 at the given index
	///</summary>
	public void RemoveCONTAINER_2At(int index)
	{
		this.RemoveRepetition("CONTAINER_2", index);
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
	/// Returns  first repetition of OML_O21_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OML_O21_OBSERVATION GetOBSERVATION() {
	   OML_O21_OBSERVATION ret = null;
	   try {
	      ret = (OML_O21_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O21_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O21_OBSERVATION GetOBSERVATION(int rep) { 
	   return (OML_O21_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O21_OBSERVATION 
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
	 * Enumerate over the OML_O21_OBSERVATION results 
	 */ 
	public IEnumerable<OML_O21_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OML_O21_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O21_OBSERVATION
	///</summary>
	public OML_O21_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as OML_O21_OBSERVATION;
	}

	///<summary>
	///Removes the given OML_O21_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(OML_O21_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OML_O21_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of OML_O21_PRIOR_RESULT (a Group object) - creates it if necessary
	///</summary>
	public OML_O21_PRIOR_RESULT GetPRIOR_RESULT() {
	   OML_O21_PRIOR_RESULT ret = null;
	   try {
	      ret = (OML_O21_PRIOR_RESULT)this.GetStructure("PRIOR_RESULT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O21_PRIOR_RESULT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O21_PRIOR_RESULT GetPRIOR_RESULT(int rep) { 
	   return (OML_O21_PRIOR_RESULT)this.GetStructure("PRIOR_RESULT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O21_PRIOR_RESULT 
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
	 * Enumerate over the OML_O21_PRIOR_RESULT results 
	 */ 
	public IEnumerable<OML_O21_PRIOR_RESULT> PRIOR_RESULTs 
	{ 
		get
		{
			for (int rep = 0; rep < PRIOR_RESULTRepetitionsUsed; rep++)
			{
				yield return (OML_O21_PRIOR_RESULT)this.GetStructure("PRIOR_RESULT", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O21_PRIOR_RESULT
	///</summary>
	public OML_O21_PRIOR_RESULT AddPRIOR_RESULT()
	{
		return this.AddStructure("PRIOR_RESULT") as OML_O21_PRIOR_RESULT;
	}

	///<summary>
	///Removes the given OML_O21_PRIOR_RESULT
	///</summary>
	public void RemovePRIOR_RESULT(OML_O21_PRIOR_RESULT toRemove)
	{
		this.RemoveStructure("PRIOR_RESULT", toRemove);
	}

	///<summary>
	///Removes the OML_O21_PRIOR_RESULT at the given index
	///</summary>
	public void RemovePRIOR_RESULTAt(int index)
	{
		this.RemoveRepetition("PRIOR_RESULT", index);
	}

}
}
