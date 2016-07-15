using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the DEO_O45_DONOR_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: NTE (Notes and Comments) optional repeating</li>
///<li>2: DEO_O45_DONOR_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class DEO_O45_DONOR_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new DEO_O45_DONOR_ORDER Group.
	///</summary>
	public DEO_O45_DONOR_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(DEO_O45_DONOR_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DEO_O45_DONOR_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of DEO_O45_DONOR_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public DEO_O45_DONOR_OBSERVATION GetDONOR_OBSERVATION() {
	   DEO_O45_DONOR_OBSERVATION ret = null;
	   try {
	      ret = (DEO_O45_DONOR_OBSERVATION)this.GetStructure("DONOR_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DEO_O45_DONOR_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DEO_O45_DONOR_OBSERVATION GetDONOR_OBSERVATION(int rep) { 
	   return (DEO_O45_DONOR_OBSERVATION)this.GetStructure("DONOR_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DEO_O45_DONOR_OBSERVATION 
	 */ 
	public int DONOR_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DONOR_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DEO_O45_DONOR_OBSERVATION results 
	 */ 
	public IEnumerable<DEO_O45_DONOR_OBSERVATION> DONOR_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < DONOR_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (DEO_O45_DONOR_OBSERVATION)this.GetStructure("DONOR_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new DEO_O45_DONOR_OBSERVATION
	///</summary>
	public DEO_O45_DONOR_OBSERVATION AddDONOR_OBSERVATION()
	{
		return this.AddStructure("DONOR_OBSERVATION") as DEO_O45_DONOR_OBSERVATION;
	}

	///<summary>
	///Removes the given DEO_O45_DONOR_OBSERVATION
	///</summary>
	public void RemoveDONOR_OBSERVATION(DEO_O45_DONOR_OBSERVATION toRemove)
	{
		this.RemoveStructure("DONOR_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the DEO_O45_DONOR_OBSERVATION at the given index
	///</summary>
	public void RemoveDONOR_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("DONOR_OBSERVATION", index);
	}

}
}
