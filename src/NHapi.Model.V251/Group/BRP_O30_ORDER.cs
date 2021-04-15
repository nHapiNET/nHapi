using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the BRP_O30_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: BRP_O30_TIMING (a Group object) optional repeating</li>
///<li>2: BPO (Blood product order) optional </li>
///<li>3: BPX (Blood product dispense status) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class BRP_O30_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new BRP_O30_ORDER Group.
	///</summary>
	public BRP_O30_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(BRP_O30_TIMING), false, true);
	      this.add(typeof(BPO), false, false);
	      this.add(typeof(BPX), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating BRP_O30_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of BRP_O30_TIMING (a Group object) - creates it if necessary
	///</summary>
	public BRP_O30_TIMING GetTIMING() {
	   BRP_O30_TIMING ret = null;
	   try {
	      ret = (BRP_O30_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BRP_O30_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BRP_O30_TIMING GetTIMING(int rep) { 
	   return (BRP_O30_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BRP_O30_TIMING 
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
	 * Enumerate over the BRP_O30_TIMING results 
	 */ 
	public IEnumerable<BRP_O30_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (BRP_O30_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new BRP_O30_TIMING
	///</summary>
	public BRP_O30_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as BRP_O30_TIMING;
	}

	///<summary>
	///Removes the given BRP_O30_TIMING
	///</summary>
	public void RemoveTIMING(BRP_O30_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the BRP_O30_TIMING at the given index
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
	/// Returns  first repetition of BPX (Blood product dispense status) - creates it if necessary
	///</summary>
	public BPX GetBPX() {
	   BPX ret = null;
	   try {
	      ret = (BPX)this.GetStructure("BPX");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BPX
	/// * (Blood product dispense status) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BPX GetBPX(int rep) { 
	   return (BPX)this.GetStructure("BPX", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BPX 
	 */ 
	public int BPXRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("BPX").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the BPX results 
	 */ 
	public IEnumerable<BPX> BPXs 
	{ 
		get
		{
			for (int rep = 0; rep < BPXRepetitionsUsed; rep++)
			{
				yield return (BPX)this.GetStructure("BPX", rep);
			}
		}
	}

	///<summary>
	///Adds a new BPX
	///</summary>
	public BPX AddBPX()
	{
		return this.AddStructure("BPX") as BPX;
	}

	///<summary>
	///Removes the given BPX
	///</summary>
	public void RemoveBPX(BPX toRemove)
	{
		this.RemoveStructure("BPX", toRemove);
	}

	///<summary>
	///Removes the BPX at the given index
	///</summary>
	public void RemoveBPXAt(int index)
	{
		this.RemoveRepetition("BPX", index);
	}

}
}
