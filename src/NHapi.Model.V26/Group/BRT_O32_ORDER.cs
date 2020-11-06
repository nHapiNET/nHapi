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
///Represents the BRT_O32_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: BRT_O32_TIMING (a Group object) optional repeating</li>
///<li>2: BPO (Blood product order) optional </li>
///<li>3: BTX (Blood Product Transfusion/Disposition) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class BRT_O32_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new BRT_O32_ORDER Group.
	///</summary>
	public BRT_O32_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(BRT_O32_TIMING), false, true);
	      this.add(typeof(BPO), false, false);
	      this.add(typeof(BTX), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating BRT_O32_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of BRT_O32_TIMING (a Group object) - creates it if necessary
	///</summary>
	public BRT_O32_TIMING GetTIMING() {
	   BRT_O32_TIMING ret = null;
	   try {
	      ret = (BRT_O32_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BRT_O32_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BRT_O32_TIMING GetTIMING(int rep) { 
	   return (BRT_O32_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BRT_O32_TIMING 
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
	 * Enumerate over the BRT_O32_TIMING results 
	 */ 
	public IEnumerable<BRT_O32_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (BRT_O32_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new BRT_O32_TIMING
	///</summary>
	public BRT_O32_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as BRT_O32_TIMING;
	}

	///<summary>
	///Removes the given BRT_O32_TIMING
	///</summary>
	public void RemoveTIMING(BRT_O32_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the BRT_O32_TIMING at the given index
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
	/// Returns  first repetition of BTX (Blood Product Transfusion/Disposition) - creates it if necessary
	///</summary>
	public BTX GetBTX() {
	   BTX ret = null;
	   try {
	      ret = (BTX)this.GetStructure("BTX");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BTX
	/// * (Blood Product Transfusion/Disposition) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BTX GetBTX(int rep) { 
	   return (BTX)this.GetStructure("BTX", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BTX 
	 */ 
	public int BTXRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("BTX").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the BTX results 
	 */ 
	public IEnumerable<BTX> BTXs 
	{ 
		get
		{
			for (int rep = 0; rep < BTXRepetitionsUsed; rep++)
			{
				yield return (BTX)this.GetStructure("BTX", rep);
			}
		}
	}

	///<summary>
	///Adds a new BTX
	///</summary>
	public BTX AddBTX()
	{
		return this.AddStructure("BTX") as BTX;
	}

	///<summary>
	///Removes the given BTX
	///</summary>
	public void RemoveBTX(BTX toRemove)
	{
		this.RemoveStructure("BTX", toRemove);
	}

	///<summary>
	///Removes the BTX at the given index
	///</summary>
	public void RemoveBTXAt(int index)
	{
		this.RemoveRepetition("BTX", index);
	}

}
}
