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
///Represents the BTS_O31_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: PRT (Participation Information) optional repeating</li>
///<li>2: BTS_O31_TIMING (a Group object) optional repeating</li>
///<li>3: BPO (Blood product order) </li>
///<li>4: NTE (Notes and Comments) optional repeating</li>
///<li>5: BTS_O31_PRODUCT_STATUS (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class BTS_O31_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new BTS_O31_ORDER Group.
	///</summary>
	public BTS_O31_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(BTS_O31_TIMING), false, true);
	      this.add(typeof(BPO), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(BTS_O31_PRODUCT_STATUS), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating BTS_O31_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of BTS_O31_TIMING (a Group object) - creates it if necessary
	///</summary>
	public BTS_O31_TIMING GetTIMING() {
	   BTS_O31_TIMING ret = null;
	   try {
	      ret = (BTS_O31_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BTS_O31_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BTS_O31_TIMING GetTIMING(int rep) { 
	   return (BTS_O31_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BTS_O31_TIMING 
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
	 * Enumerate over the BTS_O31_TIMING results 
	 */ 
	public IEnumerable<BTS_O31_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (BTS_O31_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new BTS_O31_TIMING
	///</summary>
	public BTS_O31_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as BTS_O31_TIMING;
	}

	///<summary>
	///Removes the given BTS_O31_TIMING
	///</summary>
	public void RemoveTIMING(BTS_O31_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the BTS_O31_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

	///<summary>
	/// Returns BPO (Blood product order) - creates it if necessary
	///</summary>
	public BPO BPO { 
get{
	   BPO ret = null;
	   try {
	      ret = (BPO)this.GetStructure("BPO");
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
	/// Returns  first repetition of BTS_O31_PRODUCT_STATUS (a Group object) - creates it if necessary
	///</summary>
	public BTS_O31_PRODUCT_STATUS GetPRODUCT_STATUS() {
	   BTS_O31_PRODUCT_STATUS ret = null;
	   try {
	      ret = (BTS_O31_PRODUCT_STATUS)this.GetStructure("PRODUCT_STATUS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BTS_O31_PRODUCT_STATUS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BTS_O31_PRODUCT_STATUS GetPRODUCT_STATUS(int rep) { 
	   return (BTS_O31_PRODUCT_STATUS)this.GetStructure("PRODUCT_STATUS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BTS_O31_PRODUCT_STATUS 
	 */ 
	public int PRODUCT_STATUSRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRODUCT_STATUS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the BTS_O31_PRODUCT_STATUS results 
	 */ 
	public IEnumerable<BTS_O31_PRODUCT_STATUS> PRODUCT_STATUSs 
	{ 
		get
		{
			for (int rep = 0; rep < PRODUCT_STATUSRepetitionsUsed; rep++)
			{
				yield return (BTS_O31_PRODUCT_STATUS)this.GetStructure("PRODUCT_STATUS", rep);
			}
		}
	}

	///<summary>
	///Adds a new BTS_O31_PRODUCT_STATUS
	///</summary>
	public BTS_O31_PRODUCT_STATUS AddPRODUCT_STATUS()
	{
		return this.AddStructure("PRODUCT_STATUS") as BTS_O31_PRODUCT_STATUS;
	}

	///<summary>
	///Removes the given BTS_O31_PRODUCT_STATUS
	///</summary>
	public void RemovePRODUCT_STATUS(BTS_O31_PRODUCT_STATUS toRemove)
	{
		this.RemoveStructure("PRODUCT_STATUS", toRemove);
	}

	///<summary>
	///Removes the BTS_O31_PRODUCT_STATUS at the given index
	///</summary>
	public void RemovePRODUCT_STATUSAt(int index)
	{
		this.RemoveRepetition("PRODUCT_STATUS", index);
	}

}
}
