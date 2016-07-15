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
///Represents the DPR_O48_BLOOD_UNIT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: BUI (Blood Unit Information) optional repeating</li>
///<li>1: NTE (Notes and Comments) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class DPR_O48_BLOOD_UNIT : AbstractGroup {

	///<summary> 
	/// Creates a new DPR_O48_BLOOD_UNIT Group.
	///</summary>
	public DPR_O48_BLOOD_UNIT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(BUI), false, true);
	      this.add(typeof(NTE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DPR_O48_BLOOD_UNIT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns  first repetition of BUI (Blood Unit Information) - creates it if necessary
	///</summary>
	public BUI GetBUI() {
	   BUI ret = null;
	   try {
	      ret = (BUI)this.GetStructure("BUI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BUI
	/// * (Blood Unit Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BUI GetBUI(int rep) { 
	   return (BUI)this.GetStructure("BUI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BUI 
	 */ 
	public int BUIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("BUI").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the BUI results 
	 */ 
	public IEnumerable<BUI> BUIs 
	{ 
		get
		{
			for (int rep = 0; rep < BUIRepetitionsUsed; rep++)
			{
				yield return (BUI)this.GetStructure("BUI", rep);
			}
		}
	}

	///<summary>
	///Adds a new BUI
	///</summary>
	public BUI AddBUI()
	{
		return this.AddStructure("BUI") as BUI;
	}

	///<summary>
	///Removes the given BUI
	///</summary>
	public void RemoveBUI(BUI toRemove)
	{
		this.RemoveStructure("BUI", toRemove);
	}

	///<summary>
	///Removes the BUI at the given index
	///</summary>
	public void RemoveBUIAt(int index)
	{
		this.RemoveRepetition("BUI", index);
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

}
}
