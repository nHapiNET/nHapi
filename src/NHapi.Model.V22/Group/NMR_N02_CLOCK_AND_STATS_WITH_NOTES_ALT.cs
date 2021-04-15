using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V22.Segment;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V22.Group
{
///<summary>
///Represents the NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: NCK (System Clock) optional </li>
///<li>1: NTE (NOTES AND COMMENTS) optional repeating</li>
///<li>2: NST (Statistics) optional </li>
///<li>3: NTE (NOTES AND COMMENTS) optional repeating</li>
///<li>4: NSC (STATUS CHANGE) optional </li>
///<li>5: NTE (NOTES AND COMMENTS) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT : AbstractGroup {

	///<summary> 
	/// Creates a new NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT Group.
	///</summary>
	public NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(NCK), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(NST), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(NSC), false, false);
	      this.add(typeof(NTE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns NCK (System Clock) - creates it if necessary
	///</summary>
	public NCK NCK { 
get{
	   NCK ret = null;
	   try {
	      ret = (NCK)this.GetStructure("NCK");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE (NOTES AND COMMENTS) - creates it if necessary
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
	/// * (NOTES AND COMMENTS) - creates it if necessary
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
	/// Returns NST (Statistics) - creates it if necessary
	///</summary>
	public NST NST { 
get{
	   NST ret = null;
	   try {
	      ret = (NST)this.GetStructure("NST");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE2 (NOTES AND COMMENTS) - creates it if necessary
	///</summary>
	public NTE GetNTE2() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE2
	/// * (NOTES AND COMMENTS) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE2(int rep) { 
	   return (NTE)this.GetStructure("NTE2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE2 
	 */ 
	public int NTE2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE2").Length; 
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
	public IEnumerable<NTE> NTE2s 
	{ 
		get
		{
			for (int rep = 0; rep < NTE2RepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE2", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE2()
	{
		return this.AddStructure("NTE2") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE2(NTE toRemove)
	{
		this.RemoveStructure("NTE2", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTE2At(int index)
	{
		this.RemoveRepetition("NTE2", index);
	}

	///<summary>
	/// Returns NSC (STATUS CHANGE) - creates it if necessary
	///</summary>
	public NSC NSC { 
get{
	   NSC ret = null;
	   try {
	      ret = (NSC)this.GetStructure("NSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE3 (NOTES AND COMMENTS) - creates it if necessary
	///</summary>
	public NTE GetNTE3() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE3");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE3
	/// * (NOTES AND COMMENTS) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE3(int rep) { 
	   return (NTE)this.GetStructure("NTE3", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE3 
	 */ 
	public int NTE3RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE3").Length; 
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
	public IEnumerable<NTE> NTE3s 
	{ 
		get
		{
			for (int rep = 0; rep < NTE3RepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE3", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE3()
	{
		return this.AddStructure("NTE3") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE3(NTE toRemove)
	{
		this.RemoveStructure("NTE3", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTE3At(int index)
	{
		this.RemoveRepetition("NTE3", index);
	}

}
}
